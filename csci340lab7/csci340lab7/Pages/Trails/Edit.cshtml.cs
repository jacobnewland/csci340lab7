using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csci340lab7.Data;
using csci340lab7.Models;

namespace csci340lab7.Pages.Trails
{
    public class EditModel : PageModel
    {
        private readonly csci340lab7.Data.csci340lab7Context _context;

        public EditModel(csci340lab7.Data.csci340lab7Context context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Trail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrailExists(Trail.ID))
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

        private bool TrailExists(int id)
        {
            return _context.Trail.Any(e => e.ID == id);
        }
    }
}
