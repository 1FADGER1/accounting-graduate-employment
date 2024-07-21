using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public EditModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<Specialty> Specialties { get; set; } = default!;

        [BindProperty] public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (_context.Specialty != null)
            {
                Specialties = await _context.Specialty.ToListAsync();
            }
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.Include(s => s.Address).FirstOrDefaultAsync(m => m.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            Student = student;

            return Page();
        }


        //переписать немного по другому
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine(Student.ID);
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    if (errors.Count > 0)
                    {
                        Console.WriteLine($"{key}: {string.Join(", ", errors.Select(e => e.ErrorMessage))}");
                    }
                }
                return NotFound();
            }
            var studentToUpdate = await _context.Student
            .Include(s => s.Address)
            .FirstOrDefaultAsync(s => s.ID == Student.ID);

            if (studentToUpdate == null)
            {
                Console.WriteLine("ПУСТО");
                return Page();
            }

            studentToUpdate.FullName = Student.FullName;
            studentToUpdate.Birthday = Student.Birthday;
            studentToUpdate.Gender = Student.Gender;
            studentToUpdate.Nationality = Student.Nationality;
            studentToUpdate.PhoneNumber = Student.PhoneNumber;
            studentToUpdate.Email = Student.Email;
            studentToUpdate.SNILS = Student.SNILS;
            studentToUpdate.CodeSpecialty = Student.CodeSpecialty;
            studentToUpdate.YearAdmission = Student.YearAdmission;
            studentToUpdate.YearGraduation = Student.YearGraduation;
            studentToUpdate.FormEducation = Student.FormEducation;

            studentToUpdate.Address.Country = Student.Address.Country;
            studentToUpdate.Address.Region = Student.Address.Region;
            studentToUpdate.Address.District = Student.Address.District;
            studentToUpdate.Address.Locality = Student.Address.Locality;
            studentToUpdate.Address.City = Student.Address.City;
            studentToUpdate.Address.Street = Student.Address.Street;
            studentToUpdate.Address.HouseNumber = Student.Address.HouseNumber;
            studentToUpdate.Address.ApartmentNumber = Student.Address.ApartmentNumber;

            _context.Attach(studentToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Detail", new { id = Student.ID });
        }

        private bool StudentExists(int id)
        {
            return (_context.Workplace?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
