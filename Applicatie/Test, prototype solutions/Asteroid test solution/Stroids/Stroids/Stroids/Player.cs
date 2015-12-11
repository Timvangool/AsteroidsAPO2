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
    public class Player
    {
        private Vector2 pos, direction, oldDirection, origin;
        public Texture2D texture;
        private Random rnd;
        private Rectangle hitBox;
        private float maxSpeed, speed, angle;

        public Player()
        {
            rnd = new Random();
        }

        public Player(Vector2 pos, Texture2D texture)
        {
            this.pos = pos;
            this.texture = texture;
            rnd = new Random();
            maxSpeed = 10.0f;
            angle = 0.0f;
            speed = 0.5f;
            origin = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keystate = Keyboard.GetState();
            if (keystate.IsKeyDown(Keys.W))
            {
                Move();
            }
            if (keystate.IsKeyUp(Keys.W))
            {
                SlowDown();
            }
           if (keystate.IsKeyDown(Keys.A))
           {
               angle = angle - 0.1f;
               pos += oldDirection;
           }
           if (keystate.IsKeyDown(Keys.D))
           {
               angle = angle + 0.1f;
               pos += oldDirection;    
           }

           hitBox = new Rectangle((int)(pos.X - (50 / 2)), (int)(pos.Y - (50 / 2)), 50, 50);
        }
        public void Load(ContentManager content)
        {

        }

        public void SlowDown()
        {
            if (speed > 0 && speed <= maxSpeed)
            {
                speed -= 0.05F;
            }
            else if (speed <= 0.5F)
            {
                speed = 0.5F;
            }
            pos += (direction * speed);
        }

        public void Move()
        {
            direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            direction.Normalize();

            if (speed <= maxSpeed)
            {
                speed += 0.1F;
            }
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }

            pos += (direction * speed);
            oldDirection = direction;
        }

        public void DrawPlayer(SpriteBatch batch, ContentManager content)
        {
            batch.Draw(content.Load<Texture2D>("RocketIdle"), new Rectangle((int)pos.X, (int)pos.Y, 50, 50), null, Color.Fuchsia, angle, origin, SpriteEffects.None, 0.0f);
        }
            
        public void CheckBoundries(int scrnWidth, int scrnHeight)
        {
            if (pos.Y <= 0)
            {
                pos.Y = scrnHeight - 1;
            }
            if (pos.Y >= scrnHeight)
            {
                pos.Y = 0;
            }
            if (pos.X <= 0)
            {
                pos.X = scrnWidth - 1;
            }
            if (pos.X >= scrnWidth)
            {
                pos.X = 0;
            }
        }
        public Rectangle GetPlayerHitbox()
        {
            return hitBox;
        }

    }
}
