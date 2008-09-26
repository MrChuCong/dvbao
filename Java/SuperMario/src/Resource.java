import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.*;

public class Resource {
	//Sprites ID List		
	static final int	k_Mario					= 1;
	static final int	k_Medium_Mario			= 2;
	static final int	k_Dark_Mario			= 118;
	static final int	k_Dark_Medium_Mario		= 119;
	static final int	k_Light_Mario			= 120;
	static final int	k_Light_Medium_Mario	= 121;
	static final int	k_Large_Mario			= 3;
	static final int	k_Fire_Ball				= 4;
	static final int	k_Dark_Flower			= 5;
	static final int	k_Light_Flower			= 6;
	static final int	k_Red_Goomba			= 7;
	static final int	k_Green_Goomba			= 8;
	static final int	k_White_Goomba			= 9;
	static final int	k_Green_Koopas			= 10;
	static final int	k_Red_Koopas_NoWing		= 154;
	static final int	k_White_Koopas_NoWing	= 155;
	static final int	k_Green_Koopas_NoWing	= 153;
	static final int	k_Red_Koopas			= 11;	
	static final int	k_White_Koopas			= 12;
	static final int	k_Red_Beetle			= 13;
	static final int	k_Green_Beetle			= 14;
	static final int	k_White_Beetle			= 15;
	static final int	k_Green_Monkey			= 16;
	static final int	k_White_Monkey			= 17;
	static final int	k_Green_Cheep			= 18;
	static final int	k_Red_Cheep				= 19;
	static final int	k_White_Cheep			= 20;
	static final int	k_Light_Item			= 21;
	static final int	k_Dark_Item				= 22;
	static final int	k_Flip_Coin				= 23;
	static final int	k_Flip_Coins			= 156;
	static final int	k_Star					= 24;
	static final int	k_Dark_Coin				= 25;
	static final int	k_Light_Coin			= 26;
	static final int	k_Water_Coin			= 27;
	static final int	k_Green_Pirhara_Plant	= 28;
	static final int	k_White_Pirhara_Plant	= 29;
	static final int	k_Red_Spring			= 30;
	static final int	k_White_Spring			= 31;
	static final int	k_Bloopa				= 32;
	static final int	k_Boss					= 33;
	static final int	k_Hammer				= 34;
	static final int	k_Lakitu				= 35;
	static final int	k_Spiny					= 36;	
	static final int	k_Red_Axe				= 122;
	static final int	k_White_Axe				= 126;
	static final int	k_Small_White_Coin		= 125;
	static final int	k_Small_Red_Coin		= 124;
	static final int	k_Small_Green_Coin		= 123;	
	static final int	k_Grow_Mushroom			= 132;
	static final int	k_Life_Mushroom_1		= 133;
	static final int	k_Life_Mushroom_2		= 134;
	static final int	k_Small_Green_Brick		= 129;
	static final int	k_Small_Red_Brick		= 130;
	static final int	k_Small_White_Brick		= 131;
	static final int	k_Fire_Boss				= 135;
	static final int	k_Bullet_Bill_2			= 136;
	static final int	k_Bullet_Bill_3			= 137;
	static final int	k_Up_Fire_Ball			= 138;	
	// end list
		
	// TileSet ID list
	static final int	k_Green_Flag_1			= 37;
	static final int	k_Green_Connecting_Pipe	= 38;
	static final int	k_Green_Down_Pipe		= 39;
	static final int	k_Green_Pipe			= 40;	
	static final int	k_Green_Right_Pipe		= 41;
	static final int	k_Green_Up_Pipe			= 42;	
	static final int	k_Orange_Connecting_Pipe= 43;
	static final int	k_Orange_Down_Pipe		= 44;
	static final int	k_Orange_Pipe			= 45;	
	static final int	k_Orange_Right_Pipe		= 46;
	static final int	k_Orange_Up_Pipe		= 47;
	static final int	k_White_Connecting_Pipe = 48;
	static final int	k_White_Down_Pipe		= 49;
	static final int	k_White_Pipe			= 50;	
	static final int	k_White_Right_Pipe		= 51;
	static final int	k_White_Up_Pipe			= 52;	
	static final int	k_Blue_Connecting_Pipe  = 53;
	static final int	k_Blue_Down_Pipe		= 54;
	static final int	k_Blue_Pipe				= 55;	
	static final int	k_Blue_Right_Pipe		= 56;
	static final int	k_Blue_Up_Pipe			= 57;	
	static final int	k_Bridge_1				= 58;
	static final int	k_Bridge_2				= 59;
	static final int	k_Bridge_3				= 60;
	static final int	k_Bridge_4				= 61;
	static final int	k_Red_Ground			= 62;
	static final int	k_Red_Hard_Brick		= 63;
	static final int	k_Red_Stone				= 64;
	static final int	k_Mushroom_Tree_1		= 65;
	static final int	k_Mushroom_Tree_2		= 66;
	static final int	k_Mushroom_Tree_3		= 67;		
	static final int	k_Green_Ground			= 68;
	static final int	k_Green_Hard_Brick		= 69;
	static final int	k_Green_Stone			= 70;
	static final int	k_Red_Tree_1			= 71;
	static final int	k_Red_Tree_2			= 72;
	static final int	k_Red_Tree_3			= 73;
	static final int	k_White_Ground			= 74;
	static final int	k_White_Hard_Brick		= 75;
	static final int	k_White_Stone			= 76;
	static final int	k_White_Tree_1			= 77;
	static final int	k_White_Tree_2			= 78;
	static final int	k_White_Tree_3			= 79;
	static final int	k_Bullet_Bill_1			= 80;
	static final int	k_Bullet_Bill_4			= 81;
	static final int	k_Water_Ground			= 82;
	static final int	k_Water_Brick			= 83;
	static final int	k_Castle_Brick			= 84;
	static final int	k_Dark_Bridge			= 85;
	static final int	k_Light_Bridge			= 86;
	static final int	k_Pink_Coral			= 87;
	static final int	k_Sun_Stone				= 88;
	static final int	k_Red_Bridge			= 127;
	static final int	k_White_Normal_Brick	= 146;
	static final int	k_White_Top_Brick		= 139;
	static final int	k_Red_Normal_Brick		= 144;
	static final int	k_Red_Top_Brick			= 145;
	static final int	k_Green_Normal_Brick	= 140;
	static final int	k_Green_Top_Brick		= 141;
	static final int	k_Sky_Tree_1			= 142;
	static final int	k_Sky_Tree_2			= 143;
	static final int	k_Red_Hidden_Brick		= 151;
	static final int    k_Green_Hidden_Brick	= 152;
	static final int    k_Green_Horizontal_Pipe	= 147;
	static final int    k_Orange_Horizontal_Pipe	= 148;
	static final int    k_White_Horizontal_Pipe	= 149;
	static final int    k_Blue_Horizontal_Pipe	= 150;
	// End List
	
	// Decorative ID list
	static final int	k_Blue_Cloud_1			= 89;
	static final int	k_Blue_Cloud_2			= 90;
	static final int	k_Blue_Cloud_3			= 91;	
	static final int	k_Bush_1				= 92;
	static final int	k_Bush_2				= 93;
	static final int	k_Bush_3				= 94;	
	static final int	k_Large_Mountain		= 95;
	static final int	k_Small_Mountain		= 96;
	static final int	k_Green_Tree_1			= 97;
	static final int	k_Green_Tree_2			= 98;
	static final int	k_Gray_Tree_1			= 99;
	static final int	k_Gray_Tree_2			= 100;
	static final int	k_Small_Red_Castle		= 101;
	static final int	k_Large_Red_Castle		= 102;
	static final int	k_Small_White_Castle	= 103;
	static final int	k_Large_White_Castle	= 104;	
	static final int	k_Mushroom_Trunk_1		= 105;
	static final int	k_Mushroom_Trunk_2		= 106;	
	static final int	k_Red_Seesaw			= 107;
	static final int	k_White_Seesaw			= 108;	
	static final int	k_Red_Trunk				= 109;
	static final int	k_White_Trunk			= 110;
	static final int	k_Fence					= 111;
	static final int	k_Star_Flag				= 112;	
	static final int	k_Princess_1			= 113;
	static final int	k_Princess_2			= 114;
	static final int	k_Red_Cloud_1			= 115;
	static final int	k_Red_Cloud_2			= 116;
	static final int	k_Red_Cloud_3			= 117;		
	static final int	k_Red_Flag_3			= 128;	
	// End List

	// The array of images
	private static Image[]	s_aimg = null;
	
	// The unique tileSet
	private static Image	s_imgTileSet = null;
	
	// The unique command bar image
	private static Image	s_imgCmdBar = null;
	
	// The unique title bar image
	private static Image	s_imgTitleBar = null;
	
	// The unique resource image
	private static Image	s_imgResource = null;
	
	// The resource map array	
	private static int[]	s_aiX = null;
	private static int[]	s_aiY = null;
	private static int[]	s_aiWidth = null;
	private static int[]	s_aiHeight = null;
		
	private Resource () {
	}
	
	// Initalize some variables
	public static void Initialize () {	
		DataStream stream = new DataStream(
				"/resource_map.rmp");
		// Read the size information
		int count = stream.ReadNextByte();		
		s_aiX = new int[count+1];
		s_aiY = new int[count+1];
		s_aiWidth = new int[count+1];
		s_aiHeight = new int[count+1];
		s_aimg = new Image[count+1];
		for(int i=1; i<count+1; i++) {
			s_aiX[i] = stream.ReadNextInt();
			s_aiY[i] = stream.ReadNextInt();
			s_aiWidth[i] = stream.ReadNextByte();
			s_aiHeight[i] = stream.ReadNextByte();					
		}
		if (s_imgResource == null) {
			s_imgResource = CreateImage("/resource_map.png");
		}
	}
	
	// Get an image by id
	public static Image GetImage (int id) {
		if (id == k_Red_Hidden_Brick || id == k_Green_Hidden_Brick) {
			Image image = Image.createImage(16, 16);
			image = MarioTransform.FilterImage(image, 0x00FFFFFF);
			return image;
		}
		if (id == k_Flip_Coins)
			id = k_Flip_Coin;
		if(s_aimg[id]== null) {
			s_aimg[id] = Image.createImage(s_imgResource,
				s_aiX[id],s_aiY[id],
				s_aiWidth[id],s_aiHeight[id],0);
		}
		return s_aimg[id];
	}
	
	// Get the command bar image
	public static Image GetCommandBarImg () {
		if (s_imgCmdBar == null) {
			s_imgCmdBar = CreateImage("/command_bar.png");
		}
		return s_imgCmdBar;
	}
	
	// Get the title bar image
	public static Image GetTitleBarImg () {
		if (s_imgTitleBar == null) {
			s_imgTitleBar = CreateImage("/title_bar.png");
		}
		return s_imgTitleBar;
	}
	
	// Get the tileset image
	public static Image GetTileSetImg () {
		if (s_imgTileSet == null) {
			s_imgTileSet = Image.createImage(s_imgResource,0,0,320,192,0);
		}
		return s_imgTileSet;
	}
	
	// Create an image from specified path
	public static Image CreateImage (String path) {
		Image image = null;
		try {
			image = Image.createImage(path);
		} catch (Exception ex) {
			ex.printStackTrace();
		}
		return image;
	}
			
	// Draw a graphical string
	public static void DrawString (String string,
		int x, int y, Graphics graphics) {
	}
}