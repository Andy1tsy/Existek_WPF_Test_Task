using DAL_Test_Task.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL_Test_Task.Services
{
    public interface IPersonContactService
    {
        Task<PersonContact> Add(PersonContact personContact);
        Task<bool> Delete(int id);
        IEnumerable<PersonContact> Get();
        Task<PersonContact> Get(int id);
        Task<PersonContact> Update(PersonContact personContact);
    }
}