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

        public async Task<List<SelectItemDto>> Search(SearchDto searchDto)
        {
            var results = await _context.Companies
                .Where(x => x.Name.Contains(searchDto.Value) || x.Id == searchDto.Id)
                .Select(x => new SelectItemDto
                {
                    Id = x.Id,
                    Value = x.Name,
                })
                .ToListAsync();

            return results;
        }
    }
}
