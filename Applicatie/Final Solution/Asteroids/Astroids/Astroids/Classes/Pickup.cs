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
    public class Pickup
    {
        private int index;
        private const int perkCount = 3;
        private Texture2D texture;
        private Vector2 pos, velocity;
        private Random rnd;
        private Rectangle hitBox;
        private bool isIntersected;
        private int temp;
        private SpriteFont font;

        private int framesElapsed, maxFrames;

        public Pickup()
        {
            rnd = new Random();
            pos.X = (float)rnd.Next(0, 900);
            pos.Y = (float)rnd.Next(0, 500);
            isIntersected = false;

            maxFrames = 180;
        }

        #region get/set

        public int GetIndex()
        {
            return index;
        }

        public void SetIndex(int index)
        {
            this.index = index;
        }

        public Texture GetTexture()
        {
            return texture;
        }

        public void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }

        public bool GetIsIntersected()
        {
            return isIntersected;
        }
        public Vector2 GetPos()
        {
            return pos;
        }

        public void SetPos(Vector2 pos)
        {
            this.pos = pos;
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public Rectangle GetHitbox()
        {
            return hitBox = new Rectangle((int)(pos.X - (texture.Width / 8)), (int)(pos.Y - (texture.Height / 8)), texture.Width, texture.Height);
        }

        protected void SetHitBox(Rectangle hitBox)
        {
            this.hitBox = hitBox;
        }
        #endregion

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch batch)
        {
            if (!isIntersected)
            {
                batch.Draw(texture, new Rectangle((int)pos.X, (int)pos.Y, 30, 30), Color.White);
            }
        }

        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("PickupItem");
        }

        public int RandomPerk()
        {
            index = rnd.Next(0, perkCount + 1);
            return index;
        }

        public void SetIsIntersected(bool isIntersected)
        {
            this.isIntersected = isIntersected;
        }

        public int SpawnPickup()
        {
            temp = rnd.Next(0, 100);

            return temp;
        }
    }
}
