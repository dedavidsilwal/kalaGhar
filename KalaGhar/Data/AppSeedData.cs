using KalaGhar.Models;
using System;
using System.Collections.Generic;

namespace KalaGhar.Data
{
    public static class AppSeedData
    {
        public static List<Category> Categories => new List<Category> {
             new Category() { Name = "Paintings", Enabled=true },
             new Category() { Name = "Stone crafts", Enabled=true },
             new Category() { Name = "Ceramics", Enabled=true },
             new Category() { Name = "Wooden crafts", Enabled=true },
             new Category() { Name = "Browse others", Enabled=true },
        };

        public static List<Craft> Crafts = new List<Craft> {
            new Craft(){ Name ="Himalayan Arts", Price=47, Quantity=1, PublishDate = DateTime.Now, Category = Categories.Find(x=>x.Name == "Paintings"), Published=true},

        };
    }
}
