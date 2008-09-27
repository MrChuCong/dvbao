using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TraveLineTransitServices
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                currentEmployeeTableAdapter.Fill(dataSet.CurrentEmployee,
                    txtUsername.Text, txtPassword.Text);
                if (dataSet.CurrentEmployee.Rows.Count > 0)
                {
                    Config.CurrentEmployee = (DataSet.CurrentEmployeeRow)dataSet.CurrentEmployee.Rows[0];
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Wrong username or password!",
                        "TraveLine Transit Services",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
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