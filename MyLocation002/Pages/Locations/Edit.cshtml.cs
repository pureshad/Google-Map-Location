using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLocation002.Data;
using MyLocation002.Data.Models;
using MyLocation002.ViewModel;

namespace MyLocation002.Pages.Locations
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var locationItemFromDb = _dbContext.Locations.Where(w => w.Id == LocationsVM.Locations.Id).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            locationItemFromDb.Name = LocationsVM.Locations.Name;
            locationItemFromDb.CategoryId = LocationsVM.Locations.CategoryId;
            locationItemFromDb.Adress = LocationsVM.Locations.Adress;
            locationItemFromDb.Latitude = LocationsVM.Locations.Latitude;
            locationItemFromDb.Longitude = LocationsVM.Locations.Longitude;

            await _dbContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}