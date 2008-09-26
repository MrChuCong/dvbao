using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.IO;
using System.Drawing.Drawing2D;

namespace TileMapEditor
{
    public enum eImageSet
    {
        Decoration,
        Enemy,
        Item
    }
    public partial class MainFrm : Form
    {
        public static string s_XmlMapFilename = "";
        public static string s_ImageFilename = "";
        public static string s_BinaryFilename = "";
        public static string s_DecoratateFolder = "";
        public static string s_ItemsFolder = "";
        public static string s_ResourceFolder = "";
        public static int s_Time = 400;

        private static readonly int k_DistanceThumbs = 20;
        private static List<AdvanceImage> listDecorativeImage;
        private static List<AdvanceImage> listItemsImage;
        private static List<AdvanceImage> listResourceImage;

        private PlayingMap playingMap;
        private ResourceMap resourceMap;
        private int selectedImage=0;
        private eImageSet imageSet = eImageSet.Decoration;
        private bool isResourceMap=false;
        private OptionsFrm optionDiaglog;
        private LoadPlayingMapFrm loadPlayingMapDiaglog;
        private SaveFileDialog saveDialog;
        private OpenFileDialog openDialog;
        private CreateMapFrm createResourceMapDialog;
        private eBackGround currentBackground;
        InputSceneFrm inputSceneDialog;
        
        private int maxY = 0;
        private int maxX = 0;

        public MainFrm()
        {
            InitializeComponent();
            playingMap = new PlayingMap();
            resourceMap = new ResourceMap();
            listDecorativeImage = new List<AdvanceImage>();
            listItemsImage = new List<AdvanceImage>();
            listResourceImage = new List<AdvanceImage>();
            this.KeyPreview = true;
            KeyDown += new KeyEventHandler(MainFrm_KeyDown);            
            string m_startuppath = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
            m_startuppath = m_startuppath.Replace(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].Name, "");
            s_DecoratateFolder = m_startuppath + "Decoration";
            s_ItemsFolder = m_startuppath + "Items";
            s_ResourceFolder = m_startuppath + "Resource";
            optionDiaglog = new OptionsFrm();
            loadPlayingMapDiaglog = new LoadPlayingMapFrm();
            createResourceMapDialog = new CreateMapFrm();
            saveDialog = new SaveFileDialog();
            openDialog = new OpenFileDialog();
            inputSceneDialog = new InputSceneFrm();
            LoadImageSets();
        }

        private void UpdateMap()
        {
            if (isResourceMap)
                picMap.Image = resourceMap.ImgMap;
            else
                picMap.Image = playingMap.ImgMap;
            picMap.Refresh();
        }

        private void UpdateLocationMap()
        {
            int x = (splitContainer1.Panel1.Width - picMap.Width) / 2;
            int y = (splitContainer1.Panel1.Height - picMap.Height) / 2;
            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;
            picMap.Location = new Point(x,y);
        }

        private void ChangeBackground(eBackGround color)
        {
            if (isResourceMap)
               resourceMap.ChangeBackground(color);
            else
               playingMap.ChangeBackground(color);;
            picMap.Refresh();
        }

        private void ChangeToGirdView(bool value)
        {
            if (isResourceMap)
                resourceMap.ChangeToGirdView(value);
            else
                playingMap.ChangeToGirdView(value);
            picMap.Refresh();
        }
                
        private void MainFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                UpdateMap();
            }
        }
        
		#region Menu's events

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void LightToolStripMenuItemClick(object sender, EventArgs e)
        {
        	UncheckAllBackgroundColor();
        	lightToolStripMenuItem.Checked = true;
        	ChangeBackground(eBackGround.light);
            currentBackground = eBackGround.light;
        }
        
        private void WaterToolStripMenuItemClick(object sender, EventArgs e)
        {
        	UncheckAllBackgroundColor();
        	waterToolStripMenuItem.Checked = true;
        	ChangeBackground(eBackGround.water);
            currentBackground = eBackGround.water;
        }
        
        private void FireToolStripMenuItemClick(object sender, EventArgs e)
        {
        	UncheckAllBackgroundColor();
        	fireToolStripMenuItem.Checked = true;
        	ChangeBackground(eBackGround.fire);
            currentBackground = eBackGround.fire;
        }
        
        private void DarkToolStripMenuItemClick(object sender, EventArgs e)
        {
        	UncheckAllBackgroundColor();
        	darkToolStripMenuItem.Checked = true;
        	ChangeBackground(eBackGround.dark);
            currentBackground = eBackGround.dark;
        }
        
        private void SkyToolStripMenuItemClick(object sender, EventArgs e)
        {        	
        	UncheckAllBackgroundColor();
        	skyToolStripMenuItem.Checked = true;
        	ChangeBackground(eBackGround.sky);
            currentBackground = eBackGround.sky;
        }

        private void transparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllBackgroundColor();
            transparentToolStripMenuItem.Checked = true;
            ChangeBackground(eBackGround.transparent);
            currentBackground = eBackGround.transparent;
        }

        private void GridToolStripMenuItemClick(object sender, EventArgs e)
        {
        	gridToolStripMenuItem.Checked = !gridToolStripMenuItem.Checked;
            toolStripGridBtn.Checked = !toolStripGridBtn.Checked;
        	ChangeToGirdView(gridToolStripMenuItem.Checked); 
        }
        
        private void decorativeImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decorativeImagesToolStripMenuItem.Checked = toolStripDecorationBtn.Checked = true;
            ItemsImagesToolStripMenuItem.Checked = ResourceImagesToolStripMenuItem.Checked = false;
            toolStripResourceBtn.Checked = toolStripItemsBtn.Checked = false;
            imageSet = eImageSet.Decoration;
            selectedImage = 0;
            DrawThumbnail();
        }

        private void enemyImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decorativeImagesToolStripMenuItem.Checked = ResourceImagesToolStripMenuItem.Checked= false;
            toolStripResourceBtn.Checked = toolStripDecorationBtn.Checked = false;
            ItemsImagesToolStripMenuItem.Checked = toolStripItemsBtn.Checked = true;
            imageSet = eImageSet.Enemy;
            selectedImage = 0;
            DrawThumbnail();
        }
        
        private void spriteImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decorativeImagesToolStripMenuItem.Checked = ItemsImagesToolStripMenuItem.Checked = false;
            toolStripItemsBtn.Checked = toolStripDecorationBtn.Checked = false;
            ResourceImagesToolStripMenuItem.Checked = toolStripResourceBtn.Checked = true;
            imageSet = eImageSet.Item;
            selectedImage = 0;
            DrawThumbnail();
        }
                
        #endregion

        #region Mouse's events

        private void PicThumbnailMouseDown(object sender, MouseEventArgs e)
        {
        	int x = e.X / (AdvanceImage.k_WidthThumb + k_DistanceThumbs);   
        	int y = e.Y / (AdvanceImage.k_HeightThumb + k_DistanceThumbs);  
        	int t = picThumbnail.Width / (AdvanceImage.k_WidthThumb + k_DistanceThumbs);   
            int count =  listDecorativeImage.Count;
            if (imageSet == eImageSet.Item)
                count = listResourceImage.Count;
            else if (imageSet == eImageSet.Enemy)
                count = listItemsImage.Count;
            if ((x >= 0) && (y >= 0) && (y * t + x) < count)
            {                    
                selectedImage = y * t + x;
                DrawThumbnail();
            }
        }

        private void picMap_MouseDown(object sender, MouseEventArgs e)
        {   
        	if(e.X < 0 || e.X >= picMap.Width)
        		return;
        	if(e.Y < 0 || e.Y >= picMap.Height)
        		return;
            try
            {                
                int tempTileW = playingMap.TileWidth;
                int tempTileH = playingMap.TileHeight;
                if (isResourceMap)
                {
                    tempTileW = resourceMap.TileWidth;
                    tempTileH = resourceMap.TileHeight;
                }
                int x = e.X / tempTileW;
                int y = e.Y / tempTileH;
                if (Control.ModifierKeys != Keys.Control)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        AdvanceImage tempImg;
                        switch (imageSet)
                        {
                            case eImageSet.Enemy:
                                tempImg = listItemsImage[selectedImage];
                                break;
                            case eImageSet.Decoration:
                                tempImg = listDecorativeImage[selectedImage];
                                break;
                            default:
                                tempImg = listResourceImage[selectedImage];
                                break;
                        }
                        Point temp = new Point(e.X - tempImg.Img.Width / 2, e.Y - tempImg.Img.Height / 2);
                        x = temp.X / tempTileW;
                        y = temp.Y / tempTileH;
                        tempImg.Location = new Point(x, y);
                        if (imageSet == eImageSet.Enemy)
                            playingMap.AddItemsImage(tempImg.Clone());
                        else if (imageSet == eImageSet.Decoration)
                            playingMap.AddDecorateImage(tempImg.Clone());
                        else
                            resourceMap.AddImage(tempImg.Clone());
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        if (inputSceneDialog.ShowDialog() == DialogResult.OK)
                        {   
                            ScenceMilestone sm = new ScenceMilestone(new Point(x,y),InputSceneFrm.Scene, new Point(InputSceneFrm.X, InputSceneFrm.Y));                            
                            playingMap.AddScene(sm);
                        }
                    }
                }
                else
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (imageSet == eImageSet.Decoration)
                            playingMap.RemoveDecorateImage(x, y);
                        else if (imageSet == eImageSet.Enemy)
                            playingMap.RemoveItemsImage(x, y);
                        else
                            resourceMap.RemoveImage(x, y);
                    }
                    else if (e.Button == MouseButtons.Right)
                    {                        
                        playingMap.RemoveScene(x, y);
                    }
                }
                UpdateMap();
            }
            catch { };
        
        }

        private void picMap_MouseMove(object sender, MouseEventArgs e)
        {    
            try
            {
                if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                {
            		picMap_MouseDown(sender,e);
            		return;
                }
                int tempTileW = playingMap.TileWidth;
                int tempTileH = playingMap.TileHeight;
                if (isResourceMap)
                {
                    tempTileW = resourceMap.TileWidth;
                    tempTileH = resourceMap.TileHeight;
                }
                int x = e.X / tempTileW;
                int y = e.Y / tempTileH;
                if (Control.ModifierKeys != Keys.Control)
                {                    	
                    if (!isResourceMap)
                    {
                        picMap.Image = (Bitmap)playingMap.ImgMap.Clone();
                    }
                    else
                    {
                        picMap.Image = (Bitmap)resourceMap.ImgMap.Clone();
                    }
                    Graphics g = Graphics.FromImage(picMap.Image);
                    AdvanceImage tempImg;
                    switch (imageSet)
                    {
                        case eImageSet.Enemy:
                            tempImg = listItemsImage[selectedImage];
                            break;
                        case eImageSet.Decoration:
                            tempImg = listDecorativeImage[selectedImage];
                            break;
                        default:
                            tempImg = listResourceImage[selectedImage];
                            break;
                    }  
                    Point temp = new Point(e.X - tempImg.Img.Width / 2, e.Y - tempImg.Img.Height / 2);                        
                    x = temp.X / tempTileW;
                    y = temp.Y / tempTileH;                    
                    g.DrawImage(tempImg.Img, x * tempTileW, y * tempTileH, tempImg.Img.Width, tempImg.Img.Height);
                    picMap.Refresh();
                }
                else
                {
                    UpdateMap();
                }
                toolStriplbl.Text = "(" + x.ToString() + "," + y.ToString() + ")";
            }
            catch { };
                  
        }

        private void picMap_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void picMap_MouseLeave(object sender, EventArgs e)
        {        	
            UpdateMap();
        }

        #endregion

        private void UncheckAllBackgroundColor()
        {
        	transparentToolStripMenuItem.Checked = lightToolStripMenuItem.Checked = waterToolStripMenuItem.Checked = fireToolStripMenuItem.Checked = darkToolStripMenuItem.Checked =skyToolStripMenuItem.Checked = false;
   		}
      
        private void DrawThumbnail()
        {
        	Font font = new Font(FontFamily.GenericSerif, 10);  
        	StringFormat f = new StringFormat();
        	f.Alignment = StringAlignment.Center;
            f.LineAlignment = StringAlignment.Center;
            int count = listDecorativeImage.Count;
            switch (imageSet)
            {
                case eImageSet.Enemy:
                    count = listItemsImage.Count;
                    break;
                case eImageSet.Decoration:
                    count = listDecorativeImage.Count;
                    break;
                default:
                    count = listResourceImage.Count;
                    break;
            }
            try
            {
	            int h = picThumbnail.Height;			
	            int w = splitContainer1.Panel2.Width;
	            int y = k_DistanceThumbs;
	            int temp = 0;            
	            for (int i = 0, j = 0; i < count; i++, j++)
	            {
	                temp++;
	                int x = (j + 1) * k_DistanceThumbs + j * AdvanceImage.k_WidthThumb;
	                if (x + AdvanceImage.k_WidthThumb > w)
	                {
	                    y += k_DistanceThumbs + AdvanceImage.k_HeightThumb;
	                    j = 0;
	                    maxY++;
	                    temp = 0;
	                }
	                if (maxX < temp)
	                    maxX = temp;
	            }
	            h = y + 200;
	            Image buffer = new Bitmap(w, h);
	            Graphics bufferGraphic = Graphics.FromImage(buffer);
	            bufferGraphic.Clear(Color.White);
	
	            y = k_DistanceThumbs;
	            for (int i = 0, j = 0; i < count; i++, j++)
	            {
	                int x = (j + 1) * k_DistanceThumbs + j * AdvanceImage.k_WidthThumb;
	                if (x + AdvanceImage.k_WidthThumb > w)
	                {
	                    y += k_DistanceThumbs + AdvanceImage.k_HeightThumb;
	                    j = 0;
	                    x = (j + 1) * k_DistanceThumbs + j * AdvanceImage.k_WidthThumb;
	                }
	                AdvanceImage img;
	                switch (imageSet)
	                {
	                    case eImageSet.Enemy:
	                        img = listItemsImage[i];
	                        break;
	                    case eImageSet.Decoration:
	                        img = listDecorativeImage[i];
	                        break;
	                    default:
	                        img = listResourceImage[i];
	                        break;
	                }  
	                Image thumb = img.Thumbnail;
	                bufferGraphic.DrawImage(thumb, x + (AdvanceImage.k_WidthThumb - thumb.Width) / 2, y + (AdvanceImage.k_HeightThumb - thumb.Height) / 2, thumb.Width, thumb.Height);
	             //   bufferGraphic.DrawString(img.NameImg, font, new SolidBrush(Color.Black), new Rectangle(x, y + AdvanceImage.k_HeightThumb + 1, AdvanceImage.k_WidthThumb, k_DistanceThumbs - 1), f);
	
	                if (i == selectedImage)
	                    bufferGraphic.DrawRectangle(new Pen(Color.Gold, 3), x, y, AdvanceImage.k_WidthThumb, AdvanceImage.k_HeightThumb);
	
	            }
	            
	            picThumbnail.Height = h;
		        picThumbnail.Width = w;	        
		        picThumbnail.Image = new Bitmap(w, h);
		        Graphics thumbnailGraphic = Graphics.FromImage(picThumbnail.Image);
		        thumbnailGraphic.DrawImage(buffer, 0, 0);
		        picThumbnail.Refresh();
	        }
            catch
            {
            }
            
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
            optionDiaglog.LoadValue();
            if (optionDiaglog.ShowDialog() == DialogResult.OK)
            {
                LoadImageSets();                
            }
        }

        private void LoadImageSets()
        {
            listDecorativeImage.Clear();
            listItemsImage.Clear();
            listResourceImage.Clear();
            foreach (string file in Directory.GetFiles(s_DecoratateFolder))
            {
                try
                {
                    AdvanceImage newImg = new AdvanceImage(file);
                    listDecorativeImage.Add(newImg);
                }
                catch { };
            }

            foreach (string file in Directory.GetFiles(s_ItemsFolder))
            {
                try
                {
                    AdvanceImage newImg = new AdvanceImage(file);
                    listItemsImage.Add(newImg);
                }
                catch { };
            }

            foreach (string file in Directory.GetFiles(s_ResourceFolder))
            {
                try
                {
                    AdvanceImage newImg = new AdvanceImage(file);
                    listResourceImage.Add(newImg);
                }
                catch { };
            }
            DrawThumbnail();
        }

        private void RestoreAll()
        {
            picMap.Dock = DockStyle.None;
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            picMap.BackgroundImage = null;
            toolStripExportMapBtn.Enabled = toolStripGridBtn.Enabled = toolStripDecorationBtn.Enabled = toolStripItemsBtn.Enabled = toolStripResourceBtn.Enabled = toolStripColorBtn.Enabled = true;
            viewToolStripMenuItem.Enabled = backgroundColorToolStripMenuItem.Enabled = true;
        }
              
        // create resource map
        private void createResourceMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (createResourceMapDialog.ShowDialog() == DialogResult.OK)
            {
                RestoreAll();
                resourceMap.CreateMap(CreateMapFrm.MapWidth, CreateMapFrm.MapHeight, CreateMapFrm.TileWidth, CreateMapFrm.TileHeight);                                 
                picMap.Height = resourceMap.ImgMap.Height;
                picMap.Width = resourceMap.ImgMap.Width;
                picMap.Image = resourceMap.ImgMap;
                UpdateLocationMap();
                picMap.Refresh();
                isResourceMap = true;                
                exportPlayingMapToolStripMenuItem.Enabled = false;
                exportResourceMapToolStripMenuItem.Enabled = true;
                loadResourceMapToolStripMenuItem.Enabled = true;
                toolStripLoadResourceBtn.Enabled = true;
                loadPlayingMapToolStripMenuItem.Enabled = false;
                toolStripLoadMapBtn.Enabled = false;
                spriteImagesToolStripMenuItem_Click(sender,e);
                transparentToolStripMenuItem_Click(sender,e);
            }
        }
        
        // create playing map
        private void CreatePlayingMapToolStripMenuItemClick(object sender, EventArgs e)
        {
        	if (createResourceMapDialog.ShowDialog() == DialogResult.OK)
            {
        		RestoreAll();
        		playingMap.CreateMap(CreateMapFrm.MapWidth, CreateMapFrm.MapHeight, CreateMapFrm.TileWidth, CreateMapFrm.TileHeight);                                 
                picMap.Height = playingMap.ImgMap.Height;
                picMap.Width = playingMap.ImgMap.Width;
                picMap.Image = playingMap.ImgMap;
                UpdateLocationMap();
                picMap.Refresh();
                isResourceMap = false;
                exportPlayingMapToolStripMenuItem.Enabled = true;
                exportResourceMapToolStripMenuItem.Enabled = false;
                loadPlayingMapToolStripMenuItem.Enabled = true;
                exportResourceMapToolStripMenuItem.Enabled = false;
                loadResourceMapToolStripMenuItem.Enabled = false;
                toolStripLoadResourceBtn.Enabled = false;
                toolStripLoadMapBtn.Enabled = true;
                enemyImagesToolStripMenuItem_Click(sender,e);
                LightToolStripMenuItemClick(sender,e);
        	}
        }

        // load Map
        private void loadPlayingMapToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Refresh();            
            openDialog.Filter = "Playing map|*.map|All files|*.*";
            openDialog.FileName = "";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
            	RestoreAll();                
                playingMap.LoadMap(openDialog.FileName);
                playingMap.ReDrawMap();
                picMap.Height = playingMap.ImgMap.Height;
                picMap.Width = playingMap.ImgMap.Width;
                picMap.Image = playingMap.ImgMap;
                UpdateLocationMap();
                picMap.Refresh();
                isResourceMap = false;                
                exportPlayingMapToolStripMenuItem.Enabled = true;
                exportResourceMapToolStripMenuItem.Enabled = false;
                loadResourceMapToolStripMenuItem.Enabled = false;
                toolStripLoadResourceBtn.Enabled = false;
                decorativeImagesToolStripMenuItem_Click(sender,e);
                s_Time = playingMap.PlayingTime;
            }
        }
        
        private void loadResourceMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
        	Refresh();      
            openDialog.Filter = "Resource map|*.rmp|All files|*.*";
            openDialog.FileName = "";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                resourceMap.LoadResourceMap(openDialog.FileName);
                UpdateMap();
            }
        }

        // Export
        private void exportPlayingMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDialog.Filter = "Playing map|*.map|All files|*.*";
            saveDialog.FileName = "";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                playingMap.PlayingTime = s_Time;
                playingMap.ExportMap(saveDialog.FileName);
            }
        }

        private void exportResourceMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDialog.Filter = "Resource map|*.rmp|All files|*.*";
            saveDialog.FileName = "";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                resourceMap.ExportMap(saveDialog.FileName);
            }
        }

        private void toolStripExportMapBtn_Click(object sender, EventArgs e)
        {
            if (isResourceMap)
                exportResourceMapToolStripMenuItem_Click(sender, e);
            else
                exportPlayingMapToolStripMenuItem_Click(sender, e);
        }

        private void toolStripColorBtn_Click(object sender, EventArgs e)
        {
            if ((int)currentBackground < 5)
                currentBackground++;
            else
                currentBackground = 0;
            switch (currentBackground)
            {
                case eBackGround.dark:
                    DarkToolStripMenuItemClick(sender, e);
                    break;
                case eBackGround.fire:
                    FireToolStripMenuItemClick(sender, e);
                    break;
                case eBackGround.light:
                    LightToolStripMenuItemClick(sender, e);
                    break;
                case eBackGround.sky:
                    SkyToolStripMenuItemClick(sender, e);
                    break;
                case eBackGround.water:
                    WaterToolStripMenuItemClick(sender, e);
                    break;
                case eBackGround.transparent:
                    transparentToolStripMenuItem_Click(sender, e);
                    break;
            }
        }

        private void addSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
               
      
    }
}
