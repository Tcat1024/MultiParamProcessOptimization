namespace MPPO.UI.MdiForm
{
    partial class MdiEntropyResultForm
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
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.PointOptions pointOptions1 = new DevExpress.XtraCharts.PointOptions();
            this.advChartControl1 = new SPC.Base.Control.AdvChartControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.advChartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // advChartControl1
            // 
            this.advChartControl1.BorderOptions.Visible = false;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Visible = false;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisXZooming = true;
            xyDiagram1.Margins.Bottom = 0;
            xyDiagram1.Margins.Left = 0;
            xyDiagram1.Margins.Right = 7;
            xyDiagram1.Margins.Top = 0;
            xyDiagram1.Rotated = true;
            this.advChartControl1.Diagram = xyDiagram1;
            this.advChartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advChartControl1.Legend.Visible = false;
            this.advChartControl1.Location = new System.Drawing.Point(0, 0);
            this.advChartControl1.Margin = new System.Windows.Forms.Padding(0);
            this.advChartControl1.Name = "advChartControl1";
            this.advChartControl1.Padding.Bottom = 0;
            this.advChartControl1.Padding.Left = 0;
            this.advChartControl1.Padding.Right = 0;
            this.advChartControl1.Padding.Top = 0;
            this.advChartControl1.RuntimeHitTesting = true;
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            sideBySideBarSeriesLabel1.LineVisible = false;
            pointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            sideBySideBarSeriesLabel1.PointOptions = pointOptions1;
            series1.Label = sideBySideBarSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Series 1";
            this.advChartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.advChartControl1.Size = new System.Drawing.Size(707, 458);
            this.advChartControl1.TabIndex = 3;
            this.advChartControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.advChartControl1_MouseClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.checkedListBoxControl1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(707, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(167, 458);
            this.panelControl1.TabIndex = 4;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(45, 430);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 52;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.ToolTip = "将上表中选中的列删除";
            this.simpleButton1.ToolTipController = this.toolTipController1;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(2, 26);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.checkedListBoxControl1.Size = new System.Drawing.Size(163, 398);
            this.checkedListBoxControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(2, 2);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(163, 24);
            this.labelControl1.TabIndex = 51;
            this.labelControl1.Text = "从数据表中删除列";
            // 
            // MdiEntropyResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 458);
            this.Controls.Add(this.advChartControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "MdiEntropyResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MdiEntropyResultForm";
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advChartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SPC.Base.Control.AdvChartControl advChartControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.Utils.ToolTipController toolTipController1;

    }
}