public class ItemFactory {
	static public SpriteItem CreateItem (int itemID, int topItemID,
		int row, int col) {
		SpriteItem item = null;
		SpriteItem bonus = null;
		switch (itemID) {
			case Resource.k_Red_Top_Brick:
			case Resource.k_Green_Top_Brick:
			case Resource.k_White_Top_Brick:
			case Resource.k_Red_Normal_Brick:
			case Resource.k_Green_Normal_Brick:
			case Resource.k_White_Normal_Brick:
				bonus = GetBonus(topItemID, row, col);
				if (bonus == null) {
					// Brick items
					item = new BrickItem(itemID, row, col);
				} else {
					// Bonus brick items
					item = new BonusBrickItem(itemID, row, col, bonus);
				}
				break;
			case Resource.k_Red_Hidden_Brick:
			case Resource.k_Green_Hidden_Brick:
					bonus = GetBonus(topItemID, row, col);
					if (bonus != null)
						item = new HiddenBrickItem(itemID, row, col, bonus);
					break;
			case Resource.k_Light_Item:
			case Resource.k_Dark_Item:
				// Question box items
				bonus = GetBonus(topItemID, row, col);
				item = new QuestionBoxItem(itemID, row, col, bonus);
				break;			
			case Resource.k_Light_Coin:
			case Resource.k_Dark_Coin:
			case Resource.k_Water_Coin:
				// Coin items
				item = new CoinItem(itemID, row, col);
				break;
			case Resource.k_Flip_Coin:	
				// flip coin
				item = new FlipCoin(itemID, row, col);
				break;
			case Resource.k_Flip_Coins:
					// multi-flip coins
					item = new FlipCoin(itemID, row, col, true);
					break;
			// case Resource.k_Grow_Mushroom:
			case Resource.k_Life_Mushroom_1:
			case Resource.k_Life_Mushroom_2:
				// Mushroom items
				item = new MushroomItem(itemID, row, col);
				break;
			case Resource.k_Light_Flower:
			case Resource.k_Dark_Flower:
				// Flower items
				item = new FlowerItem(itemID, row, col);
				break;
			case Resource.k_Star:
				// Star items
				item = new StarItem(itemID, row, col);
				break;
			case Resource.k_Red_Goomba:
			case Resource.k_Green_Goomba:
			case Resource.k_White_Goomba:
				// Goomba
				item = new GoombaItem(itemID, row, col);
				break;
			case Resource.k_Red_Beetle:
			case Resource.k_Green_Beetle:
			case Resource.k_White_Beetle:
				// Beetle
				item = new BeetleItem(itemID, row, col);
				break;
			case Resource.k_Red_Koopas_NoWing:
			case Resource.k_Green_Koopas_NoWing:
			case Resource.k_White_Koopas_NoWing:
				// Koopas
				item = new KoopasItem(itemID, false, row, col);
				break;				
			case Resource.k_Red_Koopas:
			case Resource.k_Green_Koopas:
			case Resource.k_White_Koopas:
				// Koopas wing
				item = new KoopasItem(itemID, true, row, col);
				break;
			case Resource.k_Boss:
					// boss
					item = new BossItem(itemID, row, col);
					break;
			case Resource.k_Green_Pirhara_Plant:
			case Resource.k_White_Pirhara_Plant:
					// carnivore
					item = new CarnivoreItem(itemID, row, col);
					break;
			case Resource.k_Green_Down_Pipe:
			case Resource.k_White_Down_Pipe:
				// Main down pipe
				item = new PipeItem(itemID, row, col);
				PlayField.s_Instance.SetDownPipe(
					(PipeItem)item, row, col);
				break;
			case Resource.k_Green_Right_Pipe:
			case Resource.k_White_Right_Pipe:
				// Main right pipe
				item = new PipeItem(itemID, row, col);
				((PipeItem)item).m_isRight = true;
				break;
			case Resource.k_Green_Pipe:
			case Resource.k_White_Pipe:
				// Sub pipe
				item = new StaticItem(itemID, row, col, 32, 16);
				break;
			case Resource.k_Green_Horizontal_Pipe:
			case Resource.k_White_Horizontal_Pipe:				
				item = new StaticItem(itemID, row, col, 16, 32);
				break;
			case Resource.k_Green_Flag_1:
				// Flag
				item = new FlagItem(itemID, row, col);
				break;
			case Resource.k_Hammer:
					// Hammer
					item = new HammerItem(itemID, row, col);
					break;
			default:
				// Static items
				item = new StaticItem(itemID, row, col);
				break;
		}
		return item;
	}
	
	private static SpriteItem GetBonus (int itemID, int row, int col) {
		SpriteItem item = null;
		switch (itemID) {
			// case Resource.k_Grow_Mushroom:
			case Resource.k_Life_Mushroom_1:
			case Resource.k_Life_Mushroom_2:
				// Mushroom items
				item = new MushroomItem(itemID, row, col);
				break;
			case Resource.k_Star:
				// Star items
				item = new StarItem(itemID, row, col);
				break;
			case Resource.k_Dark_Flower:
			case Resource.k_Light_Flower:
				// Flower items
				item = new FlowerItem(itemID, row, col);
				break;			
			case Resource.k_Flip_Coin:
				item = new FlipCoin(itemID, row, col);
				break;
			case Resource.k_Flip_Coins:
					item = new FlipCoin(itemID, row, col, true);
				break;
		}
		return item;
	}
}