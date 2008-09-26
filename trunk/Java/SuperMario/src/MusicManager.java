import javax.microedition.media.*;
import java.io.InputStream;

public class MusicManager
{
	//main music constant//
	
	//effect music constant//
	public static final int k_Jump = 11;
	public static final int k_Pause = 12;
	public static final int k_ObtainCoin = 13;	
	public static final int k_Fireball = 14;
	public static final int k_EatQuestion = 15;
	public static final int k_PowerUp1 = 16;
	public static final int k_PowerUp2 = 17;
	public static final int k_PowerDown = 18;
	public static final int k_LifeUp = 19;
	public static final int k_BreakBlock = 20;
	public static final int k_Pipe = 21;
	public static final int k_Stomp = 22;
	
	public static final int k_MoveUp = 24;
		
		
	//main music//	

	
	//effect music//
	static Music m_musicJump;
	static Music m_musicPause;
	static Music m_musicObtainCoin;		
	static Music m_musicEatQuestion;
	static Music m_musicPowerUp1;
	static Music m_musicPowerUp2;
	static Music m_musicPowerDown;
	static Music m_musicLifeUp;
	static Music m_musicBreakBlock;
	static Music m_musicPipe;
	static Music m_musicStomp;
	
	static Music m_musicMoveUp;
	
	//menu music//		
	
	private MusicManager ()
	{
		m_musicObtainCoin = new Music("/coin.wav", "audio/x-wav", 1);
		//m_musicFireball = new Music("/fireball.wav", "audio/x-wav", 1);
		
		m_musicPowerUp1	= new Music("/powerup.wav", "audio/x-wav", 1);		
		m_musicPowerUp2 = new Music("sprout.wav", "audio/x-wav", 1);
		m_musicPowerDown = new Music("powerdown.wav", "audio/x-wav", 1);
		
		m_musicJump = new Music("/jump.wav", "audio/x-wav", 1);
		m_musicLifeUp = new Music("/1-up.wav", "audio/x-wav", 1);	
		
		m_musicBreakBlock = new Music("/breakblock.wav", "audio/x-wav", 1);
		m_musicPipe = new Music("/pipe.wav", "audio/x-wav", 1);
		m_musicStomp = new Music("/stomp.wav", "audio/x-wav", 1);
		
		m_musicMoveUp = new Music("/moveup.wav", "audio/x-wav", 1);
		
	}
	
	private static MusicManager instance = null;
	
	public static MusicManager GetInstance ()
	{
		if(instance==null)
			instance = new MusicManager ();
		return instance;
	}
	
	public static void Play (int value)
	{
		if(MenuCanvas.s_haveSound == false)
			return;
		switch(value)
		{			
			//effect music//
			case k_Jump:					m_musicJump.Play();				break;
			case k_ObtainCoin:				m_musicObtainCoin.Play();		break;
			case k_Fireball:												break;
			case k_EatQuestion:				m_musicEatQuestion.Play();		break;					
			
			case k_PowerUp1:				m_musicPowerUp1.Play();			break;
			case k_PowerUp2:				m_musicPowerUp2.Play();			break;
			case k_LifeUp:					m_musicLifeUp.Play();			break;	
			case k_PowerDown:				m_musicPowerDown.Play();		break;
			case k_BreakBlock:				m_musicBreakBlock.Play();		break;
			case k_Pipe:					m_musicPipe.Play();				break;
			case k_Stomp:					m_musicStomp.Play();			break;			
			case k_MoveUp:					m_musicMoveUp.Play();			break;
		}
	}	
}
