using EmployeeApp.Dal.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Services
{
    public interface IManagerSearchService
    {
        Task<List<ManagerSearchDto>> ManagerSearch(string searchValue);
    }
}