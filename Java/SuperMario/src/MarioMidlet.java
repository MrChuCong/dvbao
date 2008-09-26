import javax.microedition.midlet.*;
import javax.microedition.lcdui.game.*;
import javax.microedition.lcdui.*;

public class MarioMidlet extends MIDlet {
	protected MarioGameCanvas	m_MarioCanvas = null;
	protected MenuCanvas 		m_MenuCanvas = null;
	protected SplashCanvas 		m_SplashCanvas = null;		
	protected GameCanvas		m_CurrentCanvas;
	protected boolean			m_isQuit = false;	
	
	public MarioMidlet () {
		Resource.Initialize();
		RecordStoreManager.Initialize();
		m_MenuCanvas = new MenuCanvas(this);
		m_SplashCanvas = new SplashCanvas(this);
		m_MarioCanvas = new MarioGameCanvas(this);
		m_CurrentCanvas = m_SplashCanvas;
	}
		
	public void startApp () {
		Display.getDisplay(this).setCurrent(m_CurrentCanvas);
		if (m_CurrentCanvas == m_MarioCanvas) {					
			m_MarioCanvas.ResumeGame();			
		}
	}
	
	public void pauseApp () {		
		m_MarioCanvas.StopGame();
	}
	
	public void destroyApp (boolean unconditional) {		
		if (m_MarioCanvas.m_wasChanged) RecordStoreManager.SaveGame();
		m_MarioCanvas.StopGame();
		m_MenuCanvas = null;
		m_SplashCanvas = null;
		m_isQuit = true;
	}
}