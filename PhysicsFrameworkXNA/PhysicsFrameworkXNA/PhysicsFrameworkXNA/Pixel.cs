using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsFrameworkXNA
{
    class Pixel
    {
        Texture2D pixel; //our pixel texture we will be using to draw primitives
        GraphicsDevice gd; //graphics device to use
        SpriteBatch sb; //sprite batch to use

        protected Color color;
        public Vector2 position;
        public Vector2 velocity;

        public Color Color { get; set; }

        public Pixel(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, int xposit, int yposit, Color col)
        {
            this.gd = graphicsDevice;
            this.sb = spriteBatch;
            position = new Vector2(xposit, yposit);
            velocity = new Vector2(0, 0);
            color = col;
            pixel = new Texture2D(gd, 1, 1);
            pixel.SetData(new Color[] {color});
        }

        public void Draw()
        {
            sb.Draw(pixel, position, color);
        }

        public void CheckBoundries(int scrnWidth, int scrnHeight)
        {
            if (position.Y < 0)
            {
                position.Y = 0;
                velocity.Y *= -1.0f;
            }

            if (position.Y > scrnHeight)
            {
                position.Y = scrnHeight;
                velocity.Y *= -1.0f;
            }

            if (position.X < 0)
            {
                position.X = 0;
                velocity.X *= -1.0f;
            }
            if (position.X > scrnWidth)
            {
                position.X = scrnWidth;
                velocity.X *= -1.0f;
            }
        }
    }
}
