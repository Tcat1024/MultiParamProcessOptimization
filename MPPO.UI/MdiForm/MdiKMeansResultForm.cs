using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraEditors;

namespace MPPO.UI.MdiForm
{
    public partial class MdiKMeansResultForm : DevExpress.XtraEditors.XtraForm, MPPO.Protocol.Interface.IMdiResultForm
    {
        public DataSet Result;
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
                this.Text = "KMeans" + MdiIndex + " - " + value;
            }
        }
        public MPPO.Protocol.Interface.IMdiDataForm<DataRow> DataForm { get; set; }
        public MdiKMeansResultForm(MPPO.Protocol.Interface.IMdiDataForm<DataRow> dataform)
        {
            InitializeComponent();
            this.DataForm = dataform;
            this.MdiParent = dataform.MdiParent;
            this.MdiIndex = dataform.MdiIndex;
            this.Caption = dataform.Caption;
        }
        public void ShowResult()
        {
            this.gridControl2.DataSource = Result;
            this.gridControl2.DataMember = "Results";
            this.gridControl1.DataSource = Result;
            this.gridControl1.DataMember = "OverView";
            this.gridView2.Columns.ColumnByFieldName("序号").Visible = false;
            this.gridView2.GroupSummary.Clear();
            this.gridView2.GroupSummary.Add(new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, this.gridView2.Columns[0].FieldName, null, "Count:{0}"));
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow temp;
            if((temp =gridView1.GetDataRow(e.FocusedRowHandle))!=null)
            (this.gridView2.DataSource as DataView).RowFilter = "序号 = "+temp[0].ToString();
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit target;
            string column;
            if ((target = sender as DevExpress.XtraEditors.ButtonEdit) != null && (column = target.Text.Trim()) != "")
            {
                var datatable= this.DataForm.GetDataTable();
                if (datatable.ContainsColumn(column))
                {
                    if ((MessageBox.Show("原表中已有列" + column + "，是否要覆盖？", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes))
                    {
                        int rowcount = (this.gridView2.DataSource as DataView).Count;
                        for (int i = 0; i < rowcount; i++)
                            datatable[i, column] = (this.gridView2.DataSource as DataView)[i]["类标号"];
                        datatable.SetColumnVisible(column);
                    }
                }
                else
                {
                    datatable.AddColumn(column, typeof(int));
                    int rowcount = (this.gridView2.DataSource as DataView).Count;
                    for (int i = 0; i < rowcount; i++)
                        datatable[i, column] = (this.gridView2.DataSource as DataView)[i]["类标号"];
                }
            }
        }



    }
}