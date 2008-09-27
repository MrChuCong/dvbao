using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TraveLineTransitServices
{
    public partial class FormFeedBackInvestigationReports : Form
    {
        public FormFeedBackInvestigationReports()
        {
            InitializeComponent();
        }

        private void FormFeedBackInvestigationReports_Load(object sender, EventArgs e)
        {
            try
            {
                complaintTableAdapter.FillByCompletedComplaints(dataSet.Complaint);
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

        private void dgFeedBacks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (complaintBindingSource.Current == null) return;
            try
            {
                DataSet.ComplaintRow complaint = (DataSet.ComplaintRow)
                    (((DataRowView)complaintBindingSource.Current).Row);
                if (complaint != null)
                {
                    FormCustomerFeedBackInvestigationReport form =
                        new FormCustomerFeedBackInvestigationReport();
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
    }
}