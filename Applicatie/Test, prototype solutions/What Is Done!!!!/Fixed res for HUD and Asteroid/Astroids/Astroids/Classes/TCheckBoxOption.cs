using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids
{
    class TCheckBoxOption
    {
        GraphicsDeviceManager graphics;

        Texture2D txCheckedBox;
        Texture2D txUnCheckedBox;

        Texture2D txCheckBoxLeft;
        Texture2D txCheckBoxRight;

        Vector2 posLeftCheckBox;
        Vector2 posRightCheckBox;
        Vector2 vecSize;

        Color col;

        Rectangle recCheckBoxLeft;
        Rectangle recCheckBoxRight;

        bool stateCheckBoxLeft = false;
        //bool stateCheckBoxRight = true;
        bool mouseReleased = true;

        public TCheckBoxOption(GraphicsDeviceManager graphics,Texture2D txCheckedBox, Texture2D txUnCheckedBox, Vector2 posLeftCheckBox, Vector2 posRightCheckBox, Vector2 vecSize, bool stateCheckBoxLeft, Color col)
        {
            this.graphics = graphics;
            this.txCheckedBox = txCheckedBox;
            this.txUnCheckedBox = txUnCheckedBox;
            if (stateCheckBoxLeft)
            {
               // stateCheckBoxRight = false;
                this.txCheckBoxLeft = txCheckedBox;
                this.txCheckBoxRight = txUnCheckedBox;
            }
            else
            {
                stateCheckBoxLeft = true;
                this.txCheckBoxLeft = txUnCheckedBox;
                this.txCheckBoxRight = txCheckedBox;
            }
            this.posLeftCheckBox = posLeftCheckBox;
            this.posRightCheckBox = posRightCheckBox;
            this.vecSize = vecSize;
            this.col = col;
            Init();


        }

        public void Init()
        {
            recCheckBoxLeft = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posLeftCheckBox.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posLeftCheckBox.Y), (int)vecSize.X, (int)vecSize.Y);
            recCheckBoxRight = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posRightCheckBox.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posRightCheckBox.Y), (int)vecSize.X, (int)vecSize.Y);
        }

        public void SelectLeftRight()
        {
            mouseReleased = false;
            CheckBoxClick();
        }

        public void AntiAliasingCheck()
        {
            graphics.PreferMultiSampling = stateCheckBoxLeft;
            graphics.ApplyChanges();
        }


        public void CheckBoxClick()
        {
            if (stateCheckBoxLeft == true)
            {
                stateCheckBoxLeft = false;
                //stateCheckBoxRight = true;
                txCheckBoxLeft = txUnCheckedBox;
                txCheckBoxRight = txCheckedBox;
                AntiAliasingCheck();
            }
            else
            {
                stateCheckBoxLeft = true;
                //stateCheckBoxRight = false;
                txCheckBoxLeft = txCheckedBox;
                txCheckBoxRight = txUnCheckedBox;
                AntiAliasingCheck();
            }

                
        }

        public void SelectedCheck(bool isSelected)
        {
            if (isSelected)
            {
                CheckBoxClick();
            }
        }

        public void Update(MouseState mouse)
        {
            Rectangle mouseRec = new Rectangle((int)mouse.X, (int)mouse.Y, (int)vecSize.X, (int)vecSize.Y);
            if (recCheckBoxLeft.Intersects(mouseRec) || recCheckBoxRight.Intersects(mouseRec))
            {
                if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
                {
                    mouseReleased = false;
                    CheckBoxClick();
                }

            }
            if (mouse.LeftButton == ButtonState.Released)
            {
                mouseReleased = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(txCheckBoxLeft, recCheckBoxLeft, col);
            spriteBatch.Draw(txCheckBoxRight, recCheckBoxRight, col);
            spriteBatch.End();
        }
    }
}
