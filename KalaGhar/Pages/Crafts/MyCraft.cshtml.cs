using KalaGhar.Data;
using KalaGhar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KalaGhar.Pages.Crafts
{
    [Authorize]

    public class MyCraftModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public MyCraftModel(ApplicationDbContext context,
            IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        [BindProperty]
        public IReadOnlyCollection<Craft> Crafts { get; set; }


        [TempData]
        public string StatusMessage { get; set; }

        public async Task OnGetAsync()
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Crafts = await _context.Crafts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task OnPostDeleteAsync(string id)
        {
            var craft = await _context.Crafts.FindAsync(id);
            _context.Remove(craft);
            await _context.SaveChangesAsync();

            var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Crafts = await _context.Crafts.Where(x => x.UserId == userId).ToListAsync();

        }
    }
}
