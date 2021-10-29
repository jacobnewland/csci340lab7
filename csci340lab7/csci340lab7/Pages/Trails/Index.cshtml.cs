using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340lab7.Data;
using csci340lab7.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace csci340lab7.Pages.Trails
{
    public class IndexModel : PageModel
    {
        private readonly csci340lab7.Data.csci340lab7Context _context;

        public IndexModel(csci340lab7.Data.csci340lab7Context context)
        {
            _context = context;
        }

        public IList<Trail> Trail { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Locations { get; set; }
        [BindProperty(SupportsGet = true)]
        public string TrailLocation { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> locationQuery = from t in _context.Trail
                                            orderby t.Location
                                            select t.Location;
            var trails = from t in _context.Trail
                         select t;
            if (!string.IsNullOrEmpty(SearchString))
            {
                trails = trails.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(TrailLocation))
            {
                trails = trails.Where(x => x.Location == TrailLocation);
            }
            Locations = new SelectList(await locationQuery.Distinct().ToListAsync());
            Trail = await trails.ToListAsync();
        }
    }
}
