namespace MPPO.UI.MdiForm
{
    partial class MdiDataViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiDataViewForm));
            this.mainGridControl = new DevExpress.XtraGrid.GridControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.mainGridView = new SPC.Base.Control.CanChooseDataGridView();
            this.loadingControl1 = new MPPO.UI.Control.LoadingControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainGridControl
            // 
            this.mainGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.mainGridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.mainGridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.mainGridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.mainGridControl.EmbeddedNavigator.Buttons.First.ImageIndex = 0;
            this.mainGridControl.EmbeddedNavigator.Buttons.ImageList = this.imageCollection1;
            this.mainGridControl.EmbeddedNavigator.Buttons.Last.ImageIndex = 5;
            this.mainGridControl.EmbeddedNavigator.Buttons.Next.ImageIndex = 3;
            this.mainGridControl.EmbeddedNavigator.Buttons.NextPage.ImageIndex = 4;
            this.mainGridControl.EmbeddedNavigator.Buttons.Prev.ImageIndex = 2;
            this.mainGridControl.EmbeddedNavigator.Buttons.PrevPage.ImageIndex = 1;
            this.mainGridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.mainGridControl.EmbeddedNavigator.TextStringFormat = "{0} / {1}";
            this.mainGridControl.Location = new System.Drawing.Point(0, 0);
            this.mainGridControl.MainView = this.mainGridView;
            this.mainGridControl.Name = "mainGridControl";
            this.mainGridControl.Size = new System.Drawing.Size(874, 458);
            this.mainGridControl.TabIndex = 0;
            this.mainGridControl.UseEmbeddedNavigator = true;
            this.mainGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mainGridView});
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
            // mainGridView
            // 
            this.mainGridView.ChooseColumnName = "choose";
            this.mainGridView.GridControl = this.mainGridControl;
            this.mainGridView.Name = "mainGridView";
            this.mainGridView.OptionsView.ColumnAutoWidth = false;
            this.mainGridView.OptionsView.ShowFooter = true;
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
            // 
            // MdiDataViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 458);
            this.Controls.Add(this.loadingControl1);
            this.Controls.Add(this.mainGridControl);
            this.Name = "MdiDataViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MdiDataViewForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MdiDataViewForm_FormClosing);
            this.Resize += new System.EventHandler(this.MdiDataViewForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mainGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl mainGridControl;
        private SPC.Base.Control.CanChooseDataGridView mainGridView;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private Control.LoadingControl loadingControl1;
    }
}