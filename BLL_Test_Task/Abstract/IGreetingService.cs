using DAL_Test_Task.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL_Test_Task.Services
{
    public interface IGreetingService
    {
        Task<Greeting> Add(Greeting greeting);
        Task<bool> Delete(int id);
        IEnumerable<Greeting> Get();
        Task<Greeting> Get(int id);
        Task<Greeting> Update(Greeting greeting);
    }
}