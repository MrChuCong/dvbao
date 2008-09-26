import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.*;
import java.io.*;
import java.util.*;

public class PlayField {
	final static int 		k_ScreenWidth = 240;
	final static int 		k_ScreenHeight = 240;
	// The background color of the play field
	private int				m_iBackgroundRedColor = 0;
	private int				m_iBackgroundGreenColor = 0;
	private int				m_iBackgroundBlueColor = 0;
	// The number of the play field's columns
	private int				m_iColumns = 0;
	// The number of the play field's rows
	private int				m_iRows = 0;
	// The tile size
	private int				m_iTileWidth = 0;
	private int				m_iTileHeight = 0;
	// The current play field map
	private int[]			m_aiMap;
	// The left side position of the view window
	protected float			m_fLeftPos = 0;
	// The decorate items
	private int[] 			m_iarrDecorateID;
	private int[] 			m_iarrDecorateX;
	private int[] 			m_iarrDecorateY;
	// The change map position
	private int[]			m_aiCM;
	private int[]			m_aiCMDstID;
	private int[]			m_aiCMDstX;
	private int[]			m_aiCMDstY;
	// The sprite items manager
	protected SpriteManager	m_SpriteManager;
	// The Mario character
	protected Mario			m_Mario;
	// The Mario transformation
	protected MarioTransform m_MarioTransform;
	// The unique instance
	public static PlayField s_Instance = null;
	// Determine whether the play field is pause
	protected boolean m_isPausing = false;
	// Determine whether the play field is changing map
	protected boolean m_isChangingMap = true;
	// Determine whether the play field changes to a new world
	protected boolean m_isNewWorld = true;
	// Determine whether the play field show the information
	protected boolean m_isShowInformation = true;
	// The finish world position
	protected int m_iFinishWorld = -1;
	// The curent map
	protected int m_iCurrentMap;
	// The time for each world
	protected int m_iTime;
	// game over 
	protected boolean m_isGameOver = false;
	
	protected boolean m_isUpdateTime=true;
	
	private PlayField () {
	}
	
	// Create the unique instance
	public static PlayField CreatePlayField () {
		if (s_Instance == null) {
			s_Instance = new PlayField();
		}
		return s_Instance;
	}
	
	public void NewGame() {
		m_isGameOver = false;
		m_iCurrentMap = 11;
		m_fLeftPos = 0;
		m_Mario = new Mario();
		m_isChangingMap = true;
		m_isShowInformation = true;
	}
	
	public void Pause () {
		m_isPausing = true;
	}
	
	public void Resume () {
		m_isPausing = false;
	}
	
	// Load the play field with the specific level from a binary map file
	public void LoadPlayField () {
		System.gc();
		try {
			m_iFinishWorld = -1;
			m_SpriteManager = new SpriteManager();
			m_Mario.Register(m_SpriteManager);
			m_Mario.m_Sprite.setVisible(true);
			//System.out.println(m_iCurrentMap);
			// Read information from the binary file
			DataStream stream = new DataStream(
				"/" + m_iCurrentMap + ".map");
			// Read the size information
			m_iColumns = stream.ReadNextInt();
			m_iRows = stream.ReadNextInt();
			m_iTileWidth = stream.ReadNextInt();
			m_iTileHeight = stream.ReadNextInt();
			// Read the tile map data
			int size = m_iColumns * m_iRows;
			m_aiMap = new int[size];
			m_aiCM = new int[size];
			int lm_count = 0;
			for (int i=0; i<size; i++) {
				m_aiMap[i] = stream.ReadNextByte();
				m_aiCM[i] = -1;
				if (m_aiMap[i] == Resource.k_Mario) {
					lm_count++;
				}
			}
			int ah = 0;
			if (m_Mario.m_iLevel != Mario.k_SMALL) {
				ah = 16;
			}
			if (lm_count > 0) {
				int lx = -1;
				int ly = -1;
				for (int j=0; j<m_iColumns; j++) {
					for (int i=0; i<m_iRows; i++) {
						int index = i * m_iColumns + j;
						if (m_aiMap[index] == Resource.k_Mario) {
							if (lx < 0 || (j * 16 - 40 < m_fLeftPos)) {
								lx = i;
								ly = j;
							}
							m_aiMap[index] = 0;
						}
					}
				}
				m_Mario.SetPosition(
					ly * 16 + m_Mario.m_Sprite.getWidth(),
					lx * 16 + m_Mario.m_Sprite.getHeight() / 2 - ah);
			} else {
				m_Mario.SetPosition(30, 30);
			}
			if (m_Mario.m_iCMX >= 0 && m_Mario.m_iCMY >= 0) {
				m_Mario.SetPosition(
					m_Mario.m_iCMX * 16 +
						m_Mario.m_Sprite.getWidth(),
					m_Mario.m_iCMY * 16 +
						m_Mario.m_Sprite.getHeight() / 2 - ah);
			}
			m_Mario.m_iCMX = -1;
			m_Mario.m_iCMY = -1;
			int startCol = Math.max(0, m_Mario.GetLeft() / 16 - 2);			
			m_fLeftPos = startCol * 16;					
			m_SpriteManager.m_LayerManager.setViewWindow(
				(int)m_fLeftPos, 0,
				k_ScreenWidth, k_ScreenHeight);
			// Read the time
			int time = stream.ReadNextInt();
			if ((m_isNewWorld || m_isShowInformation)&&m_isUpdateTime) {
				m_iTime = time;
				m_isNewWorld = false;
			}
			m_isUpdateTime=true;
			// Read the background color
			m_iBackgroundRedColor = stream.ReadNextByte();
			m_iBackgroundGreenColor = stream.ReadNextByte();
			m_iBackgroundBlueColor = stream.ReadNextByte();
			// Read all decorate images
			int nImages = stream.ReadNextInt();
			m_iarrDecorateID = new int[nImages];
			m_iarrDecorateX = new int[nImages];
			m_iarrDecorateY = new int[nImages];
			for(int i=0; i<nImages; i++) {
				m_iarrDecorateID[i] = stream.ReadNextByte();
				m_iarrDecorateX[i] = stream.ReadNextByte()
					* m_iTileWidth;
				m_iarrDecorateY[i] = stream.ReadNextByte()
					* m_iTileHeight;
			}			
			int nMarks = stream.ReadNextByte();
			m_aiCMDstID = new int[nMarks];
			m_aiCMDstX = new int[nMarks];
			m_aiCMDstY = new int[nMarks];
			for (int i=0; i<nMarks; i++) {
				int y = stream.ReadNextByte();
				int x = stream.ReadNextByte();
				m_aiCM[x * m_iColumns + y] = i;
				m_aiCMDstID[i] = stream.ReadNextInt();
				m_aiCMDstX[i] = stream.ReadNextByte();
				m_aiCMDstY[i] = stream.ReadNextByte();
			}
			// Create items for the first screen
			for (int i=14; i>=0; i--) {
				for (int j=startCol; j<startCol + 15; j++) {
					SetCell(i, j);
				}
			}
			// Finish reading the binary file
			stream.close();
		} catch (Exception ex) {
			ex.printStackTrace();
		}
	}
	
	public void SetCell (int row, int col) {
		int index = row * m_iColumns + col;
		if (m_aiMap[index] == 0) {
			return;
		}
		int itemID = m_aiMap[index];
		if (itemID == Resource.k_Green_Flag_1) {
			m_iFinishWorld = col * 16;
		}
		int topItemID = -1;
		if (row > 0) {
			topItemID = m_aiMap[index - m_iColumns];
		}
		SpriteItem item = ItemFactory.CreateItem(itemID, topItemID, row, col);		
		if (item != null) {
			if (item instanceof BonusItem) {
				m_aiMap[index - m_iColumns] = 0;
			}
			item.Register(m_SpriteManager);				
			m_aiMap[index] = 0;
		}
	}
	
	public void SetDownPipe (PipeItem item, int row, int col) {
		for (int i=row; i<m_iRows; i++) {			
			if (m_aiCM[i * m_iColumns + col] >= 0) {
				item.m_isDown = true;
			}
		}
	}
		
	// Paint the play field
	public void Paint (Graphics graphics) {	
		if (!m_isPausing) {
			m_SpriteManager.NotifyItemsToTick();
		} else {
			m_MarioTransform.Tick();
		}
		// Clear the screen with the background color
		graphics.setColor(m_iBackgroundRedColor,
			m_iBackgroundGreenColor,
			m_iBackgroundBlueColor);
		graphics.fillRect(0, 0, k_ScreenWidth, k_ScreenHeight);
		UpdateCurrentViewWindow();
		// Draw all decorate items
		if (m_iarrDecorateID != null) {			
			for(int i=0; i<m_iarrDecorateID.length;i++) {
				Image image = Resource.GetImage(
					m_iarrDecorateID[i]);
				int x = m_iarrDecorateX[i];
				int y = m_iarrDecorateY[i];
				if (x + image.getWidth() > m_fLeftPos &&
					x < m_fLeftPos + k_ScreenWidth) {					
					graphics.drawImage(image,
						x - (int)m_fLeftPos, y,
						Graphics.TOP | Graphics.LEFT);					
				}
			}
		}
		// Draw all sprite items inside the current view window
		m_SpriteManager.Paint(graphics);
		DrawInformation(graphics);
	}
	
	private void DrawInformation (Graphics g)
	{
		try
		{				
			// Draw coin number
			Image imgCoin = Image.createImage("/coin.png");
			g.drawImage(imgCoin, 120, 10, Graphics.TOP | Graphics.LEFT);			
			String numofCoin = Integer.toString(m_Mario.m_iCoins);
			DrawString.GetInstance().DrawImage(g, "x" + numofCoin, 127, 6);
			
			// Draw map name
			String mapName = Integer.toString(m_iCurrentMap);
			char a = mapName.charAt(0);
			char b = mapName.charAt(1);
			String stage = a + "-" + b;
			DrawString.GetInstance().DrawImage(g, stage, 210, 6);
			
			// Draw point
			String t_point = Integer.toString(m_Mario.m_iPoint);
			String point = "0";
			int x = t_point.length();
			for(int i=1;i<6-x;i++) { point += "0"; }
			point += t_point;
			DrawString.GetInstance().DrawImage(g, point, 10, 6);
		}
		catch(Exception e)
		{
			//System.out.println("Error in DrawInformation");
		}
	}
	
	public void UpdateCurrentViewWindow () {
		// Update the view window
		if (m_Mario.m_fPosX - m_fLeftPos >
			k_ScreenWidth * 7 / 16 &&
			m_fLeftPos + k_ScreenWidth < m_iColumns * 16) {
			float speed = m_Mario.m_fSpeed;
			if (speed > 0) {
				// Move the current view window to right
				m_fLeftPos += speed;
				if (m_fLeftPos > (m_iColumns - 15) * 16) {
					m_fLeftPos = (m_iColumns - 15) * 16;
				}
				// Update the background items
				int startCol = Math.max(0,
					(int)m_fLeftPos / 16);
				// Remove all unused background items
				Vector items = m_SpriteManager.m_vecSpriteItems;
				for (int i=0; i<items.size(); i++) {
					SpriteItem item = (SpriteItem)
						items.elementAt(i);						
					if (item.GetRight() < m_fLeftPos - 1) {
						item.Deregister(m_SpriteManager);
					}
				}
				// Release memory
				System.gc();
				// Add more background items, if any
				startCol += 14;
				int endCol = Math.min(startCol + 5, m_iColumns-1);
				for (int i=14; i>=0; i--) {
					for (int j=startCol; j<=endCol; j++) {
						SetCell(i, j);
					}
				}
			}
			m_SpriteManager.m_LayerManager.setViewWindow(
				(int)m_fLeftPos, 0,
				k_ScreenWidth, k_ScreenHeight);
		}
		int width = m_Mario.m_Sprite.getWidth() / 2;
		int height = m_Mario.m_Sprite.getHeight() / 2;
		// Reach to the left side
		if (m_Mario.m_fPosX < m_fLeftPos + width) {
			m_Mario.m_fPosX = (int)m_fLeftPos + width + 1;
		}
		// Reach to the right side
		if (m_Mario.m_fPosX > m_iColumns * 16 - width) {
			m_Mario.m_fPosX = m_iColumns * 16 - width - 1;
		}
		// Reach to the bottom side		
		if (m_Mario.GetTop() > m_iRows * 16) {
			m_Mario.NotifyDeath();
		}
		if (m_Mario.m_iMovingState == m_Mario.k_PIPE_FALLING ||
			m_Mario.m_iMovingState == m_Mario.k_PIPE_RIGHT_MOVING ||
			(m_iFinishWorld > 0 && m_Mario.GetLeft() > m_iFinishWorld)) {
			int x = m_Mario.GetLeft() / 16;
			int y = m_Mario.GetTop() / 16;
			if (0<=y && y<m_iRows && 0<=x && x<m_iColumns) {
				// Meet a world transition
				int index = m_aiCM[y * m_iColumns + x];
				if (index >= 0) {
					if (GetWorld(m_iCurrentMap) != GetWorld(m_aiCMDstID[index])) {
						m_isShowInformation = true;
						m_Mario.m_iPoint += (Math.max(0,  m_iTime - MarioGameCanvas.s_iCurrentTime / 1000))*Mario.k_PERSECOND_POINT;
					} else {
						m_isShowInformation = false;
					}
					m_iCurrentMap = m_aiCMDstID[index];
					m_Mario.m_iCMX = m_aiCMDstX[index];
					m_Mario.m_iCMY = m_aiCMDstY[index];					
					m_Mario.m_hasStar = false;				
	                m_Mario.m_isInvulnerable = false;
	                m_Mario.m_iStarPlus = m_Mario.m_iStarCount = 0;					
	                m_isChangingMap = true; 
				}
			}
		}
	}
	
	private int GetWorld (int map) {
		if (map < 100) return map;
		if (map < 1000) return map / 10;
		return map / 100;
	}
	
	// force Mario tranform (when obtaining mushroom, star or shirking due to enemy)
	public void ForceMarioTransform (int frameIndex, int isForward, int marioTransform) {
		PlayField.s_Instance.Pause();
		m_MarioTransform = MarioTransform.getTransform(
			marioTransform, frameIndex, isForward);
                if (marioTransform == MarioTransform.k_GROWUP)
                    m_MarioTransform.SetPosition(m_Mario.m_fPosX - 8,
                           m_Mario.m_fPosY - 24);
//                else if (marioTransform == MarioTransform.k_UPGRADE)
//                    m_MarioTransform.SetPosition(m_Mario.m_fPosX - 8,
//                           m_Mario.m_fPosY - 8);
//                else if (marioTransform == MarioTransform.k_SHRINK)
//                    m_MarioTransform.SetPosition(m_Mario.m_fPosX - 8,
//                           m_Mario.m_fPosY - 8);
//                else if (marioTransform == MarioTransform.k_DEATH)
//                    m_MarioTransform.SetPosition(m_Mario.m_fPosX - 8,
//                            m_Mario.m_fPosY - 8);
                else 
                    m_MarioTransform.SetPosition(m_Mario.m_fPosX - 8,
                           m_Mario.m_fPosY - 8);
		m_MarioTransform.Register(m_SpriteManager, true);
		m_Mario.Deregister(m_SpriteManager);
	}
}