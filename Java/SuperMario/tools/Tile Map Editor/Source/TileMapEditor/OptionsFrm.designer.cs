namespace TileMapEditor
{
    partial class OptionsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDecorativeFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnemyFolder = new System.Windows.Forms.TextBox();
            this.btnDecorativeFolder = new System.Windows.Forms.Button();
            this.btnEnemyFolder = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSpriteFolder = new System.Windows.Forms.Button();
            this.txtSpriteFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlayingTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Decorative Folder";
            // 
            // txtDecorativeFolder
            // 
            this.txtDecorativeFolder.Location = new System.Drawing.Point(109, 38);
            this.txtDecorativeFolder.Name = "txtDecorativeFolder";
            this.txtDecorativeFolder.Size = new System.Drawing.Size(222, 20);
            this.txtDecorativeFolder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Items Folder";
            // 
            // txtEnemyFolder
            // 
            this.txtEnemyFolder.Location = new System.Drawing.Point(109, 82);
            this.txtEnemyFolder.Name = "txtEnemyFolder";
            this.txtEnemyFolder.Size = new System.Drawing.Size(222, 20);
            this.txtEnemyFolder.TabIndex = 3;
            // 
            // btnDecorativeFolder
            // 
            this.btnDecorativeFolder.Location = new System.Drawing.Point(357, 35);
            this.btnDecorativeFolder.Name = "btnDecorativeFolder";
            this.btnDecorativeFolder.Size = new System.Drawing.Size(75, 23);
            this.btnDecorativeFolder.TabIndex = 4;
            this.btnDecorativeFolder.Text = "Browser...";
            this.btnDecorativeFolder.UseVisualStyleBackColor = true;
            this.btnDecorativeFolder.Click += new System.EventHandler(this.btnDecorativeFolder_Click);
            // 
            // btnEnemyFolder
            // 
            this.btnEnemyFolder.Location = new System.Drawing.Point(357, 79);
            this.btnEnemyFolder.Name = "btnEnemyFolder";
            this.btnEnemyFolder.Size = new System.Drawing.Size(75, 23);
            this.btnEnemyFolder.TabIndex = 5;
            this.btnEnemyFolder.Text = "Browser...";
            this.btnEnemyFolder.UseVisualStyleBackColor = true;
            this.btnEnemyFolder.Click += new System.EventHandler(this.btnEnemyFolder_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(109, 215);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(269, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSpriteFolder
            // 
            this.btnSpriteFolder.Location = new System.Drawing.Point(357, 123);
            this.btnSpriteFolder.Name = "btnSpriteFolder";
            this.btnSpriteFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSpriteFolder.TabIndex = 10;
            this.btnSpriteFolder.Text = "Browser...";
            this.btnSpriteFolder.UseVisualStyleBackColor = true;
            this.btnSpriteFolder.Click += new System.EventHandler(this.btnSpriteFolder_Click);
            // 
            // txtSpriteFolder
            // 
            this.txtSpriteFolder.Location = new System.Drawing.Point(109, 126);
            this.txtSpriteFolder.Name = "txtSpriteFolder";
            this.txtSpriteFolder.Size = new System.Drawing.Size(222, 20);
            this.txtSpriteFolder.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Resource Folder";
            // 
            // txtPlayingTime
            // 
            this.txtPlayingTime.Location = new System.Drawing.Point(109, 163);
            this.txtPlayingTime.Name = "txtPlayingTime";
            this.txtPlayingTime.Size = new System.Drawing.Size(75, 20);
            this.txtPlayingTime.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Playing Time";
            // 
            // OptionsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 259);
            this.Controls.Add(this.txtPlayingTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSpriteFolder);
            this.Controls.Add(this.txtSpriteFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnEnemyFolder);
            this.Controls.Add(this.btnDecorativeFolder);
            this.Controls.Add(this.txtEnemyFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDecorativeFolder);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsFrm";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDecorativeFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnemyFolder;
        private System.Windows.Forms.Button btnDecorativeFolder;
        private System.Windows.Forms.Button btnEnemyFolder;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSpriteFolder;
        private System.Windows.Forms.TextBox txtSpriteFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlayingTime;
        private System.Windows.Forms.Label label4;
    }
}