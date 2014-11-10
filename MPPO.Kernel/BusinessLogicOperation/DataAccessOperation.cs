using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Threading;
using System.Reflection;

namespace MPPO.Kernel.BusinessLogicOperation
{
    public partial class DataAccessOperation
    {
        public static void GetSingleTableFromDataBase(MPPO.Protocol.Interface.IMdiDataForm<DataRow> targetform,string command,string conStr,string tablename)
        {
            var data = MPPO.DataAccess.BasicOledbQuery.DebugGetTable(command, conStr,tablename);
            targetform.DataSource = data;
            targetform.DataMember = tablename;
            targetform.Caption = tablename; 
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
        public static void ExportTableToExcel(MPPO.Protocol.Interface.IDataTable<DataRow> targettable, string filepath,Protocol.Structure.WaitObject wt)
        {
            try
            {
                MPPO.DataAccess.BasicExcelOperation.ExportToExcel(targettable, filepath, wt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
            
        }
        public static void CopyViewDataFromData(MPPO.Protocol.Interface.IMdiDataForm<DataRow> targetform,MPPO.Protocol.Interface.IDataTable<DataRow> data)
        {
            targetform.DataSource = data.Copy();
            targetform.Caption = data.Name;
        }
    }
    public class ExDataAccess : MarshalByRefObject
    {
        private Assembly targetAssembly;
        public List<string[]> FindAttributes(string filepath)
        {
            List<string[]> result = new List<string[]>();
            targetAssembly = Assembly.LoadFrom(filepath);            
            Type[] types = targetAssembly.GetTypes();
            foreach(var type in types)
            {
                if(type.IsClass)
                {
                    var classattributes = type.GetCustomAttributes(typeof(MPPO.Protocol.Attribute.ExDataAccessClassAttribute), false);
                    if(classattributes.Length>0)
                    {
                        var methods = type.GetMethods();
                        foreach(var method in methods)
                        {
                            if (method.ReturnType == typeof(DataTable))
                            {
                                var methodattributes = method.GetCustomAttributes(typeof(MPPO.Protocol.Attribute.ExDataGetMethodAttribute), false);
                                if (methodattributes.Length > 0)
                                {
                                    result.Add(new string[] { type.FullName, method.Name, (methodattributes[0] as MPPO.Protocol.Attribute.ExDataGetMethodAttribute).Description });                       
                                }
                            }
                        }
                    }                
                }
            }
            return result;
        }
        public DataTable GetData(string[] input)
        {
            if (targetAssembly == null)
                return null;
            try
            {
                var classtype = targetAssembly.GetType(input[0], true);
                var classobject = Activator.CreateInstance(classtype);
                return (DataTable)classtype.InvokeMember(input[1], BindingFlags.InvokeMethod, null, classobject, null);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
