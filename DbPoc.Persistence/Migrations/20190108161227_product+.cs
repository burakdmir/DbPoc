using Microsoft.EntityFrameworkCore.Migrations;

namespace DbPoc.Persistence.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Unit",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "NetPrice", "Picture", "Quantity", "Unit", "Vat" },
                values: new object[] { 1, "Tej", 230m, null, 26m, 3, 5m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "NetPrice", "Picture", "Quantity", "Unit", "Vat" },
                values: new object[] { 2, "Kenyér", 230m, null, 42m, 2, 5m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "NetPrice", "Picture", "Quantity", "Unit", "Vat" },
                values: new object[] { 3, "Herz szalámi", 230m, null, 55m, 1, 5m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Products");
        }
    }
}
