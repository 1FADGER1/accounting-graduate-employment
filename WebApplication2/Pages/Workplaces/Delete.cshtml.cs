using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Workplaces
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
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

            var workplace = await _context.Workplace.FirstOrDefaultAsync(m => m.ID == id);

            if (workplace == null)
            {
                return NotFound();
            }
            else 
            {
                Workplace = workplace;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Workplace == null)
            {
                return NotFound();
            }
            var workplace = await _context.Workplace.FindAsync(id);

            if (workplace != null)
            {
                Workplace = workplace;
                _context.Workplace.Remove(Workplace);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
