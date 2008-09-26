public class FlipCoin extends SpriteItem {
	protected boolean m_isUpward;
	protected int m_iCoinCount;
	protected float m_fStartX;
	protected float m_fStartY;
	
	public FlipCoin (int itemID, int row, int col, boolean multiple_coins) {
		Initialize(Resource.GetImage(itemID), 16, 16);				
		m_Sprite.setRefPixelPosition(col * 16, row * 16);
		m_fStartX = GetLeft();
		m_fStartY = GetTop();
		m_Sprite.setFrame(0);
		if (multiple_coins)
			m_iCoinCount = 10;
		else
			m_iCoinCount = 1;
	}
        
	public FlipCoin (int itemID, int row, int col) {
	    Initialize(Resource.GetImage(itemID), 16, 16);				
		m_Sprite.setRefPixelPosition(col * 16, row * 16);
		m_fStartX = GetLeft();
		m_fStartY = GetTop();
		m_Sprite.setFrame(0);
		m_iCoinCount = 1;
	}

	public void MoveUpward () {
		//music obtains coin
		MusicManager.GetInstance().Play(MusicManager.k_ObtainCoin);
		//increase point
		PlayField.s_Instance.m_Mario.m_iPoint += Mario.k_OBTAINS_COIN_POINT;	
		PlayField.s_Instance.m_Mario.m_iCoins ++;
		if(PlayField.s_Instance.m_Mario.m_iCoins == 100)
		{
			PlayField.s_Instance.m_Mario.m_iCoins = 0;
			PlayField.s_Instance.m_Mario.m_iLives++;
			MusicManager.GetInstance().Play(MusicManager.k_LifeUp);
		}
		m_isUpward = true;
		m_fPosX = m_fStartX;
		m_fPosY = m_fStartY;
		m_iTickCount = 17;
		m_iCoinCount--;
	}
        
	public void Tick () {
		if (m_isUpward) {
			m_iTickCount--;
			if (m_iTickCount <= 0) {
				m_isUpward = false;
				this.Deregister(m_SpriteManager);
			}
			// set position
			if (m_iTickCount >= 11)
				SetPosition(m_fPosX, m_fPosY - m_iTickCount + 4);
			else if (m_iTickCount <= 6)
				SetPosition(m_fPosX, m_fPosY + 8 - m_iTickCount);
			// set frame
			m_Sprite.setFrame((m_iTickCount+3) % 4);
		}
	}
}