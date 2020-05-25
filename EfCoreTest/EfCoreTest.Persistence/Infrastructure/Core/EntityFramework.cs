using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreTest.Persistence.Infrastructure.Core
{
    public static class EntityFramework
    {
        public static IDbContextFactory<TContext> DefaultFactory<TContext>(
            DbContextOptions<TContext> options,
            Func<DbContextOptions<TContext>, TContext> createFn) where TContext : DbContext
        {
            return new DefaultDbContextFactory<TContext>(options, createFn);
        }
    }
}
