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
//main solution
namespace Asteroids
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region StructOptionsMain
        public struct StructOptionsMain
        {
            GraphicsDeviceManager _graphics;
            ContentManager _Content;
            SpriteBatch _spriteBatch;
            SpriteFont _spriteFont;
            ControlHandler _ch;

            public GraphicsDeviceManager Graphics
            {
                get
                {
                    return _graphics;
                }

                set
                {
                    _graphics = value;
                }
            }

            public ContentManager Content
            {
                get
                {
                    return _Content;
                }

                set
                {
                    _Content = value;
                }
            }

            public SpriteBatch SpriteBatch
            {
                get
                {
                    return _spriteBatch;
                }

                set
                {
                    _spriteBatch = value;
                }
            }

            public SpriteFont SpriteFont
            {
                get
                {
                    return _spriteFont;
                }

                set
                {
                    _spriteFont = value;
                }
            }

            internal ControlHandler Ch
            {
                get
                {
                    return _ch;
                }

                set
                {
                    _ch = value;
                }
            }
        }
        #endregion

        GraphicsDeviceManager graphics;
        StructOptionsMain structOptionsMain;
        SpriteBatch spriteBatch;
        ControlHandler ch;
        Player p;
        Random r;
        HUD hud;
        Background background;
        OptionsMenu oMenu;
        Loader loader;
        LoadingScreen loadingScreen;
        GameOverMenu gameOverMenu;
        AsteroidsIntro intro;
        KeyBindingsMenu kbm;
        Credit credit;
        MainMenu mainMenu;
        List<Asteroid> asteroidKillList, asteroid, newAsteroidList;
        List<Weapon> killListWep;
        Vector2 dir;
        GamestateManager gsm;
        Highscores scores;
        public static Game1 ExitGame;

        int playerLife;
        int numOfAsteroids;
        int currentGameState;
        int rndNum;
        int rnd1;
        int rnd2;
        int screenHeight;
        int screenWidth;

        // perks

        Pickup pickUp;
        int pickUpIndex, spawnPickup;
        bool drawShield, randomized, intersected;
        Classes.Perks.ShieldPerk shield;
        Classes.Perks.MachineGunPerk machineGun;
        Classes.Perks.SpeedUpPerk speedUp;
        Classes.Perks.ExtraLifePerk extraLife;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            gsm = new GamestateManager();
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 900;
            Content.RootDirectory = "Content";
            ExitGame = this;
            ch = new ControlHandler();
            r = new Random();
            p = new Player(ch);
            scores = new Highscores();

            intro = new AsteroidsIntro();
            credit = new Credit();

            screenHeight = graphics.PreferredBackBufferHeight;
            screenWidth = graphics.PreferredBackBufferWidth;
            drawShield = false;
            intersected = false;
            randomized = false;
            shield = new Classes.Perks.ShieldPerk(Content, p);
            speedUp = new Classes.Perks.SpeedUpPerk(Content, p);
            extraLife = new Classes.Perks.ExtraLifePerk(Content, p);
            machineGun = new Classes.Perks.MachineGunPerk(Content, p);
            hud = new HUD(screenWidth, screenHeight, shield);
            pickUp = new Pickup();

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
            mainMenu = new MainMenu(Content, graphics.GraphicsDevice, ch);
            gameOverMenu = new GameOverMenu(graphics, Content);
            scores.LoadHighScores();
            scores.SortHighScores();

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
                asteroid.Add(new Asteroid(new Vector2(rnd1, rnd2), r.Next(1, 4), (float)speed, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)), Content));
            }

            loader = new Loader(this.Content);
            kbm = new KeyBindingsMenu(graphics, Content, this);
            base.Initialize();
        }

        public void ResetLevel()
        {
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
                asteroid.Add(new Asteroid(new Vector2(rnd1, rnd2), r.Next(1, 4), (float)speed, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)), Content));
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            structOptionsMain = new StructOptionsMain();
            structOptionsMain.Graphics = graphics;
            structOptionsMain.Content = Content;
            structOptionsMain.SpriteBatch = spriteBatch;
            structOptionsMain.SpriteFont = Content.Load<SpriteFont>("MenuFont");
            structOptionsMain.Ch = ch;
            oMenu = new OptionsMenu(structOptionsMain);

            p.Load(Content);
            p.SetPlayerPos(spriteBatch);
            hud.Load(Content);
            intro.Load(Content, graphics);
            credit.Load(Content, graphics);
            oMenu.Init();
            gameOverMenu.Load();
            shield.Load();
            pickUp.Load(Content);
            if (spawnPickup >= 70)
            {
                pickUp.Load(Content);
            }
            machineGun.Load();
            extraLife.Load();

            speedUp.Load();

            mainMenu.Load(graphics.GraphicsDevice, scores);
            background = new Background(GraphicsDevice, Content);
            loadingScreen = new LoadingScreen(Content, graphics.GraphicsDevice);
            kbm.Load();

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
            {
                 this.Exit();
            }
                
            gsm.GameStateChanger(currentGameState);

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

            if (currentGameState == 2)
            {
                mainMenu.Update(gameTime, graphics.GraphicsDevice);
                mainMenu.PositionStrings(graphics.GraphicsDevice);
                if (mainMenu.GetExit() == true)
                {
                    this.Exit();
                }
            }

            if (currentGameState == 3)
            {
                p.Update(gameTime);
                p.CheckBoundries(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                hud.Update(gameTime);

                foreach (Asteroid a in asteroid)
                {
                    a.Update(gameTime);
                    a.CheckBoundries(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

                    if (p.GetPlayerHitbox().Intersects(a.GetAsteroidHitbox()))
                    {
                        if (shield.GetIsActive() == false)
                        {
                            switch (a.GetSize())
                            {
                                case 1:
                                    numOfAsteroids -= 1;
                                    Vector2 temp = new Vector2((float)a.GetXPos(), (float)a.GetYPos());
                                    break;
                                case 2:
                                    numOfAsteroids -= 1;
                                    for (int i = 0; i < 2; i++)
                                    {
                                        double angle = r.NextDouble() * 2 * Math.PI;
                                        newAsteroidList.Add(new Asteroid(new Vector2(a.GetXPos(), a.GetYPos()), 1, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)), Content));
                                        numOfAsteroids += 1;
                                    }
                                    break;
                                case 3:
                                    numOfAsteroids -= 1;
                                    for (int i = 0; i < 2; i++)
                                    {
                                        double angle = r.NextDouble() * 2 * Math.PI;
                                        newAsteroidList.Add(new Asteroid(new Vector2(a.GetXPos(), a.GetYPos()), 2, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)), Content));
                                        numOfAsteroids += 1;
                                    }
                                    break;
                                default:
                                    System.Windows.Forms.MessageBox.Show("Oeps");
                                    break;
                            }
                            a.SetGetHit(true);
                            p.SetGetHit(true);
                            RemovePerk();

                        }
                        else if (shield.GetIsActive())
                        {
                            if (shield.GetHitBox().Intersects(a.GetAsteroidHitbox()))
                            {
                                if (shield.GetIsActive() == true)
                                {
                                    switch (a.GetSize())
                                    {
                                        case 1:
                                            numOfAsteroids -= 1;
                                            Vector2 temp = new Vector2((float)a.GetXPos(), (float)a.GetYPos());
                                            shield.SetShieldLives((shield.GetShieldLives() - 1));
                                            break;
                                        case 2:
                                            numOfAsteroids -= 1;
                                            for (int i = 0; i < 2; i++)
                                            {
                                                double angle = r.NextDouble() * 2 * Math.PI;
                                                newAsteroidList.Add(new Asteroid(new Vector2(a.GetXPos(), a.GetYPos()), 1, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)), Content));
                                                numOfAsteroids += 1;
                                            }
                                            shield.SetShieldLives((shield.GetShieldLives() - 1));
                                            break;
                                        case 3:
                                            numOfAsteroids -= 1;
                                            for (int i = 0; i < 2; i++)
                                            {
                                                double angle = r.NextDouble() * 2 * Math.PI;
                                                newAsteroidList.Add(new Asteroid(new Vector2(a.GetXPos(), a.GetYPos()), 2, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)), Content));
                                                numOfAsteroids += 1;
                                            }
                                            shield.SetShieldLives((shield.GetShieldLives() - 1));
                                            break;
                                        default:
                                            System.Windows.Forms.MessageBox.Show("Oeps");
                                            break;
                                    }
                                    a.SetGetHit(true);
                                    shield.SetIsActive(false);
                                }
                            }
                        }
                    }

                    if (a.GetReadyToKill())
                    {
                        asteroidKillList.Add(a);
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

                    // bullet with asteroid collision

                    foreach (Asteroid a in asteroid)
                    {
                        if (wep.GetHitbox().Intersects(a.GetAsteroidHitbox()))
                        {
                            switch (a.GetSize())
                            {
                                case 1:
                                    killListWep.Add(wep);
                                    hud.SetScore(10);
                                    numOfAsteroids -= 1;
                                    break;
                                case 2:
                                    for (int i = 0; i < 2; i++)
                                    {
                                        double angle = r.NextDouble() * 2 * Math.PI;
                                        newAsteroidList.Add(new Asteroid(new Vector2(a.GetXPos(), a.GetYPos()), 1, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)), Content));
                                        numOfAsteroids += 1;
                                    }
                                    killListWep.Add(wep);
                                    hud.SetScore(25);
                                    break;
                                case 3:
                                    for (int i = 0; i < 2; i++)
                                    {
                                        double angle = r.NextDouble() * 2 * Math.PI;
                                        newAsteroidList.Add(new Asteroid(new Vector2(a.GetXPos(), a.GetYPos()), 2, 3.0f, dir = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)), Content));
                                        numOfAsteroids += 1;
                                    }
                                    killListWep.Add(wep);
                                    hud.SetScore(50);
                                    break;
                                default:

                                    break;
                            }
                            a.SetGetHit(true);
                        }
                    }
                }

                // remove weapon from player

                foreach (Weapon weap in killListWep)
                {
                    p.weapList.Remove(weap);
                }

                // Check for player death

                playerLife = p.GetLife();
                if (playerLife <= 0)
                {
                    currentGameState = 4;
                }

                // perks
                if (spawnPickup >= 0)
                {
                    if (pickUp.GetIsIntersected() == false)
                    {
                        if (p.GetPlayerHitbox().Intersects(pickUp.GetHitbox()))
                        {
                            pickUp.SetIsIntersected(true);

                            switch (pickUp.RandomPerk())
                            {
                                case 0:
                                    intersected = true;
                                    extraLife.Activate();
                                    pickUpIndex = 0;
                                    break;
                                case 1:
                                    intersected = true;
                                    drawShield = true;
                                    shield.SetIsActive(true);
                                    pickUpIndex = 1;
                                    break;
                                case 2:
                                    intersected = true;
                                    speedUp.Activate();
                                    pickUpIndex = 2;
                                    break;
                                case 3:
                                    intersected = true;
                                    machineGun.Activate();
                                    pickUpIndex = 3;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }

            if (currentGameState == 4)
            {
                gameOverMenu.Update(gameTime, hud, scores, ch);
                IsMouseVisible = true;
            }

            if (currentGameState == 5)
            {
                oMenu.Update();
                if (oMenu.GetCurrentGameState() == 2)
                {
                    mainMenu.SetGameState(2);
                    this.currentGameState = 2;
                }
                if (oMenu.GetCurrentGameState() == 5)
                {
                    currentGameState = 5;
                }
                if (oMenu.GetCurrentGameState() == 7)
                {
                    currentGameState = 7;
                }
            }
            if (currentGameState == 7)
            {
                currentGameState = 7;
                if (kbm.GetBackKeyPress())
                {
                    currentGameState = 5;
                }
                kbm.Update();
            }
            //hier zit een bug in < FIXED Thom 11-01-2015
            if (currentGameState == 8)
            {
                if (loadingScreen != null)
                {
                    IsFixedTimeStep = false;
                    loader = loadingScreen.Update();
                    if (loader != null)
                    {
                        currentGameState = 1;
                        IsFixedTimeStep = true;
                    }
                }
            }

            if (currentGameState == 9)
            {
                credit.Update();
                if (Keyboard.GetState().IsKeyDown(Keys.E))
                {
                    mainMenu.SetGameState(2);
                    this.currentGameState = 2;
                }
                else
                {
                    credit.IntroText();
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
                    intro.IntroText();
                    spriteBatch.Begin();
                    background.Draw(spriteBatch);
                    intro.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case 2:
                    //Main Menu
                    spriteBatch.Begin();
                    background.Draw(spriteBatch);
                    mainMenu.Draw(spriteBatch);
                    mainMenu.PositionStrings(graphics.GraphicsDevice);
                    currentGameState = mainMenu.GetCurrentGameState();
                    spriteBatch.End();
                    break;
                case 3:
                    //The Game
                    spriteBatch.Begin();
                    if (randomized)
                    {
                        pickUp.Draw(spriteBatch);
                    }
                    else
                    {
                        if (spawnPickup >= 0)
                        {
                            pickUp.Draw(spriteBatch);

                            if (!randomized)
                            {
                                randomized = true;
                            }
                        }
                    }
                    background.Draw(spriteBatch);
                    foreach (Weapon wep in p.weapList)
                    {
                        wep.Draw(spriteBatch);
                    }
                    foreach (Asteroid a in asteroid)
                    {
                        a.Draw(spriteBatch, Content);
                    }
                    hud.Draw(spriteBatch, p.GetLife());

                    if (pickUpIndex == 0 && pickUp.GetIsIntersected() == true)
                    {
                        extraLife.Draw(spriteBatch);
                    }
                    else if (pickUpIndex == 1 && pickUp.GetIsIntersected() == true)
                    {
                        if (shield.GetIsActive())
                        {
                            shield.Draw(spriteBatch);
                        }
                    }
                    else if (pickUpIndex == 2 && pickUp.GetIsIntersected() == true)
                    {
                        speedUp.Draw(spriteBatch);
                    }
                    else if (pickUpIndex == 3 && pickUp.GetIsIntersected() == true)
                    {
                        machineGun.Draw(spriteBatch);
                    }
                    p.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case 4:
                    //Game Over
                    spriteBatch.Begin();
                    gameOverMenu.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case 5:
                    //Options
                    spriteBatch.Begin();
                    oMenu.Draw(spriteBatch);
                    spriteBatch.End();
                    //currentGameState = oMenu.GetCurrentGameState();
                    break;
                case 6:
                    //Highscores

                    break;
                case 7:
                    //Keybindings
                    spriteBatch.Begin();
                    kbm.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case 8:
                    //Loading Screen
                    spriteBatch.Begin();
                    background.Draw(spriteBatch);
                    loadingScreen.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                case 9:
                    // credits
                    spriteBatch.Begin();
                    background.Draw(spriteBatch);
                    credit.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                default:

                    break;
            }

            base.Draw(gameTime);
        }

        public void LevelsIncrease()
        {
            numOfAsteroids += r.Next(0, 2);
            hud.SetLevel(1);
            ResetPickups();
            ResetLevel();

        }

        public void ResetPickups()
        {
            pickUp = new Classes.Pickup();
            randomized = false;
            spawnPickup = r.Next(0, 100);
            shield.SetShieldLives(1);
            shield.SetIsActive(false);
            p.SetMaxDelay(25);
            pickUp.SetTexture(Content.Load<Texture2D>("PickupItem"));
            p.SetMaxSpeed(3.0f);
            shield.SetElapsedFrames(0);
            machineGun.SetElapsedFrames(0);
            extraLife.SetElapsedFrames(0);
            speedUp.SetElapsedFrames(0);
            //p.SetTexture(Content.Load<Texture2D>("RocketIdle"));
            intersected = false;
        }

        public void RemovePerk()
        {
            randomized = false;
            shield.SetShieldLives(1);
            shield.SetIsActive(false);
            p.SetMaxDelay(25);
            p.SetMaxSpeed(3.0f);
            intersected = false;
            p.SetTexture(Content.Load<Texture2D>("RocketFlying"));
        }


    }
}
