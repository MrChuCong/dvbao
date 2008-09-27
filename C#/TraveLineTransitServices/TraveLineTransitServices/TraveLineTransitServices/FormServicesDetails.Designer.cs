namespace TraveLineTransitServices
{
    partial class FormServicesDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgFeedBacks = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.startingPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactPersonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicesDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new TraveLineTransitServices.DataSet();
            this.servicesDetailsTableAdapter = new TraveLineTransitServices.DataSetTableAdapters.ServicesDetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgFeedBacks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDetailsBindingSource)).BeginInit();
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
            this.startingPointDataGridViewTextBoxColumn,
            this.destinationDataGridViewTextBoxColumn,
            this.agencyDataGridViewTextBoxColumn,
            this.contactPersonDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.phoneNoDataGridViewTextBoxColumn,
            this.servicesDataGridViewTextBoxColumn});
            this.dgFeedBacks.DataSource = this.servicesDetailsBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFeedBacks.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgFeedBacks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFeedBacks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgFeedBacks.Location = new System.Drawing.Point(0, 0);
            this.dgFeedBacks.Name = "dgFeedBacks";
            this.dgFeedBacks.ReadOnly = true;
            this.dgFeedBacks.RowHeadersVisible = false;
            this.dgFeedBacks.RowHeadersWidth = 40;
            this.dgFeedBacks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFeedBacks.Size = new System.Drawing.Size(780, 301);
            this.dgFeedBacks.TabIndex = 2;
            // 
            // startingPointDataGridViewTextBoxColumn
            // 
            this.startingPointDataGridViewTextBoxColumn.DataPropertyName = "StartingPoint";
            this.startingPointDataGridViewTextBoxColumn.HeaderText = "Starting Point";
            this.startingPointDataGridViewTextBoxColumn.Name = "startingPointDataGridViewTextBoxColumn";
            this.startingPointDataGridViewTextBoxColumn.ReadOnly = true;
            this.startingPointDataGridViewTextBoxColumn.Width = 115;
            // 
            // destinationDataGridViewTextBoxColumn
            // 
            this.destinationDataGridViewTextBoxColumn.DataPropertyName = "Destination";
            this.destinationDataGridViewTextBoxColumn.HeaderText = "Destination";
            this.destinationDataGridViewTextBoxColumn.Name = "destinationDataGridViewTextBoxColumn";
            this.destinationDataGridViewTextBoxColumn.ReadOnly = true;
            this.destinationDataGridViewTextBoxColumn.Width = 101;
            // 
            // agencyDataGridViewTextBoxColumn
            // 
            this.agencyDataGridViewTextBoxColumn.DataPropertyName = "Agency";
            this.agencyDataGridViewTextBoxColumn.HeaderText = "Agency";
            this.agencyDataGridViewTextBoxColumn.Name = "agencyDataGridViewTextBoxColumn";
            this.agencyDataGridViewTextBoxColumn.ReadOnly = true;
            this.agencyDataGridViewTextBoxColumn.Width = 80;
            // 
            // contactPersonDataGridViewTextBoxColumn
            // 
            this.contactPersonDataGridViewTextBoxColumn.DataPropertyName = "ContactPerson";
            this.contactPersonDataGridViewTextBoxColumn.HeaderText = "Contact Person";
            this.contactPersonDataGridViewTextBoxColumn.Name = "contactPersonDataGridViewTextBoxColumn";
            this.contactPersonDataGridViewTextBoxColumn.ReadOnly = true;
            this.contactPersonDataGridViewTextBoxColumn.Width = 128;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 67;
            // 
            // phoneNoDataGridViewTextBoxColumn
            // 
            this.phoneNoDataGridViewTextBoxColumn.DataPropertyName = "PhoneNo";
            this.phoneNoDataGridViewTextBoxColumn.HeaderText = "Phone Number";
            this.phoneNoDataGridViewTextBoxColumn.Name = "phoneNoDataGridViewTextBoxColumn";
            this.phoneNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.phoneNoDataGridViewTextBoxColumn.Width = 126;
            // 
            // servicesDataGridViewTextBoxColumn
            // 
            this.servicesDataGridViewTextBoxColumn.DataPropertyName = "Services";
            this.servicesDataGridViewTextBoxColumn.HeaderText = "Services";
            this.servicesDataGridViewTextBoxColumn.Name = "servicesDataGridViewTextBoxColumn";
            this.servicesDataGridViewTextBoxColumn.ReadOnly = true;
            this.servicesDataGridViewTextBoxColumn.Width = 85;
            // 
            // servicesDetailsBindingSource
            // 
            this.servicesDetailsBindingSource.DataMember = "ServicesDetails";
            this.servicesDetailsBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // servicesDetailsTableAdapter
            // 
            this.servicesDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // FormServicesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 301);
            this.Controls.Add(this.dgFeedBacks);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormServicesDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Services Details";
            this.Load += new System.EventHandler(this.FormServicesDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFeedBacks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgFeedBacks;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource servicesDetailsBindingSource;
        private TraveLineTransitServices.DataSetTableAdapters.ServicesDetailsTableAdapter servicesDetailsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn startingPointDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactPersonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicesDataGridViewTextBoxColumn;
    }
}