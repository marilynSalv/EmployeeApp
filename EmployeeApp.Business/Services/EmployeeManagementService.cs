using EmployeeApp.Domain.DomainEntities;
using EmployeeApp.Domain.Interfaces.Repositories;

namespace EmployeeApp.Application.Services;

public class EmployeeManagementService : IEmployeeManagementService
{
    private readonly IEmployeeManagementRepository _employeeManagementRepository;

    public EmployeeManagementService(IEmployeeManagementRepository employeeManagementRepository)
    {
        _employeeManagementRepository = employeeManagementRepository;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        return await _employeeManagementRepository.Get();
    }

    public async Task<Guid> UpdateEmployee(Employee dto)
    {
        return await _employeeManagementRepository.Update(dto);
    }
}
