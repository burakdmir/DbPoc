using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbPoc.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NetPrice = table.Column<decimal>(nullable: false),
                    Vat = table.Column<decimal>(nullable: false),
                    Unit = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompositeProductId = table.Column<int>(nullable: true),
                    ComponentProductId = table.Column<int>(nullable: true),
                    ComponentQuantity = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Products_ComponentProductId",
                        column: x => x.ComponentProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_Products_CompositeProductId",
                        column: x => x.CompositeProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "NetPrice", "ParentId", "Unit", "Vat" },
                values: new object[] { 1, "Tej", 230m, null, 3, 5m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "NetPrice", "ParentId", "Unit", "Vat" },
                values: new object[] { 2, "Kenyér", 230m, null, 2, 5m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "NetPrice", "ParentId", "Unit", "Vat" },
                values: new object[] { 3, "Herz szalámi", 230m, null, 1, 5m });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ComponentProductId",
                table: "Recipes",
                column: "ComponentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CompositeProductId",
                table: "Recipes",
                column: "CompositeProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
