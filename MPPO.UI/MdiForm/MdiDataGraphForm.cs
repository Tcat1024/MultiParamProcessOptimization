using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MPPO.UI.MdiForm
{
    public partial class MdiDataGraphForm : DevExpress.XtraEditors.XtraForm, MPPO.Protocol.Interface.IMdiResultForm
    {
        List<TreeNodeData> m_DataSource = new List<TreeNodeData>();
        class TreeNodeData
        {
            public string Name{get;set;}
            private string m_XChar = "";
            public string XChar 
            { 
                get
                {
                    return m_XChar;
                }
                set
                {
                    m_XChar = value;
                    TryDraw();
                }
            }
            private string m_YChar = "";
            public string YChar 
            { 
                get
                {
                    return m_YChar;
                }
                set
                {
                    m_YChar = value;
                    TryDraw();
                }
            }
            private string m_X = "";
            public string X 
            { 
                get
                {
                    return m_X;
                }
                set
                {
                    m_X = value;
                    TryDraw();
                }
            }
            private string m_Y = "";
            public string Y 
            {
                get
                {
                    return m_Y;
                }
                set
                {
                    m_Y = value;
                    TryDraw();
                }
            }
            private Color m_Color;
            public Color Color 
            { 
                get
                {
                    return m_Color;
                }
                set 
                { 
                    m_Color = value; TryDraw(); 
                } 
            }
            private bool m_Show = true;
            public bool Show 
            { 
                get
                {
                    return m_Show;
                }
                set
                {
                    m_Show = value;
                    TryDraw();
                }
            }
            private DevExpress.XtraCharts.ChartControl m_ctcDrawBoard = null;
            public MPPO.Protocol.Interface.IDataTable<DataRow> DataSource = null;
            public void SetDrawBoard(DevExpress.XtraCharts.ChartControl control)
            {
                m_ctcDrawBoard = control;
            }
            private void TryDraw()
            {
                if (Name.Trim() == "" || XChar.Trim() == "" || YChar.Trim() == "" || X.Trim() == "" || Y.Trim() == "" || m_ctcDrawBoard == null || DataSource == null)
                    return;
                if(Show)
                {
                    DevExpress.XtraCharts.Series series = m_ctcDrawBoard.GetSeriesByName(Name);
                    if (series == null)
                    {
                        int index = m_ctcDrawBoard.Series.Add(Name, DevExpress.XtraCharts.ViewType.Spline);
                        series = m_ctcDrawBoard.Series[index];
                    }
                    DevExpress.XtraCharts.Axis2D axis = (m_ctcDrawBoard.Diagram as DevExpress.XtraCharts.XYDiagram).FindAxisXByName(X);
                    if (axis == null)
                    {
                        axis = new DevExpress.XtraCharts.SecondaryAxisX();
                        axis.Name = X;
                        (m_ctcDrawBoard.Diagram as DevExpress.XtraCharts.XYDiagram).SecondaryAxesX.Add(axis as DevExpress.XtraCharts.SecondaryAxisX);
                        (series.View as DevExpress.XtraCharts.SplineSeriesView).AxisX = axis as DevExpress.XtraCharts.AxisXBase;
                    }
                    else
                    {
                        (series.View as DevExpress.XtraCharts.SplineSeriesView).AxisX = axis as DevExpress.XtraCharts.AxisXBase;
                    }
                    axis = (m_ctcDrawBoard.Diagram as DevExpress.XtraCharts.XYDiagram).FindAxisYByName(Y);
                    if (axis == null)
                    {
                        axis = new DevExpress.XtraCharts.SecondaryAxisY();
                        axis.Name = Y;
                        axis.WholeRange.AlwaysShowZeroLevel = false;
                        (m_ctcDrawBoard.Diagram as DevExpress.XtraCharts.XYDiagram).SecondaryAxesY.Add(axis as DevExpress.XtraCharts.SecondaryAxisY);
                        (series.View as DevExpress.XtraCharts.SplineSeriesView).AxisY = axis as DevExpress.XtraCharts.AxisYBase;
                    }
                    else
                    {
                        (series.View as DevExpress.XtraCharts.SplineSeriesView).AxisY = axis as DevExpress.XtraCharts.AxisYBase;
                    }
                    series.Points.BeginUpdate();
                    series.Points.Clear();
                    for(int i = 0;i< DataSource.RowCount; ++i)
                    {
                        series.Points.Add(new DevExpress.XtraCharts.SeriesPoint(DataSource[i][XChar],DataSource[i][YChar]));
                    }
                    series.Points.EndUpdate();
                    if (Color == null)
                        Color = (series.View as DevExpress.XtraCharts.SplineSeriesView).Color;
                    else
                        (series.View as DevExpress.XtraCharts.SplineSeriesView).Color = Color;
                }
                else
                {
                    DevExpress.XtraCharts.Series series = m_ctcDrawBoard.GetSeriesByName(Name);
                    if (series != null)
                    {
                        
                    }
                }
            }
        }
        public MdiDataGraphForm()
        {
            InitializeComponent();
            this.grcMain.DataSource = m_DataSource;
        }
        public void AddData(object target)
        {
            var targetform = target as MPPO.Protocol.Interface.IMdiDataForm<DataRow>;
            if (targetform == null)
                return;
            TreeNodeData aNode = new TreeNodeData();
            aNode.Name = targetform.Caption;
            aNode.DataSource = targetform.GetDataTable();
            aNode.SetDrawBoard(ctcMainChart);
            m_DataSource.Add(aNode);
            
        }

        private void RefreshPopControl(int rowindex)
        {
            cmbAxisChar.Items.Clear();
            TreeNodeData data = m_DataSource[rowindex];
            int size = data.DataSource.ColumnCount;
            int i;
            for (i = 0; i < size; ++i)
            {
                cmbAxisChar.Items.Add(data.DataSource.GetColumnsList()[i]);
            }
            cmbAxisX.Items.Clear();
            cmbAxisX.Items.Add((ctcMainChart.Diagram as DevExpress.XtraCharts.XYDiagram).AxisX.ToString());
            var axesx = (ctcMainChart.Diagram as DevExpress.XtraCharts.XYDiagram).SecondaryAxesX;
            size = axesx.Count;
            for(i = 0; i < size ; ++i)
            {
                cmbAxisX.Items.Add(axesx[i].Name);
            }
            cmbAxisY.Items.Clear();
            cmbAxisY.Items.Add((ctcMainChart.Diagram as DevExpress.XtraCharts.XYDiagram).AxisY.ToString());
            var axesy = (ctcMainChart.Diagram as DevExpress.XtraCharts.XYDiagram).SecondaryAxesY;
            size = axesy.Count;
            for (i = 0; i < size; ++i)
            {
                cmbAxisY.Items.Add(axesy[i].Name);
            }
        }


        public Protocol.Interface.IMdiDataForm<DataRow> DataForm
        {
            get;
            set;
        }

        public int MdiIndex
        {
            get;
            set;
        }

        public string Caption
        {
            get;
            set;
        }

        public void ShowResult()
        {
        }

        private void MdiDataGraphForm_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                popRightMenu.ShowPopup(e.Location);
            }
        }

        private void btnAddForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConfigForm.DrawDataChooseForm configform = new ConfigForm.DrawDataChooseForm();
            List<MPPO.Protocol.Interface.IMdiDataForm<DataRow>> forms = new List<MPPO.Protocol.Interface.IMdiDataForm<DataRow>>();
            MPPO.Protocol.Interface.IMdiDataForm<DataRow> form;
            int i;
            Form[] mdiforms = this.MdiParent.MdiChildren;
            for(i = 0;i< mdiforms.Length; ++i)
            {
                if((form = mdiforms[i] as MPPO.Protocol.Interface.IMdiDataForm<DataRow>)!= null)
                    forms.Add(form);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RefreshPopControl(e.FocusedRowHandle);
        }

        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            //RefreshPopControl(gridView1.GetFocusedDataSourceRowIndex());
        }


    }
}