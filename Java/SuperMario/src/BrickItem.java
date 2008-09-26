public class BrickItem extends SpriteItem {
	protected int m_iType;
	
	public BrickItem (int itemID, int row, int col) {
		Initialize(Resource.GetImage(itemID), 16, 16);
		m_Sprite.setRefPixelPosition(col * 16, row * 16);
		m_iType = itemID;
		m_fPosX = GetLeft();
		m_fPosY = GetTop();
	}
	
	public void MakeMoving () {
		if (m_iTickCount > 0) {
			SetPosition(m_fPosX, m_fPosY + Math.min(m_iTickCount, 10 - m_iTickCount));
		}
		m_iTickCount = 10;
	}
        
	public void Tick () {
		if (m_iTickCount > 0){
			m_iTickCount--;
			if (m_iTickCount >= 5)
				SetPosition(m_fPosX, m_fPosY - 1);
			else
				SetPosition(m_fPosX, m_fPosY + 1);
		}
	}
}