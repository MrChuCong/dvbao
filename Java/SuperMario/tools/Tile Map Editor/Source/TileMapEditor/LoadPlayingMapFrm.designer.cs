/*
 * Created by SharpDevelop.
 * User: gameloft
 * Date: 8/27/2008
 * Time: 11:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TileMapEditor
{
	partial class LoadPlayingMapFrm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadPlayingMapFrm));
            this.txtXmlMapPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowserXmlMap = new System.Windows.Forms.Button();
            this.btnBrowserImage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImageFilename = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBinaryFilename = new System.Windows.Forms.TextBox();
            this.btnBinaryFilename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtXmlMapPath
            // 
            this.txtXmlMapPath.Location = new System.Drawing.Point(128, 28);
            this.txtXmlMapPath.Name = "txtXmlMapPath";
            this.txtXmlMapPath.Size = new System.Drawing.Size(181, 20);
            this.txtXmlMapPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Xml Map filename:";
            // 
            // btnBrowserXmlMap
            // 
            this.btnBrowserXmlMap.Location = new System.Drawing.Point(339, 26);
            this.btnBrowserXmlMap.Name = "btnBrowserXmlMap";
            this.btnBrowserXmlMap.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserXmlMap.TabIndex = 2;
            this.btnBrowserXmlMap.Text = "Browser...";
            this.btnBrowserXmlMap.UseVisualStyleBackColor = true;
            this.btnBrowserXmlMap.Click += new System.EventHandler(this.BtnBrowserXmlMapClick);
            // 
            // btnBrowserImage
            // 
            this.btnBrowserImage.Location = new System.Drawing.Point(339, 65);
            this.btnBrowserImage.Name = "btnBrowserImage";
            this.btnBrowserImage.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserImage.TabIndex = 5;
            this.btnBrowserImage.Text = "Browser...";
            this.btnBrowserImage.UseVisualStyleBackColor = true;
            this.btnBrowserImage.Click += new System.EventHandler(this.BtnBrowserImageClick);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(22, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Image filename:";
            // 
            // txtImageFilename
            // 
            this.txtImageFilename.Location = new System.Drawing.Point(128, 67);
            this.txtImageFilename.Name = "txtImageFilename";
            this.txtImageFilename.Size = new System.Drawing.Size(181, 20);
            this.txtImageFilename.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(100, 162);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(245, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(22, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Binary filename:";
            // 
            // txtBinaryFilename
            // 
            this.txtBinaryFilename.Location = new System.Drawing.Point(128, 112);
            this.txtBinaryFilename.Name = "txtBinaryFilename";
            this.txtBinaryFilename.Size = new System.Drawing.Size(181, 20);
            this.txtBinaryFilename.TabIndex = 10;
            // 
            // btnBinaryFilename
            // 
            this.btnBinaryFilename.Location = new System.Drawing.Point(339, 110);
            this.btnBinaryFilename.Name = "btnBinaryFilename";
            this.btnBinaryFilename.Size = new System.Drawing.Size(75, 23);
            this.btnBinaryFilename.TabIndex = 11;
            this.btnBinaryFilename.Text = "Browser...";
            this.btnBinaryFilename.UseVisualStyleBackColor = true;
            this.btnBinaryFilename.Click += new System.EventHandler(this.BtnBinaryFilenameClick);
            // 
            // LoadPlayingMapFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 218);
            this.Controls.Add(this.btnBinaryFilename);
            this.Controls.Add(this.txtBinaryFilename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnBrowserImage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtImageFilename);
            this.Controls.Add(this.btnBrowserXmlMap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXmlMapPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoadPlayingMapFrm";
            this.Text = "Load playing map";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.TextBox txtBinaryFilename;
		private System.Windows.Forms.Button btnBinaryFilename;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtImageFilename;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnBrowserImage;
		private System.Windows.Forms.Button btnBrowserXmlMap;
		private System.Windows.Forms.TextBox txtXmlMapPath;
		private System.Windows.Forms.Label label1;
	}
}
