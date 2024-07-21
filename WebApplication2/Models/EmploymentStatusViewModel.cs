
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class EmploymentStatusViewModel
    {
        public int ID { get; set; }
        public int IDStudent { get; set; }
        [DataType(DataType.Date)] public DateTime StartDate { get; set; }
        public typeemployment TypeEmployment { get; set; }
    }
}
