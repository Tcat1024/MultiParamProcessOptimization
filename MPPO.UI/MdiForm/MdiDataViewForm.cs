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
    public partial class MdiDataViewForm : DevExpress.XtraEditors.XtraForm, MPPO.Protocol.Interface.IMdiDataForm
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

        public string[] GetColumnsList()
        {
            var columnlist = this.mainTable.Columns;
            int columncount = columnlist.Count;
            string[] columns = new string[columncount];
            for(int i = 0;i<columncount;i++)
            {
                columns[i] = columnlist[i].ColumnName;
            }
            return columns;
        }
        public Protocol.Interface.IDataTable GetDataTable()
        {
            return new ViewData(mainGridView);
        }
        public string[] GetColumnsList(bool equal = true, params Type[] ttype)
        {
            var columnlist = this.mainTable.Columns;
            int columncount = columnlist.Count; 
            List<string> columns = new List<string>();
            int typecount = ttype.Length;         
            if (equal)
            {
                for (int i = 0; i < columncount; i++)
                {
                    for (int j = 0; j < typecount; j++)
                    {
                        if (columnlist[i].DataType == ttype[j])
                        {
                            columns.Add(columnlist[i].ColumnName);
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < columncount; i++)
                {
                    bool hav = false;
                    for (int j = 0; j < typecount; j++)
                    {
                        if (columnlist[i].DataType == ttype[j])
                        {
                            hav = true;
                            break;
                        }
                    }
                    if (!hav)
                        columns.Add(columnlist[i].ColumnName);
                }
            }
            return columns.ToArray();
        }

        public Type GetColumnType(int index)
        {
            return this.mainTable.Columns[index].DataType;
        }

        public Type GetColumnType(string name)
        {
            return this.mainTable.Columns[name].DataType;
        }

        public bool ContainsColumn(string name)
        {
            return this.mainTable.Columns.Contains(name); ;
        }


        public void AddColumn(string name)
        {
            this.mainTable.Columns.Add(name);
            mainGridView.Columns.AddVisible(name);
        }
        public void AddColumn(string name, Type datatype)
        {
            this.mainTable.Columns.Add(name, datatype);
            mainGridView.Columns.AddVisible(name);
        }



        public void UIInvoke(Delegate method)
        {
            this.Invoke(method);
        }


        public object GetDataCopy()
        {
            DataTable result = (this.mainGridView.DataSource as DataView).Table.Clone();
            result.TableName = (this.mainGridView.DataSource as DataView).Table.TableName + " - 副本";
            var rowcount = this.mainGridView.RowCount;
            for (int j = 0; j < rowcount; j++)
                result.Rows.Add(this.mainGridView.GetDataRow(j).ItemArray);
            var columns = this.mainGridView.VisibleColumns;
            var columncount = columns.Count;
            var totalcolumncount = columns.Count;
            int i;
            for (i = 0; i < columncount; i++)
                result.Columns[columns[i].FieldName].SetOrdinal(i);
            for (; i < totalcolumncount; i++)
                result.Columns.RemoveAt(i);
            return result;
        }


        public string GetTableName()
        {
            return (this.mainGridView.DataSource as DataView).Table.TableName;
        }


        public bool SetColumnVisible(string name)
        {
            DevExpress.XtraGrid.Columns.GridColumn target;
            if ((this.mainGridView.DataSource as DataView).Table.Columns.Contains(name) && (target = this.mainGridView.Columns.ColumnByFieldName(name)) != null && target.Visible == false)
            {
                target.Visible = true;
                return true;
            }
            return false;
        }

        public bool SetColumnUnvisible(string name)
        {
            DevExpress.XtraGrid.Columns.GridColumn target;
            if ((this.mainGridView.DataSource as DataView).Table.Columns.Contains(name) && (target = this.mainGridView.Columns.ColumnByFieldName(name)) != null && target.Visible == true)
            {
                target.Visible = false;
                return true;
            }
            return false;
        }
    }
}