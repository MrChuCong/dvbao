import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.*;
import javax.microedition.media.*;
import java.io.InputStream;

public class MenuCanvas extends GameCanvas implements Runnable
{
	private MarioMidlet m_midlet;
	
	static final int 	k_ScreenWidth = 240;
	static final int 	k_ScreenHeight = 320;
	static final int 	k_MenuItemWidth = 120;
	static final int 	k_MenuItemHeight = 30;
	static final int 	k_NumberWidth = 21;
	static final int 	k_NumberHeight = 27;
	static final int 	k_NumDigits = 6;
	
	
	static final int 	k_MenuMode = 3;	
	static final int 	k_HighScoreMode = 4;
	static final int 	k_AboutMode = 5;
		
	static final int 	k_iMenuX = 0;
	static final int 	k_iMenuY = 200;
	
	static final int 	k_Continue = 1;
	static final int 	k_NewGame = 2;
	static final int 	k_Sound = 3;
	static final int 	k_HighScore = 4;	
	static final int 	k_About = 5;
	static final int 	k_Exit = 6;
		
	static boolean 		s_haveSound;
	protected boolean	m_haveSave;
	protected boolean	m_haveResume;
	protected int 		m_iMenuIndex; 
	protected int		m_iMode;
				
	private Image 	m_imgBG;
	private Image 	m_imgContinue;	
	private Image 	m_imgResume;	
	private Image 	m_imgNewGame;	
	private Image 	m_imgSoundON;
	private Image 	m_imgSoundOFF;	
	private Image 	m_imgHighScore;	
	private Image 	m_imgAbout;	
	private Image 	m_imgAboutTeam;	
	private Image 	m_imgExit;
	private Image	m_imgArrowLeft;
	private Image	m_imgArrowRight;	
	private Image	m_imgNumber;	
	private Image	m_imgBlurBG;	
	
	private int m_iY;
	private int m_iXNewGame;
	private int m_iXContinue;
	private int m_iXHighScore;
	private int m_iXAbout;
	private int m_iXExit;
	
	private boolean	m_isContinue = true;
	public MenuCanvas (MarioMidlet midlet)
	{		
		super(false);
		m_haveResume = false;
		m_midlet = midlet;		
		LoadImage();
		setFullScreenMode(true);		
		m_iMenuIndex = k_NewGame;
		m_iMode = k_MenuMode;
		m_haveSave = RecordStoreManager.HaveSave();
		SetXY();
		if (m_haveSave) {
			m_iMenuIndex = k_Continue;
		}
		Thread runner = new Thread(this);
		runner.start();
	}
				
	public void SetXY()
	{
		m_iY = 276;
		m_iXNewGame = 55;
		m_iXContinue = 60;
		m_iXHighScore = 47;
		m_iXAbout = 80;
		m_iXExit = 95;
	}
	
	public void LoadImage ()
	{
		try
		{
			m_imgBG = Resource.CreateImage("/SplashGame.jpg");														
			m_imgSoundON = Resource.CreateImage("/SoundON.png");														
			m_imgSoundOFF = Resource.CreateImage("/SoundOFF.png");	
			m_imgContinue = Image.createImage("/Continue.png");
			m_imgResume = Image.createImage("/Resume.png");
			m_imgNewGame = Image.createImage("/NewGame.png");
			m_imgHighScore = Image.createImage("/HighScores.png");
			m_imgAbout = Image.createImage("/About.png");
			m_imgExit = Image.createImage("/Exit.png");
			m_imgArrowLeft = Image.createImage("/ArrowLeft.png");
			m_imgArrowRight = Image.createImage("/ArrowRight.png");
			m_imgAboutTeam = Image.createImage("/AboutTeam.png");
			m_imgNumber = Image.createImage("/number.png");			
			m_imgBlurBG = Image.createImage("/BackgroundMenu.jpg");			
		}
		catch(Exception e)
		{
		}
	}	
		
	protected void keyPressed(int keyCode)
	{			
		if (m_iMode==k_HighScoreMode) {
			m_iMode = k_MenuMode;
			return;
		}
		
		if (m_iMode==k_AboutMode) {
			m_iMode = k_MenuMode;
			return;
		}
	
		keyCode = getGameAction(keyCode);	
		switch (keyCode)
		{	
			case UP:
			case LEFT:
				int temp = k_NewGame;
				if (m_haveSave || m_haveResume) {				
					temp = k_Continue;
				}
				if (m_iMenuIndex > temp)
				{
					m_iMenuIndex--;
				} 
				else 
				{
					m_iMenuIndex = k_Exit;					
				}
				break;			
			case DOWN:	
			case RIGHT:				
				if (m_iMenuIndex < k_Exit)
				{
					m_iMenuIndex++;
				} 
				else 
				{					
					m_iMenuIndex = k_NewGame;
					if (m_haveSave) {
						m_iMenuIndex = k_Continue;
					}
				}
				break;	
			case FIRE:
				ProcessSelect();		
				break;
		}	
	}
	
	public void ProcessSelect () {
		switch (m_iMenuIndex) {
			case k_Continue:
				{
					if (!m_haveResume) {
						RecordStoreManager.LoadGame();
						m_midlet.m_MarioCanvas.StartGame();
					}	
					else {
						m_midlet.m_MarioCanvas.ResumeGame();
					}
					
					m_midlet.m_CurrentCanvas = m_midlet.m_MarioCanvas;
					Display.getDisplay(m_midlet).setCurrent(m_midlet.m_CurrentCanvas);
					break;
				}
			case k_NewGame:
				{
					PlayField.s_Instance.NewGame();
					m_midlet.m_MarioCanvas.StartGame();
					m_midlet.m_CurrentCanvas = m_midlet.m_MarioCanvas;
					Display.getDisplay(m_midlet).setCurrent(m_midlet.m_CurrentCanvas);
					break;
				}
			case k_Sound:
				{
					s_haveSound = !s_haveSound;
					break;
				}
			case k_HighScore:
				{
					m_iMode = k_HighScoreMode;
					break;
				}
			case k_About:
				{
					m_iMode = k_AboutMode;
					break;
				}		
			case k_Exit:
				{	
					m_midlet.destroyApp(true);
					m_midlet.notifyDestroyed();
					break;
				}				
		}
	}
	
	public void paint (Graphics g)
	{
		g.drawImage(m_imgBG, 0, 0, Graphics.TOP | Graphics.LEFT);		
		
		switch (m_iMode) {
			case k_MenuMode:
				DrawMenu(g);
				break;
			case k_HighScoreMode:
				g.drawImage(m_imgBlurBG, 0, 0, Graphics.TOP | Graphics.LEFT);
				DrawHighScore(g);
				break;				
			case k_AboutMode:				
				g.drawImage(m_imgBlurBG, 0, 0, Graphics.TOP | Graphics.LEFT);				
				g.drawImage(m_imgAboutTeam, 0, 0, Graphics.TOP | Graphics.LEFT);				
				break;
		}
		
	}
	long startTime = System.currentTimeMillis();
	boolean flag = false;	
		
	public void DrawMenu (Graphics g)
	{									
		long elapsedTime = System.currentTimeMillis() - startTime;
		//if(elapsedTime / 60 % 6 != 0)
		{			
			switch (m_iMenuIndex) 
			{
				case k_Continue:									
					if (!m_haveResume)
						g.drawImage(m_imgContinue, m_iXContinue, m_iY, Graphics.TOP | Graphics.LEFT);		
					else
						g.drawImage(m_imgResume, m_iXContinue, m_iY, Graphics.TOP | Graphics.LEFT);		
					break;
				case k_NewGame:
					g.drawImage(m_imgNewGame, m_iXNewGame, m_iY, Graphics.TOP | Graphics.LEFT);
					break;
				case k_Sound:					
					if (s_haveSound)
						g.drawImage(m_imgSoundON, m_iXNewGame, m_iY, Graphics.TOP | Graphics.LEFT);						
					else
						g.drawImage(m_imgSoundOFF, m_iXNewGame, m_iY, Graphics.TOP | Graphics.LEFT);
					break;
				case k_HighScore:					
					g.drawImage(m_imgHighScore, m_iXHighScore, m_iY, Graphics.TOP | Graphics.LEFT);	
					break;
				case k_About:					
					g.drawImage(m_imgAbout, m_iXAbout, m_iY, Graphics.TOP | Graphics.LEFT);	
					break;
				case k_Exit:					
					g.drawImage(m_imgExit, m_iXExit, m_iY, Graphics.TOP | Graphics.LEFT);					
					break;
			}
		}
		int k = 3;
		if(elapsedTime / 120 % 3 == 0)
		{
			switch (m_iMenuIndex) 
			{
				case k_Continue:									
					g.drawImage(m_imgArrowLeft, m_iXContinue - 45 - k, 280, Graphics.TOP | Graphics.LEFT);		
					g.drawImage(m_imgArrowRight, m_iXContinue + 110 + k, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_NewGame:
					g.drawImage(m_imgArrowLeft, m_iXNewGame - 45 - k, 280, Graphics.TOP | Graphics.LEFT);
					g.drawImage(m_imgArrowRight, m_iXNewGame + 126 + k, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_Sound:
					g.drawImage(m_imgArrowLeft, m_iXNewGame - 45 - k, 280, Graphics.TOP | Graphics.LEFT);
					g.drawImage(m_imgArrowRight, m_iXNewGame + 126 + k, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_HighScore:					
					g.drawImage(m_imgArrowLeft, m_iXHighScore - 45 - k, 280, Graphics.TOP | Graphics.LEFT);	
					g.drawImage(m_imgArrowRight, m_iXHighScore + 142 + k, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_About:					
					g.drawImage(m_imgArrowLeft, m_iXAbout - 45 - k, 280, Graphics.TOP | Graphics.LEFT);	
					g.drawImage(m_imgArrowRight, m_iXAbout + 75 + k, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_Exit:					
					g.drawImage(m_imgArrowLeft, m_iXExit - 45 - k, 280, Graphics.TOP | Graphics.LEFT);				
					g.drawImage(m_imgArrowRight, m_iXExit + 43 + k, 280, Graphics.TOP | Graphics.LEFT);							
					return;
			}
		}
		else if(elapsedTime / 120 % 3 == 1)
		{
			switch (m_iMenuIndex) 
			{
				case k_Continue:									
					g.drawImage(m_imgArrowLeft, m_iXContinue - 45 - 2 * k, 280, Graphics.TOP | Graphics.LEFT);		
					g.drawImage(m_imgArrowRight, m_iXContinue + 110 + 2 * k, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_NewGame:
					g.drawImage(m_imgArrowLeft, m_iXNewGame - 45 - 2 * k, 280, Graphics.TOP | Graphics.LEFT);
					g.drawImage(m_imgArrowRight, m_iXNewGame + 126 + 2 * k, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_Sound:
					g.drawImage(m_imgArrowLeft, m_iXNewGame - 45 - 2 * k, 280, Graphics.TOP | Graphics.LEFT);
					g.drawImage(m_imgArrowRight, m_iXNewGame + 126 + 2 * k, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_HighScore:					
					g.drawImage(m_imgArrowLeft, m_iXHighScore - 45 - 2 * k, 280, Graphics.TOP | Graphics.LEFT);	
					g.drawImage(m_imgArrowRight, m_iXHighScore + 142 + 2 * k, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_About:					
					g.drawImage(m_imgArrowLeft, m_iXAbout - 45 - 2 * k, 280, Graphics.TOP | Graphics.LEFT);	
					g.drawImage(m_imgArrowRight, m_iXAbout + 75 + 2 * k, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_Exit:					
					g.drawImage(m_imgArrowLeft, m_iXExit - 45 - 2 * k, 280, Graphics.TOP | Graphics.LEFT);				
					g.drawImage(m_imgArrowRight, m_iXExit + 43 + 2 * k, 280, Graphics.TOP | Graphics.LEFT);							
					return;
			}
		}
		else
		{
			switch (m_iMenuIndex) 
			{
				case k_Continue:									
					g.drawImage(m_imgArrowLeft, m_iXContinue - 45, 280, Graphics.TOP | Graphics.LEFT);		
					g.drawImage(m_imgArrowRight, m_iXContinue + 110, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_NewGame:
					g.drawImage(m_imgArrowLeft, m_iXNewGame - 45, 280, Graphics.TOP | Graphics.LEFT);
					g.drawImage(m_imgArrowRight, m_iXNewGame + 126, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_Sound:
					g.drawImage(m_imgArrowLeft, m_iXNewGame - 45, 280, Graphics.TOP | Graphics.LEFT);
					g.drawImage(m_imgArrowRight, m_iXNewGame + 126, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_HighScore:					
					g.drawImage(m_imgArrowLeft, m_iXHighScore - 45, 280, Graphics.TOP | Graphics.LEFT);	
					g.drawImage(m_imgArrowRight, m_iXHighScore + 142, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_About:					
					g.drawImage(m_imgArrowLeft, m_iXAbout - 45, 280, Graphics.TOP | Graphics.LEFT);	
					g.drawImage(m_imgArrowRight, m_iXAbout + 75, 280, Graphics.TOP | Graphics.LEFT);		
					return;
				case k_Exit:					
					g.drawImage(m_imgArrowLeft, m_iXExit - 45, 280, Graphics.TOP | Graphics.LEFT);				
					g.drawImage(m_imgArrowRight, m_iXExit + 43, 280, Graphics.TOP | Graphics.LEFT);							
					return;
			}
		}		
	}
		
	private void DrawHighScore (Graphics g )
	{		
		g.drawImage(m_imgHighScore, m_iXHighScore, k_ScreenHeight - m_iY - 40, Graphics.TOP | Graphics.LEFT);	
		for(int i =0; i<RecordStoreManager.k_HighScore; i++ )
		{
			DrawNumbers(g, RecordStoreManager.m_aiHighscore[i], k_NumDigits, 105, (i+1)*55);
			DrawNumbers(g, i+1, 2, 15, (i+1)*55);
		}	
	}
		
	public void run()
	{				
		while (m_isContinue)
		{
			try
			{
				Thread.sleep(20);
			} catch (Exception e) {}			
			
			repaint();
			serviceRepaints();
		}
	}
				
	private void DrawNumber (Graphics g, int index, int x, int y) {
		 g.drawRegion(m_imgNumber, index*k_NumberWidth, 0,
                  k_NumberWidth, k_NumberHeight,
                  Sprite.TRANS_NONE, x, y, Graphics.TOP | Graphics.LEFT);
	}
	
	private void DrawNumbers (Graphics g, int number, int numdigit, int x, int y) 
	{				
		int digit = 0;
		int temp = Math.abs(number);			
		int count = numdigit;		
		while(temp !=0)
		{
			digit = temp % 10;
			temp = temp/10;			
			DrawNumber(g,digit,(count-1)*k_NumberWidth + x,y);			
			count--;
		}				
		while(count!=0)
		{
			DrawNumber(g,0,(count-1)*k_NumberWidth + x,y);			
			count--;
		}				
	}
}
