using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class StudentViewModel
    {
        public int ID { get; set; }
        public string? FullName { get; set; }
        [DataType(DataType.Date)] public DateTime Birthday { get; set; }
        public gender Gender { get; set; }
        public string? Nationality { get; set; }
        public int IDResidentialAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? SNILS { get; set; }
        public int CodeSpecialty { get; set; }
        [DataType(DataType.Date)] public DateTime YearAdmission { get; set; }
        [DataType(DataType.Date)] public DateTime YearGraduation { get; set; }
        public form_education FormEducation { get; set; }
    }
}
