using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TraveLineTransitServices
{
    public partial class FormServicesDetails : Form
    {
        public FormServicesDetails()
        {
            InitializeComponent();
        }

        private void FormServicesDetails_Load(object sender, EventArgs e)
        {
            try
            {
                servicesDetailsTableAdapter.Fill(dataSet.ServicesDetails);
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