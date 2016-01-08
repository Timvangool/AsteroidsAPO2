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

        Game game;
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public StructOptionsMain structOptionsMain;
        public GraphicsDevice graphicsDevice;
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
        SpriteFont fontTypeHighscores;
        String highscores;
        Vector2 posHighBox;
        Vector2 posOriginHighBox;
        Vector2 speedBox;
        int[] highScores;
        string[] highPlayers;

        //Tarik Code
        Texture2D txSelectArrow;
        Vector2 posSelectArrow;
        Vector2 sizeSelectArrow;
        Rectangle recSelectArrow;

        ContentManager Content;

        int framesPassed;
        int sleepTimeUpDown;
        int selectedNumber;
        int currentGameState;
        bool boolPlay;
        bool boolOptions;
        bool boolHighscores;
        bool boolCredits;
        bool boolExit;
        bool passed;
        bool isMouseVisible;
        bool Exit;

        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 50;

        //STRUCT


        //Font Properties
        SpriteFont fontType, fontTypeTitle;

        //Properties String Positions
        Vector2 posPlay, posOptions, posHighscores, posCredits, posExit, posTitleTop, posTitleMiddle, posTitleBottom;
        Vector2 posOriginPlay, posOriginOptions, posOriginHighscores, posOriginCredits, posOriginExit, posOriginTitleTop, posOriginTitleMiddle, posOriginTitleBottom;

        public MainMenu(ContentManager Content, GraphicsDeviceManager graphics, Game game)
        {

            //Tarik Code:
            // graphics.PreferredBackBufferHeight = 500;
            // graphics.PreferredBackBufferWidth = 500;
            // graphics.ApplyChanges();

            this.graphics = graphics;
            this.Content = Content;
            ch = new ControlHandler();
            txSelectArrow = Content.Load<Texture2D>("SelectArrow");

            passed = true;
            //posSelectArrow = new Vector2((int)GraphicsDevice.Viewport.Width / 4.5f, (int)graphics.GraphicsDevice.Viewport.Height / 2.5f);
            sizeSelectArrow = new Vector2(graphics.PreferredBackBufferHeight / 900 * 30, graphics.PreferredBackBufferHeight / 500 * 30);
            posSelectArrow = new Vector2(4.5f, 2.6f);
            recSelectArrow = new Rectangle(graphics.PreferredBackBufferHeight / (int)posSelectArrow.X, graphics.PreferredBackBufferHeight / (int)posSelectArrow.Y, (int)sizeSelectArrow.X, (int)sizeSelectArrow.Y);

            framesPassed = 0;
            sleepTimeUpDown = 4;
            selectedNumber = 0;
            currentGameState = 2;
            boolPlay = true;
            boolOptions = false;
            boolHighscores = false;
            boolCredits = false;
            boolExit = false;

            //Kees elsman:
            highPlayers = new string[10];
            highScores = new int[10];

            for (int i = 0; i < 10; i++)
            {
                highPlayers[i] = "aaa";
                highScores[i] = 0;
            }
        }

        public void Load(ContentManager Content, GraphicsDevice graphics)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(graphics);

            isMouseVisible = true;
            //FontType
            fontType = Content.Load<SpriteFont>("Courier New");
            fontTypeTitle = Content.Load<SpriteFont>("Courier New");
            fontTypeHighscores = Content.Load<SpriteFont>("Courier New");
            //Possitions Strings
            PositionStrings();
        }

        public void UpdateSelect(int number, GraphicsDeviceManager graphics)
        {

            float newPos = posSelectArrow.Y;
            int newPosInt;
            int graphicsH = graphics.PreferredBackBufferHeight;
            int graphicsW = graphics.PreferredBackBufferHeight;
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
            //posSelectArrow = new Vector2((int)GraphicsDevice.Viewport.Width / 4.5f, (int)GraphicsDevice.Viewport.Height / newPos);
            recSelectArrow = new Rectangle(graphicsW / (int)posSelectArrow.X, newPosInt, (int)sizeSelectArrow.X, (int)sizeSelectArrow.Y);

        }

        public void Update(GameTime gameTime, GraphicsDevice graphicDevice)
        {
            switch (currentGameState)
            {
                
                case 2:
                    {
                        
                        //Keybindings
                        timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                        if (timeSinceLastFrame > millisecondsPerFrame)
                        {
                            timeSinceLastFrame -= millisecondsPerFrame;
                            if (passed)
                            {
                                UpdateSelect(0, graphics);
                                passed = false;
                            }
                            framesPassed = 0;
                            if (ch.GetInput().Contains("Up"))
                            {
                                switch (selectedNumber)
                                {
                                    case 0:
                                        {
                                            boolPlay = true;
                                            boolOptions = false;
                                            boolHighscores = false;
                                            boolCredits = false;
                                            boolExit = false;
                                            UpdateSelect(0, graphics);

                                            //Thread.Sleep(sleepTimeUpDown);
                                            break;
                                        }
                                    case 1:
                                        {
                                            selectedNumber--;
                                            boolPlay = false;
                                            boolOptions = true;
                                            boolHighscores = false;
                                            boolCredits = false;
                                            boolExit = false;
                                            UpdateSelect(1, graphics);
                                            // Thread.Sleep(sleepTimeUpDown);
                                            break;
                                        }
                                    case 2:
                                        {
                                            selectedNumber--;
                                            boolPlay = false;
                                            boolOptions = false;
                                            boolHighscores = true;
                                            boolCredits = false;
                                            boolExit = false;
                                            UpdateSelect(2, graphics);
                                            // Thread.Sleep(sleepTimeUpDown);
                                            break;
                                        }
                                    case 3:
                                        {
                                            selectedNumber--;
                                            boolPlay = false;
                                            boolOptions = false;
                                            boolHighscores = false;
                                            boolCredits = true;
                                            boolExit = false;
                                            UpdateSelect(3, graphics);
                                            //Thread.Sleep(sleepTimeUpDown);
                                            break;
                                        }
                                    case 4:
                                        {
                                            selectedNumber--;
                                            boolPlay = false;
                                            boolOptions = false;
                                            boolHighscores = false;
                                            boolCredits = false;
                                            boolExit = true;
                                            UpdateSelect(4, graphics);
                                            //Thread.Sleep(sleepTimeUpDown);
                                            break;
                                        }
                                }

                            }

                            else if (ch.GetInput().Contains("Down"))
                            {
                                switch (selectedNumber)
                                {
                                    case 0:
                                        {
                                            selectedNumber++;
                                            boolPlay = true;
                                            boolOptions = false;
                                            boolHighscores = false;
                                            boolCredits = false;
                                            boolExit = false;
                                            UpdateSelect(0, graphics);
                                            //Thread.Sleep(sleepTimeUpDown);
                                            break;
                                        }
                                    case 1:
                                        {
                                            selectedNumber++;
                                            boolPlay = false;
                                            boolOptions = true;
                                            boolHighscores = false;
                                            boolCredits = false;
                                            boolExit = false;
                                            UpdateSelect(1, graphics);
                                            //Thread.Sleep(sleepTimeUpDown);
                                            break;
                                        }
                                    case 2:
                                        {
                                            selectedNumber++;
                                            boolPlay = false;
                                            boolOptions = false;
                                            boolHighscores = true;
                                            boolCredits = false;
                                            boolExit = false;
                                            UpdateSelect(2, graphics);
                                            //Thread.Sleep(sleepTimeUpDown);
                                            break;
                                        }
                                    case 3:
                                        {
                                            selectedNumber++;
                                            boolPlay = false;
                                            boolOptions = false;
                                            boolHighscores = false;
                                            boolCredits = true;
                                            boolExit = false;
                                            UpdateSelect(3, graphics);
                                            //Thread.Sleep(sleepTimeUpDown);
                                            break;
                                        }
                                    case 4:
                                        {
                                            boolPlay = false;
                                            boolOptions = false;
                                            boolHighscores = false;
                                            boolCredits = false;
                                            boolExit = true;
                                            UpdateSelect(4, graphics);
                                            //Thread.Sleep(sleepTimeUpDown);
                                            break;
                                        }

                                }
                            }
                            else if (ch.GetInput().Contains("Select"))
                            {
                                if (boolPlay)
                                {
                                    currentGameState = 3;
                                }
                                else if (boolOptions)
                                {
                                    currentGameState = 5;
                                }
                                else if (boolHighscores)
                                {
                                    currentGameState = 6;
                                }
                                else if (boolCredits)
                                {
                                    currentGameState = 9;
                                }
                                else if (boolExit)
                                {
                                    Exit = true;
                                }
                            }
                            else if (ch.GetInput().Contains("Back"))
                            {
                                Exit = true;
                            }

                        }
                    //framesPassed++;
                    //Highscores
                    highscores = string.Format("1. {0},{1} \n2. {2},{3}\n3. {4},{5}\n4. {6},{7}\n5. {8},{9}\n6. {10},{11}\n7. {12},{13}\n8. {14},{15}\n9. {16},{17}\n10. {18},{19}",
                        highPlayers[0], highScores[0], highPlayers[1], highScores[1], highPlayers[2], highScores[2], highPlayers[3], highScores[3], highPlayers[4], highScores[4], highPlayers[5], highScores[5], highPlayers[6], highScores[6], highPlayers[7], highScores[7], highPlayers[8], highScores[9], highPlayers[9], highScores[9]);

                    //Movement Highscore Box
                    MoveHighscores(gameTime);
                    break;
                }
                case 3:
                {
                    graphicDevice.Clear(Color.White); break;
                }
                case 4:
                {
                    graphicDevice.Clear(Color.White); break;
                }
                case 5:
                {
                        graphicDevice.Clear(Color.White); break;
                }
                case 6:
                {
                    graphicDevice.Clear(Color.White); break;
                }
                case 7:
                {
                    graphicDevice.Clear(Color.White); break;
                }
                case 8:
                {
                    graphicDevice.Clear(Color.White); break;
                }
                case 9:
                {
                    graphicDevice.Clear(Color.White); break;
                }
            }
            
        }

        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //Draw
            //spriteBatch.Begin();
            //Draw Background
            graphicsDevice.Clear(Color.Black);
            spriteBatch.Draw(txSelectArrow, recSelectArrow, Color.White);
            switch (currentGameState)
            {
                case 2:
                    {

                        //Draw Highscore Box
                        spriteBatch.DrawString(fontTypeHighscores, highscores, posHighBox, Color.White, 0, new Vector2(50, 50), 1.0f, SpriteEffects.None, 0.65f);

                        //Draw Stings
                        spriteBatch.DrawString(fontType, txtTitleTop, posTitleTop, Color.Yellow, 0, posOriginTitleTop, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontTypeTitle, txtTitleMiddle, posTitleMiddle, Color.Yellow, 0, posOriginTitleMiddle, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontType, txtTitleBottom, posTitleBottom, Color.Yellow, 0, posOriginTitleBottom, 1.0f, SpriteEffects.None, 0.65f);

                        spriteBatch.DrawString(fontType, txtPlay, posPlay, Color.Yellow, 0, posOriginPlay, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontType, txtOptions, posOptions, Color.Yellow, 0, posOriginOptions, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontType, txtHighscores, posHighscores, Color.Yellow, 0, posOriginHighscores, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontType, txtCredits, posCredits, Color.Yellow, 0, posOriginCredits, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontType, txtExit, posExit, Color.Yellow, 0, posOriginExit, 1.0f, SpriteEffects.None, 0.65f);
                        spriteBatch.DrawString(fontType, currentGameState.ToString(), posExit, Color.White, 0, posOriginExit, 1.0f, SpriteEffects.None, 0.65f);
                        //Select Arrow
                        
                        break;
                    }
                case 3:
                    {
                        spriteBatch.DrawString(fontType, "Play", posCredits, Color.White, 0, posOriginCredits, 1.0f, SpriteEffects.None, 0.65f);
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        spriteBatch.DrawString(fontType, "Options", posCredits, Color.White, 0, posOriginCredits, 1.0f, SpriteEffects.None, 0.65f);
                        break;
                    }
                case 6:
                    {
                        spriteBatch.DrawString(fontType, "Highscore", posCredits, Color.White, 0, posOriginCredits, 1.0f, SpriteEffects.None, 0.65f);
                        break;
                    }
            }

            //spriteBatch.End();

        }

        public void PositionStrings()
        {
            //  Title
            //      top Part
            posOriginTitleTop.Y = 10.0f;
            posOriginTitleTop.X = graphics.GraphicsDevice.Viewport.Width / 6;
            posTitleTop = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
               graphics.GraphicsDevice.Viewport.Height / 15);
            //      middle Part
            posOriginTitleMiddle.Y = 20.0f;
            posOriginTitleMiddle.X = graphics.GraphicsDevice.Viewport.Width / 8;
            posTitleMiddle = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2.1f,
               graphics.GraphicsDevice.Viewport.Height / 5);
            //      bottom Part
            posOriginTitleBottom.Y = 30.0f;
            posOriginTitleBottom.X = graphics.GraphicsDevice.Viewport.Width / 6;
            posTitleBottom = new Vector2(graphics.GraphicsDevice.Viewport.Width / 1.68f,
               graphics.GraphicsDevice.Viewport.Height / 3);

            //  Play
            posOriginPlay.Y = 50.0f;
            posOriginPlay.X = graphics.GraphicsDevice.Viewport.Width / 2;
            posPlay = new Vector2(graphics.GraphicsDevice.Viewport.Width / 1.07f,
               graphics.GraphicsDevice.Viewport.Height / 2);

            //  Options
            posOriginOptions.Y = 60.0f;
            posOriginOptions.X = graphics.GraphicsDevice.Viewport.Width / 2;
            posOptions = new Vector2(graphics.GraphicsDevice.Viewport.Width / 1.12f,
               graphics.GraphicsDevice.Viewport.Height / 1.70f);

            //  Highscores
            posOriginHighscores.Y = 70.0f;
            posOriginHighscores.X = graphics.GraphicsDevice.Viewport.Width / 2;
            posHighscores = new Vector2(graphics.GraphicsDevice.Viewport.Width / 1.1745f,
               graphics.GraphicsDevice.Viewport.Height / 1.45f);

            //  Credits
            posOriginCredits.Y = 90.0f;
            posOriginCredits.X = graphics.GraphicsDevice.Viewport.Width / 2;
            posCredits = new Vector2(graphics.GraphicsDevice.Viewport.Width / 1.12f,
               graphics.GraphicsDevice.Viewport.Height / 1.25f);

            //  Exit
            posOriginExit.Y = 100.0f;
            posOriginExit.X = graphics.GraphicsDevice.Viewport.Width / 2;
            posExit = new Vector2(graphics.GraphicsDevice.Viewport.Width / 1.065f,
               graphics.GraphicsDevice.Viewport.Height / 1.14f);

            //HighScore Box
            posHighBox.Y = 50f;
            posOriginExit.X = graphics.GraphicsDevice.Viewport.Width / 2;
            posHighBox = new Vector2(50.0f, 50.0f);
            speedBox = new Vector2(50.0f, 50.0f);
        }

        public void MoveHighscores(GameTime gameTime)
        {
            posHighBox +=
                speedBox * (float)gameTime.ElapsedGameTime.TotalSeconds;

            int MaxX =
                graphics.GraphicsDevice.Viewport.Width - 150;
            int MinX = 0;
            int MaxY =
                graphics.GraphicsDevice.Viewport.Height - 280;
            int MinY = 0;

            // Check for bounce.
            if (posHighBox.X < MaxX)
            {
                speedBox.X *= -1;
                posHighBox.X = MaxX;
            }

            else if (posHighBox.X > MinX)
            {
                speedBox.X *= -1;
                posHighBox.X = MinX;
            }

            if (posHighBox.Y < MaxY)
            {
                speedBox.Y *= -1;
                posHighBox.Y = MaxY;
            }

            else if (posHighBox.Y > MinY)
            {
                speedBox.Y *= -1;
                posHighBox.Y = MinY;
            }
        }

        public int GetCurrentGamestate()
        {
            return currentGameState;
        }

        public bool GetExit()
        {
            return Exit;
        }
    }
}
