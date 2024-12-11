using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Dal.Dtos;

public abstract class EmployeeDto
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string FirstName { get; set; }


    [Required]
    public string LastName { get; set; }

    [Required]
    [MaxLength(5)]
    public string ZipCode { get; set; }

    public int? CompanyId { get; set; }
    public int? ManagerId { get; set; }
    public bool IsManager { get; set; }
}
