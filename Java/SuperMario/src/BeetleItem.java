import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.Sprite;

public class BeetleItem extends EnemyItem {
    
	protected boolean m_isKicked;
	public BeetleItem (int itemID, int row, int col) {
		InitEnemy(itemID, row, col, 16, 16);
		m_isKicked = false;
	}
        
	public void UpdateFrame () {
		if (m_isActive) {
			if (m_iDir > 0)
				m_Sprite.setTransform(Sprite.TRANS_MIRROR);
			else
				m_Sprite.setTransform(Sprite.TRANS_NONE);
			if (!m_isKicked)
				m_Sprite.setFrame(MarioGameCanvas.s_iCurrentTime / 240 % 2);
		} else {
			m_iTickCount--;
			if (!m_beingBeaten) {
				if (m_iTickCount == 0) {
					m_isActive = true;
					m_fSpeed = 1;
					return;
				}
				if (m_iTickCount <= 30) {
					if (m_iTickCount/3%2 == 0)
						m_Sprite.setTransform(Sprite.TRANS_MIRROR);
					else
						m_Sprite.setTransform(Sprite.TRANS_NONE);
				}
			} else {
				if (m_iTickCount == 0)
					this.Deregister(m_SpriteManager);
				if (m_iTickCount < 45)
					m_fHover = 5;
			}
		}
	}
        
	public void GetStomped() {
		m_isActive = false;
		m_fSpeed = 0;
		m_Sprite.setFrame(2);
		m_iTickCount = 160;		
		//increase point
		PlayField.s_Instance.m_Mario.m_iPoint += Mario.k_KILLS_ENEMY_POINT;
		// stomp music
		MusicManager.GetInstance().Play(MusicManager.k_Stomp);
	}

	public void GetBulletHit(int dir) {		
		// yawn, it can't be beaten by bullet
	}
	
	public void GetBeaten(int dir) {
		super.GetBeaten(dir);
		m_Sprite.setFrame(2);
		m_Sprite.setTransform(Sprite.TRANS_ROT180);
	}
	
	public void GetKicked(int dir) {
		m_isActive = true;
		m_isKicked = true;
		m_iDir = dir;
		m_fSpeed = 4.5f;
		SetPosition(m_fPosX + m_iDir * m_fSpeed, m_fPosY);
	}
}