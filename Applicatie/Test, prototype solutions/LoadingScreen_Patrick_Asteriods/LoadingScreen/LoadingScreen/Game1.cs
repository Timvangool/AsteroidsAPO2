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

namespace LoadingScreen
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Thread backgroundThread;
        EventWaitHandle backgroundThreadExit;
        bool loadingIsSlow;
        GameTime loadStartTime;
        int[] bounce;
        bool[] bounceBool;
        string[] letters;

        enum GameState
        {
            Loading,
        }
        private GameState currentGameState = GameState.Loading;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            if (loadingIsSlow)
            {
                backgroundThread = new Thread(BackgroundWorkerThread);
                backgroundThreadExit = new ManualResetEvent(false);
            }
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
            bounce = new int[10];
            bounceBool = new bool[10];
            letters = new string[] { "L", "o", "a", "d", "i", "n", "g", ".", ".", "." };
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

            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (backgroundThread != null)
            {
                loadStartTime = gameTime;
                backgroundThread.Start();
            }

            if (backgroundThread != null)
            {
                backgroundThreadExit.Set();
                backgroundThread.Join();
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

            // TODO: Add your drawing code here
            if (loadingIsSlow == false)
            {
                SpriteFont Font = Content.Load<SpriteFont>("Segoe UI Mono");
                const string message = "Loading...";

                Viewport viewport = GraphicsDevice.Viewport;
                Vector2 viewportSize = new Vector2(viewport.Width, viewport.Height);
                Vector2 textSize = Font.MeasureString(message);
                Vector2 textPosition = (viewportSize - textSize) / 2;

                Color color = Color.White;

                spriteBatch.Begin();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (i > 0)
                    {
                        if (bounceBool[i] == false)
                        {
                            if (bounce[i - 1] > 10)
                            {
                                if (bounce[i] < 20) bounce[i]++;
                                else
                                    bounceBool[i] = true;
                            }
                        }
                        else
                        {
                            if (bounce[i - 1] < 10)
                            {
                                if (bounce[i] > 0) bounce[i]--;
                                else bounceBool[i] = false;
                            }
                        }
                    }
                    else
                    {
                        if (bounceBool[i] == false && bounceBool[i + 1] == false)
                        {
                            if (bounce[i] < 20) bounce[i]++;
                            else if (bounce[9] == 20)
                                bounceBool[i] = true;
                        }
                        else
                        {
                            if (bounce[i] > 0) bounce[i]--;
                            else bounceBool[i] = false;
                        }
                    }

                    spriteBatch.DrawString(Font, letters[i], (textPosition + new Vector2(32 * i, -bounce[i] * 2)), color);
                }
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
        void BackgroundWorkerThread()
        {
            long lastTime = Stopwatch.GetTimestamp();
            while (!backgroundThreadExit.WaitOne(1000 / 30))
            {
                GameTime gameTime = GetGameTime(ref lastTime);

                Draw(gameTime);
            }
        }
        GameTime GetGameTime(ref long lastTime)
        {
            long currentTime = Stopwatch.GetTimestamp();
            long elapsedTicks = currentTime - lastTime;
            lastTime = currentTime;

            TimeSpan elapsedTime = TimeSpan.FromTicks(elapsedTicks *
                TimeSpan.TicksPerSecond / Stopwatch.Frequency);

            return new GameTime(loadStartTime.TotalGameTime + elapsedTime, elapsedTime);
        }
    }
}
