import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.*;
import java.util.*;

public abstract class SpriteItem {
	// The internal sprite
	protected Sprite	m_Sprite = null;
		
	// The counter to control the animation
	protected int		m_iTickCount;
        
	// Determine the item's direction
	protected int		m_iDir = 1;
	
	// Determine the position of the sprite
	protected float		m_fPosX;
	protected float		m_fPosY;
	
	// Determine the previous position of the sprite
	protected float		m_fPrevPosX;
	protected float		m_fPrevPosY;
	
	protected boolean	m_wasTransparent = false;
	
	// The registerd sprite manager
	protected SpriteManager	m_SpriteManager = null;
	
	// Initialize the internal sprite
	public void Initialize (Image image,
		int frameWidth, int frameHeight) {
		m_Sprite = new Sprite(image,
			frameWidth, frameHeight);
	}
	
	// Set the current position
	public void SetPosition (float x, float y) {
		m_fPosX = x;
		m_fPosY = y;
		m_Sprite.setRefPixelPosition((int)x, (int)y);
	}
	
	// Get the distance to another item
	public int GetDistance (SpriteItem item) {
		return Math.abs(m_Sprite.getX() - item.m_Sprite.getX()) +
			Math.abs(m_Sprite.getY() - item.m_Sprite.getY());
	}
	
	// Register the sprite item to the sprite manager
	public void Register (SpriteManager manager) {
		Register(manager, false);
	}
	
	// Register the sprite item to the sprite manager as first layer
	public void Register (SpriteManager manager, boolean firstLayer) {
			m_SpriteManager = manager;
			manager.AddElement(this, firstLayer);
	}
	
	 // Register the sprite item to the sprite manager as index layer
	public void Register (SpriteManager manager, int index) {
			m_SpriteManager = manager;
			manager.InsertElementAt(this, index);
	}
        
	// Deregister the sprite item to the sprite manager
	public void Deregister (SpriteManager manager) {
		manager.RemoveElement(this);
		m_SpriteManager = null;
	}
	
	public int GetLeft () {
		return m_Sprite.getX();
	}
	
	public int GetRight () {
		return m_Sprite.getX() + m_Sprite.getWidth();
	}
	
	public int GetTop () {
		return m_Sprite.getY();
	}
	
	public int GetBottom () {
		return m_Sprite.getY() + m_Sprite.getHeight();
	}
	
	public SpriteItem GetCollisionLeft () {
		SpriteItem result = null;
		Vector items = m_SpriteManager.m_vecSpriteItems;
		for (int i=0; i<items.size(); i++) {
			SpriteItem item = (SpriteItem)
				items.elementAt(i);
			if (item instanceof FlagItem) continue;
			int d = item.GetRight() - this.GetLeft();
			if (this != item &&
				d >= 0 && d <= 10 &&
				item.GetLeft() <= this.GetLeft() &&
				m_Sprite.collidesWith(item.m_Sprite, true)) {
				result = item;
			}
		}
		return result;
	}
	
	public SpriteItem GetCollisionRight () {
		SpriteItem result = null;
		Vector items = m_SpriteManager.m_vecSpriteItems;
		for (int i=0; i<items.size(); i++) {
			SpriteItem item = (SpriteItem)
				items.elementAt(i);
			if (item instanceof FlagItem) continue;
			int d = this.GetRight() - item.GetLeft();
			if (this != item &&
				d >= 0 && d <= 10 &&
				item.GetRight() >= this.GetRight() &&
				m_Sprite.collidesWith(item.m_Sprite, true)) {
				result = item;
			}
		}
		return result;
	}
		
	public SpriteItem GetCollisionTop () {
		SpriteItem result = null;
		Vector items = m_SpriteManager.m_vecSpriteItems;
		for (int i=0; i<items.size(); i++) {
			SpriteItem item = (SpriteItem)
				items.elementAt(i);
			if (item instanceof FlagItem) continue;
			int d = item.GetBottom() - this.GetTop();
			if (this != item &&
				d >= 0 && d <= 10 &&				
				item.GetTop() <= this.GetTop() &&
				m_Sprite.collidesWith(item.m_Sprite, true)) {				
				result = item;
			}
		}
		return result;
	}
	
	public SpriteItem GetCollisionBottom () {
		SpriteItem result = null;
		Vector items = m_SpriteManager.m_vecSpriteItems;
		for (int i=0; i<items.size(); i++) {
			SpriteItem item = (SpriteItem)
				items.elementAt(i);
			if (item instanceof FlagItem) continue;
			int d = this.GetBottom() - item.GetTop();
			if (item instanceof StaticItem) {
				if (this != item &&
					d >= 0 && d <= 10 &&				
					item.GetBottom() >= this.GetBottom() &&
					m_Sprite.collidesWith(item.m_Sprite, false)) {
					result = item;
				}
			} else {
                                if (item instanceof KoopasItem || item instanceof CarnivoreItem) {
                                    if (this != item &&
					d >= 6 && d <= 26 &&				
					item.GetBottom() >= this.GetBottom() &&
					m_Sprite.collidesWith(item.m_Sprite, true)) {
					result = item;
                                    }
                                }
                                else {
                                    boolean b = true;
                                    if (item instanceof HiddenBrickItem)
                                        if (!((HiddenBrickItem)item).m_isRevealed)
                                            b = false;
                                    if (this != item && b && !(item instanceof Mario) &&
					d >= 0 && d <= 10 &&				
					item.GetBottom() >= this.GetBottom() &&
					m_Sprite.collidesWith(item.m_Sprite, true)) {
					result = item;
                                    }
				}
			}
		}
		return result;
	}
	
	// Process per tick event
	public abstract void Tick ();
}