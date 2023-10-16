using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alten_test.Data.Migrations;

/// <inheritdoc />
public partial class FirstMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Code = table.Column<string>(type: "TEXT", nullable: true),
                Name = table.Column<string>(type: "TEXT", nullable: true),
                Description = table.Column<string>(type: "TEXT", nullable: true),
                Price = table.Column<int>(type: "INTEGER", nullable: false),
                Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                InventoryStatus = table.Column<string>(type: "TEXT", nullable: true),
                Category = table.Column<string>(type: "TEXT", nullable: true),
                image = table.Column<string>(type: "TEXT", nullable: true),
                rating = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "Id", "Category", "Code", "Description", "InventoryStatus", "Name", "Price", "Quantity", "image", "rating" },
            values: new object[,]
            {
                { 1, null, null, null, null, "Post 1", 0, 0, null, 0 },
                { 2, null, null, null, null, "Post 2", 0, 0, null, 0 },
                { 3, null, null, null, null, "Post 3", 0, 0, null, 0 },
                { 4, null, null, null, null, "Post 4", 0, 0, null, 0 },
                { 5, null, null, null, null, "Post 5", 0, 0, null, 0 },
                { 6, null, null, null, null, "Post 6", 0, 0, null, 0 }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Products");
    }
}
