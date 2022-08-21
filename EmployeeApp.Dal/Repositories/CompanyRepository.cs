using EmployeeApp.Dal.Contexts;
using EmployeeApp.Dal.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly PlayGroundContext _context;
        public CompanyRepository(PlayGroundContext context)
        {
            _context = context;
        }

        public async Task<List<CompanySearchDto>> Search(string searchValue)
        {
            var results = await _context.Companies
                .Where(x => x.Name.Contains(searchValue) || x.Id.ToString() == searchValue)
                .Select(x => new CompanySearchDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Industry = x.Industry,
                })
                .ToListAsync();

            return results;
        }
    }
}
