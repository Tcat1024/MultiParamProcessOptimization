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
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
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
                    data = MPPO.Data.BasicOledbQuery.DebugGetTable(queryform.command, queryform.conStr,queryform.tablename);
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
            if (this.ActiveMdiChild is MPPO.Protocol.Interface.IMdiDataForm)
            {
                var targetform = (this.ActiveMdiChild as MPPO.Protocol.Interface.IMdiDataForm);
                ConfigForm.DataStandardForm standardform = new ConfigForm.DataStandardForm(targetform.GetColumnsList(false,typeof(string),typeof(DateTime),typeof(bool)));
                if(standardform.ShowDialog()==DialogResult.OK)
                {
                    MPPO.Kernel.BusinessLogicOperation.DataOperation.DataStandard(targetform, standardform.GetInputColumns(), standardform.GetOutputColumns());        
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
            if (this.ActiveMdiChild is MPPO.Protocol.Interface.IMdiDataForm)
            {
                var sourceform = this.ActiveMdiChild as MPPO.Protocol.Interface.IMdiDataForm;
                try
                {
                    MdiForm.MdiDataViewForm dataview = new MdiForm.MdiDataViewForm();
                    dataview.MdiParent = this;
                    dataview.DataSource = sourceform.GetDataCopy();
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
            if (this.ActiveMdiChild is MPPO.Protocol.Interface.IMdiDataForm)
            {
                var targetform = (this.ActiveMdiChild as MPPO.Protocol.Interface.IMdiDataForm);
                ConfigForm.EntropyForm entropuConfigform = new ConfigForm.EntropyForm(targetform.GetTableName(),targetform.GetColumnsList(false, typeof(string), typeof(DateTime), typeof(bool)));
                if (entropuConfigform.ShowDialog() == DialogResult.OK)
                {
                    MdiForm.MdiEntropyResultForm resultview = new MdiForm.MdiEntropyResultForm(targetform, entropuConfigform.SelectedColumns);
                    resultview.MdiParent = this;
                    resultview.Text = "Entropy" + this.MdiChildren.Length + " - " + targetform.GetTableName();
                    resultview.Show();
                }
            }
        }


    }
}