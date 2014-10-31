using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MPPO.Test
{
    public partial class Form1 : Form
    {
        List<DataType> MyData = new List<DataType>();
        List<DataType> MyResult = new List<DataType>();
        Random DataMaker = new Random();
        const int datacount = 1000;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 1000; i++)
            {
                MyData.Add(new DataType(DataMaker.Next(100) + 300 * (int)((i / 300) + 1), DataMaker.NextDouble() * 200 + 300 * (int)((i / 300) + 1), DataMaker.NextDouble() * 300 + 300 * (int)((i / 300) + 1)));
                MyResult.Add(new DataType());
            }
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridControl1.DataSource = MyData;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime current = DateTime.Now;
            MPPO.Pretreat.Standardization.Zscore<DataType>(MyData, MyResult, new string[] { "count", "index", "id" });
            DateTime last = DateTime.Now;
            MessageBox.Show("用时" + (last - current));
            this.gridControl1.DataSource = MyResult;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime current = DateTime.Now;
            MPPO.Pretreat.Standardization.Zscore2<DataType>(MyData, MyResult, new string[] { "count", "index", "id" });
            DateTime last = DateTime.Now;
            MessageBox.Show("用时" + (last - current));
            this.gridControl1.DataSource = MyResult;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime current = DateTime.Now;
            double[] en;
            en = MPPO.Pretreat.Entropy.GetEntropy<DataType>(MyData, new string[] { "count", "index", "id" });
            DateTime last = DateTime.Now;
            MessageBox.Show("用时" + (last - current) + ",信息熵为" + en[0] + "," + en[1] + "," + en[2]);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MPPO.Cluster.ClusterReport<DataType> result= MPPO.Cluster.KMeans.AutoZScoredStart<DataType>(MyResult, new string[] { "count", "index", "id" },8,2,10);
            MessageBox.Show("用时" + result.TotalCastTime + "ms，循环" + result.HisResult.Count + "次");
            for (int i = 0; i < MyResult.Count; i++)
                MyResult[i].ClusterResult = result.FanialResult.ClassNumbers[i];
            this.gridControl1.DataSource = MyResult;
            //ResultColumn.Caption = "分类";
            //ResultColumn.Name = "gridColumn1";
            //ResultColumn.Visible = true;
            //ResultColumn.VisibleIndex = 0;
            //this.gridView1.Columns.Add(ResultColumn);
            this.gridView1.RefreshData();
            this.gridControl1.Refresh();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MPPO.Cluster.ClusterReport<DataType> result = MPPO.Cluster.KMeans.AutoZScoredParallelStart<DataType>(MyResult, new string[] { "count", "index", "id" }, 8, 2, 10);
            MessageBox.Show("用时" + result.TotalCastTime + "ms，循环" + result.HisResult.Count + "次");
            for (int i = 0; i < MyResult.Count; i++)
                MyResult[i].ClusterResult = result.FanialResult.ClassNumbers[i];
            this.gridControl1.DataSource = MyResult;
            //ResultColumn.Caption = "分类";
            //ResultColumn.Name = "gridColumn1";
            //ResultColumn.Visible = true;
            //ResultColumn.VisibleIndex = 0;
            //this.gridView1.Columns.Add(ResultColumn);
            this.gridView1.RefreshData();
            this.gridControl1.Refresh();
        }

        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            //e.Info.InnerElements.Clear();
            //e.Painter.DrawObject(e.Info);

            //var repositoryCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            //repositoryCheck.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            //repositoryCheck.Caption = "";
            //var info = repositoryCheck.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;

            //var painter = repositoryCheck.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
            //info.EditValue = true;
            //info.Bounds = e.Bounds;
            //info.CalcViewInfo(e.Graphics);
            //var args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(e.Graphics), e.Bounds);
            //painter.Draw(args);
            //args.Cache.Dispose();
            ////e.Handled = true; 
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            var gridView = (sender as DevExpress.XtraGrid.Views.Grid.GridView);
            gridView.PostEditor();
            Point pt = gridView.GridControl.PointToClient(Control.MousePosition);
            var info = gridView.CalcHitInfo(pt); 
            if(info.InColumnPanel)
            {
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var data = DataAccess.GetBOFHeatInfo("4500000");
            this.gridControl1.DataSource = data;
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var data = DataAccess.GetLFHeatInfo("4500000");
            this.gridControl1.DataSource = data;
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var data = DataAccess.GetCCHeatInfo("4500000");
            this.gridControl1.DataSource = data;
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string strName = "";
            try
            {
                if (this.gridView1.RowCount == 0)
                {
                    MessageBox.Show("Grid表格中没有数据，不能导出为Excel");
                    return;
                }
                DateTime MMSDate = DateTime.Now;
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|Excel 97-2003 工作簿(*.xls)|*.xls|PDF(*.pdf)|*.pdf|Unicode 文本(*.txt)|*.txt";
                    saveFileDialog.FilterIndex = 0;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.CreatePrompt = true;
                    saveFileDialog.Title = "导出文件保存路径";
                    //默认的文件名
                    saveFileDialog.FileName = "test" + " - " + MMSDate.ToString("yyyyMMdd");
                    //saveFileDialog.ShowDialog();
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
                        strName = saveFileDialog.FileName;
                        if (strName.LastIndexOf(".") - strName.LastIndexOf("\\") != 0)
                        {
                            switch(saveFileDialog.FilterIndex)
                            {
                                case 1: 
                                    DevExpress.XtraPrinting.XlsxExportOptions xlsx = ps.ExportOptions.Xlsx;
                                    xlsx.ShowGridLines = true; 
                                    this.gridView1.ExportToXlsx(strName); break;
                                case 2: 
                                    DevExpress.XtraPrinting.XlsExportOptions xls = ps.ExportOptions.Xls;
                                    xls.ShowGridLines = true;
                                    this.gridView1.ExportToXls(strName); break;
                                case 3: 
                                    this.gridView1.ExportToPdf(strName); break;
                                case 4: 
                                    this.gridView1.ExportToText(strName); break;
                            }
                            MessageBox.Show("导出成功", "test");
                        }
                        else
                        {
                            MessageBox.Show("保存的名称不能为空");
                        }

                    }
                }
            }
            catch (System.Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
            finally
            {
                GC.Collect();
            }
        
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var data = DataAccess.GetKRHeatInfo("4500000");
            this.gridControl1.DataSource = data;
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        
        
    }
    public class DataType:BasicDataType
    {
        public double count { get; set; }
        public double index { get; set; }
        public double id { get; set; }
        public DataType(double input1,double input2,double input3)
        {
            this.count = input1;
            this.index = input2;
            this.id = input3;
        }
        public DataType()
        {

        }
    }
    public abstract class BasicDataType
    {
        [DisplayName("类标号")]
        public int ClusterResult { get; set; }
        public bool Selected { get; set; }
    }

}
