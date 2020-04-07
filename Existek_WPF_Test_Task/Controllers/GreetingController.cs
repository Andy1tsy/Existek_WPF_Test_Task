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
    public class GreetingController : Controller
    {
        private readonly IGreetingService greetingService;

        public GreetingController(IGreetingService greetingService)
        {
            this.greetingService = greetingService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Greeting> Get(int id)
        {
            return await greetingService.Get(id);
        }

        [HttpGet]
        public IEnumerable<Greeting> Get()
        {
            return greetingService.Get();
        }

        [HttpPost]
        public async Task<Greeting> Add([FromBody] Greeting greeting)
        {
            return await greetingService.Add(greeting);
        }

        [HttpPut]
        public async Task<Greeting> Update([FromBody] Greeting greeting)
        {
            return await greetingService.Update(greeting);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await greetingService.Delete(id);
        }
    }
}
