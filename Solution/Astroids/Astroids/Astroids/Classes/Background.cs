using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Astroids.Classes
{
    class Background
    {
        private const int starAmount = 100;
        private const int planetAmount = 4;
        private Star[] starArray = new Star[starAmount];
        private Planet[] planetArray = new Planet[planetAmount];
        private GraphicsDevice graphicsManager;
        private ContentManager content;
        public Background(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.graphicsManager = graphicsDevice;
            this.content = content;
            LoadStars();
            LoadPlanets();
        }

        public void LoadStars()
        {
            Random rnd = new Random();
            for (int i = 0; i < starAmount; i++)
            {
                starArray[i] = new Star(graphicsManager, content, rnd);
            }
        }

        public void LoadPlanets()
        {
            Random rnd = new Random();
            for (int i = 0; i < planetAmount; i++)
            {
                planetArray[i] = new Planet(graphicsManager, content, rnd);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Random rnd = new Random();

            foreach (Star star in starArray)
            {
                int random = rnd.Next(0, 1000);

                if (random == 1)
                {
                    star.Draw(spriteBatch, Color.Cyan);
                }
                else if(random == 2)
                {
                    star.Draw(spriteBatch, Color.LightGray);
                }
                else if(random == 3)
                {
                    star.Draw(spriteBatch, Color.White);
                }
                else
                {
                    star.Draw(spriteBatch, Color.Gray);
                }

            }

            foreach (Planet planet in planetArray)
            {
                planet.Draw(spriteBatch, Color.Gray);
            }
        }
    }
}
