using Microsoft.EntityFrameworkCore;

namespace EfCoreTest.Persistence.Infrastructure.Core
{
    public interface IDbContextFactory<TContext> where TContext : DbContext
    {
        TContext Create();
    }
}
