using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Address
    {
        public int ID { get; set; }
        [Column("country")] public string? Country { get; set; }
        [Column("region")] public string? Region { get; set; }
        [Column("district")] public string? District { get; set; }
        [Column("locality")] public string? Locality { get; set; }
        [Column("city")] public string? City { get; set; }
        [Column("street")] public string? Street { get; set; }
        [Column("house_number")] public string? HouseNumber { get; set; }
        [Column("apartment_number")] public string? ApartmentNumber { get; set; }
    }
}
