using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPPO.Protocol.Interface
{
    public interface IDataTable<T>
    {
        string Name { get; set; }
        int RowCount { get; }
        int ColumnCount { get; }
        T this[int index] { get;}
        object[] GetGroup(int index);
        T NewRow();
        int GetSourceIndex(int i);
        T GetSourceRowbySourceIndex(int i);
        string[] GetColumnsList();
        string[] GetColumnsList(bool equal = true, params Type[] ttype);
        Type GetColumnType(int index);
        Type GetColumnType(string name);
        bool ContainsColumn(string name);
        void AddColumn(string name);
        void AddColumn(string name, Type datatype);
        bool SetColumnVisible(string name);
        bool SetColumnUnvisible(string name);
        object Copy();
    }
}
