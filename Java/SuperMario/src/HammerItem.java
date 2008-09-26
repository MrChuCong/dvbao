import javax.microedition.lcdui.*;

public class HammerItem extends SpriteItem {
    
    public HammerItem(int itemID, int row, int col) {
        Initialize(Resource.GetImage(itemID), 16, 16);
        m_Sprite.setRefPixelPosition(col * 16, row * 16);
        m_wasTransparent = true;
    }
    
    public void Tick() {
        m_Sprite.setFrame(
                (MarioGameCanvas.s_iCurrentTime / 180) % 3);
    }
    
}
