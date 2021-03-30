using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Data
{
    public interface IEmployeeRepository
    {
        List<Employee> Get();
        int Update(int id, string firstName);
    }
}
