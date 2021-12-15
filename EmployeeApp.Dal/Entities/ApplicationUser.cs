using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Dal.Entities
{
    public class ApplicationUser : IdentityUser
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
    }
}
