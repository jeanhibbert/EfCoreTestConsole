using Microsoft.EntityFrameworkCore;

namespace EfCoreTest.Persistence.Infrastructure
{
    public class ContextModelBase : IContextModelBase
    {
        public readonly DbContext _dbContext;

        public ContextModelBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}