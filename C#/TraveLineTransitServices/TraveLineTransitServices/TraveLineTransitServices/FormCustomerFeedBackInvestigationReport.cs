using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TraveLineTransitServices
{
    public partial class FormCustomerFeedBackInvestigationReport : Form
    {
        private string feedBackID = string.Empty;

        public string FeedBackID
        {
            get { return feedBackID; }
            set { feedBackID = value; }
        }

        public FormCustomerFeedBackInvestigationReport()
        {
            InitializeComponent();
        }

        private void FormCustomerFeedBackInvestigationReport_Load(object sender, EventArgs e)
        {
            try
            {
                investigationDetailsDataTableAdapter.Fill(dataSet.InvestigationDetailsData, feedBackID);
                rpCustomerFeedBackInvestigationReport.SetDataSource(dataSet);
                reportViewer.ReportSource = rpCustomerFeedBackInvestigationReport;
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
    }
}