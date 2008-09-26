using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace TileMapEditor
{
	/// <summary>
	/// Description of ResourceMap.
	/// </summary>
	public class ResourceMap:TileMap
	{		
		private List<AdvanceImage> m_arrItems = new List<AdvanceImage>();
        				
        public ResourceMap()
		{
        }

        public void LoadResourceMap(string path)
        {
            m_arrItems.Clear();
            try
            {
                BinaryReader br = new BinaryReader(new FileStream(path, FileMode.Open));
                int count = br.ReadByte();
                for (int i = 0; i < count; i++)
                {
                    int ID = i + 1;
                    int x = br.ReadUInt16();
                    int y = br.ReadUInt16();
                    int w = br.ReadByte();
                    int h = br.ReadByte();
                    string file = MainFrm.s_ResourceFolder + "\\";
                    if (ID < 10)
                        file += "00";
                    else if (ID < 100)
                        file += "0";
                    file += ID + "_i.png";
                    AdvanceImage img = new AdvanceImage(file);
                    x = x / m_iTileWidth;
                    y = y / m_iTileHeight;
                    img.Location = new Point(x, y);
                    m_arrItems.Add(img);
                }
                br.Close();
                ReDrawMap();
            }
            catch { };
        }

        public void CreateMap(int w, int h, int tw, int th)
        {
            m_iWidth = w;
            m_iHeight = h;
            m_iTileWidth = tw;
            m_iTileHeight = th;
            m_imgMap = new Bitmap(w*tw, h*th);
            m_arrItems = new List<AdvanceImage>();
            ReDrawMap();
        }

        public override void ReDrawMap()
        {
            Graphics g = Graphics.FromImage(m_imgMap);
            g.Clear(m_backgroundColor);
            for (int i = 0; i < m_arrItems.Count; i++)
            {
                g.DrawImage(m_arrItems[i].Img, m_arrItems[i].Location.X * m_iTileWidth, m_arrItems[i].Location.Y * m_iTileHeight, m_arrItems[i].Img.Width, m_arrItems[i].Img.Height);
            }
            if (m_isGridView)
                DrawGrid();
        }

        public void AddImage(AdvanceImage img)
        {
            m_arrItems.Add(img);
            ReDrawMap();
        }

        public void RemoveImage(int x, int y)
        {
            for (int i = 0; i < m_arrItems.Count; i++)
            {
                int tempX = m_arrItems[i].Location.X + m_arrItems[i].Img.Width / m_iTileWidth -1;
                int tempY = m_arrItems[i].Location.Y + m_arrItems[i].Img.Height / m_iTileHeight -1;
                if (x <= tempX && x >= m_arrItems[i].Location.X)
                    if (y <= tempY && y >= m_arrItems[i].Location.Y)
                    {
                        m_arrItems.RemoveAt(i);
                        break;
                    }
            }
            ReDrawMap();
        }

        public override void ExportMap(string filename)
        {
            BinaryWriter bw = new BinaryWriter(new FileStream(filename, FileMode.Create));            
            bw.Write((byte)m_arrItems.Count);
            m_arrItems.Sort(new ComparerAdvanceImage());            
            for (int i = 0; i < m_arrItems.Count; i++)
            {
                int temp = m_arrItems[i].Location.X * m_iTileWidth;
                bw.Write((ushort)temp);
                temp = m_arrItems[i].Location.Y * m_iTileHeight;
                bw.Write((ushort)temp);
                bw.Write((byte)m_arrItems[i].Img.Width);
                bw.Write((byte)m_arrItems[i].Img.Height);
            }            
            bw.Close();
            m_imgMap.Save(filename.Substring(0,filename.Length-4) + ".png", ImageFormat.Png);
		}

	}

    class ComparerAdvanceImage : Comparer<AdvanceImage>
    {
        public ComparerAdvanceImage()
        {
        }
        public override int Compare(AdvanceImage x, AdvanceImage y)
        {
            if (x.ID > y.ID)
                return 1;
            else if (x.ID < y.ID)
                return -1;
            return 0;
        }
    }


}
