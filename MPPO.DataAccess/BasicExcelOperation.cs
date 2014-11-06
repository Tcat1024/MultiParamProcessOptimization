using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace MPPO.DataAccess
{
    public class BasicExcelOperation
    {
        public static DataSet ImportFromExcel(string filename)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=Excel 12.0;");

            DataSet result = new DataSet();
            try
            {
                conn.Open();
                DataTable tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                OleDbDataAdapter adp = new OleDbDataAdapter();

                foreach (DataRow dr in tables.Rows)
                {
                    string sql = "Select * From [" + dr[2].ToString().Trim() + "]";
                    OleDbCommand objCmd = new OleDbCommand(sql, conn);
                    adp.SelectCommand = objCmd;
                    adp.Fill(result, dr[2].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
