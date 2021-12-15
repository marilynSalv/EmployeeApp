using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Dal.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [StringLength(300)]
        public string FirstName { get; set;  }

        [StringLength(400)]
        public string LastName { get; set;  }

        [StringLength(200)]
        public string Email { get; set;  }
    }
}
