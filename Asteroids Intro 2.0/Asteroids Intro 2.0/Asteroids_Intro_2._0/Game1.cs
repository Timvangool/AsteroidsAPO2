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

namespace Asteroids_Intro_2._0
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        ////properties UserCharacter
        //// Vector2 pos = new Vector2(300,150);
        //Vector2 speed = new Vector2(0.5f, 0.5f);
        //Vector2 origin;
        //Vector2 screenpos;
        //Vector2 direction;
        //float rotationAngle;
        //Texture2D T2D;

        ////Properties Enemy;
        //Vector2 speedEnemy = new Vector2(0.5f, 0.5f);
        //Vector2 originEnemy;
        //Vector2 screenposEnemy;
        //Vector2 directionEnemy;
        //float rotationAngleEnemy;
        //Texture2D EnemySprite;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        string output;
        string title;
        SoundEffect soundEffect;

        ////Font Properties
        SpriteFont fontType;
        Vector2 fontPos;
        Vector2 fontPosTitle;
        Vector2 fontOriginTitle;
        Vector2 fontOrigin;

        //Starfield Back Ground
        Texture2D txBackground;
        Vector2 posBackground;
        Vector2 sizeBackground;
        Rectangle recBackground;


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
        /// 
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
            fontType = Content.Load<SpriteFont>("Courier New"); 

            //soundEffect = Content.Load<SoundEffect>("John Williams - Star Wars Main Theme (FULL)");
            //soundEffect.Play();
            // TODO: use this.Content to load your game content here
            
            //Background
            txBackground = Content.Load<Texture2D>("starfield");
            posBackground = new Vector2(2.0f, 2.0f);
            sizeBackground = new Vector2(20.0f, 20.0f);
            recBackground = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            
            //Text
            fontOriginTitle.Y = -270f;
            fontOriginTitle.X = graphics.GraphicsDevice.Viewport.Width / 3;

            fontOrigin.Y = -300f;
            fontOrigin.X = graphics.GraphicsDevice.Viewport.Width / 2.6f;
            fontPosTitle = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                graphics.GraphicsDevice.Viewport.Height / 2);
            fontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                graphics.GraphicsDevice.Viewport.Height / 2);

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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            
            // TODO: Add your update logic here

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                this.Exit();
            }
            else
            {
                title = "JUST ANOTHER ASTEROIDS GAME";
                fontPosTitle.Y -= 0.5f;
                fontPos.Y -= 0.5f;

                output = @"
A long time ago in a galaxy 
far, far away....

There was a 2nd Corporal Space 
Meteor Destroyer called Dimitri.
He Ascended from Spacestation.
He had a normal life and a 
normal job.
Until the station got attacked
by aliens.
The Spacestation slowly got
destroyed.
But Dimitri barely escaped
from the station in a Small
Space Ship.
Now Dimitri is on his way
to another Space Staion/Planet
in search for safety.

Will he survive the dangers
of outerspace?

And will he ever see 
civilisation again?





















You're still waiting right








Did you try to press the 
Spacebar?


You just Tried that didnt you......


Ok, I give you a hint....
It's not the Esc button!!

90% of the people who played
this game experienced the power
of Esc.

The Other 10% are smart 
enough not to listen to some
Text that appears in their
screen.



Congratulations!!!
You've endured the Waiting
Exam!!!!

You are now ready to play a
game full of awesomeness
and Spaceness

Goodluck, we'll see you on 
the other side.




System Message: 
The key to exit this video 
is to press E
";
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

            //Draw Background

            //Draw Text
            //creating Hello World!
            
            
            

            //Draw
            spriteBatch.Begin();
            //Draw Background
            spriteBatch.Draw(txBackground, recBackground, Color.White);
            //Draw String
            spriteBatch.DrawString(fontType, title, fontPosTitle, Color.Yellow, 0, fontOriginTitle, 1.0f, SpriteEffects.None, 0.65f);
            spriteBatch.DrawString(fontType, output, fontPos, Color.Yellow, 0, fontOrigin, 1.0f, SpriteEffects.None, 0.65f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
//OldCode

