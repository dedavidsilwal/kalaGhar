using KalaGhar.Data;
using KalaGhar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KalaGhar.Pages.Crafts
{
    public class DetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public DetailModel(
            ApplicationDbContext context,
            IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        [BindProperty]
        public Craft Craft { get; set; }
        public string CraftId { get; set; }


        public async Task OnGetAsync([FromServices] IHttpContextAccessor contextAccessor)
        {
            CraftId = RouteData.Values["id"].ToString();

            Craft = await _context.Crafts.Include(s => s.Messages).FirstOrDefaultAsync(x => x.Id == CraftId);

            _ = Task.Run(async () => await AddToCraftView(CraftId));

            async Task AddToCraftView(string craftId)
            {
                var view = new CraftView {
                    CraftId = craftId,
                    PublicIP = contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString()
                };

                var userId = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId is not null)
                {
                    view.UserId = userId;
                }

                await _context.AddAsync(view);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IActionResult> OnGetAddToWishListAsync([FromServices] IHttpContextAccessor contextAccessor)
        {
            CraftId = RouteData.Values["id"].ToString();

            if (CraftId is null)
            {
                throw new System.Exception("There is an error");
            }

            var userId = GetUserId(contextAccessor);

            if (userId is null)
            {
                throw new System.Exception("Please login");
            }


            try
            {
                _context.Wishes.Add(new Wish { CraftId = CraftId, UserId = userId });
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
            Craft = await _context.Crafts.FindAsync(CraftId);

            return Page();
        }

        private static string GetUserId(IHttpContextAccessor contextAccessor)
        {
            return contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public async Task<IActionResult> OnPostMessageSubmitAsync(Message message)
        {
            message.CreatedDateTime = DateTime.UtcNow;
            message.SenderUserId = GetUserId(_contextAccessor);

            await _context.AddAsync(message);
            await _context.SaveChangesAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostReplyMessageSubmitAsync(Reply reply)
        {
            var message = await _context.Messages.FindAsync(reply.MessageId);

            reply.Id = Guid.NewGuid().ToString();
            reply.CreatedDateTime = DateTime.UtcNow;
            message.Replies.Add(reply);

            _context.Update(message);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
