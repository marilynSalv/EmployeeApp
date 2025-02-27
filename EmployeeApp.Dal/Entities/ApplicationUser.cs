﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Dal.Entities;

public class ApplicationUser : IdentityUser<int>
{
    [StringLength(300)]
    public string FirstName { get; set; }

    [StringLength(400)]
    public string LastName { get; set; }

    [StringLength(5)]
    public string ZipCode { get; set; }
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiration { get; set; }
    public DateTime? RefreshTokenCreatedOn { get; set; }
    public bool? RefreshTokenValid { get; set; }
    public int? CompanyId { get; set; }
    public bool IsManager { get; set; }
    public int? ManagerId { get; set; }
    public File? Photo { get; set; }

    [ForeignKey("ManagerId")]
    public virtual ApplicationUser Manager { get; set; }

    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }
}

internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasOne(user => user.Photo)
            .WithOne()
            .HasForeignKey<File>(file => file.ApplicationUserId)
            .IsRequired(false);
    }
}