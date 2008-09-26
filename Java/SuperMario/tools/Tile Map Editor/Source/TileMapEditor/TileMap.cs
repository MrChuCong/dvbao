using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TileMapEditor
{
    public enum eBackGround
    {
        light,
        water,
        dark,
        fire,
        sky,
        transparent
    }

    public abstract class TileMap
    {
        protected int m_iWidth;
        protected int m_iHeight;
        protected int m_iTileWidth;
        protected int m_iTileHeight;
        public int TileWidth
        {
            get { return m_iTileWidth; }
            set { m_iTileWidth = value; }
        }

        public int TileHeight
        {
            get { return m_iTileHeight; }
            set { m_iTileHeight = value; }
        }
        protected bool m_isGridView;
        protected Color m_backgroundColor;
        protected Image m_imgMap;
        public Image ImgMap
        {
            get { return m_imgMap; }
            set { m_imgMap = value; }
        }

        public void ChangeBackground(eBackGround background)
        {
            switch (background)
            {
                case eBackGround.light:
                    m_backgroundColor = Color.FromArgb(92, 148, 252);
                    break;
                case eBackGround.dark:
                    m_backgroundColor = Color.FromArgb(0, 0, 0);
                    break;
                case eBackGround.water:
                    m_backgroundColor = Color.FromArgb(32, 56, 236);
                    break;
                case eBackGround.fire:
                    m_backgroundColor = Color.FromArgb(216, 40, 0);
                    break;
                case eBackGround.sky:
                    m_backgroundColor = Color.FromArgb(60, 188, 252);
                    break;
                case eBackGround.transparent:
                    m_backgroundColor = Color.Transparent;
                    break;
            }
            ReDrawMap();
        }

        public void ChangeToGirdView(bool value)
        {
            m_isGridView = value;
            ReDrawMap();
        }

        public void DrawGrid()
        {
            Graphics g = Graphics.FromImage(m_imgMap);
            Pen pen = new Pen(Color.White);
            for (int i = 0; i < m_iHeight; i++)
            {
                g.DrawLine(pen, 0, i * m_iTileHeight, m_iTileWidth * m_iWidth, i * m_iTileHeight);
            }
            for (int i = 0; i < m_iWidth; i++)
            {
                g.DrawLine(pen, i * m_iTileWidth, 0, i * m_iTileWidth, m_iHeight * m_iTileHeight);
            }
        }

        public abstract void ReDrawMap();
        public abstract void ExportMap(string filename);
    }
}
