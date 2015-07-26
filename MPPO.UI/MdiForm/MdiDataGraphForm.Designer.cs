namespace MPPO.UI.MdiForm
{
    partial class MdiDataGraphForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView3 = new DevExpress.XtraCharts.SplineSeriesView();
            this.ctcMainChart = new DevExpress.XtraCharts.ChartControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.popRightMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnAddForm = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grcMain = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cXChar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbAxisChar = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cYChar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbAxisX = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbAxisY = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.cColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cleColor = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.cShow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckeShow = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ctcMainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popRightMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAxisChar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAxisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAxisY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cleColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckeShow)).BeginInit();
            this.SuspendLayout();
            // 
            // ctcMainChart
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.WholeRange.AlwaysShowZeroLevel = false;
            this.ctcMainChart.Diagram = xyDiagram1;
            this.ctcMainChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctcMainChart.Legend.Visible = false;
            this.ctcMainChart.Location = new System.Drawing.Point(0, 0);
            this.ctcMainChart.Name = "ctcMainChart";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series1.Name = "Series 1";
            series1.View = splineSeriesView1;
            series2.Name = "Series 2";
            series2.View = splineSeriesView2;
            this.ctcMainChart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.ctcMainChart.SeriesTemplate.View = splineSeriesView3;
            this.ctcMainChart.Size = new System.Drawing.Size(773, 293);
            this.ctcMainChart.TabIndex = 0;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl1.Location = new System.Drawing.Point(0, 293);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(773, 12);
            this.splitterControl1.TabIndex = 2;
            this.splitterControl1.TabStop = false;
            // 
            // popRightMenu
            // 
            this.popRightMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddForm)});
            this.popRightMenu.Manager = this.barManager1;
            this.popRightMenu.Name = "popRightMenu";
            // 
            // btnAddForm
            // 
            this.btnAddForm.Caption = "添加";
            this.btnAddForm.Id = 0;
            this.btnAddForm.Name = "btnAddForm";
            this.btnAddForm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddForm_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddForm});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(773, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 505);
            this.barDockControlBottom.Size = new System.Drawing.Size(773, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 505);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(773, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 505);
            // 
            // grcMain
            // 
            this.grcMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grcMain.Location = new System.Drawing.Point(0, 305);
            this.grcMain.MainView = this.gridView1;
            this.grcMain.MenuManager = this.barManager1;
            this.grcMain.Name = "grcMain";
            this.grcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbAxisChar,
            this.cmbAxisX,
            this.cmbAxisY,
            this.cleColor,
            this.ckeShow});
            this.grcMain.Size = new System.Drawing.Size(773, 200);
            this.grcMain.TabIndex = 8;
            this.grcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cName,
            this.cXChar,
            this.cYChar,
            this.cX,
            this.cY,
            this.cColor,
            this.cShow});
            this.gridView1.GridControl = this.grcMain;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsPrint.PrintGroupFooter = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.GotFocus += new System.EventHandler(this.gridView1_GotFocus);
            // 
            // cName
            // 
            this.cName.Caption = "表名";
            this.cName.FieldName = "Name";
            this.cName.Name = "cName";
            this.cName.OptionsColumn.AllowEdit = false;
            this.cName.OptionsColumn.ReadOnly = true;
            this.cName.Visible = true;
            this.cName.VisibleIndex = 0;
            // 
            // cXChar
            // 
            this.cXChar.Caption = "X轴字段";
            this.cXChar.ColumnEdit = this.cmbAxisChar;
            this.cXChar.FieldName = "XChar";
            this.cXChar.Name = "cXChar";
            this.cXChar.Visible = true;
            this.cXChar.VisibleIndex = 1;
            // 
            // cmbAxisChar
            // 
            this.cmbAxisChar.AutoHeight = false;
            this.cmbAxisChar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAxisChar.Name = "cmbAxisChar";
            this.cmbAxisChar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // cYChar
            // 
            this.cYChar.Caption = "Y轴字段";
            this.cYChar.ColumnEdit = this.cmbAxisChar;
            this.cYChar.FieldName = "YChar";
            this.cYChar.Name = "cYChar";
            this.cYChar.Visible = true;
            this.cYChar.VisibleIndex = 2;
            // 
            // cX
            // 
            this.cX.Caption = "X轴";
            this.cX.ColumnEdit = this.cmbAxisX;
            this.cX.FieldName = "X";
            this.cX.Name = "cX";
            this.cX.Visible = true;
            this.cX.VisibleIndex = 3;
            // 
            // cmbAxisX
            // 
            this.cmbAxisX.AutoHeight = false;
            this.cmbAxisX.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAxisX.Name = "cmbAxisX";
            // 
            // cY
            // 
            this.cY.Caption = "Y轴";
            this.cY.ColumnEdit = this.cmbAxisY;
            this.cY.FieldName = "Y";
            this.cY.Name = "cY";
            this.cY.Visible = true;
            this.cY.VisibleIndex = 4;
            // 
            // cmbAxisY
            // 
            this.cmbAxisY.AutoHeight = false;
            this.cmbAxisY.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAxisY.Name = "cmbAxisY";
            // 
            // cColor
            // 
            this.cColor.Caption = "颜色";
            this.cColor.ColumnEdit = this.cleColor;
            this.cColor.FieldName = "Color";
            this.cColor.Name = "cColor";
            this.cColor.Visible = true;
            this.cColor.VisibleIndex = 5;
            // 
            // cleColor
            // 
            this.cleColor.AutoHeight = false;
            this.cleColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cleColor.Name = "cleColor";
            // 
            // cShow
            // 
            this.cShow.Caption = "显示";
            this.cShow.ColumnEdit = this.ckeShow;
            this.cShow.FieldName = "Show";
            this.cShow.Name = "cShow";
            this.cShow.Visible = true;
            this.cShow.VisibleIndex = 6;
            // 
            // ckeShow
            // 
            this.ckeShow.AutoHeight = false;
            this.ckeShow.Caption = "Check";
            this.ckeShow.Name = "ckeShow";
            // 
            // MdiDataGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 505);
            this.Controls.Add(this.ctcMainChart);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.grcMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MdiDataGraphForm";
            this.Text = "MdiDataGraphForm";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MdiDataGraphForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctcMainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popRightMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAxisChar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAxisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAxisY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cleColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckeShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl ctcMainChart;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraBars.PopupMenu popRightMenu;
        private DevExpress.XtraBars.BarButtonItem btnAddForm;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl grcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn cName;
        private DevExpress.XtraGrid.Columns.GridColumn cXChar;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbAxisChar;
        private DevExpress.XtraGrid.Columns.GridColumn cYChar;
        private DevExpress.XtraGrid.Columns.GridColumn cX;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbAxisX;
        private DevExpress.XtraGrid.Columns.GridColumn cY;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbAxisY;
        private DevExpress.XtraGrid.Columns.GridColumn cColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit cleColor;
        private DevExpress.XtraGrid.Columns.GridColumn cShow;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckeShow;
    }
}