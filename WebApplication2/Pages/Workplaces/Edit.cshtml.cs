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

namespace WebApplication2.Pages.Workplaces
{
    public class EditModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public EditModel(WebApplication2.Data.WebApplication2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Workplace Workplace { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Workplace == null)
            {
                return NotFound();
            }

            var workplace =  await _context.Workplace.FirstOrDefaultAsync(m => m.ID == id);
            if (workplace == null)
            {
                return NotFound();
            }
            Workplace = workplace;
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

            _context.Attach(Workplace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkplaceExists(Workplace.ID))
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

        private bool WorkplaceExists(int id)
        {
          return (_context.Workplace?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
