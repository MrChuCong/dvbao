using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TraveLineTransitServices
{
    public partial class FormAssign : Form
    {
        private string feedBackID = string.Empty;

        public string FeedBackID
        {
            get { return feedBackID; }
            set { feedBackID = value; }
        }

        public FormAssign()
        {
            InitializeComponent();
        }

        private void FormAssign_Load(object sender, EventArgs e)
        {
            try
            {
                txtFeedBackID.Text = feedBackID;
                employeeTableAdapter.FillAssigneeByDepartment(dataSet.Employee,
                    Config.CurrentEmployee.DepartmentID);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet.EmployeeRow assignee = (DataSet.EmployeeRow)
                    (((DataRowView)employeeBindingSource.Current).Row);
                complaintTableAdapter.Assign(
                    Config.CurrentEmployee.EmployeeID,
                    assignee.EmployeeID,
                    "Under Investigation",
                    dtDateOfAssignment.Value,
                    feedBackID);
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