namespace TraveLineTransitServices
{
    partial class FormInvestigationDetails
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
            this.components = new System.ComponentModel.Container();
            this.pnBackground = new DevComponents.DotNetBar.PanelEx();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.investigationDetailsDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new TraveLineTransitServices.DataSet();
            this.lblDetails = new System.Windows.Forms.Label();
            this.dtDateOfCompletion = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfCompletion = new System.Windows.Forms.Label();
            this.cboDriver = new System.Windows.Forms.ComboBox();
            this.driverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDriver = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.cboValidity = new System.Windows.Forms.ComboBox();
            this.lblValidity = new System.Windows.Forms.Label();
            this.txtFeedBackID = new System.Windows.Forms.TextBox();
            this.lblFeedBackID = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.driverTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.DriverTableAdapter();
            this.investigationDetailsDataTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.InvestigationDetailsDataTableAdapter();
            this.feedBackTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.FeedBackTableAdapter();
            this.pnBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investigationDetailsDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBackground
            // 
            this.pnBackground.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnBackground.Controls.Add(this.txtDetails);
            this.pnBackground.Controls.Add(this.lblDetails);
            this.pnBackground.Controls.Add(this.dtDateOfCompletion);
            this.pnBackground.Controls.Add(this.lblDateOfCompletion);
            this.pnBackground.Controls.Add(this.cboDriver);
            this.pnBackground.Controls.Add(this.lblDriver);
            this.pnBackground.Controls.Add(this.txtReason);
            this.pnBackground.Controls.Add(this.lblReason);
            this.pnBackground.Controls.Add(this.cboValidity);
            this.pnBackground.Controls.Add(this.lblValidity);
            this.pnBackground.Controls.Add(this.txtFeedBackID);
            this.pnBackground.Controls.Add(this.lblFeedBackID);
            this.pnBackground.Controls.Add(this.btnCancel);
            this.pnBackground.Controls.Add(this.btnOK);
            this.pnBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackground.Location = new System.Drawing.Point(0, 0);
            this.pnBackground.Name = "pnBackground";
            this.pnBackground.Size = new System.Drawing.Size(640, 457);
            this.pnBackground.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnBackground.Style.BackColor1.Color = System.Drawing.Color.PeachPuff;
            this.pnBackground.Style.BackColor2.Color = System.Drawing.Color.White;
            this.pnBackground.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnBackground.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnBackground.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnBackground.Style.GradientAngle = 90;
            this.pnBackground.TabIndex = 0;
            // 
            // txtDetails
            // 
            this.txtDetails.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investigationDetailsDataBindingSource, "Details", true));
            this.txtDetails.Location = new System.Drawing.Point(127, 249);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDetails.Size = new System.Drawing.Size(486, 115);
            this.txtDetails.TabIndex = 11;
            // 
            // investigationDetailsDataBindingSource
            // 
            this.investigationDetailsDataBindingSource.DataMember = "InvestigationDetailsData";
            this.investigationDetailsDataBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(60, 252);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(53, 19);
            this.lblDetails.TabIndex = 10;
            this.lblDetails.Text = "Details:";
            // 
            // dtDateOfCompletion
            // 
            this.dtDateOfCompletion.CustomFormat = "dd/MM/yyyy";
            this.dtDateOfCompletion.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.investigationDetailsDataBindingSource, "DateOfCompletion", true));
            this.dtDateOfCompletion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfCompletion.Location = new System.Drawing.Point(474, 202);
            this.dtDateOfCompletion.Name = "dtDateOfCompletion";
            this.dtDateOfCompletion.Size = new System.Drawing.Size(139, 26);
            this.dtDateOfCompletion.TabIndex = 9;
            // 
            // lblDateOfCompletion
            // 
            this.lblDateOfCompletion.AutoSize = true;
            this.lblDateOfCompletion.Location = new System.Drawing.Point(323, 206);
            this.lblDateOfCompletion.Name = "lblDateOfCompletion";
            this.lblDateOfCompletion.Size = new System.Drawing.Size(135, 19);
            this.lblDateOfCompletion.TabIndex = 8;
            this.lblDateOfCompletion.Text = "Date Of Completion:";
            // 
            // cboDriver
            // 
            this.cboDriver.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investigationDetailsDataBindingSource, "DriverName", true));
            this.cboDriver.DataSource = this.driverBindingSource;
            this.cboDriver.DisplayMember = "DriverName";
            this.cboDriver.FormattingEnabled = true;
            this.cboDriver.Location = new System.Drawing.Point(127, 202);
            this.cboDriver.Name = "cboDriver";
            this.cboDriver.Size = new System.Drawing.Size(139, 27);
            this.cboDriver.TabIndex = 7;
            // 
            // driverBindingSource
            // 
            this.driverBindingSource.DataMember = "Driver";
            this.driverBindingSource.DataSource = this.dataSet;
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(63, 206);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(50, 19);
            this.lblDriver.TabIndex = 6;
            this.lblDriver.Text = "Driver:";
            // 
            // txtReason
            // 
            this.txtReason.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investigationDetailsDataBindingSource, "Reason", true));
            this.txtReason.Location = new System.Drawing.Point(127, 67);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReason.Size = new System.Drawing.Size(486, 115);
            this.txtReason.TabIndex = 5;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(56, 69);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(57, 19);
            this.lblReason.TabIndex = 4;
            this.lblReason.Text = "Reason:";
            // 
            // cboValidity
            // 
            this.cboValidity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investigationDetailsDataBindingSource, "Validity", true));
            this.cboValidity.FormattingEnabled = true;
            this.cboValidity.Items.AddRange(new object[] {
            "TRUE",
            "FALSE"});
            this.cboValidity.Location = new System.Drawing.Point(474, 21);
            this.cboValidity.Name = "cboValidity";
            this.cboValidity.Size = new System.Drawing.Size(139, 27);
            this.cboValidity.TabIndex = 3;
            // 
            // lblValidity
            // 
            this.lblValidity.AutoSize = true;
            this.lblValidity.Location = new System.Drawing.Point(400, 25);
            this.lblValidity.Name = "lblValidity";
            this.lblValidity.Size = new System.Drawing.Size(58, 19);
            this.lblValidity.TabIndex = 2;
            this.lblValidity.Text = "Validity:";
            // 
            // txtFeedBackID
            // 
            this.txtFeedBackID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFeedBackID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.investigationDetailsDataBindingSource, "FeedBackID", true));
            this.txtFeedBackID.Location = new System.Drawing.Point(127, 21);
            this.txtFeedBackID.Name = "txtFeedBackID";
            this.txtFeedBackID.ReadOnly = true;
            this.txtFeedBackID.Size = new System.Drawing.Size(139, 26);
            this.txtFeedBackID.TabIndex = 1;
            // 
            // lblFeedBackID
            // 
            this.lblFeedBackID.AutoSize = true;
            this.lblFeedBackID.Location = new System.Drawing.Point(18, 25);
            this.lblFeedBackID.Name = "lblFeedBackID";
            this.lblFeedBackID.Size = new System.Drawing.Size(95, 19);
            this.lblFeedBackID.TabIndex = 0;
            this.lblFeedBackID.Text = "FeedBack ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(337, 388);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 48);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(182, 388);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(121, 48);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // driverTableAdapter
            // 
            this.driverTableAdapter.ClearBeforeFill = true;
            // 
            // investigationDetailsDataTableAdapter
            // 
            this.investigationDetailsDataTableAdapter.ClearBeforeFill = true;
            // 
            // feedBackTableAdapter
            // 
            this.feedBackTableAdapter.ClearBeforeFill = true;
            // 
            // FormInvestigationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(640, 457);
            this.Controls.Add(this.pnBackground);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInvestigationDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Investigation Details";
            this.Load += new System.EventHandler(this.FormInvestigationDetails_Load);
            this.pnBackground.ResumeLayout(false);
            this.pnBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.investigationDetailsDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnBackground;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.TextBox txtFeedBackID;
        private System.Windows.Forms.Label lblFeedBackID;
        private DataSet dataSet;
        private System.Windows.Forms.Label lblValidity;
        private System.Windows.Forms.ComboBox cboValidity;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.ComboBox cboDriver;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.BindingSource driverBindingSource;
        private TraveLineTransitServices.DataSetTableAdapters.DriverTableAdapter driverTableAdapter;
        private System.Windows.Forms.BindingSource investigationDetailsDataBindingSource;
        private TraveLineTransitServices.DataSetTableAdapters.InvestigationDetailsDataTableAdapter investigationDetailsDataTableAdapter;
        private TraveLineTransitServices.DataSetTableAdapters.FeedBackTableAdapter feedBackTableAdapter;
        private System.Windows.Forms.Label lblDateOfCompletion;
        private System.Windows.Forms.DateTimePicker dtDateOfCompletion;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label lblDetails;
    }
}