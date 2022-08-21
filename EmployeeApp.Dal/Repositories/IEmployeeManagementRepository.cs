using EmployeeApp.Dal.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories
{
    public interface IEmployeeManagementRepository
    {
        Task<List<EmployeeManagementDto>> Get();
        int Update(int id, string firstName);
    }
}
