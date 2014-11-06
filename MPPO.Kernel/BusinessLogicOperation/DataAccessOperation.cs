using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPPO.Kernel.BusinessLogicOperation
{
    public partial class DataAccessOperation
    {
        public static DataSet GetSingleTableFromDataBase(string command,string conStr,string tablename)
        {
             return MPPO.DataAccess.BasicOledbQuery.DebugGetTable(command, conStr,tablename);
        }
        public static List<string> GetTableNamesFromDataBase(string conStr)
        {
            return MPPO.DataAccess.BasicOledbQuery.GetTableNames(conStr);
        }
        public static List<string> GetColumnNamesFromDataBase(string conStr, string tablename)
        {
            return MPPO.DataAccess.BasicOledbQuery.GetColumnNames(conStr, tablename);
        }
        public static DataSet GetTablesFromExcel(string filepath)
        {
            return MPPO.DataAccess.BasicExcelOperation.ImportFromExcel(filepath);
        }
    }
}
