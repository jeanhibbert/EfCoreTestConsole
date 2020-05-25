using System.Linq;

namespace EfCoreTest.Persistence.Infrastructure
{
    public interface IEfCoreTestContextReadonly : IDbContextReadonly
    {
        IQueryable<Person> Persons { get; }
    }
}
