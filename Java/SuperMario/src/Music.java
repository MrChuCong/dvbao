import javax.microedition.media.*;
import java.io.InputStream;

public class Music
{
	Player m_player;	
	
	int m_iLoopCount;	
	
	String m_strPath;
	String m_strType;
	
	boolean m_isFirstTime = true;	
	long m_lTime;
	boolean m_isPaused = false;	
	
	public Music(String path, String type, int loopCount)
	{		
		m_iLoopCount = loopCount;
		m_strPath = path;
		m_strType = type;
		LoadMusic();		
	}	
	
	public void LoadMusic ()
	{		
		try
		{
			m_player = Manager.createPlayer(getClass().getResourceAsStream(m_strPath),m_strType);
			m_player.realize();
			m_player.prefetch();
			m_player.setLoopCount(m_iLoopCount);
		}
		catch(Exception e)
		{
		}
	}	
		
	public void Play ()
	{			
		try
		{
			if(m_player.getMediaTime()==0)
			{
				m_player.start();
			}
			else if(m_player.getMediaTime()==m_player.getDuration())
			{
				m_player.start();
			}
			else
			{				
				// while(m_player.getMediaTime()!=m_player.getDuration())
				// {
				// }
				m_player.stop();
				m_player.setMediaTime(-1);
				m_player.start();				
			}			
		}
		catch(Exception e) 
		{			
		}				
	}
	
	public void Resume ()
	{
		try
		{
			if(m_isPaused)
			{
				m_player.setMediaTime(m_lTime);
				m_player.start();
				m_isPaused = false;
			}			
		}
		catch(Exception e)
		{			
		}
	}
	
	public void Pause ()
	{
		try
		{
			m_lTime = m_player.getMediaTime();
			m_player.stop();
			m_isPaused = true;
		}
		catch(Exception e)
		{			
		}
	}
	
	public void Stop ()
	{
		try
		{		
			if(m_player!=null)
			{
				m_player.stop();
				m_player = null;				
			}
		}
		catch(Exception e)
		{			
		}
	}
	
	public boolean IsFinished ()
	{				
		boolean result = false;		
		if(m_player.getMediaTime() >= m_player.getDuration())
		{
			try
			{
				m_player.setMediaTime(-1);
			}
			catch(Exception e)
			{
			}		
			return true;			
		}
		if(m_player.getMediaTime() == 0)
		{			
			return true;
		}
		return result;
	}
}