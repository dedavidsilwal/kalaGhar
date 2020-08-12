using KalaGhar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGhar.ViewComponents
{
    [ViewComponent(Name = "HomePageCraft")]

    public class HomePageCraftViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public HomePageCraftViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var crafts = await _context.Crafts.ToListAsync();
            return View(crafts);
        }
    }
}
