﻿using Microsoft.AspNetCore.Identity;

namespace EmployeeApp.Dal.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
    }
}
