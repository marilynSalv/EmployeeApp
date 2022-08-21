using EmployeeApp.Dal.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories;

public interface IManagerSearchRepository
{
    Task<List<ManagerSearchDto>> ManagerSearch(string searchValue);
}