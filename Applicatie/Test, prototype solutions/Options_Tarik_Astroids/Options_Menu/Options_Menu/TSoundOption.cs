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
        bool mouseReleased = true;

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
            distance = graphics.PreferredBackBufferWidth / posSoundBar.X;
            distance += count;
            return distance;
        }

        public void MakeResolutionArray()
        {
            float soundBarW = recSoundBar.Width / 6;
            arVolumes = new float[][]
            {
            
            new float[] { DistanceCalculate((soundBarW * 6) - 20f ), 1f},
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

            temp = graphics.PreferredBackBufferHeight / barCursorHeigthFloat;

            barCursorHeigth = Convert.ToInt32(temp - 17);
            return barCursorHeigth;
        }
        public void Init()
        {
            sizeW = (graphics.PreferredBackBufferWidth / 900);
            sizeH = (graphics.PreferredBackBufferHeight / 500);
            MakeResolutionArray();
            recSoundBar = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posSoundBar.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posSoundBar.Y), Convert.ToInt32(sizeW * sizeSoundBar.X), Convert.ToInt32(sizeH * sizeSoundBar.Y));
            recBarCursor = new Rectangle(Convert.ToInt32(arVolumes[arrayNumber][0]), BarCursorHeigthConvert(), Convert.ToInt32(sizeW * sizeBarCursor.X), Convert.ToInt32(sizeH * sizeBarCursor.Y));
            recArrowLeft = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowLeft.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowLeft.Y), Convert.ToInt32(sizeW * sizeArrow.X), Convert.ToInt32(sizeH * sizeArrow.Y));
            recArrowRight = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowRight.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowRight.Y), Convert.ToInt32(sizeW * sizeArrow.X), Convert.ToInt32(sizeH * sizeArrow.Y));
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

        public void Update(MouseState mouse)
        {
            Rectangle mouseRec = new Rectangle((int)mouse.X, (int)mouse.Y, recArrowLeft.Width, recArrowLeft.Height);
            if (recArrowLeft.Intersects(mouseRec))
            {
                if (mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && mouseReleased == true)
                {
                    if (arrayNumber != arVolumes.Count() - 1)
                    {
                        arrayNumber++;
                        MoveCurser(arVolumes[arrayNumber][0]);
                        ChangeVolume(arVolumes[arrayNumber][1]);
                    }
                    mouseReleased = false;
                }
            }
            if (recArrowRight.Intersects(mouseRec))
            {
                if (mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && mouseReleased == true)
                {
                    if (arrayNumber != 0)
                    {
                        arrayNumber--;
                        MoveCurser(arVolumes[arrayNumber][0]);
                        ChangeVolume(arVolumes[arrayNumber][1]);
                    }
                    mouseReleased = false;
                }
            }
            if (mouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                mouseReleased = true;
            }
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
