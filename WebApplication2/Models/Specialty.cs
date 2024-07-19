using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Specialty
    {
        [Column("code_specialty"), Key] public int CodeSpecialty { get; set; }
        [Column("name_specialty")] public string? NameSpecialty { get; set; }
        [Column("training_profile")] public string? TrainingSpecialty { get; set; }
    }
}
