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


namespace Asteroids.Classes.Perks
{
    abstract class Perk
    {
        private Texture2D texture;
        private int duration, maxDuration;
        private const float speedIncrease = 1;
        private Player p;

        public Perk()
        {

        }

        #region get/set

        protected void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }

        protected Texture2D GetTexture()
        {
            return this.texture;
        }

        protected void SetDuration(int duration)
        {
            this.duration = duration;
        }

        protected int GetDuration()
        {
            return this.duration;
        }

        protected void SetMaxDuration(int maxDuration)
        {
            this.maxDuration = maxDuration;
        }

        protected int GetMaxDuration()
        {
            return this.maxDuration;
        }

        protected float GetSpeedIncrease()
        {
            return speedIncrease;
        }
        #endregion

        public abstract void Update();

        public abstract void Draw(SpriteBatch batch);

        public abstract void Load();

        public abstract void Activate();

    }
}
