using EmployeeApp.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Dal.Contexts
{
    public class PlayGroundContext: DbContext
    {

        public PlayGroundContext(DbContextOptions<PlayGroundContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }

}
