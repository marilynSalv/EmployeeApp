using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Dal.Dtos
{
    public class RegisterDto : EmployeeDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
