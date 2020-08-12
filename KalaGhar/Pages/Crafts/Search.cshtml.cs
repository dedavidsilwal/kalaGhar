using KalaGhar.Data;
using KalaGhar.Extensions;
using KalaGhar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalaGhar.Pages.Crafts
{
    public class SearchModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SearchModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Craft> Crafts
        {
            get; set;
        }

        public async Task OnGetAsync()
        {
            if (RouteData.Values.TryGetValue("keyword", out var input))
            {
                var keyword = input.ToString();

                Crafts = await _context.Crafts.WhereIf(!string.IsNullOrEmpty(keyword), c => c.Name.Contains(keyword)).ToListAsync();
            }

            Crafts = await _context.Crafts.ToListAsync();

        }

        //save searches

        public async Task<IActionResult> OnGetFilterChangedAsync(SortBy sortBy)
        {
            Crafts = sortBy switch
            {
                SortBy.Price => await _context.Crafts.OrderBy(s => s.Price).ToListAsync(),
                SortBy.Relevance => throw new System.NotImplementedException(),
                SortBy.ViewCount => throw new System.NotImplementedException(),
                SortBy.RecentlyPublish => throw new System.NotImplementedException(),
                _ => throw new System.NotImplementedException()
            };

            return Page();
        }

        public async Task OnGetSearchByCategoryAsync(string category)
        {
            var categories = await _context.Categories
                .WhereIf(!string.IsNullOrEmpty(category), c => c.Name.Contains(category)).Include(s => s.Crafts)
                .FirstOrDefaultAsync();

            Crafts = categories.Crafts.ToList();
        }
    }
}
