import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.*;

public class MarioGameCanvas extends GameCanvas
	implements Runnable {
	private MarioMidlet m_midlet;
	// The time to refresh the canvas
	final static int 	k_MS_PER_FRAME = 30;
	// The play field for playing game
	protected PlayField	m_PlayField;
	// Indicate the game loop is continue or not
	static boolean		m_isContinue = true;	
	// The current time, in ms
	protected static int s_iCurrentTime = 0;
	// The mario box
	protected Sprite	m_sprMarioBox = null;
	// The number sprite
	protected Sprite	m_sprNumber = null;
	// The clock image
	protected Image		m_imgClock = null;
	protected boolean	m_isUpdateTime = false;
	protected boolean	m_wasChanged = false;
	
	public MarioGameCanvas (MarioMidlet midlet) {
		super(true);
		m_midlet = midlet;
		m_PlayField = PlayField.CreatePlayField();
		m_sprMarioBox = new Sprite(Resource.CreateImage("/mario_box.png"),
			32, 32);
		m_sprMarioBox.setRefPixelPosition(14, 14);
		m_sprNumber = new Sprite(Resource.CreateImage("/number.png"),21, 27);
		m_imgClock = Resource.CreateImage("/clock.png");
		setFullScreenMode(true);
	}
	
	public void StartGame () {
		// Start a new thread for game loop
		m_wasChanged = true;
		m_isContinue = true;
		new Thread(this).start();
	}
	
	int m_iTimeStop;
	public void StopGame () {
		// Stop the game loop thread
		m_iTimeStop = Math.max(0,  PlayField.s_Instance.m_iTime - MarioGameCanvas.s_iCurrentTime / 1000);
		m_isContinue = false;
	}
	
	public void ResumeGame () {
		// Stop the game loop thread
		PlayField.s_Instance.m_iTime = m_iTimeStop;
		StartGame();
	}
	
	private void PaintNumber (Graphics graphics,
		int number, int x, int y) {
		m_sprNumber.setRefPixelPosition(x, y);
		m_sprNumber.setFrame(number);
		m_sprNumber.paint(graphics);
	}
	
	private void PaintTitleBar (Graphics graphics) {
		graphics.drawImage(Resource.GetTitleBarImg(), 0, 0,
			Graphics.TOP | Graphics.LEFT);
		m_sprMarioBox.paint(graphics);
		int lives = Math.min(m_PlayField.m_Mario.m_iLives, 100);
		if (lives < 0) {
			lives = 0;
		}
		PaintNumber(graphics, lives / 10, 50, 15);
		PaintNumber(graphics, lives % 10, 71, 15);
		graphics.drawImage(m_imgClock, 114, 10,
			Graphics.TOP | Graphics.LEFT);
		int time = Math.max(0,
			m_PlayField.m_iTime - s_iCurrentTime / 1000);
		if (time == 0) {
			m_PlayField.ForceMarioTransform(
				m_PlayField.m_Mario.m_Sprite.getFrame() -
				m_PlayField.m_Mario.m_iStarPlus,
				m_PlayField.m_Mario.m_iDir,
				MarioTransform.k_DEATH);
		}
		PaintNumber(graphics, time / 100, 165, 15);
		PaintNumber(graphics, (time % 100) / 10, 186, 15);
		PaintNumber(graphics, time % 10, 207, 15);
	}
	
	public void run () {
		// Get the game canvas's Graphics object
		Graphics graphics = getGraphics();
		long gameStartTime = System.currentTimeMillis();
		int tick = 0;
		while (m_isContinue) {						
			long cycleStartTime = System.currentTimeMillis();
			// Update the time
			s_iCurrentTime = (int)(cycleStartTime - gameStartTime);
                        PlayField.s_Instance.m_Mario.tempTime = 0;
			if (m_PlayField.m_isChangingMap) {
				if (!m_isUpdateTime) {
					m_PlayField.m_iTime = Math.max(0,
						m_PlayField.m_iTime - s_iCurrentTime / 1000);
					m_isUpdateTime = true;
				}
				int max = 10;
				if (m_PlayField.m_isShowInformation) {
					max = 70;
				}
				if (tick < max) {
					tick++;
				} else {
					tick = 0;
					gameStartTime = System.currentTimeMillis();
					m_PlayField.m_Mario.m_iMovingState = Mario.k_FALLING;
					m_PlayField.m_Mario.m_Sprite.setFrame(0);
					m_PlayField.m_Mario.m_fHover = -Mario.k_FINAL_HOVER;
					m_PlayField.m_Mario.m_fSpeed = 0;
					m_PlayField.m_isChangingMap = false;					
					m_PlayField.LoadPlayField();					
					m_PlayField.m_isShowInformation = true;
					m_isUpdateTime = false;
				}
			}
			if (!m_PlayField.m_isChangingMap) {
				// Process the user's input
				m_PlayField.m_Mario.ProcessUserInput(
					getKeyStates());
				// Paint the title bar
				if (!m_PlayField.m_isPausing) {
					m_sprMarioBox.setFrame((s_iCurrentTime / 1000) % 2);
					PaintTitleBar(graphics);
				}
				// Paint the command bar
				graphics.drawImage(Resource.GetCommandBarImg(), 0, 300,
					Graphics.TOP | Graphics.LEFT);
				// Translate and setclip to prepare the game screen
				graphics.translate(0, 60);
				graphics.setClip(0, 0, 240, 240);
				if (!m_isContinue) break;
				// Paint the play field
				try {
					m_PlayField.Paint(graphics);
				} catch (Exception ex) {
					ex.printStackTrace();
				}
				// Restore the graphics
				graphics.translate(0, -60);
				graphics.setClip(0, 0, 240, 320);
			} else {
				
				if (m_PlayField.m_isShowInformation) {
					ShowInformation(graphics);
				}
			}
			// Flush the graphics
			flushGraphics();
			long timeSinceStart =
			System.currentTimeMillis() - cycleStartTime;			
			if (timeSinceStart < k_MS_PER_FRAME) {
				try {
					// Delay before the next loop
					Thread.sleep(k_MS_PER_FRAME -
						timeSinceStart);
				} catch (Exception ex) {
					ex.printStackTrace();
				}
			}
		}
		if (PlayField.s_Instance.m_isGameOver) {
			PlayField.s_Instance.m_isGameOver = false;
			m_midlet.m_MenuCanvas.m_iMode = MenuCanvas.k_HighScoreMode;			
			m_midlet.m_MenuCanvas.m_haveSave = false;
			m_midlet.m_MenuCanvas.m_haveResume = false;
			m_midlet.m_MenuCanvas.m_iMenuIndex = MenuCanvas.k_NewGame;
			m_midlet.m_MarioCanvas.m_wasChanged = false;
			RecordStoreManager.ClearSaveGame();
			Display.getDisplay(m_midlet).setCurrent(m_midlet.m_MenuCanvas);				
		}
		if (m_midlet.m_isQuit)
		{
			m_PlayField.m_SpriteManager.m_vecSpriteItems.removeAllElements();
			m_PlayField.m_SpriteManager = null;
			m_PlayField = null;
		}
		System.gc();
	}
	
	public void ShowInformation (Graphics g)
	{
		g.setColor(0x000000);
		g.fillRect(0, 0, 240, 320);
		
		String mapName = Integer.toString(m_PlayField.m_iCurrentMap);
		char a = mapName.charAt(0);
		char b = mapName.charAt(1);
		String stage = a + "-" + b;		
		String numofCoin = Integer.toString(m_PlayField.m_Mario.m_iCoins);
		String life = Integer.toString(m_PlayField.m_Mario.m_iLives);
		try
		{					
			Image imgMario = Image.createImage("/mario.png");
			Image imgCoin = Image.createImage("/coin.png");
			g.drawImage(imgMario, 90, 104, Graphics.TOP | Graphics.LEFT);
			g.drawImage(imgCoin, 192, 27, Graphics.TOP | Graphics.LEFT);
			
			// /*Draw point*/
			DrawString.GetInstance().DrawImage(g, "MARIO", 10, 10);
			String t_point = Integer.toString(m_PlayField.m_Mario.m_iPoint);
			String point = "0";
			int x = t_point.length();
			for(int i=1;i<6-x;i++) { point += "0"; }
			point += t_point;
			DrawString.GetInstance().DrawImage(g, point, 10, 22);	
			
			// /*Draw coin number*/
			DrawString.GetInstance().DrawImage(g, "COINS", 185, 10);
			DrawString.GetInstance().DrawImage(g, "x" + numofCoin, 200, 22);						
			DrawString.GetInstance().DrawImage(g, " x " + life,  110, 106);						
			DrawString.GetInstance().DrawImage(g, "WORLD " + stage, 80, 80);			
		}
		catch(Exception e) 
		{			
		}		
	}
	
	protected void keyPressed(int keyCode)
	{	
		switch (keyCode)
		{	
			case -6:
				m_midlet.m_MenuCanvas.m_haveResume = true;				
				m_midlet.m_MenuCanvas.m_iMode = MenuCanvas.k_MenuMode;
				m_midlet.m_MenuCanvas.m_iMenuIndex = MenuCanvas.k_Continue;
				StopGame();
				Display.getDisplay(m_midlet).setCurrent(m_midlet.m_MenuCanvas);	
				break;
			case -7:
				StopGame();
				m_midlet.destroyApp(false);
				m_midlet.notifyDestroyed();
				break;
		}
	}	
}