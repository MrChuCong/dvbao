using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor
{
    public partial class InputSceneFrm : Form
    {
        public static int X = 0;
        public static int Y = 0;
        public static int Scene = 11;
        public InputSceneFrm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            X = int.Parse(txtX.Text);
            Y = int.Parse(txtY.Text);
            Scene = int.Parse(txtScene.Text);
        }
    }
}