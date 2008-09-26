using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cogitance;
using Cogitance.DVizion;
using System.Runtime.InteropServices;

namespace WrongWayDrivingDetector
{
    public partial class FormDetector : Form
    {
        private VideoCogControl videoControl;
        private Detector detector = null;
        private Bitmap bitmap = null;
        private byte[] tmp;
        private int current;
        private int previous;
        
        public FormDetector()
        {
            InitializeVideoControl();
            InitializeComponent();
        }

        #region Initialize Video Control

        private void InitializeVideoControl()
        {
            videoControl = new VideoCogControl();
            videoControl.BackColor = Color.White;
            videoControl.BorderStyle = BorderStyle.FixedSingle;
            videoControl.Debug = false;
            videoControl.DesignPreview = false;
            videoControl.Dock = DockStyle.Fill;
            videoControl.Fullscreen = false;
            videoControl.Name = "videoControl";
            videoControl.OutputFile = null;
            videoControl.Playing = false;
            videoControl.Recording = false;
            VideoCogStream stream = new VideoCogStream();
            stream.GrabberEnabled = false;
            stream.Height = 1F;
            stream.Left = 0F;
            stream.Opacity = 0F;
            stream.Source = null;
            stream.SourceInputIndex = -2147467259;
            stream.Top = 0F;
            stream.TVChannel = -1;
            stream.TVCountryCode = -2147467259;
            stream.TVTunerInput = -2147467259;
            stream.Width = 1F;
            videoControl.Streams.Add(stream);
            Controls.Add(videoControl);
        }

        #endregion

        private void FormDetector_Load(object sender, EventArgs e)
        {
            videoControl.Streams[0].GrabberEnabled = true;
            videoControl.SetFrameCallback(new DelegateFrameCallback(FrameCallback));
        }

        private void mnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.AddExtension = true;
            dialog.Filter =
                "Video Files (*.avi, *.wmv, *.mpg, *.mov)|*.avi;*.wmv;*.mpg;*.mov|AVI Files (*.avi)|*.avi|WMV Files (*.wmv)|*.wmv|MPEG Files (*.mpg)|*.mpg|MOV Files (*.mov)|*.mov|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Refresh();
                detector = null;
                if (bitmap != null) bitmap.Dispose();
                videoControl.Streams[0].Source = dialog.FileName;
            }
            Activate();
        }

        private void mnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            videoControl.Play();
            Activate();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            videoControl.Pause();
            Activate();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            videoControl.Pause();
            videoControl.Reset();
            Activate();
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            videoControl.StepBackward(10);
            Activate();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            videoControl.StepForward(10);
            Activate();
        }

        private void FrameCallback(double time, IntPtr buffer, int size, int width, int height)
        {
            if (detector == null)
            {
                detector = new Detector(size, width, height);
                bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                tmp = new byte[size];
                current = 0;
                previous = -100;
            }
            current++;
            if (detector.Apply(buffer) && mnCapture.Checked && current - previous > 20)
            {
                BitmapData data = bitmap.LockBits(new Rectangle(
                    0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                Marshal.Copy(buffer, tmp, 0, size);
                Marshal.Copy(tmp, 0, data.Scan0, size);
                bitmap.UnlockBits(data);
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                bitmap.Save("Frame" + current + ".jpg");
                previous = current;
            }
        }
    }
}