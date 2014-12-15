namespace MPPO.UI.MdiForm
{
    partial class MdiDataSheetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiDataSheetForm));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.loadingControl1 = new MPPO.UI.Control.LoadingControl();
            this.spreadsheetControl = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("doublefirst_16x16.png", "images/arrows/doublefirst_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/doublefirst_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "doublefirst_16x16.png");
            this.imageCollection1.InsertGalleryImage("doubleprev_16x16.png", "images/arrows/doubleprev_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/doubleprev_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "doubleprev_16x16.png");
            this.imageCollection1.InsertGalleryImage("prev_16x16.png", "images/arrows/prev_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/prev_16x16.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "prev_16x16.png");
            this.imageCollection1.InsertGalleryImage("next_16x16.png", "images/arrows/next_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/next_16x16.png"), 3);
            this.imageCollection1.Images.SetKeyName(3, "next_16x16.png");
            this.imageCollection1.InsertGalleryImage("doublenext_16x16.png", "images/arrows/doublenext_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/doublenext_16x16.png"), 4);
            this.imageCollection1.Images.SetKeyName(4, "doublenext_16x16.png");
            this.imageCollection1.InsertGalleryImage("doublelast_16x16.png", "images/arrows/doublelast_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/doublelast_16x16.png"), 5);
            this.imageCollection1.Images.SetKeyName(5, "doublelast_16x16.png");
            // 
            // loadingControl1
            // 
            this.loadingControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadingControl1.Location = new System.Drawing.Point(292, 164);
            this.loadingControl1.Margin = new System.Windows.Forms.Padding(0);
            this.loadingControl1.Name = "loadingControl1";
            this.loadingControl1.Position = 0;
            this.loadingControl1.ProgressBarVisible = true;
            this.loadingControl1.Size = new System.Drawing.Size(291, 130);
            this.loadingControl1.TabIndex = 1;
            this.loadingControl1.Visible = false;
            this.loadingControl1.WaitText = "Please Wait, Loading ...";
            this.loadingControl1.Cancel += new System.EventHandler(this.loadingControl1_Cancel);
            // 
            // spreadsheetControl
            // 
            this.spreadsheetControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetControl.Location = new System.Drawing.Point(0, 0);
            this.spreadsheetControl.Name = "spreadsheetControl";
            this.spreadsheetControl.Options.Export.Csv.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl1.Options.Export.Csv.Encoding")));
            this.spreadsheetControl.Options.Export.Txt.Encoding = ((System.Text.Encoding)(resources.GetObject("spreadsheetControl1.Options.Export.Txt.Encoding")));
            this.spreadsheetControl.Options.TabSelector.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetElementVisibility.Hidden;
            this.spreadsheetControl.Size = new System.Drawing.Size(874, 458);
            this.spreadsheetControl.TabIndex = 2;
            this.spreadsheetControl.Text = "spreadsheetControl";
            // 
            // MdiDataSheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 458);
            this.Controls.Add(this.loadingControl1);
            this.Controls.Add(this.spreadsheetControl);
            this.Name = "MdiDataSheetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MdiDataViewForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MdiDataViewForm_FormClosing);
            this.Resize += new System.EventHandler(this.MdiDataViewForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollection1;
        private Control.LoadingControl loadingControl1;
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl;
    }
}