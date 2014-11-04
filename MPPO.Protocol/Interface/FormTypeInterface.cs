using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPPO.Protocol.Interface
{
    public interface IMdiDataForm
    {
        string[] GetColumnsList();
        string[] GetColumnsList(bool equal=true,params Type[] ttype);
        IDataTable GetDataTable();
        Type GetColumnType(int index);
        Type GetColumnType(string name);
        bool ContainsColumn(string name);
        void AddColumn(string name);
        void AddColumn(string name, Type datatype);
        bool SetColumnVisible(string name);
        bool SetColumnUnvisible(string name);
        void UIInvoke(Delegate method);
        object GetDataCopy();
        string GetTableName();
    }
}
