using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340lab7.Data;
using csci340lab7.Models;

namespace csci340lab7.Pages.Trails
{
    public class DeleteModel : PageModel
    {
        private readonly csci340lab7.Data.csci340lab7Context _context;

        public DeleteModel(csci340lab7.Data.csci340lab7Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Trail Trail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trail = await _context.Trail.FirstOrDefaultAsync(m => m.ID == id);

            if (Trail == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trail = await _context.Trail.FindAsync(id);

            if (Trail != null)
            {
                _context.Trail.Remove(Trail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
