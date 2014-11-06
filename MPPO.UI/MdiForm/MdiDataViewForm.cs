using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MPPO.UI.MdiForm
{
    public partial class MdiDataViewForm : DevExpress.XtraEditors.XtraForm, MPPO.Protocol.Interface.IMdiDataForm<DataRow>
    {
        public MdiDataViewForm()
        {
            InitializeComponent();
        }
        private object _DataSource;
        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue("")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public object DataSource
        {
            get
            {
                return this._DataSource;
            }
            set
            {
                this._DataSource = value;
                DataInit();
            }
        }
        private string _DataMember;
        [Category("Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string DataMember
        {
            get
            {
                return this._DataMember;
            }
            set
            {
                this._DataMember = value;
                if (this.DataSource != null)
                    DataInit();
            }
        }
        private DataTable mainTable;
        private void DataInit()
        {
            if (this.DataSource == null)
            {
                MessageBox.Show("数据集为空");
                return;
            }
            try
            {
                mainGridView.Columns.Clear();
                this.mainGridControl.DataSource = this.DataSource;
                this.mainGridControl.DataMember = this.DataMember;
                if (this.DataSource is DataSet&&this.DataMember!=null&&this.DataMember.Trim()!="")
                    this.mainTable = (this.DataSource as DataSet).Tables[this.DataMember];
                else if (this.DataSource is DataTable)
                    this.mainTable = this.DataSource as DataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        public Protocol.Interface.IDataTable<DataRow> GetDataTable()
        {
            return new ViewData(mainGridView);
        }

        public void UIInvoke(Delegate method)
        {
            this.Invoke(method);
        }


       
    }
}