using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbPoc.Persistence.Migrations
{
    public partial class temporaltablecomputed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "EndTime",
            //    table: "Products",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "StartTime",
            //    table: "Products",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.Sql(@"
ALTER TABLE Products   
ADD   
    StartTime datetime2 (2) GENERATED ALWAYS AS ROW START HIDDEN    
        constraint DF_StartTime DEFAULT DATEADD(second, -1, SYSUTCDATETIME())  
    , EndTime datetime2 (2)  GENERATED ALWAYS AS ROW END HIDDEN     
        constraint DF_EndTime DEFAULT '9999.12.31 23:59:59.99'  
    , PERIOD FOR SYSTEM_TIME (StartTime, EndTime);   
  
ALTER TABLE Products    
    SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.Products_History));  ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "EndTime",
            //    table: "Products");

            //migrationBuilder.DropColumn(
            //    name: "StartTime",
            //    table: "Products");
        }
    }
}
