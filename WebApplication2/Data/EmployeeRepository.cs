using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PlayGroundContext _context;
        public EmployeeRepository(PlayGroundContext context)
        {
            _context = context;
        }
        public List<Employee> Get()
        {
            var result = _context.Employees.Take(100).ToList();
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
