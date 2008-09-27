using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TraveLineTransitServices
{
    public partial class FormViewAllFeedBacks : Form
    {
        public FormViewAllFeedBacks()
        {
            InitializeComponent();
        }

        private void FormViewAllFeedBacks_Load(object sender, EventArgs e)
        {
            try
            {
                feedBackDataTableAdapter.Fill(dataSet.FeedBackData);
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
            if (feedBackDataBindingSource.Current == null) return;
            try
            {
                DataSet.FeedBackDataRow feedBack = (DataSet.FeedBackDataRow)
                    (((DataRowView)feedBackDataBindingSource.Current).Row);
                FormFeedBack form = new FormFeedBack();
                form.FeedBackID = feedBack.FeedBackID;
                form.ShowDialog();
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