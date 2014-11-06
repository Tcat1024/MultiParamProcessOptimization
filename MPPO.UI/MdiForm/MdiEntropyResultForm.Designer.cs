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
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.PointOptions pointOptions2 = new DevExpress.XtraCharts.PointOptions();
            this.advChartControl1 = new SPC.Base.Control.AdvChartControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.LoadingControl = new DevExpress.XtraEditors.PanelControl();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.advChartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingControl)).BeginInit();
            this.LoadingControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // advChartControl1
            // 
            this.advChartControl1.BorderOptions.Visible = false;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.Visible = false;
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram2.EnableAxisXScrolling = true;
            xyDiagram2.EnableAxisXZooming = true;
            xyDiagram2.Margins.Bottom = 0;
            xyDiagram2.Margins.Left = 0;
            xyDiagram2.Margins.Right = 7;
            xyDiagram2.Margins.Top = 0;
            xyDiagram2.Rotated = true;
            this.advChartControl1.Diagram = xyDiagram2;
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
            series2.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            sideBySideBarSeriesLabel2.LineVisible = false;
            pointOptions2.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            sideBySideBarSeriesLabel2.PointOptions = pointOptions2;
            series2.Label = sideBySideBarSeriesLabel2;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Series 1";
            this.advChartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.advChartControl1.Size = new System.Drawing.Size(707, 461);
            this.advChartControl1.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.checkedListBoxControl1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(707, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(167, 461);
            this.panelControl1.TabIndex = 4;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(45, 433);
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
            this.checkedListBoxControl1.Location = new System.Drawing.Point(2, 26);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(163, 401);
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
            // LoadingControl
            // 
            this.LoadingControl.Controls.Add(this.progressPanel1);
            this.LoadingControl.Controls.Add(this.progressBarControl1);
            this.LoadingControl.Location = new System.Drawing.Point(265, 180);
            this.LoadingControl.Name = "LoadingControl";
            this.LoadingControl.Size = new System.Drawing.Size(345, 101);
            this.LoadingControl.TabIndex = 13;
            this.LoadingControl.Visible = false;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.progressPanel1.Caption = "Please Wait, Loading ...";
            this.progressPanel1.Description = "";
            this.progressPanel1.Location = new System.Drawing.Point(34, 14);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(277, 37);
            this.progressPanel1.TabIndex = 3;
            this.progressPanel1.Text = "progressPanel2";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(15, 57);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new System.Drawing.Size(315, 30);
            this.progressBarControl1.TabIndex = 5;
            // 
            // MdiEntropyResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 461);
            this.Controls.Add(this.LoadingControl);
            this.Controls.Add(this.advChartControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "MdiEntropyResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MdiEntropyResultForm";
            this.Load += new System.EventHandler(this.MdiEntropyResultForm_Load);
            this.Resize += new System.EventHandler(this.MdiEntropyResultForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advChartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingControl)).EndInit();
            this.LoadingControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SPC.Base.Control.AdvChartControl advChartControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.PanelControl LoadingControl;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;

    }
}