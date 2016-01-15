using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Options_Menu
{
    class TSoundOption
    {
        GraphicsDeviceManager graphics;
        int arrayNumber = 0;
        float[][] arVolumes;

        Texture2D txSoundBar;
        Texture2D txBarCursor;
        Texture2D txArrowLeft;
        Texture2D txArrowRight;

        Vector2 posSoundBar;
        Vector2 posArrowLeft;
        Vector2 posArrowRight;

        Vector2 sizeSoundBar;
        Vector2 sizeBarCursor;
        Vector2 sizeArrow;

        Color col;

        Rectangle recSoundBar;
        Rectangle recBarCursor;
        Rectangle recArrowLeft;
        Rectangle recArrowRight;

        float sizeW;
        float sizeH;
        float distance;
        float temp;
        float barCursorHeigthFloat;
        int barCursorHeigth;

        public TSoundOption(StructOptionsMain structOptionsMain, StructSound structSound)
        {
            this.graphics = structOptionsMain.Graphics;

            this.txSoundBar = structSound.TxSoundBar;
            this.txBarCursor = structSound.TxSoundBarCursor;
            this.txArrowLeft = structSound.TxArrowLeft;
            this.txArrowRight = structSound.TxArrowRight;

            this.posSoundBar = structSound.PosSoundBar;
            this.posArrowLeft = structSound.PosArrowLeft;
            this.posArrowRight = structSound.PosArrowRight;

            this.sizeSoundBar = structSound.SizeSoundBar;
            this.sizeBarCursor = structSound.SizeSoundBarCursor;
            this.sizeArrow = structSound.SizeArrow;

            this.col = Color.White;
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
            float graphicsW = graphics.PreferredBackBufferWidth;
            float graphicsH = graphics.PreferredBackBufferHeight;
            sizeW = (graphicsW / 900);
            sizeH = (graphicsH / 500);

            int recSoundBarX = Convert.ToInt32(graphicsW / posSoundBar.X);
            int recSoundBarY = Convert.ToInt32(graphicsH / posSoundBar.Y);
            int recSoundBarWidth = Convert.ToInt32(sizeW * sizeSoundBar.X);
            int recSoundBarHeigth = Convert.ToInt32(sizeH * sizeSoundBar.Y);
            recSoundBar = new Rectangle(recSoundBarX, recSoundBarY, recSoundBarWidth, recSoundBarHeigth);

            int recBarCursorX = Convert.ToInt32(arVolumes[arrayNumber][0]);
            int recBarCursorY = BarCursorHeigthConvert();
            int recBarCursorWidth = Convert.ToInt32(sizeW * sizeBarCursor.X);
            int recBarCursorHeigth = Convert.ToInt32(sizeH * sizeBarCursor.Y);
            recBarCursor = new Rectangle(recBarCursorX, recBarCursorY, recBarCursorWidth, recBarCursorHeigth);

            int recArrowLeftX = Convert.ToInt32(graphicsW / posArrowLeft.X);
            int recArrowY = Convert.ToInt32(graphicsH / posArrowLeft.Y);
            int recArrowWidth = Convert.ToInt32(sizeW * sizeArrow.X);
            int recArrowHeigth = Convert.ToInt32(sizeH * sizeArrow.Y);
            recArrowLeft = new Rectangle(recArrowLeftX, recArrowY, recArrowWidth, recArrowHeigth);
            int recArrowRightX = Convert.ToInt32(graphicsW / posArrowRight.X);
            recArrowRight = new Rectangle(recArrowRightX, recArrowY, recArrowWidth, recArrowHeigth);
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
