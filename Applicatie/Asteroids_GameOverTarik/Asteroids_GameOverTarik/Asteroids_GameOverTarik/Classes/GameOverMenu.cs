using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids_GameOverTarik
{
    class GameOverMenu
    {
        GraphicsDeviceManager graphics;
        SpriteFont spriteFont;
        ContentManager Content;
        int gameStateNumber;

        string textUpHeader;
        Vector2 posUpHeader;

        Texture2D txHeader;
        Vector2 posHeader;
        Vector2 sizeHeader;
        Rectangle recHeader;

        string textDownHeader;
        Vector2 posDownHeader;

        string textUpScore;
        Vector2 posUpScore;

        string textScore;
        Vector2 posScore;

        Texture2D txMainMenu;
        Vector2 posMainMenu;
        Vector2 sizeMainMenu;
        Rectangle recMainMenu;

        Texture2D txRetry;
        Vector2 posRetry;
        Vector2 sizeRetry;
        Rectangle recRetry;

        Color col;

        bool mouseReleased = true;

        public GameOverMenu(GraphicsDeviceManager graphics, ContentManager Content, string textScore)
        {
            this.graphics = graphics;
            this.Content = Content;
            this.textScore = textScore;
            gameStateNumber = 3;

        }

        public void Load()
        {
            spriteFont = Content.Load<SpriteFont>("MenuFont");

            textUpHeader = "Just Another";
            posUpHeader = new Vector2(2.5f, 13f);

            txHeader = Content.Load<Texture2D>("TextGameOver");
            posHeader = new Vector2(3.4f, 7f);
            sizeHeader = new Vector2(220f, 300f);

            textDownHeader = "Screen";
            posDownHeader = new Vector2(2f, 2.2f);

            textUpScore = "Your Score:";
            posUpScore = new Vector2(2.5f, 1.7f);

            posScore = new Vector2(2.5f, 1.5f);

            txMainMenu = Content.Load<Texture2D>("BtnMainMenu");
            posMainMenu = new Vector2(2f, 1.2f);
            sizeMainMenu = new Vector2(125f, 80f);

            txRetry = Content.Load<Texture2D>("BtnRetry");
            posRetry = new Vector2(4.5f, 1.2f);
            sizeRetry = new Vector2(125f, 80f);

            col = Color.White;

            //kor
            posUpHeader = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posUpHeader.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posUpHeader.Y));
            posDownHeader = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posDownHeader.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posDownHeader.Y));
            posUpScore = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posUpScore.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posUpScore.Y));
            posScore = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posScore.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posScore.Y));

            recHeader = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posHeader.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posHeader.Y), Convert.ToInt32(sizeHeader.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeHeader.Y / 900 * graphics.PreferredBackBufferHeight));
            recMainMenu = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posMainMenu.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posMainMenu.Y), Convert.ToInt32(sizeMainMenu.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeMainMenu.Y / 900 * graphics.PreferredBackBufferHeight));
            recRetry = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posRetry.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posRetry.Y), Convert.ToInt32(sizeRetry.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeRetry.Y / 900 * graphics.PreferredBackBufferHeight));
            //recRetry = new Rectangle(400, 400, 5, txRetry.Height);
        }

        public void Update()
        {

            MouseState mouse = Mouse.GetState();
            Point mousePoint = new Point(mouse.X, mouse.Y);
            //Rectangle mouseRec = new Rectangle((int)mouse.X, (int)mouse.Y, 1,1);
            if (recRetry.Contains(mousePoint))
            {
                if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
                {
                    gameStateNumber = 2;
                    mouseReleased = false;
                }

            }
            if (recMainMenu.Contains(mousePoint))
            {
                if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
                {
                    gameStateNumber = 1;
                    mouseReleased = false;
                }

            }
            if (mouse.LeftButton == ButtonState.Released)
            {
                mouseReleased = true;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(spriteFont, textUpHeader, posUpHeader, col);
            spriteBatch.Draw(txHeader, recHeader, col);
            spriteBatch.DrawString(spriteFont, textDownHeader, posDownHeader, col, 0, new Vector2(0, 0), 0.7f, SpriteEffects.None, 0f);

            spriteBatch.DrawString(spriteFont, textUpScore, posUpScore, col);
            spriteBatch.DrawString(spriteFont, textScore, posScore, col, 0, new Vector2(0, 0), 0.85f, SpriteEffects.None, 0f);

            spriteBatch.Draw(txMainMenu, recMainMenu, col);
            spriteBatch.Draw(txRetry, recRetry, col);

        }

        public int getGameStateNumber()
        {
            return gameStateNumber;
        }
    }
}
