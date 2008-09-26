public class QuestionBoxItem extends BonusItem {
	public QuestionBoxItem (int itemID, int row, int col, SpriteItem bonus) {
		Initialize(Resource.GetImage(itemID), 16, 16);
		m_Sprite.setRefPixelPosition(col * 16, row * 16);
		m_Bonus = bonus;
		m_fPosX = GetLeft();
		m_fPosY = GetTop();
		m_iType = itemID;
	}
	
	public void Tick () {
		super.Tick();
		if (!m_isRevealed)
		m_Sprite.setFrame((MarioGameCanvas.s_iCurrentTime / 240) % 3);
	}
}