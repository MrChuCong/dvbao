using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TraveLineTransitServices
{
    public partial class FormTraveLineTransitServices : Form
    {
        public FormTraveLineTransitServices()
        {
            InitializeComponent();
        }

        private void FormTraveLineTransitServices_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            string title = "TraveLine Transit Services";
            mnLogCustomerFeedBack.Enabled = false;
            mnViewAllFeedBacks.Enabled = false;
            mnViewAllComplaints.Enabled = false;
            mnPendingComplaintReports.Enabled = false;
            mnFeedBackInvestigationReports.Enabled = false;
            if (Config.CurrentEmployee != null)
            {
                mnLogOut.Enabled = true;
                title += " - " + Config.CurrentEmployee.EmployeeName +
                    " (" + Config.CurrentEmployee.DepartmentName + ")";
                if (Config.CurrentEmployee.DepartmentName == "Customer Relations")
                {
                    mnLogCustomerFeedBack.Enabled = true;
                    mnViewAllFeedBacks.Enabled = true;
                    mnViewAllComplaints.Enabled = true;
                    mnPendingComplaintReports.Enabled = true;
                    mnFeedBackInvestigationReports.Enabled = true;
                }
                else mnViewAllComplaints.Enabled = true;
            }
            else mnLogOut.Enabled = false;
            Text = title;
        }

        private void mnLogIn_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateUI();
            }
        }

        private void mnLogOut_Click(object sender, EventArgs e)
        {
            Config.CurrentEmployee = null;
            UpdateUI();
        }

        private void mnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnLogCustomerFeedBack_Click(object sender, EventArgs e)
        {
            FormFeedBack form = new FormFeedBack();
            form.ShowDialog();
        }

        private void mnViewAllFeedBacks_Click(object sender, EventArgs e)
        {
            FormViewAllFeedBacks form = new FormViewAllFeedBacks();
            form.ShowDialog();
        }

        private void mnViewAllComplaints_Click(object sender, EventArgs e)
        {
            FormViewAllComplaints form = new FormViewAllComplaints();
            form.ShowDialog();
        }

        private void mnPendingComplaintReports_Click(object sender, EventArgs e)
        {
            FormPendingComplaintReport form = new FormPendingComplaintReport();
            form.ShowDialog();
        }

        private void mnFeedBackInvestigationReports_Click(object sender, EventArgs e)
        {
            FormFeedBackInvestigationReports form = new FormFeedBackInvestigationReports();
            form.ShowDialog();
        }

        private void mnHelpContents_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider.HelpNamespace);
        }

        private void mnServicesDetails_Click(object sender, EventArgs e)
        {
            FormServicesDetails form = new FormServicesDetails();
            form.ShowDialog();
        }

        private void mnAbout_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.ShowDialog();
        }
    }
}