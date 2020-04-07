using DAL_Test_Task.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL_Test_Task.Abstract
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get();
        Task<int> Save(IEnumerable<Customer> customers);
    }
}