using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MPPO.Kernel;

namespace MPPO.UI
{
    public class ViewData:MPPO.Protocol.Interface.IDataTable<DataRow>
    {
        SPC.Base.Control.CanChooseDataGridView View;
        DataTable sourceTable;
        public ViewData(SPC.Base.Control.CanChooseDataGridView view)
        {
            this.View = view;
            this.sourceTable = (view.DataSource as DataView).Table;
            view.GridControl.Invoke(new Action(() => { this.View.ActiveFilter.Add(view.Columns[view.ChooseColumnName], new DevExpress.XtraGrid.Columns.ColumnFilterInfo(view.ChooseColumnName + " = true")); }));
        }
        public DataRow this[int index]
        {
            get
            {
                return this.View.GetDataRow(index);
            }
        }
        public object this[int rowindex, int columnindex]
        {
            get
            {
                return this.View.GetRowCellValue(rowindex, this.View.VisibleColumns[columnindex]);
            }
            set
            {
                this.View.SetRowCellValue(rowindex, this.View.VisibleColumns[columnindex], value);
            }
        }

        public object this[int rowindex, string columnname]
        {
            get
            {
                return this.View.GetRowCellValue(rowindex, columnname);
            }
            set
            {
                this.View.SetRowCellValue(rowindex, columnname, value);
            }
        }
        public int RowCount
        {
            get
            {
                return this.View.DataRowCount;
            }
        }
        public int ColumnCount
        {
            get
            {
                return this.View.VisibleColumns.Count;
            }
        }
        public string Name
        {
            get
            {
                return this.sourceTable.TableName;
            }
            set
            {
                this.sourceTable.TableName = value;
            }
        }
        public object[] GetGroup(int index)
        {
            throw new NotImplementedException();
        }
        public int GetSourceIndex(int i)
        {
            return this.View.GetDataSourceRowIndex(i);
        }
        public DataRow GetSourceRowbySourceIndex(int i)
        {
            return sourceTable.Rows[i];
        }
        public string[] GetColumnsList()
        {
            var columnlist = this.View.VisibleColumns;
            int columncount = columnlist.Count;
            string[] columns = new string[columncount];
            for (int i = 0; i < columncount; i++)
            {
                columns[i] = columnlist[i].FieldName;
            }
            return columns;
        }
        public string[] GetColumnsList(bool equal = true, params Type[] ttype)
        {
            var columnlist = this.View.VisibleColumns;
            int columncount = columnlist.Count;
            List<string> columns = new List<string>();
            int typecount = ttype.Length;
            if (equal)
            {
                for (int i = 0; i < columncount; i++)
                {
                    for (int j = 0; j < typecount; j++)
                    {
                        if (columnlist[i].ColumnType == ttype[j])
                        {
                            columns.Add(columnlist[i].FieldName);
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
                        if (columnlist[i].ColumnType == ttype[j])
                        {
                            hav = true;
                            break;
                        }
                    }
                    if (!hav)
                        columns.Add(columnlist[i].FieldName);
                }
            }
            return columns.ToArray();
        }

        public Type GetColumnType(int index)
        {
            return this.sourceTable.Columns[index].DataType;
        }

        public Type GetColumnType(string name)
        {
            return this.sourceTable.Columns[name].DataType;
        }

        public bool ContainsColumn(string name)
        {
            return this.sourceTable.Columns.Contains(name); ;
        }

        public void AddColumn(string name)
        {
            this.sourceTable.Columns.Add(name);
            this.View.Columns.AddVisible(name);
        }
        public void AddColumn(string name, Type datatype)
        {
            this.sourceTable.Columns.Add(name, datatype);
            this.View.Columns.AddVisible(name);
        }

        public object Copy()
        {
            DataTable result = this.sourceTable.Clone();
            result.TableName = this.sourceTable.TableName + " - 副本";
            var rowcount = this.View.RowCount;
            for (int j = 0; j < rowcount; j++)
                result.Rows.Add(this.View.GetDataRow(j).ItemArray);
            var columns = this.View.VisibleColumns;
            var columncount = columns.Count;
            var totalcolumncount = columns.Count;
            int i;
            for (i = 0; i < columncount; i++)
                result.Columns[columns[i].FieldName].SetOrdinal(i);
            for (; i < totalcolumncount; i++)
                result.Columns.RemoveAt(i);
            return result;
            //object[] t = new object[3];
            //t[0] = this.sourceTable.TableName + " - 副本";
            //t[1] = false;
            //string[] temp = new string[columncount];
            //for (i = 0; i < columncount; i++)
            //    temp[i] = View.VisibleColumns[i].FieldName;
            //t[2] = temp;
            //return typeof(DataView).GetMethod("ToTable", new Type[] { typeof(string), typeof(bool), typeof(string[]) }).Invoke(this.dataView, t);
        }
        public bool SetColumnVisible(string name)
        {
            DevExpress.XtraGrid.Columns.GridColumn target;
            if (this.sourceTable.Columns.Contains(name) && (target = this.View.Columns.ColumnByFieldName(name)) != null && target.Visible == false)
            {
                target.Visible = true;
                return true;
            }
            return false;
        }

        public bool SetColumnUnvisible(string name)
        {
            DevExpress.XtraGrid.Columns.GridColumn target;
            if (this.sourceTable.Columns.Contains(name) && (target = this.View.Columns.ColumnByFieldName(name)) != null && target.Visible == true)
            {
                target.Visible = false;
                return true;
            }
            return false;
        }
        public DataRow NewRow()
        {
            return this.sourceTable.NewRow();
        }


        private int index = -1;


        public DataRow Current
        {
            get { return this.View.GetDataRow(index); }
        }

        public void Dispose()
        {
            index = -1 ;
        }

        object System.Collections.IEnumerator.Current
        {
            get { return this.View.GetDataRow(index); }
        }

        public bool MoveNext()
        {
            if (index == this.RowCount - 1)
                return false;
            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

    }

}
