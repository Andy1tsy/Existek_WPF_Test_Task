using DAL_Test_Task.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL_Test_Task.Services
{
    public interface IPersonService
    {
        Task<Person> Add(Person person);
        Task<bool> Delete(int id);
        IEnumerable<Person> Get();
        Task<Person> Get(int id);
        Task<Person> Update(Person person);
    }
}