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
using WiimoteLib;

namespace WiimoteTest2015
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        WiimoteHandler wm;
        Rectangle pos = new Rectangle(50, 50, 50, 50);
        Texture2D sShip;


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
            base.Initialize();
            wm = new WiimoteHandler();
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
            sShip = this.Content.Load<Texture2D>("spaceship");
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) || wm.GetButtonsPressed().Contains("Home"))
                this.Exit();
            wm.GetButtonsPressed();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || wm.GetButtonsPressed().Contains("Up"))
                pos.X--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || wm.GetButtonsPressed().Contains("Down"))
                pos.X++;
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || wm.GetButtonsPressed().Contains("Right"))
                pos.Y--;
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || wm.GetButtonsPressed().Contains("Left"))
                pos.Y++;

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
            spriteBatch.Draw(sShip, pos, Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
