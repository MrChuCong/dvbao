import java.util.Vector;
import javax.microedition.lcdui.*;

public class CarnivoreItem extends EnemyItem {
            
    public CarnivoreItem (int itemID, int row, int col) {
        Initialize(Resource.GetImage(itemID), 16, 32);
        m_Sprite.defineReferencePixel(m_Sprite.getWidth() / 2, m_Sprite.getHeight() / 2);
        SetPosition(col * 16 + 8, row * 16);
        m_iDir = -1;
        m_isActive = true;
        m_iTickCount = 220;
    }
    
    public void GetStomped() {
        // No you can't ^^
    }

    public void GetBulletHit(int dir) {
        GetBeaten(dir);
    }

    public void GetBeaten(int dir) {
        this.Deregister(m_SpriteManager);
    }
    
    public void Tick() {
        m_iTickCount--;
        if (m_iTickCount <= 0)
            m_iTickCount = 220;
        if (m_iTickCount >= 160)
            SetPosition(m_fPosX, m_fPosY + 0.5f);
        else if (m_iTickCount <= 100 && m_iTickCount > 40) {
            Mario mario = PlayField.s_Instance.m_Mario;
            if (mario.GetRight() + 8 < this.GetLeft() || mario.GetLeft() > this.GetRight() + 8)
                SetPosition(m_fPosX, m_fPosY - 0.5f);
            else if (m_iTickCount == 100)
                m_iTickCount++;
        }
        UpdateFrame();
    }
    
    public void UpdateFrame() {
        m_Sprite.setFrame(MarioGameCanvas.s_iCurrentTime / 120 % 2);
    }
}
