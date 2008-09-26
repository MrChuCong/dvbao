import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.*;

public class MarioTransform extends SpriteItem{
	public static final int k_GROWUP = 1;
	public static final int k_UPGRADE = 2;
	public static final int k_SHRINK = 3;
	public static final int k_DEATH = 4;
	
	private static Image k_SMALL_MARIO;
	private static Image k_MEDIUM_MARIO;
	private static Image k_LARGE_MARIO;
	private static Image k_LIGHT_MEDIUM_MARIO;
	private static Image k_DARK_MEDIUM_MARIO;
	
	public static Image transformImg = null;
	protected int m_iTransform;
	protected int m_iSeqIndex;
	
	private MarioTransform() {
		k_SMALL_MARIO = Resource.GetImage(Resource.k_Mario);
		k_MEDIUM_MARIO = Resource.GetImage(Resource.k_Medium_Mario);
		k_LARGE_MARIO = Resource.GetImage(Resource.k_Large_Mario);
		k_LIGHT_MEDIUM_MARIO = Resource.GetImage(Resource.k_Light_Medium_Mario);
		k_DARK_MEDIUM_MARIO = Resource.GetImage(Resource.k_Dark_Medium_Mario);
	}
	
	private static MarioTransform instance = null;
	
	public static MarioTransform getTransform(int transform, int seqIndex, int isForward) {
		if (instance == null)
			instance = new MarioTransform();
		try {
			instance.m_iTransform = transform;
			instance.m_iSeqIndex = seqIndex;
			if (transform == k_DEATH) {
				transformImg = k_SMALL_MARIO;
				instance.m_Sprite = new Sprite(transformImg, 16, 16);
				instance.m_Sprite.setFrame(1);
				instance.m_iTickCount = 60;
				return instance;
			}
			if (transform == k_GROWUP) {
                                transformImg = Image.createImage(48, 32);
                                Graphics g = transformImg.getGraphics();
				// draw first frame
				g.drawRegion(k_SMALL_MARIO, seqIndex * 16, 0, 16, 16,
					(isForward > 0 ? Sprite.TRANS_NONE : Sprite.TRANS_MIRROR), 0, 16, Graphics.TOP|Graphics.LEFT);
				// draw third frame
				g.drawRegion(k_MEDIUM_MARIO, seqIndex * 16, 0, 16, 16 * 2, 
					(isForward > 0 ? Sprite.TRANS_NONE : Sprite.TRANS_MIRROR), 16 * 2, 0, Graphics.TOP|Graphics.LEFT);
				// draw second frame
				g.drawRegion(k_MEDIUM_MARIO, seqIndex * 16, 0, 16, 12, 
					(isForward > 0 ? Sprite.TRANS_NONE : Sprite.TRANS_MIRROR), 16, 8, Graphics.TOP|Graphics.LEFT);
				g.drawRegion(k_MEDIUM_MARIO, seqIndex * 16, 18, 16, 12,
					(isForward > 0 ? Sprite.TRANS_NONE : Sprite.TRANS_MIRROR), 16, 20, Graphics.TOP|Graphics.LEFT);			
					
			} 
			else if (transform == k_UPGRADE) {
                                transformImg = Image.createImage(48, 32);
                                Graphics g = transformImg.getGraphics();
				// draw first frame
				g.drawRegion(k_DARK_MEDIUM_MARIO, seqIndex * 16, 0, 16, 16*2,
					(isForward > 0 ? Sprite.TRANS_NONE : Sprite.TRANS_MIRROR), 0, 0, Graphics.TOP|Graphics.LEFT);
				// draw third frame
				g.drawRegion(k_LARGE_MARIO, seqIndex * 16, 0, 16, 16 * 2, 
					(isForward > 0 ? Sprite.TRANS_NONE : Sprite.TRANS_MIRROR), 16, 0, Graphics.TOP|Graphics.LEFT);
				// draw second frame
				g.drawRegion(k_LIGHT_MEDIUM_MARIO, seqIndex * 16, 0, 16, 16*2, 
					(isForward > 0 ? Sprite.TRANS_NONE : Sprite.TRANS_MIRROR), 16*2, 0, Graphics.TOP|Graphics.LEFT);
			}
			else if (transform == k_SHRINK) {
                                transformImg = Image.createImage(64, 32);
                                Graphics g = transformImg.getGraphics();
                                // draw second frame
				g.drawRegion(k_MEDIUM_MARIO, seqIndex * 16, 0, 16, 16 * 2,
					(isForward > 0 ? Sprite.TRANS_NONE : Sprite.TRANS_MIRROR), 16, 0, Graphics.TOP|Graphics.LEFT);
				// draw fourth frame
				g.drawRegion(k_SMALL_MARIO, seqIndex * 16, 0, 16, 16, 
					(isForward > 0 ? Sprite.TRANS_NONE : Sprite.TRANS_MIRROR), 16 * 3, 16, Graphics.TOP|Graphics.LEFT);
				// draw third frame
				g.drawRegion(k_MEDIUM_MARIO, seqIndex * 16, 0, 16, 12, 
					(isForward > 0 ? Sprite.TRANS_NONE : Sprite.TRANS_MIRROR), 16 * 2, 8, Graphics.TOP|Graphics.LEFT);
				g.drawRegion(k_MEDIUM_MARIO, seqIndex * 16, 18, 16, 12,
					(isForward > 0 ? Sprite.TRANS_NONE : Sprite.TRANS_MIRROR), 16 * 2, 20, Graphics.TOP|Graphics.LEFT);	
                        }
                        // do sth crazy
			transformImg = FilterImage(transformImg, 0x00FFFFFF);
                        // end of crazy						
			instance.m_Sprite = new Sprite(transformImg, 16, 16 * 2);
			instance.m_Sprite.setFrame(0);
			instance.m_iTickCount = 25;
		} catch (Exception e) {                        		
		}
		return instance;
	}
	
	public static Image FilterImage(Image image, int transparentColor) {
		int tempPixel;
		int bitMask = 0x00FFFFFF;
		int blankPixel = 0x00000000;
		int colorMask = transparentColor & bitMask;
		int[] imageData = new int[image.getWidth() * image.getHeight()];
		image.getRGB(imageData, 0, image.getWidth(), 0, 0, image.getWidth(), image.getHeight());
		for(int k=0; k < imageData.length; k++) {
			tempPixel = imageData[k] & bitMask;
			if(tempPixel == colorMask) {
			imageData[k] = blankPixel;
			}
		}
		return Image.createRGBImage(imageData, image.getWidth(), image.getHeight(), true);
	}
	
	public void Tick() {
		m_iTickCount--;
		if (m_iTickCount == 0) {
			PlayField playField = PlayField.s_Instance;
			playField.Resume();
			if (m_iTransform == k_DEATH) {
				playField.m_Mario.NotifyDeath();
				return;
			}
			this.Deregister(playField.m_SpriteManager);
			playField.m_Mario.Register(playField.m_SpriteManager);
			return;
		}
		if (m_iTransform == k_GROWUP) {
			if (m_iTickCount == 22)
					m_Sprite.setFrame(1);
			if (m_iTickCount == 19)
					m_Sprite.setFrame(0);
			if (m_iTickCount == 16)
					m_Sprite.setFrame(1);
			if (m_iTickCount == 13)
					m_Sprite.setFrame(0);
			if (m_iTickCount == 10)
					m_Sprite.setFrame(1);
			if (m_iTickCount == 7)
					m_Sprite.setFrame(2);
			if (m_iTickCount == 4)
					m_Sprite.setFrame(1);
			if (m_iTickCount == 1)
					m_Sprite.setFrame(2);
		}
		else if (m_iTransform == k_UPGRADE) {
			if (m_iTickCount == 22)
					m_Sprite.setFrame(1);
			if (m_iTickCount == 19)
					m_Sprite.setFrame(2);
			if (m_iTickCount == 16)
					m_Sprite.setFrame(0);
			if (m_iTickCount == 13)
					m_Sprite.setFrame(1);
			if (m_iTickCount == 10)
					m_Sprite.setFrame(2);
			if (m_iTickCount == 7)
					m_Sprite.setFrame(0);
			if (m_iTickCount == 4)
					m_Sprite.setFrame(1);
			if (m_iTickCount == 1)
					m_Sprite.setFrame(2);
		}
		else if (m_iTransform == k_SHRINK) {
			if (m_iTickCount == 23)
					m_Sprite.setFrame(1);
			if (m_iTickCount == 21)
					m_Sprite.setFrame(0);
			if (m_iTickCount == 19)
					m_Sprite.setFrame(2);
			if (m_iTickCount == 17)
					m_Sprite.setFrame(0);
			if (m_iTickCount == 15)
					m_Sprite.setFrame(2);
			if (m_iTickCount == 13)
					m_Sprite.setFrame(0);
			if (m_iTickCount == 11)
					m_Sprite.setFrame(3);
			if (m_iTickCount == 9)
					m_Sprite.setFrame(2);
			if (m_iTickCount == 7)
					m_Sprite.setFrame(0);
			if (m_iTickCount == 5)
					m_Sprite.setFrame(3);
			if (m_iTickCount == 3)
					m_Sprite.setFrame(0);
			if (m_iTickCount == 1)
					m_Sprite.setFrame(3);
		}
		else if (m_iTransform == k_DEATH) {
			if (m_iTickCount > 50) {}
			else if (m_iTickCount > 35)
				m_fPosY -= 5;
			else
				m_fPosY += 5;
			m_Sprite.setRefPixelPosition((int)m_fPosX, (int)m_fPosY);
		}
	}
	
	
}