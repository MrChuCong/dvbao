using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace TraveLineTransitServices
{
    public partial class FormPendingComplaintReport : Form
    {
        public FormPendingComplaintReport()
        {
            InitializeComponent();
        }

        private void FormPendingComplaintReports_Load(object sender, EventArgs e)
        {
            try
            {
                complaintTableAdapter.FillByPendingComplaints(dataSet.Complaint);
                rpPendingComplaintReport.SetDataSource(dataSet);
                reportViewer.ReportSource = rpPendingComplaintReport;
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