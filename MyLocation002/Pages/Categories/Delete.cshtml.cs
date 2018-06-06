using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLocation002.Data;
using MyLocation002.Data.Models;
using System.Threading.Tasks;

namespace MyLocation002.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [TempData]
        public string Message { get; set; }

        public DeleteModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categories = await _dbContext.Categories.SingleOrDefaultAsync(w => w.Id == id);

            if (Categories == null)
            {
                return NotFound();
            }

            return Page();
        }

        [BindProperty]
        public Category Categories { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categories = await _dbContext.Categories.FindAsync(id);

            if (Categories != null)
            {
                _dbContext.Categories.Remove(Categories);

                await _dbContext.SaveChangesAsync();

                Message = "Item Was Deleted !";
            }

            return RedirectToPage("./Index");
        }
    }
}