using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Migrations
{
    public partial class SeedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 1, "this is the first category", "Category 1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 2, "this is the second category", "Category 2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 3, "this is the third category", "Category 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
