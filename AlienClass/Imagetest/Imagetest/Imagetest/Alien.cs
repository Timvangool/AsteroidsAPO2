using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imagetest
{
    public class Alien
    {
        Random rng = new Random();
        GameTime time = new GameTime();
        Texture2D DrawTexture;
        Vector2 Position;
        Vector2 Direction;
        Vector2 Origin;
        float Rotation;
        float SpeedX;
        float SpeedY;
        Texture2D bulletTexture;
        List<Bullet> bullets;
        int timeBetweenShots = 1000;
        int shotTimer = 0;
        double Time;
        int MoveRandom = 0;
        int TimeRandom = 0;

        public Alien(Texture2D texture, Vector2 position, Vector2 direction, float rotation, float Speed, Texture2D bulletTexture)
        {
            this.DrawTexture = texture;
            this.Position = position;
            this.Direction = direction;
            this.Rotation = rotation;
            this.SpeedX = Speed;
            this.SpeedY = SpeedX / 2;
            this.bulletTexture = bulletTexture;
            bullets = new List<Bullet>();
        }
        public void Update(GameTime gameTime)
        {
            MoveAround(gameTime);
            ShootBullet(gameTime);
        }
        public void MoveAround(GameTime gameTime)
        {
            double Elapsed = gameTime.ElapsedGameTime.TotalMilliseconds;
            Time += Elapsed;
            Position.X += SpeedX;
            Random rngb = new Random();
            TimeRandom = rngb.Next(700, 1400);
            if (Time >= TimeRandom)
            {
                Random rn = new Random();
                MoveRandom = rng.Next(1, 4);
                Time = 0;
            }
            if (MoveRandom == 2)
            {
                Position.Y += SpeedY;
            }
            else if (MoveRandom == 3)
            {
                Position.Y -= SpeedY;
            }
            else
            {
                Position.Y += 0;
            }
            int MaxX = 750;
            int MinX = 0;
            int MaxY = 500;
            int MinY = 0;

            if (Position.X >= MaxX)
            {
                SpeedX *= -1;
                Position.X = MaxX;
            }

            else if (Position.X <= MinX)
            {
                SpeedX *= -1;
                Position.X = MinX;
            }

            if (Position.Y >= MaxY)
            {
                SpeedY *= -1;
                Position.Y = MaxY;
            }

            else if (Position.Y <= MinY)
            {
                SpeedY *= -1;
                Position.Y = MinY;
            }
        }
        public void ShootBullet(GameTime gameTime) 
        {
            this.Origin = new Vector2(Position.X + DrawTexture.Width / 2, Position.Y + DrawTexture.Height / 2);
            shotTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (shotTimer > timeBetweenShots)
            {
                shotTimer = 0;
                Bullet b = new Bullet(
                    bulletTexture,
                    this.Origin,
                    this.Direction,
                    1, // The Speed
                    2000); // The active time in Milliseconds
                bullets.Add(b);
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime);

                if (bullets[i].TotalActiveTime > bullets[i].ActiveTime)
                    bullets.RemoveAt(i);
            }
            Direction.X = rng.Next(-5, 5);
            Direction.Y = rng.Next(-5, 5);
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(DrawTexture, Position, Color.White);
            foreach (Bullet b in bullets)
            {
                b.Draw(spritebatch);
            }
        }
    }
}
