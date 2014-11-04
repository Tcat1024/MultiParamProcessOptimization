namespace MPPO.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.btnNewQuery = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewTable = new DevExpress.XtraBars.BarButtonItem();
            this.btnCopyTable = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.menuFile = new DevExpress.XtraBars.BarSubItem();
            this.btnQueryDataBase = new DevExpress.XtraBars.BarButtonItem();
            this.menuEdit = new DevExpress.XtraBars.BarSubItem();
            this.menuData = new DevExpress.XtraBars.BarSubItem();
            this.btnStandardData = new DevExpress.XtraBars.BarButtonItem();
            this.menuStatistics = new DevExpress.XtraBars.BarSubItem();
            this.menuGraph = new DevExpress.XtraBars.BarSubItem();
            this.menuDataMining = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.btnEntropy = new DevExpress.XtraBars.BarButtonItem();
            this.btnOrthogSelect = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem7 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem8 = new DevExpress.XtraBars.BarSubItem();
            this.menuWindow = new DevExpress.XtraBars.BarSubItem();
            this.btnWindowCascade = new DevExpress.XtraBars.BarButtonItem();
            this.btnWindowTile = new DevExpress.XtraBars.BarButtonItem();
            this.btnWindowMin = new DevExpress.XtraBars.BarButtonItem();
            this.btnWindowRecover = new DevExpress.XtraBars.BarButtonItem();
            this.menuHelp = new DevExpress.XtraBars.BarSubItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.stlCurrentForm = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuData,
            this.menuStatistics,
            this.menuGraph,
            this.menuDataMining,
            this.menuWindow,
            this.menuHelp,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem9,
            this.barSubItem1,
            this.barSubItem2,
            this.barSubItem3,
            this.btnStandardData,
            this.barSubItem4,
            this.barSubItem5,
            this.barSubItem6,
            this.barSubItem7,
            this.barSubItem8,
            this.btnEntropy,
            this.btnOrthogSelect,
            this.barButtonItem11,
            this.btnWindowCascade,
            this.btnWindowTile,
            this.btnWindowMin,
            this.btnWindowRecover,
            this.btnQueryDataBase,
            this.barStaticItem1,
            this.stlCurrentForm,
            this.btnNewQuery,
            this.btnNewTable,
            this.btnCopyTable});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 46;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem3, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem9),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.Text = "Tools";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "barSubItem3";
            this.barSubItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubItem3.Glyph")));
            this.barSubItem3.Id = 20;
            this.barSubItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barSubItem3.LargeGlyph")));
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNewTable),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCopyTable)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // btnNewQuery
            // 
            this.btnNewQuery.Caption = "新建数据库查询";
            this.btnNewQuery.Id = 43;
            this.btnNewQuery.Name = "btnNewQuery";
            // 
            // btnNewTable
            // 
            this.btnNewTable.Caption = "新建空数据表";
            this.btnNewTable.Id = 44;
            this.btnNewTable.Name = "btnNewTable";
            // 
            // btnCopyTable
            // 
            this.btnCopyTable.Caption = "从当前数据表复制";
            this.btnCopyTable.Id = 45;
            this.btnCopyTable.Name = "btnCopyTable";
            this.btnCopyTable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCopyTable_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 10;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "barButtonItem9";
            this.barButtonItem9.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem9.Glyph")));
            this.barButtonItem9.Id = 17;
            this.barButtonItem9.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem9.LargeGlyph")));
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubItem1.Glyph")));
            this.barSubItem1.Id = 18;
            this.barSubItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barSubItem1.LargeGlyph")));
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "barSubItem2";
            this.barSubItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barSubItem2.Glyph")));
            this.barSubItem2.Id = 19;
            this.barSubItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barSubItem2.LargeGlyph")));
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.Glyph")));
            this.barButtonItem3.Id = 11;
            this.barButtonItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.LargeGlyph")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.Glyph")));
            this.barButtonItem4.Id = 12;
            this.barButtonItem4.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.LargeGlyph")));
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.Glyph")));
            this.barButtonItem5.Id = 13;
            this.barButtonItem5.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.LargeGlyph")));
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.Glyph")));
            this.barButtonItem6.Id = 14;
            this.barButtonItem6.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem6.LargeGlyph")));
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.menuFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuData),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuStatistics),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuGraph),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuDataMining),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuWindow),
            new DevExpress.XtraBars.LinkPersistInfo(this.menuHelp)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // menuFile
            // 
            this.menuFile.Caption = "文件(&F)";
            this.menuFile.Id = 1;
            this.menuFile.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
                | System.Windows.Forms.Keys.F));
            this.menuFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnQueryDataBase)});
            this.menuFile.Name = "menuFile";
            // 
            // btnQueryDataBase
            // 
            this.btnQueryDataBase.Caption = "查询数据库";
            this.btnQueryDataBase.Id = 38;
            this.btnQueryDataBase.Name = "btnQueryDataBase";
            this.btnQueryDataBase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQueryDataBase_ItemClick);
            // 
            // menuEdit
            // 
            this.menuEdit.Caption = "编辑(&E)";
            this.menuEdit.Id = 2;
            this.menuEdit.Name = "menuEdit";
            // 
            // menuData
            // 
            this.menuData.Caption = "数据(&A)";
            this.menuData.Id = 3;
            this.menuData.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnStandardData)});
            this.menuData.Name = "menuData";
            // 
            // btnStandardData
            // 
            this.btnStandardData.Caption = "标准化";
            this.btnStandardData.Id = 21;
            this.btnStandardData.Name = "btnStandardData";
            this.btnStandardData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStandardData_ItemClick);
            // 
            // menuStatistics
            // 
            this.menuStatistics.Caption = "统计(&S)";
            this.menuStatistics.Id = 4;
            this.menuStatistics.Name = "menuStatistics";
            // 
            // menuGraph
            // 
            this.menuGraph.Caption = "图形(&G)";
            this.menuGraph.Id = 5;
            this.menuGraph.Name = "menuGraph";
            // 
            // menuDataMining
            // 
            this.menuDataMining.Caption = "数据挖掘(&M)";
            this.menuDataMining.Id = 6;
            this.menuDataMining.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem6),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem7),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem8)});
            this.menuDataMining.Name = "menuDataMining";
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "属性选择";
            this.barSubItem4.Id = 24;
            this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEntropy),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOrthogSelect)});
            this.barSubItem4.Name = "barSubItem4";
            // 
            // btnEntropy
            // 
            this.btnEntropy.Caption = "信息熵选择";
            this.btnEntropy.Id = 29;
            this.btnEntropy.Name = "btnEntropy";
            this.btnEntropy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEntropy_ItemClick);
            // 
            // btnOrthogSelect
            // 
            this.btnOrthogSelect.Caption = "无监督正交选择";
            this.btnOrthogSelect.Id = 30;
            this.btnOrthogSelect.Name = "btnOrthogSelect";
            // 
            // barSubItem5
            // 
            this.barSubItem5.Caption = "聚类";
            this.barSubItem5.Id = 25;
            this.barSubItem5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem11)});
            this.barSubItem5.Name = "barSubItem5";
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "K-Means聚类";
            this.barButtonItem11.Id = 31;
            this.barButtonItem11.Name = "barButtonItem11";
            // 
            // barSubItem6
            // 
            this.barSubItem6.Caption = "分类";
            this.barSubItem6.Id = 26;
            this.barSubItem6.Name = "barSubItem6";
            // 
            // barSubItem7
            // 
            this.barSubItem7.Caption = "关联规则";
            this.barSubItem7.Id = 27;
            this.barSubItem7.Name = "barSubItem7";
            // 
            // barSubItem8
            // 
            this.barSubItem8.Caption = "神经网络";
            this.barSubItem8.Id = 28;
            this.barSubItem8.Name = "barSubItem8";
            // 
            // menuWindow
            // 
            this.menuWindow.Caption = "窗口(&W)";
            this.menuWindow.Id = 7;
            this.menuWindow.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnWindowCascade),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnWindowTile),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnWindowMin),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnWindowRecover)});
            this.menuWindow.Name = "menuWindow";
            // 
            // btnWindowCascade
            // 
            this.btnWindowCascade.Caption = "层叠";
            this.btnWindowCascade.Id = 33;
            this.btnWindowCascade.Name = "btnWindowCascade";
            this.btnWindowCascade.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWindowCascade_ItemClick);
            // 
            // btnWindowTile
            // 
            this.btnWindowTile.Caption = "平铺";
            this.btnWindowTile.Id = 34;
            this.btnWindowTile.Name = "btnWindowTile";
            this.btnWindowTile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWindowTile_ItemClick);
            // 
            // btnWindowMin
            // 
            this.btnWindowMin.Caption = "全部最小化";
            this.btnWindowMin.Id = 35;
            this.btnWindowMin.Name = "btnWindowMin";
            this.btnWindowMin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWindowMin_ItemClick);
            // 
            // btnWindowRecover
            // 
            this.btnWindowRecover.Caption = "恢复显示";
            this.btnWindowRecover.Id = 36;
            this.btnWindowRecover.Name = "btnWindowRecover";
            this.btnWindowRecover.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWindowRecover_ItemClick);
            // 
            // menuHelp
            // 
            this.menuHelp.Caption = "帮助(&H)";
            this.menuHelp.Id = 8;
            this.menuHelp.Name = "menuHelp";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.stlCurrentForm)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.barStaticItem1.Caption = "当前工作表:";
            this.barStaticItem1.Id = 39;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // stlCurrentForm
            // 
            this.stlCurrentForm.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.stlCurrentForm.Id = 40;
            this.stlCurrentForm.Name = "stlCurrentForm";
            this.stlCurrentForm.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1284, 58);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 774);
            this.barDockControlBottom.Size = new System.Drawing.Size(1284, 29);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 58);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 716);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1284, 58);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 716);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 803);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MPPO";
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem menuFile;
        private DevExpress.XtraBars.BarSubItem menuEdit;
        private DevExpress.XtraBars.BarSubItem menuData;
        private DevExpress.XtraBars.BarSubItem menuStatistics;
        private DevExpress.XtraBars.BarSubItem menuGraph;
        private DevExpress.XtraBars.BarSubItem menuDataMining;
        private DevExpress.XtraBars.BarSubItem menuWindow;
        private DevExpress.XtraBars.BarSubItem menuHelp;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnStandardData;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraBars.BarButtonItem btnEntropy;
        private DevExpress.XtraBars.BarButtonItem btnOrthogSelect;
        private DevExpress.XtraBars.BarSubItem barSubItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarSubItem barSubItem6;
        private DevExpress.XtraBars.BarSubItem barSubItem7;
        private DevExpress.XtraBars.BarSubItem barSubItem8;
        private DevExpress.XtraBars.BarButtonItem btnWindowCascade;
        private DevExpress.XtraBars.BarButtonItem btnWindowTile;
        private DevExpress.XtraBars.BarButtonItem btnWindowMin;
        private DevExpress.XtraBars.BarButtonItem btnWindowRecover;
        private DevExpress.XtraBars.BarButtonItem btnQueryDataBase;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem stlCurrentForm;
        private DevExpress.XtraBars.BarButtonItem btnNewQuery;
        private DevExpress.XtraBars.BarButtonItem btnNewTable;
        private DevExpress.XtraBars.BarButtonItem btnCopyTable;
    }
}