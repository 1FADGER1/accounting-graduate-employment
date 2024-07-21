using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("SelfEmployment")]
    public class SelfEmployment
    {
        public int ID { get; set; }
        [Column("ID_status"), ForeignKey("EmploymentStatus")] public int IDStatus { get; set; }
        [Column("type_activity")] public string? TypeActivity { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; } = default!;
    }
}
