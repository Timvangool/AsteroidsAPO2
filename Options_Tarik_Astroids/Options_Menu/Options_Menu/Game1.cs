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

namespace Options_Menu
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        enum GameState
        {
            Menu,
            Options
        }
        private GameState currentGameState = GameState.Options;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Song song;

        TResolutionOption tResolution;
        Texture2D txResolutionBar;
        Texture2D txArrowLeft;
        Texture2D txArrowRight;
        Vector2 posArrowLeft;
        Vector2 posArrowRight;
        Vector2 posResolutionBar;
        Vector2 sizeArrow;
        Vector2 sizeResolutionBar;

        TCheckBoxOption cbAlias;
        Texture2D checkedBox;
        Texture2D unCheckedBox;
        Vector2 posCheckBoxLeft;
        Vector2 posCheckBoxRight;
        Vector2 vecSizeCheckBox;
        bool stateCheckBox = true;

        TSoundOption tSound;
        Texture2D txSoundBar;
        Texture2D txSoundBarCursor;
        Vector2 posSoundBar;
        Vector2 posSoundBarCursor;
        Vector2 sizeSoundBar;
        Vector2 sizeSoundBarCursor;

        OptionsText oText;
        Texture2D txBackground;
        Texture2D txBack;
        string textHeader;
        string textSound;
        string textResolution;
        string textAlias;
        string textAliasOn;
        string textAliasOff;
        Vector2 posBack;
        Vector2 posHeader;
        Vector2 posSound;
        Vector2 posResolution;
        Vector2 posAlias;
        Vector2 posAliasOn;
        Vector2 posAliasOff;
        Vector2 sizeBack;

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
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            graphics.PreferMultiSampling = stateCheckBox;
            graphics.ApplyChanges();

            song = Content.Load<Song>("Ismo_Kan_Niet_Hangen_Met_Je");
            MediaPlayer.Play(song);
            MediaPlayer.Volume = 1f;
            spriteFont = Content.Load<SpriteFont>("MenuFont");

            txSoundBar = Content.Load<Texture2D>("SoundBar");
            txSoundBarCursor = Content.Load<Texture2D>("SoundBarCursor");
            txArrowLeft = Content.Load<Texture2D>("ArrowLeft");
            txArrowRight = Content.Load<Texture2D>("ArrowRight");
            posSoundBar = new Vector2(2.35f, 3f);
            posSoundBarCursor = new Vector2(1.77f, 3.17f);
            posArrowLeft = new Vector2(2.64f, 3.17f);
            posArrowRight = new Vector2(1.67f, 3.17f);
            sizeArrow = new Vector2(43, 35);
            sizeSoundBar = new Vector2(204, 10);
            sizeSoundBarCursor = new Vector2(22, 35);
            tSound = new TSoundOption(graphics, txSoundBar, txSoundBarCursor, txArrowLeft, txArrowRight, posSoundBar, sizeSoundBar, sizeSoundBarCursor, posArrowLeft, posArrowRight, sizeArrow, Color.White);

            txResolutionBar = Content.Load<Texture2D>("ResolutionBar");
            txArrowLeft = Content.Load<Texture2D>("ArrowLeft");
            txArrowRight = Content.Load<Texture2D>("ArrowRight");
            posArrowLeft = new Vector2(2.64f, 2.5f);
            posArrowRight = new Vector2(1.67f, 2.5f);
            posResolutionBar = new Vector2(2.4f, 2.5f);
            sizeArrow = new Vector2(43, 35);
            sizeResolutionBar = new Vector2(229, 35);
            tResolution = new TResolutionOption(graphics, txResolutionBar, txArrowLeft, txArrowRight, posResolutionBar, sizeResolutionBar, posArrowLeft, posArrowRight, sizeArrow, Color.White);

            checkedBox = Content.Load<Texture2D>("CheckboxTrue");
            unCheckedBox = Content.Load<Texture2D>("CheckboxFalse");
            posCheckBoxLeft = new Vector2(2.63f, 2);
            posCheckBoxRight = new Vector2(1.79f, 2);
            vecSizeCheckBox = new Vector2(35, 35);
            cbAlias = new TCheckBoxOption(graphics, checkedBox, unCheckedBox, posCheckBoxLeft, posCheckBoxRight, vecSizeCheckBox, stateCheckBox, Color.White);

            txBackground = Content.Load<Texture2D>("OptionsBG");
            txBack = Content.Load<Texture2D>("Back");
            textHeader = "JUST ANOTHER OPTIONS MENU";
            textSound = "SOUND";
            textResolution = "RESOLUTION";
            textAlias = "ANTI ALIASING";
            textAliasOn = "ON";
            textAliasOff = "OFF";
            posBack = new Vector2(2.4f, 1.7f);
            posHeader = new Vector2(3f, 5f);
            posSound = new Vector2(3.51f, 3.2f);
            posResolution = new Vector2(4.4f, 2.5f);
            posAlias = new Vector2(5.1f, 2f);
            posAliasOn = new Vector2(2.41f, 2f);
            posAliasOff = new Vector2(1.69f, 2f);
            sizeBack = new Vector2(65, 20);
            oText = new OptionsText(graphics, txBackground, txBack, posBack, sizeBack, spriteFont, textHeader, posHeader, textSound, posSound, textResolution, posResolution, textAlias, posAlias, textAliasOn, posAliasOn, textAliasOff, posAliasOff, Color.White);
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
                        if (tResolution.GetResolutionChanged())
                        {
                            tResolution.Init();
                            tSound.Init();
                            cbAlias.Init();
                            oText.Init();
                        }
                        MouseState mouse = Mouse.GetState();
                        cbAlias.Update(mouse);
                        tResolution.Update(mouse);
                        tSound.Update(mouse);
                        if (oText.Update(mouse))
                        {
                            currentGameState = GameState.Menu;
                        }
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
                        break;
                    }
                case GameState.Options:
                    {
                        oText.Draw(spriteBatch);
                        cbAlias.Draw(spriteBatch);
                        tResolution.Draw(spriteBatch, spriteFont);
                        tSound.Draw(spriteBatch);
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
