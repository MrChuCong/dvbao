using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TraveLineTransitServices
{
    public partial class FormFeedBack : Form
    {
        private bool view = true;
        private string feedBackID = string.Empty;

        public string FeedBackID
        {
            get { return feedBackID; }
            set { feedBackID = value; }
        }

        public FormFeedBack()
        {
            InitializeComponent();
        }

        private void FormEditFeedBack_Load(object sender, EventArgs e)
        {
            try
            {
                if (feedBackID.Length == 0) view = false;
                customerTableAdapter.Fill(dataSet.Customer);
                departmentTableAdapter.Fill(dataSet.Department);
                if (view)
                {
                    feedBackDataTableAdapter.FillBy(dataSet.FeedBackData, feedBackID);
                }
                else
                {
                    txtRepresentativeName.Text = Config.CurrentEmployee.EmployeeName;
                    cboCustomerName.SelectedIndex = 0;
                    cboDepartmentName.SelectedIndex = 0;
                    cboFeedBackCategory.SelectedIndex = 0;
                    cboFeedBackSource.SelectedIndex = 0;
                    cboFeedBackType.SelectedIndex = 0;
                    CreateFeedBackID();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "TraveLine Transit Services",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Close();
            }
        }

        private void CreateFeedBackID()
        {
            feedBackTableAdapter.FillBySortedID(dataSet.FeedBack);
            if (dataSet.FeedBack.Rows.Count == 0) feedBackID = "F0001";
            else
            {
                string id = ((DataSet.FeedBackRow)dataSet.FeedBack.Rows[0]).FeedBackID;
                id = id.Substring(1);
                feedBackID = ((int)(Convert.ToInt32(id) + 1)).ToString();
                while (feedBackID.Length < 4) feedBackID = "0" + feedBackID;
                feedBackID = "F" + feedBackID;
            }
            txtFeedBackID.Text = feedBackID;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (view) Close();
            else CreateFeedBack();
        }

        private void CreateFeedBack()
        {
            try
            {
                DataSet.CustomerRow customer = (DataSet.CustomerRow)
                    (((DataRowView)customerBindingSource.Current).Row);
                DataSet.DepartmentRow department = (DataSet.DepartmentRow)
                    (((DataRowView)departmentBindingSource.Current).Row);
                feedBackTableAdapter.Insert(
                    feedBackID,
                    customer.CustomerID,
                    Config.CurrentEmployee.EmployeeID,
                    dtDateOfFeedBack.Value,
                    cboFeedBackSource.SelectedItem.ToString(),
                    cboFeedBackType.SelectedItem.ToString(),
                    cboFeedBackCategory.SelectedItem.ToString(),
                    txtDescription.Text,
                    department.DepartmentID,
                    dtIncidentDate.Value, txtIncidentPlace.Text,
                    txtBusStop.Text, txtVehicleNumber.Text,
                    "E000", "E000", DateTime.Now, DateTime.Now, "New", DateTime.Now);
                if (cboFeedBackType.SelectedItem.ToString() == "Complaint")
                {
                    investigationDetailsTableAdapter.Insert(
                        feedBackID, "TRUE", "", "R01", "");
                    correctiveActionsTableAdapter.Insert(
                        feedBackID, "", "E000");
                }
                MessageBox.Show("Done!",
                    "TraveLine Transit Services",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "TraveLine Transit Services",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}