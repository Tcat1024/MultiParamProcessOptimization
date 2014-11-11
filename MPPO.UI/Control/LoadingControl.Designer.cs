namespace MPPO.UI.Control
{
    partial class LoadingControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.AutoWidth = true;
            this.progressPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.progressPanel1.Caption = "Please Wait, Loading ...";
            this.progressPanel1.Description = "";
            this.progressPanel1.Location = new System.Drawing.Point(10, 4);
            this.progressPanel1.Margin = new System.Windows.Forms.Padding(10, 4, 10, 2);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(270, 46);
            this.progressPanel1.TabIndex = 6;
            this.progressPanel1.Text = "progressPanel2";
            this.progressPanel1.SizeChanged += new System.EventHandler(this.progressPanel1_SizeChanged);
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarControl1.Location = new System.Drawing.Point(6, 51);
            this.progressBarControl1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new System.Drawing.Size(278, 37);
            this.progressBarControl1.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(101, 93);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 31);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LoadingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressPanel1);
            this.Controls.Add(this.progressBarControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LoadingControl";
            this.Size = new System.Drawing.Size(291, 130);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
