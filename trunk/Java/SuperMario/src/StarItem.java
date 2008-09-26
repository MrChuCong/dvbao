public class StarItem extends SpriteItem {
    
        protected boolean m_isUpward = false;		
        protected boolean m_isMoving = false;
        
	public StarItem (int itemID, int row, int col) {
		Initialize(Resource.GetImage(itemID), 16, 16);
		m_Sprite.setRefPixelPosition(col * 16, row * 16);
		m_wasTransparent = true;
                m_fPosX = GetLeft();
		m_fPosY = GetTop();
	}
	
        public void MoveUpward () {
            m_isUpward = true;
            m_isMoving = false;
            m_iTickCount = 17;
        }
		
	public void Tick () {
            if (m_isUpward || m_isMoving) {
                m_iTickCount--;
                if (m_iTickCount <= 0 && m_isUpward) {
                    m_isUpward = false;
                    m_isMoving = true;
                    m_iDir = 1;
                    m_iTickCount = 21;
                    return;
                }
                if (m_isUpward)
                    SetPosition(m_fPosX, m_fPosY - 1);
                if (m_isMoving) {
                    if (m_fPosY > PlayField.k_ScreenHeight || m_fPosX < PlayField.s_Instance.m_fLeftPos ||
                            m_fPosX > PlayField.k_ScreenHeight + PlayField.s_Instance.m_fLeftPos) {
                        //System.out.println("Star disappeared");
                        Deregister(m_SpriteManager);
                        return;
                    }
                    // try moving horizon
                    m_fPrevPosX = m_fPosX;
                    SetPosition(m_fPosX + m_iDir * 2, m_fPosY);
                    SpriteItem cleft = GetCollisionLeft();
                    SpriteItem cright = GetCollisionRight();
                    if (cleft != null) {
                        if (cleft instanceof StaticItem || cleft instanceof BrickItem || cleft instanceof BonusItem) {
                            //System.out.println("Collision left");
                            m_iDir *= -1;
                            SetPosition(m_fPrevPosX, m_fPrevPosY);
                        }
                    }
                    else if (cright != null) {
                        if (cright instanceof StaticItem || cright instanceof BrickItem || cright instanceof BonusItem) {                           
                            //System.out.println("Collision right");
                            m_iDir *= -1;
                            SetPosition(m_fPrevPosX, m_fPrevPosY);
                        }
                    }
                    // try moving vertically
                    m_fPrevPosY = m_fPosY;
                    int dy = 0;
                    if (m_iTickCount > 10)  {// going upper
                        if (m_iTickCount > 16)
                            dy = -5;
                        else if (m_iTickCount > 13)
                            dy = -3;
                        else
                            dy = -1;
                    } else {
                        if (m_iTickCount <= 4)
                            dy = 5;
                        else if (m_iTickCount <= 7)
                            dy = 3;
                        else
                            dy = 1;
                    }
                    SetPosition(m_fPosX, m_fPosY + dy);
                    SpriteItem ctop = GetCollisionTop();
                    SpriteItem cbottom = GetCollisionBottom();				
                    if (ctop != null) {
                        if (ctop instanceof StaticItem || ctop instanceof BrickItem || ctop instanceof BonusItem) {
                            //System.out.println("Collision top");
                            m_iTickCount = 21 - m_iTickCount;
                            SetPosition(m_fPrevPosX, m_fPrevPosY);
                        }
                    }
                    if (cbottom != null) {
                        if (cbottom instanceof StaticItem || cbottom instanceof BrickItem || cbottom instanceof BonusItem) {
                            //System.out.println("Collision bottom");
                            m_iTickCount = 21;
                            SetPosition(m_fPrevPosX, m_fPrevPosY);
                        }
                    }
                    
                }
            }
            m_Sprite.setFrame(
                    (MarioGameCanvas.s_iCurrentTime / 180) % 4);
	}
}