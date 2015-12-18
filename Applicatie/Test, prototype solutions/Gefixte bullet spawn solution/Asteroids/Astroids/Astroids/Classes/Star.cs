using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Asteroids
{
    class Star
    {
        private Texture2D starTexture;
        private Vector2 location;
        private GraphicsDevice graphicsManager;
        private Random rnd;

        public Star(GraphicsDevice graphicsManager, ContentManager content, Random rnd)
        {
            this.graphicsManager = graphicsManager;
            this.rnd = rnd;
            //colour = Color.White;
            LoadTexture(content);
            SetRandomLocation();
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(starTexture, location, color);
        }

        public void SetRandomLocation()
        {
            int screenHeight = graphicsManager.Viewport.Height;
            int screenWidth = graphicsManager.Viewport.Width;
            location = new Vector2(rnd.Next(0, screenWidth), rnd.Next(0, screenHeight));
        }

        public void LoadTexture(ContentManager content)
        {
            int random = rnd.Next(0, 3);

            switch (random)
            {
                case 0:
                    starTexture = content.Load<Texture2D>("star1");
                    break;
                case 1:
                    starTexture = content.Load<Texture2D>("star2");
                    break;
                case 2:
                    starTexture = content.Load<Texture2D>("star3");
                    break;
            }   
        }
    }
}
