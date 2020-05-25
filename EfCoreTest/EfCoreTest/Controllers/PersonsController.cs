using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EfCoreTest.Application.Person.Dtos;
using EfCoreTest.Application.Person.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<PersonDto>> Get()
        {
            var personService = new PersonService(null);
            return await personService.GetAllPersons(CancellationToken.None);
        }

    }
}