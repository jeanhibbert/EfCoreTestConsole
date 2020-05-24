using EfCoreTest.Application.Person.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EfCoreTest.Application.Person.Services
{
    public interface IPersonLoader
    {
        Task<IEnumerable<PersonDto>> GetAllPersons();
    }

    public class PersonLoader : IPersonLoader
    {
        public async Task<IEnumerable<PersonDto>> GetAllPersons()
        {
            throw new System.NotImplementedException();
        }
    }
}