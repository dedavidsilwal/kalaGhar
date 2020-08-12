using KalaGhar.Data;
using KalaGhar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace KalaGhar.Pages.Crafts
{
    public class UploadImageModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public UploadImageModel(ApplicationDbContext context)
        {
            _context = context;
        }


        public Craft Craft { get; set; }

        public string CraftId { get; set; }



        [Required]
        [Display(Name = "Picture")]
        [BindProperty]
        public List<IFormFile> Images { get; set; }

        public int AvailableImage { get; set; }


        public async Task OnGetAsync()
        {
            CraftId = RouteData.Values["id"].ToString();

            Craft = await _context.Crafts.FindAsync(CraftId);

            AvailableImage = 4 - (Craft.Images.Count);


        }

        public async Task<IActionResult> OnPostAsync()
        {

            CraftId = RouteData.Values["id"].ToString();

            if (Craft is null)
            {
                Craft = await _context.Crafts.FindAsync(CraftId);
            }

            if (!ModelState.IsValid && string.IsNullOrEmpty(CraftId) && Craft == null)
            {
                return Page();
            }

            if (Images == null || Images.Count == 0)
                return Content("Image not selected");


            var directory = Path.Combine(
                          Directory.GetCurrentDirectory(), "wwwroot",
                          "Images");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }


            foreach (var imageFile in Images)
            {
                var imageName = Guid.NewGuid().ToString() + ".jpg";
                var path = Path.Combine(directory, imageName);


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }


                var imageEntity = new Image {
                    CraftId = CraftId,
                    DisplayName = imageFile.FileName,
                    Extension = imageFile.ContentType,
                    Name = imageName
                };

                Craft.Images.Add(imageEntity);
            }
            _context.Update(Craft);


            await _context.SaveChangesAsync();

            return RedirectToPage("./MyCraft");
        }
    }
}
