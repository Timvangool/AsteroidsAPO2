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
    class Player
    {
        //variables
        Texture2D playerTexture;
        int speed;
        Vector2 playerPos;

        public Player()
        {
            playerPos = new Vector2(0, 0);
            speed = 10;
        }

        public void Load(ContentManager content)
        {
            playerTexture = content.Load<Texture2D>("PlayerPlaceHolder");
        }

        public void Update(GameTime gameTime)
        {
 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, playerPos, Color.White);
        }
    }
}
