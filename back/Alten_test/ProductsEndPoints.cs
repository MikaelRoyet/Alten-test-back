
using Microsoft.EntityFrameworkCore;
using Alten_test.Data.Models;
using Server.Data;


namespace Alten_test;
public static class ProductsEndpoints
{
    // Extends WebApplication.
    public static void MapProductsEndpoints(this WebApplication app)
    {
        app.MapGet("/products", async (AppDbContext dbContext) =>
        {
            List<Product> allPosts = await dbContext.Products.ToListAsync();

            return Results.Ok(allPosts);
        });

        app.MapGet("/products/{Id}", async (int Id, AppDbContext dbContext) =>
        {
            Product? product = await dbContext.Products.FindAsync(Id);

            if (product != null)
            {
                return Results.Ok(product);
            }
            else
            {
                return Results.NotFound();
            }
        });

        app.MapPost("/products", async (ProductDTO postToCreateDTO, AppDbContext dbContext) =>
        {

            // Let EF Core auto-increment the ID.
            Product PostToCreate = new()
            {
                Id = 0,
                Code = postToCreateDTO.Code,
                Name = postToCreateDTO.Name,
                Description = postToCreateDTO.Description,
                Price = postToCreateDTO.Price,
                Quantity = postToCreateDTO.Quantity,
                InventoryStatus = postToCreateDTO.InventoryStatus,
                Category = postToCreateDTO.Category,
                image = postToCreateDTO.image,
                rating = postToCreateDTO.rating,
            };

            dbContext.Products.Add(PostToCreate);

            bool success = await dbContext.SaveChangesAsync() > 0;

            if (success)
            {
                return Results.Created($"/posts/{PostToCreate.Id}", postToCreateDTO);
            }
            else
            {
                return Results.StatusCode(500);
            }
        });

        app.MapPut("/products/{Id}", async (int Id, Product updatedProductDTO, AppDbContext dbContext) =>
        {
            var productToUpdate = await dbContext.Products.FindAsync(Id);

            if (productToUpdate != null)
            {
                productToUpdate.Code = updatedProductDTO.Code;
                productToUpdate.Name = updatedProductDTO.Name;
                productToUpdate.Description = updatedProductDTO.Description;
                productToUpdate.Quantity = updatedProductDTO.Quantity;
                productToUpdate.InventoryStatus = updatedProductDTO.InventoryStatus;
                productToUpdate.Category = updatedProductDTO.Category;
                productToUpdate.image = updatedProductDTO.image;
                productToUpdate.rating = updatedProductDTO.rating;
 

                bool success = await dbContext.SaveChangesAsync() > 0;

                if (success)
                {
                    return Results.Ok(productToUpdate);
                }
                else
                {
                    return Results.StatusCode(500);
                }
            }
            else
            {
                return Results.NotFound();
            }
        });

        app.MapDelete("/products/{Id}", async (int Id, AppDbContext dbContext) =>
        {
            Product? productToDelete = await dbContext.Products.FindAsync(Id);

            if (productToDelete != null)
            {
                dbContext.Products.Remove(productToDelete);

                bool success = await dbContext.SaveChangesAsync() > 0;

                if (success)
                {
                    return Results.NoContent();
                }
                else
                {
                    return Results.StatusCode(500);
                }
            }
            else
            {
                return Results.NotFound();
            }
        });
    }
}