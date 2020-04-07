using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL_Test_Task.Services;
using DAL_Test_Task.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Existek_WPF_Test_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonContactController : Controller
    {
        private readonly IPersonContactService personContactService;

        public PersonContactController(IPersonContactService personContactService)
        {
            this.personContactService = personContactService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<PersonContact> Get(int id)
        {
            return await personContactService.Get(id);
        }

        [HttpGet]
        public IEnumerable<PersonContact> Get()
        {
            return personContactService.Get();
        }

        [HttpPost]
        public async Task<PersonContact> Add([FromBody] PersonContact personContact)
        {
            return await personContactService.Add(personContact);
        }

        [HttpPut]
        public async Task<PersonContact> Update([FromBody] PersonContact personContact)
        {
            return await personContactService.Update(personContact);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await personContactService.Delete(id);
        }
    }
}
