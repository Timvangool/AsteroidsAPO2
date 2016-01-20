﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Asteroids.Classes
{
    class HUD
    {
        private Vector2 life1, life2, life3, life4, shieldLife1;
        private int score;
        private Rectangle wepBox;
        private Texture2D lifeSprite, shieldLifeSprite;
        private SpriteFont spriteFont;
        private int level, screenWidht, screenHeight;
        private Classes.Perks.ShieldPerk shield;

        public HUD(int screenWidth, int screenHeight, Classes.Perks.ShieldPerk shield)
        {
            score = 0;
            life1 = new Vector2(50, 10);
            life2 = new Vector2(100, 10);
            life3 = new Vector2(150, 10);
            life4 = new Vector2(200, 10);
            shieldLife1 = new Vector2(50, 75);
            wepBox = new Rectangle(250, 10, 500, 500);
            level = 1;
            this.screenHeight = screenHeight;
            this.screenWidht = screenWidth;
            this.shield = shield;
        }

        public void Load(ContentManager content)
        {
            lifeSprite = content.Load<Texture2D>("LifeSprite");
            shieldLifeSprite = content.Load<Texture2D>("ShieldBar");
            spriteFont = content.Load<SpriteFont>("Score");
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, int playerLife)
        {
            if (playerLife == 4)
            {
                spriteBatch.Draw(lifeSprite, life1, Color.White);
                spriteBatch.Draw(lifeSprite, life2, Color.White);
                spriteBatch.Draw(lifeSprite, life3, Color.White);
                spriteBatch.Draw(lifeSprite, life4, Color.White);
            }
            else if (playerLife == 3)
            {
                spriteBatch.Draw(lifeSprite, life1, Color.White);
                spriteBatch.Draw(lifeSprite, life2, Color.White);
                spriteBatch.Draw(lifeSprite, life3, Color.White);
            }
            else if (playerLife == 2)
            {
                spriteBatch.Draw(lifeSprite, life1, Color.White);
                spriteBatch.Draw(lifeSprite, life2, Color.White);
            }
            else if (playerLife == 1)
            {
                spriteBatch.Draw(lifeSprite, life1, Color.White);
            }

            if (shield.GetIsActive() == true)
            {
                if (shield.GetShieldLives() == 1)
                {
                    spriteBatch.Draw(shieldLifeSprite, shieldLife1, Color.White);
                }
            }


            spriteBatch.DrawString(spriteFont, Convert.ToString(score), new Vector2(screenWidht - 125, 10), Color.Red);
            spriteBatch.DrawString(spriteFont, Convert.ToString("Level: " + level), new Vector2(screenWidht - 125, 35), Color.Red);
        }

        public void SetScore(int score)
        {
            this.score += score;
        }

        public void SetLevel(int level)
        {
            this.level += level;
        }

        public int GetScore()
        {
            return score;
        }
    }
}
