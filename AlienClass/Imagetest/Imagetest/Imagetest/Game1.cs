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

namespace Imagetest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Random rng = new Random();
        GameTime time = new GameTime();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Alien alien;

        
        //Rocket
        Vector2 rocketPosition = new Vector2(250, 250);
        Vector2 rocketOrigin = new Vector2(0, 0);
        Vector2 bulletPosition = new Vector2(0, 0);
        Vector2 bulletDirection = new Vector2(0, 0);
        Vector2 spriteVelocity;
        Texture2D Rocket;

        float rotation;
        float friction = 0.025f;
        bool idle = true;

        
        const float tangentialVelocity = 5f;

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
            Rocket = this.Content.Load<Texture2D>("RocketIdle");
            alien = new Alien(Content.Load<Texture2D>("AlienShip"), new Vector2(50, 100), Vector2.Zero, 0f, 2f, Content.Load<Texture2D>("AlienBullet"));
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
            alien.Update(gameTime);
            // Allows the game to exit
            //00:00:00
            //Time = gameTime.ElapsedGameTime.Seconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            Rectangle rect = new Rectangle((int)rocketPosition.X, (int)rocketPosition.Y, Rocket.Width, Rocket.Height);
            rocketOrigin = new Vector2(rect.Width / 2, rect.Height / 2);
            rocketPosition = spriteVelocity + rocketPosition;
            rocketmovement();
            RocketAnimation();
            

            //Screenside teleport rocket
            if (rocketPosition.X >= GraphicsDevice.Viewport.Width)
                rocketPosition.X = 0;

            else if (rocketPosition.X <= 0)
                rocketPosition.X = GraphicsDevice.Viewport.Width;

            if (rocketPosition.Y >= GraphicsDevice.Viewport.Height)
                rocketPosition.Y = 0;

            else if (rocketPosition.Y <= 0)
                rocketPosition.Y = GraphicsDevice.Viewport.Height;
            bulletPosition.X += 1;
            ////screenside teleport alien
            //if (alienPosition.X >= GraphicsDevice.Viewport.Width)
            //    alienPosition.X = 0;

            //else if (alienPosition.X <= 0)
            //    alienPosition.X = GraphicsDevice.Viewport.Width;

            //if (alienPosition.Y >= GraphicsDevice.Viewport.Height)
            //    alienPosition.Y = 0;

            //else if (alienPosition.Y <= 0)
            //    alienPosition.Y = GraphicsDevice.Viewport.Height;

            
        

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        public void rocketmovement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                rotation -= 0.05f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                rotation += 0.05f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                spriteVelocity.X = (float)Math.Cos(rotation) * tangentialVelocity;
                spriteVelocity.Y = (float)Math.Sin(rotation) * tangentialVelocity;
                idle = false;
            }
            
            else if (spriteVelocity != Vector2.Zero)
            {
                idle = true;
                Vector2 i = spriteVelocity;
                spriteVelocity = i -= friction * i; 
            }
        }
        public void RocketAnimation()
        {
            if (idle == true)
            {
                Rocket = this.Content.Load<Texture2D>("RocketIdle");
            }
            else if (idle == false)
            {
                Rocket = this.Content.Load<Texture2D>("RocketFlying");
            }
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(Rocket, rocketPosition, null, Color.White, rotation, rocketOrigin, 1f, SpriteEffects.None,0);
            alien.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
