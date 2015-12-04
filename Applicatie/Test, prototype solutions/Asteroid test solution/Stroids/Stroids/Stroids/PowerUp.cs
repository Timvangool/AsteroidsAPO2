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

namespace Stroids
{
    class PowerUp
    {
        private int type, posX, posY, duration;
        private Texture2D texture;
        private bool isVisable;
        private Rectangle hitBox;

        public PowerUp()
        {
            type = 1;
            posX = 0;
            posY = 0;
            duration = 0;
            texture = null;
            isVisable = true;
            hitBox = new Rectangle();

        }

        public void Load(ContentManager content)
        {
            if (type == 1)
            {

            }
        }

        public void Draw(SpriteBatch batch, ContentManager content)
        {
                batch.Draw(texture, new Rectangle(posX, posY, 30, 30), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            if(type == 1)   
            {

            }

            hitBox = new Rectangle((int)(posX - (50 / 2)), (int)(posY - (50 / 2)), 50, 50);
        }

        public Vector2 GetPos()
        {
            return new Vector2(posX, posY);
        }

        public void SetPos(Vector2 pos)
        {
            this.posX = (int)pos.X;
            this.posY = (int)pos.Y;
        }

        public int GetDuration()
        {
            return duration;
        }

        public void SetDuration(int duration)
        {
            this.duration = duration;
        }

        public int GetPowerUpType()
        {
            return type;
        }

        public void SetType(int type)
        {
            this.type = type;
        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }

        public void SetIsVisable(bool isVisable)
        {
            this.isVisable = isVisable;
        }

        public bool GetIsVisable()
        {
            return isVisable;
        }

        public Rectangle GetHitbox()
        {
            return hitBox;
        }
    }
}
