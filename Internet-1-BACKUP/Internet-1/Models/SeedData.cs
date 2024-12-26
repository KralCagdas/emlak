using Microsoft.EntityFrameworkCore;

namespace Internet_1.Models
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {




            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Categori 1", IsActive = true },
                new Category() { Id = 2, Name = "Categori 1", IsActive = true },
                new Category() { Id = 3, Name = "Categori 2", IsActive = true }
);


            modelBuilder.Entity<Product>().HasData(
            new Product() { Id = 1, Name = "ad", Price = 10, Description = "açıklama", IsActive = true, CategoryId = 1, PhotoUrl = "", City = "Sample City" },
            new Product() { Id = 2, Name = "ad", Price = 15, Description = "açıklama", IsActive = true, CategoryId = 1, PhotoUrl = "", City = "Sample City" },
            new Product() { Id = 3, Name = "ad", Price = 20, Description = "açıklama", IsActive = false, CategoryId = 2, PhotoUrl = "", City = "Sample City" },
            new Product() { Id = 4, Name = "ad", Price = 30, Description = "açıklama", IsActive = false, CategoryId = 2, PhotoUrl = "", City = "Sample City" },
            new Product() { Id = 5, Name = "ad", Price = 25, Description = "açıklama", IsActive = false, CategoryId = 3, PhotoUrl = "", City = "Sample City" }
            );



        }

    }
}
