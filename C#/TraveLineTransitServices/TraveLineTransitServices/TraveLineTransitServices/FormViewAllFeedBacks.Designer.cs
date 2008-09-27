namespace TraveLineTransitServices
{
    partial class FormViewAllFeedBacks
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgFeedBacks = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.feedBackDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new TraveLineTransitServices.DataSet();
            this.feedBackDataTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.FeedBackDataTableAdapter();
            this.feedBackIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.representativeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfFeedBackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedBackTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedBackCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedBackSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incidentDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incidentPlaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.busStopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assigneeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgFeedBacks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedBackDataBindingSource)).BeginInit();
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
            this.feedBackTypeDataGridViewTextBoxColumn,
            this.feedBackCategoryDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.feedBackSourceDataGridViewTextBoxColumn,
            this.departmentNameDataGridViewTextBoxColumn,
            this.incidentDateDataGridViewTextBoxColumn,
            this.incidentPlaceDataGridViewTextBoxColumn,
            this.busStopDataGridViewTextBoxColumn,
            this.vehicleNumberDataGridViewTextBoxColumn,
            this.assignerNameDataGridViewTextBoxColumn,
            this.assigneeNameDataGridViewTextBoxColumn});
            this.dgFeedBacks.DataSource = this.feedBackDataBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFeedBacks.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgFeedBacks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFeedBacks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgFeedBacks.Location = new System.Drawing.Point(0, 0);
            this.dgFeedBacks.Name = "dgFeedBacks";
            this.dgFeedBacks.ReadOnly = true;
            this.dgFeedBacks.RowHeadersVisible = false;
            this.dgFeedBacks.RowHeadersWidth = 40;
            this.dgFeedBacks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFeedBacks.Size = new System.Drawing.Size(742, 433);
            this.dgFeedBacks.TabIndex = 0;
            this.dgFeedBacks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFeedBacks_CellDoubleClick);
            // 
            // feedBackDataBindingSource
            // 
            this.feedBackDataBindingSource.DataMember = "FeedBackData";
            this.feedBackDataBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // feedBackDataTableAdapter
            // 
            this.feedBackDataTableAdapter.ClearBeforeFill = true;
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
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.dateOfFeedBackDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dateOfFeedBackDataGridViewTextBoxColumn.HeaderText = "FeedBack Date";
            this.dateOfFeedBackDataGridViewTextBoxColumn.Name = "dateOfFeedBackDataGridViewTextBoxColumn";
            this.dateOfFeedBackDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateOfFeedBackDataGridViewTextBoxColumn.Width = 130;
            // 
            // feedBackTypeDataGridViewTextBoxColumn
            // 
            this.feedBackTypeDataGridViewTextBoxColumn.DataPropertyName = "FeedBackType";
            this.feedBackTypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.feedBackTypeDataGridViewTextBoxColumn.Name = "feedBackTypeDataGridViewTextBoxColumn";
            this.feedBackTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedBackTypeDataGridViewTextBoxColumn.Width = 65;
            // 
            // feedBackCategoryDataGridViewTextBoxColumn
            // 
            this.feedBackCategoryDataGridViewTextBoxColumn.DataPropertyName = "FeedBackCategory";
            this.feedBackCategoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.feedBackCategoryDataGridViewTextBoxColumn.Name = "feedBackCategoryDataGridViewTextBoxColumn";
            this.feedBackCategoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedBackCategoryDataGridViewTextBoxColumn.Width = 90;
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
            // feedBackSourceDataGridViewTextBoxColumn
            // 
            this.feedBackSourceDataGridViewTextBoxColumn.DataPropertyName = "FeedBackSource";
            this.feedBackSourceDataGridViewTextBoxColumn.HeaderText = "FeedBackSource";
            this.feedBackSourceDataGridViewTextBoxColumn.Name = "feedBackSourceDataGridViewTextBoxColumn";
            this.feedBackSourceDataGridViewTextBoxColumn.ReadOnly = true;
            this.feedBackSourceDataGridViewTextBoxColumn.Visible = false;
            this.feedBackSourceDataGridViewTextBoxColumn.Width = 140;
            // 
            // departmentNameDataGridViewTextBoxColumn
            // 
            this.departmentNameDataGridViewTextBoxColumn.DataPropertyName = "DepartmentName";
            this.departmentNameDataGridViewTextBoxColumn.HeaderText = "DepartmentName";
            this.departmentNameDataGridViewTextBoxColumn.Name = "departmentNameDataGridViewTextBoxColumn";
            this.departmentNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.departmentNameDataGridViewTextBoxColumn.Visible = false;
            this.departmentNameDataGridViewTextBoxColumn.Width = 142;
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
            // assigneeNameDataGridViewTextBoxColumn
            // 
            this.assigneeNameDataGridViewTextBoxColumn.DataPropertyName = "AssigneeName";
            this.assigneeNameDataGridViewTextBoxColumn.HeaderText = "AssigneeName";
            this.assigneeNameDataGridViewTextBoxColumn.Name = "assigneeNameDataGridViewTextBoxColumn";
            this.assigneeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.assigneeNameDataGridViewTextBoxColumn.Visible = false;
            this.assigneeNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // FormViewAllFeedBacks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 433);
            this.Controls.Add(this.dgFeedBacks);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormViewAllFeedBacks";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View All FeedBacks";
            this.Load += new System.EventHandler(this.FormViewAllFeedBacks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFeedBacks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedBackDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgFeedBacks;
        private System.Windows.Forms.BindingSource feedBackDataBindingSource;
        private DataSet dataSet;
        private TraveLineTransitServices.DataSetTableAdapters.FeedBackDataTableAdapter feedBackDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn representativeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfFeedBackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn incidentDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn incidentPlaceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn busStopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicleNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assigneeNameDataGridViewTextBoxColumn;
    }
}