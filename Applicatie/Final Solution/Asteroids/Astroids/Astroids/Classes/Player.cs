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
    class Player
    {
        //variables
        private Texture2D playerTextureIdle, playerTextureMoving, defaultTexture, bulletTexture;
        private Vector2 playerPos;
        private Vector2 tempPlayerPos;
        private Vector2 origin;
        private Vector2 velocity;
        private Vector2 bulletDirection;
        private SoundEffect sound;
        private Rectangle hitBox;
        private Vector2 oldDirection;
        private Vector2 direction;
        public List<Weapon> weapList;
        private Random r;
        private float speed;
        private int lives;
        private float delay, maxDelay;
        private int maxSpeed;
        private int hitboxWidth;
        private int hitboxHeight;

        //Texture2D test;

        private float rotationAngle;

        public Player()
        {
            playerPos = new Vector2();
            speed = 0;
            maxSpeed = 5;
            lives = 3;
            weapList = new List<Weapon>();
            maxDelay = 0;
            delay = maxDelay;
            r = new Random();
        }

        public void Load(ContentManager content)
        {
            playerTextureMoving = content.Load<Texture2D>("RocketFlying");
            defaultTexture = content.Load<Texture2D>("RocketIdle");
            playerTextureIdle = defaultTexture;
            bulletTexture = content.Load<Texture2D>("RocketBulllet");
            sound = content.Load<SoundEffect>("SoundPlaceHolder");
            origin.X = playerTextureIdle.Width / 2;
            origin.Y = playerTextureIdle.Height / 2;
            bulletDirection = new Vector2((float)Math.Cos(rotationAngle), (float)Math.Sin(rotationAngle));
        }

        public void Move()
        {
            //velocity.X += 0.05f;
            float mass = 100000;
            // float r = 100;
            //if (velocity.Length() == 0.0f)
            //    r = 10000f;
            //else
            //    r = velocity.Length();
            //r = r * r;
            float f = mass * 100.0001f;
            float a = f / mass;
            Vector2 dir = new Vector2((float)Math.Cos(rotationAngle), (float)Math.Sin(rotationAngle));
            //dir.Normalize();

            velocity += dir * a;
            if (velocity.Length() > 3.0f)
            {
                velocity.Normalize();
                velocity *= 3.0f;
            }
        }

        public void SlowDown()
        {
            Vector2 dir = new Vector2((float)Math.Cos(rotationAngle), (float)Math.Sin(rotationAngle));
            dir.Normalize();

            if (velocity.Length() <= 0)
                velocity *= 0;
            else
                velocity *= 0.99f;
        }

        public void Update(GameTime gameTime, ControlHandler contHand)
        {
            //Player movement
            if (contHand.GetInput().Contains("Up"))
            {
                Move();
                playerTextureIdle = playerTextureMoving;
            }
            if (!contHand.GetInput().Contains("Up"))
            {
                SlowDown();
                playerTextureIdle = defaultTexture;
            }
            if (contHand.GetInput().Contains("Right"))
            {
                rotationAngle = rotationAngle + 0.1f;
                bulletDirection = new Vector2((float)Math.Cos(rotationAngle), (float)Math.Sin(rotationAngle));
            }
            if (contHand.GetInput().Contains("Left"))
            {
                rotationAngle = rotationAngle - 0.1f;
                bulletDirection = new Vector2((float)Math.Cos(rotationAngle), (float)Math.Sin(rotationAngle));
            }

            if (delay > 0)
            {
                delay--;
            }

            if (delay <= 0)
            {
                if (contHand.GetInput().Contains("Shoot"))
                {
                    weapList.Add(Shoot(1));
                }
            }
            playerPos += velocity;

            hitBox = new Rectangle((int)(playerPos.X - (playerTextureIdle.Width / 2)), (int)(playerPos.Y - (playerTextureIdle.Height / 2)), playerTextureIdle.Width, playerTextureIdle.Height);
            contHand.SetWiimoteLeds(0, lives);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTextureIdle, playerPos, null, Color.White, rotationAngle, origin, 1.0f, SpriteEffects.None, 0.0f);
            //spriteBatch.Draw(test, hitBox, Color.White);
        }

        public void CheckBoundries(int scrnWidth, int scrnHeight)
        {
            //top
            if (playerPos.Y <= 0)
            {
                playerPos.Y = scrnHeight - 1;
            }
            //bottom
            if (playerPos.Y >= scrnHeight)
            {
                playerPos.Y = 0;
            }
            //left
            if (playerPos.X <= 0 )
            { 
                playerPos.X = scrnWidth - 1;
            }
            //right
            if (playerPos.X >= scrnWidth)
            {
                playerPos.X = 0;
            }
        }
        public Weapon Shoot(int weapon)
        {
            // 1 = basic bullet
            if (weapon == 1)
            {
                BasicBullet basic = new BasicBullet();
                basic.SetTexture(bulletTexture);
                hitboxWidth = (basic.GetTextureWidth() / 2);
                hitboxHeight = (basic.GetTextureHeight() / 2);
                tempPlayerPos.X = (playerPos.X - hitboxWidth);
                tempPlayerPos.Y = (playerPos.Y - hitboxHeight);
                basic.SetPos(tempPlayerPos);
                basic.SetDirection(bulletDirection);
                delay = maxDelay;
                return basic;
            }
            return null;
        }

        public void SetPlayerPos(SpriteBatch sb)
        {
            playerPos.X = (sb.GraphicsDevice.Viewport.Width / 2) - hitboxWidth;
            playerPos.Y = (sb.GraphicsDevice.Viewport.Height / 2) - hitboxHeight;
        }

        public Vector2 GetDirection()
        {
            return direction;
        }

        public Rectangle GetPlayerHitbox()
        {
            return hitBox;
        }

        public void SetLives(int lives)
        {
            this.lives = lives;
        }

        public int GetLife()
        {
            return lives;
        }
    }
}
