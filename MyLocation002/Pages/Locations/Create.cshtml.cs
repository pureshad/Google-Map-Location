using GoogleMaps.LocationServices;
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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private GoogleLocationService _googleLocation;

        public CreateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public LocationsViewModel LocationsVM { get; set; }

        public IActionResult OnGet()
        {
            LocationsVM = new LocationsViewModel()
            {
                Locations = new Location(),
                Categories = _dbContext.Categories.ToList()
            };

            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbContext.Locations.Add(LocationsVM.Locations);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            Message = "New Location Has Been Added!";

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostFatchCordinates()
        {
            LocationsVM = new LocationsViewModel()
            {
                Locations = new Location()
                {
                    Name = LocationsVM.Locations.Name,
                    Adress = LocationsVM.Locations.Adress
                },
                Categories = await _dbContext.Categories.ToListAsync().ConfigureAwait(false)
            };

            _googleLocation = new GoogleLocationService();

            var name = LocationsVM.Locations.Name;
            var adress = LocationsVM.Locations.Adress;

            var point = _googleLocation.GetLatLongFromAddress(name + " " + adress);

            LocationsVM.Locations.Longitude = point.Longitude;
            LocationsVM.Locations.Latitude = point.Latitude;

            return Page();
        }
    }
}