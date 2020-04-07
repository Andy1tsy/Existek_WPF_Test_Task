using DAL_Test_Task.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Test_Task.Abstract
{
    public interface ICountryService
    {
        Task<Country> Get(string code);
        IEnumerable<Country> Get();
        Task<Country> Add(Country country);
        Task<Country> Update(Country country);
        Task<bool> Delete(string code);
    }
}
