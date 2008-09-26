import javax.microedition.rms.*;

public class RecordStoreManager {
	static final String k_RecRecord = "MARIO_DB";
	static final int k_HighScore = 5;
	static int[] m_aiHighscore;
	private static RecordStore m_rs = null;
		
	private RecordStoreManager() {
	
	}
	
	public static void Initialize () {
		try
		{
			m_rs = RecordStore.openRecordStore(k_RecRecord, true );						
			if(m_rs.getNumRecords()==0){
				for (int i =0; i< k_HighScore + 12;i++) {
					AddRecord(0,i,true);
				}
			}
			m_rs.closeRecordStore();
		}
		catch(Exception e)
		{			
		}
		LoadHighScore();
	}
	
	
	public static boolean HaveSave () {
		boolean re = true;
		try
		{
			m_rs = RecordStore.openRecordStore(k_RecRecord, true );						
			int temp = GetRecord(1);
			if (temp == 0) {
				re = false;
			}
			m_rs.closeRecordStore();
		}
		catch(Exception e)
		{			
		}
		return re;
	}
	
	public static boolean SaveGame () {								
		PlayField game = PlayField.s_Instance;		
		boolean re = true;
		try
		{
			m_rs = RecordStore.openRecordStore(k_RecRecord, true );							
			AddRecord(game.m_iCurrentMap,1,false);				
			AddRecord(game.m_Mario.GetLeft() / 16,2,false);
			AddRecord(game.m_Mario.GetTop() / 16,3,false);
			AddRecord(game.m_Mario.m_iLives,4,false);
			AddRecord(game.m_Mario.m_iCoins,5,false);
			AddRecord(game.m_Mario.m_iPoint,6,false);
			AddRecord(game.m_Mario.m_iLevel,7,false);
			AddRecord(game.m_Mario.m_iStarCount,8,false);	
			int hasStar = 0;
			if (game.m_Mario.m_hasStar)
				hasStar = 1;
			AddRecord(hasStar,9,false);			
			AddRecord(game.m_Mario.m_iStarPlus,10,false);			
			AddRecord(Math.max(0, game.m_iTime - MarioGameCanvas.s_iCurrentTime / 1000),11,false);			
			m_rs.closeRecordStore();
		}
		catch(Exception e)
		{
			re = false;			
		}
		return re;
	}	
	
	public static boolean ClearSaveGame () {						
		PlayField game = PlayField.s_Instance;		
		boolean re = true;
		try
		{
			m_rs = RecordStore.openRecordStore(k_RecRecord, true );				
			for (int i =1; i< 12;i++) {
				AddRecord(0,i,false);
			}		
			m_rs.closeRecordStore();
		}
		catch(Exception e)
		{
			re = false;			
		}
		return re;
	}
	
	private static void AddRecord (int data, int index, boolean isNew) {		
		byte[] rec = Integer.toString(data).getBytes();
		try {
			if (isNew) {
				m_rs.addRecord(rec,0,rec.length);				
			}
			else {
				m_rs.setRecord(index,rec,0,rec.length);				
			}
		}	
		catch (Exception e) {			
		}		
	}
	
	private static int GetRecord (int index) {
		int re = 0;
		try {					
			byte[] recData = new byte[m_rs.getRecordSize(index)];		   
			int len = m_rs.getRecord(index, recData, 0);	
			String temp = new String(recData, 0, len);					
			re = Integer.parseInt(temp,10);			
		}
		catch (Exception e) {			
		}		
		return re;
	}
		
	public static boolean LoadGame () {						
		PlayField game = PlayField.s_Instance;
		try
		{
			m_rs = RecordStore.openRecordStore(k_RecRecord, true );				
			int temp = GetRecord(1);
			if (temp == 0) {
				return false;
			}			
			game.m_iCurrentMap = GetRecord(1);						
			game.m_Mario.m_iCMX = GetRecord(2);			
			game.m_Mario.m_iCMY = GetRecord(3);			
			game.m_Mario.m_iLives = GetRecord(4);			
			game.m_Mario.m_iCoins = GetRecord(5);			
			game.m_Mario.m_iPoint = GetRecord(6);			
			game.m_Mario.m_iLevel = GetRecord(7);			
			game.m_Mario.m_iStarCount = GetRecord(8);						
			game.m_Mario.m_hasStar = false;			
			if (GetRecord(9) == 1)
				game.m_Mario.m_hasStar = true;			
			game.m_Mario.m_iStarPlus = GetRecord(10);			
			game.m_iTime = GetRecord(11);			
			game.m_isChangingMap = true;
			game.m_isShowInformation = true;
			game.m_isUpdateTime = false;
			m_rs.closeRecordStore();
		}
		catch(Exception e)
		{	
			return false;
		}
		return true;
	}
		
	public static boolean SaveHighScore (int point) {
		int[] temp = new int[k_HighScore];
		int i = 0;
		boolean change = false;
		for(; i<k_HighScore; i++)
		{
			if(m_aiHighscore[i]>point)
			{
				temp[i] = m_aiHighscore[i];				
			}
			else			
			{
				temp[i] = point;
				i++;
				change = true;
				break;
			}
		}
			
		if(change)
		{			
			// have new record
			for(; i<k_HighScore; i++)
			{
				temp[i] = m_aiHighscore[i-1];
			}			
			try {	
				m_rs = RecordStore.openRecordStore(k_RecRecord, true );				
				for (i =0; i< k_HighScore;i++) {					
					m_aiHighscore[i] = temp[i];						
					AddRecord(m_aiHighscore[i],i + 12, false);
				}
				m_rs.closeRecordStore();
			}	
			catch(Exception e)
			{	
				return false;
			}
		}		
		return true;		
	}
	
	public static boolean LoadHighScore() {
		m_aiHighscore = new int[k_HighScore];
		try
		{
			m_rs = RecordStore.openRecordStore(k_RecRecord, true );				
			int i = 0;						
			for (int j = 12;j<k_HighScore+12; i++, j++)
				m_aiHighscore[i] = GetRecord(j);
			m_rs.closeRecordStore();
		}
		catch(Exception e)
		{		
			return false;
		}
		return true;	
	}
} 