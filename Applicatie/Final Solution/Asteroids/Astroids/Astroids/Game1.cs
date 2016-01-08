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

        //TO DO: 
        //Aliens moeten worden geImplementeerd met collision
        
        Alien alien;
        BulletAlien bulletAlien;
        GraphicsDeviceManager graphics;
        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;
        ControlHandler ch;
        Player p;
        Random r;
        HUD hud;
        Background background;
        OptionsMenu oMenu;
        Loader loader;
        LoadingScreen loadingScreen;
        AsteroidsIntro intro;
        MainMenu mainMenu;
        GraphicsDevice graphicDevice;
        List<Asteroid> asteroidKillList, asteroid, newAsteroidList;
        List<Weapon> killListWep;
        List<BulletAlien> alienBulletKillList, newAlienBulletList;
        Vector2 dir, origin;
        GamestateManager gsm;
        Texture2D texture;
        public static Game1 ExitGame;
        int playerLife;
        int numOfAsteroids;
        int currentGameState;
        int rndNum;
        int rnd1;
        int rnd2;
        int screenHeight;
        int screenWidth;
        int activeTime;
        string[] alienBulletArray;
        float speed;
        bool isOpen;
        bool isKeyUp;

        public Game1()
        {
            bulletAlien = new BulletAlien(texture, origin, dir, speed, activeTime);
            graphics = new GraphicsDeviceManager(this);
            gsm = new GamestateManager();
            //   graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 900;
            Content.RootDirectory = "Content";
            ExitGame = this;
            ch = new ControlHandler();
            r = new Random();
            p = new Player();
            hud = new HUD(graphics);
            oMenu = new OptionsMenu(graphics, Content);
            intro = new AsteroidsIntro();
            
            screenHeight = graphics.PreferredBackBufferHeight;
            screenWidth = graphics.PreferredBackBufferWidth;
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
            isOpen = false;
            isKeyUp = false;
            asteroidKillList = new List<Asteroid>();
            asteroid = new List<Asteroid>();
            newAsteroidList = new List<Asteroid>();
            killListWep = new List<Weapon>();
            alienBulletKillList = new List<BulletAlien>();
            newAlienBulletList = new List<BulletAlien>();

            for (int i = 0; i < numOfAsteroids; i++)
            {
                rndNum = r.Next(1, 3);

                switch (rndNum)
                {
                    case 1:
                        rnd2 = r.Next(0, screenHeight);
                        rnd1 = r.Next(-100, 0);
                        break;
                    case 2:
                        rnd2 = r.Next(screenHeight, screenHeight + 100);
                        rnd1 = r.Next(0, screenWidth);
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show("oeps");
                        rnd1 = 0;
                        rnd2 = 0;
                        break;
                }
                double speed = r.NextDouble() * 3 * Math.PI;
                System.Threading.Thread.Sleep(1);
                double angle = r.NextDouble() * 2 * Math.PI;
                asteroid.Add(new Asteroid(new Vector2(rnd1, rnd2), r.Next(1, 4), (float)speed, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle))));
            }

            loader = new Loader(this.Content);
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
            mainMenu = new MainMenu(Content, graphics, this);
            intro.Load(Content, graphics);
            oMenu.Load();
            mainMenu.Load(Content, graphicsDevice);
            background = new Background(GraphicsDevice, Content);
            loadingScreen = new LoadingScreen(Content, graphics.GraphicsDevice);
            alien = new Alien(Content.Load<Texture2D>("AlienShip"), new Vector2(50, 100), Vector2.Zero, 0f, 2f, Content.Load<Texture2D>("AlienBullet"));

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

            //Intro 
            if (currentGameState == 1)
            {
                intro.Update();
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    currentGameState = 2;
                }
                else
                {
                    intro.IntroText();
                }
            }

            //MainMenu
            if (currentGameState == 2)
            {
                mainMenu.Update(gameTime, graphicDevice);
                mainMenu.PositionStrings();
                mainMenu.MoveHighscores(gameTime);
                currentGameState = mainMenu.GetCurrentGamestate();

                if (mainMenu.GetExit() == true)
                {
                    this.Exit();
                }
            }

            //Game itself
            if (currentGameState == 3)
            {
                p.Update(gameTime, ch);
                p.CheckBoundries(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                hud.Update(gameTime);
                alien.Update(gameTime);

                foreach (Asteroid a in asteroid)
                {
                    a.Update(gameTime);
                    a.CheckBoundries(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

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

                ////JOOOOO KIJK HIER ENS FF NAR JONGE
                //foreach (BulletAlien b in alien.GetBulletList())
                //{
                //    if (p.GetPlayerHitbox().Intersects(bulletAlien.GetHitBoxBullet()))
                //    {
                //        p.SetLives((p.GetLife() - 1));
                //        //alien.bullets.Remove(bulletAlien);
                //        newAlienBulletList.Add(b);
                //    }
                //}

                //foreach (BulletAlien b in newAlienBulletList)
                //{
                //    alien.GetBulletList().Remove(b);
                //}

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

                //Shooting?
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

            
            //Loading Screen
            if (currentGameState == 8)
            {
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
            }

            base.Update(gameTime);
        }
                    

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            gsm.GameStateChanger(currentGameState);

            switch (currentGameState)
            {
                case 1:
                    //Intro
                        spriteBatch.Begin();
                        background.Draw(spriteBatch);
                        intro.Draw(spriteBatch);
                        spriteBatch.End();                    
                    break;

                case 2:
                    spriteBatch.Begin();
                    background.Draw(spriteBatch);
                    mainMenu.Draw(gameTime, graphics.GraphicsDevice, spriteBatch);
                    spriteBatch.End();
                    currentGameState = mainMenu.GetCurrentGamestate();
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
                    //alien.Draw(spriteBatch);
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
                    if (loadingScreen != null)
                    {
                        spriteBatch.Begin();
                        background.Draw(spriteBatch);
                        loadingScreen.Draw(spriteBatch);
                        spriteBatch.End();
                    }
                    else
                    {
                        currentGameState = 1;
                    }
                    break;
                default:

                    break;
            }

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
