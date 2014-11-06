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
    public partial class MdiKMeansResultForm : DevExpress.XtraEditors.XtraForm
    {
        private MPPO.Protocol.Interface.IMdiDataForm<DataRow> dataForm;
        private string[] selectedColumns;
        private int startClustNum;
        private int endClustNum;
        private int maxCount;
        private double[] avg;
        private double[] stdev;
        private Protocol.Interface.IDataTable<DataRow> dataTable;
        private DataSet result;
        private double costTime;
        private object[] flags;
        private int dataCount;
        public MdiKMeansResultForm(MPPO.Protocol.Interface.IMdiDataForm<DataRow> dataform,string[] selectedcolumns, int startclustnum,int endclustnum,int maxcount,double avg,double stdev)
        {
            InitializeComponent();
            this.dataForm = dataform;
            this.dataTable = dataform.GetDataTable();
            this.dataCount = this.dataTable.Count();
            this.selectedColumns = selectedcolumns;
            this.startClustNum = startclustnum<2?2:startclustnum;
            this.endClustNum = endclustnum < 2 ? (int)Math.Pow(dataCount, 0.5) : endclustnum;
            this.maxCount = maxcount < 2 ? 10 : maxcount;
            int paracount = selectedcolumns.Length;
            if (!double.IsNaN(avg))
            {
                this.avg = new double[paracount];
                for (int i = 0; i < paracount; i++)
                    this.avg[i] = avg;
            }
            if (!double.IsNaN(stdev))
            {
                this.stdev = new double[paracount];
                for (int i = 0; i < paracount; i++)
                    this.stdev[i] = stdev;
            }
            int clustcount = this.endClustNum-this.startClustNum+1;
            flags = new object[clustcount];
            for (int i = 0; i < clustcount; i++)
                flags[i] = 0;
        }

        private void MdiKMeansResultForm_Load(object sender, EventArgs e)
        {
            this.LoadingControl.Visible = true;
            new Thread(doMethod) { IsBackground = true}.Start();
        }
        private void getProgress()
        {
            int progress;
            while (true)
            {
                Thread.Sleep(1000);
                progress = 0;
                foreach (var o in this.flags)
                    progress+=(int)o;
                progress = progress * 100 / (this.maxCount * (this.endClustNum - this.startClustNum + 1));
                this.Invoke(new Action(() => { this.progressBarControl1.Position = progress; }));
               
            }
        }
        private void doMethod()
        {
            var progressthread = new Thread(getProgress) { IsBackground = true };
            progressthread.Start();
            DateTime starttime = DateTime.Now;
            MPPO.Kernel.BusinessLogicOperation.DataMiningOperation.KMeans(this.dataTable, this.selectedColumns, this.maxCount, this.startClustNum, this.endClustNum, this.avg, this.stdev,this.flags,out this.result);
            DateTime endtime = DateTime.Now;
            this.costTime = (endtime - starttime).TotalSeconds;
            this.Invoke(new Action(showResult));
            progressthread.Abort();
        }
        private void showResult()
        {
            this.gridControl2.DataSource = result;
            this.gridControl2.DataMember = "Results";
            this.gridControl1.DataSource = result;
            this.gridControl1.DataMember = "OverView";
            this.gridView2.Columns.ColumnByFieldName("序号").Visible = false;
            this.gridView3.Columns.ColumnByFieldName("序号").Visible = false;
            this.LoadingControl.Visible = false;
            var mainform = this.Parent as MPPO.Protocol.Interface.IMainForm;
            if (mainform != null)
                mainform.ShowTime(this.costTime);
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
                if (this.dataTable.ContainsColumn(column))
                {
                    if ((MessageBox.Show("原表中已有列" + column + "，是否要覆盖？", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes))
                    {
                        for (int i = 0; i < this.dataCount; i++)
                            this.dataTable[i][column] = this.result.Tables["Results"].Rows[i]["分类号"];
                        this.dataTable.SetColumnVisible(column);
                    }
                }
                else
                {
                    this.dataTable.AddColumn(column, typeof(int));
                    for (int i = 0; i < this.dataCount; i++)
                        this.dataTable[i][column] = this.result.Tables["Results"].Rows[i]["分类号"];
                }
            }
        }

        private void MdiKMeansResultForm_Resize(object sender, EventArgs e)
        {
            this.LoadingControl.Location = new Point((this.Width - this.LoadingControl.Width) / 2, (this.Height - this.LoadingControl.Height) / 2);
        }
    }
}