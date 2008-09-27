namespace TraveLineTransitServices
{
    partial class FormViewAllComplaints
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgFeedBacks = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.pnBackground = new DevComponents.DotNetBar.PanelEx();
            this.btnCorrectiveActionDetails = new DevComponents.DotNetBar.ButtonX();
            this.btnInvestigationDetails = new DevComponents.DotNetBar.ButtonX();
            this.btnAssign = new DevComponents.DotNetBar.ButtonX();
            this.btnDetails = new DevComponents.DotNetBar.ButtonX();
            this.complaintBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new TraveLineTransitServices.DataSet();
            this.complaintTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.ComplaintTableAdapter();
            this.feedBackIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representativeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfFeedBackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assigneeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedBackCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedBackSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedBackTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incidentDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incidentPlaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.busStopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgFeedBacks)).BeginInit();
            this.pnBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.complaintBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFeedBacks
            // 
            this.dgFeedBacks.AllowUserToAddRows = false;
            this.dgFeedBacks.AllowUserToDeleteRows = false;
            this.dgFeedBacks.AutoGenerateColumns = false;
            this.dgFeedBacks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgFeedBacks.BackgroundColor = System.Drawing.Color.White;
            this.dgFeedBacks.ColumnHeadersHeight = 40;
            this.dgFeedBacks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.feedBackIDDataGridViewTextBoxColumn,
            this.customerNameDataGridViewTextBoxColumn,
            this.representativeNameDataGridViewTextBoxColumn,
            this.dateOfFeedBackDataGridViewTextBoxColumn,
            this.assigneeNameDataGridViewTextBoxColumn,
            this.departmentNameDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.feedBackCategoryDataGridViewTextBoxColumn,
            this.feedBackSourceDataGridViewTextBoxColumn,
            this.feedBackTypeDataGridViewTextBoxColumn,
            this.incidentDateDataGridViewTextBoxColumn,
            this.incidentPlaceDataGridViewTextBoxColumn,
            this.busStopDataGridViewTextBoxColumn,
            this.vehicleNumberDataGridViewTextBoxColumn,
            this.assignerNameDataGridViewTextBoxColumn});
            this.dgFeedBacks.DataSource = this.complaintBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFeedBacks.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgFeedBacks.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgFeedBacks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgFeedBacks.Location = new System.Drawing.Point(0, 0);
            this.dgFeedBacks.Name = "dgFeedBacks";
            this.dgFeedBacks.ReadOnly = true;
            this.dgFeedBacks.RowHeadersVisible = false;
            this.dgFeedBacks.RowHeadersWidth = 40;
            this.dgFeedBacks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFeedBacks.Size = new System.Drawing.Size(754, 398);
            this.dgFeedBacks.TabIndex = 0;
            this.dgFeedBacks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFeedBacks_CellDoubleClick);
            // 
            // pnBackground
            // 
            this.pnBackground.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnBackground.Controls.Add(this.btnCorrectiveActionDetails);
            this.pnBackground.Controls.Add(this.btnInvestigationDetails);
            this.pnBackground.Controls.Add(this.btnAssign);
            this.pnBackground.Controls.Add(this.btnDetails);
            this.pnBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackground.Location = new System.Drawing.Point(0, 398);
            this.pnBackground.Name = "pnBackground";
            this.pnBackground.Size = new System.Drawing.Size(754, 84);
            this.pnBackground.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnBackground.Style.BackColor1.Color = System.Drawing.Color.PeachPuff;
            this.pnBackground.Style.BackColor2.Color = System.Drawing.Color.White;
            this.pnBackground.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnBackground.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnBackground.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnBackground.Style.GradientAngle = 90;
            this.pnBackground.TabIndex = 1;
            // 
            // btnCorrectiveActionDetails
            // 
            this.btnCorrectiveActionDetails.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCorrectiveActionDetails.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnCorrectiveActionDetails.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorrectiveActionDetails.Location = new System.Drawing.Point(496, 18);
            this.btnCorrectiveActionDetails.Name = "btnCorrectiveActionDetails";
            this.btnCorrectiveActionDetails.Size = new System.Drawing.Size(246, 48);
            this.btnCorrectiveActionDetails.TabIndex = 3;
            this.btnCorrectiveActionDetails.Text = "Corrective Action Details";
            this.btnCorrectiveActionDetails.Click += new System.EventHandler(this.btnCorrectiveActionDetails_Click);
            // 
            // btnInvestigationDetails
            // 
            this.btnInvestigationDetails.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInvestigationDetails.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnInvestigationDetails.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvestigationDetails.Location = new System.Drawing.Point(240, 18);
            this.btnInvestigationDetails.Name = "btnInvestigationDetails";
            this.btnInvestigationDetails.Size = new System.Drawing.Size(246, 48);
            this.btnInvestigationDetails.TabIndex = 2;
            this.btnInvestigationDetails.Text = "Investigation Details";
            this.btnInvestigationDetails.Click += new System.EventHandler(this.btnInvestigationDetails_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAssign.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnAssign.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(126, 18);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(104, 48);
            this.btnAssign.TabIndex = 1;
            this.btnAssign.Text = "Assign";
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnDetails
            // 
            this.btnDetails.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDetails.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnDetails.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetails.Location = new System.Drawing.Point(12, 18);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(104, 48);
            this.btnDetails.TabIndex = 0;
            this.btnDetails.Text = "Details";
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // complaintBindingSource
            // 
            this.complaintBindingSource.DataMember = "Complaint";
            this.complaintBindingSource.DataSource = this.dataSet;
            this.complaintBindingSource.CurrentChanged += new System.EventHandler(this.complaintBindingSource_CurrentChanged);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // complaintTableAdapter
            // 
            this.complaintTableAdapter.ClearBeforeFill = true;
            // 
            // feedBackIDDataGridViewTextBoxColumn
            // 
            this.feedBackIDDataGridViewTextBoxColumn.DataPropertyName = "FeedBackID";
            this.feedBackIDDataGridViewTextBoxColumn.HeaderText = "FeedBack ID";
            this.feedBackIDDataGridViewTextBoxColumn.Name = "feedBackIDDataGridViewTextBoxColumn";
            this.feedBackIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedBackIDDataGridViewTextBoxColumn.Width = 117;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "Customer";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerNameDataGridViewTextBoxColumn.Width = 93;
            // 
            // representativeNameDataGridViewTextBoxColumn
            // 
            this.representativeNameDataGridViewTextBoxColumn.DataPropertyName = "RepresentativeName";
            this.representativeNameDataGridViewTextBoxColumn.HeaderText = "Representative";
            this.representativeNameDataGridViewTextBoxColumn.Name = "representativeNameDataGridViewTextBoxColumn";
            this.representativeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.representativeNameDataGridViewTextBoxColumn.Width = 123;
            // 
            // dateOfFeedBackDataGridViewTextBoxColumn
            // 
            this.dateOfFeedBackDataGridViewTextBoxColumn.DataPropertyName = "DateOfFeedBack";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.dateOfFeedBackDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dateOfFeedBackDataGridViewTextBoxColumn.HeaderText = "FeedBack Date";
            this.dateOfFeedBackDataGridViewTextBoxColumn.Name = "dateOfFeedBackDataGridViewTextBoxColumn";
            this.dateOfFeedBackDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateOfFeedBackDataGridViewTextBoxColumn.Width = 130;
            // 
            // assigneeNameDataGridViewTextBoxColumn
            // 
            this.assigneeNameDataGridViewTextBoxColumn.DataPropertyName = "AssigneeName";
            this.assigneeNameDataGridViewTextBoxColumn.HeaderText = "Assignee";
            this.assigneeNameDataGridViewTextBoxColumn.Name = "assigneeNameDataGridViewTextBoxColumn";
            this.assigneeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.assigneeNameDataGridViewTextBoxColumn.Width = 88;
            // 
            // departmentNameDataGridViewTextBoxColumn
            // 
            this.departmentNameDataGridViewTextBoxColumn.DataPropertyName = "DepartmentName";
            this.departmentNameDataGridViewTextBoxColumn.HeaderText = "Department";
            this.departmentNameDataGridViewTextBoxColumn.Name = "departmentNameDataGridViewTextBoxColumn";
            this.departmentNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.departmentNameDataGridViewTextBoxColumn.Width = 105;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 71;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 103;
            // 
            // feedBackCategoryDataGridViewTextBoxColumn
            // 
            this.feedBackCategoryDataGridViewTextBoxColumn.DataPropertyName = "FeedBackCategory";
            this.feedBackCategoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.feedBackCategoryDataGridViewTextBoxColumn.Name = "feedBackCategoryDataGridViewTextBoxColumn";
            this.feedBackCategoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedBackCategoryDataGridViewTextBoxColumn.Visible = false;
            this.feedBackCategoryDataGridViewTextBoxColumn.Width = 90;
            // 
            // feedBackSourceDataGridViewTextBoxColumn
            // 
            this.feedBackSourceDataGridViewTextBoxColumn.DataPropertyName = "FeedBackSource";
            this.feedBackSourceDataGridViewTextBoxColumn.HeaderText = "FeedBackSource";
            this.feedBackSourceDataGridViewTextBoxColumn.Name = "feedBackSourceDataGridViewTextBoxColumn";
            this.feedBackSourceDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedBackSourceDataGridViewTextBoxColumn.Visible = false;
            this.feedBackSourceDataGridViewTextBoxColumn.Width = 140;
            // 
            // feedBackTypeDataGridViewTextBoxColumn
            // 
            this.feedBackTypeDataGridViewTextBoxColumn.DataPropertyName = "FeedBackType";
            this.feedBackTypeDataGridViewTextBoxColumn.HeaderText = "FeedBackType";
            this.feedBackTypeDataGridViewTextBoxColumn.Name = "feedBackTypeDataGridViewTextBoxColumn";
            this.feedBackTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedBackTypeDataGridViewTextBoxColumn.Visible = false;
            this.feedBackTypeDataGridViewTextBoxColumn.Width = 128;
            // 
            // incidentDateDataGridViewTextBoxColumn
            // 
            this.incidentDateDataGridViewTextBoxColumn.DataPropertyName = "IncidentDate";
            this.incidentDateDataGridViewTextBoxColumn.HeaderText = "IncidentDate";
            this.incidentDateDataGridViewTextBoxColumn.Name = "incidentDateDataGridViewTextBoxColumn";
            this.incidentDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.incidentDateDataGridViewTextBoxColumn.Visible = false;
            this.incidentDateDataGridViewTextBoxColumn.Width = 111;
            // 
            // incidentPlaceDataGridViewTextBoxColumn
            // 
            this.incidentPlaceDataGridViewTextBoxColumn.DataPropertyName = "IncidentPlace";
            this.incidentPlaceDataGridViewTextBoxColumn.HeaderText = "IncidentPlace";
            this.incidentPlaceDataGridViewTextBoxColumn.Name = "incidentPlaceDataGridViewTextBoxColumn";
            this.incidentPlaceDataGridViewTextBoxColumn.ReadOnly = true;
            this.incidentPlaceDataGridViewTextBoxColumn.Visible = false;
            this.incidentPlaceDataGridViewTextBoxColumn.Width = 115;
            // 
            // busStopDataGridViewTextBoxColumn
            // 
            this.busStopDataGridViewTextBoxColumn.DataPropertyName = "BusStop";
            this.busStopDataGridViewTextBoxColumn.HeaderText = "BusStop";
            this.busStopDataGridViewTextBoxColumn.Name = "busStopDataGridViewTextBoxColumn";
            this.busStopDataGridViewTextBoxColumn.ReadOnly = true;
            this.busStopDataGridViewTextBoxColumn.Visible = false;
            this.busStopDataGridViewTextBoxColumn.Width = 86;
            // 
            // vehicleNumberDataGridViewTextBoxColumn
            // 
            this.vehicleNumberDataGridViewTextBoxColumn.DataPropertyName = "VehicleNumber";
            this.vehicleNumberDataGridViewTextBoxColumn.HeaderText = "VehicleNumber";
            this.vehicleNumberDataGridViewTextBoxColumn.Name = "vehicleNumberDataGridViewTextBoxColumn";
            this.vehicleNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.vehicleNumberDataGridViewTextBoxColumn.Visible = false;
            this.vehicleNumberDataGridViewTextBoxColumn.Width = 129;
            // 
            // assignerNameDataGridViewTextBoxColumn
            // 
            this.assignerNameDataGridViewTextBoxColumn.DataPropertyName = "AssignerName";
            this.assignerNameDataGridViewTextBoxColumn.HeaderText = "AssignerName";
            this.assignerNameDataGridViewTextBoxColumn.Name = "assignerNameDataGridViewTextBoxColumn";
            this.assignerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.assignerNameDataGridViewTextBoxColumn.Visible = false;
            this.assignerNameDataGridViewTextBoxColumn.Width = 123;
            // 
            // FormViewAllComplaints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 482);
            this.Controls.Add(this.pnBackground);
            this.Controls.Add(this.dgFeedBacks);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormViewAllComplaints";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View All Complaints";
            this.Load += new System.EventHandler(this.FormViewAllComplaints_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFeedBacks)).EndInit();
            this.pnBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.complaintBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgFeedBacks;
        private DevComponents.DotNetBar.PanelEx pnBackground;
        private DevComponents.DotNetBar.ButtonX btnCorrectiveActionDetails;
        private DevComponents.DotNetBar.ButtonX btnInvestigationDetails;
        private DevComponents.DotNetBar.ButtonX btnAssign;
        private DevComponents.DotNetBar.ButtonX btnDetails;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource complaintBindingSource;
        private TraveLineTransitServices.DataSetTableAdapters.ComplaintTableAdapter complaintTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn representativeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfFeedBackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assigneeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn incidentDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn incidentPlaceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn busStopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignerNameDataGridViewTextBoxColumn;
    }
}