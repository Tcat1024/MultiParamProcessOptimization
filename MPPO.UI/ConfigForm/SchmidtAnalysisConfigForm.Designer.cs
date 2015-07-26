namespace MPPO.UI.ConfigForm
{
    partial class SchmidtAnalysisConfigForm
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.triStateTreeView1 = new SPC.Controls.Base.TriStateTreeView();
            this.txeAreaSize = new DevExpress.XtraEditors.TextEdit();
            this.txeAreaSpace = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txeAreaSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txeAreaSpace.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(244, 182);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(97, 24);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(244, 229);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(97, 24);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl1.Location = new System.Drawing.Point(9, 9);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(220, 24);
            this.labelControl1.TabIndex = 50;
            this.labelControl1.Text = "选择列";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Location = new System.Drawing.Point(249, 148);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(92, 17);
            this.labelControl2.TabIndex = 61;
            this.labelControl2.Text = "*未选择任何列";
            this.labelControl2.Visible = false;
            // 
            // triStateTreeView1
            // 
            this.triStateTreeView1.CheckBoxes = true;
            this.triStateTreeView1.Location = new System.Drawing.Point(9, 33);
            this.triStateTreeView1.Name = "triStateTreeView1";
            this.triStateTreeView1.Size = new System.Drawing.Size(220, 220);
            this.triStateTreeView1.TabIndex = 62;
            this.triStateTreeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.triStateTreeView1_AfterCheck);
            // 
            // txeAreaSize
            // 
            this.txeAreaSize.Location = new System.Drawing.Point(244, 42);
            this.txeAreaSize.Name = "txeAreaSize";
            this.txeAreaSize.Properties.Mask.EditMask = "n0";
            this.txeAreaSize.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txeAreaSize.Size = new System.Drawing.Size(100, 22);
            this.txeAreaSize.TabIndex = 63;
            // 
            // txeAreaSpace
            // 
            this.txeAreaSpace.Location = new System.Drawing.Point(244, 95);
            this.txeAreaSpace.Name = "txeAreaSpace";
            this.txeAreaSpace.Properties.Mask.EditMask = "n0";
            this.txeAreaSpace.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txeAreaSpace.Size = new System.Drawing.Size(100, 22);
            this.txeAreaSpace.TabIndex = 64;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(244, 19);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(98, 17);
            this.labelControl3.TabIndex = 65;
            this.labelControl3.Text = "滑动区间大小：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(244, 70);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 17);
            this.labelControl4.TabIndex = 66;
            this.labelControl4.Text = "滑动步长：";
            // 
            // SchmidtAnalysisConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 265);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txeAreaSpace);
            this.Controls.Add(this.txeAreaSize);
            this.Controls.Add(this.triStateTreeView1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SchmidtAnalysisConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "施密特分析";
            ((System.ComponentModel.ISupportInitialize)(this.txeAreaSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txeAreaSpace.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private SPC.Controls.Base.TriStateTreeView triStateTreeView1;
        private DevExpress.XtraEditors.TextEdit txeAreaSize;
        private DevExpress.XtraEditors.TextEdit txeAreaSpace;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}