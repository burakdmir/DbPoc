using Microsoft.EntityFrameworkCore.Migrations;

namespace DbPoc.Persistence.Migrations
{
    public partial class recipehistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
ALTER TABLE Recipes   
ADD   
    StartTime datetime2 (2) GENERATED ALWAYS AS ROW START HIDDEN    
        constraint Recipes_StartTime DEFAULT DATEADD(second, -1, SYSUTCDATETIME())  
    , EndTime datetime2 (2)  GENERATED ALWAYS AS ROW END HIDDEN     
        constraint Recipes_EndTime DEFAULT '9999.12.31 23:59:59.99'  
    , PERIOD FOR SYSTEM_TIME (StartTime, EndTime);   
  
ALTER TABLE Recipes    
    SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.Recipes_History));  ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
