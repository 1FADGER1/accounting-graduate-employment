using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class MilitaryService
    {
        public int ID { get; set; }
        [Column("ID_status"), ForeignKey("EmploymentStatus")] public int IDStatus { get; set; }
        [Column("place_service")] public string? PlaceService { get; set; }
        [Column("post_military")] public string? PostMilitary { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; } = default!;
    }
}
