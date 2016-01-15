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

//new from taric
namespace Asteroids.Classes
{
    class MainMenu
    {
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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        StructOptionsMain structOptionsMain;
        ContentManager Content;
        Background background;
        //Control Classes
        ControlHandler ch;

        //strings Main Menu
        string txtPlay = "Play",
            txtOptions = "Options",
            txtHighscores = "Highscores",
            txtCredits = "Credits",
            txtExit = "Exit",
            txtTitleTop = "Just Another",
            txtTitleMiddle = "ASTEROIDS",
            txtTitleBottom = "game";

        //Top 10 HighscoreBox
        SpriteFont fontHighscores, fontTitle, fontMenu;
        GameTime gameTime;
        Vector2 posHighscoreBoard;
        Vector2 velocityHighscores;
        List<Highscores> scoreList;
        string[] highscores;
        string highscoreBoard;
        int[] highscoreCounter;


        //Tarik Code
        Texture2D txSelectArrow;
        Vector2 posSelectArrow;
        Vector2 sizeSelectArrow;
        Rectangle recSelectArrow;
        int framesPassed, currentGameState, selectedNumber, selectState;
        bool exit = false;



        //Font Properties
        SpriteFont fontType, fontTypeTitle;

        //Properties String Positions
        Vector2 posPlay, posOptions, posHighscores, posCredits, posExit, posTitleTop, posTitleMiddle, posTitleBottom;
        Vector2 posOriginPlay, posOriginOptions, posOriginHighscores, posOriginCredits, posOriginExit, posOriginTitleTop, posOriginTitleMiddle, posOriginTitleBottom;

        public MainMenu(ContentManager Content, GraphicsDevice graphicsDevice, ControlHandler ch)
        {
            this.Content = Content;
            this.ch = ch;
            background = new Background(graphicsDevice, Content);
            sizeSelectArrow = new Vector2(graphicsDevice.Viewport.Width / 900 * 30, graphicsDevice.Viewport.Height / 500 * 30);
            posSelectArrow = new Vector2(4.5f, 2.6f);
            recSelectArrow = new Rectangle(graphicsDevice.Viewport.Width / (int)posSelectArrow.X, graphicsDevice.Viewport.Height / (int)posSelectArrow.Y, (int)sizeSelectArrow.X, (int)sizeSelectArrow.Y);

            framesPassed = 0;
            selectedNumber = 0;
            currentGameState = 2;
        }

        public void Load(GraphicsDevice graphicsDevice, Highscores scores)
        {
            spriteBatch = new SpriteBatch(graphicsDevice);

            //FontType
            txSelectArrow = Content.Load<Texture2D>("SelectArrow");
            fontType = Content.Load<SpriteFont>("Courier New");
            fontTypeTitle = Content.Load<SpriteFont>("Courier New");

            fontHighscores = Content.Load<SpriteFont>("HighScores");
            velocityHighscores = new Vector2(2f, 2f);
            scoreList = scores.highscores;
            highscores = new string[10];
            highscoreCounter = new int[10];
            for (int i = 0; i < scoreList.Count; i++)
            {
                if (scoreList[i].Name != null)
                {
                    highscores[i] = scoreList[i].Name;
                    highscoreCounter[i] = scoreList[i].Score;
                }
                else
                {
                    highscores[i] = "Empty";
                    highscoreCounter[i] = 0;
                }
            }
        }

        public void UpdateSelect(int number, GraphicsDevice graphicsDevice)
        {
            selectState = number;
            float newPos = posSelectArrow.Y;
            int newPosInt;
            int graphicsH = graphicsDevice.Viewport.Height;
            int graphicsW = graphicsDevice.Viewport.Width;
            switch (number)
            {
                case 0:
                    {
                        newPos = graphicsH / posSelectArrow.Y;
                        break;
                    }
                case 1:
                    {
                        newPos = graphicsH / (posSelectArrow.Y - 0.35f);
                        break;
                    }
                case 2:
                    {
                        newPos = graphicsH / (posSelectArrow.Y - 0.70f);
                        break;
                    }
                case 3:
                    {
                        newPos = graphicsH / (posSelectArrow.Y - 0.95f);
                        break;
                    }
                case 4:
                    {
                        newPos = graphicsH / (posSelectArrow.Y - 1.07f);
                        break;
                    }
                default:
                    {
                        newPos = graphicsH / posSelectArrow.Y;
                        break;
                    }
            }
            newPosInt = Convert.ToInt32(newPos);
            recSelectArrow = new Rectangle(graphicsW / (int)posSelectArrow.X, newPosInt, (int)sizeSelectArrow.X, (int)sizeSelectArrow.Y);
        }

        public void Update(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            //Keybindings
            framesPassed++;
            if (framesPassed % 7 == 0)
            {
                if (ch.GetInput().Contains("Up"))
                {
                    if (selectedNumber > 0)
                    {
                        selectedNumber--;
                        switch (selectedNumber)
                        {
                            case 0:
                                {
                                    UpdateSelect(0, graphicsDevice);

                                    break;
                                }
                            case 1:
                                {
                                    UpdateSelect(1, graphicsDevice);
                                    break;
                                }
                            case 2:
                                {
                                    UpdateSelect(2, graphicsDevice);
                                    break;
                                }
                            case 3:
                                {
                                    UpdateSelect(3, graphicsDevice);
                                    break;
                                }
                            case 4:
                                {
                                    UpdateSelect(4, graphicsDevice);
                                    break;
                                }
                        }
                    }
                }
                else if (ch.GetInput().Contains("Down"))
                {
                    if (selectedNumber < 4)
                    {
                        selectedNumber++;
                        switch (selectedNumber)
                        {
                            case 0:
                                {
                                    UpdateSelect(0, graphicsDevice);
                                    break;
                                }
                            case 1:
                                {
                                    UpdateSelect(1, graphicsDevice);
                                    break;
                                }
                            case 2:
                                {
                                    UpdateSelect(2, graphicsDevice);
                                    break;
                                }
                            case 3:
                                {
                                    UpdateSelect(3, graphicsDevice);
                                    break;
                                }
                            case 4:
                                {
                                    UpdateSelect(4, graphicsDevice);
                                    break;
                                }
                        }
                    }
                }
                else if (ch.GetInput().Contains("Select"))
                {
                    switch (selectState)
                    {
                        case 0:
                            {
                                currentGameState = 3;
                                break;
                            }
                        case 1:
                            {
                                currentGameState = 5;
                                break;
                            }
                        case 2:
                            {
                                currentGameState = 6;
                                break;
                            }
                        case 3:
                            {
                                currentGameState = 9;
                                break;
                            }
                        case 4:
                            {
                                exit = true;
                                break;
                            }
                    }
                }
                else if (ch.GetInput().Contains("Back"))
                {
                    exit = true;
                }
                framesPassed++;
            }
            //Highscores
            highscoreBoard = string.Format("TOP 10 PLAYERS \n1. {0} - {1} \n2. {2} - {3}\n3. {4} - {5}\n4. {6} - {7}\n5. {8} - {9}\n6. {10} - {11}\n7. {12} - {13}\n8. {14} - {15}\n9. {16} - {17}\n10. {18} - {19}",
highscoreCounter[0], highscores[0], highscoreCounter[1], highscores[1], highscoreCounter[2], highscores[2], highscoreCounter[3], highscores[3], highscoreCounter[4], highscores[4], highscoreCounter[5], highscores[5], highscoreCounter[6], highscores[6], highscoreCounter[7], highscores[7], highscoreCounter[8], highscores[9], highscoreCounter[9], highscores[9]);
            //Movement Highscores
            MoveHighscores(gameTime, graphicsDevice);

            PositionStrings(graphicsDevice);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //graphics.GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            //Draw
            //spriteBatch.Begin();
            //Draw Background
            switch (currentGameState)
            {
                case 2:
                    {
                        //Draw Highscore Box
                        spriteBatch.DrawString(fontHighscores, highscoreBoard, posHighscoreBoard, Color.White, 0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.65f);
                        //Draw Stings
                        spriteBatch.DrawString(fontType, txtTitleTop, posTitleTop, Color.Yellow, 0, posOriginTitleTop, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontTypeTitle, txtTitleMiddle, posTitleMiddle, Color.Yellow, 0, posOriginTitleMiddle, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontType, txtTitleBottom, posTitleBottom, Color.Yellow, 0, posOriginTitleBottom, 1.0f, SpriteEffects.None, 0.65f);

                        spriteBatch.DrawString(fontType, txtPlay, posPlay, Color.Yellow, 0, posOriginPlay, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontType, txtOptions, posOptions, Color.Yellow, 0, posOriginOptions, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontType, txtHighscores, posHighscores, Color.Yellow, 0, posOriginHighscores, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontType, txtCredits, posCredits, Color.Yellow, 0, posOriginCredits, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontType, txtExit, posExit, Color.Yellow, 0, posOriginExit, 1.0f, SpriteEffects.None, 0.65f);

                        //Tarik Code
                        spriteBatch.Draw(txSelectArrow, recSelectArrow, Color.White);
                        break;
                    }
                case 3:
                    {
                        currentGameState = 3;
                        break;
                    }
                case 4:
                    {
                        currentGameState = 4;
                        break;
                    }
                case 5:
                    {
                        currentGameState = 5;
                        break;
                    }
                case 6:
                    {
                        currentGameState = 6;
                        break;
                    }
            }
            //spriteBatch.End();
        }

        public void MoveHighscores(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            posHighscoreBoard = posHighscoreBoard + velocityHighscores /** (float)gameTime.ElapsedGameTime.TotalSeconds*/;

            int MaxX =
                graphicsDevice.Viewport.Width - 120;
            int MinX = 0;
            int MaxY =
                graphicsDevice.Viewport.Height - 243;
            int MinY = 0;

            if (posHighscoreBoard.X >= MaxX)
            {
                velocityHighscores.X *= -1;
                posHighscoreBoard.X = MaxX;
            }

            else if (posHighscoreBoard.X < MinX)
            {
                velocityHighscores.X *= -1;
                posHighscoreBoard.X = MinX;
            }

            if (posHighscoreBoard.Y >= MaxY)
            {
                velocityHighscores.Y *= -1;
                posHighscoreBoard.Y = MaxY;
            }

            else if (posHighscoreBoard.Y < MinY)
            {
                velocityHighscores.Y *= -1;
                posHighscoreBoard.Y = MinY;
            }
        }


        public void PositionStrings(GraphicsDevice graphicsDevice)
        {
            //  Title
            //      top Part
            posOriginTitleTop.Y = 10.0f;
            posOriginTitleTop.X = graphicsDevice.Viewport.Width / 6;
            posTitleTop = new Vector2(graphicsDevice.Viewport.Width / 2,
               graphicsDevice.Viewport.Height / 15);
            //      middle Part
            posOriginTitleMiddle.Y = 20.0f;
            posOriginTitleMiddle.X = graphicsDevice.Viewport.Width / 8;
            posTitleMiddle = new Vector2(graphicsDevice.Viewport.Width / 2.1f,
               graphicsDevice.Viewport.Height / 5);
            //      bottom Part
            posOriginTitleBottom.Y = 30.0f;
            posOriginTitleBottom.X = graphicsDevice.Viewport.Width / 6;
            posTitleBottom = new Vector2(graphicsDevice.Viewport.Width / 1.68f,
               graphicsDevice.Viewport.Height / 3);
            //  Play
            posOriginPlay.Y = 50.0f;
            posOriginPlay.X = graphicsDevice.Viewport.Width / 2;
            posPlay = new Vector2(graphicsDevice.Viewport.Width / 1.07f,
               graphicsDevice.Viewport.Height / 2);
            //  Options
            posOriginOptions.Y = 60.0f;
            posOriginOptions.X = graphicsDevice.Viewport.Width / 2;
            posOptions = new Vector2(graphicsDevice.Viewport.Width / 1.12f,
               graphicsDevice.Viewport.Height / 1.70f);
            //  Highscores
            posOriginHighscores.Y = 70.0f;
            posOriginHighscores.X = graphicsDevice.Viewport.Width / 2;
            posHighscores = new Vector2(graphicsDevice.Viewport.Width / 1.1745f,
               graphicsDevice.Viewport.Height / 1.45f);
            //  Credits
            posOriginCredits.Y = 90.0f;
            posOriginCredits.X = graphicsDevice.Viewport.Width / 2;
            posCredits = new Vector2(graphicsDevice.Viewport.Width / 1.12f,
               graphicsDevice.Viewport.Height / 1.25f);
            //  Exit
            posOriginExit.Y = 100.0f;
            posOriginExit.X = graphicsDevice.Viewport.Width / 2;
            posExit = new Vector2(graphicsDevice.Viewport.Width / 1.065f,
               graphicsDevice.Viewport.Height / 1.14f);
        }



        public int GetCurrentGameState()
        {
            return currentGameState;
        }

        public bool GetExit()
        {
            return exit;
        }

        public void SetGameState(int gameState)
        {
            this.currentGameState = gameState;
        }
    }
}
