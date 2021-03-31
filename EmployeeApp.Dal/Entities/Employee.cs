using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Dal.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set;  }
        public string LastName { get; set;  }
        public string Email { get; set;  }
    }
}
