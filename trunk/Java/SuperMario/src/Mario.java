import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.*;
import java.util.*;

public class Mario extends SpriteItem {
	// Key pressed event
	final static int		KEY_UP		= GameCanvas.UP_PRESSED;
	final static int		KEY_DOWN	= GameCanvas.DOWN_PRESSED;
	final static int		KEY_LEFT	= GameCanvas.LEFT_PRESSED;
	final static int		KEY_RIGHT	= GameCanvas.RIGHT_PRESSED;
	final static int		KEY_FIRE	= GameCanvas.FIRE_PRESSED;
	// Moving status of Mario
	final static int 		k_STANDING = 0;
	final static int 		k_WALKING = 1;
	final static int 		k_RUNNING = 2;
	final static int 		k_BRAKING = 3;
	final static int 		k_JUMPING = 4;
	final static int 		k_FALLING = 5;
	final static int 		k_PIPE_FALLING = 6;
	final static int		k_PIPE_RIGHT_MOVING = 7;
	// Mario Level
	final static int 		k_SMALL = 0;
	final static int 		k_MEDIUM = 1;
	final static int 		k_LARGE = 2;
	// Moving const value of Mario
	final static float		k_INITIAL_SPEED = 0.4f;
	final static float		k_WALKING_SCALE = 1.5f;
	final static float		k_SLOW_SCALE = 0.95f;
	final static float		k_RUNNING_SCALE = 2.0f;
	final static float		k_BRAKING_SCALE = 0.8f;
	final static float		k_INITIAL_HOVER = -8.5f;
	final static float		k_BONUS_HOVER = -1.5f;
	final static float		k_FINAL_HOVER = -1.8f;
	final static float		k_HOVER_SCALE = 0.9f;
	final static float		k_FINAL_WALKING = 2.3f;
	final static float		k_FINAL_RUNNING = 4.0f;
	final static float		k_AIRMOVING_SCALE = 1.2f;
	final static float		k_AIRBRAKING_SCALE = 0.92f;
	// Point
	final static int		k_OBTAINS_COIN_POINT = 200;
	final static int		k_GROW_UP_POINT = 1000;
	public final static int	k_KILLS_ENEMY_POINT = 100;
	final static int		k_LIFE_UP_POINT = 1000;
	final static int		k_OBTAINS_STAR_POINT = 1000;
	final static int		k_PERSECOND_POINT = 50;
	final static int		k_BREAK_BLOCK_POINT = 50;
	final static int		k_END = 400;
	
	// Indicate the state of Mario
	protected int			m_iMovingState;
	
	// Indicate whether the player holding the B button
	protected boolean		m_isHoldingB = false;
	
	// Moving speed of Mario
	protected float			m_fSpeed = 0;
	// Dropping / jumping speed of Mario
	protected float			m_fHover = -k_FINAL_HOVER;
	
	// Indicate whether player has released up button
	protected boolean 		m_isReleaseJumpButton = true;
	
	// Indicate whether player has released down button
	protected boolean 		m_isReleaseDownButton = true;
	
	// The pipe item to interact
	protected PipeItem m_PipeItem = null;
	
	// Determine the level
	protected int m_iLevel = k_SMALL;
	
	// Determine the lives number
	protected int m_iLives = 3;
	
	// Determine the coin number
	protected int m_iCoins = 0;
	
	// Determine the point
	protected int m_iPoint = 0;	
	
	// Star variables
	private static int k_STAR_PERIOD = 500;
	protected int m_iStarCount = 0;
	protected boolean m_hasStar;
	protected int m_iStarPlus = 0;
        
	// Invulnerable variable
	protected boolean m_isInvulnerable = false;
	private static int k_INVULNERABLE_PERIOD = 100;
	protected int m_iInvulnerableCount = 0;
	
	protected int m_iCMX = -1;
	protected int m_iCMY = -1;
	
	public Mario () {
		Initialize(Resource.GetImage(Resource.k_Mario), 16, 16);
		m_Sprite.defineReferencePixel(
			m_Sprite.getWidth() / 2,
			m_Sprite.getHeight() / 2);
		m_iMovingState = k_FALLING;		
	}
		
	
	int prevS = -1;
	private void ShowState () {
		if (m_iMovingState == prevS) return;
		prevS = m_iMovingState;
		switch (m_iMovingState) {
			case k_STANDING:				
				break;
			case k_WALKING:				
				break;
			case k_RUNNING:				
				break;
			case k_BRAKING:				
				break;
			case k_JUMPING:				
				break;
			case k_FALLING:				
				break;
			case k_PIPE_FALLING:				
				break;
			case k_PIPE_RIGHT_MOVING:				
				break;
		}
	}
	
	// Process when Mario smash a brick
	private void SmashBrick(BrickItem item) {
		// check if Mario really hit a brick
		if (this.GetRight() - item.GetLeft() < 4) {
			this.SetPosition(item.GetLeft() - 7, m_fPosY);
			// check if it still collide with another brick/bonus item nearby
			item.Deregister(m_SpriteManager);
			SpriteItem another = GetCollisionTop();
			if (another instanceof BrickItem)
				SmashBrick((BrickItem)another);
			else if (another instanceof BonusItem)
				RevealItem((BonusItem)another);
			item.Register(m_SpriteManager);
			// end check
			return;
		}
		if (item.GetRight() - this.GetLeft() < 4) {
			this.SetPosition(item.GetRight() + 7, m_fPosY);
			// check if it still collide with another brick/bonus item nearby
			item.Deregister(m_SpriteManager);
			SpriteItem another = GetCollisionTop();
			if (another instanceof BrickItem)
				SmashBrick((BrickItem)another);
			else if (another instanceof BonusItem)
				RevealItem((BonusItem)another);
			item.Register(m_SpriteManager);
			// end check
			return;
		}
				
		SmashItemAbove(item);                
		if (m_iLevel > k_SMALL) {
			// breakblock music
			MusicManager.GetInstance().Play(MusicManager.k_BreakBlock);
			//increase point
			m_iPoint += k_BREAK_BLOCK_POINT;
			item.Deregister(m_SpriteManager);
			RuinBrickItem[] ruinBrickItem = new RuinBrickItem[4];
			for (int i = 0; i < 4; i++) {
				ruinBrickItem[i] = new RuinBrickItem(item, i);
				ruinBrickItem[i].Register(m_SpriteManager, true);
			}
		} else {
			item.MakeMoving();		
		}
		SetPosition(m_fPrevPosX, m_fPrevPosY);
		m_iMovingState = k_FALLING;
		m_fHover = -m_fHover;
		
	}
	
	// Process when Mario reveal an item
	private void RevealItem(BonusItem item) {
		// check if it really hit the bonus item
		if (this.GetRight() - item.GetLeft() < 4) {
			this.SetPosition(item.GetLeft() - 7, m_fPosY);
			// check if it still collide with another brick/bonus item nearby
			item.Deregister(m_SpriteManager);
			SpriteItem another = GetCollisionTop();
			if (another instanceof BrickItem)
				SmashBrick((BrickItem)another);
			else if (another instanceof BonusItem)
				RevealItem((BonusItem)another);
			item.Register(m_SpriteManager);
			// end check
			return;
		}
		if (item.GetRight() - this.GetLeft() < 4) {
			this.SetPosition(item.GetRight() + 7, m_fPosY);
			// check if it still collide with another brick/bonus item nearby
			item.Deregister(m_SpriteManager);
			SpriteItem another = GetCollisionTop();
			if (another instanceof BrickItem)
				SmashBrick((BrickItem)another);
			else if (another instanceof BonusItem)
				RevealItem((BonusItem)another);
			item.Register(m_SpriteManager);
			// end check
			return;
		}
		if (!item.m_isRevealed) {            								
			SmashItemAbove(item);
			item.BeginReveal();
		}
		SetPosition(m_fPrevPosX, m_fPrevPosY);
		m_iMovingState = k_FALLING;
		m_fHover = -m_fHover;
	}
        
	// Process when Mario obtains a coin
	private void ObtainsCoin (SpriteItem item) {
		if (item instanceof CoinItem) {			
			//music obtains coin//			
			MusicManager.GetInstance().Play(MusicManager.k_ObtainCoin);			
			m_iCoins++;
			if(m_iCoins == 100)
			{
				m_iCoins = 0;
				m_iLives++;
				MusicManager.GetInstance().Play(MusicManager.k_LifeUp);
			}			
			//increase point
			m_iPoint += k_OBTAINS_COIN_POINT;
			item.Deregister(item.m_SpriteManager);
		}
	}
	
	// Process when Mario obtains a mushroom
	private void ObtainsMushroom (SpriteItem item) {
		if (item instanceof MushroomItem) {			
			item.Deregister(item.m_SpriteManager);
			if (((MushroomItem)item).m_iType ==
				Resource.k_Grow_Mushroom) { // Grow up mushroom
				if (m_isInvulnerable) {
					m_isInvulnerable = false;
					m_iStarPlus = 0;
					m_Sprite.setFrame(m_Sprite.getFrame() % 7);
				}
				if (m_iLevel == k_SMALL) {
					m_iLevel = k_MEDIUM;
				} else
					return;
				
				//music powerup1
				MusicManager.GetInstance().Play(MusicManager.k_PowerUp1);
				m_iPoint += k_GROW_UP_POINT;
				
				PlayField.s_Instance.ForceMarioTransform(m_Sprite.getFrame() % 7, m_iDir, MarioTransform.k_GROWUP);
				if (m_hasStar)
					m_Sprite.setImage(GetStarImageSprite(), 16, 32);
				else
					m_Sprite.setImage(Resource.GetImage(Resource.k_Medium_Mario),16, 16 * 2);
				SetPosition(m_fPosX, m_fPosY - 16);			
			} else { // Life mushroom
				m_iLives++;
				//music life up
				MusicManager.GetInstance().Play(MusicManager.k_LifeUp);
				//increase point
				m_iPoint += k_LIFE_UP_POINT;
			}
		}
	}
	
	// Notify when the Mario died
	public void NotifyDeath () {
		m_hasStar = false;
		m_isInvulnerable = false;
		m_iStarPlus = m_iStarCount = 0;
		m_iLives--;
		s_iBullet = 2;
		tempTime = 0;
		if (m_iLives == 0) {
			// Game Over
			RecordStoreManager.SaveHighScore(m_iPoint);					
			MarioGameCanvas.m_isContinue = false;
			PlayField.s_Instance.m_isGameOver = true;
			return;
		}
		m_iLevel = k_SMALL;
		Initialize(Resource.GetImage(Resource.k_Mario), 16, 16);
		m_Sprite.setFrame(0);
		m_Sprite.defineReferencePixel(m_Sprite.getWidth() / 2, m_Sprite.getHeight() / 2);		
		PlayField.s_Instance.m_isChangingMap = true;                		
		return;
	}
	
	// Process when Mario obtains a flower
	private void ObtainsFlower (SpriteItem item) {
		if (item instanceof FlowerItem) {
			if (m_iLevel == k_SMALL) { // Small --> Medium
				if (m_isInvulnerable) {
					m_isInvulnerable = false;
					m_iStarPlus = 0;
					m_Sprite.setFrame(m_Sprite.getFrame() % 7);
				}
				m_iLevel = k_MEDIUM;
				item.Deregister(item.m_SpriteManager);	
				
				//music powerup 1
				MusicManager.GetInstance().Play(MusicManager.k_PowerUp1);
				//increase point
				m_iPoint += k_GROW_UP_POINT;
				
				PlayField.s_Instance.ForceMarioTransform(
					m_Sprite.getFrame() % 7, m_iDir,
					MarioTransform.k_GROWUP);
					if (m_hasStar)
						m_Sprite.setImage(GetStarImageSprite(), 16, 32);
					else
						m_Sprite.setImage(Resource.GetImage(Resource.k_Medium_Mario),16, 16 * 2);
				SetPosition(m_fPosX, m_fPosY - 16);
			} else if (m_iLevel == k_MEDIUM) { // Medium --> Large
				m_iLevel = k_LARGE;
				item.Deregister(item.m_SpriteManager);
				s_iBullet = 2;
				//music powerup 2
				MusicManager.GetInstance().Play(MusicManager.k_PowerUp2);
				//increase point
				m_iPoint += k_GROW_UP_POINT;
				
				PlayField.s_Instance.ForceMarioTransform(m_Sprite.getFrame() % 7, m_iDir, MarioTransform.k_UPGRADE);
				if (m_hasStar)
					m_Sprite.setImage(GetStarImageSprite(), 16, 32);
				else
					m_Sprite.setImage(Resource.GetImage(Resource.k_Large_Mario),16, 16 * 2);
			}
			else 
				item.Deregister(item.m_SpriteManager);
		}
	}
	
	// Process when Mario obtains a star
	private void ObtainsStar (SpriteItem item) {
		if (item instanceof StarItem) {			
			//music obtains star			
			//increase point
			m_iPoint += k_GROW_UP_POINT;
			
			item.Deregister(item.m_SpriteManager);
			if (m_hasStar) {    // already having star
				m_iStarCount = k_STAR_PERIOD;
				return;
			}
			m_hasStar = true;
			int seqIndex = m_Sprite.getFrame() % 7;
			m_iStarPlus = 0;
			if (m_iLevel == k_SMALL)
				m_Sprite.setImage(GetStarImageSprite(), 16, 16);
			else if (m_iLevel == k_MEDIUM)
				m_Sprite.setImage(GetStarImageSprite(), 16, 32);
			else if (m_iLevel == k_LARGE)
				m_Sprite.setImage(GetStarImageSprite(), 16, 32);
			m_iStarCount = k_STAR_PERIOD;
			m_Sprite.setFrame(seqIndex);
			// eliminate invurable status if needed
			m_isInvulnerable = false;
			}
	}
	
	// get star image for Mario sprite
	private Image GetStarImageSprite () {
		Image image = null;
		try {
			if (m_iLevel == k_SMALL) {
				image = Image.createImage(112,48);								
				Graphics g = image.getGraphics();								
				g.setColor(0x00ff0000);
				g.fillRect(0, 0, 112, 48);
				g.drawRegion(Resource.GetImage(Resource.k_Mario), 0, 0, 112, 16, Sprite.TRANS_NONE, 0, 0, Graphics.LEFT|Graphics.TOP);
				g.drawRegion(Resource.GetImage(Resource.k_Dark_Mario), 0, 0, 112, 16, Sprite.TRANS_NONE, 0, 16, Graphics.LEFT|Graphics.TOP);
				g.drawRegion(Resource.GetImage(Resource.k_Light_Mario), 0, 0, 112, 16, Sprite.TRANS_NONE, 0, 32, Graphics.LEFT|Graphics.TOP);                                
				image = MarioTransform.FilterImage(image, 0x00ff0000);
			}
			else if (m_iLevel == k_MEDIUM) {
				image = Image.createImage(112, 96);
				Graphics g = image.getGraphics();
				g.setColor(0x00ff0000);
				g.fillRect(0, 0, 112, 96);
				g.drawRegion(Resource.GetImage(Resource.k_Medium_Mario), 0, 0, 112, 32, Sprite.TRANS_NONE, 0, 0, Graphics.LEFT|Graphics.TOP);
				g.drawRegion(Resource.GetImage(Resource.k_Dark_Medium_Mario), 0, 0, 112, 32, Sprite.TRANS_NONE, 0, 32, Graphics.LEFT|Graphics.TOP);
				g.drawRegion(Resource.GetImage(Resource.k_Light_Medium_Mario), 0, 0, 112, 32, Sprite.TRANS_NONE, 0, 64, Graphics.LEFT|Graphics.TOP);  
				image = MarioTransform.FilterImage(image, 0x00ff0000);
			}
			else if (m_iLevel == k_LARGE) {
				image = Image.createImage(112, 96);
				Graphics g = image.getGraphics();
				g.setColor(0x00ff0000);
				g.fillRect(0, 0, 112, 96);
				g.drawRegion(Resource.GetImage(Resource.k_Large_Mario), 0, 0, 112, 32, Sprite.TRANS_NONE, 0, 0, Graphics.LEFT|Graphics.TOP);
				g.drawRegion(Resource.GetImage(Resource.k_Dark_Medium_Mario), 0, 0, 112, 32, Sprite.TRANS_NONE, 0, 32, Graphics.LEFT|Graphics.TOP);
				g.drawRegion(Resource.GetImage(Resource.k_Light_Medium_Mario), 0, 0, 112, 32, Sprite.TRANS_NONE, 0, 64, Graphics.LEFT|Graphics.TOP);  
				image = MarioTransform.FilterImage(image, 0x00ff0000);
			}
		} catch (Exception e) {
			e.printStackTrace();
	    }
		return image;
	}
        
	// Process when Mario meets an enemy from left or right
	private void MeetsEnemy (SpriteItem item) {
		if (item instanceof EnemyItem) {
			EnemyItem enemy = (EnemyItem)item;                        
			if (enemy.m_beingBeaten)
				return;			
			if (m_hasStar) {
				// do sth about the enemy
				enemy.GetBeaten(m_iDir);
				return;
			}
			if (m_isInvulnerable && enemy.m_isActive) {
				return;
			}
			if (!enemy.m_isActive) {
				if (enemy instanceof KoopasItem || enemy instanceof BeetleItem) {
					if (enemy instanceof KoopasItem) {
						if (GetLeft() < enemy.GetLeft())
							((KoopasItem)enemy).GetKicked(1);
						else
							((KoopasItem)enemy).GetKicked(-1);
					}
					else if (enemy instanceof BeetleItem) {
						if (GetLeft() < enemy.GetLeft())
							((BeetleItem)enemy).GetKicked(1);
						else
							((BeetleItem)enemy).GetKicked(-1);
					}
				}
				return;
			}
			MakeMarioShrink();		
		}
	}
	
	private void Move () {
		// Backup
		m_fPrevPosX = m_fPosX;
		m_fPrevPosY = m_fPosY;
		// Try to move on horizontal dimension		
		if (m_fSpeed > k_FINAL_RUNNING) {
			m_fSpeed = k_FINAL_RUNNING;
		}
		if (m_fSpeed < -k_FINAL_RUNNING) {
			m_fSpeed = -k_FINAL_RUNNING;
		}
		SetPosition(m_fPosX + m_fSpeed, m_fPosY);
		SpriteItem cleft = GetCollisionLeft();
		SpriteItem cright = GetCollisionRight();
		if (cleft != null || cright != null) {
			if (cleft instanceof CoinItem ||
				cright instanceof CoinItem) {
				ObtainsCoin(cleft);
				if (cright != cleft) {
					ObtainsCoin(cright);
				}
			} else if (cleft instanceof MushroomItem ||
				cright instanceof MushroomItem) {
				ObtainsMushroom(cleft);
				if (cright != cleft) {
					ObtainsMushroom(cright);
				}
				return;
			} else if (cleft instanceof FlowerItem ||
				cright instanceof FlowerItem) {
				ObtainsFlower(cleft);
				if (cright != cleft) {
					ObtainsFlower(cright);
				}
				return;
			} else if (cleft instanceof StarItem ||
				cright instanceof StarItem) {
				ObtainsStar(cleft);
				if (cright != cleft) {
					ObtainsStar(cright);
				}
				return;
			} else if (cleft instanceof BossBullet || cright instanceof BossBullet) {
				if (!m_isInvulnerable && !m_hasStar) {
					MakeMarioShrink();
					return;
				}
			} else if (cleft instanceof EnemyItem ||
				cright instanceof EnemyItem ) {
				boolean b = m_isInvulnerable;
				MeetsEnemy(cleft);
				if (cright != cleft) {					
					MeetsEnemy(cright);					
				}
				if (!b)
					return;
                                
			} else if (cleft instanceof RuinBrickItem || cright instanceof RuinBrickItem) {
				// do nothing
			} else if (cleft instanceof PipeItem || cright instanceof PipeItem) {
				if (cright instanceof PipeItem &&
					(m_iMovingState == k_RUNNING ||
					m_iMovingState == k_WALKING)) {
					PipeItem pipe = (PipeItem)cright;
					int d = pipe.GetBottom() - GetBottom();
					if (pipe.m_isRight && m_iDir > 0 &&	d >= 0 && d < 2) {
						m_iMovingState = k_PIPE_RIGHT_MOVING;
						m_PipeItem = pipe;
						m_Sprite.setFrame(0);
						SpriteManager manager = m_SpriteManager;
						Deregister(manager);
						Register(manager);
						return;
					}
				}
				SetPosition(m_fPrevPosX, m_fPrevPosY);
			} else {
				// Restore
				SetPosition(m_fPrevPosX, m_fPrevPosY);
			}
		}
		// Backup
		m_fPrevPosX = m_fPosX;
		m_fPrevPosY = m_fPosY;
		// Try to move on vertical dimension
		SetPosition(m_fPosX, m_fPosY + m_fHover);
		SpriteItem ctop = GetCollisionTop();
		SpriteItem cbottom = GetCollisionBottom();
		if (ctop == cbottom && (ctop instanceof StaticItem || ctop instanceof BrickItem || ctop instanceof BonusItem)) {
			SetPosition(m_fPosX, ctop.GetTop() - this.m_Sprite.getHeight());
		}
		if (ctop != null || cbottom != null) {
			if (ctop instanceof CoinItem ||
				cbottom instanceof CoinItem) {
				ObtainsCoin(ctop);
				if (cbottom != ctop) {
					ObtainsCoin(cbottom);
				}
			} else if (ctop instanceof MushroomItem ||
				cbottom instanceof MushroomItem) {
				ObtainsMushroom(ctop);
				if (cbottom != ctop) {
					ObtainsMushroom(cbottom);
				}
			} else if (ctop instanceof FlowerItem ||
				cbottom instanceof FlowerItem) {
				ObtainsFlower(ctop);
				if (cbottom != ctop) {
					ObtainsFlower(cbottom);
				}
			} else if (ctop instanceof StarItem ||
				cbottom instanceof StarItem) {
				ObtainsStar(ctop);
				if (cbottom != ctop) {
					ObtainsStar(cbottom);
				}
			} else if (ctop instanceof BrickItem) {
				SmashBrick((BrickItem)ctop);
			} else if (ctop instanceof BonusItem) {
				RevealItem((BonusItem)ctop);
			} else if (ctop instanceof BossBullet || cbottom instanceof BossBullet) {
					if (!m_isInvulnerable && !m_hasStar) {
						MakeMarioShrink();
						return;
					}
			} else if (ctop instanceof RuinBrickItem || cbottom instanceof RuinBrickItem) {
			} else {
				m_PipeItem = null;
				if (cbottom instanceof PipeItem) {
					PipeItem item = (PipeItem)cbottom;
					if (item.m_isDown) {
						m_PipeItem = item;
					}
				} else if (cbottom instanceof HammerItem) {
					Vector items = m_SpriteManager.m_vecSpriteItems;
					for (int i=0; i<items.size(); i++) {
						SpriteItem item = (SpriteItem)items.elementAt(i);
						if (item instanceof BossItem) {
							((BossItem)item).GetBeaten(-1);
							break;
						}
					}
					cbottom.Deregister(m_SpriteManager);
					return;
				}
				if (ctop instanceof EnemyItem) {
					MeetsEnemy(ctop);
					return;
				}
				boolean temp = true;
				if (cbottom != null) {
					if (cbottom instanceof EnemyItem && m_iMovingState == k_FALLING) {
						EnemyItem enemy = (EnemyItem)cbottom;
						if (m_hasStar || enemy instanceof BossItem || enemy instanceof CarnivoreItem)
							MeetsEnemy(enemy);
						else if (enemy.m_isActive) {
							enemy.GetStomped();
							this.BounceUp();
						} else {
							if (enemy instanceof KoopasItem || enemy instanceof BeetleItem) {
								if (enemy instanceof KoopasItem) {
									if (GetLeft() < enemy.GetLeft())
										((KoopasItem)enemy).GetKicked(1);
									else
										((KoopasItem)enemy).GetKicked(-1);
									this.BounceUp();
								}
								else if (enemy instanceof BeetleItem) {
									if (GetLeft() < enemy.GetLeft())
										((BeetleItem)enemy).GetKicked(1);
									else
										((BeetleItem)enemy).GetKicked(-1);
									this.BounceUp();
								}
							}
						}                                        
						temp = false;
					}		
				}
				else
					temp = false;		
				
				if (temp && m_iMovingState == k_FALLING) {					
					// Restore
					SetPosition(m_fPrevPosX, m_fPrevPosY);
					m_fHover = 0;
					m_fSpeed *= 0.8;
					if (m_fSpeed > 0) {
						m_iDir = 1;
					} else if (m_fSpeed < 0) {
						m_iDir = -1;
					}
					if (m_fSpeed < 0.8 && m_fSpeed > -0.8) {
						m_fSpeed = 0;
						m_Sprite.setFrame(m_iStarPlus + 0);
						m_iMovingState = k_STANDING;
					} else if (m_fSpeed >= -k_FINAL_WALKING &&
						m_fSpeed <= k_FINAL_WALKING) {
						m_Sprite.setFrame(m_iStarPlus + 5);
						m_iMovingState = k_WALKING;
						m_iTickCount = 2;
					} else {
						m_Sprite.setFrame(m_iStarPlus + 5);
						m_iMovingState = k_RUNNING;
						m_iTickCount = 4;
					}
				}
				
				if (ctop != null && m_iMovingState == k_JUMPING) {
					// Restore
					SetPosition(m_fPrevPosX, m_fPrevPosY);
					m_iMovingState = k_FALLING;
					m_fHover = -m_fHover;
				}
			}
		}
	}
	
	public void Tick () {	
		ShowState();
		if (m_iMovingState == k_PIPE_FALLING) {
			SetPosition(m_fPosX, m_fPosY + 2);
			return;
		}
		if (m_iMovingState == k_PIPE_RIGHT_MOVING) {
			SetPosition(m_fPosX + 2, m_fPosY);
			if (GetLeft() > m_PipeItem.GetLeft()) {
				m_Sprite.setVisible(false);
			}
			return;
		}
		Move();
		if (PlayField.s_Instance.m_isPausing) {
			return;
		}
		// handle star status
		if (m_hasStar) {
			m_iStarCount--;
			int seqIndex = m_Sprite.getFrame() % 7;
			if (m_iStarCount <= 0) {
				// end star status
				m_iStarPlus = 0;
				m_hasStar = false;
				if (m_iLevel == k_SMALL)
					m_Sprite.setImage(Resource.GetImage(Resource.k_Mario), 16, 16);
				else if (m_iLevel == k_MEDIUM)
					m_Sprite.setImage(Resource.GetImage(Resource.k_Medium_Mario), 16, 32);
				else if (m_iLevel == k_LARGE)
					m_Sprite.setImage(Resource.GetImage(Resource.k_Large_Mario), 16, 32);
				m_Sprite.setFrame(seqIndex);
				return;
			} 
			if ((m_iStarCount > 75 && m_iStarCount % 3 == 1) ||                       
					(m_iStarCount < 75 && m_iStarCount % 5 == 1) )
						m_iStarPlus = (m_iStarPlus + 7) % 21;
			m_Sprite.setFrame(m_iStarPlus + seqIndex);
		}
		// end of handling
		// handle invulnerable status
		if (m_isInvulnerable) {
			if (m_iInvulnerableCount <= 0) {				
				m_isInvulnerable = false;
				m_iStarPlus = 0;
				int seqIndex = m_Sprite.getFrame() % 7;
				m_Sprite.setImage(Resource.GetImage(Resource.k_Mario), 16, 16);
				m_Sprite.setFrame(seqIndex);
			} else {
				m_iInvulnerableCount--;
				if (m_iInvulnerableCount % 2 == 1)
					m_iStarPlus = 7;
				else
					m_iStarPlus = 0;
			}
		}
                
		SetPosition(m_fPosX, m_fPosY + 2);
		if (m_iMovingState != k_FALLING &&
			m_iMovingState != k_JUMPING &&
			GetCollisionBottom() == null) {
			m_iMovingState = k_FALLING;
			m_fHover = -k_FINAL_HOVER;
		}
		SetPosition(m_fPosX, m_fPosY - 2);
		m_iTickCount--;
		SpriteItem item = GetCollisionTop();		
		if (item != null && !m_isInvulnerable)
		    if (!(item instanceof EnemyItem) && !(item instanceof BossBullet))
			SetPosition(m_fPosX, m_fPosY + 1);
		item = GetCollisionBottom();		
		if (item != null && !m_isInvulnerable)
		    if (!(item instanceof EnemyItem) && !(item instanceof BossBullet))
			SetPosition(m_fPosX, m_fPosY - 1);		
		item = GetCollisionLeft();		
		if (item != null && !m_isInvulnerable)
		    if (!(item instanceof EnemyItem) && !(item instanceof BossBullet))
			SetPosition(m_fPosX + 1, m_fPosY);
		item = GetCollisionRight();		
		if (item != null && !m_isInvulnerable)
		    if (!(item instanceof EnemyItem) && !(item instanceof BossBullet))
			SetPosition(m_fPosX - 1, m_fPosY);
		if (m_iMovingState == k_WALKING ||
			m_iMovingState == k_RUNNING) {
			if (m_iTickCount <= 0) {
				if (m_iMovingState == k_WALKING) {
					// Walking --> Standing
					m_iMovingState = k_STANDING;
					if (!m_isReleaseDownButton &&
						(m_iLevel == k_MEDIUM ||
						m_iLevel == k_LARGE)) {
						m_Sprite.setFrame(m_iStarPlus + 1);
					} else {
						m_Sprite.setFrame(m_iStarPlus + 0);
					}
					m_fSpeed = 0;
					return;
				} else {
					// Running --> Walking
					m_iTickCount = 2;
					m_iMovingState = k_WALKING;
					m_fSpeed = (m_fSpeed > 0. ?
						k_FINAL_WALKING : -k_FINAL_WALKING);
				}
			}
			// Update sprite's frame
			int curFrame = m_Sprite.getFrame() % 7;
			if (m_isReleaseDownButton == false && curFrame == 1) {
				m_Sprite.setFrame(m_iStarPlus + 1);
			}
			else if (curFrame == 5)
				m_Sprite.setFrame(m_iStarPlus + 4);
			else if (curFrame == 4)
				m_Sprite.setFrame(m_iStarPlus + 3);
			else
				m_Sprite.setFrame(m_iStarPlus + 5);
			return;
		}
		if (m_iMovingState == k_BRAKING) {
			if (m_iTickCount <= 0) { // Braking --> Walking
				m_iDir = -m_iDir;
				m_iMovingState = k_WALKING;
				m_iTickCount = 2;
				m_fSpeed = (m_iDir > 0 ?
					k_INITIAL_SPEED : -k_INITIAL_SPEED);
			}
			return;
		}
		if (m_iMovingState == k_JUMPING) {
			if (m_iTickCount <= 0) { // Jumping --> Falling
				m_fHover = -m_fHover;
				m_iMovingState = k_FALLING;
			} else {
				if (m_fHover > k_FINAL_HOVER) {
					m_fHover = -k_FINAL_HOVER;
					m_iMovingState = k_FALLING;
				} else {
					m_fHover *= k_HOVER_SCALE;
				}
			}
			return;
		}
		if (m_iMovingState == k_FALLING) {
			if (m_fHover < -k_INITIAL_HOVER) {
				m_fHover /= k_HOVER_SCALE;
			}
			return;
		}
	}
		
	private void ProcessLRKeypressed (int nextDir, int keyState) {
		if (m_iDir != nextDir && m_iMovingState != k_JUMPING &&
			m_iMovingState != k_FALLING) { // Change direction
			if (m_iMovingState == k_BRAKING) { // Braking
				if (m_fSpeed * m_iDir < 0.2f) {
					// End braking
					m_iDir = -m_iDir;
					m_iMovingState = k_WALKING;
					m_fSpeed = nextDir * k_INITIAL_SPEED;
					m_iTickCount = 2;
				} else {
					m_fSpeed *= k_BRAKING_SCALE;
				}
			} else if (m_fSpeed * m_iDir < k_FINAL_WALKING) {
				// Not enough speed to brake
				m_iDir = -m_iDir;
				m_iMovingState = k_WALKING;
				m_fSpeed = nextDir * k_INITIAL_SPEED;
				m_iTickCount = 2;
				m_Sprite.setFrame(m_iStarPlus + 5);
			} else { // Start braking
				if (m_iMovingState == k_WALKING) {
					// Walking --> Braking
					m_iTickCount = 3;
				} else {
					// Running --> Braking, need more time
					m_iTickCount = 6;
				}
				m_iMovingState = k_BRAKING;
				m_fSpeed *= k_BRAKING_SCALE;
				m_Sprite.setFrame(m_iStarPlus + 2);
			}
			return;
		}
		if (m_isHoldingB) { // Holding B button
			if (m_iMovingState == k_STANDING) { // Standing --> Running
				m_iMovingState = k_RUNNING;
				m_fSpeed = nextDir * k_INITIAL_SPEED;
				m_iTickCount = 4;
				m_Sprite.setFrame(m_iStarPlus + 5);
			} else if (m_iMovingState == k_WALKING) {
				if (m_isReleaseDownButton) {
					// Walking --> Running
					m_iMovingState = k_RUNNING;
					m_iTickCount += 3;
					m_Sprite.setFrame(m_iStarPlus + 5);
				}
			} else if (m_iMovingState == k_RUNNING) { // Running
				if (m_iTickCount < 10) {
					if (m_isReleaseDownButton) {
						m_iTickCount += 3;
					}
				}
				if (m_fSpeed * nextDir < k_FINAL_RUNNING) {
					m_fSpeed = nextDir * Math.min(
						nextDir * m_fSpeed * k_RUNNING_SCALE,
						k_FINAL_RUNNING);
				}
			}
		} else { // Not holding B button
			if (m_iMovingState == k_STANDING) { // Standing --> Walking
				m_iMovingState = k_WALKING;
				m_fSpeed = nextDir * k_INITIAL_SPEED;
				m_iTickCount = 2;
				m_Sprite.setFrame(m_iStarPlus + 5);
			} else if (m_iMovingState == k_WALKING) { // Walking
				if (m_iTickCount < 10) {
					if (m_isReleaseDownButton) {
						m_iTickCount += 2;
					}
				}
				if (m_fSpeed * nextDir < k_FINAL_WALKING) {
					m_fSpeed = nextDir * Math.min(
						nextDir * m_fSpeed * k_WALKING_SCALE,
						k_FINAL_WALKING);
				}
			} else if (m_iMovingState == k_RUNNING) {
				// Running --> Walking
				m_fSpeed *= k_SLOW_SCALE;
			}
		}
                
		// handle star state
		if (m_hasStar) {
			m_iStarCount--;
			if (m_iStarCount <= 0) {
				// end star status
			}
			if (m_iStarCount % 2 == 1)
				m_iStarPlus = (m_iStarPlus + 7) % 21;
		}
	}
	
	private void ProcessUpKeypressed () {
		if (m_iMovingState == k_JUMPING) {
			if (m_iTickCount < 10) {
				m_iTickCount += 2; // Lengthen the time Mario jumping up
			}
		} else if (m_isReleaseJumpButton) {
			// jmup music//
			MusicManager.GetInstance().Play(MusicManager.k_Jump);
			m_isReleaseJumpButton = false;
			m_iMovingState = k_JUMPING;
			m_fHover = k_INITIAL_HOVER;
			if (m_fSpeed >= k_FINAL_RUNNING ||
				m_fSpeed <= -k_FINAL_RUNNING) {
					m_fHover += k_BONUS_HOVER;
			}
			m_iTickCount = 5;
			m_Sprite.setFrame(m_iStarPlus + 6);
		}
	}
	
	protected static int s_iBullet = 2;
	int tempTime = 0;
	public void ProcessUserInput (int keyState) {
		if (m_iMovingState == k_PIPE_FALLING ||
			m_iMovingState == k_PIPE_RIGHT_MOVING) {
			return;
		}
		m_isReleaseDownButton = (keyState & KEY_DOWN) == 0;
		if (!m_isReleaseDownButton && m_PipeItem != null &&
			GetLeft() - m_PipeItem.GetLeft() >= 2 &&
			m_PipeItem.GetRight() - GetRight() >= 2) {
			m_iMovingState = k_PIPE_FALLING;
			m_Sprite.setFrame(0);
			// pipe falling music//
			MusicManager.GetInstance().Play(MusicManager.k_Pipe);
			SpriteManager manager = m_SpriteManager;
			Deregister(manager);
			Register(manager);
			return;
		}
		m_isHoldingB = (keyState & KEY_FIRE) != 0;
		if (m_isHoldingB && m_iLevel == k_LARGE) {                       
			if (s_iBullet > 0 && (MarioGameCanvas.s_iCurrentTime - tempTime) > 250 ){				
				tempTime = MarioGameCanvas.s_iCurrentTime;
				MarioBullet bullet = new MarioBullet(this);
				bullet.Register(PlayField.s_Instance.m_SpriteManager, true);
				s_iBullet--;
				MusicManager.GetInstance().Play(MusicManager.k_Fireball);
			}	
		}
		if ((keyState & KEY_LEFT) != 0 &&
			(keyState & KEY_RIGHT) != 0) {
			return;
		}		
		if ((keyState & KEY_LEFT) != 0) {
			if (!m_isReleaseDownButton &&
				m_iMovingState == k_STANDING) {
				return;
			}
			m_Sprite.setTransform(Sprite.TRANS_MIRROR);
			ProcessLRKeypressed(-1, keyState);
		}
		if ((keyState & KEY_RIGHT) != 0) {
			if (!m_isReleaseDownButton &&
				m_iMovingState == k_STANDING) {
				return;
			}
			m_Sprite.setTransform(Sprite.TRANS_NONE);
			ProcessLRKeypressed(1, keyState);
		}
		if ((keyState & KEY_UP) != 0 &&		
			m_iMovingState != k_FALLING &&
			m_iMovingState != k_BRAKING &&
			(m_iMovingState == k_JUMPING ||
			m_isReleaseJumpButton)) {
			if (!m_isReleaseDownButton &&
				m_iMovingState == k_STANDING) {
				return;
			}
			ProcessUpKeypressed();
			// Check moving while jumping
			if (m_iDir > 0) {
				m_Sprite.setTransform(Sprite.TRANS_NONE);
				if ((keyState & KEY_RIGHT) != 0)	 {	// move right
					if (m_fSpeed == 0)
						m_fSpeed = k_INITIAL_SPEED;
					else if (m_fSpeed < k_FINAL_WALKING)
						m_fSpeed = Math.min(m_fSpeed *
							k_AIRMOVING_SCALE, k_FINAL_WALKING);
				} else if ((keyState & KEY_LEFT) != 0) {
					if (m_fSpeed < 0)
						m_fSpeed *= k_AIRMOVING_SCALE;
					else if (0 <= m_fSpeed && m_fSpeed <= 0.8)
						m_fSpeed = -k_INITIAL_SPEED;
					else
						m_fSpeed *= k_AIRBRAKING_SCALE;
				}
			} else {
				m_Sprite.setTransform(Sprite.TRANS_MIRROR);
				if ((keyState & KEY_LEFT) != 0)	 {	// move right
					if (m_fSpeed == 0)
						m_fSpeed = -k_INITIAL_SPEED;
					else if (m_fSpeed > -k_FINAL_WALKING)
						m_fSpeed = Math.max(m_fSpeed *
							k_AIRMOVING_SCALE, -k_FINAL_WALKING);
				} else if ((keyState & KEY_RIGHT) != 0) {
					if (m_fSpeed > 0)
						m_fSpeed *= k_AIRMOVING_SCALE;
					else if (0 >= m_fSpeed && m_fSpeed >= -0.8)
						m_fSpeed = k_INITIAL_SPEED;
					else
						m_fSpeed *= k_AIRBRAKING_SCALE;
				}
			}
		} else if (m_iMovingState == k_FALLING) {
			// Check moving while dropping
			if (m_iDir > 0) {
				m_Sprite.setTransform(Sprite.TRANS_NONE);
				if ((keyState & GameCanvas.RIGHT_PRESSED) != 0)	 {	// move right
					if (m_fSpeed <= 0)
						m_fSpeed = k_INITIAL_SPEED;
					else if (m_fSpeed < k_FINAL_WALKING)
						m_fSpeed = Math.min(m_fSpeed *
							k_AIRMOVING_SCALE, k_FINAL_WALKING);
				} else if ((keyState & GameCanvas.LEFT_PRESSED) != 0) {
					if (m_fSpeed < 0 && m_fSpeed > -k_FINAL_WALKING)
						m_fSpeed = Math.max(m_fSpeed *
							k_AIRMOVING_SCALE, -k_FINAL_WALKING);
					else if (0 <= m_fSpeed && m_fSpeed <= 0.8)
						m_fSpeed = -k_INITIAL_SPEED;
					else
						m_fSpeed *= k_AIRBRAKING_SCALE;
				}
			} else {
				m_Sprite.setTransform(Sprite.TRANS_MIRROR);
				if ((keyState & GameCanvas.LEFT_PRESSED) != 0)	 {	// move right
					if (m_fSpeed == 0)
						m_fSpeed = -k_INITIAL_SPEED;
					else if (m_fSpeed > -k_FINAL_WALKING)
						m_fSpeed = Math.max(m_fSpeed *
							k_AIRMOVING_SCALE, -k_FINAL_WALKING);
				} else if ((keyState & GameCanvas.RIGHT_PRESSED) != 0) {
					if (m_fSpeed > 0 && m_fSpeed < k_FINAL_WALKING)
						m_fSpeed = Math.min(m_fSpeed *
							k_AIRMOVING_SCALE, k_FINAL_WALKING);
					else if (0 >= m_fSpeed && m_fSpeed >= -0.8)
						m_fSpeed = k_INITIAL_SPEED;
					else
						m_fSpeed *= k_AIRBRAKING_SCALE;
				}
			}
		} else if ((keyState & KEY_UP) == 0) {			
			m_isReleaseJumpButton = true;
		}
		if (!m_isReleaseDownButton) {
			if (m_iMovingState == k_STANDING ||
				m_iMovingState == k_WALKING ||
				m_iMovingState == k_RUNNING) {
				if (m_iLevel == k_MEDIUM || m_iLevel == k_LARGE) {
					m_Sprite.setFrame(m_iStarPlus + 1);
				}
			}
		} else {
			if (m_iMovingState == k_STANDING) {
				m_Sprite.setFrame(m_iStarPlus + 0);
			} else if (m_iMovingState == k_JUMPING || m_iMovingState == k_FALLING)
                                m_Sprite.setFrame(m_iStarPlus + 6);
		}	
		if (keyState == 0) {
			if (m_iMovingState == k_WALKING ||
				m_iMovingState == k_RUNNING) {
				if (m_fSpeed > k_FINAL_WALKING) {
					m_fSpeed = k_FINAL_WALKING;
				} else {
					m_fSpeed *= k_SLOW_SCALE;
				}
				return;
			}
			if (m_iMovingState == k_BRAKING) {
				m_iDir = -m_iDir;
				m_iMovingState = k_WALKING;
				m_iTickCount = 2;
				m_fSpeed = (m_iDir > 0 ?
					k_INITIAL_SPEED : -k_INITIAL_SPEED);
				return;
			}
		}
	}
        
	// override check collision functions
	public SpriteItem GetCollisionLeft () {
		if (!m_isInvulnerable)
			return super.GetCollisionLeft();
		SpriteItem result = null;
		Vector items = m_SpriteManager.m_vecSpriteItems;
		for (int i=0; i<items.size(); i++) {
			SpriteItem item = (SpriteItem)
				items.elementAt(i);
			if (item instanceof FlagItem) continue;
			int d = item.GetRight() - this.GetLeft();
			if (this != item && !(item instanceof HiddenBrickItem) &&
				d >= 0 && d <= 10 &&
				item.GetLeft() <= this.GetLeft() &&
				m_Sprite.collidesWith(item.m_Sprite, false)) {
				result = item;
			}
		}
		return result;
	}
	
	public SpriteItem GetCollisionRight () {
		if (!m_isInvulnerable)
			return super.GetCollisionRight();
		SpriteItem result = null;
		Vector items = m_SpriteManager.m_vecSpriteItems;
		for (int i=0; i<items.size(); i++) {
			SpriteItem item = (SpriteItem)
				items.elementAt(i);
			if (item instanceof FlagItem) continue;
			int d = this.GetRight() - item.GetLeft();
			if (this != item && !(item instanceof HiddenBrickItem) &&
				d >= 0 && d <= 10 &&
				item.GetRight() >= this.GetRight() &&
				m_Sprite.collidesWith(item.m_Sprite, false)) {
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
			if (((m_isInvulnerable || (item instanceof HiddenBrickItem && m_iMovingState == k_JUMPING)) && this != item &&
				d >= 0 && d <= 10 &&				
				item.GetTop() <= this.GetTop() &&
				m_Sprite.collidesWith(item.m_Sprite, false))
                        || (!m_isInvulnerable && this != item &&
				d >= 0 && d <= 10 &&				
				item.GetTop() <= this.GetTop() &&
				m_Sprite.collidesWith(item.m_Sprite, true)) ){				
				result = item;
			}
		}
		return result;
	}
	
	public SpriteItem GetCollisionBottom () {
		if (!m_isInvulnerable)
			return super.GetCollisionBottom();
		SpriteItem result = null;
		Vector items = m_SpriteManager.m_vecSpriteItems;
		for (int i=0; i<items.size(); i++) {
			SpriteItem item = (SpriteItem)
				items.elementAt(i);
			if (item instanceof FlagItem) continue;
			int d = this.GetBottom() - item.GetTop();
			if (item instanceof KoopasItem || item instanceof CarnivoreItem) {
				if (d >= 6 && d <= 20 &&				
					item.GetBottom() >= this.GetBottom() &&
					m_Sprite.collidesWith(item.m_Sprite, false)) {
					result = item;
				}
			}
			else {
				boolean b = true;
				if (item instanceof HiddenBrickItem)
					if (!((HiddenBrickItem)item).m_isRevealed)
						b = false;
				if (b && d >= 0 && d <= 10 &&				
					item.GetBottom() >= this.GetBottom() &&
					m_Sprite.collidesWith(item.m_Sprite, false)) {
					result = item;
				}
			}
		}
		return result;
	}
        
	public void BounceUp () {
		m_isReleaseJumpButton = false;
		m_iMovingState = k_JUMPING;
		m_fHover = k_INITIAL_HOVER * 2 / 3;
		SetPosition(m_fPosX, m_fPosY + m_fHover);
		m_iTickCount = 5;
		m_Sprite.setFrame(m_iStarPlus + 6);
	}
	
	public void MakeMarioShrink() {
		if (m_iLevel == k_SMALL) {
				PlayField.s_Instance.ForceMarioTransform(
					m_Sprite.getFrame() % 7, m_iDir,
					MarioTransform.k_DEATH);                                
				return;
		}

		m_iLevel = k_SMALL;
		// power down music//
		MusicManager.GetInstance().Play(MusicManager.k_PowerDown);
		PlayField.s_Instance.ForceMarioTransform(
				m_Sprite.getFrame() % 7, m_iDir,
				MarioTransform.k_SHRINK);

		// make Mario invulnerable & his sprite
		Image image = null;
		try {
			image = Image.createImage(16 * 7, 32);
			Graphics g = image.getGraphics();
			g.drawRegion(Resource.GetImage(Resource.k_Mario), 0, 0, 16 * 7, 16, Sprite.TRANS_NONE, 
					0, 0, Graphics.LEFT|Graphics.TOP);
			image = MarioTransform.FilterImage(image, 0x00FFFFFF);
			m_Sprite.setImage(image, 16, 16);
			//m_Sprite.setImage(Resource.GetImage(Resource.k_Mario), 16, 16);
		} catch (Exception e) {
			e.printStackTrace();
		}
		SetPosition(m_fPosX, m_fPosY + 16);
		m_isInvulnerable = true;
		m_iInvulnerableCount = k_INVULNERABLE_PERIOD;
	}
	
	public void SmashItemAbove(SpriteItem item) {
		// Move a little up to check anything above
		item.SetPosition(item.m_fPosX, item.m_fPosY - 2);
		SpriteItem ctop = item.GetCollisionTop();
		if (ctop instanceof CoinItem) {						
			FlipCoin flipCoin = new FlipCoin(Resource.k_Flip_Coin, ctop.GetTop()/16, ctop.GetLeft()/16);
			ctop.Deregister(m_SpriteManager);
			flipCoin.Register(m_SpriteManager);
			flipCoin.MoveUpward();
			// ---------------------------------------------------------------------- score coin
		} else if (ctop instanceof EnemyItem) {			
			if (ctop.GetLeft() <= item.GetLeft())
				((EnemyItem)ctop).GetBeaten(1);
			else
				((EnemyItem)ctop).GetBeaten(-1);
		}                    
		item.SetPosition(item.m_fPosX, item.m_fPosY + 2);
		// end checking
	}
}
