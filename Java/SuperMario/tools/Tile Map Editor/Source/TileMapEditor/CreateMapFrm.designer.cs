namespace TileMapEditor
{
    partial class CreateMapFrm
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateMapFrm));
        	this.label1 = new System.Windows.Forms.Label();
        	this.txtWidth = new System.Windows.Forms.TextBox();
        	this.txtHeight = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.txtTileWidth = new System.Windows.Forms.TextBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.txtTileHeight = new System.Windows.Forms.TextBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.btnOk = new System.Windows.Forms.Button();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(21, 35);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(35, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Width";
        	// 
        	// txtWidth
        	// 
        	this.txtWidth.Location = new System.Drawing.Point(62, 32);
        	this.txtWidth.Name = "txtWidth";
        	this.txtWidth.Size = new System.Drawing.Size(77, 20);
        	this.txtWidth.TabIndex = 1;
        	this.txtWidth.Text = "200";
        	// 
        	// txtHeight
        	// 
        	this.txtHeight.Location = new System.Drawing.Point(62, 76);
        	this.txtHeight.Name = "txtHeight";
        	this.txtHeight.Size = new System.Drawing.Size(77, 20);
        	this.txtHeight.TabIndex = 3;
        	this.txtHeight.Text = "15";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(21, 79);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(38, 13);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "Height";
        	// 
        	// txtTileWidth
        	// 
        	this.txtTileWidth.Location = new System.Drawing.Point(224, 32);
        	this.txtTileWidth.Name = "txtTileWidth";
        	this.txtTileWidth.Size = new System.Drawing.Size(77, 20);
        	this.txtTileWidth.TabIndex = 5;
        	this.txtTileWidth.Text = "16";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(166, 35);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(52, 13);
        	this.label3.TabIndex = 4;
        	this.label3.Text = "TileWidth";
        	// 
        	// txtTileHeight
        	// 
        	this.txtTileHeight.Location = new System.Drawing.Point(224, 76);
        	this.txtTileHeight.Name = "txtTileHeight";
        	this.txtTileHeight.Size = new System.Drawing.Size(77, 20);
        	this.txtTileHeight.TabIndex = 7;
        	this.txtTileHeight.Text = "16";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(166, 79);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(55, 13);
        	this.label4.TabIndex = 6;
        	this.label4.Text = "TileHeight";
        	// 
        	// btnOk
        	// 
        	this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.btnOk.Location = new System.Drawing.Point(77, 131);
        	this.btnOk.Name = "btnOk";
        	this.btnOk.Size = new System.Drawing.Size(75, 23);
        	this.btnOk.TabIndex = 8;
        	this.btnOk.Text = "Ok";
        	this.btnOk.UseVisualStyleBackColor = true;
        	this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.btnCancel.Location = new System.Drawing.Point(186, 131);
        	this.btnCancel.Name = "btnCancel";
        	this.btnCancel.Size = new System.Drawing.Size(75, 23);
        	this.btnCancel.TabIndex = 9;
        	this.btnCancel.Text = "Cancel";
        	this.btnCancel.UseVisualStyleBackColor = true;
        	this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        	// 
        	// CreateMapFrm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(324, 179);
        	this.Controls.Add(this.btnCancel);
        	this.Controls.Add(this.btnOk);
        	this.Controls.Add(this.txtTileHeight);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.txtTileWidth);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.txtHeight);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.txtWidth);
        	this.Controls.Add(this.label1);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "CreateMapFrm";
        	this.Text = "Map Property";
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTileWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTileHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
