using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MPPO.UI.MdiForm
{
    public partial class MdiEntropyResultForm : DevExpress.XtraEditors.XtraForm
    {
        private MPPO.Protocol.Interface.IMdiDataForm dataForm;
        private List<string> selectedColumns;
        public MdiEntropyResultForm(MPPO.Protocol.Interface.IMdiDataForm dataform,List<string> selectedcolumns)
        {
            InitializeComponent();
            this.dataForm = dataform;
            this.selectedColumns = selectedcolumns;
        }

        private void MdiEntropyResultForm_Load(object sender, EventArgs e)
        {
            List<Tuple<string, double>> result;
            MPPO.Kernel.BusinessLogicOperation.DataMiningOperation.Entropy(dataForm.GetDataTable(), selectedColumns, out result);
            this.advChartControl1.Series[0].Points.BeginUpdate();
            this.checkedListBoxControl1.Items.BeginUpdate();
            this.checkedListBoxControl1.Items.Clear();
            this.advChartControl1.Series[0].Points.Clear();
            foreach (var r in result)
            {
                this.advChartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(r.Item1, r.Item2));
                this.checkedListBoxControl1.Items.Insert(0,new DevExpress.XtraEditors.Controls.CheckedListBoxItem(r.Item1,false));
            }
            this.advChartControl1.Series[0].Points.EndUpdate();
            this.checkedListBoxControl1.Items.EndUpdate();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach(DevExpress.XtraEditors.Controls.CheckedListBoxItem r in this.checkedListBoxControl1.Items)
            {
                if (r.CheckState == CheckState.Checked && this.dataForm.SetColumnUnvisible(r.Value.ToString()))
                    i++;                    ;
            }
            MessageBox.Show("成功更改了"+i+"列");
        }






    }
}