using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace MPPO.DataAccess
{
    public class BasicOledbQuery
    {
        public static DataSet DebugGetTable(string cmd, string conn,string tablename)
        {
            OleDbConnection con = new OleDbConnection(conn);
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd, conn);
            adp.MissingSchemaAction = MissingSchemaAction.Add;
            DataSet result = new DataSet();
            try
            {
                adp.Fill(result, tablename);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        public static List<string> GetTableNames(string conn)
        {
            OleDbConnection con = new OleDbConnection(conn);
            OleDbCommand com = new OleDbCommand("select * from user_tables order by table_name", con);
            try
            {
                con.Open();
                OleDbDataReader reader = com.ExecuteReader();
                List<string> result = new List<string>();
                while (reader.Read())
                {
                    result.Add(reader[0].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        public static List<string> GetColumnNames(string conn, string tablename)
        {
            OleDbConnection con = new OleDbConnection(conn);
            OleDbCommand com = new OleDbCommand(string.Format(@"select aa.COLUMN_NAME,bb.CONSTRAINT_TYPE from (select column_name from user_tab_columns where table_name='{0}'
                                order by column_id) aa left join (select a.column_name,b.CONSTRAINT_TYPE from user_cons_columns a, 
                                user_constraints b where a.constraint_name = b.constraint_name and b.constraint_type = 'P' 
                                and a.table_name = '{0}') bb on aa.column_name = bb.column_name", tablename.ToUpper()), con);
            try
            {
                con.Open();
                OleDbDataReader reader = com.ExecuteReader();
                List<string> result = new List<string>();
                while (reader.Read())
                {

                    if (reader[1] != null)
                    {
                        if (reader[1].ToString() == "P")
                        {
                            result.Add(reader[0].ToString() + "(PK)");
                            continue;
                        }
                    }
                    result.Add(reader[0].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
