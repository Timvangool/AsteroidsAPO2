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

namespace Astroids.Classes
{
    class AstroidThom
    {
        private Vector2 pos;
        private Texture2D texture;
        private Rectangle hitBox;
        private bool isVisable;
        private float speed;
        private int yPos;
        private int xPos;
        private int direction;

        public AstroidThom()
        {
            isVisable = true;
            speed = 1;
        }

        public AstroidThom(int yPos, int xPos, float speed, int direction)
        {
            this.yPos = yPos;
            this.xPos = xPos;
            this.speed = speed;
            isVisable = true;
            this.direction = direction;
        }

        public void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>("placeholderas");
            pos = new Vector2(xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            //Direction 1 = from the top, 2 = from the left, 3 = from the right, 4 = from the bottom;
            if(direction == 1)
            {
                pos.Y = pos.Y + speed;
            }
            if (direction == 2)
            {
                pos.X = pos.X + speed;
            }
            if (direction == 3)
            {
                pos.X = pos.X - speed;
            }
            if (direction == 4)
            {
                pos.Y = pos.Y - speed;
            }

            hitBox = new Rectangle((int)pos.X, (int)pos.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisable)
            {
                spriteBatch.Draw(texture, pos, Color.White);
            }
        }

        public void CheckBoundries(int scrnWidth, int scrnHeight)
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

        public Rectangle GetHitbox()
        {
            return hitBox;
        }

        public bool GetIsVisable()
        {
            return isVisable;
        }

        public void SetIsVisable(bool isVisable)
        {
            this.isVisable = isVisable;
        }
    }
}
