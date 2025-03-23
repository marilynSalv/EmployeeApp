using EmployeeApp.Dal.Entities;
using EmployeeApp.Dal.Entities.DbQueries;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeApp.Dal.Contexts
{
    public class PlayGroundContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public PlayGroundContext(DbContextOptions<PlayGroundContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlayGroundContext).Assembly);
            modelBuilder.Ignore<TestSprocDto>();

            modelBuilder.Entity<ApplicationUser>().ToTable("asp_net_users");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("asp_net_user_tokens");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("asp_net_user_logins");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("asp_net_user_claims");
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("asp_net_roles");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("asp_net_user_roles");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("asp_net_role_claims");
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<File> Files { get; set; }

        // Dtos for Db Queries
        public DbSet<TestSprocDto> TestSprocDtos { get; set; }

    }
}
