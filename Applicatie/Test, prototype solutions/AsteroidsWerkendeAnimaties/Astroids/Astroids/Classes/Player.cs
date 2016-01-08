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
        private SpritesheetLoader rocketExplodeSprite;
        private Texture2D playerTextureIdle, playerTextureMoving, defaultTexture, bulletTexture;
        private Vector2 playerPos;
        private Vector2 origin;
        private Vector2 bulletDirection;
        private SoundEffect sound;
        private Rectangle hitBox;
       // private Vector2 oldDirection;
        private int lives;
        Vector2 direction;
        public List<Weapon> weapList;
        private float delay, maxDelay;
        private ControlHandler contHand;
        private Random r;
        private bool GetHit;
        private bool IsInAnimation;
        private Vector2 velocity;

        //Texture2D test;

        private float rotationAngle;

        public Player()
        {
            playerPos = new Vector2(250, 250);
            lives = 3;
            contHand = new ControlHandler();
            weapList = new List<Weapon>();
            maxDelay = 25;
            delay = maxDelay;
            r = new Random();
            GetHit = false;
            IsInAnimation = false;
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
            rocketExplodeSprite = new SpritesheetLoader("RocketExplosion", false, 8, content);
        }

        public void Respawn()
        {
            lives -= 1;
            GetHit = false;
            playerPos = new Vector2(200, 200);
            playerTextureIdle = defaultTexture;
            IsInAnimation = false;
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

        public void Update(GameTime gameTime)
        {
            if (lives > 0)
            {
                if (IsInAnimation == false)
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
                }

                if (GetHit)
                {
                    RocketExplosion();
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
                hitBox = new Rectangle((int)(playerPos.X - (playerTextureIdle.Width / 2)), (int)(playerPos.Y - (playerTextureIdle.Height / 2)), playerTextureIdle.Width, playerTextureIdle.Height);
                playerPos += velocity;
                contHand.SetWiimoteLeds(0, lives);
            }
        }
        public void RocketExplosion()
        {
            IsInAnimation = true;
            playerTextureIdle = rocketExplodeSprite.tx;
            rocketExplodeSprite.GetNextSprite();
            velocity = new Vector2(0, 0);

            if (rocketExplodeSprite.isRunning == false)
            {
                Respawn();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTextureIdle, playerPos, null, Color.White, rotationAngle, origin, 1.0f, SpriteEffects.None, 0.0f);
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
            if (playerPos.X <= 0)
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

        public bool GetIsRunning()
        {
            return rocketExplodeSprite.isRunning;
        }

        public bool GetGetHit()
        {
            return GetHit;
        }

        public int GetLife()
        {
            return lives;
        }

        public void SetGetHit(bool getHit)
        {
            this.GetHit = getHit;
        }
    }
}
