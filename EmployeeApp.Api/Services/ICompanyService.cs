using EmployeeApp.Dal.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApp.Api.Services
{
    public interface ICompanyService
    {
        Task<List<SelectItemDto>> Search(string searchValue);
    }
}