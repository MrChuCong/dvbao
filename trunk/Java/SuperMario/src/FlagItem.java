public class FlagItem extends SpriteItem {
	public FlagItem (int itemID, int row, int col) {
		Initialize(Resource.GetImage(itemID), 16, 16);
		m_Sprite.setRefPixelPosition(col * 16, row * 16);
	}
	
	public void Tick () {
	}
}