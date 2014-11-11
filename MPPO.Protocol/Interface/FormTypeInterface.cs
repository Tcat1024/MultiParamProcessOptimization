using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace MPPO.Protocol.Interface
{
    public interface IMainForm
    {
        IMdiDataForm<DataRow> ActiveDataForm { get; }
    }
    public interface IMdiDataForm<T>
    {
        object DataSource { get; set; }
        string DataMember { get; set; }
        int MdiIndex { get; set; }
        string Text { get; }
        string Caption { get; set; }
        bool IsBusy { get; }
        double CostTime { get; }
        string State { get; }
        Form MdiParent { get; }
        event EventHandler MethodEnd;
        event EventHandler StateChanged;
        IDataTable<T> GetDataTable();
        void UIInvoke(Delegate method);
        void DoMethod(string methodname, Action<object> method, Structure.WaitObject waithandle, Action callback = null);
    }
    public interface IMdiResultForm
    {
        IMdiDataForm<DataRow> DataForm { get; set; }
        int MdiIndex { get; set; }
        string Caption { get; set; }
        void ShowResult();
    }
}
