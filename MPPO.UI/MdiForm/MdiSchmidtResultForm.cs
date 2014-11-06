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
    public partial class MdiSchmidtResultForm : DevExpress.XtraEditors.XtraForm
    {
        private MPPO.Protocol.Interface.IMdiDataForm<DataRow> dataForm;
        private MPPO.Protocol.Interface.IDataTable<DataRow> dataTable;
        private List<string> selectedColumns;
        private double costTime;
        private DataTable resultDetail;
        private List<string> result;
        public MdiSchmidtResultForm(MPPO.Protocol.Interface.IMdiDataForm<DataRow> dataform, List<string> selectedcolumns)
        {
            InitializeComponent();
            this.dataForm = dataform;
            this.dataTable = dataform.GetDataTable();
            this.selectedColumns = selectedcolumns;
        }

        private void MdiEntropyResultForm_Load(object sender, EventArgs e)
        {
            this.LoadingControl.Visible = true;
            new Thread(doMethod) { IsBackground = true}.Start();        
        }
        private void doMethod()
        {
            DateTime starttime = DateTime.Now;
            MPPO.Kernel.BusinessLogicOperation.DataProcessOperation.Schmidt(this.dataTable, selectedColumns, out result,out resultDetail); 
            DateTime endtime = DateTime.Now;
            this.costTime = (endtime - starttime).TotalSeconds;
            this.Invoke(new Action(showResult));
        }
        private void showResult()
        {
            this.checkedListBoxControl1.Items.BeginUpdate();
            this.checkedListBoxControl1.Items.Clear();
            foreach (var r in this.result)
            {
                this.checkedListBoxControl1.Items.Add(new DevExpress.XtraEditors.Controls.CheckedListBoxItem(r, false));
            }
            this.checkedListBoxControl1.Items.EndUpdate();
            this.gridControl1.DataSource = this.resultDetail;
            this.LoadingControl.Visible = false;
            var mainform = this.Parent as MPPO.Protocol.Interface.IMainForm;
            if (mainform != null)
                mainform.ShowTime(this.costTime);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem r in this.checkedListBoxControl1.Items)
            {
                if (r.CheckState == CheckState.Checked && this.dataTable.SetColumnUnvisible(r.Value.ToString()))
                    i++;                    ;
            }
            MessageBox.Show("成功更改了"+i+"列");
        }

        private void MdiEntropyResultForm_Resize(object sender, EventArgs e)
        {
            this.LoadingControl.Location = new Point((this.Width - this.LoadingControl.Width) / 2, (this.Height - this.LoadingControl.Height) / 2);
        }






    }
}