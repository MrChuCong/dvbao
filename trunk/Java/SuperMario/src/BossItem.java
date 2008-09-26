import java.util.Random;
import javax.microedition.lcdui.game.Sprite;

public class BossItem extends EnemyItem {    
    protected static float k_DISTANCE = 55;
    protected int m_iLife;
    protected boolean m_willFire;
    protected boolean m_isMoving;
    protected boolean m_isJumping;
    protected Random rand;
    protected float m_fStartPosX, m_fStartPosY;
    protected int m_iPrepareCount;

    public void SetPosition(float x, float y) {
        m_fPosX = x;
		m_fPosY = y;
		m_Sprite.setRefPixelPosition((int)x + 16, (int)y + 16);
    }
    
    public BossItem (int itemID, int row, int col) {
         InitEnemy(itemID, row, col, 32, 32);
         m_iLife = 5;
         m_willFire = false;
         m_isMoving = false;
         m_isJumping = false;
         m_iDir = -1;
         m_fStartPosX = m_fPosX;
         m_fStartPosY = m_fPosY;
         rand = new Random();
    }

    public void Tick() {
        if (m_beingBeaten) {
            m_iTickCount--;
            if (m_iTickCount == 35)
                  m_fHover = 3;
            SetPosition(m_fPosX, m_fPosY + m_fHover);
            return;
        }
        UpdateFrame();
        if (m_isMoving || m_isJumping) {
            m_iTickCount--;
            if (m_iTickCount <= 0 && !m_isJumping) {
                m_isMoving = false;
                return;
            }
            SetPosition(m_fPosX + m_iDir, m_fPosY);
            if (m_fPosX < m_fStartPosX - k_DISTANCE || m_fPosX > m_fStartPosX + k_DISTANCE)
                m_iDir *= -1;
            if (m_isJumping) {
                if (m_iTickCount <= 0) {
                    m_isJumping = false;
                    return;
                }
                int dy = 0;
                if (m_iTickCount > 15)  {// going upper
                    if (m_iTickCount > 25)
                        dy = -4;
                    else if (m_iTickCount > 20)
                        dy = -2;
                    else
                        dy = -1;
                } else {
                    if (m_iTickCount <= 5)
                        dy = 4;
                    else if (m_iTickCount <= 10)
                        dy = 2;
                    else
                        dy = 1;
                }
                SetPosition(m_fPosX, m_fPosY + dy);
            }
        } else {
            if (PlayField.s_Instance.m_Mario.GetLeft() > this.GetRight()) {
                // chase Mario
                m_Sprite.setTransform(Sprite.TRANS_MIRROR);
                if (m_fPosX < m_fStartPosX + k_DISTANCE)
                    SetPosition(m_fPosX + 2, m_fPosY);
                return;
            }
            m_Sprite.setTransform(Sprite.TRANS_NONE);
            int x = rand.nextInt() % 15;
            if (x == 0) {
                m_isMoving = true;
                m_isJumping = false;
                m_iTickCount = 16;
            } else if (x == 2) {
                m_isMoving = false;
                m_isJumping = true;
                m_iTickCount = 31;
            }
        }
        
    }
    
    public void UpdateFrame() {
        m_iPrepareCount--;
        if (!m_willFire) {
            if (m_iPrepareCount <= 0 && PlayField.s_Instance.m_Mario.GetLeft() < this.GetRight()) {
                if (rand.nextInt() % 3 != 0) {
                    m_willFire = true;
                    m_iPrepareCount = 21;
                }
                else
                    m_iPrepareCount = 41;
                return;
            }
            if (m_iTickCount / 4 % 2 == 0)
                m_Sprite.setFrame(0);
            else
                m_Sprite.setFrame(1);
        } else {
            if (m_iPrepareCount <= 0) {
                Fire();
                m_willFire = false;
                m_iPrepareCount = 41;
                return;
            }
            if (m_iTickCount / 4 % 2 == 0)
                m_Sprite.setFrame(2);
            else
                m_Sprite.setFrame(3);
        }
    }
  
    public void Fire () {
        BossBullet bullet = new BossBullet(this);
        bullet.Register(m_SpriteManager);
    }
    
    public void GetStomped() {
        // cannot happen ^__^
    }
    
    public void GetBulletHit(int dir) {
        m_iLife--;
        if (m_iLife <= 0)
            GetBeaten(dir);
    }
    
    public void GetBeaten(int dir) {
        super.GetBeaten(dir);
        m_fHover = -3;
        m_Sprite.setTransform(Sprite.TRANS_ROT180);
    }
}
