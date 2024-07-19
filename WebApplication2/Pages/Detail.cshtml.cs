using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Pages
{
    public class DetailModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DetailModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FirstOrDefaultAsync(m => m.ID == id);

            if (student == null)
            {
                return NotFound();
            }
            else
                Student = student;
            return Page();
        }
    }
}
