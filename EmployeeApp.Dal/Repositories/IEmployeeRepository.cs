using EmployeeApp.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> Get();
        int Update(int id, string firstName);
    }
}
