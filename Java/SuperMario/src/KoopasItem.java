import javax.microedition.lcdui.game.*; 
import java.util.*;
public class KoopasItem extends EnemyItem {
    protected boolean m_haveWing;
    protected boolean m_isKicked;
    public KoopasItem(int itemID, boolean haveWing, int row, int col) {
        m_haveWing = haveWing;
        if (itemID == Resource.k_Red_Koopas_NoWing)
            itemID = Resource.k_Red_Koopas;
        else if (itemID == Resource.k_Green_Koopas_NoWing)
            itemID = Resource.k_Green_Koopas;
        else if (itemID == Resource.k_White_Koopas_NoWing)
            itemID = Resource.k_White_Koopas;
        InitEnemy(itemID, row, col, 16, 32);
        m_isKicked = false;
        if (m_haveWing) {            
            m_iTickCount = 201;
        }
    }

    public void Move() {
        if (!m_haveWing)
            super.Move();
        else {
            m_iTickCount--;
            if (m_iTickCount <= 0)
                m_iTickCount = 200;
            if (m_iTickCount >= 170)
                SetPosition(m_fPosX, m_fPosY - 1);
            else if (m_iTickCount >= 140)
                SetPosition(m_fPosX, m_fPosY - 2);
            else if (m_iTickCount >= 110)
                SetPosition(m_fPosX, m_fPosY - 1);
            else if (m_iTickCount >= 100) {}
            else if (m_iTickCount >= 70)
                SetPosition(m_fPosX, m_fPosY + 1);
            else if (m_iTickCount >= 40)
                SetPosition(m_fPosX, m_fPosY + 2);
            else if (m_iTickCount >= 10)
                SetPosition(m_fPosX, m_fPosY + 1);
        }
    }
    
    public void UpdateFrame() {
        if (m_isActive) {
            if (m_iDir > 0)
                m_Sprite.setTransform(Sprite.TRANS_MIRROR);
            else
                m_Sprite.setTransform(Sprite.TRANS_NONE);
            if (!m_isKicked) {
                if (m_haveWing)
                    m_Sprite.setFrame(MarioGameCanvas.s_iCurrentTime / 240 % 2);
                else
                    m_Sprite.setFrame(MarioGameCanvas.s_iCurrentTime / 240 % 2 + 2);
            }
        } else {
            m_iTickCount--;
            if (!m_beingBeaten) {
                if (m_iTickCount == 0) {
                    m_isActive = true;
                    m_fSpeed = 1;
                    return;
                }
                if (m_iTickCount <= 30)
                    m_Sprite.setFrame(m_iTickCount/3%2 + 4);
            } else {
                if (m_iTickCount == 0)
                    this.Deregister(m_SpriteManager);
                if (m_iTickCount < 45)
                    m_fHover = 5;
            }
        }
    }
    
    public void GetStomped() {        
        if (m_haveWing) {
            m_haveWing = false;
            m_fSpeed = 1;
            return;
        }
        m_isActive = false;
        m_fSpeed = 0;
        m_Sprite.setFrame(5);
        m_iTickCount = 160;
		
		//increase point
		PlayField.s_Instance.m_Mario.m_iPoint += Mario.k_KILLS_ENEMY_POINT;
		// stomp music
		MusicManager.GetInstance().Play(MusicManager.k_Stomp);
    }
    
    public void GetBulletHit(int dir) {        
        m_haveWing = false;
        GetBeaten(dir);
    }
    
    public void GetBeaten(int dir) {        
        super.GetBeaten(dir);
        m_Sprite.setFrame(5);
        m_Sprite.setTransform(Sprite.TRANS_ROT180);
    }
    
    public void GetKicked(int dir) {
        m_isActive = true;
        m_isKicked = true;
        m_iDir = dir;
        m_fSpeed = 4.5f;
        SetPosition(m_fPosX + m_iDir * m_fSpeed, m_fPosY);
    }
    
}	
	