import javax.microedition.lcdui.game.Sprite;

public class GoombaItem extends EnemyItem {
	public GoombaItem (int itemID, int row, int col) {
		InitEnemy(itemID, row, col, 16, 16);
	}
        
	public void UpdateFrame () {
		if (!m_isActive) {
			m_iTickCount--;
			if (m_iTickCount <= 0)
				this.Deregister(m_SpriteManager);
			if (m_beingBeaten) {
				if (m_iTickCount < 45)
					m_fHover = 5;
			}
		}
		else
			m_Sprite.setFrame(MarioGameCanvas.s_iCurrentTime / 240 % 2);
	}
        
	public void GetStomped() {            
		m_isActive = false;
		m_fSpeed = 0;
		m_Sprite.setFrame(2);
		m_iTickCount = 8;		
		//increase point
		PlayField.s_Instance.m_Mario.m_iPoint += Mario.k_KILLS_ENEMY_POINT;
		// stomp music
		MusicManager.GetInstance().Play(MusicManager.k_Stomp);
	}

	public void GetBulletHit(int dir) {		
		GetBeaten(dir);
	}
	
	public void GetBeaten(int dir) {		
		super.GetBeaten(dir);
		m_Sprite.setFrame(0);
		m_Sprite.setTransform(Sprite.TRANS_ROT180);
	}
}