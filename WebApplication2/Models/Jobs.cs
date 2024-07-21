using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Jobs
    {
        public int ID { get; set; }
        [Column("ID_status"), ForeignKey("EmploymentStatus")] public int IDStatus { get; set; }
        [Column("ID_workplace"), ForeignKey("Workplace")] public int? IDWorkplace { get; set; }
        [Column("position")] public string? Position { get; set; }
        [Column("availability_employment")] public bool AvailabilityEmployment { get; set; }

        public Workplace Workplace { get; set; } = default!;
        public EmploymentStatus EmploymentStatus { get; set; } = default!;
    }
}
