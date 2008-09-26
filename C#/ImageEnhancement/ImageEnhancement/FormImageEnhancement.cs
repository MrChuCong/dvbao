using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileDialogEx;

namespace ImageEnhancement
{
    public partial class FormImageEnhancement : Form
    {
        private string DefaultFilter =
            "All Image Files (*.png, *.jpg, *.jpeg, *.jpe, *.jfif, *.bmp, *.imt)|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.imt|PNG (*.png)|*.png|JPEG (*.jpg, *.jpeg, *.jpe, *.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|BMP (*.bmp)|*.bmp|Image Text (*.imt)|*.imt|All Files (*.*)|*.*";

        private CSImage currentImage = null;

        public FormImageEnhancement()
        {
            InitializeComponent();
        }

        private void UpdateCurrentImage()
        {
            if (pbCurrentImage.Image != null)
                pbCurrentImage.Image.Dispose();
            pbCurrentImage.Image = currentImage.ToBitmap();
        }

        private void mnOpen_Click(object sender, EventArgs e)
        {
            PreviewOpenFileDialog dialog = new PreviewOpenFileDialog();
            dialog.DefaultViewMode = FolderViewMode.Thumbnails;
            dialog.OpenDialog.CheckFileExists = true;
            dialog.OpenDialog.CheckPathExists = true;
            dialog.OpenDialog.Filter = DefaultFilter;
            dialog.OpenDialog.FilterIndex = 0;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Refresh();
                CSImage csImage = CSImage.FromFile(dialog.OpenDialog.FileName);
                if (csImage == null)
                {
                    MessageBox.Show(
                        "Invalid image file!",
                        "Image Enhancement",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                }
                else
                {
                    currentImage = csImage;
                    UpdateCurrentImage();
                }
            }
            dialog.Dispose();
        }

        private void mnSave_Click(object sender, EventArgs e)
        {
            if (currentImage == null) return;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.OverwritePrompt = true;
            dialog.Filter = DefaultFilter;
            dialog.FilterIndex = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Refresh();
                string ext = dialog.FileName.Substring(
                    dialog.FileName.LastIndexOf('.') + 1);
                switch (ext.ToUpper())
                {
                    case "PNG":
                    case "JPG":
                    case "JPEG":
                    case "JPE":
                    case "JFIF":
                    case "BMP":
                        pbCurrentImage.Image.Save(dialog.FileName);
                        break;
                    default:
                        currentImage.Save(dialog.FileName);
                        break;
                }
            }
        }

        private void mnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnAutoEnhancement_Click(object sender, EventArgs e)
        {
            if (currentImage == null) return;
            Refresh();
            currentImage.ContrastStretching();
            currentImage.Sharpening();
            UpdateCurrentImage();
        }

        private void mnNaturalScence_Click(object sender, EventArgs e)
        {
            if (currentImage == null) return;
            Refresh();
            currentImage.ContrastStretching();            
            UpdateCurrentImage();
        }

        private void mnXRay_Click(object sender, EventArgs e)
        {
            if (currentImage == null) return;
            Refresh();
            for (int i = 0; i < 5; i++)
                currentImage.ContrastStretching();
            currentImage.Sharpening();
            UpdateCurrentImage();
        }

        private void mnOldPortrait_Click(object sender, EventArgs e)
        {
            if (currentImage == null) return;
            Refresh();
            currentImage.ContrastStretching();
            currentImage.Smoothing();
            UpdateCurrentImage();
        }

        private void mnCircleDetection_Click(object sender, EventArgs e)
        {
            if (currentImage == null) return;
            Refresh();
            currentImage.CircleDetection();
            UpdateCurrentImage();
        }
    }
}