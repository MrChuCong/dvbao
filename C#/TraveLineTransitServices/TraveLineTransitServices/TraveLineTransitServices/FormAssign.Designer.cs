namespace TraveLineTransitServices
{
    partial class FormAssign
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
            this.dtDateOfAssignment = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfAssignment = new System.Windows.Forms.Label();
            this.cboAssignee = new System.Windows.Forms.ComboBox();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new TraveLineTransitServices.DataSet();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtFeedBackID = new System.Windows.Forms.TextBox();
            this.lblFeedBackID = new System.Windows.Forms.Label();
            this.employeeTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.EmployeeTableAdapter();
            this.complaintTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.ComplaintTableAdapter();
            this.pnBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBackground
            // 
            this.pnBackground.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnBackground.Controls.Add(this.dtDateOfAssignment);
            this.pnBackground.Controls.Add(this.lblDateOfAssignment);
            this.pnBackground.Controls.Add(this.cboAssignee);
            this.pnBackground.Controls.Add(this.btnCancel);
            this.pnBackground.Controls.Add(this.btnOK);
            this.pnBackground.Controls.Add(this.lblPassword);
            this.pnBackground.Controls.Add(this.txtFeedBackID);
            this.pnBackground.Controls.Add(this.lblFeedBackID);
            this.pnBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackground.Location = new System.Drawing.Point(0, 0);
            this.pnBackground.Name = "pnBackground";
            this.pnBackground.Size = new System.Drawing.Size(377, 229);
            this.pnBackground.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnBackground.Style.BackColor1.Color = System.Drawing.Color.PeachPuff;
            this.pnBackground.Style.BackColor2.Color = System.Drawing.Color.White;
            this.pnBackground.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnBackground.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnBackground.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnBackground.Style.GradientAngle = 90;
            this.pnBackground.TabIndex = 0;
            // 
            // dtDateOfAssignment
            // 
            this.dtDateOfAssignment.CustomFormat = "dd/MM/yyyy";
            this.dtDateOfAssignment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfAssignment.Location = new System.Drawing.Point(175, 65);
            this.dtDateOfAssignment.Name = "dtDateOfAssignment";
            this.dtDateOfAssignment.Size = new System.Drawing.Size(175, 26);
            this.dtDateOfAssignment.TabIndex = 3;
            // 
            // lblDateOfAssignment
            // 
            this.lblDateOfAssignment.AutoSize = true;
            this.lblDateOfAssignment.Location = new System.Drawing.Point(24, 69);
            this.lblDateOfAssignment.Name = "lblDateOfAssignment";
            this.lblDateOfAssignment.Size = new System.Drawing.Size(134, 19);
            this.lblDateOfAssignment.TabIndex = 2;
            this.lblDateOfAssignment.Text = "Date Of Assignment:";
            // 
            // cboAssignee
            // 
            this.cboAssignee.DataSource = this.employeeBindingSource;
            this.cboAssignee.DisplayMember = "EmployeeName";
            this.cboAssignee.FormattingEnabled = true;
            this.cboAssignee.Location = new System.Drawing.Point(175, 104);
            this.cboAssignee.Name = "cboAssignee";
            this.cboAssignee.Size = new System.Drawing.Size(175, 27);
            this.cboAssignee.TabIndex = 5;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(199, 155);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 48);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(56, 155);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(121, 48);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(24, 108);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 19);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Assignee:";
            // 
            // txtFeedBackID
            // 
            this.txtFeedBackID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFeedBackID.Location = new System.Drawing.Point(175, 26);
            this.txtFeedBackID.Name = "txtFeedBackID";
            this.txtFeedBackID.ReadOnly = true;
            this.txtFeedBackID.Size = new System.Drawing.Size(175, 26);
            this.txtFeedBackID.TabIndex = 1;
            // 
            // lblFeedBackID
            // 
            this.lblFeedBackID.AutoSize = true;
            this.lblFeedBackID.Location = new System.Drawing.Point(24, 30);
            this.lblFeedBackID.Name = "lblFeedBackID";
            this.lblFeedBackID.Size = new System.Drawing.Size(95, 19);
            this.lblFeedBackID.TabIndex = 0;
            this.lblFeedBackID.Text = "FeedBack ID:";
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // complaintTableAdapter
            // 
            this.complaintTableAdapter.ClearBeforeFill = true;
            // 
            // FormAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(377, 229);
            this.Controls.Add(this.pnBackground);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAssign";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign Complaint";
            this.Load += new System.EventHandler(this.FormAssign_Load);
            this.pnBackground.ResumeLayout(false);
            this.pnBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnBackground;
        private System.Windows.Forms.ComboBox cboAssignee;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtFeedBackID;
        private System.Windows.Forms.Label lblFeedBackID;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private TraveLineTransitServices.DataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private TraveLineTransitServices.DataSetTableAdapters.ComplaintTableAdapter complaintTableAdapter;
        private System.Windows.Forms.DateTimePicker dtDateOfAssignment;
        private System.Windows.Forms.Label lblDateOfAssignment;
    }
}