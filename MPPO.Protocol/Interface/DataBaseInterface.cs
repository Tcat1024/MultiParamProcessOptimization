using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPPO.Protocol.Interface
{
    public interface IDataTable<T>
    {
        T this[int index] { get;}
        object[] GetGroup(int index);
        int Count();
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
        object GetDataCopy();
        string GetTableName();
    }
}
