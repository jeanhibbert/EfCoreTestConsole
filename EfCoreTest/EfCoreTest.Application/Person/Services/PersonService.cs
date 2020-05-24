using EfCoreTest.Application.Person.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EfCoreTest.Application.Person.Services
{
    public class PersonService
    {
        private readonly IPersonLoader _personLoader;

        public PersonService(IPersonLoader personLoader)
        {
            _personLoader = personLoader;
        }

        public async Task<IEnumerable<PersonDto>> GetAllPersons()
        {
            // validation

            return await _personLoader.GetAllPersons();
        }
    }
}
