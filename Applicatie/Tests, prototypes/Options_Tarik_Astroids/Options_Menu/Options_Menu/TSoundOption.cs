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

        float distance;
        float temp;
        float barCursorHeigthFloat;
        int barCursorHeigth;
        bool mouseReleased = true;

        public TSoundOption(GraphicsDeviceManager graphics, Texture2D txSoundBar, Texture2D txBarCursor, Texture2D txArrowLeft, Texture2D txArrowRight, Vector2 posSoundBar, Vector2 sizeSoundBar, Vector2 sizeBarCursor, Vector2 posArrowLeft, Vector2 posArrowRight, Vector2 sizeArrow, Color col)
        {
            this.graphics = graphics;

            this.txSoundBar = txSoundBar;
            this.txBarCursor = txBarCursor;
            this.txArrowLeft = txArrowLeft;
            this.txArrowRight = txArrowRight;

            this.posSoundBar = posSoundBar;
            this.posArrowLeft = posArrowLeft;
            this.posArrowRight = posArrowRight;

            this.sizeSoundBar = sizeSoundBar;
            this.sizeBarCursor = sizeBarCursor;
            this.sizeArrow = sizeArrow;

            this.col = col;
            barCursorHeigthFloat = posSoundBar.Y += 0.17f;
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
            arVolumes = new float[][]
        {
            new float[] { DistanceCalculate(178f), 1f},
            new float[] { DistanceCalculate(142.2f), 0.8f},
            new float[] { DistanceCalculate(108.4f), 0.6f},
            new float[] { DistanceCalculate(74.6f), 0.4f},
            new float[] { DistanceCalculate(38.8f), 0.1f},
            new float[] { DistanceCalculate(3f), 0f },
        };
        }

        public int BarCursorHeigthConvert()
        {

            temp = graphics.PreferredBackBufferHeight / barCursorHeigthFloat;

            barCursorHeigth = Convert.ToInt32(temp);
            return barCursorHeigth;
        }
        public void Init()
        {
            MakeResolutionArray();
            recSoundBar = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posSoundBar.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posSoundBar.Y), (int)sizeSoundBar.X, (int)sizeSoundBar.Y);
            recBarCursor = new Rectangle(Convert.ToInt32(arVolumes[arrayNumber][0]), BarCursorHeigthConvert(), (int)sizeBarCursor.X, (int)sizeBarCursor.Y);
            recArrowLeft = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowLeft.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowLeft.Y), (int)sizeArrow.X, (int)sizeArrow.Y);
            recArrowRight = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posArrowRight.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posArrowRight.Y), (int)sizeArrow.X, (int)sizeArrow.Y);
        }

        public void ChangeVolume(float volume)
        {
            MediaPlayer.Volume = volume;
            graphics.ApplyChanges();
        }

        public void MoveCurser(float x)
        {
            recBarCursor = new Rectangle(Convert.ToInt32(arVolumes[arrayNumber][0]), BarCursorHeigthConvert(), (int)sizeBarCursor.X, (int)sizeBarCursor.Y);
        }

        public void Update(MouseState mouse)
        {
            Rectangle mouseRec = new Rectangle((int)mouse.X, (int)mouse.Y, (int)sizeArrow.X, (int)sizeArrow.Y);
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
