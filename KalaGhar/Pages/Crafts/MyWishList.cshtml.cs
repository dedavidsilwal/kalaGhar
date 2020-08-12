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

    public class MyWishListModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MyWishListModel(ApplicationDbContext context)
        {
            _context = context;
        }


        [BindProperty]
        public IReadOnlyCollection<Wish> Wishes { get; set; }


        public async Task OnGetAsync([FromServices] IHttpContextAccessor contextAccessor)
        {
            var userId = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Wishes = await _context.Wishes.Where(x => x.UserId == userId).Include(x => x.Craft).ToListAsync();
        }


        public async Task OnPostDeleteAsync(string id, [FromServices] IHttpContextAccessor contextAccessor)
        {
            var craft = await _context.Crafts.FindAsync(id);
            _context.Remove(craft);
            await _context.SaveChangesAsync();

            var userId = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Wishes = await _context.Wishes.Where(x => x.UserId == userId).Include(x => x.Craft).ToListAsync();

        }
    }
}
