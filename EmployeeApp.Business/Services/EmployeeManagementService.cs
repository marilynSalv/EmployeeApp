using EmployeeApp.Dal.Dtos;
using EmployeeApp.Dal.Repositories;

namespace EmployeeApp.Business.Services;

public class EmployeeManagementService : IEmployeeManagementService
{
    private readonly IEmployeeManagementRepository _employeeManagementRepository;

    public EmployeeManagementService(IEmployeeManagementRepository employeeManagementRepository)
    {
        _employeeManagementRepository = employeeManagementRepository;
    }

    public async Task<List<EmployeeManagementDto>> GetEmployees()
    {
        return await _employeeManagementRepository.Get();
    }

    public async Task<int> UpdateEmployee(UpdateEmployeeDto dto)
    {
        return await _employeeManagementRepository.Update(dto);
    }
}
