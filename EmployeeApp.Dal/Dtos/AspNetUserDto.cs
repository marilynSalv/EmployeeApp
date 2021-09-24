using System;

namespace EmployeeApp.Dal.Dtos
{
    public class AspNetUserDto
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTimeOffset? LockoutEndDate { get; set; }
        public bool LockoutEnabled { get; set; }
    }
}
