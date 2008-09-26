namespace Unikey
{
    partial class FormUnikey
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.radVni = new System.Windows.Forms.RadioButton();
            this.radTelex = new System.Windows.Forms.RadioButton();
            this.chkSwitchKey = new System.Windows.Forms.CheckBox();
            this.chkActivateKey = new System.Windows.Forms.CheckBox();
            this.lblInputMethod = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(23, 248);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(55, 29);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(93, 248);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(55, 29);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(163, 248);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(55, 29);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // radVni
            // 
            this.radVni.Location = new System.Drawing.Point(110, 152);
            this.radVni.Name = "radVni";
            this.radVni.Size = new System.Drawing.Size(50, 20);
            this.radVni.TabIndex = 0;
            this.radVni.Text = "VNI";
            this.radVni.CheckedChanged += new System.EventHandler(this.radVni_CheckedChanged);
            // 
            // radTelex
            // 
            this.radTelex.Location = new System.Drawing.Point(168, 152);
            this.radTelex.Name = "radTelex";
            this.radTelex.Size = new System.Drawing.Size(71, 20);
            this.radTelex.TabIndex = 1;
            this.radTelex.Text = "TELEX";
            this.radTelex.CheckedChanged += new System.EventHandler(this.radTelex_CheckedChanged);
            // 
            // chkSwitchKey
            // 
            this.chkSwitchKey.Location = new System.Drawing.Point(10, 183);
            this.chkSwitchKey.Name = "chkSwitchKey";
            this.chkSwitchKey.Size = new System.Drawing.Size(222, 20);
            this.chkSwitchKey.TabIndex = 2;
            this.chkSwitchKey.Text = "Switch Key: CTRL + SHIFT + S";
            this.chkSwitchKey.CheckStateChanged += new System.EventHandler(this.chkSwitchKey_CheckStateChanged);
            // 
            // chkActivateKey
            // 
            this.chkActivateKey.Location = new System.Drawing.Point(10, 212);
            this.chkActivateKey.Name = "chkActivateKey";
            this.chkActivateKey.Size = new System.Drawing.Size(222, 20);
            this.chkActivateKey.TabIndex = 3;
            this.chkActivateKey.Text = "Activate Key: CTRL + SHIFT + U";
            this.chkActivateKey.CheckStateChanged += new System.EventHandler(this.chkActivateKey_CheckStateChanged);
            // 
            // lblInputMethod
            // 
            this.lblInputMethod.Location = new System.Drawing.Point(10, 154);
            this.lblInputMethod.Name = "lblInputMethod";
            this.lblInputMethod.Size = new System.Drawing.Size(89, 20);
            this.lblInputMethod.Text = "Input Method:";
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(24, 1);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(186, 150);
            // 
            // FormUnikey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblInputMethod);
            this.Controls.Add(this.chkActivateKey);
            this.Controls.Add(this.chkSwitchKey);
            this.Controls.Add(this.radTelex);
            this.Controls.Add(this.radVni);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "FormUnikey";
            this.Text = "Unikey";
            this.Load += new System.EventHandler(this.FormUnikey_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton radVni;
        private System.Windows.Forms.RadioButton radTelex;
        private System.Windows.Forms.CheckBox chkSwitchKey;
        private System.Windows.Forms.CheckBox chkActivateKey;
        private System.Windows.Forms.Label lblInputMethod;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}

