using EmployeeApp.Dal.Entities;
using System.Collections.Generic;

namespace EmployeeApp.Dal.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> Get();
        int Update(int id, string firstName);
    }
}
