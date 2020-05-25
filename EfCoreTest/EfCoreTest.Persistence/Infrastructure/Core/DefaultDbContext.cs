using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTest.Persistence.Infrastructure.Core
{
    public class DefaultDbContext<TContext> : IDefaultContext where TContext : DbContext
    {
        private readonly ILogger<DefaultDbContext<TContext>> logger;
        private readonly IDbContextFactory<TContext> factory;

        public DefaultDbContext(ILogger<DefaultDbContext<TContext>> logger, IDbContextFactory<TContext> factory)
        {
            this.logger = logger;
            this.factory = factory;
        }

        public async Task<TResult> Read<TResult>(Func<DbContext, Task<TResult>> fn)
        {
            using (var context = this.factory.Create())
            {
                context.ChangeTracker.LazyLoadingEnabled = false;
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                return await fn(context);
            }
        }

        public async Task<TResult> Write<TResult>(Func<DbContext, Task<TResult>> fn)
        {
            using (var context = this.factory.Create())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var result = await fn(context);
                        await context.SaveChangesAsync();
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public async Task<TResult> WriteOptimistically<TResult>(Func<DbContext, Task<TResult>> fn, int maxSaveAttempts = 10)
        {
            using (var context = this.factory.Create())
            {
                var saved = false;
                var saveAttempts = 0;
                DbUpdateConcurrencyException lastConcurrentException = null;
                while (!saved && (saveAttempts++ < maxSaveAttempts || maxSaveAttempts == -1))
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var result = await fn(context);
                            await context.SaveChangesAsync();
                            transaction.Commit();
                            return result;
                        }
                        catch (DbUpdateConcurrencyException ex)
                        {
                            await transaction.RollbackAsync();
                            logger.LogDebug("Concurrency Failure", ex);
                            lastConcurrentException = ex;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
                throw lastConcurrentException;
            }
        }

    }
}
