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

        int[] counter = new int[3] {0,0,0};
        string EnterName;
        Vector2 posEnterName;

        string[] Alphabet = new string[26];
        string Name;
        Vector2 posName;
        int[] letter = new int[3] {0, 0, 0};

        Texture2D BtnArrowUp;
        Texture2D BtnArrowDown;
        Rectangle[] recArrowUp = new Rectangle[3];
        Rectangle[] recArrowDown = new Rectangle[3];
        Vector2[] posArrowUp = new Vector2[3];
        Vector2[] posArrowDown = new Vector2[3];
        Vector2 sizeArrows;

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
        int framesPassed;
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

            BtnArrowUp = Content.Load<Texture2D>("ArrowButtonUp");
            BtnArrowDown = Content.Load<Texture2D>("ArrowButtonDown");
            posArrowUp = new Vector2[]
            {
                new Vector2(1.56f,1.55f),
                new Vector2(1.50f,1.55f),
                new Vector2(1.45f,1.55f)
            };
            posArrowDown = new Vector2[]
            {
                new Vector2(1.56f,1.35f),
                new Vector2(1.50f,1.35f),
                new Vector2(1.45f,1.35f)
            };
            sizeArrows = new Vector2(13f, 40f);
            textUpHeader = "Just Another";
            posUpHeader = new Vector2(2.5f, 13f);

            txHeader = Content.Load<Texture2D>("TextGameOver");
            posHeader = new Vector2(3.4f, 7f);
            sizeHeader = new Vector2(220f, 300f);

            textDownHeader = "Screen";
            posDownHeader = new Vector2(2f, 2.2f);

            EnterName = "Enter your name here:";
            posEnterName = new Vector2(5.3f, 1.5f);

            Alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Name = (Alphabet[0] + Alphabet[0] + Alphabet[0]);
            posName = new Vector2(1.55f,1.5f);

            textUpScore = "Your Score:";
            posUpScore = new Vector2(2.5f, 1.7f);
            posScore = new Vector2(1.55f, 1.675f);

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
            posEnterName = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posEnterName.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posEnterName.Y));
            posName = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posName.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posName.Y));

            recHeader = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posHeader.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posHeader.Y), Convert.ToInt32(sizeHeader.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeHeader.Y / 900 * graphics.PreferredBackBufferHeight));
            recMainMenu = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posMainMenu.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posMainMenu.Y), Convert.ToInt32(sizeMainMenu.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeMainMenu.Y / 900 * graphics.PreferredBackBufferHeight));
            recRetry = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posRetry.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posRetry.Y), Convert.ToInt32(sizeRetry.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeRetry.Y / 900 * graphics.PreferredBackBufferHeight));
            for (int i = 0; i < 3; i++)
            {
                recArrowUp[i] = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowUp[i].X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowUp[i].Y), Convert.ToInt32(sizeArrows.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeArrows.Y / 900 * graphics.PreferredBackBufferHeight));
                recArrowDown[i] = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowDown[i].X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowDown[i].Y), Convert.ToInt32(sizeArrows.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeArrows.Y / 900 * graphics.PreferredBackBufferHeight));
            }
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            Point mousePoint = new Point(mouse.X, mouse.Y);
            SelectName(mouse, mousePoint, gameTime);
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
            for (int i = 0; i < 3; i++)
            {
                spriteBatch.Draw(BtnArrowUp, recArrowUp[i], col);
                spriteBatch.Draw(BtnArrowDown, recArrowDown[i], col);
            }
            spriteBatch.DrawString(spriteFont, textDownHeader, posDownHeader, col, 0, new Vector2(0, 0), 0.7f, SpriteEffects.None, 0f); 
            spriteBatch.DrawString(spriteFont, EnterName, posEnterName, col);
            spriteBatch.DrawString(spriteFont, Name, posName, col);
            spriteBatch.DrawString(spriteFont, textUpScore, posUpScore, col);
            spriteBatch.DrawString(spriteFont, textScore, posScore, col, 0, new Vector2(0, 0), 0.85f, SpriteEffects.None, 0f);

            spriteBatch.Draw(txMainMenu, recMainMenu, col);
            spriteBatch.Draw(txRetry, recRetry, col);

        }
        public void OrderName()
        {
            Name = Alphabet[letter[0]] + Alphabet[letter[1]] + Alphabet[letter[2]];
        }
        public void SelectName(MouseState mouse, Point mousePoint, GameTime gameTime)
        {
            framesPassed++;
            if (framesPassed % 7 == 0)
            {
                if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (recArrowDown[i].Contains(mousePoint))
                        {
                            if (letter[i] < 25)
                                letter[i]++;
                            else if (letter[i] == 25)
                                letter[i] = 0;
                        }
                        else if (recArrowUp[i].Contains(mousePoint))
                        {
                            if (letter[i] > 0)
                                    letter[i]--;
                            else if (letter[i] == 0)
                                letter[i] = 25;
                        }
                    }
                }
                if (mouse.LeftButton == ButtonState.Released)
                {
                    mouseReleased = true;
                }
            }
            OrderName();
            framesPassed++;
        }
        public int getGameStateNumber()
        {
            return gameStateNumber;
        }
    }
}
