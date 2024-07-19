using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Specialties
{
    public class EditModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public EditModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Specialty Specialty { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Specialty == null)
            {
                return NotFound();
            }

            var specialty =  await _context.Specialty.FirstOrDefaultAsync(m => m.CodeSpecialty == id);
            if (specialty == null)
            {
                return NotFound();
            }
            Specialty = specialty;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Specialty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialtyExists(Specialty.CodeSpecialty))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpecialtyExists(int id)
        {
          return (_context.Specialty?.Any(e => e.CodeSpecialty == id)).GetValueOrDefault();
        }
    }
}
