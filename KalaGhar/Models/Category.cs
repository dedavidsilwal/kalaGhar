using System.Collections.Generic;

namespace KalaGhar.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }

        public ICollection<Craft> Crafts { get; set; }
    }
}
