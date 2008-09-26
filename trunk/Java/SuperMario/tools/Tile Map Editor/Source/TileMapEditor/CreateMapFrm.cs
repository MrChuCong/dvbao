using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor
{
    public partial class CreateMapFrm : Form
    {
        public static int MapWidth = 200; // resource: 20 x 60
        public static int MapHeight = 15;
        public static int TileWidth = 16;
        public static int TileHeight = 16;

        public CreateMapFrm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MapWidth = int.Parse(txtWidth.Text);
            MapHeight = int.Parse(txtHeight.Text);
            TileWidth = int.Parse(txtTileWidth.Text);
            TileHeight = int.Parse(txtTileHeight.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
