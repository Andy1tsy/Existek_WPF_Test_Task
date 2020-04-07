using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL_Test_Task.Services;
using DAL_Test_Task.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Existek_WPF_Test_Task.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PersonController : Controller
        {
            private readonly IPersonService personService;

            public PersonController(IPersonService personService)
            {
                this.personService = personService;
            }

            [HttpGet]
            [Route("{id}")]
            public async Task<Person> Get(int id)
            {
                return await personService.Get(id);
            }

            [HttpGet]
            public IEnumerable<Person> Get()
            {
                return personService.Get();
            }

            [HttpPost]
            public async Task<Person> Add([FromBody] Person person)
            {
                return await personService.Add(person);
            }

            [HttpPut]
            public async Task<Person> Update([FromBody] Person person)
            {
                return await personService.Update(person);
            }

            [HttpDelete]
            [Route("{id}")]
            public async Task<bool> Delete(int id)
            {
                return await personService.Delete(id);
            }
        }
}
