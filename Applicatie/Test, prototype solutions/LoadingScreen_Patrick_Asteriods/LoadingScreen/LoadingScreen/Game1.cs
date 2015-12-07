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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Loader loader;
        LoadingScreen loadingScreen;

        public Game1() 
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize() 
        {
            loader = new Loader(this.Content);
            base.Initialize();
        }

        protected override void LoadContent() 
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            loadingScreen = new LoadingScreen(Content, graphics.GraphicsDevice);

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
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin();
                spriteBatch.DrawString(loader.font, "Loading done", new Vector2(200, 200), Color.Black);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}
