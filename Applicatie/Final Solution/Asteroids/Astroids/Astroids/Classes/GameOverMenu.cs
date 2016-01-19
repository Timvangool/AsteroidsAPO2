using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids.Classes
{
    class GameOverMenu
    {
        GraphicsDeviceManager graphics;
        SpriteFont spriteFont;
        ContentManager Content;
        int gameStateNumber;

        int[] counter = new int[3] { 0, 0, 0 };
        string EnterName;
        Vector2 posEnterName;
        bool selected;
        int frames;
        string[] Alphabet = new string[26];
        string Name;
        Vector2 posName;
        int[] letter = new int[3] { 0, 0, 0 };

        Texture2D BtnArrowUp;
        Texture2D BtnArrowDown;
        Rectangle[] recArrowUp = new Rectangle[3];
        Rectangle[] recArrowDown = new Rectangle[3];
        Vector2[] posArrowUp = new Vector2[3];
        Vector2[] posArrowDown = new Vector2[3];
        Vector2 sizeArrows;

        //string textUpHeader;
        //Vector2 posUpHeader;

        Texture2D txHeader;
        Vector2 posHeader;
        Vector2 sizeHeader;
        Rectangle recHeader;

        //string textDownHeader;
        //Vector2 posDownHeader;

        string textUpScore;
        Vector2 posUpScore;

        string textScore;
        Vector2 posScore;

        string textSucces;
        Vector2 posSucces;
        bool Saved = false;
        int selectedRect;

        Texture2D txMainMenu;
        Vector2 posMainMenu;
        Vector2 sizeMainMenu;
        Rectangle recMainMenu;

        Texture2D txSubmit;
        Vector2 posSubmit;
        Vector2 sizeSubmit;
        Rectangle recSubmit;

        Texture2D txRetry;
        Vector2 posRetry;
        Vector2 sizeRetry;
        Rectangle recRetry;

        Color col;
        int framesPassed;
        bool mouseReleased = true;
        Rectangle[] rectArray;

        public GameOverMenu(GraphicsDeviceManager graphics, ContentManager Content)
        {
            this.graphics = graphics;
            this.Content = Content;
            gameStateNumber = 3;
            frames = 0;
            selectedRect = 0;
        }

        public void Load()
        {
            spriteFont = Content.Load<SpriteFont>("GameOverFont");

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

            //textUpHeader = "Just Another";
            //posUpHeader = new Vector2(2.5f, 13f);

            txHeader = Content.Load<Texture2D>("GameOverText");
            posHeader = new Vector2(3.4f, 7f);
            sizeHeader = new Vector2(220f, 300f);

            //textDownHeader = "Screen";
            //posDownHeader = new Vector2(2f, 2.2f);

            EnterName = "Enter your name here:";
            posEnterName = new Vector2(5.3f, 1.5f);

            Alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            Name = (Alphabet[0] + Alphabet[0] + Alphabet[0]);
            posName = new Vector2(1.55f, 1.5f);

            textUpScore = "Your Score:";
            posUpScore = new Vector2(2.5f, 1.8f);
            posScore = new Vector2(1.55f, 1.775f);

            textSucces = "Saved Succesfully!";
            posSucces = new Vector2(5.5f, 2.05f);

            txSubmit = Content.Load<Texture2D>("BtnSubmit");
            posSubmit = new Vector2(1.35f, 1.5f);
            sizeSubmit = new Vector2(80f, 60f);

            txMainMenu = Content.Load<Texture2D>("BtnMainMenu");
            posMainMenu = new Vector2(2f, 1.2f);
            sizeMainMenu = new Vector2(125f, 80f);

            txRetry = Content.Load<Texture2D>("BtnRetry");
            posRetry = new Vector2(4.5f, 1.2f);
            sizeRetry = new Vector2(125f, 80f);



            col = Color.White;

            //kor
            //posUpHeader = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posUpHeader.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posUpHeader.Y));
            //posDownHeader = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posDownHeader.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posDownHeader.Y));
            posUpScore = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posUpScore.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posUpScore.Y));
            posScore = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posScore.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posScore.Y));
            posEnterName = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posEnterName.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posEnterName.Y));
            posName = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posName.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posName.Y));
            posSucces = new Vector2(Convert.ToInt32(graphics.PreferredBackBufferWidth / posSucces.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posSucces.Y));

            recSubmit = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posSubmit.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posSubmit.Y), Convert.ToInt32(sizeSubmit.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeSubmit.Y / 900 * graphics.PreferredBackBufferHeight));
            recHeader = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posHeader.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posHeader.Y), Convert.ToInt32(sizeHeader.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeHeader.Y / 900 * graphics.PreferredBackBufferHeight));
            recMainMenu = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posMainMenu.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posMainMenu.Y), Convert.ToInt32(sizeMainMenu.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeMainMenu.Y / 900 * graphics.PreferredBackBufferHeight));
            recRetry = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posRetry.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posRetry.Y), Convert.ToInt32(sizeRetry.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeRetry.Y / 900 * graphics.PreferredBackBufferHeight));

            rectArray = new Rectangle[9];
            rectArray[0] = recArrowUp[0];
            rectArray[1] = recArrowDown[0];
            rectArray[2] = recArrowUp[1];
            rectArray[3] = recArrowDown[1];
            rectArray[4] = recArrowUp[2];
            rectArray[5] = recArrowDown[2];
            rectArray[6] = recSubmit;
            rectArray[7] = recRetry;
            rectArray[8] = recMainMenu;
            selectedRect = 0;
            
            for (int i = 0; i < 3; i++)
            {
                recArrowUp[i] = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowUp[i].X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowUp[i].Y), Convert.ToInt32(sizeArrows.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeArrows.Y / 900 * graphics.PreferredBackBufferHeight));
                recArrowDown[i] = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowDown[i].X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowDown[i].Y), Convert.ToInt32(sizeArrows.X / 500 * graphics.PreferredBackBufferWidth), Convert.ToInt32(sizeArrows.Y / 900 * graphics.PreferredBackBufferHeight));
            }
        }

        public void Update(GameTime gameTime, HUD hud, Highscores scores, ControlHandler contHand)
        {
            MouseState mouse = Mouse.GetState();
            Point mousePoint = new Point(mouse.X, mouse.Y);
            textScore = hud.GetScore().ToString();
            SelectName(mouse, mousePoint, gameTime, contHand, scores);
            //Rectangle mouseRec = new Rectangle((int)mouse.X, (int)mouse.Y, 1,1);
            //if (recRetry.Contains(mousePoint))
            //{
            //    if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
            //    {
            //        gameStateNumber = 2;
            //        mouseReleased = false;
            //    }
            //}
            //if (recMainMenu.Contains(mousePoint))
            //{
            //    if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
            //    {
            //        gameStateNumber = 1;
            //        mouseReleased = false;
            //    }
            //}
            //if (recSubmit.Contains(mousePoint))
            //{
            //    if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
            //    {
            //        scores.AddHighscore(hud.GetScore(), Name);
            //        scores.SaveHighScores();
            //        scores.LoadHighScores();
            //        scores.SortHighScores();

            //        mouseReleased = false;
            //    }
            //}
            //if (mouse.LeftButton == ButtonState.Released)
            //{
            //    mouseReleased = true;
            //}
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.DrawString(spriteFont, textUpHeader, posUpHeader, col);
            spriteBatch.Draw(txHeader, recHeader, col);
            //spriteBatch.DrawString(spriteFont, textDownHeader, posDownHeader, col, 0, new Vector2(0, 0), 0.7f, SpriteEffects.None, 0f);

            spriteBatch.DrawString(spriteFont, textScore, posScore, col, 0, new Vector2(0, 0), 0.85f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(spriteFont, EnterName, posEnterName, col);
            spriteBatch.DrawString(spriteFont, Name, posName, col);
            spriteBatch.DrawString(spriteFont, textUpScore, posUpScore, col);
            if (Saved == true)
            {
                spriteBatch.DrawString(spriteFont, textSucces, posSucces, col);
                spriteBatch.Draw(txSubmit, recSubmit, Color.Gray);
                for (int i = 0; i < 3; i++)
                {
                    spriteBatch.Draw(BtnArrowUp, recArrowUp[i], Color.Gray);
                    spriteBatch.Draw(BtnArrowDown, recArrowDown[i], Color.Gray);
                }
            }
            else
            {
                spriteBatch.Draw(txSubmit, recSubmit, col);
                for (int i = 0; i < 3; i++)
                {
                    spriteBatch.Draw(BtnArrowUp, recArrowUp[i], col);
                    spriteBatch.Draw(BtnArrowDown, recArrowDown[i], col);
                }
            }
            spriteBatch.Draw(txMainMenu, recMainMenu, col);
            spriteBatch.Draw(txRetry, recRetry, col);

        }
        public void OrderName()
        {
            Name = Alphabet[letter[0]] + Alphabet[letter[1]] + Alphabet[letter[2]];
        }
        public void SelectName(MouseState mouse, Point mousePoint, GameTime gameTime, ControlHandler contHand, Highscores scores)
        {
            if (selectedRect >= 8)
            {
                selectedRect = 8;
            }
            if (selectedRect <= 0)
            {
                selectedRect = 0;
            }

            if (frames > 60)
            {
                if (contHand.GetInput().Contains("Right"))
                {
                    selectedRect++;
                }
                if (contHand.GetInput().Contains("Left"))
                {
                    selectedRect--;
                }

                if (contHand.GetInput().Contains("Select"))
                {
                    System.Threading.Thread.Sleep(100);
                    switch (selectedRect)
                    {
                        case 0:
                            if (letter[0] < 25)
                                letter[0]++;
                            else if (letter[0] == 25)
                                letter[0] = 0;
                            break;
                        case 1:
                            if (letter[0] > 0)
                                letter[0]--;
                            else if (letter[0] == 0)
                                letter[0] = 25;
                            break;
                        case 2:
                            if (letter[1] < 25)
                                letter[1]++;
                            else if (letter[1] == 25)
                                letter[1] = 0;
                            break;
                        case 3:
                            if (letter[1] > 0)
                                letter[1]--;
                            else if (letter[1] == 0)
                                letter[1] = 25;
                            break;
                        case 4:
                            if (letter[2] < 25)
                                letter[2]++;
                            else if (letter[1] == 25)
                                letter[2] = 0;
                            break;
                        case 5:
                            if (letter[2] > 0)
                                letter[2]--;
                            else if (letter[2] == 0)
                                letter[2] = 25;
                            break;
                        case 6:
                            scores.AddHighscore(Convert.ToInt32(textScore), Name);
                            scores.SaveHighScores();
                            scores.LoadHighScores();
                            scores.SortHighScores();
                            Saved = true;
                            break;
                        case 7:
                            gameStateNumber = 3;
                            break;
                        case 8:
                            gameStateNumber = 2;
                            break;
                        default:
                            break;
                    }
                }
                frames = 0;
            }
            frames++;

            //if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true && Saved != true)
            //{
            //    framesPassed++;
            //    if (framesPassed % 7 == 0)
            //    {
            //        for (int i = 0; i < 3; i++)
            //        {
            //            if (recArrowDown[i].Contains(mousePoint))
            //            {
            //                if (letter[i] < 25)
            //                    letter[i]++;
            //                else if (letter[i] == 25)
            //                    letter[i] = 0;
            //            }
            //            else if (recArrowUp[i].Contains(mousePoint))
            //            {
            //                if (letter[i] > 0)
            //                    letter[i]--;
            //                else if (letter[i] == 0)
            //                    letter[i] = 25;
            //            }
            //        }
            //    }
            //    if (recSubmit.Contains(mousePoint))
            //    {
            //        if (Name == "AAA")
            //        {
            //            textSucces = "Very creative...Saved Succesful!";
            //        }
            //        Saved = true;
            //    }
            //}
            //if (mouse.LeftButton == ButtonState.Released)
            //{
            //    mouseReleased = true;
            //}
            OrderName();
            framesPassed++;
        }
        public int getGameStateNumber()
        {
            return gameStateNumber;
        }
    }
}
