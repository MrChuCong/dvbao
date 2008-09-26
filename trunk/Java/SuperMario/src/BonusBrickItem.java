public class BonusBrickItem extends BonusItem {
	public BonusBrickItem (int itemID, int row, int col, SpriteItem bonus) {
		Initialize(Resource.GetImage(itemID), 16, 16);
		m_Sprite.setRefPixelPosition(col * 16, row * 16);
		m_iType = itemID;
		m_fPosX = GetLeft();
		m_fPosY = GetTop();
		m_Bonus = bonus;
		m_iType = itemID;
	}
	
	public void Tick () {
		super.Tick();
	}
}