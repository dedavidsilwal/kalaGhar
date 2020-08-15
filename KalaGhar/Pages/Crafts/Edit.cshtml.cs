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
using System.Threading.Tasks;

namespace KalaGhar.Pages.Crafts
{

    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }


        [BindProperty]

        public Craft Craft { get; set; }

        [TempData]
        public string StatusMessage { get; set; }


        public List<Category> Categories { get; set; }


        [BindProperty]
        public List<IFormFile> UploadedImage { get; set; }

        public int AvailableImage { get; set; }



        public async Task OnGetAsync()
        {
            Categories = await _context.Categories.ToListAsync();

            var id = RouteData.Values["id"].ToString();
            Craft = await _context.Crafts.FindAsync(id);

            AvailableImage = 4 - Craft.Images.Count;
            //Categories = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = await _context.Categories.ToListAsync();

                return Page();
            }

            await AddImagesToCraft();

            _context.Update(Craft);
            await _context.SaveChangesAsync();

            StatusMessage = "Craft updated successfully.";

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
