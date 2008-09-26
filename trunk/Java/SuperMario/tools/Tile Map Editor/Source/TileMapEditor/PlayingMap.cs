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
    public class ScenceMilestone
    {
        private Point m_Location;

        public Point Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }
        private int m_Scene;

        public int Scene
        {
            get { return m_Scene; }
            set { m_Scene = value; }
        }
        private Point m_SceneLocation;

        public Point SceneLocation
        {
            get { return m_SceneLocation; }
            set { m_SceneLocation = value; }
        }

        public ScenceMilestone()
        {
        }

        public ScenceMilestone(Point location, int scene, Point sceneLocation)
        {
            Location = new Point(location.X,location.Y);
            Scene = scene;
            SceneLocation = new Point(sceneLocation.X,sceneLocation.Y);
        }

    }
	public class PlayingMap:TileMap
	{
        private List<AdvanceImage> m_arrDecorate = new List<AdvanceImage>();
        private List<AdvanceImage> m_arrItems = new List<AdvanceImage>();
        private List<ScenceMilestone> m_arrScene = new List<ScenceMilestone>();
        private int m_iPlayingTime;

        public int PlayingTime
        {
            get { return m_iPlayingTime; }
            set { m_iPlayingTime = value; }
        }        
		private int[] m_arrData;
		
        private Image m_imgPlayingTileSet;
        
		public Image ImgTileSet 
        {
			get { return m_imgPlayingTileSet; }
			set { m_imgPlayingTileSet = value; }
		}
        
		public PlayingMap()
		{				
		}
		
		public void CreateMap(int w, int h, int tw, int th)
		{
			m_iWidth = w;
			m_iHeight = h;
			m_iTileWidth = tw;
			m_iTileHeight = th;			
			m_imgMap = new Bitmap(m_iWidth * m_iTileWidth, m_iHeight * m_iTileHeight);
			m_arrData = new int[m_iWidth * m_iHeight];
			for(int i =0; i<m_arrData.Length;i++)
			{
				m_arrData[i] = 0;
			}			
			m_arrDecorate = new List<AdvanceImage>();
			m_arrItems = new List<AdvanceImage>();
		}
		                      
        public void LoadMap(string path)
        {
        	int id=0;
        	try
	        {
	        	BinaryReader br = new BinaryReader(new FileStream(path, FileMode.Open));
	        	int tempWidth = br.ReadUInt16();
                int tempHeight = br.ReadUInt16();
                int tempTileWidth = br.ReadUInt16();
                int tempTileHeight = br.ReadUInt16();                                
				m_arrData = new int[m_iWidth * m_iHeight];
				for(int i =0; i<m_arrData.Length;i++)
				{
					m_arrData[i] = 0;
				}	
                m_arrDecorate = new List<AdvanceImage>();
                m_arrItems = new List<AdvanceImage>();
                m_arrScene = new List<ScenceMilestone>();
                for (int i = 0; i < tempHeight; i++)
	            {
                    for (int j = 0; j < tempWidth; j++)
	                {                        
                        id = br.ReadByte();
                        if (id != 0)
                        {
                            string file = String.Empty;
                            if (id < 10)
                                file = MainFrm.s_ItemsFolder + "\\" + "00" + id + "_i.png";
                            else if (id < 100)
                                file = MainFrm.s_ItemsFolder + "\\" + "0" + id + "_i.png"; 
                            else
                            	file = MainFrm.s_ItemsFolder + "\\" + id + "_i.png";
                            AdvanceImage img = new AdvanceImage(file);
                            img.Location = new Point(j, i);
                            m_arrItems.Add(img);                            
                        }
	                }
	            }
                PlayingTime = br.ReadUInt16();
	        	int Red = br.ReadByte();
	        	int Green = br.ReadByte();
	        	int Blue = br.ReadByte();
	        	m_backgroundColor = Color.FromArgb(Red, Green, Blue);
	        	int count = br.ReadUInt16();
	        	for(int i=0 ; i< count ;i++)
	        	{	
	        		int ID = br.ReadByte();
	        		int x = br.ReadByte();
	        		int y = br.ReadByte();
                    string file = MainFrm.s_DecoratateFolder + "\\";
                    if (ID < 10)
                        file += "00";
                    else if (ID < 100)
                        file += "0";
                    file+= ID + "_d.png";
                    AdvanceImage img = new AdvanceImage(file);
	        		img.Location = new Point(x,y);
	        		m_arrDecorate.Add(img);
	        	}
                count = br.ReadByte();
                for (int i = 0; i < count; i++)
                {                    
                    int x = br.ReadByte();
                    int y = br.ReadByte();
                    int scene = br.ReadUInt16();
                    int sceneX = br.ReadByte();
                    int sceneY = br.ReadByte();
                    ScenceMilestone sm = new ScenceMilestone(new Point(x, y), scene, new Point(sceneX, sceneY));
                    m_arrScene.Add(sm);
                }

	        	br.Close();
        	}
        	catch
        	{
        		MessageBox.Show(id.ToString());
        		//MessageBox.Show(err.Message + "\n" + err.StackTrace,"Tile Map", MessageBoxButtons.OK,MessageBoxIcon.Error);
        	}
        }

        public override void ExportMap(string filename)
        {
            int[] temp = (int[])m_arrData.Clone();
            for (int i = 0; i < m_arrItems.Count; i++)
            {
                int id = m_arrItems[i].Location.Y * m_iWidth + m_arrItems[i].Location.X;
                temp[id] = m_arrItems[i].ID;
            }
        	BinaryWriter bw = new BinaryWriter(new FileStream(filename, FileMode.Create));            
            bw.Write((ushort)m_iWidth);
            bw.Write((ushort)m_iHeight);
            bw.Write((ushort)m_iTileWidth);
            bw.Write((ushort)m_iTileHeight);            
            for (int i = 0; i < m_iHeight; i++)
            {
                for (int j = 0; j < m_iWidth; j++)
                {
                	bw.Write((byte)temp[i * m_iWidth + j]);
                }
            }
            bw.Write((ushort)PlayingTime);
            bw.Write((byte)m_backgroundColor.R);
            bw.Write((byte)m_backgroundColor.G);
            bw.Write((byte)m_backgroundColor.B);
            bw.Write((ushort)m_arrDecorate.Count);
            for (int i = 0; i < m_arrDecorate.Count; i++)
            {
                bw.Write((byte)m_arrDecorate[i].ID);
                bw.Write((byte)m_arrDecorate[i].Location.X);
                bw.Write((byte)m_arrDecorate[i].Location.Y);
            }
            bw.Write((byte)m_arrScene.Count);
            for (int i = 0; i < m_arrScene.Count; i++)
            {
                bw.Write((byte)m_arrScene[i].Location.X);
                bw.Write((byte)m_arrScene[i].Location.Y);
                bw.Write((ushort)m_arrScene[i].Scene);
                bw.Write((byte)m_arrScene[i].SceneLocation.X);
                bw.Write((byte)m_arrScene[i].SceneLocation.Y);
            }
            bw.Close();
        }

        public override void ReDrawMap()
        {            
            Graphics g = Graphics.FromImage(m_imgMap);
            g.Clear(m_backgroundColor);

            for (int i = 0; i < m_arrDecorate.Count; i++)
            {
                g.DrawImage(m_arrDecorate[i].Img, m_arrDecorate[i].Location.X*m_iTileWidth,m_arrDecorate[i].Location.Y*m_iTileHeight,m_arrDecorate[i].Img.Width,m_arrDecorate[i].Img.Height);
            }           

            for (int i = 0; i < m_arrItems.Count; i++)
            {
                g.DrawImage(m_arrItems[i].Img, m_arrItems[i].Location.X * m_iTileWidth, m_arrItems[i].Location.Y * m_iTileHeight, m_arrItems[i].Img.Width, m_arrItems[i].Img.Height);

            }

            if(m_isGridView)
            {
                DrawGrid();
            }
            Font font = new Font(FontFamily.GenericMonospace, 7, FontStyle.Bold);
            for (int i = 0; i < m_arrScene.Count; i++)
            {
                Point temp = new Point(m_arrScene[i].Location.X * m_iTileWidth, m_arrScene[i].Location.Y * m_iTileHeight);
                g.FillRectangle(new SolidBrush(Color.Yellow), temp.X, temp.Y, 16, 16);
                g.DrawString(m_arrScene[i].Scene.ToString(), font, new SolidBrush(Color.Red), temp);
            }            
        }

        public void AddDecorateImage(AdvanceImage img)
        {
            m_arrDecorate.Add(img);
            ReDrawMap();
        }

        public void RemoveDecorateImage(int x, int y)
        {
            for (int i = 0; i < m_arrDecorate.Count; i++)
            {
                int tempX = m_arrDecorate[i].Location.X + m_arrDecorate[i].Img.Width/m_iTileWidth - 1;
                int tempY = m_arrDecorate[i].Location.Y + m_arrDecorate[i].Img.Height/m_iTileHeight - 1;
                if (x <= tempX && x >= m_arrDecorate[i].Location.X )
                    if (y <= tempY && y >= m_arrDecorate[i].Location.Y )
                    {
                        m_arrDecorate.RemoveAt(i);
                        break;
                    }
            }
            ReDrawMap();
        }

        public void AddItemsImage(AdvanceImage img)
        {    	
            m_arrItems.Add(img);
            ReDrawMap();        	
        }

        public void RemoveItemsImage(int x, int y)
        {
            for (int i = 0; i < m_arrItems.Count; i++)
            {
                int tempX = m_arrItems[i].Location.X + m_arrItems[i].Img.Width / m_iTileWidth - 1;
                int tempY = m_arrItems[i].Location.Y + m_arrItems[i].Img.Height / m_iTileHeight - 1;
                if (x <= tempX && x >= m_arrItems[i].Location.X)
                    if (y <= tempY && y >= m_arrItems[i].Location.Y)
                    {
                        m_arrItems.RemoveAt(i);
                        break;
                    }
            }
            ReDrawMap();
        }

        public void AddScene(ScenceMilestone sm)
        {
            m_arrScene.Add(sm);
            ReDrawMap();
        }

        public void RemoveScene(int x, int y)
        {
            for (int i = 0; i < m_arrScene.Count; i++)
            {
                if (x == m_arrScene[i].Location.X)
                    if (y == m_arrScene[i].Location.Y)
                    {
                        m_arrScene.RemoveAt(i);
                        break;
                    }
            }
            ReDrawMap();
        }
    }
}
