using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids.Classes
{
    class Alien
    {
        Random rnd = new Random();
        GameTime gameTime = new GameTime();
        Texture2D drawTexture;
        Vector2 position;
        Vector2 direction;
        Vector2 origin;
        float rotation;
        float speedX;
        float speedY;
        Texture2D bulletTexture;
        public List<BulletAlien> bullets;
        int timeBetweenShots = 1000;
        int shottimer = 0;
        double time;
        int moveRandom = 0;
        int timeRandom = 0;

        public Alien(Texture2D texture, Vector2 position, Vector2 direction, float rotation, float speed, Texture2D bulletTexture)
        {
            this.drawTexture = texture;
            this.position = position;
            this.direction = direction;
            this.rotation = rotation;
            this.speedX = speed;
            this.speedY = speedX / 2;
            this.bulletTexture = bulletTexture;
            bullets = new List<BulletAlien>();
        }
        public void Update(GameTime gameTime)
        {
            MoveAround(gameTime);
            ShootBullet(gameTime);
        }
        public void MoveAround(GameTime gameTime)
        {
            double Elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
            time += Elapsed;
            position.X += speedX;

            timeRandom = rnd.Next(700, 1400);
            if (time >= timeRandom)
            {
                moveRandom = rnd.Next(1, 4);
                time = 0;
            }
            if (moveRandom == 2)
            {
                position.Y += speedY;
            }
            else if (moveRandom == 3)
            {
                position.Y -= speedY;
            }
            else
            {
                position.Y += 0;
            }
            int maxX = 750;
            int minX = 0;
            int maxY = 500;
            int minY = 0;

            if (position.X >= maxX)
            {
                speedX *= -1;
                position.X = maxX;
            }

            else if (position.X <= minX)
            {
                speedX *= -1;
                position.X = minX;
            }

            if (position.Y >= maxY)
            {
                speedY *= -1;
                position.Y = maxY;
            }

            else if (position.Y <= minY)
            {
                speedY *= -1;
                position.Y = minY;
            }
        }
        public void ShootBullet(GameTime gameTime)
        {
            this.origin = new Vector2(position.X + drawTexture.Width / 2, position.Y + drawTexture.Height / 2);
            shottimer += gameTime.ElapsedGameTime.Milliseconds;

            if (shottimer > timeBetweenShots)
            {
                shottimer = 0;
                BulletAlien b = new BulletAlien(
                    bulletTexture,
                    this.origin,
                    this.direction,
                    1, // The speed
                    2000); // The active time in Milliseconds
                bullets.Add(b);
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime);

                if (bullets[i].totalActiveTime > bullets[i].activeTime)
                    bullets.RemoveAt(i);
            }
            direction.X = rnd.Next(-5, 5);
            direction.Y = rnd.Next(-5, 5);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(drawTexture, position, Color.Pink);
            foreach (BulletAlien b in bullets)
            {
                b.Draw(spritebatch);
            }
        }

        public List<BulletAlien> GetBulletList()
        {
            return bullets;
        }
    }
}
