#define playGame

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
using Asteroids.Classes;

namespace Asteroids
{
    public class Game1 : Microsoft.Xna.Framework.Game 
    {
        Loader loader;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player p;
        Random r;
        HUD hud;
        List<Asteroid> asteroidList, asteroid, newAsteroidList;
        List<Weapon> killListWep;
        Vector2 dir;
        int numOfAsteroids;
        LoadingScreen loadingScreen;

        public static Game1 ExitGame;

        public Game1() 
        {
            ExitGame = this;
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

        protected override void Initialize() 
        {
            // TODO: Add your initialization logic here
#if playGame
            asteroidList = new List<Asteroid>();
            asteroid = new List<Asteroid>();
            newAsteroidList = new List<Asteroid>();
            killListWep = new List<Weapon>();
            for (int i = 0; i < numOfAsteroids; i++)
            {
                double angle = r.NextDouble() * 2 * Math.PI;
                asteroid.Add(new Asteroid(r.Next(1, graphics.PreferredBackBufferWidth), r.Next(1, graphics.PreferredBackBufferHeight), r.Next(1, 4), 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
            }
#endif
            loader = new Loader(this.Content);
            base.Initialize();
        }

        protected override void LoadContent() 
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            loadingScreen = new LoadingScreen(Content, graphics.GraphicsDevice);
#if playGame
            p.Load(Content);
            hud.Load(Content);

            foreach (Weapon wep in p.weapList)
            {
                wep.Load(Content, p.GetDirection());
            }
#endif
        }

        protected override void UnloadContent() 
        {
        }

        protected override void Update(GameTime gameTime) 
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (loadingScreen != null) 
            {
                IsFixedTimeStep = false;
                loader = loadingScreen.Update();
                if (loader != null) 
                {
                    loadingScreen = null;
                    IsFixedTimeStep = true;
                }
            }
            else 
            {
            }
#if playGame
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
#endif
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) 
        {
            if (loadingScreen != null) 
            {
                loadingScreen.Draw();
            }
            else 
            {
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
            }
            base.Draw(gameTime);
        }
#if playGame
        public void LevelsIncrease()
        {
            numOfAsteroids += r.Next(0, 3);
            hud.SetLevel(1);
            Initialize();
        }
#endif
    }
}
