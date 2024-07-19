using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class EmploymentStatus
    {
        public int ID { get; set; }
        [Column("ID_student")] public int IDStudent { get; set; }
        [Column("start_date"), DataType(DataType.Date)] public DateTime StartDate { get; set; }
        [Column("end_date"), DataType(DataType.Date)] public DateTime EndDate { get; set; }
        [Column("type_employment")] public string? TypeEmployment { get; set; }
    }
}
