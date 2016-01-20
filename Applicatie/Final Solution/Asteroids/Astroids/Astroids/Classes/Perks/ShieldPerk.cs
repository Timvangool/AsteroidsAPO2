using System;
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

namespace Asteroids.Classes.Perks
{
    class ShieldPerk : Perks.Perk
    {
        private ContentManager content;
        private Player p;
        private SpriteBatch batch;
        private bool isActive;
        private Rectangle hitBox;
        private int lives;
        private SpriteFont font;
        private int framesElapsed, maxFrames;

        public ShieldPerk()
        {

        }

        public ShieldPerk(ContentManager content, Player p)
        {
            this.content = content;
            this.p = p;
            this.isActive = false;
            lives = 1;

            maxFrames = 180;
        }

        public override void Update()
        {

        }

        public override void Load()
        {
            font = content.Load<SpriteFont>("LoadingScreen");
        }

        public override void Draw(SpriteBatch batch)
        {
            if (lives >= 1 || isActive != false)
            {
                batch.Draw(content.Load<Texture2D>("Shield"), new Rectangle((int)p.GetPos().X - 50, (int)p.GetPos().Y - 50, 100, 100), Color.White);
            }

            if (framesElapsed != maxFrames)
            {
                batch.DrawString(font, "Picked up : Shield Perk", new Vector2(250, 20), Color.Yellow);
                framesElapsed++;
            }

        }

        public override void Activate()
        {

        }

        public bool GetIsActive()
        {
            return isActive;
        }

        public void SetIsActive(bool isActive)
        {
            this.isActive = isActive;
        }

        public Rectangle GetHitBox()
        {
            if (lives >= 1)
            {
                return hitBox = new Rectangle((int)p.GetPos().X - 50, (int)p.GetPos().Y - 50, 100, 100);
            }
            else
            {
                return hitBox = new Rectangle(0, 0, 0, 0);
            }
        }

        public int GetShieldLives()
        {
            return lives;
        }

        public void SetShieldLives(int lives)
        {
            this.lives = lives;
        }

        public void SetElapsedFrames(int elapsedFrames)
        {
            this.framesElapsed = elapsedFrames;
        }
    }
}
