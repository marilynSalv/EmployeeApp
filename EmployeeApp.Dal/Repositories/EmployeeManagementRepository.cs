using EmployeeApp.Dal.Contexts;
using EmployeeApp.Dal.Dtos;
using EmployeeApp.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories
{
    public class EmployeeManagementRepository : IEmployeeManagementRepository
    {
        private readonly PlayGroundContext _context;
        public EmployeeManagementRepository(PlayGroundContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeManagementDto>> Get()
        {
            var result = await _context.ApplicationUsers
                .Select(x => new EmployeeManagementDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    CompanyId = x.CompanyId,
                    ManagerId = x.ManagerId,
                    IsManager = x.IsManager,

                })
                .Take(10)
                .ToListAsync();

            return result;
        }

        public int Update(int id, string firstName)
        {
            var entity = _context.ApplicationUsers.Where(x => x.Id == id).Single();
            entity.FirstName = firstName;
            _context.SaveChanges();

            return entity.Id;
        }
    }
}
