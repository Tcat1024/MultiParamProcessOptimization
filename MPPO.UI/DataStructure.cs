using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MPPO.Kernel;

namespace MPPO.UI
{
    public class ViewData:MPPO.Protocol.Interface.IDataTable
    {
        SPC.Base.Control.CanChooseDataGridView View;
        public ViewData(SPC.Base.Control.CanChooseDataGridView view)
        {
            this.View = view;
            view.GridControl.Invoke(new Action(() => { this.View.ActiveFilter.Add(view.Columns[view.ChooseColumnName], new DevExpress.XtraGrid.Columns.ColumnFilterInfo(view.ChooseColumnName + " = true")); }));  
        }
        public object this[int index]
        {
            get
            {
                return this.View.GetDataRow(index);
            }
        }
        public object[] GetGroup(int index)
        {
            throw new NotImplementedException();
        }
        public int Count()
        {
            return this.View.DataRowCount;
        }
        public void BeginDataUpdate()
        {
            this.View.BeginDataUpdate();
        }
        public void EndDataUpdate()
        {
            this.View.GridControl.FindForm().Invoke(new Action(() => {this.View.EndDataUpdate(); }));
        }
    }
}
