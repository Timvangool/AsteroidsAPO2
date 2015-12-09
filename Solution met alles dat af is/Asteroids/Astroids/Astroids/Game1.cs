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
using Asteroids.Classes;

namespace Asteroids
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ControlHandler ch;
        Player p;
        Random r;
        HUD hud;
        Background background;
        OptionsMenu oMenu;
        AsteroidsIntro intro;
        List<Asteroid> asteroidKillList, asteroid, newAsteroidList;
        List<Weapon> killListWep;
        Vector2 dir;
        GamestateManager gsm;
        int playerLife;
        int numOfAsteroids;
        int currentGameState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            gsm = new GamestateManager();
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 900;
            Content.RootDirectory = "Content";
            ch = new ControlHandler();
            r = new Random();
            p = new Player();
            hud = new HUD();
            oMenu = new OptionsMenu(graphics, Content);
            intro = new AsteroidsIntro();
            numOfAsteroids = 3;
            currentGameState = 1;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            asteroidKillList = new List<Asteroid>();
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
            intro.Load(Content, graphics);
            oMenu.Load();
            background = new Background(GraphicsDevice, Content);

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

            gsm.GameStateChanger(currentGameState);

            if (currentGameState == 1)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    currentGameState = 3;
                }
                else
                {
                    intro.IntroText();
                }
            }

            if (currentGameState == 3)
            {
                p.Update(gameTime, ch);
                p.CheckBoundries(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                hud.Update(gameTime);

                foreach (Asteroid a in asteroid)
                {
                    a.Update(gameTime);
                    a.CheckBoundries(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

                    if (p.GetPlayerHitbox().Intersects(a.GetAsteroidHitbox()))
                    {
                        switch (a.GetSize())
                        {
                            case 1:
                                numOfAsteroids -= 1;
                                Vector2 temp = new Vector2((float)a.GetXPos(), (float)a.GetYPos());
                                asteroidKillList.Add(a);
                                p.SetLives((p.GetLife() - 1));
                                break;
                            case 2:
                                numOfAsteroids -= 1;
                                for (int i = 0; i < 2; i++)
                                {
                                    double angle = r.NextDouble() * 2 * Math.PI;
                                    newAsteroidList.Add(new Asteroid(new Vector2(a.GetXPos(), a.GetYPos()), 1, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
                                    numOfAsteroids += 1;
                                }
                                asteroidKillList.Add(a);
                                p.SetLives((p.GetLife() - 1));
                                break;
                            case 3:
                                numOfAsteroids -= 1;
                                for (int i = 0; i < 2; i++)
                                {
                                    double angle = r.NextDouble() * 2 * Math.PI;
                                    newAsteroidList.Add(new Asteroid(new Vector2(a.GetXPos(), a.GetYPos()), 2, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
                                    numOfAsteroids += 1;
                                }
                                asteroidKillList.Add(a);
                                p.SetLives((p.GetLife() - 1));
                                break;
                            default:
                                System.Windows.Forms.MessageBox.Show("Oeps");
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

                foreach (Asteroid a in asteroidKillList)
                {
                    asteroid.Remove(a);
                }

                asteroidKillList.Clear();
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
                                    asteroidKillList.Add(a);
                                    killListWep.Add(wep);
                                    hud.SetScore(10);
                                    numOfAsteroids -= 1;
                                    break;
                                case 2:
                                    for (int i = 0; i < 2; i++)
                                    {
                                        double angle = r.NextDouble() * 2 * Math.PI;
                                        newAsteroidList.Add(new Asteroid(new Vector2(a.GetXPos(), a.GetYPos()), 1, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
                                        numOfAsteroids += 1;
                                    }
                                    asteroidKillList.Add(a);
                                    killListWep.Add(wep);
                                    hud.SetScore(25);
                                    break;
                                case 3:
                                    for (int i = 0; i < 2; i++)
                                    {
                                        double angle = r.NextDouble() * 2 * Math.PI;
                                        newAsteroidList.Add(new Asteroid(new Vector2(a.GetXPos(), a.GetYPos()), 2, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
                                        numOfAsteroids += 1;
                                    }
                                    asteroidKillList.Add(a);
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

                playerLife = p.GetLife();
                if (playerLife <= 0)
                {
                    currentGameState = 4;
                }
            }

            if (currentGameState == 4)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    numOfAsteroids = 5;
                    r = new Random();
                    p = new Player();
                    hud = new HUD();
                    Initialize();
                    currentGameState = 3;
                }
            }

            if (currentGameState == 5)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.F))
                {
                    currentGameState = 2;
                }
                else
                {
                    oMenu.Update(ch);
                }
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

            gsm.GameStateChanger(currentGameState);

            switch (currentGameState)
            {
                case 1:
                    //Intro
                    intro.Draw(spriteBatch);
                    break;
                case 2:
                    //Main Menu

                    break;
                case 3:
                    //The Game
                    spriteBatch.Begin();
                    background.Draw(spriteBatch);
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
                    break;
                case 4:
                    //Game Over

                    break;
                case 5:
                    //Options
                    oMenu.Draw(spriteBatch);
                    break;
                case 6:
                    //Highscores

                    break;
                case 7:
                    //Keybindings

                    break;
                case 8:
                    //Loading Screen

                    break;
                default:

                    break;
            }

            base.Draw(gameTime);
        }

        public void LevelsIncrease()
        {
            numOfAsteroids = (numOfAsteroids + r.Next(0, 3));
            hud.SetLevel(1);
            Initialize();
        }
    }
}
