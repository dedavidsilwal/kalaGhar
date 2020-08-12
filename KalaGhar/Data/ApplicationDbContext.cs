using KalaGhar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KalaGhar.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Name).IsRequired();

            builder.Entity<Category>().HasData(AppSeedData.Categories);


            builder.Entity<Craft>().HasKey(p => p.Id);
            builder.Entity<Craft>().Property(p => p.Name).IsRequired();

            builder.Entity<Craft>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Crafts)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<Craft>().OwnsMany(p => p.Images, i => {
                i.HasKey(x => x.Id);
                i.WithOwner().HasForeignKey(x => x.CraftId);
            });

            builder.Entity<Wish>().HasKey(e => new { e.CraftId, e.UserId });
            builder.Entity<Message>().HasKey(e => new { e.CraftId, e.UserId });

            builder.Entity<Craft>()
                 .HasOne(p => p.User)
                 .WithMany(p => p.Crafts)
                 .HasForeignKey(p => p.UserId)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Message>()
                     .HasOne(p => p.Craft)
                     .WithMany(p => p.Messages)
                     .HasForeignKey(p => p.CraftId)
                     .OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<Wish>()
                 .HasOne(p => p.User)
                 .WithMany(p => p.Wishes)
                 .HasForeignKey(p => p.UserId)
                 .OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<CraftView>()
                      .HasOne(p => p.Craft)
                      .WithMany(p => p.Views)
                      .HasForeignKey(p => p.CraftId)
                      .OnDelete(DeleteBehavior.ClientSetNull);


            base.OnModelCreating(builder);
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Craft> Crafts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Wish> Wishes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CraftView> Views { get; set; }

    }
}
