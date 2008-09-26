using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Core
{
    public partial class FormFADPlayer : Form
    {
        public FormFADPlayer()
        {
            InitializeComponent();
        }

        public void SetFA(FA fa)
        {
            player.FA = fa;
        }

        public void SetInput(string input)
        {
            player.Input = input;
        }

        private void FormFADPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Reset();
        }
    }
}