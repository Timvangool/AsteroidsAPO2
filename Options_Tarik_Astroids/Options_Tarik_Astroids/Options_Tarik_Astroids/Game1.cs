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

namespace Options_Tarik_Astroids
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        enum GameState
        {
            Options
        }
        private GameState currentGameState = GameState.Options;
        //Screen Adjustments
        int screenHeight = 1920, screenWidth = 1080;

        Tool_CheckBox tCheckBox;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //private Texture2D cbAliasOn;
        //private Texture2D cbAliasOff;
        //private Vector2 cbAliasOnPosition;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            //cbAliasOnPosition = new Vector2((GraphicsDevice.Viewport.Width / 2) - 40, 300);
            //size = new 
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
            this.IsMouseVisible = true;
            //cbAliasOn = Content.Load<Texture2D>(@"checkbox_icon_checked");
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            tCheckBox = new Tool_CheckBox(Content.Load<Texture2D>("checkbox_icon_checked"), graphics.GraphicsDevice);
            tCheckBox.setPosition(new Vector2(50, 50));
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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //{
            //    this.Exit();
            //}


            // TODO: Add your update logic here
            MouseState mouse = Mouse.GetState();
            switch (currentGameState)
            {
                case GameState.Options:
                    {
                        if (tCheckBox.isClicked == true)
                        {
                            tCheckBox.Update(mouse);
                        }
                        break;
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //draw the start menu
            switch (currentGameState)
            {
                case GameState.Options:
                    {
                        tCheckBox.Draw(spriteBatch);
                        //spriteBatch.Draw(Content.Load<Texture2D>("OptionsBG"), new Rectangle(0, 0, screenHeight, screenHeight), Color.White);
                        break;
                    }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}