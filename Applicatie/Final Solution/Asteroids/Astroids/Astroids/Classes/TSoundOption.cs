using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids
{
    class TSoundOption
    {
        //GRAPHICS
        GraphicsDeviceManager graphics;

        //TEXTURES
        Texture2D txSoundBar;
        Texture2D txBarCursor;
        Texture2D txArrowLeft;
        Texture2D txArrowRight;

        //TEXTURES POSITIONS
        Vector2 posSoundBar;
        Vector2 posArrowLeft;
        Vector2 posArrowRight;

        //TEXTURES SIZES
        Vector2 sizeSoundBar;
        Vector2 sizeBarCursor;
        Vector2 sizeArrow;

        //COLOUR
        Color col;

        //RECTANGLES
        Rectangle recSoundBar;
        Rectangle recBarCursor;
        Rectangle recArrowLeft;
        Rectangle recArrowRight;

        //VARIABLES
        int arrayNumber = 0;
        int barCursorHeigth;
        float[][] arVolumes; float sizeW;
        float sizeH;
        float distance;
        float temp;
        float barCursorHeigthFloat;

        public TSoundOption(Game1.StructOptionsMain structOptionsMain, StructSound structSound)
        {
            //GRAPHICS
            this.graphics = structOptionsMain.Graphics;

            //TEXTURES
            this.txSoundBar = structSound.TxSoundBar;
            this.txBarCursor = structSound.TxSoundBarCursor;
            this.txArrowLeft = structSound.TxArrowLeft;
            this.txArrowRight = structSound.TxArrowRight;

            //TEXTURES POSITIONS
            this.posSoundBar = structSound.PosSoundBar;
            this.posArrowLeft = structSound.PosArrowLeft;
            this.posArrowRight = structSound.PosArrowRight;

            //TEXTURES SIZES
            this.sizeSoundBar = structSound.SizeSoundBar;
            this.sizeBarCursor = structSound.SizeSoundBarCursor;
            this.sizeArrow = structSound.SizeArrow;

            //COLOUR
            this.col = Color.White;

            //INITIALIZE
            barCursorHeigthFloat = posSoundBar.Y += 0.30f;
            MakeResolutionArray();
            Init();
        }

        public float DistanceCalculate(float count)
        {
            distance = (float)graphics.PreferredBackBufferWidth / posSoundBar.X;
            distance += count;
            return distance;
        }

        public void MakeResolutionArray()
        {
            float soundBarW = recSoundBar.Width / 6;
            arVolumes = new float[][]
            {
            
            new float[] { DistanceCalculate((soundBarW * 5.4f) ), 1f},
            new float[] { DistanceCalculate((soundBarW * 5) ), 0.8f},
            new float[] { DistanceCalculate((soundBarW * 4) ), 0.6f},
            new float[] { DistanceCalculate((soundBarW * 3) ), 0.4f},
            new float[] { DistanceCalculate((soundBarW * 2) ), 0.2f},
            new float[] { DistanceCalculate((soundBarW * 1) ), 0.1f},
            new float[] { DistanceCalculate((soundBarW * 0) ), 0f},
            };
        }

        public int BarCursorHeigthConvert()
        {

            temp = (float)graphics.PreferredBackBufferHeight / barCursorHeigthFloat;

            barCursorHeigth = Convert.ToInt32(temp - 19);
            return barCursorHeigth;
        }
        public void Init()
        {
            //SCREEN SCALE
            float graphicsW = graphics.PreferredBackBufferWidth;
            float graphicsH = graphics.PreferredBackBufferHeight;
            sizeW = (graphicsW / 900);
            sizeH = (graphicsH / 500);

            //RECTANGLE SOUNDBAR
            int recSoundBarX = Convert.ToInt32(graphicsW / posSoundBar.X);
            int recSoundBarY = Convert.ToInt32(graphicsH / posSoundBar.Y);
            int recSoundBarWidth = Convert.ToInt32(sizeW * sizeSoundBar.X);
            int recSoundBarHeigth = Convert.ToInt32(sizeH * sizeSoundBar.Y);
            recSoundBar = new Rectangle(recSoundBarX, recSoundBarY, recSoundBarWidth, recSoundBarHeigth);

            //RECTANGLE SOUNDBARCURSOR
            int recBarCursorX = Convert.ToInt32(arVolumes[arrayNumber][0]);
            int recBarCursorY = BarCursorHeigthConvert();
            int recBarCursorWidth = Convert.ToInt32(sizeW * sizeBarCursor.X);
            int recBarCursorHeigth = Convert.ToInt32(sizeH * sizeBarCursor.Y);
            recBarCursor = new Rectangle(recBarCursorX, recBarCursorY, recBarCursorWidth, recBarCursorHeigth);

            //RECTANGLE LEFT ARROW
            int recArrowLeftX = Convert.ToInt32(graphicsW / posArrowLeft.X);
            int recArrowY = Convert.ToInt32(graphicsH / posArrowLeft.Y);
            int recArrowWidth = Convert.ToInt32(sizeW * sizeArrow.X);
            int recArrowHeigth = Convert.ToInt32(sizeH * sizeArrow.Y);
            recArrowLeft = new Rectangle(recArrowLeftX, recArrowY, recArrowWidth, recArrowHeigth);

            //RECTANGLE RIGHT ARROW
            int recArrowRightX = Convert.ToInt32(graphicsW / posArrowRight.X);
            recArrowRight = new Rectangle(recArrowRightX, recArrowY, recArrowWidth, recArrowHeigth);

            //RESOLUTION ARRAY
            MakeResolutionArray();
        }

        public void ChangeVolume(float volume)
        {
            MediaPlayer.Volume = volume;
            graphics.ApplyChanges();
        }

        public void SelectLeft()
        {
            if (arrayNumber != arVolumes.Count() - 1)
            {
                arrayNumber++;
                MoveCurser(arVolumes[arrayNumber][0]);
                ChangeVolume(arVolumes[arrayNumber][1]);
            }
        }

        public void SelectRight()
        {
            if (arrayNumber != 0)
            {
                arrayNumber--;
                MoveCurser(arVolumes[arrayNumber][0]);
                ChangeVolume(arVolumes[arrayNumber][1]);
            }
        }

        public void MoveCurser(float x)
        {
            recBarCursor = new Rectangle(Convert.ToInt32(arVolumes[arrayNumber][0]), BarCursorHeigthConvert(), recBarCursor.Width, recBarCursor.Height);
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(txSoundBar, recSoundBar, col);
            sprite.Draw(txBarCursor, recBarCursor, col);
            sprite.Draw(txArrowLeft, recArrowLeft, col);
            sprite.Draw(txArrowRight, recArrowRight, col);
        }
    }
}
