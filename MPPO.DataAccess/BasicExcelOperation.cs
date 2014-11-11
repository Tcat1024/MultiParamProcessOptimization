using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;
using MPPO.Protocol.Interface;
using Microsoft.Office.Interop.Excel;

namespace MPPO.DataAccess
{
    public class BasicExcelOperation
    {
        public static DataSet ImportFromExcel(string filename)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;;Data Source=" + filename + ";Extended Properties=\'Excel 12.0;HDR=Yes\'");

            DataSet result = new DataSet();
            try
            {
                conn.Open();
                System.Data.DataTable tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
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
        public static void ExportToExcel(IDataTable<DataRow> data, string filename,Protocol.Structure.WaitObject wt)
        {
            if (data == null)
                return;
            var excel = new ApplicationClass();
            if (excel == null)
                throw new Exception("Excel无法启动");
            int rowNum = data.RowCount;
            string[] columns = data.GetColumnsList();
            int columnNum = columns.Length;
            wt.Flags = new int[1];
            wt.Max = rowNum * columnNum;
            int rowIndex = 1;
            int columnIndex = 0;
            var book = excel.Application.Workbooks.Add(true);
            try
            {
                foreach (var column in columns)
                {
                    columnIndex++;
                    excel.Cells[rowIndex, columnIndex] = column;
                    if (data.GetColumnType(column) == typeof(string))
                        excel.get_Range(excel.Cells[rowIndex + 1, columnIndex], excel.Cells[rowNum + 1, columnIndex]).NumberFormatLocal = "@";
                }
                for (int i = 0; i < rowNum; i++)
                {
                    rowIndex++;
                    columnIndex = 0;
                    for (int j = 0; j < columnNum; j++)
                    {
                        columnIndex++;
                        excel.Cells[rowIndex, columnIndex] = data[i][columns[j]];
                        wt.Flags[0]++;
                    }

                }
                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;
                book.SaveCopyAs(filename);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                book.Close(false);
                book = null;
                excel.Quit();
                excel = null;
            }

        }
    }
}
