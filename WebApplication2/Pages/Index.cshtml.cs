using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.ViewModel;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public IndexModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)] public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Student> studentsQuery = _context.Student.Include(s => s.Specialty).Include(s => s.Address);

            if (!string.IsNullOrEmpty(SearchString))
            {
                studentsQuery = studentsQuery.Where(s => s.FullName.Contains(SearchString));
            }

            Students = await studentsQuery.ToListAsync();

            if (_context.Specialty != null)
            {
                Specialties = await _context.Specialty.ToListAsync();
                Console.WriteLine(Specialties);
                //SpecialtyDictionary = Specialties.ToDictionary(a => a.CodeSpecialty, s => s.NameSpecialty);
            }
        }

        public IList<Student> Students { get; set; } = default!;
        public IList<Specialty> Specialties { get; set; } = default!;
        // public IDictionary<int, string> SpecialtyDictionary { get; set; } // один из способов сопоставить данные между студентом и специальностью
        [BindProperty] public Address Address { get; set; } = default!;
        [BindProperty] public StudentViewModel Student { get; set; } = default!;

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!ModelState.IsValid || Student == null || Address == null)
            {
                return NotFound();
            }

            _context.Address.Add(Address);
            await _context.SaveChangesAsync();
            
            var newStudent = new Student
            {
                FullName = Student.FullName,
                Birthday = Student.Birthday,
                Gender = Student.Gender,
                Nationality = Student.Nationality,
                IDResidentialAddress = Address.ID,
                PhoneNumber = Student.PhoneNumber,
                Email = Student.Email,
                SNILS = Student.SNILS,
                CodeSpecialty = Student.CodeSpecialty,
                YearAdmission = Student.YearAdmission,
                YearGraduation = Student.YearGraduation,
                FormEducation = Student.FormEducation
            };

            _context.Student.Add(newStudent);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? studentId)
        {
            if (studentId == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Address)
                .FirstOrDefaultAsync(m => m.ID == studentId);

            if (student != null && student.Address != null)
            {
                _context.Address.Remove(student.Address);
                _context.Student.Remove(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}