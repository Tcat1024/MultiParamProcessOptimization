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
    public partial class MdiEntropyResultForm : DevExpress.XtraEditors.XtraForm,MPPO.Protocol.Interface.IMdiResultForm
    {
        public List<Tuple<string, double>> Result;
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
                this.Text = "Entropy" + MdiIndex + " - " + value;
            }
        }
        public MPPO.Protocol.Interface.IMdiDataForm<DataRow> DataForm { get; set; }
        public MdiEntropyResultForm(MPPO.Protocol.Interface.IMdiDataForm<DataRow> dataform)
        {
            InitializeComponent();
            this.DataForm = dataform;
            this.MdiParent = dataform.MdiParent;
            this.MdiIndex = dataform.MdiIndex;
            this.Caption = dataform.Caption;
        }
        public void ShowResult()
        {
            this.advChartControl1.Series[0].Points.BeginUpdate();
            this.checkedListBoxControl1.Items.BeginUpdate();
            this.checkedListBoxControl1.Items.Clear();
            this.advChartControl1.Series[0].Points.Clear();
            foreach (var r in Result)
            {
                this.advChartControl1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(r.Item1, r.Item2));
                this.checkedListBoxControl1.Items.Insert(0, new DevExpress.XtraEditors.Controls.CheckedListBoxItem(r.Item1, false));
            }
            this.advChartControl1.Series[0].Points.EndUpdate();
            this.checkedListBoxControl1.Items.EndUpdate();
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

        private void advChartControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var targetcontrol =sender as DevExpress.XtraCharts.ChartControl;
            if(targetcontrol!=null)
            {
                var hitinfo = (targetcontrol.Diagram as DevExpress.XtraCharts.XYDiagram2D).PointToDiagram(e.Location);
                if(hitinfo!=null&&hitinfo.QualitativeArgument!=null)
                {
                    int index = this.checkedListBoxControl1.Items.IndexOf(hitinfo.QualitativeArgument);
                    if (index >= 0)
                        this.checkedListBoxControl1.SelectedIndex = index;
                }
            }
        }

    }
}