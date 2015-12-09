using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Astroids.Classes
{
    class Planet
    {
        private Vector2 location;
        private Texture2D planetTexture;
        private GraphicsDevice graphicsManager;
        private Random rnd;

        public Planet(GraphicsDevice graphicsManager, ContentManager content, Random rnd)
        {
            this.graphicsManager = graphicsManager;
            this.rnd = rnd;
            //colour = Color.White;
            LoadTexture(content);
            SetRandomLocation();
        }

        public void SetRandomLocation()
        {
            int screenHeight = graphicsManager.Viewport.Height;
            int screenWidth = graphicsManager.Viewport.Width;
            location = new Vector2(rnd.Next(0, screenWidth), rnd.Next(0, screenHeight));
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(planetTexture, location, color);
        }

        public void LoadTexture(ContentManager content)
        {
            int random = rnd.Next(0, 3);

            switch (random)
            {
                case 0:
                    planetTexture = content.Load<Texture2D>("Planet1");
                    break;
                case 1:
                    planetTexture = content.Load<Texture2D>("Planet2");
                    break;
                case 2:
                    planetTexture = content.Load<Texture2D>("Planet3");
                    break;
            }
        }
    }
}
