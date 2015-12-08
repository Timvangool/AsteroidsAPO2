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
    class Missile : Weapon
    {
        public Missile()
        {
            speed = 10;
            isVisable = true;
            fadeTime = 1000;
        }

        public override void Load(ContentManager content, Vector2 direction)
        {

        }

        public override void Update(GameTime gameTime, Vector2 direction)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }


    }
}
