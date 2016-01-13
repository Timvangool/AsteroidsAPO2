using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Options_Menu
{
    class TResolutionOption
    {
        GraphicsDeviceManager graphics;

        string[][] arResolutions = new string[][]
        {
            new string[] {"  1920 x 1080", "1920", "1080"},
            new string[] {"  1600 x 900", "1600", "900"},
            new string[] {"  1440 x 900", "1440", "900"},
            new string[] {"  1366 x 768", "1366", "786"},
            new string[] {"  1280 x 800", "1280", "800"},
            new string[] {"  1024 x 786", "1024", "786"},
            new string[] {"  1024 x 576", "1024", "576"}
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
        float sizeW;
        float sizeH;
        bool mouseReleased = true;
        bool resolutionChanged = false;
        float scale;

        public TResolutionOption(StructOptionsMain structOptionsMain, StructResolution structResolution)
        {
            this.graphics = structOptionsMain.Graphics;
            this.txResolutionBar = structResolution.TxResolutionBar;
            this.txArrowLeft = structResolution.TxArrowLeft;
            this.txArrowRight = structResolution.TxArrowRight;
            this.posResolutionBar = structResolution.PosResolutionBar;
            this.sizeResolutionBar = structResolution.SizeResolutionBar;
            this.posArrowLeft = structResolution.PosArrowLeft;
            this.posArrowRight = structResolution.PosArrowRight;
            this.sizeArrow = structResolution.SizeArrow;
            this.sizeResolutionBar = structResolution.SizeResolutionBar;
            this.col = Color.White;
            this.temp = posResolutionBar;
            Init();

        }

        public void Init()
        {
            sizeW = (graphics.PreferredBackBufferWidth / 900);
            sizeH = (graphics.PreferredBackBufferHeight / 500);
            scale = sizeW * 1.0f;
            posResolutionBar = new Vector2(graphics.PreferredBackBufferWidth / temp.X, graphics.PreferredBackBufferHeight / temp.Y);
            recArrowLeft = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowLeft.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowLeft.Y), Convert.ToInt32(sizeW * sizeArrow.X), Convert.ToInt32(sizeH * sizeArrow.Y));
            recArrowRight = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowRight.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowRight.Y), Convert.ToInt32(sizeW * sizeArrow.X), Convert.ToInt32(sizeH * sizeArrow.Y));
            recResolutionBar = new Rectangle(Convert.ToInt32(posResolutionBar.X), Convert.ToInt32(posResolutionBar.Y), Convert.ToInt32(sizeW * sizeResolutionBar.X), Convert.ToInt32(sizeH * sizeResolutionBar.Y));
            
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
            Rectangle mouseRec = new Rectangle((int)mouse.X, (int)mouse.Y, recArrowLeft.Width, (int)recArrowLeft.Height);
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

        public void Draw(SpriteBatch sprite, SpriteFont spriteFont)
        {
            sprite.Draw(txArrowLeft, recArrowLeft, col);
            sprite.Draw(txArrowRight, recArrowRight, col);
            sprite.Draw(txResolutionBar, recResolutionBar, col);
            sprite.DrawString(spriteFont, arResolutions[arrayNumber][0], new Vector2(posResolutionBar.X - 10, posResolutionBar.Y), Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

    }
}
