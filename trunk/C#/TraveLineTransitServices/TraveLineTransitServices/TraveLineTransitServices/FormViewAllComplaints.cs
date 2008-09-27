using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TraveLineTransitServices
{
    public partial class FormViewAllComplaints : Form
    {
        private DataSet.ComplaintRow complaint = null;

        public FormViewAllComplaints()
        {
            InitializeComponent();
        }

        private void UpdateData()
        {
            if (Config.CurrentEmployee.DepartmentName == "Customer Relations")
            {
                complaintTableAdapter.Fill(dataSet.Complaint);
            }
            else
            {
                complaintTableAdapter.FillByDepartment(dataSet.Complaint,
                    Config.CurrentEmployee.DepartmentID);
            }
        }

        private void FormViewAllComplaints_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateData();
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

        private void GetCurrentComplaint()
        {
            if (complaintBindingSource.Current == null) return;
            complaint = (DataSet.ComplaintRow)
                (((DataRowView)complaintBindingSource.Current).Row);
        }

        private void ShowDetails()
        {
            if (complaintBindingSource.Current == null) return;
            try
            {
                GetCurrentComplaint();
                if (complaint != null)
                {
                    FormFeedBack form = new FormFeedBack();
                    form.FeedBackID = complaint.FeedBackID;
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "TraveLine Transit Services",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgFeedBacks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowDetails();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (complaintBindingSource.Current == null) return;
            GetCurrentComplaint();
            if (complaint != null)
            {
                FormAssign form = new FormAssign();
                form.FeedBackID = complaint.FeedBackID;
                form.ShowDialog();
                UpdateData();
            }
        }

        private void btnInvestigationDetails_Click(object sender, EventArgs e)
        {
            if (complaintBindingSource.Current == null) return;
            GetCurrentComplaint();
            if (complaint != null)
            {
                FormInvestigationDetails form = new FormInvestigationDetails();
                form.FeedBackID = complaint.FeedBackID;
                form.Status = complaint.Status;
                form.ShowDialog();
                UpdateData();
            }
        }

        private void btnCorrectiveActionDetails_Click(object sender, EventArgs e)
        {
            if (complaintBindingSource.Current == null) return;
            GetCurrentComplaint();
            if (complaint != null)
            {
                FormCorrectiveActionDetails form = new FormCorrectiveActionDetails();
                form.FeedBackID = complaint.FeedBackID;
                form.Status = complaint.Status;
                form.ShowDialog();
                UpdateData();
            }
        }

        private void complaintBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (complaintBindingSource.Current == null) return;
            GetCurrentComplaint();
            if (complaint != null)
            {
                btnAssign.Enabled = false;
                btnInvestigationDetails.Enabled = false;
                btnCorrectiveActionDetails.Enabled = false;
                if (Config.CurrentEmployee.DepartmentName == "Customer Relations")
                {
                    if (complaint.Status == "Investigation Complete" ||
                        complaint.Status == "Closed")
                        btnInvestigationDetails.Enabled = true;
                    if (complaint.Status == "Closed") btnCorrectiveActionDetails.Enabled = true;
                }
                else
                {
                    if (complaint.Status == "New" &&
                        Config.CurrentEmployee.Designation == "KeyPerson")
                        btnAssign.Enabled = true;
                    if (complaint.Status == "Under Investigation" &&
                        complaint.AssigneeID == Config.CurrentEmployee.EmployeeID)
                        btnInvestigationDetails.Enabled = true;
                    if (Config.CurrentEmployee.Designation == "KeyPerson" &&
                        (complaint.Status == "Investigation Complete" ||
                        complaint.Status == "Closed"))
                    {
                        btnInvestigationDetails.Enabled = true;
                        btnCorrectiveActionDetails.Enabled = true;
                    }
                }
            }
        }
    }
}