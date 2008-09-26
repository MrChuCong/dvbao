public class MushroomItem extends SpriteItem {
	protected int m_iType;
	protected boolean m_isUpward;
	protected boolean m_isMoving;
        protected boolean m_isFalling = false;
        
	public MushroomItem (int itemID, int row, int col) {
		Initialize(Resource.GetImage(itemID), 16, 16);
		m_Sprite.setRefPixelPosition(col * 16, row * 16);
		m_iType = itemID;
		m_wasTransparent = true;
		m_fPosX = GetLeft();
		m_fPosY = GetTop();
	}
	
	public MushroomItem (FlowerItem item) {
		Initialize(Resource.GetImage(Resource.k_Grow_Mushroom), 16, 16);
		m_Sprite.setRefPixelPosition(item.GetLeft(), item.GetTop());
		m_iType = Resource.k_Grow_Mushroom;
		m_wasTransparent = true;
		m_fPosX = GetLeft();
		m_fPosY = GetTop();
	}
	
	public void MoveUpward () {
		m_isUpward = true;
		m_iTickCount = 17;
	}
        
	public void Tick () {
		if (m_isUpward) {
			m_iTickCount--;
			if (m_iTickCount <= 0) {
				m_isUpward = false;
				m_isMoving = true;
			}
			SetPosition(m_fPosX, m_fPosY - 1);
		}
		else if (m_isMoving) {
			// try to move vertically
			SetPosition(m_fPosX, m_fPosY + 3);
			SpriteItem cbottom = GetCollisionBottom();
			if (!m_isFalling) {
				if (cbottom == null || !(cbottom instanceof StaticItem ||
					cbottom instanceof BrickItem || cbottom instanceof BonusItem)) {   // check if drop down
					m_isFalling = true;                        
					SetPosition(m_fPosX, m_fPosY + 3);
				}
			} else {    // is falling
				if (cbottom instanceof StaticItem || cbottom instanceof BrickItem ||
					cbottom instanceof BonusItem) {
					m_isFalling = false;
					SetPosition(m_fPosX, cbottom.GetTop() - m_Sprite.getHeight() + 1);
				} else
					SetPosition(m_fPosX, m_fPosY + 3);
			}
			SetPosition(m_fPosX, m_fPosY - 3);
			if (m_fPosY > PlayField.k_ScreenHeight) {
				this.Deregister(m_SpriteManager);
				return;
			}
			
			// try to move horizontal
			SetPosition(m_fPosX + 2 * m_iDir, m_fPosY);
			if (m_iDir < 0) { // check left collision
				SpriteItem cleft = GetCollisionLeft();
				if (cleft instanceof StaticItem || 
					cleft instanceof BrickItem || cleft instanceof BonusItem) {
					// change direction and restore
					m_iDir = 1;
					SetPosition(m_fPosX + 2 * m_iDir, m_fPosY);
				}
			} else {    // check right collision
				SpriteItem cright = GetCollisionRight();
				if (cright instanceof StaticItem || 
					cright instanceof BrickItem || cright instanceof BonusItem) {
					// change direction and restore
					m_iDir = -1;
					SetPosition(m_fPosX + 2 * m_iDir, m_fPosY);
				}
			}
			if (m_fPosX < PlayField.s_Instance.m_fLeftPos - 40 || 
					m_fPosX > PlayField.s_Instance.m_fLeftPos + PlayField.k_ScreenWidth + 40)
				this.Deregister(m_SpriteManager);
		}
	}
	
	public boolean ProcessFalling () {
		SpriteItem itemBottom = GetCollisionBottom();
		if (itemBottom == null) {	
			m_fPosX += 0.1*m_iDir;
			m_fPosY += 2;								
			SetPosition(m_fPosX, m_fPosY);							
			return true;
		}		
		return false;
	}
}