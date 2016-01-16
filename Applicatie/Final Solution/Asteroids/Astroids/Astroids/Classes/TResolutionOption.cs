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
        //GRAPHICS
        GraphicsDeviceManager graphics;

        //TEXTURES
        Texture2D txResolutionBar;
        Texture2D txArrowLeft;
        Texture2D txArrowRight;

        //TEXTURES POSITIONS
        Vector2 posResolutionBarText;
        Vector2 posResolutionBar;
        Vector2 posArrowLeft;
        Vector2 posArrowRight;

        //TEXTURES SIZES
        Vector2 sizeResolutionBar;
        Vector2 sizeArrow;
        Vector2 temp;

        //TEXTURES RECTANGLES
        Rectangle recArrowLeft;
        Rectangle recArrowRight;
        Rectangle recResolutionBar;

        //COLOUR
        Color col;

        //VARIABLES
        int arrayNumber = 6;
        float sizeW;
        float sizeH;
        float scale;
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
        bool resolutionChanged = false;

        public TResolutionOption(Game1.StructOptionsMain structOptionsMain, StructResolution structResolution)
        {
            //GRAPHICS
            this.graphics = structOptionsMain.Graphics;

            //TEXTURES
            this.txResolutionBar = structResolution.TxResolutionBar;
            this.txArrowLeft = structResolution.TxArrowLeft;
            this.txArrowRight = structResolution.TxArrowRight;

            //TEXTURES POSITIONS
            this.posResolutionBar = structResolution.PosResolutionBar;
            this.posArrowLeft = structResolution.PosArrowLeft;
            this.posArrowRight = structResolution.PosArrowRight;

            //TEXTURES SIZED
            this.sizeResolutionBar = structResolution.SizeResolutionBar;
            this.sizeArrow = structResolution.SizeArrow;
            this.sizeResolutionBar = structResolution.SizeResolutionBar;

            //COLOUR
            this.col = Color.White;

            //INITIALIZE
            this.temp = posResolutionBar;
            Init();

        }

        public void Init()
        {
            //SCREEN SCALE
            int prefBBufW = graphics.PreferredBackBufferWidth;
            sizeW = ((float)graphics.PreferredBackBufferWidth / 900);
            sizeH = ((float)graphics.PreferredBackBufferHeight / 500);
            scale = (float)sizeW * 0.4f;

            
            //RECTANGLE LEFT ARROW
            int recArrowX = Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowLeft.X);
            int recArrowY = Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowLeft.Y);
            int recArrowWidth = Convert.ToInt32(sizeW * sizeArrow.X);
            int recArrowHeigth = Convert.ToInt32(sizeH * sizeArrow.Y);
            recArrowLeft = new Rectangle(recArrowX, recArrowY, recArrowWidth, recArrowHeigth);

            //RECTANGLE RIGHT ARROW
            recArrowX = Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowRight.X);
            recArrowY = Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowRight.Y);
            recArrowRight = new Rectangle(recArrowX, recArrowY, recArrowWidth, recArrowHeigth);

            //RECTANGLE RESOLUTIONBAR
            recResolutionBar = new Rectangle(Convert.ToInt32(posResolutionBar.X), Convert.ToInt32(posResolutionBar.Y), Convert.ToInt32(sizeW * sizeResolutionBar.X), Convert.ToInt32(sizeH * sizeResolutionBar.Y));

            //POSITIONS
            posResolutionBar = new Vector2(graphics.PreferredBackBufferWidth / temp.X, graphics.PreferredBackBufferHeight / temp.Y);
            posResolutionBarText = new Vector2((float)recResolutionBar.X / 10 * 9.6f, recResolutionBar.Y);

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
            if (resolutionChanged == false)
            {
                resolutionChanged = true;
            }
            graphics.PreferredBackBufferWidth = (int)screen.X;
            graphics.PreferredBackBufferHeight = (int)screen.Y;
            graphics.ApplyChanges();
        }

        public void Draw(SpriteBatch sprite, SpriteFont spriteFont)
        {
            sprite.Draw(txArrowLeft, recArrowLeft, col);
            sprite.Draw(txArrowRight, recArrowRight, col);
            sprite.Draw(txResolutionBar, recResolutionBar, col);
            sprite.DrawString(spriteFont, arResolutions[arrayNumber][0], posResolutionBarText, Color.Black, 0, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

    }
}
