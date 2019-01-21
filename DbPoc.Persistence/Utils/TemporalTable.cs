using DbPoc.Domain.Entities;
using System;

namespace DbPoc.Persistence.Utils
{
    public static class TemporalTable
    {
        public static string GetTemporalTableSql(string tableName, string schema = "history")
        {
            return $@"
ALTER TABLE {tableName}   
ADD   
    StartTime datetime2 (2) GENERATED ALWAYS AS ROW START HIDDEN    
        constraint DF_{tableName}_StartTime DEFAULT DATEADD(second, -1, SYSUTCDATETIME()) , EndTime datetime2 (2)
GENERATED ALWAYS AS ROW END HIDDEN 
constraint DF_{tableName}_EndTime DEFAULT '9999.12.31 23:59:59.99'  ,
PERIOD FOR SYSTEM_TIME (StartTime, EndTime);   
  
ALTER TABLE {tableName}    
    SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = {schema}.{tableName})); ";
        }
    }
}
