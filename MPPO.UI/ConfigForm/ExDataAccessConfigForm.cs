using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors;
using MPPO.Kernel.BusinessLogicOperation;

namespace MPPO.UI.ConfigForm
{
    public partial class ExDataAccessConfigForm : DevExpress.XtraEditors.XtraForm
    {
        public ExDataAccessConfigForm()
        {
            InitializeComponent();
        }
        private AppDomain currentDomain;
        private ExDataAccess exDataAccess;
        public DataTable ResultTable { get; private set; }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog configform = new OpenFileDialog();
            configform.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            configform.Filter = "程序集文件(*.dll,*.exe)|*.dll;*.exe";
            configform.FilterIndex = 1;
            configform.RestoreDirectory = true;
            if (configform.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (currentDomain != null)
                        AppDomain.Unload(currentDomain);
                    currentDomain = AppDomain.CreateDomain("temp");
                    string configfile = configform.FileName + ".config";
                    string filedic = Path.GetDirectoryName(configform.FileName);
                    var m = typeof(AppDomainSetup).GetMethod("UpdateContextProperty", BindingFlags.NonPublic | BindingFlags.Static);
                    var funsion = typeof(AppDomain).GetMethod("GetFusionContext", BindingFlags.NonPublic | BindingFlags.Instance);
                    if(File.Exists(configfile))
                        currentDomain.SetData("APP_CONFIG_FILE", configfile);
                    var test = currentDomain.SetupInformation;
                    exDataAccess = (ExDataAccess)currentDomain.CreateInstanceAndUnwrap(typeof(ExDataAccess).Assembly.FullName, typeof(ExDataAccess).FullName);
                    currentDomain.SetData("APPBASE", filedic);
                    m.Invoke(null, new object[] { funsion.Invoke(currentDomain, null), "APPBASE", filedic });
                    this.textEdit1.Text = configform.FileName;
                    var results = exDataAccess.FindAttributes(configform.FileName);
                    if (results.Count > 0)
                    {
                        this.treeList1.ClearNodes();
                        foreach (var result in results)
                        {
                            this.treeList1.Nodes.Add(result[0], result[1], result[2]);
                        }
                    }
                    
                    currentDomain.SetupInformation.ConfigurationFile =configform.FileName+".config";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.treeList1.Selection.Count < 1)
                {
                    MessageBox.Show("未选择任何方法");
                    return;
                }
                this.ResultTable = exDataAccess.GetData(new string[] { this.treeList1.Selection[0][0].ToString(), this.treeList1.Selection[0][1].ToString() });
                if (ResultTable == null)
                {
                    MessageBox.Show("数据为null");
                    return;
                }
                if (currentDomain != null)
                    AppDomain.Unload(currentDomain);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (currentDomain != null)
                AppDomain.Unload(currentDomain);
            this.DialogResult = DialogResult.Cancel;
        }
    }
}