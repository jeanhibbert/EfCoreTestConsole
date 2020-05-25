using Microsoft.EntityFrameworkCore;

namespace EfCoreTest.Persistence.Infrastructure
{
    public interface IEfCoreTestContextWriteable : IDbContextWriteable
    {
        DbSet<Person> Persons { get; }
    }
}
