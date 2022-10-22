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
                    ZipCode = x.ZipCode,
                    CompanyName = x.Company.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                })
                .Take(10)
                .ToListAsync();

            return result;
        }

        public async Task<int> Update(UpdateEmployeeDto employeeDto)
        {
            var entity = await _context.ApplicationUsers
                .Where(x => x.Id == employeeDto.Id)
                .SingleAsync();

            entity.Email = employeeDto.Email;
            entity.ZipCode = employeeDto.ZipCode;

            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
