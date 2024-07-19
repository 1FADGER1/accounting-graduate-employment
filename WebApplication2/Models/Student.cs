using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("GraduateStudent")]
    public class Student
    {
        public int ID { get; set; }
        [Column("full_name")] public string? FullName { get; set; }
        [Column("birth_date", TypeName = "date"), DataType(DataType.Date)] public DateTime Birthday { get; set; }
        [Column("gender", TypeName = "gender")] public gender Gender { get; set; }
        [Column("nationality")] public string? Nationality { get; set; }
        [Column("ID_residential_address")] public int IDResidentialAddress { get; set; }
        [Column("phone_number")] public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? SNILS { get; set; }
        [Column("code_specialty"), ForeignKey("Specialty")] public int CodeSpecialty { get; set; }
        [Column("year_admission", TypeName = "date"), DataType(DataType.Date)] public DateTime YearAdmission { get; set; }
        [Column("year_graduation", TypeName = "date"), DataType(DataType.Date)] public DateTime YearGraduation { get; set; }
        [Column("form_education")] public form_education FormEducation { get; set; }

        public Specialty Specialty { get; set; } = default!;
    }
}
