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
        private float speed;
        private Vector2 playerPos;
        private Vector2 origin;
        private Vector2 bulletDirection;
        private SoundEffect sound;
        private Rectangle hitBox;
        private Vector2 oldDirection;
        private int lives;
        Vector2 direction;
        private int maxSpeed;
        public List<Weapon> weapList;
        private float delay, maxDelay;
        //private ControlHandler contHand;
        private Random r;

        //Texture2D test;

        private float rotationAngle;

        public Player()
        {
            playerPos = new Vector2(200,200);
            speed = 0;
            maxSpeed = 5;
            lives = 3;
            //contHand = new ControlHandler();
            weapList = new List<Weapon>();
            maxDelay = 25;
            delay = maxDelay;
            r = new Random();
        }

        public void Load(ContentManager content)
        {
            playerTextureMoving = content.Load<Texture2D>("RocketFlying");
            defaultTexture = content.Load<Texture2D>("RocketIdle");
            playerTextureIdle = defaultTexture;
            bulletTexture = content.Load<Texture2D>("RocketBulllet");
            //test = content.Load<Texture2D>("placeholderas");
            sound = content.Load<SoundEffect>("SoundPlaceHolder");
            origin.X = playerTextureIdle.Width / 2;
            origin.Y = playerTextureIdle.Height / 2;
        }

        public void Move()
        {
            direction = new Vector2((float)Math.Cos(rotationAngle), (float)Math.Sin(rotationAngle));
            direction.Normalize();
            if (speed <= maxSpeed)
            {
                speed += 0.1F;
            }
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }

            playerPos = playerPos + (direction * speed);
            oldDirection = direction;
        }

        public void SlowDown()
        {
            if (speed > 0 && speed <= maxSpeed)
            {
                speed -= 0.1F;
            }
            else if(speed <= 0.0F)
            {
                speed = 0.0F;
            }
            playerPos = playerPos + (direction * speed);
        }

        public void Update(GameTime gameTime)
        {
            //Player movement
            //if (contHand.GetInput().Contains("Up"))
            //{
            //    Move();
            //    playerTextureIdle = playerTextureMoving;
            //}
            //if (!contHand.GetInput().Contains("Up"))
            //{
            //    SlowDown();
            //    playerTextureIdle = defaultTexture;
            //}
            //if (contHand.GetInput().Contains("Right"))
            //{
            //    rotationAngle = rotationAngle + 0.1f;
            //    bulletDirection = new Vector2((float)Math.Cos(rotationAngle), (float)Math.Sin(rotationAngle));
            //}
            //if (contHand.GetInput().Contains("Left"))
            //{
            //    rotationAngle = rotationAngle - 0.1f;
            //    bulletDirection = new Vector2((float)Math.Cos(rotationAngle), (float)Math.Sin(rotationAngle));
            //}

            if (delay > 0)
            {
                delay--;
            }

            if (delay <= 0)
            {
                //if (contHand.GetInput().Contains("Shoot"))
                //{
                //    weapList.Add(Shoot(1));
                //}
            }

            hitBox = new Rectangle((int)(playerPos.X - (playerTextureIdle.Width / 2)), (int)(playerPos.Y - (playerTextureIdle.Height / 2)), playerTextureIdle.Width, playerTextureIdle.Height);
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
                basic.SetPos(playerPos);
                basic.SetDirection(bulletDirection);
                delay = maxDelay;
                return basic;
            }
            return null;
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
