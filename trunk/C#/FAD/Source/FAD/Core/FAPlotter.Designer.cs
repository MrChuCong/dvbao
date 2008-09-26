namespace Core
{
    partial class FAPlotter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAPlotter));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnState = new System.Windows.Forms.ToolStripButton();
            this.btnTransition = new System.Windows.Forms.ToolStripButton();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.background = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showAllControlLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockAllStatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockAllTransitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbar.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnState,
            this.btnTransition,
            this.btnSelect,
            this.btnDelete,
            this.toolStripSeparator2,
            this.btnPlay});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(774, 31);
            this.toolbar.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::Core.Properties.Resources.New;
            this.btnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(28, 28);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::Core.Properties.Resources.Open;
            this.btnOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(28, 28);
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::Core.Properties.Resources.Save;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(28, 28);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnState
            // 
            this.btnState.Image = global::Core.Properties.Resources.State;
            this.btnState.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnState.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnState.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnState.Name = "btnState";
            this.btnState.Size = new System.Drawing.Size(72, 28);
            this.btnState.Text = "State";
            this.btnState.Click += new System.EventHandler(this.btnState_Click);
            // 
            // btnTransition
            // 
            this.btnTransition.Image = global::Core.Properties.Resources.Transition;
            this.btnTransition.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTransition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTransition.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnTransition.Name = "btnTransition";
            this.btnTransition.Size = new System.Drawing.Size(100, 28);
            this.btnTransition.Text = "Transition";
            this.btnTransition.Click += new System.EventHandler(this.btnTransition_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::Core.Properties.Resources.Select;
            this.btnSelect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelect.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(76, 28);
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Core.Properties.Resources.Delete;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 28);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlay.Margin = new System.Windows.Forms.Padding(5, 1, 5, 2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(39, 28);
            this.btnPlay.Text = "Play";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.Color.White;
            this.background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.background.Location = new System.Drawing.Point(0, 31);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(774, 404);
            this.background.TabIndex = 0;
            this.background.MouseDown += new System.Windows.Forms.MouseEventHandler(this.background_MouseDown);
            this.background.MouseMove += new System.Windows.Forms.MouseEventHandler(this.background_MouseMove);
            this.background.MouseClick += new System.Windows.Forms.MouseEventHandler(this.background_MouseClick);
            this.background.Resize += new System.EventHandler(this.background_Resize);
            this.background.Paint += new System.Windows.Forms.PaintEventHandler(this.background_Paint);
            this.background.MouseUp += new System.Windows.Forms.MouseEventHandler(this.background_MouseUp);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllControlLinesToolStripMenuItem,
            this.lockAllStatesToolStripMenuItem,
            this.lockAllTransitionsToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(174, 70);
            // 
            // showAllControlLinesToolStripMenuItem
            // 
            this.showAllControlLinesToolStripMenuItem.Name = "showAllControlLinesToolStripMenuItem";
            this.showAllControlLinesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.showAllControlLinesToolStripMenuItem.Text = "Show all control lines";
            this.showAllControlLinesToolStripMenuItem.Click += new System.EventHandler(this.showAllControlLinesToolStripMenuItem_Click);
            // 
            // lockAllStatesToolStripMenuItem
            // 
            this.lockAllStatesToolStripMenuItem.Name = "lockAllStatesToolStripMenuItem";
            this.lockAllStatesToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.lockAllStatesToolStripMenuItem.Text = "Lock all states";
            this.lockAllStatesToolStripMenuItem.Click += new System.EventHandler(this.lockAllObjectsToolStripMenuItem_Click);
            // 
            // lockAllTransitionsToolStripMenuItem
            // 
            this.lockAllTransitionsToolStripMenuItem.Name = "lockAllTransitionsToolStripMenuItem";
            this.lockAllTransitionsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.lockAllTransitionsToolStripMenuItem.Text = "Lock all transitions";
            this.lockAllTransitionsToolStripMenuItem.Click += new System.EventHandler(this.lockAllTransitionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // FAPlotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.menu;
            this.Controls.Add(this.background);
            this.Controls.Add(this.toolbar);
            this.Name = "FAPlotter";
            this.Size = new System.Drawing.Size(774, 435);
            this.Load += new System.EventHandler(this.FAPlotter_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton btnState;
        private System.Windows.Forms.ToolStripButton btnTransition;
        private System.Windows.Forms.Panel background;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem showAllControlLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockAllStatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockAllTransitionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPlay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
