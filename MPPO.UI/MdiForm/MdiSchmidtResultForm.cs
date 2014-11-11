using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace MPPO.UI.MdiForm
{
    public partial class MdiSchmidtResultForm : DevExpress.XtraEditors.XtraForm, MPPO.Protocol.Interface.IMdiResultForm
    {
        public Tuple<List<string>, List<double>, DataTable> Result;
        public int MdiIndex { get; set; }
        private string _Caption;
        public string Caption
        {
            get
            {
                return this._Caption;
            }
            set
            {
                this._Caption = value;
                this.Text = "Schmidt" + MdiIndex + " - " + value;
            }
        }
        public MPPO.Protocol.Interface.IMdiDataForm<DataRow> DataForm { get; set; }
        public MdiSchmidtResultForm(MPPO.Protocol.Interface.IMdiDataForm<DataRow> dataform)
        {
            InitializeComponent();
            this.DataForm = dataform;
            this.MdiParent = dataform.MdiParent;
            this.MdiIndex = dataform.MdiIndex;
            this.Caption = dataform.Caption;
        }
        public void ShowResult()
        {
            this.checkedListBoxControl1.Items.BeginUpdate();
            this.checkedListBoxControl1.Items.Clear();
            foreach (var r in this.Result.Item1)
            {
                this.checkedListBoxControl1.Items.Add(new DevExpress.XtraEditors.Controls.CheckedListBoxItem(r, false));
            }
            this.checkedListBoxControl1.Items.EndUpdate();
            this.gridControl1.DataSource = this.Result.Item3;
            int columncount = this.gridView1.Columns.Count;
            for (int i = 0; i < columncount; i++)
            {
                this.gridView1.Columns[i].Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "", this.Result.Item2[i].ToString()));
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem r in this.checkedListBoxControl1.Items)
            {
                if (r.CheckState == CheckState.Checked && this.DataForm.GetDataTable().SetColumnUnvisible(r.Value.ToString()))
                    i++;                    ;
            }
            MessageBox.Show("成功更改了"+i+"列");
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int index = this.checkedListBoxControl1.Items.IndexOf(e.Column.FieldName);
            this.checkedListBoxControl1.SelectedIndex = index;
        }



    }
}