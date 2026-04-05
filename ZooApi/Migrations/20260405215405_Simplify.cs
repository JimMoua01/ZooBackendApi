using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooApi.Migrations
{
    /// <inheritdoc />
    public partial class Simplify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "Id", "Count" },
                values: new object[] { 1, 60 });

            migrationBuilder.InsertData(
                table: "ZooStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 1, "Open" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ZooStatuses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
