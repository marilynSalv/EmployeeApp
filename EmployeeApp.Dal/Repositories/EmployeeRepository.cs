using EmployeeApp.Dal.Contexts;
using EmployeeApp.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Dal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PlayGroundContext _context;
        public EmployeeRepository(PlayGroundContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> Get()
        {
            var result = await _context.Employees.Take(10).ToListAsync();
            return result;
        }

        public int Update(int id, string firstName)
        {
            var entity = _context.Employees.Where(x => x.Id == id).Single();
            entity.FirstName = firstName;
            _context.SaveChanges();

            return entity.Id;
        }
    }
}
