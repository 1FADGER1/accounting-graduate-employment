using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public IndexModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public IList<Student> Students { get; set; } = default!;
        public IList<Specialty> Specialties { get; set; } = default!;
        // public IDictionary<int, string> SpecialtyDictionary { get; set; } // один из способов сопоставить данные между студентом и специальностью
        [BindProperty] public Address Address { get; set; } = default!;
        [BindProperty] public Student Student { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Student != null)
            {
                Students = await _context.Student.Include(s => s.Specialty).ToListAsync();
            }
            if(_context.Specialty != null)
            {
                Specialties = await _context.Specialty.ToListAsync();

                //SpecialtyDictionary = Specialties.ToDictionary(a => a.CodeSpecialty, s => s.NameSpecialty);
            }
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!ModelState.IsValid || _context.Student == null || Student == null || _context.Address == null || Address == null) //
            {
                return Page();
            }

            _context.Address.Add(Address);
            await _context.SaveChangesAsync();

            Student.IDResidentialAddress = Address.ID;
            _context.Student.Add(Student);
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}