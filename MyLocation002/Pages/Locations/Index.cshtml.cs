using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLocation002.Data;
using MyLocation002.Data.Models;

namespace MyLocation002.Pages.Locations
{
    /// <summary>
    /// Locations Index
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public IList<Location> Locations { get; set; }

        public async Task OnGetAsync()
        {
            Locations = await _dbContext.Locations.
                Include(w => w.Category).
                ToListAsync();
        }

        public async Task OnGetSortByAlphabet()
        {
            Locations = await _dbContext.Locations.Include(w => w.Category).OrderBy(w => w.Adress).ToListAsync();
        }
    }
}