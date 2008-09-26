import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.Sprite;
import java.util.Random;
        
public class BossBullet extends SpriteItem {
    
    protected float m_fHeight;   // 16, 32, 48
    public BossBullet(BossItem boss) {
        try {
            Image image = Image.createImage(64, 16);
            Image bullet = Resource.GetImage(Resource.k_Fire_Boss);
            Graphics g = image.getGraphics();
            g.drawImage(bullet, 0, 0, Graphics.LEFT|Graphics.TOP);
            g.drawRegion(bullet, 0, 0, 32, 16, Sprite.TRANS_MIRROR_ROT180, 32, 0, Graphics.LEFT|Graphics.TOP);
            image = MarioTransform.FilterImage(image, 0x00FFFFFF);
            m_Sprite = new Sprite(image, 32, 16);
            m_fPosX = boss.GetLeft() - 26;
            m_fPosY = boss.GetTop() + 4;
            m_Sprite.setRefPixelPosition((int)m_fPosX, (int)m_fPosY);            
            m_iTickCount = 200;
            int x = Math.abs((new Random()).nextInt()) % 5;
            if (x == 0)
                m_fHeight = boss.m_fStartPosY - 20;
            else if (x <= 2)
                m_fHeight = boss.m_fStartPosY - 4;
            else
                m_fHeight = boss.m_fStartPosY + 12; 
        }
        catch (Exception e) {
            e.printStackTrace();
        }
    }

    public void Tick() {
        m_iTickCount--;
        if (m_iTickCount <= 0) {
            this.Deregister(m_SpriteManager);
            return;
        }
        int dy = 0;
        if (m_fPosY + 1 < m_fHeight)
            dy = 2;
        if (m_fPosY - 1 > m_fHeight)
            dy = -2;
        SetPosition(m_fPosX - 2.5f, m_fPosY + dy);
        if (Math.abs(m_fPosY - m_fHeight) < 1)
            m_fPosY = m_fHeight;
        m_Sprite.setFrame((MarioGameCanvas.s_iCurrentTime / 60) % 2);
    }
    
}
