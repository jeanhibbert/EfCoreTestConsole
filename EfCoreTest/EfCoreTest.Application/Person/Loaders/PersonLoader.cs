using EfCoreTest.Application.Person.Dtos;
using EfCoreTest.Persistence.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTest.Application.Person.Services
{
    public interface IPersonLoader
    {
        Task<IEnumerable<PersonDto>> GetAllPersons(CancellationToken cancellationToken);
    }

    public class PersonLoader : IPersonLoader
    {
        private readonly IEfCoreTestContextFactory _factory;
        public PersonLoader(IEfCoreTestContextFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<PersonDto>> GetAllPersons(CancellationToken cancellationToken)
        {
            using (var context = _factory.GetDbContextReadonly())
            {
                return await (from person in context.Persons
                             where person.EmailPromotion == 2
                             select new PersonDto 
                             {
                                 FullName = person.FirstName + " " + person.LastName
                             }).ToListAsync(cancellationToken);
            }
        }
    }
}