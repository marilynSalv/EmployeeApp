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

            modelBuilder.Entity<ApplicationUser>().ToTable("asp_net_users"); //represents user
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("asp_net_roles"); //represents role; A role is used to define a user's position or responsibility within a system. example Admin vs user vs manager
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("asp_net_user_claims"); //Represents a claim that a user possesses. Represents specific pieces of information about a user. attribute-based access control. example name, email adddress, permission.
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("asp_net_user_tokens");//Represents an authentication token for a user.
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("asp_net_user_logins"); //Associates a user with a login
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("asp_net_user_roles"); //A join entity that associates users and roles.
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("asp_net_role_claims"); //Represents a claim that's granted to all users within a role.
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<File> Files { get; set; }

        // Dtos for Db Queries
        public DbSet<TestSprocDto> TestSprocDtos { get; set; }

    }
}
