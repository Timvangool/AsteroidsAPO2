using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imagetest
{
    class Bullet
    {
        public Texture2D DrawTexture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public int ActiveTime { get; set; }
        public int TotalActiveTime { get; set; }

        public Bullet(Texture2D texture, Vector2 position, Vector2 direction, float speed, int activeTime)
        {
            this.DrawTexture = texture;
            this.Position = position;
            this.Direction = direction;
            this.Speed = speed;
            this.ActiveTime = activeTime;

            this.TotalActiveTime = 0;
        }

        public void Update(GameTime gameTime)
        {
            this.Position += Direction * + Speed;
            this.TotalActiveTime += gameTime.ElapsedGameTime.Milliseconds;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(DrawTexture, Position, null,Color.White,0f,
                 new Vector2(DrawTexture.Width / 2,DrawTexture.Height / 2),
                 1.0f,SpriteEffects.None, 1.0f);
        }
    }
}
