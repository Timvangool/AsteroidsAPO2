using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Asteroids.Classes
{
    class Asteroid
    {

        private int posX, posY, size;
        private float speed;
        private Vector2 pos , direction;
        private Rectangle hitBox;

        public Asteroid()
        {
        }

        public Asteroid(int posX, int posY, int size, float speed, Vector2 direction)
        {
            this.posX = posX;
            this.posY = posY;
            this.size = size;
            this.speed = speed;
            this.direction = direction;
        }

        public Asteroid(Vector2 pos, int size, float speed, Vector2 direction)
        {
            this.pos = pos;
            this.size = size;
            this.speed = speed;
            this.direction = direction;
        }

        public void Load(ContentManager content)
        {

        }

        public void Draw(SpriteBatch batch, ContentManager content)
        {
            switch (size)
            {
                case 1:
                    batch.Draw(content.Load<Texture2D>("AsteroidSmall"), new Rectangle((int)pos.X, (int)pos.Y, 30, 30), Color.White);
                    hitBox = new Rectangle((int)pos.X, (int)pos.Y, 30, 30);
                    break;
                case 2:
                    batch.Draw(content.Load<Texture2D>("AsteroidMedium"), new Rectangle((int)pos.X, (int)pos.Y, 60, 60), Color.White);
                    hitBox = new Rectangle((int)pos.X, (int)pos.Y, 60, 60);
                    break;
                case 3:
                    batch.Draw(content.Load<Texture2D>("AsteroidLarge"), new Rectangle((int)pos.X, (int)pos.Y, 100, 100), Color.White);
                    hitBox = new Rectangle((int)pos.X, (int)pos.Y, 100, 100);
                    break;
                default:
                    
                    break;
            }
        }

        public void Update(GameTime gametime)
        {
            pos += direction;
        }

        public void CheckBoundries(int scrnWidth, int scrnHeight)
        {
            if (pos.Y <= 0)
            {
                pos.Y = scrnHeight - 1;
            }
            if (pos.Y >= scrnHeight)
            {
                pos.Y = 0;
            }
            if (pos.X <= 0)
            {
                pos.X = scrnWidth - 1;
            }
            if (pos.X >= scrnWidth)
            {
                pos.X = 0;
            }
        }

        public int GetSize()
        {
            return size;
        }

        public Rectangle GetAsteroidHitbox()
        {
            return hitBox;
        }

        public int GetXPos()
        {
            int temp = Convert.ToInt32(pos.X);
            return temp;
        }

        public int GetYPos()
        {
            int temp = Convert.ToInt32(pos.Y);
            return temp;
        }
    }
}
