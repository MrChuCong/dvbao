namespace TraveLineTransitServices
{
    partial class FormTraveLineTransitServices
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
            this.mnApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLogIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnFeedBack = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLogCustomerFeedBack = new System.Windows.Forms.ToolStripMenuItem();
            this.mnViewAllFeedBacks = new System.Windows.Forms.ToolStripMenuItem();
            this.mnViewAllComplaints = new System.Windows.Forms.ToolStripMenuItem();
            this.mnReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPendingComplaintReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnFeedBackInvestigationReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHelpContents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnServicesDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Silver;
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnApplication,
            this.mnFeedBack,
            this.mnReports,
            this.mnHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(756, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnApplication
            // 
            this.mnApplication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnLogIn,
            this.mnLogOut,
            this.toolStripSeparator1,
            this.mnExit});
            this.mnApplication.Name = "mnApplication";
            this.mnApplication.Size = new System.Drawing.Size(92, 20);
            this.mnApplication.Text = "&Application";
            // 
            // mnLogIn
            // 
            this.mnLogIn.Name = "mnLogIn";
            this.mnLogIn.Size = new System.Drawing.Size(163, 22);
            this.mnLogIn.Text = "Log &In...";
            this.mnLogIn.Click += new System.EventHandler(this.mnLogIn_Click);
            // 
            // mnLogOut
            // 
            this.mnLogOut.Name = "mnLogOut";
            this.mnLogOut.Size = new System.Drawing.Size(163, 22);
            this.mnLogOut.Text = "Log &Out";
            this.mnLogOut.Click += new System.EventHandler(this.mnLogOut_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnExit.Size = new System.Drawing.Size(163, 22);
            this.mnExit.Text = "E&xit";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // mnFeedBack
            // 
            this.mnFeedBack.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnLogCustomerFeedBack,
            this.mnViewAllFeedBacks,
            this.mnViewAllComplaints});
            this.mnFeedBack.Name = "mnFeedBack";
            this.mnFeedBack.Size = new System.Drawing.Size(80, 20);
            this.mnFeedBack.Text = "&FeedBack";
            // 
            // mnLogCustomerFeedBack
            // 
            this.mnLogCustomerFeedBack.Name = "mnLogCustomerFeedBack";
            this.mnLogCustomerFeedBack.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnLogCustomerFeedBack.Size = new System.Drawing.Size(303, 22);
            this.mnLogCustomerFeedBack.Text = "&Log Customer FeedBack...";
            this.mnLogCustomerFeedBack.Click += new System.EventHandler(this.mnLogCustomerFeedBack_Click);
            // 
            // mnViewAllFeedBacks
            // 
            this.mnViewAllFeedBacks.Name = "mnViewAllFeedBacks";
            this.mnViewAllFeedBacks.Size = new System.Drawing.Size(303, 22);
            this.mnViewAllFeedBacks.Text = "View All &FeedBacks...";
            this.mnViewAllFeedBacks.Click += new System.EventHandler(this.mnViewAllFeedBacks_Click);
            // 
            // mnViewAllComplaints
            // 
            this.mnViewAllComplaints.Name = "mnViewAllComplaints";
            this.mnViewAllComplaints.Size = new System.Drawing.Size(303, 22);
            this.mnViewAllComplaints.Text = "View All &Complaints...";
            this.mnViewAllComplaints.Click += new System.EventHandler(this.mnViewAllComplaints_Click);
            // 
            // mnReports
            // 
            this.mnReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnPendingComplaintReports,
            this.mnFeedBackInvestigationReports});
            this.mnReports.Name = "mnReports";
            this.mnReports.Size = new System.Drawing.Size(72, 20);
            this.mnReports.Text = "&Reports";
            // 
            // mnPendingComplaintReports
            // 
            this.mnPendingComplaintReports.Name = "mnPendingComplaintReports";
            this.mnPendingComplaintReports.Size = new System.Drawing.Size(307, 22);
            this.mnPendingComplaintReports.Text = "Pending &Complaint Reports...";
            this.mnPendingComplaintReports.Click += new System.EventHandler(this.mnPendingComplaintReports_Click);
            // 
            // mnFeedBackInvestigationReports
            // 
            this.mnFeedBackInvestigationReports.Name = "mnFeedBackInvestigationReports";
            this.mnFeedBackInvestigationReports.Size = new System.Drawing.Size(307, 22);
            this.mnFeedBackInvestigationReports.Text = "FeedBack &Investigation Reports...";
            this.mnFeedBackInvestigationReports.Click += new System.EventHandler(this.mnFeedBackInvestigationReports_Click);
            // 
            // mnHelp
            // 
            this.mnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnHelpContents,
            this.mnServicesDetails,
            this.toolStripSeparator2,
            this.mnAbout});
            this.mnHelp.Name = "mnHelp";
            this.mnHelp.Size = new System.Drawing.Size(48, 20);
            this.mnHelp.Text = "&Help";
            // 
            // mnHelpContents
            // 
            this.mnHelpContents.Name = "mnHelpContents";
            this.mnHelpContents.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnHelpContents.Size = new System.Drawing.Size(304, 22);
            this.mnHelpContents.Text = "Help &Contents";
            this.mnHelpContents.Click += new System.EventHandler(this.mnHelpContents_Click);
            // 
            // mnServicesDetails
            // 
            this.mnServicesDetails.Name = "mnServicesDetails";
            this.mnServicesDetails.Size = new System.Drawing.Size(304, 22);
            this.mnServicesDetails.Text = "&Services Details...";
            this.mnServicesDetails.Click += new System.EventHandler(this.mnServicesDetails_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(301, 6);
            // 
            // mnAbout
            // 
            this.mnAbout.Name = "mnAbout";
            this.mnAbout.Size = new System.Drawing.Size(304, 22);
            this.mnAbout.Text = "&About TraveLine Transit Services";
            this.mnAbout.Click += new System.EventHandler(this.mnAbout_Click);
            // 
            // helpProvider
            // 
            this.helpProvider.HelpNamespace = "Help.chm";
            // 
            // FormTraveLineTransitServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 417);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTraveLineTransitServices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraveLine Transit Services";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormTraveLineTransitServices_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnApplication;
        private System.Windows.Forms.ToolStripMenuItem mnLogIn;
        private System.Windows.Forms.ToolStripMenuItem mnLogOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.ToolStripMenuItem mnFeedBack;
        private System.Windows.Forms.ToolStripMenuItem mnLogCustomerFeedBack;
        private System.Windows.Forms.ToolStripMenuItem mnViewAllFeedBacks;
        private System.Windows.Forms.ToolStripMenuItem mnViewAllComplaints;
        private System.Windows.Forms.ToolStripMenuItem mnReports;
        private System.Windows.Forms.ToolStripMenuItem mnPendingComplaintReports;
        private System.Windows.Forms.ToolStripMenuItem mnFeedBackInvestigationReports;
        private System.Windows.Forms.ToolStripMenuItem mnHelp;
        private System.Windows.Forms.ToolStripMenuItem mnHelpContents;
        private System.Windows.Forms.ToolStripMenuItem mnServicesDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnAbout;
        private System.Windows.Forms.HelpProvider helpProvider;
    }
}

