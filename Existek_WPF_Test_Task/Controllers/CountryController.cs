using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL_Test_Task.Abstract;
using DAL_Test_Task.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Existek_WPF_Test_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {

            private readonly ICountryService countryService;

            public CountryController(ICountryService countryService)
            {
                this.countryService = countryService;
            }

            [HttpGet]
            [Route("{code}")]
            public async Task<Country> Get(string code)
            {
                return await countryService.Get(code);
            }

            [HttpGet]
            public IEnumerable<Country> Get()
            {
                return countryService.Get();
            }

            [HttpPost]
            public async Task<Country> Add([FromBody] Country country)
            {
                return await countryService.Add(country);
            }

            [HttpPut]
            public async Task<Country> Update([FromBody] Country country)
            {
                return await countryService.Update(country);
            }

            [HttpDelete]
            [Route("{code}")]
            public async Task<bool> Delete(string code)
            {
                return await countryService.Delete(code);
            }
        }
    }

