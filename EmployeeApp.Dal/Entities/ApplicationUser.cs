using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Infrastructure.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    [StringLength(300)]
    public required string FirstName { get; set; }

    [StringLength(400)]
    public required string LastName { get; set; }

    [StringLength(5)]
    public required string ZipCode { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiration { get; set; }
    public DateTime? RefreshTokenCreatedOn { get; set; }
    public bool? RefreshTokenValid { get; set; }
    public Guid? CompanyId { get; set; }
    public bool IsManager { get; set; }
    public Guid? ManagerId { get; set; }
    public FileEntity? Photo { get; set; }

    [ForeignKey("ManagerId")]
    public virtual ApplicationUser Manager { get; set; }

    [ForeignKey("CompanyId")]
    public virtual CompanyEntity Company { get; set; }
}

internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasOne(user => user.Photo)
            .WithOne()
            .HasForeignKey<FileEntity>(file => file.UserId)
            .IsRequired(false);
    }
}