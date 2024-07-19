﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Specialties
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication2.Data.WebApplication2Context _context;

        public DeleteModel(WebApplication2.Data.WebApplication2Context context)
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

            var specialty = await _context.Specialty.FirstOrDefaultAsync(m => m.CodeSpecialty == id);

            if (specialty == null)
            {
                return NotFound();
            }
            else 
            {
                Specialty = specialty;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Specialty == null)
            {
                return NotFound();
            }
            var specialty = await _context.Specialty.FindAsync(id);

            if (specialty != null)
            {
                Specialty = specialty;
                _context.Specialty.Remove(Specialty);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
