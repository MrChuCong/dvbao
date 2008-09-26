using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Core;

namespace FAD
{
    public partial class FormFAD : Form
    {
        public FormFAD()
        {
            InitializeComponent();
            faPlotter.SelectEvent += new FAPlotter.SelectHandler(faPlotter_SelectEvent);
        }

        private void faPlotter_SelectEvent(object obj)
        {
            property.SelectedObject = obj;
        }

        private void property_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            faPlotter.OnPaint();
        }

        private void FormFAD_FormClosing(object sender, FormClosingEventArgs e)
        {
            faPlotter.ReleaseFA();
        }
    }
}