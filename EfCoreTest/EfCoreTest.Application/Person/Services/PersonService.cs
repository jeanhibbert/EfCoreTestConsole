using EfCoreTest.Application.Person.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EfCoreTest.Application.Person.Services
{
    public class PersonService
    {
        private readonly PersonLoader _personLoader;

        public PersonService(PersonLoader personLoader)
        {
            _personLoader = personLoader;
        }

        public async Task<IEnumerable<PersonDto>> GetAllPersons(CancellationToken cancellationToken)
        {
            // validation

            return await _personLoader.GetAllPersons(cancellationToken);
        }
    }
}
