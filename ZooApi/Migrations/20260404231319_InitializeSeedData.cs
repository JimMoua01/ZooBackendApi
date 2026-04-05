using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooApi.Migrations
{
    /// <inheritdoc />
    public partial class InitializeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Count", "Feeding", "Gender", "Health", "Image", "Latitude", "Longitude", "Name", "Species", "Status" },
                values: new object[,]
                {
                    { 1, 5, "5:00 PM", "Male", "Healthy", "/images/elephant.png", 45.5, -90.700000000000003, "Henri", "Elephant", "Open" },
                    { 2, 8, "8:00 PM", "Female", "Healthy", "/images/tiger.png", 44.5, -91.200000000000003, "Aurora", "Tiger", "Open" },
                    { 3, 4, "12:00 PM", "Male", "Healthy", "/images/panda.png", 43.5, -89.599999999999994, "Cliff", "Panda", "Open" },
                    { 4, 7, "9:00 PM", "Male", "Sick", "/images/monkey.png", 40.5, -90.299999999999997, "Caesar", "Monkey", "Open" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
