using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EfCoreTest.Persistence.Infrastructure
{
    public class ContextModelBase : IContextModelBase
    {
        private readonly DbContext _dbContext;

        public ContextModelBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> SaveChangesAsync()
        {
            // exception handling
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}