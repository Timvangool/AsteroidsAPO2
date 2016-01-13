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
        private Vector2 pos, direction;
        private Rectangle hitBox;
        private SpritesheetLoader SmallAstExp, MedAstExp, LargeAstExp;
        private Texture2D SmallAst, MedAst, LargeAst;
        private bool GetHit, ReadyToKill;

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

        public Asteroid(Vector2 pos, int size, float speed, Vector2 direction, ContentManager content)
        {
            this.pos = pos;
            this.size = size;
            this.speed = speed;
            this.direction = direction;
            this.GetHit = false;
            this.ReadyToKill = false;
            SmallAst = content.Load<Texture2D>("AsteroidSmall");
            MedAst = content.Load<Texture2D>("AsteroidMedium");
            LargeAst = content.Load<Texture2D>("AsteroidLarge");
            SmallAstExp = new SpritesheetLoader("SAExplosion", false, 4, content);
            MedAstExp = new SpritesheetLoader("MAExplosion", false, 6, content);
            LargeAstExp = new SpritesheetLoader("LAExplosion", false, 6, content);
        }

        public void Load(ContentManager content)
        {

        }

        public void Draw(SpriteBatch batch, ContentManager content)
        {
            switch (size)
            {
                case 1:
                    batch.Draw(SmallAst, new Rectangle((int)pos.X, (int)pos.Y, 30, 30), Color.White);
                    hitBox = new Rectangle((int)pos.X, (int)pos.Y, 30, 30);
                    break;
                case 2:
                    batch.Draw(MedAst, new Rectangle((int)pos.X, (int)pos.Y, 60, 60), Color.White);
                    hitBox = new Rectangle((int)pos.X, (int)pos.Y, 60, 60);
                    break;
                case 3:
                    batch.Draw(LargeAst, new Rectangle((int)pos.X, (int)pos.Y, 100, 100), Color.White);
                    hitBox = new Rectangle((int)pos.X, (int)pos.Y, 100, 100);
                    break;
                default:

                    break;
            }
        }

        public void ExplodeAnimation()
        {
            switch (size)
            {
                case 1:
                    SmallAst = SmallAstExp.tx;
                    SmallAstExp.GetNextSprite();
                    if (SmallAstExp.isRunning == false)
                    {
                        ReadyToKill = true;
                    }
                    break;
                case 2:
                    MedAst = MedAstExp.tx;
                    MedAstExp.GetNextSprite();
                    if (MedAstExp.isRunning == false)
                    {
                        ReadyToKill = true;
                    }
                    break;
                case 3:
                    LargeAst = LargeAstExp.tx;
                    LargeAstExp.GetNextSprite();
                    if (LargeAstExp.isRunning == false)
                    {
                        ReadyToKill = true;
                    }
                    break;
                default:
                    break;
            }
        }

        public void Update(GameTime gametime)
        {
            pos += direction;
            if (GetHit)
            {
                ExplodeAnimation();
                hitBox = new Rectangle();
            }
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

        public bool GetIsRunning()
        {
            return SmallAstExp.isRunning;
        }

        public bool GetReadyToKill()
        {
            return ReadyToKill;
        }

        public void SetGetHit(bool GetHit)
        {
            this.GetHit = GetHit;
        }
    }
}
