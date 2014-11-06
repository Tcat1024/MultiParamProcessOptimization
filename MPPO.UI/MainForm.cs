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

namespace MPPO.UI
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm,MPPO.Protocol.Interface.IMainForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnQueryDataBase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var queryform = new MPPO.UI.ConfigForm.DebugDataSelectForm();
            if (queryform.ShowDialog() == DialogResult.Yes)
            {
                DataSet data;
                try
                {
                    data = MPPO.Kernel.BusinessLogicOperation.DataAccessOperation.GetSingleTableFromDataBase(queryform.command, queryform.conStr, queryform.tablename);
                    MdiForm.MdiDataViewForm dataview = new MdiForm.MdiDataViewForm();
                    dataview.MdiParent = this;
                    dataview.DataSource = data;
                    dataview.DataMember = data.Tables[0].TableName;
                    dataview.Text = "WorkTable"+this.MdiChildren.Length+" - "+data.Tables[0].TableName;
                    dataview.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.stlCurrentForm.Caption = this.ActiveMdiChild.Text;
            else
                this.stlCurrentForm.Caption = "";
        }
        private void btnStandardData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild is MPPO.Protocol.Interface.IMdiDataForm<DataRow>)
            {
                var targetform = (this.ActiveMdiChild as MPPO.Protocol.Interface.IMdiDataForm<DataRow>);
                ConfigForm.DataStandardForm standardform = new ConfigForm.DataStandardForm(targetform.GetDataTable().GetColumnsList(false,typeof(string),typeof(DateTime),typeof(bool)));
                if(standardform.ShowDialog()==DialogResult.OK)
                {
                    MPPO.Kernel.BusinessLogicOperation.DataProcessOperation.DataStandard(targetform, standardform.InputColumns, standardform.OutputColumns);        
                }
            }
        }
        private void btnWindowRecover_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var form in this.MdiChildren)
            {
                form.WindowState = FormWindowState.Normal;
            }
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void btnWindowCascade_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void btnWindowTile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void btnWindowMin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach(var form in this.MdiChildren)
            {
                form.WindowState = FormWindowState.Minimized;
            }
        }

        private void btnCopyTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild is MPPO.Protocol.Interface.IMdiDataForm<DataRow>)
            {
                var sourceform = this.ActiveMdiChild as MPPO.Protocol.Interface.IMdiDataForm<DataRow>;
                try
                {
                    MdiForm.MdiDataViewForm dataview = new MdiForm.MdiDataViewForm();
                    dataview.MdiParent = this;
                    dataview.DataSource = sourceform.GetDataTable().GetDataCopy();
                    dataview.Text = "WorkTable" + this.MdiChildren.Length + " - " + (dataview.DataSource as DataTable).TableName;
                    dataview.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void btnEntropy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild is MPPO.Protocol.Interface.IMdiDataForm<DataRow>)
            {
                var targetform = (this.ActiveMdiChild as MPPO.Protocol.Interface.IMdiDataForm<DataRow>);
                var targettable = targetform.GetDataTable();
                ConfigForm.AttributeSelectionForm Configform = new ConfigForm.AttributeSelectionForm(targettable.GetTableName(), targettable.GetColumnsList(false, typeof(string), typeof(DateTime), typeof(bool)));
                Configform.Text += "_信息熵";
                if (Configform.ShowDialog() == DialogResult.OK)
                {
                    MdiForm.MdiEntropyResultForm resultview = new MdiForm.MdiEntropyResultForm(targetform, Configform.SelectedColumns);
                    resultview.MdiParent = this;
                    resultview.Text = "Entropy" + this.MdiChildren.Length + " - " + targettable.GetTableName();
                    resultview.Show();
                }
            }
        }

        private void btnKMeans_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild is MPPO.Protocol.Interface.IMdiDataForm<DataRow>)
            {
                var targetform = (this.ActiveMdiChild as MPPO.Protocol.Interface.IMdiDataForm<DataRow>);
                var targettable = targetform.GetDataTable();
                ConfigForm.KMeansForm kMeansConfigform = new ConfigForm.KMeansForm(targettable.GetColumnsList(false, typeof(string), typeof(DateTime), typeof(bool)));
                if (kMeansConfigform.ShowDialog() == DialogResult.OK)
                {
                    MdiForm.MdiKMeansResultForm resultview = new MdiForm.MdiKMeansResultForm(targetform, kMeansConfigform.SelectedColumns, kMeansConfigform.StartClustNum, kMeansConfigform.EndClustNum, kMeansConfigform.MaxCount, kMeansConfigform.Avg, kMeansConfigform.Stdev);
                    resultview.MdiParent = this;
                    resultview.Text = "KMeans" + this.MdiChildren.Length + " - " + targettable.GetTableName();
                    resultview.Show();
                }
            }
        }
        public void ShowTime(double time)
        {
            this.stlCostTime.Caption = time + "秒";
        }

        private void btnSchmidtSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild is MPPO.Protocol.Interface.IMdiDataForm<DataRow>)
            {
                var targetform = (this.ActiveMdiChild as MPPO.Protocol.Interface.IMdiDataForm<DataRow>);
                var targettable = targetform.GetDataTable();
                ConfigForm.AttributeSelectionForm Configform = new ConfigForm.AttributeSelectionForm(targettable.GetTableName(), targettable.GetColumnsList(false, typeof(string), typeof(DateTime), typeof(bool)));
                Configform.Text += "_施密特";
                if (Configform.ShowDialog() == DialogResult.OK)
                {
                    MdiForm.MdiSchmidtResultForm resultview = new MdiForm.MdiSchmidtResultForm(targetform, Configform.SelectedColumns);
                    resultview.MdiParent = this;
                    resultview.Text = "Schmidt" + this.MdiChildren.Length + " - " + targettable.GetTableName();
                    resultview.Show();
                }
            }
        }

        private void btnOpenTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog configform = new OpenFileDialog();
            configform.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            configform.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|Excel 97-2003 工作簿(*.xls)|*.xls";
            configform.FilterIndex = 1;
            configform.RestoreDirectory = true;
            if (configform.ShowDialog() == DialogResult.OK)
            {
                DataSet data = MPPO.Kernel.BusinessLogicOperation.DataAccessOperation.GetTablesFromExcel(configform.FileName);
                foreach(DataTable table in data.Tables)
                {
                    MdiForm.MdiDataViewForm dataview = new MdiForm.MdiDataViewForm();
                    dataview.MdiParent = this;
                    dataview.DataSource = table;
                    dataview.Text = "WorkTable" + this.MdiChildren.Length + " - " + table.TableName;
                    dataview.Show();
                }
            }
        }



    }
}