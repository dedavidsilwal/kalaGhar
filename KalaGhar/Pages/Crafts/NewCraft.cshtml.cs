using KalaGhar.Data;
using KalaGhar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KalaGhar.Pages.Crafts
{
    [Authorize]

    public class NewCraftModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public NewCraftModel(
            ApplicationDbContext context,
            IHttpContextAccessor contextAccessor
            )
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }


        [BindProperty]

        public Craft Craft { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public List<Category> Categories { get; set; }


        [BindProperty]
        public List<IFormFile> UploadedImage { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();

            //Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (UploadedImage.Count == 0)
            {
                ModelState.AddModelError("UploadedImage", "Please upload image to create a craft");

                Categories = await _context.Categories.ToListAsync();

                return Page();
            }

            if (!ModelState.IsValid)
            {
                Categories = await _context.Categories.ToListAsync();

                return Page();
            }
            await AddImagesToCraft();

            Craft.UserId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _context.Crafts.Add(Craft);
            await _context.SaveChangesAsync();

            StatusMessage = "Craft created successfully.";

            return RedirectToPage("./MyCraft");

            async Task AddImagesToCraft()
            {
                var directory = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot",
                    "Images");

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }


                foreach (var imageFile in UploadedImage)
                {
                    var imageName = Guid.NewGuid().ToString() + ".jpg";
                    var path = Path.Combine(directory, imageName);


                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }


                    var imageEntity = new Image {
                        CraftId = Craft.Id,
                        DisplayName = imageFile.FileName,
                        Extension = imageFile.ContentType,
                        Name = imageName
                    };

                    Craft.Images.Add(imageEntity);
                }
            }

        }
    }
}
