namespace WhuGIS.Forms.FormMain
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.SplitContainer splitContainer1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.axTOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.EagleEyeMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.TocContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuSeeAttr = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuRemoveLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuZoomToLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSelFeature = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuZoomToSel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClearSel = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Openmxd = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_OpenGDB = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_OpenShapfile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_区域导出 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_全域导出 = new System.Windows.Forms.ToolStripMenuItem();
            this.数据分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图量测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.距离量测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.面积量测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.网络分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_最短路径分析 = new System.Windows.Forms.ToolStripMenuItem();
            this.信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.摄像头ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.特征地物图像查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.校园信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EagleEyeMapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).BeginInit();
            this.TocContextMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(this.axTOCControl);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(this.EagleEyeMapControl);
            splitContainer1.Panel2.Controls.Add(this.axLicenseControl);
            splitContainer1.Panel2.Controls.Add(this.axMapControl);
            splitContainer1.Size = new System.Drawing.Size(1112, 609);
            splitContainer1.SplitterDistance = 180;
            splitContainer1.TabIndex = 2;
            // 
            // axTOCControl
            // 
            this.axTOCControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl.Name = "axTOCControl";
            this.axTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl.OcxState")));
            this.axTOCControl.Size = new System.Drawing.Size(180, 609);
            this.axTOCControl.TabIndex = 1;
            this.axTOCControl.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl_OnMouseDown);
            this.axTOCControl.OnMouseUp += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseUpEventHandler(this.axTOCControl_OnMouseUp);
            // 
            // EagleEyeMapControl
            // 
            this.EagleEyeMapControl.Location = new System.Drawing.Point(0, 396);
            this.EagleEyeMapControl.Name = "EagleEyeMapControl";
            this.EagleEyeMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("EagleEyeMapControl.OcxState")));
            this.EagleEyeMapControl.Size = new System.Drawing.Size(275, 213);
            this.EagleEyeMapControl.TabIndex = 4;
            this.EagleEyeMapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.EagleEyeMapControl_OnMouseDown);
            this.EagleEyeMapControl.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.EagleEyeMapControl_OnMouseUp);
            this.EagleEyeMapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.EagleEyeMapControl_OnMouseMove);
            // 
            // axLicenseControl
            // 
            this.axLicenseControl.Enabled = true;
            this.axLicenseControl.Location = new System.Drawing.Point(813, -13);
            this.axLicenseControl.Name = "axLicenseControl";
            this.axLicenseControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl.OcxState")));
            this.axLicenseControl.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl.TabIndex = 3;
            // 
            // axMapControl
            // 
            this.axMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl.Location = new System.Drawing.Point(0, 0);
            this.axMapControl.Name = "axMapControl";
            this.axMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl.OcxState")));
            this.axMapControl.Size = new System.Drawing.Size(928, 609);
            this.axMapControl.TabIndex = 0;
            this.axMapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_OnMouseDown);
            this.axMapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl_OnMouseMove);
            this.axMapControl.OnDoubleClick += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnDoubleClickEventHandler(this.axMapControl_OnDoubleClick);
            this.axMapControl.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl_OnExtentUpdated);
            this.axMapControl.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl_OnMapReplaced);
            // 
            // TocContextMenu
            // 
            this.TocContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSeeAttr,
            this.toolStripSeparator1,
            this.MenuRemoveLayer,
            this.MenuZoomToLayer,
            this.MenuSelFeature,
            this.MenuZoomToSel,
            this.MenuClearSel});
            this.TocContextMenu.Name = "TocContextMenu";
            this.TocContextMenu.Size = new System.Drawing.Size(161, 142);
            this.TocContextMenu.Text = "右键菜单";
            // 
            // MenuSeeAttr
            // 
            this.MenuSeeAttr.Name = "MenuSeeAttr";
            this.MenuSeeAttr.Size = new System.Drawing.Size(160, 22);
            this.MenuSeeAttr.Text = "查看项目属性";
            this.MenuSeeAttr.Click += new System.EventHandler(this.MenuSeeAttr_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // MenuRemoveLayer
            // 
            this.MenuRemoveLayer.Name = "MenuRemoveLayer";
            this.MenuRemoveLayer.Size = new System.Drawing.Size(160, 22);
            this.MenuRemoveLayer.Text = "移除图层";
            this.MenuRemoveLayer.Click += new System.EventHandler(this.MenuRemoveLayer_Click);
            // 
            // MenuZoomToLayer
            // 
            this.MenuZoomToLayer.Name = "MenuZoomToLayer";
            this.MenuZoomToLayer.Size = new System.Drawing.Size(160, 22);
            this.MenuZoomToLayer.Text = "缩放至图层";
            this.MenuZoomToLayer.Click += new System.EventHandler(this.缩放至图层ToolStripMenuItem_Click);
            // 
            // MenuSelFeature
            // 
            this.MenuSelFeature.Name = "MenuSelFeature";
            this.MenuSelFeature.Size = new System.Drawing.Size(160, 22);
            this.MenuSelFeature.Text = "要素选择";
            this.MenuSelFeature.Click += new System.EventHandler(this.要素选择ToolStripMenuItem_Click);
            // 
            // MenuZoomToSel
            // 
            this.MenuZoomToSel.Name = "MenuZoomToSel";
            this.MenuZoomToSel.Size = new System.Drawing.Size(160, 22);
            this.MenuZoomToSel.Text = "缩放至所选要素";
            this.MenuZoomToSel.Click += new System.EventHandler(this.MenuZoomToSel_Click);
            // 
            // MenuClearSel
            // 
            this.MenuClearSel.Name = "MenuClearSel";
            this.MenuClearSel.Size = new System.Drawing.Size(160, 22);
            this.MenuClearSel.Text = "清除所选要素";
            this.MenuClearSel.Click += new System.EventHandler(this.MenuClearSel_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1136, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "StatusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(124, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel";
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File,
            this.数据分析ToolStripMenuItem,
            this.信息查询ToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1136, 25);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_File
            // 
            this.ToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Openmxd,
            this.ToolStripMenuItem_OpenGDB,
            this.ToolStripMenuItem_OpenShapfile,
            this.toolStripMenuItem1,
            this.ToolStripMenuItem_SaveAs,
            this.导出ToolStripMenuItem});
            this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
            this.ToolStripMenuItem_File.Size = new System.Drawing.Size(44, 21);
            this.ToolStripMenuItem_File.Text = "文件";
            // 
            // ToolStripMenuItem_Openmxd
            // 
            this.ToolStripMenuItem_Openmxd.Name = "ToolStripMenuItem_Openmxd";
            this.ToolStripMenuItem_Openmxd.Size = new System.Drawing.Size(198, 22);
            this.ToolStripMenuItem_Openmxd.Text = "打开地图文件...";
            this.ToolStripMenuItem_Openmxd.Click += new System.EventHandler(this.ToolStripMenuItem_Openmxd_Click);
            // 
            // ToolStripMenuItem_OpenGDB
            // 
            this.ToolStripMenuItem_OpenGDB.Name = "ToolStripMenuItem_OpenGDB";
            this.ToolStripMenuItem_OpenGDB.Size = new System.Drawing.Size(198, 22);
            this.ToolStripMenuItem_OpenGDB.Text = "打开MDB数据库文件...";
            this.ToolStripMenuItem_OpenGDB.Click += new System.EventHandler(this.ToolStripMenuItem_OpenGDB_Click);
            // 
            // ToolStripMenuItem_OpenShapfile
            // 
            this.ToolStripMenuItem_OpenShapfile.Name = "ToolStripMenuItem_OpenShapfile";
            this.ToolStripMenuItem_OpenShapfile.Size = new System.Drawing.Size(198, 22);
            this.ToolStripMenuItem_OpenShapfile.Text = "添加ShapeFile...(图层)";
            this.ToolStripMenuItem_OpenShapfile.Click += new System.EventHandler(this.ToolStripMenuItem_OpenShapfile_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 6);
            // 
            // ToolStripMenuItem_SaveAs
            // 
            this.ToolStripMenuItem_SaveAs.Name = "ToolStripMenuItem_SaveAs";
            this.ToolStripMenuItem_SaveAs.Size = new System.Drawing.Size(198, 22);
            this.ToolStripMenuItem_SaveAs.Text = "另存为...";
            this.ToolStripMenuItem_SaveAs.Click += new System.EventHandler(this.ToolStripMenuItem_SaveAs_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_区域导出,
            this.ToolStripMenuItem_全域导出});
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // ToolStripMenuItem_区域导出
            // 
            this.ToolStripMenuItem_区域导出.Name = "ToolStripMenuItem_区域导出";
            this.ToolStripMenuItem_区域导出.Size = new System.Drawing.Size(133, 22);
            this.ToolStripMenuItem_区域导出.Text = "区域导出...";
            this.ToolStripMenuItem_区域导出.Click += new System.EventHandler(this.ToolStripMenuItem_区域导出_Click);
            // 
            // ToolStripMenuItem_全域导出
            // 
            this.ToolStripMenuItem_全域导出.Name = "ToolStripMenuItem_全域导出";
            this.ToolStripMenuItem_全域导出.Size = new System.Drawing.Size(133, 22);
            this.ToolStripMenuItem_全域导出.Text = "全域导出...";
            this.ToolStripMenuItem_全域导出.Click += new System.EventHandler(this.ToolStripMenuItem_全域导出_Click);
            // 
            // 数据分析ToolStripMenuItem
            // 
            this.数据分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.地图量测ToolStripMenuItem,
            this.网络分析ToolStripMenuItem});
            this.数据分析ToolStripMenuItem.Name = "数据分析ToolStripMenuItem";
            this.数据分析ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据分析ToolStripMenuItem.Text = "数据分析";
            // 
            // 地图量测ToolStripMenuItem
            // 
            this.地图量测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.距离量测ToolStripMenuItem,
            this.面积量测ToolStripMenuItem});
            this.地图量测ToolStripMenuItem.Name = "地图量测ToolStripMenuItem";
            this.地图量测ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.地图量测ToolStripMenuItem.Text = "地图量测";
            // 
            // 距离量测ToolStripMenuItem
            // 
            this.距离量测ToolStripMenuItem.Name = "距离量测ToolStripMenuItem";
            this.距离量测ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.距离量测ToolStripMenuItem.Text = "距离量测";
            this.距离量测ToolStripMenuItem.Click += new System.EventHandler(this.距离量测ToolStripMenuItem_Click);
            // 
            // 面积量测ToolStripMenuItem
            // 
            this.面积量测ToolStripMenuItem.Name = "面积量测ToolStripMenuItem";
            this.面积量测ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.面积量测ToolStripMenuItem.Text = "面积量测";
            this.面积量测ToolStripMenuItem.Click += new System.EventHandler(this.面积量测ToolStripMenuItem_Click);
            // 
            // 网络分析ToolStripMenuItem
            // 
            this.网络分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_最短路径分析});
            this.网络分析ToolStripMenuItem.Name = "网络分析ToolStripMenuItem";
            this.网络分析ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.网络分析ToolStripMenuItem.Text = "网络分析";
            // 
            // ToolStripMenuItem_最短路径分析
            // 
            this.ToolStripMenuItem_最短路径分析.Name = "ToolStripMenuItem_最短路径分析";
            this.ToolStripMenuItem_最短路径分析.Size = new System.Drawing.Size(157, 22);
            this.ToolStripMenuItem_最短路径分析.Text = "最短路径分析...";
            this.ToolStripMenuItem_最短路径分析.Click += new System.EventHandler(this.ToolStripMenuItem_最短路径分析_Click);
            // 
            // 信息查询ToolStripMenuItem
            // 
            this.信息查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.摄像头ToolStripMenuItem,
            this.特征地物图像查询ToolStripMenuItem,
            this.校园信息查询ToolStripMenuItem});
            this.信息查询ToolStripMenuItem.Name = "信息查询ToolStripMenuItem";
            this.信息查询ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.信息查询ToolStripMenuItem.Text = "信息查询";
            // 
            // 摄像头ToolStripMenuItem
            // 
            this.摄像头ToolStripMenuItem.Name = "摄像头ToolStripMenuItem";
            this.摄像头ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.摄像头ToolStripMenuItem.Text = "监控覆盖范围...";
            this.摄像头ToolStripMenuItem.Click += new System.EventHandler(this.摄像头ToolStripMenuItem_Click);
            // 
            // 特征地物图像查询ToolStripMenuItem
            // 
            this.特征地物图像查询ToolStripMenuItem.Name = "特征地物图像查询ToolStripMenuItem";
            this.特征地物图像查询ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.特征地物图像查询ToolStripMenuItem.Text = "特征地物图像查询";
            this.特征地物图像查询ToolStripMenuItem.Click += new System.EventHandler(this.特征地物图像查询ToolStripMenuItem_Click);
            // 
            // 校园信息查询ToolStripMenuItem
            // 
            this.校园信息查询ToolStripMenuItem.Name = "校园信息查询ToolStripMenuItem";
            this.校园信息查询ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.校园信息查询ToolStripMenuItem.Text = "校园公共信息查询...";
            this.校园信息查询ToolStripMenuItem.Click += new System.EventHandler(this.校园信息查询ToolStripMenuItem_Click);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 34);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(22, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Size = new System.Drawing.Size(1112, 609);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1112, 609);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1136, 656);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.MainMenu);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 656);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FormMain";
            this.Text = "校园地理信息系统";
            this.Load += new System.EventHandler(this.FormMain_Load);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EagleEyeMapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl)).EndInit();
            this.TocContextMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip TocContextMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuSeeAttr;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuRemoveLayer;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.ToolStripMenuItem MenuZoomToLayer;
        private System.Windows.Forms.ToolStripMenuItem MenuSelFeature;
        private System.Windows.Forms.ToolStripMenuItem MenuZoomToSel;
        private System.Windows.Forms.ToolStripMenuItem MenuClearSel;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Openmxd;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenGDB;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenShapfile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_区域导出;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_全域导出;
        private System.Windows.Forms.ToolStripMenuItem 数据分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图量测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 距离量测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 面积量测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 网络分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_最短路径分析;
        private System.Windows.Forms.ToolStripMenuItem 信息查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 摄像头ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 特征地物图像查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 校园信息查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl;
        private ESRI.ArcGIS.Controls.AxMapControl EagleEyeMapControl;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;

    }
}

