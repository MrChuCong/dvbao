import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.*;
import java.util.*;

public class SpriteManager {
	// The list of sprite items
	protected Vector		m_vecSpriteItems;
	// The layer manager of the play field
	protected LayerManager	m_LayerManager;
	
	public SpriteManager () {
		m_vecSpriteItems = new Vector();
		m_LayerManager = new LayerManager();
	}
	
	public void AddElement (SpriteItem item) {
		AddElement(item, false);
	}
	
	public void AddElement (SpriteItem item, boolean firstLayer) {
		m_vecSpriteItems.addElement(item);
		if (firstLayer)
			m_LayerManager.insert(item.m_Sprite, 0);
		else
			m_LayerManager.append(item.m_Sprite);
	}
		
	public void InsertElementAt(SpriteItem item, int index)	{
		m_vecSpriteItems.insertElementAt(item, index);
		m_LayerManager.insert(item.m_Sprite, index);
	}
        
	public void RemoveElement (SpriteItem item) {
		// Remove the sprite item from the list
		m_vecSpriteItems.removeElement(item);
		// Remove the internal sprite from the layer manager
		m_LayerManager.remove(item.m_Sprite);
	}
	
	public void NotifyItemsToTick () {
		for (int i=0; i<m_vecSpriteItems.size(); i++) {
			SpriteItem item = (SpriteItem)m_vecSpriteItems.elementAt(i);
			// Process the tick event of each sprite item
			item.Tick();
		}
	}
	
	// Paint all sprite items
	public void Paint (Graphics graphics) {
		m_LayerManager.paint(graphics, 0, 0);
	}
}