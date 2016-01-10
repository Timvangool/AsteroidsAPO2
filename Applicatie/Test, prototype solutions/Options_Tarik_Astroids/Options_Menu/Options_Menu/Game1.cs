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
using System.Threading;

namespace Options_Menu
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    enum GameState
    {
        Menu,
        Options,
        Keybindings
    }

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

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        

        private GameState currentGameState = GameState.Options;
        GraphicsDeviceManager graphics;
        ControlHandler ch;
        OptionsMenu oMenu;
        SpriteBatch spriteBatch;
        StructOptionsMain structOptionsMain;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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
            //graphics.IsFullScreen = true;
            structOptionsMain = new StructOptionsMain();
            ch = new ControlHandler();

            structOptionsMain.Graphics = graphics;
            structOptionsMain.Content = Content;
            structOptionsMain.SpriteBatch = spriteBatch;
            structOptionsMain.SpriteFont = Content.Load<SpriteFont>("MenuFont");
            structOptionsMain.Ch = ch;
            oMenu = new OptionsMenu(structOptionsMain);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 576;
            oMenu.Init();
            

            
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
            switch (currentGameState)
            {
                case GameState.Menu:
                    {
                        break;
                    }
                case GameState.Options:
                    {
                        oMenu.Update(gameTime);
                        break;
                    }
                default:
                    {
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
            switch (currentGameState)
            {
                case GameState.Menu:
                    {
                        GraphicsDevice.Clear(Color.Black);
                        break;
                    }
                case GameState.Options:
                    {
                        oMenu.Draw(spriteBatch);
                        if(oMenu.GetCurrentGameState() == 2)
                        {
                            currentGameState = GameState.Menu;
                        }
                        if (oMenu.GetCurrentGameState() == 5)
                        {
                            currentGameState = GameState.Options;
                        }
                        if (oMenu.GetCurrentGameState() == 7)
                        {
                            currentGameState = GameState.Keybindings;
                        }
                        break;
                    }
                case GameState.Keybindings:
                    {
                        GraphicsDevice.Clear(Color.Yellow);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
