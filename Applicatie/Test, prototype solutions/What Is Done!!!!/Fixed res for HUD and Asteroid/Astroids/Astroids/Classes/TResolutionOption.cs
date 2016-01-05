using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids
{
    class TResolutionOption
    {
        GraphicsDeviceManager graphics;

        string[][] arResolutions = new string[][]
        {
            new string[] {"  1920 x 1080", "1920", "1080"},
            new string[] {"  1680 x 1050", "1680", "1050"},
            new string[] {"  1600 x 900", "1600", "900"},
            new string[] {"  1440 x 900", "1440", "900"},
            new string[] {"  1366 x 768", "1366", "786"},
            new string[] {"  1280 x 1024", "1280", "1024"},
            new string[] {"  1280 x 800", "1280", "800"},
            new string[] {"  1024 x 786", "1024", "786"}
        };
        int arrayNumber = 6;
        Texture2D txResolutionBar;
        Texture2D txArrowLeft;
        Texture2D txArrowRight;
        Vector2 posResolutionBar;
        Vector2 sizeResolutionBar;
        Vector2 posArrowLeft;
        Vector2 posArrowRight; 
        Vector2 sizeArrow;
        Vector2 temp;

        Rectangle recArrowLeft;
        Rectangle recArrowRight;
        Rectangle recResolutionBar;
        Color col;
        bool mouseReleased = true;
        bool resolutionChanged = false;

        public TResolutionOption(GraphicsDeviceManager graphics, Texture2D txResolutionBar, Texture2D txArrowLeft, Texture2D txArrowRight, Vector2 posResolutionBar, Vector2 sizeResolutionBar, Vector2 posArrowLeft, Vector2 posArrowRight, Vector2 sizeArrow, Color col)
        {
            this.graphics = graphics;
            this.txResolutionBar = txResolutionBar;
            this.txArrowLeft = txArrowLeft;
            this.txArrowRight = txArrowRight;
            this.posResolutionBar = posResolutionBar;
            this.sizeResolutionBar = sizeResolutionBar;
            this.posArrowLeft = posArrowLeft;
            this.posArrowRight = posArrowRight;
            this.sizeArrow = sizeArrow;
            this.sizeResolutionBar = sizeResolutionBar;
            this.col = col;
            this.temp = posResolutionBar;
            Init();

        }

        public void Init()
        {
            posResolutionBar = new Vector2(graphics.PreferredBackBufferWidth / temp.X, graphics.PreferredBackBufferHeight / temp.Y);
            recArrowLeft = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowLeft.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowLeft.Y), (int)sizeArrow.X, (int)sizeArrow.Y);
            recArrowRight = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowRight.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowRight.Y), (int)sizeArrow.X, (int)sizeArrow.Y);
            recResolutionBar = new Rectangle(Convert.ToInt32(posResolutionBar.X), Convert.ToInt32(posResolutionBar.Y), (int)sizeResolutionBar.X, (int)sizeResolutionBar.Y);
            
        }

        public void SelectLeft()
        {
            if (arrayNumber != arResolutions.Count() - 1)
            {
                arrayNumber++;
                ChangeResolution(new Vector2(Convert.ToInt32(arResolutions[arrayNumber][1]), Convert.ToInt32(arResolutions[arrayNumber][2])));
            }
        }

        public void SelectRight()
        {
            if (arrayNumber != 0)
            {
                arrayNumber--;
                ChangeResolution(new Vector2(Convert.ToInt32(arResolutions[arrayNumber][1]), Convert.ToInt32(arResolutions[arrayNumber][2])));
            }
        }

        public bool GetResolutionChanged()
        {
            return resolutionChanged;
        }

        public void ChangeResolution(Vector2 screen)
        {
            if(resolutionChanged == false)
            {
                resolutionChanged = true;
            }
            graphics.PreferredBackBufferWidth = (int)screen.X;
            graphics.PreferredBackBufferHeight = (int)screen.Y;
            graphics.ApplyChanges();
        }

        public void Update(MouseState mouse)
        {
            Rectangle mouseRec = new Rectangle((int)mouse.X, (int)mouse.Y, (int)sizeArrow.X, (int)sizeArrow.Y);
            if (recArrowLeft.Intersects(mouseRec))
            {
                if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
                {
                    if (arrayNumber != arResolutions.Count() - 1)
                    {
                        arrayNumber++;
                        ChangeResolution(new Vector2(Convert.ToInt32(arResolutions[arrayNumber][1]), Convert.ToInt32(arResolutions[arrayNumber][2])));
                    }

                    mouseReleased = false;
                }

            }
            if (recArrowRight.Intersects(mouseRec))
            {
                if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
                {
                    if (arrayNumber != 0)
                    {
                        arrayNumber--;
                        ChangeResolution(new Vector2(Convert.ToInt32(arResolutions[arrayNumber][1]), Convert.ToInt32(arResolutions[arrayNumber][2])));
                    }

                    mouseReleased = false;
                }

            }
            if (mouse.LeftButton == ButtonState.Released)
            {
                mouseReleased = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(txArrowLeft, recArrowLeft, col);
            spriteBatch.Draw(txArrowRight, recArrowRight, col);
            spriteBatch.Draw(txResolutionBar, recResolutionBar, col);
            spriteBatch.DrawString(spriteFont, arResolutions[arrayNumber][0], posResolutionBar, Color.Black);
            spriteBatch.End();
        }

    }
}
