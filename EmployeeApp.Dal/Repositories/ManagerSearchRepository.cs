using EmployeeApp.Dal.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApp.Domain.Interfaces.Repositories;
using EmployeeApp.Domain.ValueObjects;
namespace EmployeeApp.Infrastructure.Repositories;

public class ManagerSearchRepository : IManagerSearchRepository
{
    private readonly PlayGroundContext _context;
    public ManagerSearchRepository(PlayGroundContext context)
    {
        _context = context;
    }

    public async Task<List<ManagerSearch>>  ManagerSearch(string searchValue)
    {
        var results = await _context.ApplicationUsers
            .Where(x => x.IsManager)
            .Where(x => x.FirstName.Contains(searchValue) || x.LastName.Contains(searchValue) || x.UserName.Contains(searchValue))
            .Select(x => new ManagerSearch
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CompanyName = x.Company.Name,
            })
            .ToListAsync();

        return results;
    }
}
