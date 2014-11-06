using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MPPO.Protocol.Interface
{
    public interface IMainForm
    {
        void ShowTime(double time);
    }
    public interface IMdiDataForm<T>
    {
        IDataTable<T> GetDataTable();
        void UIInvoke(Delegate method);
    }
}
