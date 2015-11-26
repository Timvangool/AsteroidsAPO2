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
using Astroids.Classes;

namespace Astroids
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player p;
        Random r;
        HUD hud;
        List<Astroid> a;
        
        int numbOfAstroids;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 900;
            numbOfAstroids = 10;
            Content.RootDirectory = "Content";
            r = new Random();
            p = new Player();
            a = new List<Astroid>(numbOfAstroids);
            hud = new HUD();
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

            for (int i = 0; i < numbOfAstroids; i++)
            {
                a.Add(new Astroid(r.Next(1, GraphicsDevice.Viewport.Width), r.Next(1, GraphicsDevice.Viewport.Height), r.Next(1, 4), r.Next(1, 4)));
            }

            p.Load(Content);
            hud.Load(Content);
            foreach(Astroid ast in a)
            {
                ast.Load(Content);
            }

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

            p.Update(gameTime);
            p.CheckBoundries(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            hud.Update(gameTime);

            List<Astroid> killListAst = new List<Astroid>();
            List<Weapon> killListWep = new List<Weapon>();
            foreach (Astroid ast in a)
            {
                ast.Update(gameTime);
                ast.CheckBoundries(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                if (p.GetPlayerHitbox().Intersects(ast.GetHitbox()))
                {
                    p.SetLives((p.GetLife() - 1));
                    ast.SetIsVisable(false);
                    if (ast.GetIsVisable() == false)
                    {
                        killListAst.Add(ast);
                    }
                }
            }

            foreach (Weapon wep in p.weapList)
            {
                wep.Update(gameTime, wep.GetDirection());
                wep.CheckBoundries(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

                if (wep.GetFadeTime() == 0)
                {
                    wep.SetIsVisable(false);
                    killListWep.Add(wep);
                }

                foreach (Astroid ast in a)
                {
                    if(wep.GetHitbox().Intersects(ast.GetHitbox()))
                    {
                        ast.SetIsVisable(false);
                        wep.SetIsVisable(false);
                        hud.SetScore(10);
                        if (ast.GetIsVisable() == false)
                        {
                            killListAst.Add(ast);
                            killListWep.Add(wep);
                        }
                    }
                }
            }

            foreach (Astroid astr in killListAst)
            {
                a.Remove(astr);
            }

            foreach (Weapon weap in killListWep)
            {
                p.weapList.Remove(weap);
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

            spriteBatch.Begin();
            hud.Draw(spriteBatch, p.GetLife());
            foreach (Astroid ast in a)
            {
                ast.Draw(spriteBatch);
            }
            foreach (Weapon wep in p.weapList)
            {
                wep.Draw(spriteBatch);
            }
            p.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
