public class PipeItem extends StaticItem {
	protected int m_iType;
	protected boolean m_isDown = false;
	protected boolean m_isRight = false;
	
	public PipeItem (int itemID, int row, int col) {
		super(itemID, row, col, 32, 32);
		m_iType = itemID;
	}
	
	public void Tick () {
	}
}