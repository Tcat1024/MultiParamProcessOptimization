using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace MPPO.UI
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm,MPPO.Protocol.Interface.IMainForm
    {
        public MPPO.Protocol.Interface.IMdiDataForm<DataRow> ActiveDataForm { get; private set; }
        public int DataFormIndex = 0;
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            MPPO.Protocol.Interface.IMdiDataForm<DataRow> dataform;
            MPPO.Protocol.Interface.IMdiResultForm resultform;
            if ((dataform = this.ActiveMdiChild as MPPO.Protocol.Interface.IMdiDataForm<DataRow>) != null)
            {
                registerDataForm(dataform);
            }
            else if ((resultform = this.ActiveMdiChild as MPPO.Protocol.Interface.IMdiResultForm) != null)
            {
                if (resultform.DataForm!=this.ActiveDataForm)
                    registerDataForm(resultform.DataForm);
            }
        }
        private void registerDataForm(MPPO.Protocol.Interface.IMdiDataForm<DataRow> dataform)
        {
            if(this.ActiveDataForm!=null)
            {
                this.ActiveDataForm.MethodEnd -= showCostTime;
                this.ActiveDataForm.StateChanged -= showState;
            }
            this.stlCurrentForm.Caption = dataform.Text;
            this.stlFormState.Caption = dataform.State;
            this.ActiveDataForm = dataform;
            dataform.MethodEnd += showCostTime;
            dataform.StateChanged += showState;
        }
        private void showState(object sender,EventArgs e)
        {
            this.stlFormState.Caption = this.ActiveDataForm.State;
        }
        private void showCostTime(object sender,EventArgs e)
        {
            this.stlCostTime.Caption = this.ActiveDataForm.CostTime + "秒";
        }
        private void btnQueryDataBase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var configform = new MPPO.UI.ConfigForm.DebugDataSelectForm();
            if (configform.ShowDialog() == DialogResult.Yes)
            {
                try
                {
                    MdiForm.MdiDataViewForm targetform = new MdiForm.MdiDataViewForm();
                    targetform.MdiParent = this;
                    targetform.MdiIndex = this.DataFormIndex++;
                    targetform.Show();
                    MPPO.Kernel.BusinessLogicOperation.DataAccessOperation.GetSingleTableFromDataBase(targetform, configform.command, configform.conStr, configform.tablename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        private void btnStandardData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveDataForm != null && !this.ActiveDataForm.IsBusy)
            {
                var targetform = this.ActiveDataForm;
                var configform = new ConfigForm.DataStandardForm(targetform.GetDataTable().GetColumnsList(false,typeof(string),typeof(DateTime),typeof(bool)));
                if(configform.ShowDialog()==DialogResult.OK)
                {
                    MPPO.Kernel.BusinessLogicOperation.DataProcessOperation.DataStandard(targetform, configform.InputColumns, configform.OutputColumns);                 
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
            if (this.ActiveDataForm != null && !this.ActiveDataForm.IsBusy)
            {
                var data = this.ActiveDataForm.GetDataTable();
                try
                {
                    MdiForm.MdiDataViewForm targetform = new MdiForm.MdiDataViewForm();
                    targetform.MdiParent = this;
                    targetform.MdiIndex = this.DataFormIndex++;
                    targetform.Show();
                    MPPO.Kernel.BusinessLogicOperation.DataAccessOperation.CopyViewDataFromData(targetform, data);
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
            if (this.ActiveDataForm != null && !this.ActiveDataForm.IsBusy)
            {
                var targetform = this.ActiveDataForm;
                var targettable = targetform.GetDataTable();
                ConfigForm.AttributeSelectionForm configform = new ConfigForm.AttributeSelectionForm(targettable.Name, targettable.GetColumnsList(false, typeof(string), typeof(DateTime), typeof(bool)));
                if (configform.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MdiForm.MdiEntropyResultForm resultform = new MdiForm.MdiEntropyResultForm(targetform);
                        Protocol.Structure.WaitObject wt = new Protocol.Structure.WaitObject();
                        targetform.DoMethod("计算信息熵", (ThreadPool) =>
                        {
                            resultform.Result = Kernel.BusinessLogicOperation.DataProcessOperation.Entropy(targettable, configform.SelectedColumns, wt);
                        }, wt, () =>
                        {
                            this.Invoke(new Action(() =>
                                {
                                    resultform.ShowResult();
                                    resultform.Show();
                                }));
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }



        private void btnSchmidtSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveDataForm != null && !this.ActiveDataForm.IsBusy)
            {
                var targetform = this.ActiveDataForm;
                var targettable = targetform.GetDataTable();
                ConfigForm.AttributeSelectionForm configform = new ConfigForm.AttributeSelectionForm(targettable.Name, targettable.GetColumnsList(false, typeof(string), typeof(DateTime), typeof(bool)));
                if (configform.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MdiForm.MdiSchmidtResultForm resultform = new MdiForm.MdiSchmidtResultForm(targetform);
                        Protocol.Structure.WaitObject wt = new Protocol.Structure.WaitObject();
                        targetform.DoMethod("施密特正交约减", (ThreadPool) =>
                        {
                            resultform.Result = Kernel.BusinessLogicOperation.DataProcessOperation.Schmidt(targettable, configform.SelectedColumns);
                        }, wt, () =>
                        {
                            this.Invoke(new Action(() =>
                            {
                                resultform.ShowResult();
                                resultform.Show();
                            }));
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
                    MdiForm.MdiDataViewForm targetform = new MdiForm.MdiDataViewForm();
                    targetform.MdiParent = this;
                    targetform.MdiIndex = this.DataFormIndex++;
                    targetform.DataSource = table;
                    targetform.Caption = table.TableName;
                    targetform.Show();
                }
            }
        }

        private void btnKMeans_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveDataForm != null && !this.ActiveDataForm.IsBusy)
            {
                var targetform = this.ActiveDataForm;
                var targettable = targetform.GetDataTable();
                ConfigForm.KMeansForm configform = new ConfigForm.KMeansForm(targettable.GetColumnsList(false, typeof(string), typeof(DateTime), typeof(bool)), targettable.RowCount);
                if (configform.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MdiForm.MdiKMeansResultForm resultform = new MdiForm.MdiKMeansResultForm(targetform);
                        Protocol.Structure.WaitObject wt = new Protocol.Structure.WaitObject();
                        targetform.DoMethod("K均值聚类", (ThreadPool) =>
                        {
                            resultform.Result = Kernel.BusinessLogicOperation.DataMiningOperation.KMeans(ThreadPool,targettable, configform.SelectedColumns, configform.MaxCount, configform.StartClustNum, configform.EndClustNum, configform.Avg, configform.Stdev, wt, configform.InitialMode, configform.MethodMode, configform.MaxThread);
                        }, wt, () =>
                        {
                            this.Invoke(new Action(() =>
                            {
                                resultform.ShowResult();
                                resultform.Show();
                            }));
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }                
                }
            }
        }
        private void btnExDataAccess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var configform = new MPPO.UI.ConfigForm.ExDataAccessConfigForm();
            if (configform.ShowDialog() == DialogResult.OK)
            {
                DataTable data;
                try
                {
                    data = configform.ResultTable;
                    MdiForm.MdiDataViewForm targetform = new MdiForm.MdiDataViewForm();
                    targetform.MdiParent = this;
                    targetform.MdiIndex = this.DataFormIndex++;
                    targetform.DataSource = data;
                    targetform.Caption = data.TableName;
                    targetform.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnTableSaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveDataForm!=null&&!this.ActiveDataForm.IsBusy)
            {
                var targetform = this.ActiveDataForm;
                SaveFileDialog configform = new SaveFileDialog();
                configform.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                configform.Filter = "Excel 工作簿(*.xlsx)|*.xlsx|Excel 97-2003 工作簿(*.xls)|*.xls";
                configform.FilterIndex = 1;
                configform.RestoreDirectory = true;
                if (configform.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var targettable = targetform.GetDataTable();
                        Protocol.Structure.WaitObject wt = new Protocol.Structure.WaitObject();
                        targetform.DoMethod("导出Excel", (ThreadPool) =>
                        {
                            Kernel.BusinessLogicOperation.DataAccessOperation.ExportTableToExcel(targettable, configform.FileName, wt);
                        }, wt, () =>
                        {
                            this.Invoke(new Action(() =>
                                {
                                    MessageBox.Show("导出成功");
                                }));
                        });
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }




    }
}