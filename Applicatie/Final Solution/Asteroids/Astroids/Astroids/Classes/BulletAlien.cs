using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids.Classes
{
    class BulletAlien
    {
        public Texture2D drawTexture; 
        public Vector2 position;
        public Vector2 direction; 
        public float speed; 
        public int activeTime;
        public int totalActiveTime;    
        private Rectangle hitBoxBullet;
        
        public BulletAlien(Texture2D texture, Vector2 position, Vector2 direction, float speed, int activeTime)
        {
            drawTexture = texture;
            this.position = position;
            this.direction = direction;
            this.speed = speed;
            this.activeTime = activeTime;

            totalActiveTime = 0;
        }

        public void Update(GameTime gameTime)
        {
            position += direction * +speed;
            totalActiveTime += gameTime.ElapsedGameTime.Milliseconds;

            hitBoxBullet = new Rectangle((int)(position.X - (drawTexture.Width / 2)), (int)(position.Y - (drawTexture.Height / 2)), 100, 100);
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //hitBoxBullet = (new Rectangle((int)(position.X - (drawTexture.Width / 2)), (int)(position.Y - (drawTexture.Height / 2)), drawTexture.Width, drawTexture.Height));
            spriteBatch.Draw(drawTexture, position, hitBoxBullet, Color.Yellow, 0f,
                 new Vector2(drawTexture.Width / 2, drawTexture.Height / 2),
                 1.0f, SpriteEffects.None, 1.0f);
        }

        public Rectangle GetHitBoxBullet()
        {
            return hitBoxBullet;
        }
    }
}
