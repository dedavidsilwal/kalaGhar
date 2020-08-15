using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace KalaGhar.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string DisplayName => string.Concat(FirstName, " ", LastName);


        public ICollection<Wish> Wishes { get; set; } = new List<Wish>();
        public ICollection<Craft> Crafts { get; set; } = new List<Craft>();
    }
}
