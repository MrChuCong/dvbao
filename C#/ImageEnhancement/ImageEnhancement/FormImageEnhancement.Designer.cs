namespace ImageEnhancement
{
    partial class FormImageEnhancement
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEnhancement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAutoEnhancement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnByCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNaturalScence = new System.Windows.Forms.ToolStripMenuItem();
            this.mnXRay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOldPortrait = new System.Windows.Forms.ToolStripMenuItem();
            this.pbCurrentImage = new System.Windows.Forms.PictureBox();
            this.mnCircleDetection = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFile,
            this.mnEnhancement});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(809, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnFile
            // 
            this.mnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnOpen,
            this.mnSave,
            this.toolStripSeparator1,
            this.mnExit});
            this.mnFile.Name = "mnFile";
            this.mnFile.Size = new System.Drawing.Size(35, 20);
            this.mnFile.Text = "&File";
            // 
            // mnOpen
            // 
            this.mnOpen.Image = global::ImageEnhancement.Properties.Resources.MenuFileOpenIcon;
            this.mnOpen.Name = "mnOpen";
            this.mnOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnOpen.Size = new System.Drawing.Size(152, 22);
            this.mnOpen.Text = "&Open...";
            this.mnOpen.Click += new System.EventHandler(this.mnOpen_Click);
            // 
            // mnSave
            // 
            this.mnSave.Image = global::ImageEnhancement.Properties.Resources.MenuFileSaveIcon;
            this.mnSave.Name = "mnSave";
            this.mnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnSave.Size = new System.Drawing.Size(152, 22);
            this.mnSave.Text = "&Save...";
            this.mnSave.Click += new System.EventHandler(this.mnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnExit.Size = new System.Drawing.Size(152, 22);
            this.mnExit.Text = "E&xit";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // mnEnhancement
            // 
            this.mnEnhancement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnAutoEnhancement,
            this.mnByCategory,
            this.mnCircleDetection});
            this.mnEnhancement.Name = "mnEnhancement";
            this.mnEnhancement.Size = new System.Drawing.Size(84, 20);
            this.mnEnhancement.Text = "&Enhancement";
            // 
            // mnAutoEnhancement
            // 
            this.mnAutoEnhancement.Name = "mnAutoEnhancement";
            this.mnAutoEnhancement.Size = new System.Drawing.Size(165, 22);
            this.mnAutoEnhancement.Text = "&Auto Enhancement";
            this.mnAutoEnhancement.Click += new System.EventHandler(this.mnAutoEnhancement_Click);
            // 
            // mnByCategory
            // 
            this.mnByCategory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnNaturalScence,
            this.mnXRay,
            this.mnOldPortrait});
            this.mnByCategory.Name = "mnByCategory";
            this.mnByCategory.Size = new System.Drawing.Size(165, 22);
            this.mnByCategory.Text = "By &Category";
            // 
            // mnNaturalScence
            // 
            this.mnNaturalScence.Name = "mnNaturalScence";
            this.mnNaturalScence.Size = new System.Drawing.Size(152, 22);
            this.mnNaturalScence.Text = "&Natural Scene";
            this.mnNaturalScence.Click += new System.EventHandler(this.mnNaturalScence_Click);
            // 
            // mnXRay
            // 
            this.mnXRay.Name = "mnXRay";
            this.mnXRay.Size = new System.Drawing.Size(152, 22);
            this.mnXRay.Text = "&X Ray";
            this.mnXRay.Click += new System.EventHandler(this.mnXRay_Click);
            // 
            // mnOldPortrait
            // 
            this.mnOldPortrait.Name = "mnOldPortrait";
            this.mnOldPortrait.Size = new System.Drawing.Size(152, 22);
            this.mnOldPortrait.Text = "Old &Portrait";
            this.mnOldPortrait.Click += new System.EventHandler(this.mnOldPortrait_Click);
            // 
            // pbCurrentImage
            // 
            this.pbCurrentImage.BackColor = System.Drawing.Color.White;
            this.pbCurrentImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCurrentImage.Location = new System.Drawing.Point(0, 24);
            this.pbCurrentImage.Name = "pbCurrentImage";
            this.pbCurrentImage.Size = new System.Drawing.Size(809, 542);
            this.pbCurrentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCurrentImage.TabIndex = 1;
            this.pbCurrentImage.TabStop = false;
            // 
            // mnCircleDetection
            // 
            this.mnCircleDetection.Name = "mnCircleDetection";
            this.mnCircleDetection.Size = new System.Drawing.Size(165, 22);
            this.mnCircleDetection.Text = "Circle &Detection";
            this.mnCircleDetection.Click += new System.EventHandler(this.mnCircleDetection_Click);
            // 
            // FormImageEnhancement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 566);
            this.Controls.Add(this.pbCurrentImage);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormImageEnhancement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Enhancement";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.PictureBox pbCurrentImage;
        private System.Windows.Forms.ToolStripMenuItem mnFile;
        private System.Windows.Forms.ToolStripMenuItem mnOpen;
        private System.Windows.Forms.ToolStripMenuItem mnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.ToolStripMenuItem mnEnhancement;
        private System.Windows.Forms.ToolStripMenuItem mnAutoEnhancement;
        private System.Windows.Forms.ToolStripMenuItem mnByCategory;
        private System.Windows.Forms.ToolStripMenuItem mnNaturalScence;
        private System.Windows.Forms.ToolStripMenuItem mnXRay;
        private System.Windows.Forms.ToolStripMenuItem mnOldPortrait;
        private System.Windows.Forms.ToolStripMenuItem mnCircleDetection;
    }
}

