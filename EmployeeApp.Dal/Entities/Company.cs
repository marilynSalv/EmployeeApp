using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Dal.Entities
{
    [Table("Company", Schema = "dbo")]

    public class Company
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(400)]
        public string Industry { get; set; }

        [StringLength(400)]
        public string Market { get; set; }

        [StringLength(50)]
        public string Symbol { get; set; }
    }
}
