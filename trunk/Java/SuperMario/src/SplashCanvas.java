import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.*;

public class SplashCanvas extends GameCanvas implements Runnable
{
	private MarioMidlet	m_midlet;	
	static final int 	k_ScreenWidth = 240;
	static final int 	k_ScreenHeight = 320;	
	private Image m_imgLogo;
	private Image m_imgSplash;
	private Image m_imgBuffer;
	private long m_iTime;
	
	public SplashCanvas (MarioMidlet midlet)
	{		
		super(false);
		m_midlet = midlet;				
		setFullScreenMode(true);		
		m_imgLogo = Resource.CreateImage("/GL_Logo.png");
		m_imgSplash = Resource.CreateImage("/SplashGame.jpg");
		m_imgBuffer = Image.createImage(k_ScreenWidth,k_ScreenHeight);
		m_iTime = System.currentTimeMillis();
		Thread runner = new Thread(this);
		runner.start();
	}
	
	protected void hideNotify ()
	{		
	}
	
	protected void showNotify ()
	{		
	}
	
	public void run ()
	{	
		while (true)
		{
			try
			{
				Thread.sleep(20);
			} catch (Exception e) {}			
			
			if (System.currentTimeMillis() - m_iTime < 2000 ){				
				m_imgBuffer = DrawLogoScreen();
			}
			else if (System.currentTimeMillis() - m_iTime < 4000 ){				
				m_imgBuffer = m_imgSplash;
			}
			else if (System.currentTimeMillis() - m_iTime > 4000 ){								
				m_midlet.m_CurrentCanvas = m_midlet.m_MenuCanvas;
				Display.getDisplay(m_midlet).setCurrent(m_midlet.m_CurrentCanvas);
				break;
			}
			repaint();
			serviceRepaints();
		}
	}	
	
	public Image DrawLogoScreen ()
	{
		Image img = Image.createImage(k_ScreenWidth,k_ScreenHeight);
		Graphics g = img.getGraphics();		
		g.setColor(0xffffff);
		g.fillRect(0, 0, k_ScreenWidth, k_ScreenHeight);	
		g.drawImage(m_imgLogo,k_ScreenWidth/2,k_ScreenHeight/2,Graphics.HCENTER| Graphics.VCENTER);
		return img;
	}
	
	public void paint (Graphics g)
	{
		g.drawImage(m_imgBuffer,0,0,Graphics.TOP| Graphics.LEFT);
	}
	
	
}
	