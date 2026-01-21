using EmployeeApp.Dal.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories
{
    public interface IEmployeeManagementRepository
    {
        Task<List<EmployeeManagementDto>> Get();
        Task<Guid> Update(UpdateEmployeeDto employeeDto);
    }
}
