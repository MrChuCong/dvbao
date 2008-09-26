namespace Core
{
    partial class FormFADPlayer
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
            this.player = new Core.FADPlayer();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player.FA = null;
            this.player.Input = null;
            this.player.Location = new System.Drawing.Point(0, 0);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(948, 559);
            this.player.TabIndex = 0;
            // 
            // FormFADPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 559);
            this.Controls.Add(this.player);
            this.Name = "FormFADPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finite Automata Demonstration Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFADPlayer_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private FADPlayer player;
    }
}