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

namespace Asteroids.Classes
{
    class BasicBullet : Weapon
    {
        Texture2D tempTexture;

        public BasicBullet()
        {
            speed = 10;
            isVisable = true;
            fadeTime = 75;
        }

        public override void Load(ContentManager content, Vector2 direction)
        {
           // pos = pos + direction;
        }

        public override void Update(GameTime gameTime, Vector2 direction)
        {
            pos = pos + (direction * speed);
            fadeTime--;
            hitBox = new Rectangle((int)(pos.X - (texture.Width / 2)), (int)(pos.Y - (texture.Height / 2)), texture.Width, texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
        }

        public int GetTextureWidth()
        {
            tempTexture = texture;
            return tempTexture.Width;
        }

        public int GetTextureHeight()
        {
            tempTexture = GetTexture();
            return tempTexture.Height;
        }
    }
}
