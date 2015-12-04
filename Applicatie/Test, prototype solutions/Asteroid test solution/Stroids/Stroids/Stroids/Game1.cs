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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        private List<PowerUp> powerUp, powerUpKillList;
        private List<Asteroid> asteroidKillList, asteroid, newAsteroidList;
        private int screenWidth, screenHeight, numOfAsteroids;
        private Random rnd;
        LEVEL currentLevel;
        Vector2 dir;
        Texture2D texture;
        private AnimatedTexture SpriteTexture;
        private const float Rotation = 0;
        private const float Scale = 2.0f;
        private const float Depth = 0.5f;
        private const int frames = 4;
        private const int framesPerSec = 2;


        public enum LEVEL
        {
            LEVEL1,
            LEVEL2,
            LEVEL3,
            LEVEL4
        }
        #region Constructors
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            player = new Player();
            currentLevel = new LEVEL();
            currentLevel = LEVEL.LEVEL1;
            asteroidKillList = new List<Asteroid>();
            asteroid = new List<Asteroid>();
            newAsteroidList = new List<Asteroid>();
            powerUp = new List<PowerUp>();
            SpriteTexture = new AnimatedTexture();
            powerUpKillList = new List<PowerUp>();
        }
        #endregion

        #region Initialize
        protected override void Initialize()
        {
            base.Initialize();
            screenHeight = 600;
            screenWidth = 800;

            rnd = new Random();
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            graphics.ApplyChanges();

            foreach (PowerUp p in powerUp)
            {
                p.SetPos(new Vector2(0, 0));
                p.SetTexture(Content.Load<Texture2D>("powerup"));
                p.SetType(1);
                p.SetIsVisable(true);
            }

            player = new Player(new Vector2(400, 300), texture);
            asteroid.Clear();
            asteroidKillList.Clear();
            newAsteroidList.Clear();
            powerUp.Clear();


            switch (currentLevel)
            {
                case LEVEL.LEVEL1:
                    numOfAsteroids = 5;
                    break;
                case LEVEL.LEVEL2:
                    numOfAsteroids = 10;
                    break;
                case LEVEL.LEVEL3:
                    numOfAsteroids = 15;
                    break;
                case LEVEL.LEVEL4:
                    numOfAsteroids = 20;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < numOfAsteroids; i++)
            {
                double angle = rnd.NextDouble() * 2 * Math.PI;
                asteroid.Add(new Asteroid(rnd.Next(-50, graphics.PreferredBackBufferWidth + 50), rnd.Next(-50, graphics.PreferredBackBufferHeight + 50), rnd.Next(1, 4), 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
            }
        }
        #endregion

        #region Load/Unload content
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteTexture.Load(Content, "AsteroidExplosion", frames, framesPerSec);
            player.Load(Content);
        }

        protected override void UnloadContent()
        {

        }
        #endregion

        #region Update

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SpriteTexture.UpdateFrame(elapsed);

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            player.Update(gameTime);
            player.CheckBoundries(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            foreach (PowerUp p in powerUp)
            {
                if(p.GetHitbox().Intersects(player.GetPlayerHitbox()))
                {
                    powerUpKillList.Add(p);
                }

                p.Update(gameTime);
            }

            foreach (Asteroid ast in asteroid)
            {
                ast.Update(gameTime);
                ast.CheckBoundries(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

                if (player.GetPlayerHitbox().Intersects(ast.GetAsteroidHitbox()))
                {
                    switch (ast.GetSize())
                    {
                        case 1:
                            numOfAsteroids -= 1;
                            Vector2 temp = new Vector2((float)ast.getXPos(), (float)ast.getYPos());
                                spriteBatch.Begin();
                                SpriteTexture.DrawFrame(spriteBatch, temp);
                                spriteBatch.End();
                            asteroidKillList.Add(ast);
                            break;
                        case 2:
                            numOfAsteroids -= 1;
                            for (int i = 0; i < 2; i++)
                            {
                                double angle = rnd.NextDouble() * 2 * Math.PI;
                                newAsteroidList.Add(new Asteroid(ast.getXPos(), ast.getYPos(), 1, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
                                numOfAsteroids += 1;
                            }
                            asteroidKillList.Add(ast);
                            break;
                        case 3:
                            numOfAsteroids -= 1;
                            for (int i = 0; i < 2; i++)
                            {
                                double angle = rnd.NextDouble() * 2 * Math.PI;
                                newAsteroidList.Add(new Asteroid(ast.getXPos(), ast.getYPos(), 2, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
                                numOfAsteroids += 1;
                            }
                            asteroidKillList.Add(ast);
                            break;
                        default:
                            System.Windows.Forms.MessageBox.Show("Oeps");
                            break;
                    }
                }
            }

            foreach (Asteroid a in newAsteroidList)
            {
                asteroid.Add(a);
            }

            foreach (Asteroid a in asteroidKillList)
            {
                asteroid.Remove(a);
            }

            foreach (PowerUp p in powerUpKillList)
            {
                powerUp.Remove(p);
            }

            asteroidKillList.Clear();
            newAsteroidList.Clear();
            powerUpKillList.Clear();

            if (numOfAsteroids == 0)
            {
                switch (currentLevel)
                {
                    case LEVEL.LEVEL1:
                        currentLevel = LEVEL.LEVEL2;
                        InitializeNewLevel();
                        break;
                    case LEVEL.LEVEL2:
                        currentLevel = LEVEL.LEVEL3;
                        InitializeNewLevel();
                        break;
                    case LEVEL.LEVEL3:
                        currentLevel = LEVEL.LEVEL4;
                        InitializeNewLevel();
                        break;
                    case LEVEL.LEVEL4:
                        System.Windows.Forms.MessageBox.Show("You win!");
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            foreach (PowerUp p in powerUp)
            {
                p.Draw(spriteBatch, Content);
            }

            foreach (Asteroid a in asteroid)
            {
                a.Draw(spriteBatch, Content);
            }

            player.DrawPlayer(spriteBatch, Content);

            spriteBatch.End();

            base.Draw(gameTime);    
        }
        #endregion

        #region Methods

        public void InitializeNewLevel()
        {
            asteroid.Clear();
            asteroidKillList.Clear();
            newAsteroidList.Clear();
            powerUp.Clear();

            switch (currentLevel)
            {
                case LEVEL.LEVEL1:
                    numOfAsteroids = 5;
                    break;
                case LEVEL.LEVEL2:
                    numOfAsteroids = 10;
                    break;
                case LEVEL.LEVEL3:
                    numOfAsteroids = 15;
                    break;
                case LEVEL.LEVEL4:
                    numOfAsteroids = 20;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < numOfAsteroids; i++)
            {
                double angle = rnd.NextDouble() * 2 * Math.PI;
                asteroid.Add(new Asteroid(rnd.Next(-50 , graphics.PreferredBackBufferWidth + 50), rnd.Next(1, graphics.PreferredBackBufferHeight), rnd.Next(1, 4), 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
            }
        }

        #endregion
    }
}
