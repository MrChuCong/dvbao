
public class MarioBullet extends SpriteItem {
	protected boolean m_isExploded = false;
	public MarioBullet (Mario mario) {
		Initialize(Resource.GetImage(Resource.k_Fire_Ball), 16, 16);		
		m_iDir = mario.m_iDir;	
		if (m_iDir > 0)
			SetPosition(mario.GetRight() - 8, mario.GetTop());
		else
			SetPosition(mario.GetLeft() - 8, mario.GetTop());
		m_iTickCount = 0;
	}
        
	public void Move() {
		if (m_fPosY > PlayField.k_ScreenHeight || m_fPosX < PlayField.s_Instance.m_fLeftPos ||
				m_fPosX > PlayField.k_ScreenHeight + PlayField.s_Instance.m_fLeftPos) {			
			Deregister(m_SpriteManager);
			return;
		}

		// try moving horizon
		SetPosition(m_fPosX + m_iDir * 6, m_fPosY);
		SpriteItem cleft = GetCollisionLeft();
		SpriteItem cright = GetCollisionRight();
		if (cleft != null) {
			if (cleft instanceof StaticItem || cleft instanceof BrickItem ||
					cleft instanceof EnemyItem || cleft instanceof BonusItem) {
				Explode();
				if (cleft instanceof EnemyItem)
					if (!((EnemyItem)cleft).m_beingBeaten)
						((EnemyItem)cleft).GetBulletHit(m_iDir);
				return;
			}
		}
		else if (cright != null) {
			if (cright instanceof StaticItem || cright instanceof BrickItem || 
					cright instanceof BonusItem || cright instanceof EnemyItem) {                           
				Explode();
				if (cright instanceof EnemyItem)
					if (!((EnemyItem)cright).m_beingBeaten)
						((EnemyItem)cright).GetBulletHit(m_iDir);
				return;
			}
		}
		if (m_fPosX < PlayField.s_Instance.m_fLeftPos || m_fPosX > PlayField.s_Instance.m_fLeftPos + PlayField.k_ScreenWidth)
		{
			this.Deregister(m_SpriteManager);
			return;
		}
		// try moving vertically
		m_fPrevPosY = m_fPosY;
		int dy = 0;
		if (m_iTickCount >= 8)  {// going upper
			if (m_iTickCount >= 15)
				dy = -5;
			else if (m_iTickCount >= 12)
				dy = -2;
			else
				dy = -1;
		} else {
			if (m_iTickCount <= 0)
				dy = 5;
			else if (m_iTickCount <= 3)
				dy = 2;
			else
				dy = 1;
		}
		SetPosition(m_fPosX, m_fPosY + dy);
		SpriteItem cbottom = GetCollisionBottom();				            
		if (cbottom != null) {
			if (cbottom instanceof StaticItem || cbottom instanceof BrickItem 
					|| cbottom instanceof BonusItem || cbottom instanceof EnemyItem) {
				if (cbottom instanceof EnemyItem) {
					Explode();
					if (!((EnemyItem)cbottom).m_beingBeaten)
						((EnemyItem)cbottom).GetBulletHit(m_iDir);
				} else {
					m_iTickCount = 16;
					SetPosition(m_fPosX, cbottom.GetTop() - 13);
				}
			}
		}
	}   
	
	public void Explode() {
		m_isExploded = true;
		m_iTickCount = 4;
	}
        
	public void Tick() {
            if (m_isExploded) {
                if (m_iTickCount > 6)
                    this.Deregister(m_SpriteManager);
                else {
                    m_Sprite.setFrame(m_iTickCount);
                    m_iTickCount++;
                }
                return;
            }
            m_iTickCount--;
            Move();
            m_Sprite.setFrame(MarioGameCanvas.s_iCurrentTime / 30 % 4);
        }
		
	// Deregister the sprite item to the sprite manager
	public void Deregister (SpriteManager manager) {
		super.Deregister(manager);
		Mario.s_iBullet++;		
	}
			
}