using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLocation002.Data;
using MyLocation002.Data.Models;

namespace MyLocation002.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [TempData]
        public string Message { get; set; }


        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Category> Categories { get; set; }

        public async Task OnGet()
        {
            Categories = await _dbContext.Categories.OrderBy(w => w.DisplayCategory).ToListAsync();
        }
    }
}