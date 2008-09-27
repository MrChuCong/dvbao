using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TraveLineTransitServices
{
    public partial class FormInvestigationDetails : Form
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

        public FormInvestigationDetails()
        {
            InitializeComponent();
        }

        private void FormInvestigationDetails_Load(object sender, EventArgs e)
        {
            try
            {
                driverTableAdapter.Fill(dataSet.Driver);
                investigationDetailsDataTableAdapter.Fill(dataSet.InvestigationDetailsData, feedBackID);    
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
            if (status != "Under Investigation")
            {
                Close();
                return;
            }
            try
            {
                DataSet.DriverRow driver = (DataSet.DriverRow)
                    (((DataRowView)driverBindingSource.Current).Row);
                investigationDetailsDataTableAdapter.Create(
                    cboValidity.SelectedItem.ToString(),
                    txtReason.Text,
                    driver.DriverID,
                    txtDetails.Text,
                    feedBackID);
                feedBackTableAdapter.CompleteInvestigation("Investigation Complete",
                    dtDateOfCompletion.Value,
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