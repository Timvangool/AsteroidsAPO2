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
namespace Astroids.Classes
{
    class Asteroid
    {
        ContentManager content;
        SpritesheetLoader largeAstSpriteLoader;
        SpritesheetLoader medAstSpriteLoader;
        SpritesheetLoader smallAstSpriteLoader;
        Rectangle largeAstRect = new Rectangle(-200, -200, 122, 127);
        Rectangle medAstRect = new Rectangle(-100, -100, 62, 65);
        Rectangle smallAstRect = new Rectangle(-50, -50, 27, 27);
        private int posX, posY, size;
        private float speed;
        private Vector2 pos , direction;
        private Rectangle hitBox;

        public Asteroid()
        {
        }

        public Asteroid(int posX, int posY, int size, float speed, Vector2 direction, ContentManager content)
        {
            this.posX = posX;
            this.posY = posY;
            this.size = size;
            this.speed = speed;
            this.direction = direction;
            this.content = content;
            largeAstSpriteLoader = new SpritesheetLoader("LAExplosion", false, 2, content);
            medAstSpriteLoader = new SpritesheetLoader("MAExplosion", false, 2, content);
            smallAstSpriteLoader = new SpritesheetLoader("SAExplosion", false, 2, content);
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
            //AsteroidExplosion = content.Load<Texture2D>("LargeAsteroidExplosionspritesheet");
            batch.Draw(largeAstSpriteLoader.tx, largeAstRect, Color.White);
            batch.Draw(medAstSpriteLoader.tx, medAstRect, Color.White);
            batch.Draw(smallAstSpriteLoader.tx, smallAstRect, Color.White);
        }

        public void Update(GameTime gametime)
        {
            pos += direction;
            ExplodeAnimation(gametime);
        }
        public void ExplodeAnimation(GameTime gametime)
        {
            switch (GetSize())
            {
                case 0:
                    this.smallAstRect.Location = new Point(this.posX - 5, this.posY - 5);
                    smallAstSpriteLoader.GetNextSprite();
                    break;
                case 1:
                    this.medAstRect.Location = new Point(this.posX - 7, this.posY - 7);
                    medAstSpriteLoader.GetNextSprite();
                    break;
                case 2:
                    this.largeAstRect.Location = new Point(this.posX - 10, this.posY - 8);
                    largeAstSpriteLoader.GetNextSprite();
                    break;
                default:
                    break;
            }
        }

        //public void Explodeanimation(GameTime gametime)
        //{
        //    
        //    elapsed += (float)gametime.ElapsedGameTime.TotalMilliseconds;
        //    for (int i = 1; i < 6; i++)
        //    {
        //        if (elapsed >= delay)
        //        {
        //            if (frames < 6)
        //            {
        //                frames++;
        //            }
        //            elapsed = 0;
        //        }
        //        sourcerect = new Rectangle(132 * frames, 0, 122, 117);
        //    }
        //}

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

        public int getXPos()
        {
            int temp = Convert.ToInt32(pos.X);
            return temp;
        }

        public int getYPos()
        {
            int temp = Convert.ToInt32(pos.Y);
            return temp;
        }
    }
}
