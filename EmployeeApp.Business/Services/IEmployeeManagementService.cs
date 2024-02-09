using EmployeeApp.Dal.Dtos;

namespace EmployeeApp.Business.Services;

public interface IEmployeeManagementService
{
    Task<List<EmployeeManagementDto>> GetEmployees();
    Task<int> UpdateEmployee(UpdateEmployeeDto dto);
}