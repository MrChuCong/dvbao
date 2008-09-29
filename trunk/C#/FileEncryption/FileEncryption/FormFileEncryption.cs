using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace FileEncryption
{
    public partial class FormFileEncryption : Form
    {
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private DES des = DES.Create();
        private Random random = new Random(DateTime.Now.Millisecond);

        public FormFileEncryption()
        {
            InitializeComponent();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "All Files (*.*)|*.*";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "All Files (*.*)|*.*";
            des.Padding = PaddingMode.PKCS7;
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            string key = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                key += Convert.ToChar(random.Next(93) + 33);
            }
            txtKey.Text = key;
        }

        private void btnBrowseInputFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInputFile.Text = openFileDialog.FileName;
            }
        }

        private void btnBrowseOutputFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputFile.Text = saveFileDialog.FileName;
            }
        }

        private void InitializeKey()
        {
            string key = txtKey.Text;
            byte[] keyBytes = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                keyBytes[i] = (byte)key[i];
            }
            des.Key = keyBytes;
            des.IV = keyBytes;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FileName.Length > 0 &&
                saveFileDialog.FileName.Length > 0 &&
                txtKey.Text.Length > 0)
            {
                InitializeKey();                
                FileStream inputStream = new FileStream(openFileDialog.FileName,
                    FileMode.Open, FileAccess.Read);
                FileStream outputStream = new FileStream(saveFileDialog.FileName,
                    FileMode.Create, FileAccess.Write);
                ICryptoTransform encryptor = des.CreateEncryptor();
                CryptoStream cryptoStream = new CryptoStream(outputStream,
                    encryptor, CryptoStreamMode.Write);
                byte[] data = new byte[inputStream.Length];
                inputStream.Read(data, 0, data.Length);
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.Close();
                inputStream.Close();
                outputStream.Close();
                MessageBox.Show("Done.", "File Encryption",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FileName.Length > 0 &&
                saveFileDialog.FileName.Length > 0 &&
                txtKey.Text.Length > 0)
            {
                InitializeKey();                
                FileStream inputStream = new FileStream(openFileDialog.FileName,
                    FileMode.Open, FileAccess.Read);
                FileStream outputStream = new FileStream(saveFileDialog.FileName,
                    FileMode.Create, FileAccess.Write);
                ICryptoTransform decryptor = des.CreateDecryptor();
                CryptoStream cryptoStream = new CryptoStream(inputStream,
                    decryptor, CryptoStreamMode.Read);
                byte[] data = new byte[inputStream.Length];
                cryptoStream.Read(data, 0, data.Length);
                outputStream.Write(data, 0, data.Length);
                cryptoStream.Close();
                inputStream.Close();
                outputStream.Close();
                MessageBox.Show("Done.", "File Encryption",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}