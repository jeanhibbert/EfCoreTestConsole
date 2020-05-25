using Microsoft.EntityFrameworkCore;
using System;

namespace EfCoreTest.Persistence.Infrastructure.Core
{
    internal class DefaultDbContextFactory<TContext> : IDbContextFactory<TContext> where TContext : DbContext
    {
        private DbContextOptions<TContext> options;
        private Func<DbContextOptions<TContext>, TContext> createFn;

        public DefaultDbContextFactory(DbContextOptions<TContext> options, Func<DbContextOptions<TContext>, TContext> createFn)
        {
            this.options = options;
            this.createFn = createFn;
        }

        public TContext Create()
        {
            return createFn(options);
        }
    }
}