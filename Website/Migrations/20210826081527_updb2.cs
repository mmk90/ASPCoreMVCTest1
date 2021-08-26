using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Migrations
{
    public partial class updb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "ItemID", "Name" },
                values: new object[] { 1, "this is the first Product", 1, "Product 1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "ItemID", "Name" },
                values: new object[] { 2, "this is the second Product", 2, "Product 2" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "ItemID", "Name" },
                values: new object[] { 3, "this is the third Product", 3, "Product 3" });

            migrationBuilder.InsertData(
                table: "CategorytoProducts",
                columns: new[] { "CategoryID", "ProductID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ID", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, 854.0m, 5 },
                    { 2, 3302.0m, 8 },
                    { 3, 2500m, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CategorytoProducts",
                keyColumns: new[] { "CategoryID", "ProductID" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
