namespace TraveLineTransitServices
{
    partial class FormCorrectiveActionDetails
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
            this.txtRepresentative = new System.Windows.Forms.TextBox();
            this.lblRepresentative = new System.Windows.Forms.Label();
            this.txtActionDetails = new System.Windows.Forms.TextBox();
            this.lblActionDetails = new System.Windows.Forms.Label();
            this.txtFeedBackID = new System.Windows.Forms.TextBox();
            this.lblFeedBackID = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.lblDateOfClosure = new System.Windows.Forms.Label();
            this.dtDateOfClosure = new System.Windows.Forms.DateTimePicker();
            this.correctiveActionsDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new TraveLineTransitServices.DataSet();
            this.correctiveActionsDataTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.CorrectiveActionsDataTableAdapter();
            this.feedBackTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.FeedBackTableAdapter();
            this.pnBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.correctiveActionsDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBackground
            // 
            this.pnBackground.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnBackground.Controls.Add(this.dtDateOfClosure);
            this.pnBackground.Controls.Add(this.lblDateOfClosure);
            this.pnBackground.Controls.Add(this.txtRepresentative);
            this.pnBackground.Controls.Add(this.lblRepresentative);
            this.pnBackground.Controls.Add(this.txtActionDetails);
            this.pnBackground.Controls.Add(this.lblActionDetails);
            this.pnBackground.Controls.Add(this.txtFeedBackID);
            this.pnBackground.Controls.Add(this.lblFeedBackID);
            this.pnBackground.Controls.Add(this.btnCancel);
            this.pnBackground.Controls.Add(this.btnOK);
            this.pnBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackground.Location = new System.Drawing.Point(0, 0);
            this.pnBackground.Name = "pnBackground";
            this.pnBackground.Size = new System.Drawing.Size(389, 376);
            this.pnBackground.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnBackground.Style.BackColor1.Color = System.Drawing.Color.PeachPuff;
            this.pnBackground.Style.BackColor2.Color = System.Drawing.Color.White;
            this.pnBackground.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnBackground.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnBackground.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnBackground.Style.GradientAngle = 90;
            this.pnBackground.TabIndex = 0;
            // 
            // txtRepresentative
            // 
            this.txtRepresentative.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRepresentative.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.correctiveActionsDataBindingSource, "RepresentativeName", true));
            this.txtRepresentative.Location = new System.Drawing.Point(146, 255);
            this.txtRepresentative.Name = "txtRepresentative";
            this.txtRepresentative.ReadOnly = true;
            this.txtRepresentative.Size = new System.Drawing.Size(219, 26);
            this.txtRepresentative.TabIndex = 7;
            // 
            // lblRepresentative
            // 
            this.lblRepresentative.AutoSize = true;
            this.lblRepresentative.Location = new System.Drawing.Point(18, 259);
            this.lblRepresentative.Name = "lblRepresentative";
            this.lblRepresentative.Size = new System.Drawing.Size(101, 19);
            this.lblRepresentative.TabIndex = 6;
            this.lblRepresentative.Text = "Representative:";
            // 
            // txtActionDetails
            // 
            this.txtActionDetails.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.correctiveActionsDataBindingSource, "ActionDetails", true));
            this.txtActionDetails.Location = new System.Drawing.Point(146, 118);
            this.txtActionDetails.Multiline = true;
            this.txtActionDetails.Name = "txtActionDetails";
            this.txtActionDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtActionDetails.Size = new System.Drawing.Size(219, 115);
            this.txtActionDetails.TabIndex = 5;
            // 
            // lblActionDetails
            // 
            this.lblActionDetails.AutoSize = true;
            this.lblActionDetails.Location = new System.Drawing.Point(18, 122);
            this.lblActionDetails.Name = "lblActionDetails";
            this.lblActionDetails.Size = new System.Drawing.Size(97, 19);
            this.lblActionDetails.TabIndex = 4;
            this.lblActionDetails.Text = "Action Details:";
            // 
            // txtFeedBackID
            // 
            this.txtFeedBackID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFeedBackID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.correctiveActionsDataBindingSource, "FeedBackID", true));
            this.txtFeedBackID.Location = new System.Drawing.Point(146, 22);
            this.txtFeedBackID.Name = "txtFeedBackID";
            this.txtFeedBackID.ReadOnly = true;
            this.txtFeedBackID.Size = new System.Drawing.Size(219, 26);
            this.txtFeedBackID.TabIndex = 1;
            // 
            // lblFeedBackID
            // 
            this.lblFeedBackID.AutoSize = true;
            this.lblFeedBackID.Location = new System.Drawing.Point(18, 26);
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
            this.btnCancel.Location = new System.Drawing.Point(205, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 48);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(62, 306);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(121, 48);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblDateOfClosure
            // 
            this.lblDateOfClosure.AutoSize = true;
            this.lblDateOfClosure.Location = new System.Drawing.Point(18, 74);
            this.lblDateOfClosure.Name = "lblDateOfClosure";
            this.lblDateOfClosure.Size = new System.Drawing.Size(112, 19);
            this.lblDateOfClosure.TabIndex = 2;
            this.lblDateOfClosure.Text = "Date Of Closure:";
            // 
            // dtDateOfClosure
            // 
            this.dtDateOfClosure.CustomFormat = "dd/MM/yyyy";
            this.dtDateOfClosure.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.correctiveActionsDataBindingSource, "DateOfClosure", true));
            this.dtDateOfClosure.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfClosure.Location = new System.Drawing.Point(146, 70);
            this.dtDateOfClosure.Name = "dtDateOfClosure";
            this.dtDateOfClosure.Size = new System.Drawing.Size(219, 26);
            this.dtDateOfClosure.TabIndex = 3;
            // 
            // correctiveActionsDataBindingSource
            // 
            this.correctiveActionsDataBindingSource.DataMember = "CorrectiveActionsData";
            this.correctiveActionsDataBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // correctiveActionsDataTableAdapter
            // 
            this.correctiveActionsDataTableAdapter.ClearBeforeFill = true;
            // 
            // feedBackTableAdapter
            // 
            this.feedBackTableAdapter.ClearBeforeFill = true;
            // 
            // FormCorrectiveActionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(389, 376);
            this.Controls.Add(this.pnBackground);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCorrectiveActionDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corrective Action Details";
            this.Load += new System.EventHandler(this.FormCorrectiveActionDetails_Load);
            this.pnBackground.ResumeLayout(false);
            this.pnBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.correctiveActionsDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnBackground;
        private System.Windows.Forms.Label lblRepresentative;
        private System.Windows.Forms.TextBox txtActionDetails;
        private System.Windows.Forms.Label lblActionDetails;
        private System.Windows.Forms.TextBox txtFeedBackID;
        private System.Windows.Forms.Label lblFeedBackID;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.TextBox txtRepresentative;
        private System.Windows.Forms.BindingSource correctiveActionsDataBindingSource;
        private DataSet dataSet;
        private TraveLineTransitServices.DataSetTableAdapters.CorrectiveActionsDataTableAdapter correctiveActionsDataTableAdapter;
        private TraveLineTransitServices.DataSetTableAdapters.FeedBackTableAdapter feedBackTableAdapter;
        private System.Windows.Forms.DateTimePicker dtDateOfClosure;
        private System.Windows.Forms.Label lblDateOfClosure;
    }
}