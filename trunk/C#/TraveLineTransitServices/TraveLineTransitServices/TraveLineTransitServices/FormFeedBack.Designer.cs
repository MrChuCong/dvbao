namespace TraveLineTransitServices
{
    partial class FormFeedBack
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
            System.Windows.Forms.Label feedBackIDLabel;
            System.Windows.Forms.Label dateOfFeedBackLabel;
            System.Windows.Forms.Label representativeNameLabel;
            System.Windows.Forms.Label customerNameLabel;
            System.Windows.Forms.Label departmentNameLabel;
            System.Windows.Forms.Label feedBackSourceLabel;
            System.Windows.Forms.Label feedBackTypeLabel;
            System.Windows.Forms.Label feedBackCategoryLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label incidentDateLabel;
            System.Windows.Forms.Label incidentPlaceLabel;
            System.Windows.Forms.Label busStopLabel;
            System.Windows.Forms.Label vehicleNumberLabel;
            System.Windows.Forms.Label assignerNameLabel;
            System.Windows.Forms.Label assigneeNameLabel;
            this.dataSet = new TraveLineTransitServices.DataSet();
            this.feedBackDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.feedBackDataTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.FeedBackDataTableAdapter();
            this.dtDateOfFeedBack = new System.Windows.Forms.DateTimePicker();
            this.txtRepresentativeName = new System.Windows.Forms.TextBox();
            this.cboCustomerName = new System.Windows.Forms.ComboBox();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboDepartmentName = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboFeedBackSource = new System.Windows.Forms.ComboBox();
            this.cboFeedBackType = new System.Windows.Forms.ComboBox();
            this.cboFeedBackCategory = new System.Windows.Forms.ComboBox();
            this.pnBackground = new DevComponents.DotNetBar.PanelEx();
            this.txtAssigneeName = new System.Windows.Forms.TextBox();
            this.txtAssignerName = new System.Windows.Forms.TextBox();
            this.txtVehicleNumber = new System.Windows.Forms.TextBox();
            this.txtBusStop = new System.Windows.Forms.TextBox();
            this.txtIncidentPlace = new System.Windows.Forms.TextBox();
            this.dtIncidentDate = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtFeedBackID = new System.Windows.Forms.TextBox();
            this.departmentTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.DepartmentTableAdapter();
            this.customerTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.CustomerTableAdapter();
            this.feedBackTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.FeedBackTableAdapter();
            this.investigationDetailsTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.InvestigationDetailsTableAdapter();
            this.correctiveActionsTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.CorrectiveActionsTableAdapter();
            feedBackIDLabel = new System.Windows.Forms.Label();
            dateOfFeedBackLabel = new System.Windows.Forms.Label();
            representativeNameLabel = new System.Windows.Forms.Label();
            customerNameLabel = new System.Windows.Forms.Label();
            departmentNameLabel = new System.Windows.Forms.Label();
            feedBackSourceLabel = new System.Windows.Forms.Label();
            feedBackTypeLabel = new System.Windows.Forms.Label();
            feedBackCategoryLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            incidentDateLabel = new System.Windows.Forms.Label();
            incidentPlaceLabel = new System.Windows.Forms.Label();
            busStopLabel = new System.Windows.Forms.Label();
            vehicleNumberLabel = new System.Windows.Forms.Label();
            assignerNameLabel = new System.Windows.Forms.Label();
            assigneeNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedBackDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            this.pnBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // feedBackIDLabel
            // 
            feedBackIDLabel.AutoSize = true;
            feedBackIDLabel.Location = new System.Drawing.Point(30, 32);
            feedBackIDLabel.Name = "feedBackIDLabel";
            feedBackIDLabel.Size = new System.Drawing.Size(95, 19);
            feedBackIDLabel.TabIndex = 0;
            feedBackIDLabel.Text = "FeedBack ID:";
            // 
            // dateOfFeedBackLabel
            // 
            dateOfFeedBackLabel.AutoSize = true;
            dateOfFeedBackLabel.Location = new System.Drawing.Point(400, 32);
            dateOfFeedBackLabel.Name = "dateOfFeedBackLabel";
            dateOfFeedBackLabel.Size = new System.Drawing.Size(108, 19);
            dateOfFeedBackLabel.TabIndex = 2;
            dateOfFeedBackLabel.Text = "FeedBack Date:";
            // 
            // representativeNameLabel
            // 
            representativeNameLabel.AutoSize = true;
            representativeNameLabel.Location = new System.Drawing.Point(30, 75);
            representativeNameLabel.Name = "representativeNameLabel";
            representativeNameLabel.Size = new System.Drawing.Size(101, 19);
            representativeNameLabel.TabIndex = 4;
            representativeNameLabel.Text = "Representative:";
            // 
            // customerNameLabel
            // 
            customerNameLabel.AutoSize = true;
            customerNameLabel.Location = new System.Drawing.Point(400, 75);
            customerNameLabel.Name = "customerNameLabel";
            customerNameLabel.Size = new System.Drawing.Size(71, 19);
            customerNameLabel.TabIndex = 6;
            customerNameLabel.Text = "Customer:";
            // 
            // departmentNameLabel
            // 
            departmentNameLabel.AutoSize = true;
            departmentNameLabel.Location = new System.Drawing.Point(30, 118);
            departmentNameLabel.Name = "departmentNameLabel";
            departmentNameLabel.Size = new System.Drawing.Size(83, 19);
            departmentNameLabel.TabIndex = 8;
            departmentNameLabel.Text = "Department:";
            // 
            // feedBackSourceLabel
            // 
            feedBackSourceLabel.AutoSize = true;
            feedBackSourceLabel.Location = new System.Drawing.Point(400, 118);
            feedBackSourceLabel.Name = "feedBackSourceLabel";
            feedBackSourceLabel.Size = new System.Drawing.Size(122, 19);
            feedBackSourceLabel.TabIndex = 10;
            feedBackSourceLabel.Text = "FeedBack Source:";
            // 
            // feedBackTypeLabel
            // 
            feedBackTypeLabel.AutoSize = true;
            feedBackTypeLabel.Location = new System.Drawing.Point(30, 161);
            feedBackTypeLabel.Name = "feedBackTypeLabel";
            feedBackTypeLabel.Size = new System.Drawing.Size(110, 19);
            feedBackTypeLabel.TabIndex = 12;
            feedBackTypeLabel.Text = "FeedBack Type:";
            // 
            // feedBackCategoryLabel
            // 
            feedBackCategoryLabel.AutoSize = true;
            feedBackCategoryLabel.Location = new System.Drawing.Point(400, 161);
            feedBackCategoryLabel.Name = "feedBackCategoryLabel";
            feedBackCategoryLabel.Size = new System.Drawing.Size(135, 19);
            feedBackCategoryLabel.TabIndex = 14;
            feedBackCategoryLabel.Text = "FeedBack Category:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(30, 247);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(81, 19);
            descriptionLabel.TabIndex = 20;
            descriptionLabel.Text = "Description:";
            // 
            // incidentDateLabel
            // 
            incidentDateLabel.AutoSize = true;
            incidentDateLabel.Location = new System.Drawing.Point(30, 380);
            incidentDateLabel.Name = "incidentDateLabel";
            incidentDateLabel.Size = new System.Drawing.Size(93, 19);
            incidentDateLabel.TabIndex = 22;
            incidentDateLabel.Text = "Incident Date:";
            // 
            // incidentPlaceLabel
            // 
            incidentPlaceLabel.AutoSize = true;
            incidentPlaceLabel.Location = new System.Drawing.Point(400, 380);
            incidentPlaceLabel.Name = "incidentPlaceLabel";
            incidentPlaceLabel.Size = new System.Drawing.Size(97, 19);
            incidentPlaceLabel.TabIndex = 24;
            incidentPlaceLabel.Text = "Incident Place:";
            // 
            // busStopLabel
            // 
            busStopLabel.AutoSize = true;
            busStopLabel.Location = new System.Drawing.Point(30, 424);
            busStopLabel.Name = "busStopLabel";
            busStopLabel.Size = new System.Drawing.Size(68, 19);
            busStopLabel.TabIndex = 26;
            busStopLabel.Text = "Bus Stop:";
            // 
            // vehicleNumberLabel
            // 
            vehicleNumberLabel.AutoSize = true;
            vehicleNumberLabel.Location = new System.Drawing.Point(400, 424);
            vehicleNumberLabel.Name = "vehicleNumberLabel";
            vehicleNumberLabel.Size = new System.Drawing.Size(111, 19);
            vehicleNumberLabel.TabIndex = 28;
            vehicleNumberLabel.Text = "Vehicle Number:";
            // 
            // assignerNameLabel
            // 
            assignerNameLabel.AutoSize = true;
            assignerNameLabel.Location = new System.Drawing.Point(30, 204);
            assignerNameLabel.Name = "assignerNameLabel";
            assignerNameLabel.Size = new System.Drawing.Size(64, 19);
            assignerNameLabel.TabIndex = 16;
            assignerNameLabel.Text = "Assigner:";
            // 
            // assigneeNameLabel
            // 
            assigneeNameLabel.AutoSize = true;
            assigneeNameLabel.Location = new System.Drawing.Point(400, 204);
            assigneeNameLabel.Name = "assigneeNameLabel";
            assigneeNameLabel.Size = new System.Drawing.Size(66, 19);
            assigneeNameLabel.TabIndex = 18;
            assigneeNameLabel.Text = "Assignee:";
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // feedBackDataBindingSource
            // 
            this.feedBackDataBindingSource.DataMember = "FeedBackData";
            this.feedBackDataBindingSource.DataSource = this.dataSet;
            // 
            // feedBackDataTableAdapter
            // 
            this.feedBackDataTableAdapter.ClearBeforeFill = true;
            // 
            // dtDateOfFeedBack
            // 
            this.dtDateOfFeedBack.CustomFormat = "dd/MM/yyyy";
            this.dtDateOfFeedBack.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.feedBackDataBindingSource, "DateOfFeedBack", true));
            this.dtDateOfFeedBack.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOfFeedBack.Location = new System.Drawing.Point(553, 28);
            this.dtDateOfFeedBack.Name = "dtDateOfFeedBack";
            this.dtDateOfFeedBack.Size = new System.Drawing.Size(182, 26);
            this.dtDateOfFeedBack.TabIndex = 3;
            // 
            // txtRepresentativeName
            // 
            this.txtRepresentativeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtRepresentativeName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "RepresentativeName", true));
            this.txtRepresentativeName.Location = new System.Drawing.Point(156, 71);
            this.txtRepresentativeName.Name = "txtRepresentativeName";
            this.txtRepresentativeName.ReadOnly = true;
            this.txtRepresentativeName.Size = new System.Drawing.Size(182, 26);
            this.txtRepresentativeName.TabIndex = 5;
            // 
            // cboCustomerName
            // 
            this.cboCustomerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "CustomerName", true));
            this.cboCustomerName.DataSource = this.customerBindingSource;
            this.cboCustomerName.DisplayMember = "CustomerName";
            this.cboCustomerName.FormattingEnabled = true;
            this.cboCustomerName.Location = new System.Drawing.Point(552, 71);
            this.cboCustomerName.Name = "cboCustomerName";
            this.cboCustomerName.Size = new System.Drawing.Size(182, 27);
            this.cboCustomerName.TabIndex = 7;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "Customer";
            this.customerBindingSource.DataSource = this.dataSet;
            // 
            // cboDepartmentName
            // 
            this.cboDepartmentName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "DepartmentName", true));
            this.cboDepartmentName.DataSource = this.departmentBindingSource;
            this.cboDepartmentName.DisplayMember = "DepartmentName";
            this.cboDepartmentName.FormattingEnabled = true;
            this.cboDepartmentName.Location = new System.Drawing.Point(156, 113);
            this.cboDepartmentName.Name = "cboDepartmentName";
            this.cboDepartmentName.Size = new System.Drawing.Size(182, 27);
            this.cboDepartmentName.TabIndex = 9;
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "Department";
            this.departmentBindingSource.DataSource = this.dataSet;
            // 
            // cboFeedBackSource
            // 
            this.cboFeedBackSource.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "FeedBackSource", true));
            this.cboFeedBackSource.FormattingEnabled = true;
            this.cboFeedBackSource.Items.AddRange(new object[] {
            "Verbal",
            "Written",
            "Media"});
            this.cboFeedBackSource.Location = new System.Drawing.Point(552, 113);
            this.cboFeedBackSource.Name = "cboFeedBackSource";
            this.cboFeedBackSource.Size = new System.Drawing.Size(182, 27);
            this.cboFeedBackSource.TabIndex = 11;
            // 
            // cboFeedBackType
            // 
            this.cboFeedBackType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "FeedBackType", true));
            this.cboFeedBackType.FormattingEnabled = true;
            this.cboFeedBackType.Items.AddRange(new object[] {
            "Complaint",
            "Commendation",
            "Suggestion"});
            this.cboFeedBackType.Location = new System.Drawing.Point(156, 156);
            this.cboFeedBackType.Name = "cboFeedBackType";
            this.cboFeedBackType.Size = new System.Drawing.Size(182, 27);
            this.cboFeedBackType.TabIndex = 13;
            // 
            // cboFeedBackCategory
            // 
            this.cboFeedBackCategory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "FeedBackCategory", true));
            this.cboFeedBackCategory.FormattingEnabled = true;
            this.cboFeedBackCategory.Items.AddRange(new object[] {
            "Driving Behavior",
            "Operational Shortcoming",
            "Vehicle Condition"});
            this.cboFeedBackCategory.Location = new System.Drawing.Point(552, 156);
            this.cboFeedBackCategory.Name = "cboFeedBackCategory";
            this.cboFeedBackCategory.Size = new System.Drawing.Size(182, 27);
            this.cboFeedBackCategory.TabIndex = 15;
            // 
            // pnBackground
            // 
            this.pnBackground.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnBackground.Controls.Add(assigneeNameLabel);
            this.pnBackground.Controls.Add(this.txtAssigneeName);
            this.pnBackground.Controls.Add(assignerNameLabel);
            this.pnBackground.Controls.Add(this.txtAssignerName);
            this.pnBackground.Controls.Add(vehicleNumberLabel);
            this.pnBackground.Controls.Add(this.txtVehicleNumber);
            this.pnBackground.Controls.Add(busStopLabel);
            this.pnBackground.Controls.Add(this.txtBusStop);
            this.pnBackground.Controls.Add(incidentPlaceLabel);
            this.pnBackground.Controls.Add(this.txtIncidentPlace);
            this.pnBackground.Controls.Add(incidentDateLabel);
            this.pnBackground.Controls.Add(this.dtIncidentDate);
            this.pnBackground.Controls.Add(descriptionLabel);
            this.pnBackground.Controls.Add(this.txtDescription);
            this.pnBackground.Controls.Add(this.cboFeedBackCategory);
            this.pnBackground.Controls.Add(feedBackCategoryLabel);
            this.pnBackground.Controls.Add(this.btnCancel);
            this.pnBackground.Controls.Add(this.btnOK);
            this.pnBackground.Controls.Add(this.cboFeedBackSource);
            this.pnBackground.Controls.Add(feedBackSourceLabel);
            this.pnBackground.Controls.Add(this.cboFeedBackType);
            this.pnBackground.Controls.Add(feedBackTypeLabel);
            this.pnBackground.Controls.Add(this.cboDepartmentName);
            this.pnBackground.Controls.Add(departmentNameLabel);
            this.pnBackground.Controls.Add(representativeNameLabel);
            this.pnBackground.Controls.Add(feedBackIDLabel);
            this.pnBackground.Controls.Add(this.cboCustomerName);
            this.pnBackground.Controls.Add(customerNameLabel);
            this.pnBackground.Controls.Add(this.txtFeedBackID);
            this.pnBackground.Controls.Add(dateOfFeedBackLabel);
            this.pnBackground.Controls.Add(this.txtRepresentativeName);
            this.pnBackground.Controls.Add(this.dtDateOfFeedBack);
            this.pnBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackground.Location = new System.Drawing.Point(0, 0);
            this.pnBackground.Name = "pnBackground";
            this.pnBackground.Size = new System.Drawing.Size(774, 552);
            this.pnBackground.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnBackground.Style.BackColor1.Color = System.Drawing.Color.PeachPuff;
            this.pnBackground.Style.BackColor2.Color = System.Drawing.Color.White;
            this.pnBackground.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnBackground.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnBackground.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnBackground.Style.GradientAngle = 90;
            this.pnBackground.TabIndex = 0;
            // 
            // txtAssigneeName
            // 
            this.txtAssigneeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAssigneeName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "AssigneeName", true));
            this.txtAssigneeName.Location = new System.Drawing.Point(552, 200);
            this.txtAssigneeName.Name = "txtAssigneeName";
            this.txtAssigneeName.ReadOnly = true;
            this.txtAssigneeName.Size = new System.Drawing.Size(182, 26);
            this.txtAssigneeName.TabIndex = 19;
            // 
            // txtAssignerName
            // 
            this.txtAssignerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAssignerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "AssignerName", true));
            this.txtAssignerName.Location = new System.Drawing.Point(156, 200);
            this.txtAssignerName.Name = "txtAssignerName";
            this.txtAssignerName.ReadOnly = true;
            this.txtAssignerName.Size = new System.Drawing.Size(182, 26);
            this.txtAssignerName.TabIndex = 17;
            // 
            // txtVehicleNumber
            // 
            this.txtVehicleNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "VehicleNumber", true));
            this.txtVehicleNumber.Location = new System.Drawing.Point(552, 420);
            this.txtVehicleNumber.Name = "txtVehicleNumber";
            this.txtVehicleNumber.Size = new System.Drawing.Size(182, 26);
            this.txtVehicleNumber.TabIndex = 29;
            // 
            // txtBusStop
            // 
            this.txtBusStop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "BusStop", true));
            this.txtBusStop.Location = new System.Drawing.Point(156, 420);
            this.txtBusStop.Name = "txtBusStop";
            this.txtBusStop.Size = new System.Drawing.Size(182, 26);
            this.txtBusStop.TabIndex = 27;
            // 
            // txtIncidentPlace
            // 
            this.txtIncidentPlace.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "IncidentPlace", true));
            this.txtIncidentPlace.Location = new System.Drawing.Point(552, 377);
            this.txtIncidentPlace.Name = "txtIncidentPlace";
            this.txtIncidentPlace.Size = new System.Drawing.Size(182, 26);
            this.txtIncidentPlace.TabIndex = 25;
            // 
            // dtIncidentDate
            // 
            this.dtIncidentDate.CustomFormat = "dd/MM/yyyy";
            this.dtIncidentDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.feedBackDataBindingSource, "IncidentDate", true));
            this.dtIncidentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIncidentDate.Location = new System.Drawing.Point(156, 377);
            this.dtIncidentDate.Name = "dtIncidentDate";
            this.dtIncidentDate.Size = new System.Drawing.Size(182, 26);
            this.dtIncidentDate.TabIndex = 23;
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "Description", true));
            this.txtDescription.Location = new System.Drawing.Point(156, 243);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(578, 115);
            this.txtDescription.TabIndex = 21;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(423, 476);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 48);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnOK.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(231, 476);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(121, 48);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtFeedBackID
            // 
            this.txtFeedBackID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtFeedBackID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.feedBackDataBindingSource, "FeedBackID", true));
            this.txtFeedBackID.Location = new System.Drawing.Point(156, 28);
            this.txtFeedBackID.Name = "txtFeedBackID";
            this.txtFeedBackID.ReadOnly = true;
            this.txtFeedBackID.Size = new System.Drawing.Size(182, 26);
            this.txtFeedBackID.TabIndex = 1;
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // feedBackTableAdapter
            // 
            this.feedBackTableAdapter.ClearBeforeFill = true;
            // 
            // investigationDetailsTableAdapter
            // 
            this.investigationDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // correctiveActionsTableAdapter
            // 
            this.correctiveActionsTableAdapter.ClearBeforeFill = true;
            // 
            // FormFeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(774, 552);
            this.Controls.Add(this.pnBackground);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFeedBack";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeedBack";
            this.Load += new System.EventHandler(this.FormEditFeedBack_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedBackDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            this.pnBackground.ResumeLayout(false);
            this.pnBackground.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataSet dataSet;
        private System.Windows.Forms.BindingSource feedBackDataBindingSource;
        private TraveLineTransitServices.DataSetTableAdapters.FeedBackDataTableAdapter feedBackDataTableAdapter;
        private System.Windows.Forms.DateTimePicker dtDateOfFeedBack;
        private System.Windows.Forms.TextBox txtRepresentativeName;
        private System.Windows.Forms.ComboBox cboCustomerName;
        private System.Windows.Forms.ComboBox cboDepartmentName;
        private System.Windows.Forms.ComboBox cboFeedBackSource;
        private System.Windows.Forms.ComboBox cboFeedBackType;
        private System.Windows.Forms.ComboBox cboFeedBackCategory;
        private DevComponents.DotNetBar.PanelEx pnBackground;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.TextBox txtAssigneeName;
        private System.Windows.Forms.TextBox txtAssignerName;
        private System.Windows.Forms.TextBox txtVehicleNumber;
        private System.Windows.Forms.TextBox txtBusStop;
        private System.Windows.Forms.TextBox txtIncidentPlace;
        private System.Windows.Forms.DateTimePicker dtIncidentDate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtFeedBackID;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private TraveLineTransitServices.DataSetTableAdapters.DepartmentTableAdapter departmentTableAdapter;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private TraveLineTransitServices.DataSetTableAdapters.CustomerTableAdapter customerTableAdapter;
        private TraveLineTransitServices.DataSetTableAdapters.FeedBackTableAdapter feedBackTableAdapter;
        private TraveLineTransitServices.DataSetTableAdapters.InvestigationDetailsTableAdapter investigationDetailsTableAdapter;
        private TraveLineTransitServices.DataSetTableAdapters.CorrectiveActionsTableAdapter correctiveActionsTableAdapter;
    }
}