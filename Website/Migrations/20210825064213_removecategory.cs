using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Migrations
{
    public partial class removecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Family",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
