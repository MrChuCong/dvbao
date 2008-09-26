public class FlowerItem extends SpriteItem {
    
	protected boolean m_isUpward = false;
        
	public FlowerItem (int itemID, int row, int col) {
		Initialize(Resource.GetImage(itemID), 16, 16);
		m_Sprite.setRefPixelPosition(col * 16, row * 16);
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
			}
			SetPosition(m_fPosX, m_fPosY - 1);
		}
		m_Sprite.setFrame(
		(MarioGameCanvas.s_iCurrentTime / 60) % 4);
	}
}