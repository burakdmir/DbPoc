using DbPoc.Persistence.Utils;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbPoc.Persistence.Migrations
{
    public partial class createtemporaltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(name: "history");
            migrationBuilder.Sql(TemporalTable.GetTemporalTableSql("Products"));
            migrationBuilder.Sql(TemporalTable.GetTemporalTableSql("Recipes"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
