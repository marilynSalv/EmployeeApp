using EmployeeApp.Dal.Dtos;
using EmployeeApp.Dal.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Services;

public class ManagerSearchService : IManagerSearchService
{
    private readonly IManagerSearchRepository _managerSearchRepository;
    public ManagerSearchService(IManagerSearchRepository managerSearchRepository)
    {
        _managerSearchRepository = managerSearchRepository;
    }

    public Task<List<ManagerSearchDto>> ManagerSearch(string searchValue)
    {
        return _managerSearchRepository.ManagerSearch(searchValue);
    }
}
