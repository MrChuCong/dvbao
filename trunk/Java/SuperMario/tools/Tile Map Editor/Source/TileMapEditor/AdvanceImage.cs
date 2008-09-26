using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;

namespace TileMapEditor
{
    public class AdvanceImage
    {
        public static readonly int k_WidthThumb = 50;
        public static readonly int k_HeightThumb = 50;
        
        private string m_strNameImg; 

        public string NameImg
        {
            get { return m_strNameImg; }            
        }
        private Bitmap m_img;

        public Bitmap Img  
        {
            get { return m_img; }
            set { m_img = value; }
        }
        private Bitmap m_imgThumbnail;  

        public Bitmap Thumbnail
        {
            get { return m_imgThumbnail; }
            set { m_imgThumbnail = value; }
        }

        private int m_iID;

        public int ID
        {
            get { return m_iID; }
            set { m_iID = value; }
        }

        private Point m_iLocation;

        public Point Location
        {
            get { return m_iLocation; }
            set { m_iLocation = value; }
        }

        public AdvanceImage()
        {
            
        }

        public AdvanceImage(string path)
        {
            m_img = (Bitmap)Bitmap.FromFile(path);            
            string[] temp = path.Split('\\');
            m_strNameImg = temp[temp.Length-1];
            temp = m_strNameImg.Split('.');
            string[] temp1 = temp[0].Split('_');
            try
            {
                ID = int.Parse(temp1[0]);
            }
            catch { };
            GetThumbnail();
        }
        
        private void GetThumbnail()
        {
            int dw = m_img.Width;
            int dh = m_img.Height;
            int tw = k_WidthThumb;
            int th = k_HeightThumb;
            if (dw > tw || dh > th)
            {
                double zw = (tw / (double)dw);
                double zh = (th / (double)dh);
                double z = (zw <= zh) ? zw : zh;
                dw = (int)(dw * z);
                dh = (int)(dh * z);
            }
            m_imgThumbnail = new Bitmap(dw, dh);
            Graphics g = Graphics.FromImage(m_imgThumbnail);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(m_img, 0, 0, dw, dh);
            g.Dispose();
        }

        public AdvanceImage Clone()
        {
            AdvanceImage re = new AdvanceImage();
            re.m_iID = m_iID;
            re.m_iLocation = m_iLocation;
            re.m_img = m_img;
            re.m_imgThumbnail = m_imgThumbnail;
            re.m_strNameImg = m_strNameImg;
            return re;
        }
    }
}
