public class RuinBrickItem extends SpriteItem {
    protected int m_iRuinIndex;
    
    public static final float k_INITIAL_SPEED = 1.5f;
    public static final float k_INITIAL_HOVER_UPPER = -10.0f;
    public static final float k_INITIAL_HOVER_LOWER = -6.0f;
    public static final float k_FINAL_HOVER = -1.8f;
    public static final float k_HOVER_SCALE = 0.8f;
    
    protected float m_fSpeed;
    protected float m_fHover;
    
    public RuinBrickItem(BrickItem aBrick, int ruinIndex) {
        int type = aBrick.m_iType;
        m_iRuinIndex = ruinIndex;
        if (type == Resource.k_Red_Top_Brick || type == Resource.k_Red_Normal_Brick)
            Initialize(Resource.GetImage(Resource.k_Small_Red_Brick), 16, 16);
        else if (type == Resource.k_Green_Top_Brick || type == Resource.k_Green_Normal_Brick)
            Initialize(Resource.GetImage(Resource.k_Small_Green_Brick), 16, 16);
        else if (type == Resource.k_White_Top_Brick || type == Resource.k_White_Normal_Brick)
            Initialize(Resource.GetImage(Resource.k_Small_White_Brick), 16, 16);
        if (ruinIndex == 0) {
            SetPosition(aBrick.GetLeft() - 4, aBrick.GetTop() - 8);
            m_fSpeed = -k_INITIAL_SPEED;
            m_fHover = k_INITIAL_HOVER_UPPER;
        }
        else if (ruinIndex == 1) {
            SetPosition(aBrick.GetLeft() + 4, aBrick.GetTop() - 8);
            m_fSpeed = k_INITIAL_SPEED;
            m_fHover = k_INITIAL_HOVER_UPPER;
        }
        else if (ruinIndex == 2) {
            SetPosition(aBrick.GetLeft() - 4, aBrick.GetTop());
            m_fSpeed = -k_INITIAL_SPEED;
            m_fHover = k_INITIAL_HOVER_LOWER;
        }
        else if (ruinIndex == 3) {
             SetPosition(aBrick.GetLeft() + 4, aBrick.GetTop());
             m_fSpeed = k_INITIAL_SPEED;
             m_fHover = k_INITIAL_HOVER_LOWER;
        }

        m_Sprite.setFrame(0);
        m_iTickCount = 45;
    }
    
    public void Tick() {
        m_iTickCount--;
        if (m_iTickCount <= 0)
            Deregister(m_SpriteManager);
        else {
            SetPosition(m_fPosX + m_fSpeed, m_fPosY + m_fHover);
            if (m_fHover < 0) {
                m_fHover *= k_HOVER_SCALE;
                if (m_fHover > k_FINAL_HOVER)
                    m_fHover = -m_fHover;
            } else
                m_fHover /= k_HOVER_SCALE;
        }
    }
}
