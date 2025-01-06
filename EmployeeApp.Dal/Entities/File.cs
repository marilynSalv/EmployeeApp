using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Dal.Entities;

[Table("File", Schema = "dbo")]
public class File
{
    [Key]
    public Guid Id { get; set; }
    public byte[] Bytes { get; set; }
    public string Description { get; set; }
    public string FileExtension { get; set; }
    public string FileName { get; set; }
    public DateTime CreatedOn { get; set; }
    public int? ApplicationUserId { get; set; }
}
    