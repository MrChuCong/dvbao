using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace ImageEnhancement
{
    public class CSImage
    {
        #region Properties

        private int width = 0;

        public int Width
        {
            get { return width; }
        }

        private int height = 0;

        public int Height
        {
            get { return height; }
        }

        private byte[,] red = null;

        public byte[,] Red
        {
            get { return red; }
        }

        private byte[,] green = null;

        public byte[,] Green
        {
            get { return green; }
        }

        private byte[,] blue = null;

        public byte[,] Blue
        {
            get { return blue; }
        }

        private double amin = 0;
        private double amax = 255;

        #endregion

        #region Constructors

        private CSImage(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.red = new byte[height, width];
            this.green = new byte[height, width];
            this.blue = new byte[height, width];
        }

        public static CSImage FromFile(string filename)
        {
            CSImage csImage = FromImageFile(filename);
            if (csImage == null) csImage = FromTextFile(filename);
            if (csImage != null)
            {
                int width = csImage.Width;
                int height = csImage.Height;
                int pmin = (int)Math.Ceiling(0.008 * width * height);
                int pmax = (int)Math.Ceiling(0.992 * width * height);
                byte[] value = new byte[width * height];
                int index = 0;
                for (int i = 0; i < height; i++)
                    for (int j = 0; j < width; j++)
                        value[index++] = csImage.Red[i, j];
                Array.Sort(value);
                byte minr = (byte)value[pmin];
                byte maxr = (byte)value[pmax];
                index = 0;
                for (int i = 0; i < height; i++)
                    for (int j = 0; j < width; j++)
                        value[index++] = csImage.Green[i, j];
                Array.Sort(value);
                byte ming = (byte)value[pmin];
                byte maxg = (byte)value[pmax];
                index = 0;
                for (int i = 0; i < height; i++)
                    for (int j = 0; j < width; j++)
                        value[index++] = csImage.Blue[i, j];
                Array.Sort(value);
                byte minb = (byte)value[pmin];
                byte maxb = (byte)value[pmax];
                csImage.amin = 0.1 * minr + 0.6 * ming + 0.3 * minb;
                csImage.amax = 0.1 * maxr + 0.6 * maxg + 0.3 * maxb;
            }
            return csImage;
        }

        private static CSImage FromImageFile(string filename)
        {
            CSImage csImage = null;
            try
            {
                using (Image image = Image.FromFile(filename))
                {
                    int width = image.Width;
                    int height = image.Height;
                    csImage = new CSImage(width, height);
                    Rectangle rectangle = new Rectangle(0, 0, width, height);
                    using (Bitmap bitmap = new Bitmap(width, height,
                        PixelFormat.Format24bppRgb))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.DrawImage(image, 0, 0, width, height);
                        }
                        BitmapData bitmapData = bitmap.LockBits(rectangle,
                            ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                        IntPtr ptr = bitmapData.Scan0;
                        byte[] rgbValues = new byte[width * height * 3];
                        Marshal.Copy(ptr, rgbValues, 0, rgbValues.Length);
                        int index = 0;
                        for (int i = 0; i < height; i++)
                        {
                            for (int j = 0; j < width; j++)
                            {
                                csImage.Red[i, j] = rgbValues[index++];
                                csImage.Green[i, j] = rgbValues[index++];
                                csImage.Blue[i, j] = rgbValues[index++];
                            }
                        }
                        bitmap.UnlockBits(bitmapData);
                    }
                }
            }
            catch { }
            return csImage;
        }

        private static CSImage FromTextFile(string filename)
        {
            CSImage csImage = null;
            try
            {
                StreamReader stream = new StreamReader(filename);
                string line = stream.ReadLine();
                string[] arr = line.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                int height = Convert.ToInt32(arr[0]);
                int width = Convert.ToInt32(arr[1]);
                csImage = new CSImage(width, height);
                for (int i = 0; i < height; i++)
                {
                    line = stream.ReadLine();
                    arr = line.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < width; j++)
                    {
                        int index = j * 3;
                        csImage.Red[i, j] = Convert.ToByte(arr[index++]);
                        csImage.Green[i, j] = Convert.ToByte(arr[index++]);
                        csImage.Blue[i, j] = Convert.ToByte(arr[index++]);
                    }
                }
                stream.Close();
            }
            catch { }
            return csImage;
        }

        #endregion

        #region Convert

        public Bitmap ToBitmap()
        {
            if (width == 0 || height == 0 ||
                red == null || green == null || blue == null) return null;
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Rectangle rectangle = new Rectangle(0, 0, width, height);
            BitmapData bitmapData = bitmap.LockBits(rectangle,
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr = bitmapData.Scan0;
            byte[] rgbValues = new byte[width * height * 3];
            int index = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    rgbValues[index++] = Red[i, j];
                    rgbValues[index++] = Green[i, j];
                    rgbValues[index++] = Blue[i, j];
                }
            }
            Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }

        #endregion

        #region Save

        public void Save(string filename)
        {
            StreamWriter stream = new StreamWriter(filename);
            stream.WriteLine(height + " " + width);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    stream.Write(
                        Red[i, j] + " " +
                        Green[i, j] + " " +
                        Blue[i, j] + " ");
                }
                stream.WriteLine();
            }
            stream.Close();
        }

        #endregion

        #region Contrast Stretching

        public void ContrastStretching()
        {
            ContrastStretching(Red);
            ContrastStretching(Green);
            ContrastStretching(Blue);
        }

        private void ContrastStretching(byte[,] channel)
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    int value = (int)
                        (255 * (channel[i, j] - amin) / (amax - amin));
                    if (value <= 0) channel[i, j] = 0;
                    else
                        if (value >= 255) channel[i, j] = 255;
                        else channel[i, j] = (byte)value;
                }
        }

        #endregion

        #region Sharpening

        public void Sharpening()
        {
            Sharpening(Red);
            Sharpening(Green);
            Sharpening(Blue);
        }

        private void Sharpening(byte[,] channel)
        {   
            int[,] mask = {
                {0, -2, 0},
                {-2, 10, -2},
                {0, -2, 0},
            };
            Filtering(channel, mask, 2);
        }

        private void Filtering(byte[,] channel, int[,] mask, int weight)
        {
            int[,] m = new int[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    m[i, j] = channel[i, j];
            for (int i = 1; i < height - 1; i++)
                for (int j = 1; j < width - 1; j++)
                {
                    int tmp = 0;
                    for (int u = -1; u <= 1; u++)
                        for (int v = -1; v <= 1; v++)
                            tmp += channel[i + u, j + v] * mask[u + 1, v + 1];
                    m[i, j] = tmp / weight;
                }
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                {
                    if (m[i, j] <= 0) channel[i, j] = 0;
                    else
                        if (m[i, j] >= 255) channel[i, j] = 255;
                        else channel[i, j] = (byte)m[i, j];
                }
        }

        #endregion

        #region Smoothing

        public void Smoothing()
        {
            Smoothing(Red);
            Smoothing(Green);
            Smoothing(Blue);
        }

        private void Smoothing(byte[,] channel)
        {
            int[,] mask = {
                {1, 1, 1},
                {1, 2, 1},
                {1, 1, 1},
            };
            Filtering(channel, mask, 10);
        }

        #endregion

        public void CircleDetection()
        {

        }
    }
}
