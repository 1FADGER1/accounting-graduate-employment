namespace WebApplication2.Models
{
    public class Workplace
    {
        public int ID { get; set; }
        public string? Appellation { get; set; } //название изначально неверное должно быть NameOrganization
        public string? OKVED { get; set; }
        public string? INN { get; set; }
        public string? Region { get; set; }

        public ICollection<Jobs> Jobs { get; set; } = default!;
    }
}
