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
    abstract class Weapon
    {
        protected Texture2D texture;
        protected Vector2 pos;
        protected Vector2 origin;
        protected Vector2 direction;
        protected float speed;
        protected bool isVisable;
        protected Rectangle hitBox;
        protected float fadeTime;


        public Weapon()
        {
            texture = null;
            pos = new Vector2();
            origin = new Vector2();
            speed = 0;
            fadeTime = 0;
            isVisable = true;
            hitBox = new Rectangle();
        }

        abstract public void Load(ContentManager content, Vector2 direction);

        abstract public void Update(GameTime gameTime, Vector2 direction);

        abstract public void Draw(SpriteBatch spriteBatch);

        virtual public void CheckBoundries(int scrnWidth, int scrnHeight)
        {
            //top
            if (pos.Y <= 0)
            {
                pos.Y = scrnHeight - 1;
            }
            //bottom
            if (pos.Y >= scrnHeight)
            {
                pos.Y = 0;
            }
            //left
            if (pos.X <= 0)
            {
                pos.X = scrnWidth - 1;
            }
            //right
            if (pos.X >= scrnWidth)
            {
                pos.X = 0;
            }
        }

        virtual public Texture2D GetTexture()
        {
            return texture;
        }

        virtual public void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }

        virtual public void SetPos(Vector2 pos)
        {
            this.pos = pos;
        }

        virtual public void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }

        virtual public Vector2 GetDirection()
        {
            return direction;
        }

        virtual public Vector2 GetPos()
        {
            return pos;
        }

        virtual public Rectangle GetHitbox()
        {
            return hitBox;
        }

        virtual public float GetFadeTime()
        {
            return fadeTime;
        }

        virtual public void SetIsVisable(bool isVisable)
        {
            this.isVisable = isVisable;
        }

        virtual public bool GetIsVisable()
        {
            return isVisable;
        }
    }
}
