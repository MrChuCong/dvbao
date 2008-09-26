import javax.microedition.lcdui.Image;

public class BonusItem extends SpriteItem {
	protected int m_iType;
	protected SpriteItem m_Bonus = null;
    protected boolean m_isRevealed = false;
        
	public void MakeMoving () {
		if (m_iTickCount > 0) {
			SetPosition(m_fPosX, m_fPosY + Math.min(m_iTickCount, 10 - m_iTickCount));
		}
		m_iTickCount = 10;
	}
    	
	public void Tick () {
		if (m_iTickCount > 0) {			
			m_iTickCount--;			
			if (m_iTickCount >= 5)
				SetPosition(m_fPosX, m_fPosY - 1);
			else
				SetPosition(m_fPosX, m_fPosY + 1);				
			if (m_iTickCount <= 0) {        // end reveal
				if (m_Bonus instanceof FlowerItem) {
					//mushroom music
					MusicManager.GetInstance().Play(MusicManager.k_MoveUp);
					int level = PlayField.s_Instance.m_Mario.m_iLevel;
					if (level == Mario.k_SMALL) {				
						// Change to mush room
						m_Bonus = new MushroomItem((FlowerItem)m_Bonus);
						m_Bonus.Register(this.m_SpriteManager);
						((MushroomItem)m_Bonus).MoveUpward();
					} else {
						m_Bonus.Register(this.m_SpriteManager);
						((FlowerItem)m_Bonus).MoveUpward();
					}
				}
				else if (m_Bonus instanceof StarItem) {
					m_Bonus.Register(this.m_SpriteManager);
					((StarItem)m_Bonus).MoveUpward();
				} else if (m_Bonus instanceof MushroomItem) {     // life mushroom
					//mushroom music
					MusicManager.GetInstance().Play(MusicManager.k_MoveUp);
					m_Bonus.Register(this.m_SpriteManager);
					((MushroomItem)m_Bonus).MoveUpward();
				}								
			}	
		}
	}
        
        public void BeginReveal () {
            if (m_Bonus instanceof FlipCoin) {
                if (!((FlipCoin)m_Bonus).m_isUpward)
                    m_Bonus.Register(this.m_SpriteManager, true);
                ((FlipCoin)m_Bonus).MoveUpward();
                if (((FlipCoin)m_Bonus).m_iCoinCount > 0)
                {
                    MakeMoving();
                    return;
                }
            }
            
            Image image = null;
            switch (m_iType) {
                case Resource.k_Light_Item:
                case Resource.k_Red_Top_Brick:
                case Resource.k_Red_Normal_Brick:
                case Resource.k_Red_Hidden_Brick:
                    image = Resource.GetImage(Resource.k_Red_Hard_Brick);
                    break;
                case Resource.k_Dark_Item:
                case Resource.k_Green_Top_Brick:
                case Resource.k_Green_Normal_Brick:
                case Resource.k_Green_Hidden_Brick:
                    image = Resource.GetImage(Resource.k_Green_Hard_Brick);
                    break;
                case Resource.k_White_Top_Brick:
                case Resource.k_White_Normal_Brick:
                    image = Resource.GetImage(Resource.k_White_Hard_Brick);
                    break;
            }
       
            m_Sprite.setImage(image, 16, 16);
            m_Sprite.setFrame(0);
            MakeMoving();
            m_isRevealed = true;
        }
}