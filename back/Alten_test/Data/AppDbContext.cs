using Alten_test.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Data;

public class AppDbContext : DbContext
{
    // We use => (expression-bodied members) to avoid nullable reference types errors.
    // Source: https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types#dbcontext-and-dbset.
    public DbSet<Product> Products => Set<Product>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Call the base version of this method (in DbContext) as well, else we sometimes get an error later on.
        base.OnModelCreating(modelBuilder);

        var productToSeed = new Product[6];

        for (int i = 1; i < 7; i++)
        {
            productToSeed[i - 1] = new()
            {
                Id = i,
                Code = $"Post {i}",
                Name = $"Post {i}",
                Description = $"Post {i}",
                Price = i,
                Quantity = i,
                InventoryStatus = $"Post {i}",
                Category = $"Post {i}",
                image = $"Post {i}",
                rating  = i,
            };
        }


        modelBuilder.Entity<Product>().HasData(productToSeed);
    }

}