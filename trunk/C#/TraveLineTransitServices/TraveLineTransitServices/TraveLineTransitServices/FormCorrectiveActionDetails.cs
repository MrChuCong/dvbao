using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TraveLineTransitServices
{
    public partial class FormCorrectiveActionDetails : Form
    {
        private string feedBackID = string.Empty;

        public string FeedBackID
        {
            get { return feedBackID; }
            set { feedBackID = value; }
        }

        private string status = string.Empty;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public FormCorrectiveActionDetails()
        {
            InitializeComponent();
        }

        private void FormCorrectiveActionDetails_Load(object sender, EventArgs e)
        {
            try
            {
                correctiveActionsDataTableAdapter.Fill(dataSet.CorrectiveActionsData, feedBackID);
                if (txtRepresentative.Text.Length == 0)
                    txtRepresentative.Text = Config.CurrentEmployee.EmployeeName;
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
            if (status != "Investigation Complete")
            {
                Close();
                return;
            }
            try
            {
                correctiveActionsDataTableAdapter.Create(
                    txtActionDetails.Text,
                    Config.CurrentEmployee.EmployeeID,
                    feedBackID);
                feedBackTableAdapter.CloseFeedBack("Closed",
                    dtDateOfClosure.Value,
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