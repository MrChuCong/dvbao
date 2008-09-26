import javax.microedition.lcdui.game.*; 

public abstract class EnemyItem extends SpriteItem {
    
    protected float m_fSpeed;   // horizontal speed of the enemy
    protected float m_fHover;   // vertical speed of enemy
    protected boolean m_isFalling;
    protected boolean m_isActive;   // indicate that it can make Mario shrink
    protected boolean m_beingBeaten;   // indicate that it is flying upside-down to hell
    
    public void InitEnemy (int itemID, int row, int col, int width, int height) {
        Initialize(Resource.GetImage(itemID), width, height);
        m_Sprite.defineReferencePixel(m_Sprite.getWidth() / 2, m_Sprite.getHeight() / 2);
        SetPosition(col * 16, row * 16);
        m_iDir = -1;
        m_fSpeed = 1;
        m_fHover = 3;
        m_isFalling = false;
        m_isActive = true;
        m_beingBeaten = false;
        m_iTickCount = 0;
    }
    
    public void SetPosition (float x, float y) {
		m_fPosX = x;
		m_fPosY = y;
		m_Sprite.setRefPixelPosition((int)(x + m_Sprite.getWidth()/2), (int)(y + m_Sprite.getHeight() / 2));
    }
    
    public void Tick() {
        Move();
        UpdateFrame();
    }
    
    public void Move() {
        if (m_fPosY > PlayField.k_ScreenHeight || m_fPosX < PlayField.s_Instance.m_fLeftPos) {            
            Deregister(m_SpriteManager);
            return;
        }
        
        // try to move vertically
        SetPosition(m_fPosX, m_fPosY + m_fHover);
        if (m_beingBeaten) {
            SetPosition(m_fPosX + m_iDir * m_fSpeed, m_fPosY);
            return;
        }
        SpriteItem cbottom = GetCollisionBottom();
        SpriteItem ctop = GetCollisionTop();
        if (cbottom == ctop && (cbottom instanceof StaticItem || cbottom instanceof BrickItem ||
            cbottom instanceof BonusItem)) {
            // handle bug that enemy is stuck
            SetPosition(m_fPosX, cbottom.GetTop() - m_Sprite.getHeight());
            m_isFalling = false;
            return;
        }
        if (!m_isFalling) {
            if (cbottom == null || !(cbottom instanceof StaticItem || cbottom instanceof EnemyItem ||
                cbottom instanceof BrickItem || cbottom instanceof BonusItem)) {   // check if drop down
                m_isFalling = true;                
                SetPosition(m_fPosX, m_fPosY + m_fHover);
            }
        } else {    // is falling
            if (cbottom instanceof StaticItem || cbottom instanceof BrickItem ||
                    cbottom instanceof EnemyItem || cbottom instanceof BonusItem) {
                m_isFalling = false;
                SetPosition(m_fPosX, cbottom.GetTop() - m_Sprite.getHeight() + m_fHover);
            } else
                SetPosition(m_fPosX, m_fPosY + m_fHover);
        }
        SetPosition(m_fPosX, m_fPosY - m_fHover);
        
        // try to move horizontal
        SetPosition(m_fPosX + m_fSpeed * m_iDir, m_fPosY);
        if (m_iDir < 0) { // check left collision
            SpriteItem cleft = GetCollisionLeft();
            if (cleft instanceof EnemyItem || cleft instanceof StaticItem || 
                cleft instanceof BrickItem || cleft instanceof BonusItem) {
                boolean b = false;
                if (this instanceof KoopasItem)
                    if (((KoopasItem)this).m_isKicked)
                        b = true;
                if (this instanceof BeetleItem)
                    if (((BeetleItem)this).m_isKicked)
                        b = true;
                if (b && cleft instanceof EnemyItem) {        // koopas/beetle shell hit another enemy
                    ((EnemyItem)cleft).GetBeaten(m_iDir);
                } else {
                    // change direction and restore
                    m_iDir = 1;
                    SetPosition(m_fPosX + m_fSpeed * m_iDir, m_fPosY);
                }
            }
        } else {    // check right collision
            SpriteItem cright = GetCollisionRight();
            if (cright instanceof EnemyItem || cright instanceof StaticItem || 
                cright instanceof BrickItem || cright instanceof BonusItem) {
                boolean b = false;
                if (this instanceof KoopasItem)
                    if (((KoopasItem)this).m_isKicked)
                        b = true;
                if (this instanceof BeetleItem)
                    if (((BeetleItem)this).m_isKicked)
                        b = true;
                if (b && cright instanceof EnemyItem) {        // koopas/beetle shell hit another enemy
                    ((EnemyItem)cright).GetBeaten(m_iDir);
                } else {
                    // change direction and restore
                    m_iDir = -1;
                    SetPosition(m_fPosX + m_fSpeed * m_iDir, m_fPosY);
                }
            }
        }
    }
    
    public abstract void UpdateFrame();    
    
    public abstract void GetStomped();      // when Mario stomp at its head
    
    public abstract void GetBulletHit(int dir);    // when Mario's bullet hits
    
    public void GetBeaten(int dir)  {      // when staring Mario or koopas/beetle shell hits
        m_iDir = dir;
        m_isActive = false;
        m_beingBeaten = true;
        m_fHover = -3f;
        m_fSpeed = 1.5f;
        m_iTickCount = 50;
        SpriteManager manager = m_SpriteManager;
        Deregister(manager);
        Register(manager, true);
		
		//increase point
		PlayField.s_Instance.m_Mario.m_iPoint += Mario.k_KILLS_ENEMY_POINT;
		// stomp music
		MusicManager.GetInstance().Play(MusicManager.k_Stomp);
    }
}