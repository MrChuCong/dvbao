using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TileMapEditor
{
    public partial class OptionsFrm : Form
    {
        FolderBrowserDialog folderDiaglog;

        public OptionsFrm()
        {
            InitializeComponent();            
            folderDiaglog = new FolderBrowserDialog();
            folderDiaglog.Description = "Please choose one folder to open";
            folderDiaglog.ShowNewFolderButton = false;
            folderDiaglog.RootFolder = Environment.SpecialFolder.Desktop;
        }

        public void LoadValue()
        {
            txtDecorativeFolder.Text = MainFrm.s_DecoratateFolder;
            txtEnemyFolder.Text = MainFrm.s_ItemsFolder;
            txtSpriteFolder.Text = MainFrm.s_ResourceFolder;
            txtPlayingTime.Text = MainFrm.s_Time.ToString();
        }

        private void btnDecorativeFolder_Click(object sender, EventArgs e)
        {
            if (folderDiaglog.ShowDialog() == DialogResult.OK)
            {
                txtDecorativeFolder.Text = folderDiaglog.SelectedPath + "\\";
            }
        }

        private void btnEnemyFolder_Click(object sender, EventArgs e)
        {
            if (folderDiaglog.ShowDialog() == DialogResult.OK)
            {
                txtEnemyFolder.Text = folderDiaglog.SelectedPath + "\\";
            }
        }
        
        private void btnSpriteFolder_Click(object sender, EventArgs e)
        {
            if (folderDiaglog.ShowDialog() == DialogResult.OK)
            {
                txtEnemyFolder.Text = folderDiaglog.SelectedPath + "\\";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MainFrm.s_ItemsFolder = txtEnemyFolder.Text;
            MainFrm.s_DecoratateFolder = txtDecorativeFolder.Text;
            MainFrm.s_ResourceFolder = txtSpriteFolder.Text;
            MainFrm.s_Time = int.Parse(txtPlayingTime.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
