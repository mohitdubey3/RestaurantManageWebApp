using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TasteTown.Models;
namespace TasteTown.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    
            public DbSet<Product> Products { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<OrderItem> OrderItems { get; set; }
            public DbSet<Ingredient> Ingredients { get; set; }
            public DbSet<ProductIngredient> ProductIngredients { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<ProductIngredient>()
                    .HasKey(pi => new { pi.ProductId, pi.IngredientId });

                modelBuilder.Entity<ProductIngredient>()
                    .HasOne(pi => pi.Product)
                    .WithMany(p => p.ProductIngredients)
                    .HasForeignKey(pi => pi.ProductId);

                modelBuilder.Entity<ProductIngredient>()
                    .HasOne(pi => pi.Ingredient)
                    .WithMany(i => i.ProductIngredients)
                    .HasForeignKey(pi => pi.IngredientId);

                modelBuilder.Entity<Category>().HasData(
                 new Category { CategoryId = 1, Name = "Fine Dinning" },
                 new Category { CategoryId = 2, Name = "Casual Dinning" },
                 new Category { CategoryId = 3, Name = "Fast Casual" },
                 new Category { CategoryId = 4, Name = "Thali Restaurant" },
                 new Category { CategoryId = 5, Name = "Tandoori" },
                 new Category { CategoryId = 6, Name = "Regional Special" },
                 new Category { CategoryId = 7, Name = "Coffee" },
                 new Category { CategoryId = 8, Name = "Starters" },
                 new Category { CategoryId = 9, Name = "Non-Vegetarian" }
               );

                modelBuilder.Entity<Ingredient>().HasData(
                  new Ingredient { IngredientId = 1, Name = "Vegetables" },
                  new Ingredient { IngredientId = 2, Name = "Breads" },
                  new Ingredient { IngredientId = 3, Name = "Dairy & Cheese" },
                  new Ingredient { IngredientId = 4, Name = "Fruits" },
                  new Ingredient { IngredientId = 5, Name = "Rice" },
                  new Ingredient { IngredientId = 6, Name = "Meat" },
                  new Ingredient { IngredientId = 7, Name = "Masala" }
              );

                modelBuilder.Entity<Product>().HasData(

                    new Product
                    {
                        ProductId = 1,
                        Name = "Chicken Tikka",
                        Description = "Fresh lemon wedge and mint or aromatic flavor",
                        Price = 150.0m,
                        Stock = 100,
                        CategoryId = 8
                    },
                    new Product
                    {
                        ProductId = 2,
                        Name = "Paneer Butter Masala",
                        Description = "A delicious Achari panner tikka",
                        Price = 215.60m,
                        Stock = 19,
                        CategoryId = 2
                    },
                    new Product
                    {
                        ProductId = 3,
                        Name = "Pakora",
                        Description = "mixed Vegetable Pakoras include paneer, potato, Gobi and chiken",
                        Price = 3.99m,
                        Stock = 90,
                        CategoryId = 3
                    },
                    new Product
                    {
                        ProductId = 4,
                        Name = "Fried Rice",
                        Description = "Most delicious fried rice for all",
                        Price = 3.99m,
                        Stock = 90,
                        CategoryId = 1
                    }
                    );

                modelBuilder.Entity<ProductIngredient>().HasData(
                    new ProductIngredient { ProductId = 1, IngredientId = 3 },
                    new ProductIngredient { ProductId = 1, IngredientId = 6 },
                    new ProductIngredient { ProductId = 1, IngredientId = 7 },
                    new ProductIngredient { ProductId = 2, IngredientId = 1 },
                    new ProductIngredient { ProductId = 2, IngredientId = 3 },
                    new ProductIngredient { ProductId = 2, IngredientId = 4 },
                    new ProductIngredient { ProductId = 2, IngredientId = 7 },
                    new ProductIngredient { ProductId = 3, IngredientId = 1 },
                    new ProductIngredient { ProductId = 3, IngredientId = 3 },
                    new ProductIngredient { ProductId = 4, IngredientId = 1 },
                    new ProductIngredient { ProductId = 4, IngredientId = 5 },
                    new ProductIngredient { ProductId = 4, IngredientId = 7 }
                );
            }
    }

}
