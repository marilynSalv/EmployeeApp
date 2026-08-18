using EmployeeApp.Application.Dtos;
using EmployeeApp.Domain.Interfaces.Repositories;
using EmployeeApp.Domain.ValueObjects;

namespace EmployeeApp.Application.Services;

public class ManagerSearchService : IManagerSearchService
{
    private readonly IManagerSearchRepository _managerSearchRepository;
    public ManagerSearchService(IManagerSearchRepository managerSearchRepository)
    {
        _managerSearchRepository = managerSearchRepository;
    }

    public Task<List<ManagerSearch>> ManagerSearch(string searchValue)
    {
        return _managerSearchRepository.ManagerSearch(searchValue);
    }
}
