namespace TileMapEditor
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPlayingMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createResourceMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPlayingMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadResourceMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPlayingMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportResourceMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decorativeImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemsImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResourceImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripCreateMapBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripCreateResourceMapBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripLoadMapBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripLoadResourceBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripExportMapBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripGridBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDecorationBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripItemsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripResourceBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripColorBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripOptionBtn = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.picMap = new System.Windows.Forms.PictureBox();
            this.picThumbnail = new System.Windows.Forms.PictureBox();
            this.toolStriplbl = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(826, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewMapToolStripMenuItem,
            this.loadMapToolStripMenuItem,
            this.exportMapToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createNewMapToolStripMenuItem
            // 
            this.createNewMapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createPlayingMapToolStripMenuItem,
            this.createResourceMapToolStripMenuItem});
            this.createNewMapToolStripMenuItem.Name = "createNewMapToolStripMenuItem";
            this.createNewMapToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.createNewMapToolStripMenuItem.Text = "Create New Map...";
            // 
            // createPlayingMapToolStripMenuItem
            // 
            this.createPlayingMapToolStripMenuItem.Name = "createPlayingMapToolStripMenuItem";
            this.createPlayingMapToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.createPlayingMapToolStripMenuItem.Text = "Playing Map...";
            this.createPlayingMapToolStripMenuItem.Click += new System.EventHandler(this.CreatePlayingMapToolStripMenuItemClick);
            // 
            // createResourceMapToolStripMenuItem
            // 
            this.createResourceMapToolStripMenuItem.Name = "createResourceMapToolStripMenuItem";
            this.createResourceMapToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.createResourceMapToolStripMenuItem.Text = "Resource Map...";
            this.createResourceMapToolStripMenuItem.Click += new System.EventHandler(this.createResourceMapToolStripMenuItem_Click);
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPlayingMapToolStripMenuItem,
            this.loadResourceMapToolStripMenuItem});
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.loadMapToolStripMenuItem.Text = "Load Map ...";
            // 
            // loadPlayingMapToolStripMenuItem
            // 
            this.loadPlayingMapToolStripMenuItem.Enabled = false;
            this.loadPlayingMapToolStripMenuItem.Name = "loadPlayingMapToolStripMenuItem";
            this.loadPlayingMapToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.loadPlayingMapToolStripMenuItem.Text = "Playing Map...";
            this.loadPlayingMapToolStripMenuItem.Click += new System.EventHandler(this.loadPlayingMapToolStripMenuItem_Click);
            // 
            // loadResourceMapToolStripMenuItem
            // 
            this.loadResourceMapToolStripMenuItem.Enabled = false;
            this.loadResourceMapToolStripMenuItem.Name = "loadResourceMapToolStripMenuItem";
            this.loadResourceMapToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.loadResourceMapToolStripMenuItem.Text = "Resource Map...";
            this.loadResourceMapToolStripMenuItem.Click += new System.EventHandler(this.loadResourceMapToolStripMenuItem_Click);
            // 
            // exportMapToolStripMenuItem
            // 
            this.exportMapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportPlayingMapToolStripMenuItem,
            this.exportResourceMapToolStripMenuItem});
            this.exportMapToolStripMenuItem.Name = "exportMapToolStripMenuItem";
            this.exportMapToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exportMapToolStripMenuItem.Text = "Export Map...";
            // 
            // exportPlayingMapToolStripMenuItem
            // 
            this.exportPlayingMapToolStripMenuItem.Enabled = false;
            this.exportPlayingMapToolStripMenuItem.Name = "exportPlayingMapToolStripMenuItem";
            this.exportPlayingMapToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exportPlayingMapToolStripMenuItem.Text = "Playing Map...";
            this.exportPlayingMapToolStripMenuItem.Click += new System.EventHandler(this.exportPlayingMapToolStripMenuItem_Click);
            // 
            // exportResourceMapToolStripMenuItem
            // 
            this.exportResourceMapToolStripMenuItem.Enabled = false;
            this.exportResourceMapToolStripMenuItem.Name = "exportResourceMapToolStripMenuItem";
            this.exportResourceMapToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exportResourceMapToolStripMenuItem.Text = "Resource Map...";
            this.exportResourceMapToolStripMenuItem.Click += new System.EventHandler(this.exportResourceMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.imageSetToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.GridToolStripMenuItemClick);
            // 
            // imageSetToolStripMenuItem
            // 
            this.imageSetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decorativeImagesToolStripMenuItem,
            this.ItemsImagesToolStripMenuItem,
            this.ResourceImagesToolStripMenuItem});
            this.imageSetToolStripMenuItem.Name = "imageSetToolStripMenuItem";
            this.imageSetToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.imageSetToolStripMenuItem.Text = "Image Set";
            // 
            // decorativeImagesToolStripMenuItem
            // 
            this.decorativeImagesToolStripMenuItem.Checked = true;
            this.decorativeImagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.decorativeImagesToolStripMenuItem.Name = "decorativeImagesToolStripMenuItem";
            this.decorativeImagesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.decorativeImagesToolStripMenuItem.Text = "Decorative images";
            this.decorativeImagesToolStripMenuItem.Click += new System.EventHandler(this.decorativeImagesToolStripMenuItem_Click);
            // 
            // ItemsImagesToolStripMenuItem
            // 
            this.ItemsImagesToolStripMenuItem.Name = "ItemsImagesToolStripMenuItem";
            this.ItemsImagesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.ItemsImagesToolStripMenuItem.Text = "Other Item images";
            this.ItemsImagesToolStripMenuItem.Click += new System.EventHandler(this.enemyImagesToolStripMenuItem_Click);
            // 
            // ResourceImagesToolStripMenuItem
            // 
            this.ResourceImagesToolStripMenuItem.Name = "ResourceImagesToolStripMenuItem";
            this.ResourceImagesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.ResourceImagesToolStripMenuItem.Text = "Resource images";
            this.ResourceImagesToolStripMenuItem.Click += new System.EventHandler(this.spriteImagesToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lightToolStripMenuItem,
            this.waterToolStripMenuItem,
            this.darkToolStripMenuItem,
            this.fireToolStripMenuItem,
            this.skyToolStripMenuItem,
            this.transparentToolStripMenuItem});
            this.backgroundColorToolStripMenuItem.Enabled = false;
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.backgroundColorToolStripMenuItem.Text = "Background Color";
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.Checked = true;
            this.lightToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.lightToolStripMenuItem.Text = "Light";
            this.lightToolStripMenuItem.Click += new System.EventHandler(this.LightToolStripMenuItemClick);
            // 
            // waterToolStripMenuItem
            // 
            this.waterToolStripMenuItem.Name = "waterToolStripMenuItem";
            this.waterToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.waterToolStripMenuItem.Text = "Water";
            this.waterToolStripMenuItem.Click += new System.EventHandler(this.WaterToolStripMenuItemClick);
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.darkToolStripMenuItem.Text = "Dark";
            this.darkToolStripMenuItem.Click += new System.EventHandler(this.DarkToolStripMenuItemClick);
            // 
            // fireToolStripMenuItem
            // 
            this.fireToolStripMenuItem.Name = "fireToolStripMenuItem";
            this.fireToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.fireToolStripMenuItem.Text = "Fire";
            this.fireToolStripMenuItem.Click += new System.EventHandler(this.FireToolStripMenuItemClick);
            // 
            // skyToolStripMenuItem
            // 
            this.skyToolStripMenuItem.Name = "skyToolStripMenuItem";
            this.skyToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.skyToolStripMenuItem.Text = "Sky";
            this.skyToolStripMenuItem.Click += new System.EventHandler(this.SkyToolStripMenuItemClick);
            // 
            // transparentToolStripMenuItem
            // 
            this.transparentToolStripMenuItem.Name = "transparentToolStripMenuItem";
            this.transparentToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.transparentToolStripMenuItem.Text = "Transparent";
            this.transparentToolStripMenuItem.Click += new System.EventHandler(this.transparentToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences...";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCreateMapBtn,
            this.toolStripCreateResourceMapBtn,
            this.toolStripLoadMapBtn,
            this.toolStripLoadResourceBtn,
            this.toolStripExportMapBtn,
            this.toolStripSeparator2,
            this.toolStripGridBtn,
            this.toolStripSeparator3,
            this.toolStripDecorationBtn,
            this.toolStripItemsBtn,
            this.toolStripResourceBtn,
            this.toolStripSeparator4,
            this.toolStripColorBtn,
            this.toolStripSeparator5,
            this.toolStripOptionBtn,
            this.toolStriplbl});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(826, 70);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripCreateMapBtn
            // 
            this.toolStripCreateMapBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCreateMapBtn.Image")));
            this.toolStripCreateMapBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripCreateMapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreateMapBtn.Name = "toolStripCreateMapBtn";
            this.toolStripCreateMapBtn.Size = new System.Drawing.Size(55, 67);
            this.toolStripCreateMapBtn.Text = "New Map";
            this.toolStripCreateMapBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripCreateMapBtn.ToolTipText = "New Resource Map";
            this.toolStripCreateMapBtn.Click += new System.EventHandler(this.CreatePlayingMapToolStripMenuItemClick);
            // 
            // toolStripCreateResourceMapBtn
            // 
            this.toolStripCreateResourceMapBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCreateResourceMapBtn.Image")));
            this.toolStripCreateResourceMapBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripCreateResourceMapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreateResourceMapBtn.Name = "toolStripCreateResourceMapBtn";
            this.toolStripCreateResourceMapBtn.Size = new System.Drawing.Size(80, 67);
            this.toolStripCreateResourceMapBtn.Text = "New Resource";
            this.toolStripCreateResourceMapBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripCreateResourceMapBtn.ToolTipText = "New Resource Map";
            this.toolStripCreateResourceMapBtn.Click += new System.EventHandler(this.createResourceMapToolStripMenuItem_Click);
            // 
            // toolStripLoadMapBtn
            // 
            this.toolStripLoadMapBtn.Enabled = false;
            this.toolStripLoadMapBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLoadMapBtn.Image")));
            this.toolStripLoadMapBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLoadMapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLoadMapBtn.Name = "toolStripLoadMapBtn";
            this.toolStripLoadMapBtn.Size = new System.Drawing.Size(57, 67);
            this.toolStripLoadMapBtn.Text = "Load Map";
            this.toolStripLoadMapBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripLoadMapBtn.ToolTipText = "New Resource Map";
            this.toolStripLoadMapBtn.Click += new System.EventHandler(this.loadPlayingMapToolStripMenuItem_Click);
            // 
            // toolStripLoadResourceBtn
            // 
            this.toolStripLoadResourceBtn.Enabled = false;
            this.toolStripLoadResourceBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLoadResourceBtn.Image")));
            this.toolStripLoadResourceBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLoadResourceBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLoadResourceBtn.Name = "toolStripLoadResourceBtn";
            this.toolStripLoadResourceBtn.Size = new System.Drawing.Size(82, 67);
            this.toolStripLoadResourceBtn.Text = "Load Resource";
            this.toolStripLoadResourceBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripLoadResourceBtn.ToolTipText = "New Resource Map";
            this.toolStripLoadResourceBtn.Click += new System.EventHandler(this.loadResourceMapToolStripMenuItem_Click);
            // 
            // toolStripExportMapBtn
            // 
            this.toolStripExportMapBtn.Enabled = false;
            this.toolStripExportMapBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripExportMapBtn.Image")));
            this.toolStripExportMapBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripExportMapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripExportMapBtn.Name = "toolStripExportMapBtn";
            this.toolStripExportMapBtn.Size = new System.Drawing.Size(66, 67);
            this.toolStripExportMapBtn.Text = "Export Map";
            this.toolStripExportMapBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripExportMapBtn.ToolTipText = "New Resource Map";
            this.toolStripExportMapBtn.Click += new System.EventHandler(this.toolStripExportMapBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 70);
            // 
            // toolStripGridBtn
            // 
            this.toolStripGridBtn.Enabled = false;
            this.toolStripGridBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripGridBtn.Image")));
            this.toolStripGridBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripGridBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripGridBtn.Name = "toolStripGridBtn";
            this.toolStripGridBtn.Size = new System.Drawing.Size(54, 67);
            this.toolStripGridBtn.Text = "Grid";
            this.toolStripGridBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripGridBtn.ToolTipText = "New Resource Map";
            this.toolStripGridBtn.Click += new System.EventHandler(this.GridToolStripMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 70);
            // 
            // toolStripDecorationBtn
            // 
            this.toolStripDecorationBtn.Enabled = false;
            this.toolStripDecorationBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDecorationBtn.Image")));
            this.toolStripDecorationBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDecorationBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDecorationBtn.Name = "toolStripDecorationBtn";
            this.toolStripDecorationBtn.Size = new System.Drawing.Size(63, 67);
            this.toolStripDecorationBtn.Text = "Decoration";
            this.toolStripDecorationBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripDecorationBtn.ToolTipText = "New Resource Map";
            this.toolStripDecorationBtn.Click += new System.EventHandler(this.decorativeImagesToolStripMenuItem_Click);
            // 
            // toolStripItemsBtn
            // 
            this.toolStripItemsBtn.Enabled = false;
            this.toolStripItemsBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripItemsBtn.Image")));
            this.toolStripItemsBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripItemsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripItemsBtn.Name = "toolStripItemsBtn";
            this.toolStripItemsBtn.Size = new System.Drawing.Size(54, 67);
            this.toolStripItemsBtn.Text = "Items";
            this.toolStripItemsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripItemsBtn.ToolTipText = "New Resource Map";
            this.toolStripItemsBtn.Click += new System.EventHandler(this.enemyImagesToolStripMenuItem_Click);
            // 
            // toolStripResourceBtn
            // 
            this.toolStripResourceBtn.Enabled = false;
            this.toolStripResourceBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripResourceBtn.Image")));
            this.toolStripResourceBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripResourceBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripResourceBtn.Name = "toolStripResourceBtn";
            this.toolStripResourceBtn.Size = new System.Drawing.Size(56, 67);
            this.toolStripResourceBtn.Text = "Resource";
            this.toolStripResourceBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripResourceBtn.ToolTipText = "New Resource Map";
            this.toolStripResourceBtn.Click += new System.EventHandler(this.spriteImagesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 70);
            // 
            // toolStripColorBtn
            // 
            this.toolStripColorBtn.Enabled = false;
            this.toolStripColorBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripColorBtn.Image")));
            this.toolStripColorBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripColorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripColorBtn.Name = "toolStripColorBtn";
            this.toolStripColorBtn.Size = new System.Drawing.Size(54, 67);
            this.toolStripColorBtn.Text = "Color";
            this.toolStripColorBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripColorBtn.ToolTipText = "New Resource Map";
            this.toolStripColorBtn.Click += new System.EventHandler(this.toolStripColorBtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 70);
            // 
            // toolStripOptionBtn
            // 
            this.toolStripOptionBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripOptionBtn.Image")));
            this.toolStripOptionBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripOptionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripOptionBtn.Name = "toolStripOptionBtn";
            this.toolStripOptionBtn.Size = new System.Drawing.Size(54, 67);
            this.toolStripOptionBtn.Text = "Options";
            this.toolStripOptionBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripOptionBtn.ToolTipText = "New Resource Map";
            this.toolStripOptionBtn.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 94);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.picMap);
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.picThumbnail);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel2MinSize = 20;
            this.splitContainer1.Size = new System.Drawing.Size(826, 569);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 2;
            // 
            // picMap
            // 
            this.picMap.BackColor = System.Drawing.Color.Transparent;
            this.picMap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picMap.BackgroundImage")));
            this.picMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMap.InitialImage = null;
            this.picMap.Location = new System.Drawing.Point(0, 0);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(826, 569);
            this.picMap.TabIndex = 0;
            this.picMap.TabStop = false;
            this.picMap.MouseLeave += new System.EventHandler(this.picMap_MouseLeave);
            this.picMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseDown);
            this.picMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseMove);
            this.picMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picMap_MouseUp);
            // 
            // picThumbnail
            // 
            this.picThumbnail.Location = new System.Drawing.Point(0, 0);
            this.picThumbnail.Name = "picThumbnail";
            this.picThumbnail.Size = new System.Drawing.Size(670, 74);
            this.picThumbnail.TabIndex = 0;
            this.picThumbnail.TabStop = false;
            this.picThumbnail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicThumbnailMouseDown);
            // 
            // toolStriplbl
            // 
            this.toolStriplbl.Name = "toolStriplbl";
            this.toolStriplbl.Size = new System.Drawing.Size(0, 67);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(826, 663);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.Text = "Tile Map Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ToolStripButton toolStripCreateMapBtn;
        private System.Windows.Forms.ToolStripMenuItem createPlayingMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createResourceMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadResourceMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPlayingMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportResourceMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPlayingMapToolStripMenuItem;
        private System.Windows.Forms.PictureBox picThumbnail;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem imageSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decorativeImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItemsImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResourceImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem transparentToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripGridBtn;
        private System.Windows.Forms.ToolStripButton toolStripDecorationBtn;
        private System.Windows.Forms.ToolStripButton toolStripResourceBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripItemsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripOptionBtn;
        private System.Windows.Forms.ToolStripButton toolStripCreateResourceMapBtn;
        private System.Windows.Forms.ToolStripButton toolStripExportMapBtn;
        private System.Windows.Forms.ToolStripButton toolStripColorBtn;
        private System.Windows.Forms.ToolStripButton toolStripLoadMapBtn;
        private System.Windows.Forms.ToolStripButton toolStripLoadResourceBtn;
        private System.Windows.Forms.ToolStripLabel toolStriplbl;
    }
}

