public class StaticItem extends SpriteItem {
	public StaticItem (int itemID, int row, int col) {
		Initialize(Resource.GetImage(itemID), 16, 16);
		m_Sprite.setRefPixelPosition(col * 16, row * 16);
	}
	
	public StaticItem (int itemID, int row, int col,
		int width, int height) {
		Initialize(Resource.GetImage(itemID), width, height);
		m_Sprite.setRefPixelPosition(col * 16, row * 16);
	}
	
	public void Tick () {
	}
}