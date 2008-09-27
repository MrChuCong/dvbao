namespace TraveLineTransitServices
{
    partial class FormFeedBackInvestigationReports
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
            this.feedBackIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfFeedBackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representativeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedBackSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedBackTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedBackCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incidentDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incidentPlaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.busStopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assigneeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assigneeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complaintBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new TraveLineTransitServices.DataSet();
            this.complaintTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.ComplaintTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgFeedBacks)).BeginInit();
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
            this.dateOfFeedBackDataGridViewTextBoxColumn,
            this.customerNameDataGridViewTextBoxColumn,
            this.departmentNameDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.representativeNameDataGridViewTextBoxColumn,
            this.feedBackSourceDataGridViewTextBoxColumn,
            this.feedBackTypeDataGridViewTextBoxColumn,
            this.feedBackCategoryDataGridViewTextBoxColumn,
            this.incidentDateDataGridViewTextBoxColumn,
            this.incidentPlaceDataGridViewTextBoxColumn,
            this.busStopDataGridViewTextBoxColumn,
            this.vehicleNumberDataGridViewTextBoxColumn,
            this.assignerNameDataGridViewTextBoxColumn,
            this.assigneeNameDataGridViewTextBoxColumn,
            this.assigneeIDDataGridViewTextBoxColumn});
            this.dgFeedBacks.DataSource = this.complaintBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFeedBacks.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgFeedBacks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFeedBacks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgFeedBacks.Location = new System.Drawing.Point(0, 0);
            this.dgFeedBacks.Name = "dgFeedBacks";
            this.dgFeedBacks.ReadOnly = true;
            this.dgFeedBacks.RowHeadersVisible = false;
            this.dgFeedBacks.RowHeadersWidth = 40;
            this.dgFeedBacks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFeedBacks.Size = new System.Drawing.Size(622, 363);
            this.dgFeedBacks.TabIndex = 1;
            this.dgFeedBacks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFeedBacks_CellDoubleClick);
            // 
            // feedBackIDDataGridViewTextBoxColumn
            // 
            this.feedBackIDDataGridViewTextBoxColumn.DataPropertyName = "FeedBackID";
            this.feedBackIDDataGridViewTextBoxColumn.HeaderText = "FeedBack ID";
            this.feedBackIDDataGridViewTextBoxColumn.Name = "feedBackIDDataGridViewTextBoxColumn";
            this.feedBackIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedBackIDDataGridViewTextBoxColumn.Width = 117;
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
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "Customer";
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerNameDataGridViewTextBoxColumn.Width = 93;
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
            // representativeNameDataGridViewTextBoxColumn
            // 
            this.representativeNameDataGridViewTextBoxColumn.DataPropertyName = "RepresentativeName";
            this.representativeNameDataGridViewTextBoxColumn.HeaderText = "RepresentativeName";
            this.representativeNameDataGridViewTextBoxColumn.Name = "representativeNameDataGridViewTextBoxColumn";
            this.representativeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.representativeNameDataGridViewTextBoxColumn.Visible = false;
            this.representativeNameDataGridViewTextBoxColumn.Width = 132;
            // 
            // feedBackSourceDataGridViewTextBoxColumn
            // 
            this.feedBackSourceDataGridViewTextBoxColumn.DataPropertyName = "FeedBackSource";
            this.feedBackSourceDataGridViewTextBoxColumn.HeaderText = "FeedBackSource";
            this.feedBackSourceDataGridViewTextBoxColumn.Name = "feedBackSourceDataGridViewTextBoxColumn";
            this.feedBackSourceDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedBackSourceDataGridViewTextBoxColumn.Visible = false;
            this.feedBackSourceDataGridViewTextBoxColumn.Width = 115;
            // 
            // feedBackTypeDataGridViewTextBoxColumn
            // 
            this.feedBackTypeDataGridViewTextBoxColumn.DataPropertyName = "FeedBackType";
            this.feedBackTypeDataGridViewTextBoxColumn.HeaderText = "FeedBackType";
            this.feedBackTypeDataGridViewTextBoxColumn.Name = "feedBackTypeDataGridViewTextBoxColumn";
            this.feedBackTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedBackTypeDataGridViewTextBoxColumn.Visible = false;
            this.feedBackTypeDataGridViewTextBoxColumn.Width = 105;
            // 
            // feedBackCategoryDataGridViewTextBoxColumn
            // 
            this.feedBackCategoryDataGridViewTextBoxColumn.DataPropertyName = "FeedBackCategory";
            this.feedBackCategoryDataGridViewTextBoxColumn.HeaderText = "FeedBackCategory";
            this.feedBackCategoryDataGridViewTextBoxColumn.Name = "feedBackCategoryDataGridViewTextBoxColumn";
            this.feedBackCategoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedBackCategoryDataGridViewTextBoxColumn.Visible = false;
            this.feedBackCategoryDataGridViewTextBoxColumn.Width = 123;
            // 
            // incidentDateDataGridViewTextBoxColumn
            // 
            this.incidentDateDataGridViewTextBoxColumn.DataPropertyName = "IncidentDate";
            this.incidentDateDataGridViewTextBoxColumn.HeaderText = "IncidentDate";
            this.incidentDateDataGridViewTextBoxColumn.Name = "incidentDateDataGridViewTextBoxColumn";
            this.incidentDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.incidentDateDataGridViewTextBoxColumn.Visible = false;
            this.incidentDateDataGridViewTextBoxColumn.Width = 93;
            // 
            // incidentPlaceDataGridViewTextBoxColumn
            // 
            this.incidentPlaceDataGridViewTextBoxColumn.DataPropertyName = "IncidentPlace";
            this.incidentPlaceDataGridViewTextBoxColumn.HeaderText = "IncidentPlace";
            this.incidentPlaceDataGridViewTextBoxColumn.Name = "incidentPlaceDataGridViewTextBoxColumn";
            this.incidentPlaceDataGridViewTextBoxColumn.ReadOnly = true;
            this.incidentPlaceDataGridViewTextBoxColumn.Visible = false;
            this.incidentPlaceDataGridViewTextBoxColumn.Width = 97;
            // 
            // busStopDataGridViewTextBoxColumn
            // 
            this.busStopDataGridViewTextBoxColumn.DataPropertyName = "BusStop";
            this.busStopDataGridViewTextBoxColumn.HeaderText = "BusStop";
            this.busStopDataGridViewTextBoxColumn.Name = "busStopDataGridViewTextBoxColumn";
            this.busStopDataGridViewTextBoxColumn.ReadOnly = true;
            this.busStopDataGridViewTextBoxColumn.Visible = false;
            this.busStopDataGridViewTextBoxColumn.Width = 72;
            // 
            // vehicleNumberDataGridViewTextBoxColumn
            // 
            this.vehicleNumberDataGridViewTextBoxColumn.DataPropertyName = "VehicleNumber";
            this.vehicleNumberDataGridViewTextBoxColumn.HeaderText = "VehicleNumber";
            this.vehicleNumberDataGridViewTextBoxColumn.Name = "vehicleNumberDataGridViewTextBoxColumn";
            this.vehicleNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.vehicleNumberDataGridViewTextBoxColumn.Visible = false;
            this.vehicleNumberDataGridViewTextBoxColumn.Width = 104;
            // 
            // assignerNameDataGridViewTextBoxColumn
            // 
            this.assignerNameDataGridViewTextBoxColumn.DataPropertyName = "AssignerName";
            this.assignerNameDataGridViewTextBoxColumn.HeaderText = "AssignerName";
            this.assignerNameDataGridViewTextBoxColumn.Name = "assignerNameDataGridViewTextBoxColumn";
            this.assignerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.assignerNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // assigneeNameDataGridViewTextBoxColumn
            // 
            this.assigneeNameDataGridViewTextBoxColumn.DataPropertyName = "AssigneeName";
            this.assigneeNameDataGridViewTextBoxColumn.HeaderText = "AssigneeName";
            this.assigneeNameDataGridViewTextBoxColumn.Name = "assigneeNameDataGridViewTextBoxColumn";
            this.assigneeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.assigneeNameDataGridViewTextBoxColumn.Visible = false;
            this.assigneeNameDataGridViewTextBoxColumn.Width = 103;
            // 
            // assigneeIDDataGridViewTextBoxColumn
            // 
            this.assigneeIDDataGridViewTextBoxColumn.DataPropertyName = "AssigneeID";
            this.assigneeIDDataGridViewTextBoxColumn.HeaderText = "AssigneeID";
            this.assigneeIDDataGridViewTextBoxColumn.Name = "assigneeIDDataGridViewTextBoxColumn";
            this.assigneeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.assigneeIDDataGridViewTextBoxColumn.Visible = false;
            this.assigneeIDDataGridViewTextBoxColumn.Width = 86;
            // 
            // complaintBindingSource
            // 
            this.complaintBindingSource.DataMember = "Complaint";
            this.complaintBindingSource.DataSource = this.dataSet;
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
            // FormFeedBackInvestigationReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 363);
            this.Controls.Add(this.dgFeedBacks);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFeedBackInvestigationReports";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FeedBack Investigation Reports";
            this.Load += new System.EventHandler(this.FormFeedBackInvestigationReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFeedBacks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaintBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgFeedBacks;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource complaintBindingSource;
        private TraveLineTransitServices.DataSetTableAdapters.ComplaintTableAdapter complaintTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfFeedBackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn representativeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn incidentDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn incidentPlaceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn busStopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assigneeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assigneeIDDataGridViewTextBoxColumn;
    }
}