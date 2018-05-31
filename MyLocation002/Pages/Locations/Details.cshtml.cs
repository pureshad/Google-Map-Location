using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLocation002.Data;
using MyLocation002.Data.Models;
using MyLocation002.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyLocation002.Pages.Locations
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public DetailsModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Location Locations { get; set; }

        [BindProperty]
        public LocationsViewModel LocationsVM { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LocationsVM = new LocationsViewModel()
            {
                Locations = await _dbContext.Locations.Include(w => w.Category).SingleOrDefaultAsync(w => w.Id == id),
                Categories = _dbContext.Categories.ToList()
            };

            if (LocationsVM.Locations == null)
            {
                return NotFound();
            }

            Locations = await _dbContext.Locations.SingleOrDefaultAsync(w => w.Id == id);

            if (Locations == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}