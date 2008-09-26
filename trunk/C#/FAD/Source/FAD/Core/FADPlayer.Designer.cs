namespace Core
{
    partial class FADPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FADPlayer));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnAutoplay = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.background = new System.Windows.Forms.Panel();
            this.comment = new Core.Comment();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolbar.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolbar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrevious,
            this.btnNext,
            this.btnReset,
            this.toolStripSeparator,
            this.btnAutoplay});
            this.toolbar.Location = new System.Drawing.Point(0, 421);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(849, 55);
            this.toolbar.TabIndex = 0;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Image = global::Core.Properties.Resources.Previous;
            this.btnPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(131, 52);
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::Core.Properties.Resources.Next;
            this.btnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 52);
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::Core.Properties.Resources.Reset;
            this.btnReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReset.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 52);
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAutoplay
            // 
            this.btnAutoplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAutoplay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoplay.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoplay.Image")));
            this.btnAutoplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAutoplay.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.btnAutoplay.Name = "btnAutoplay";
            this.btnAutoplay.Size = new System.Drawing.Size(86, 52);
            this.btnAutoplay.Text = "Autoplay";
            this.btnAutoplay.Click += new System.EventHandler(this.btnAutoplay_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.background);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.comment);
            this.splitContainer.Size = new System.Drawing.Size(849, 421);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 1;
            // 
            // background
            // 
            this.background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(500, 421);
            this.background.TabIndex = 0;
            this.background.Resize += new System.EventHandler(this.background_Resize);
            this.background.Paint += new System.Windows.Forms.PaintEventHandler(this.background_Paint);
            // 
            // comment
            // 
            this.comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comment.Location = new System.Drawing.Point(0, 0);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(345, 421);
            this.comment.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FADPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolbar);
            this.Name = "FADPlayer";
            this.Size = new System.Drawing.Size(849, 476);
            this.Load += new System.EventHandler(this.FADPlayer_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel background;
        private Comment comment;
        private System.Windows.Forms.ToolStripButton btnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton btnAutoplay;
        private System.Windows.Forms.Timer timer;
    }
}
