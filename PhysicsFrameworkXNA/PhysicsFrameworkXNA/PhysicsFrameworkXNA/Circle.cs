using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PhysicsFrameworkXNA
{
    class Circle
    {
        Texture2D pixel; //our pixel texture we will be using to draw primitives
        GraphicsDevice gd; //graphics device to use
        SpriteBatch sb; //sprite batch to use

        private Color color;
        public Vector2 position;
        public Vector2 velocity;
        public int radius;

        public Color Color { get; set; }

        public Circle(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Vector2 position, Color color, int radius)
        {
            this.gd = graphicsDevice;
            this.sb = spriteBatch;
            this.position = position;
            velocity = new Vector2(0, 0);
            this.color = color;
            this.radius = radius;
            pixel = new Texture2D(gd, 1, 1);
            pixel.SetData(new Color[] {color});
        }

        public void Draw()
        {
            for (int x = (int)position.X - radius; x <= (int)position.X + radius; x++)
            {
                for (int y = (int)position.Y - radius; y <= (int)position.Y + radius; y++)
                {
                    float dx = x - position.X;
                    float dy = y - position.Y;
                    if (dx * dx + dy * dy < radius * radius )
                    {
                        sb.Draw(pixel, new Vector2(x, y), color);
                    }
                }
            }
        }
    }
}
