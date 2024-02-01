using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Dal.Dtos;

public abstract class EmployeeDto
{
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }


    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Zip code is required")]
    [MaxLength(5)]
    public string ZipCode { get; set; }

    public int? CompanyId { get; set; }
    public int? ManagerId { get; set; }
    public bool IsManager { get; set; }
}
