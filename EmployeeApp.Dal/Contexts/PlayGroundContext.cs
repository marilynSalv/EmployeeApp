using EmployeeApp.Dal.Entities;
using EmployeeApp.Dal.Entities.DbQueries;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Dal.Contexts
{
    public class PlayGroundContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {

        public PlayGroundContext(DbContextOptions<PlayGroundContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }

        // Dtos for Db Queries
        public DbSet<TestSprocDto> TestSprocDtos { get; set; }

    }
}
