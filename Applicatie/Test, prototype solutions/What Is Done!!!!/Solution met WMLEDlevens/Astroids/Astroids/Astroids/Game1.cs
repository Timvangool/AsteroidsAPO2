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
using Astroids.Classes;

namespace Astroids
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player p;
        Random r;
        HUD hud;
        List<Asteroid> asteroidList, asteroid, newAsteroidList;
        List<Weapon> killListWep;
        Vector2 dir;
        int numOfAsteroids;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 900;
            Content.RootDirectory = "Content";
            r = new Random();
            p = new Player();
            hud = new HUD();
            numOfAsteroids = 5;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            asteroidList = new List<Asteroid>();
            asteroid = new List<Asteroid>();
            newAsteroidList = new List<Asteroid>();
            killListWep = new List<Weapon>();
            for (int i = 0; i < numOfAsteroids; i++)
            {
                double angle = r.NextDouble() * 2 * Math.PI;
                asteroid.Add(new Asteroid(r.Next(1, graphics.PreferredBackBufferWidth), r.Next(1, graphics.PreferredBackBufferHeight), r.Next(1, 4), 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            p.Load(Content);
            hud.Load(Content);

            foreach (Weapon wep in p.weapList)
            {
                wep.Load(Content, p.GetDirection());
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            p.Update(gameTime);
            p.CheckBoundries(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            hud.Update(gameTime);

            foreach (Asteroid ast in asteroid)
            {
                ast.Update(gameTime);
                ast.CheckBoundries(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

                if (p.GetPlayerHitbox().Intersects(ast.GetAsteroidHitbox()))
                {
                    switch (ast.GetSize())
                    {
                        case 1:
                            asteroidList.Add(ast);
                            p.SetLives((p.GetLife() - 1));
                            break;
                        case 2:
                            for (int i = 0; i < 2; i++)
                            {
                                double angle = r.NextDouble() * 2 * Math.PI;
                                newAsteroidList.Add(new Asteroid(ast.getXPos(), ast.getYPos(), 1, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
                            }
                            asteroidList.Add(ast);
                            p.SetLives((p.GetLife() - 1));
                            break;
                        case 3:
                            for (int i = 0; i < 2; i++)
                            {
                                double angle = r.NextDouble() * 2 * Math.PI;
                                newAsteroidList.Add(new Asteroid(ast.getXPos(), ast.getYPos(), 2, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
                            }
                            asteroidList.Add(ast);
                            p.SetLives((p.GetLife() - 1));
                            break;
                        default:

                            break;
                    }
                }
            }

            if (asteroid.Count == 0)
            {
                LevelsIncrease();
            }

            foreach (Asteroid a in newAsteroidList)
            {
                asteroid.Add(a);
            }

            foreach (Asteroid a in asteroidList)
            {
                asteroid.Remove(a);
            }

            asteroidList.Clear();
            newAsteroidList.Clear();

            foreach (Weapon wep in p.weapList)
            {
                wep.Update(gameTime, wep.GetDirection());
                wep.CheckBoundries(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

                if (wep.GetFadeTime() == 0)
                {
                    wep.SetIsVisable(false);
                    killListWep.Add(wep);
                }

                foreach (Asteroid a in asteroid)
                {
                    if (wep.GetHitbox().Intersects(a.GetAsteroidHitbox()))
                    {
                         switch (a.GetSize())
                         {
                             case 1:
                            asteroidList.Add(a);
                            killListWep.Add(wep);
                            hud.SetScore(10);
                            break;
                        case 2:
                            for (int i = 0; i < 2; i++)
                            {
                                double angle = r.NextDouble() * 2 * Math.PI;
                                newAsteroidList.Add(new Asteroid(a.getXPos(), a.getYPos(), 1, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
                            }
                            asteroidList.Add(a);
                            killListWep.Add(wep);
                            hud.SetScore(25);
                            break;
                        case 3:
                            for (int i = 0; i < 2; i++)
                            {
                                double angle = r.NextDouble() * 2 * Math.PI;
                                newAsteroidList.Add(new Asteroid(a.getXPos(), a.getYPos(), 2, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
                            }
                            asteroidList.Add(a);
                            killListWep.Add(wep);
                            hud.SetScore(50);
                            break;
                        default:

                            break;
                         }
                    }
                }
            }

            foreach (Weapon weap in killListWep)
            {
                p.weapList.Remove(weap);
            }

            base.Update(gameTime);
        }
                    

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            foreach (Weapon wep in p.weapList)
            {
                wep.Draw(spriteBatch);
            }
            foreach (Asteroid a in asteroid)
            {
                a.Draw(spriteBatch, Content);
            }
            p.Draw(spriteBatch);
            hud.Draw(spriteBatch, p.GetLife());
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void LevelsIncrease()
        {
            numOfAsteroids += r.Next(0, 3);
            hud.SetLevel(1);
            Initialize();
        }
    }
}
