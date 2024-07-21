using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("EmploymentStatus")]
    public class EmploymentStatus
    {
        public int ID { get; set; }
        [Column("ID_student"), ForeignKey("Student")] public int IDStudent { get; set; }
        [Column("start_date", TypeName = "date"), DataType(DataType.Date)] public DateTime StartDate { get; set; }
        [Column("type_employment")] public typeemployment TypeEmployment { get; set; }

        //public Student Student { get; set; } = default!;
        public ICollection<Jobs> Jobs { get; set; } = default!;
        public ICollection<MilitaryService> MilitaryServices { get; set; } = default!;
        public ICollection<SelfEmployment> SelfEmployment { get; set; } = default!;
    }
}
