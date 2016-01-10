using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Options_Menu
{
    class TCheckBoxOption
    {
        GraphicsDeviceManager graphics;

        Texture2D txCheckedBox;
        Texture2D txUnCheckedBox;

        Texture2D txCheckBoxLeft;
        Texture2D txCheckBoxRight;

        Vector2 PosCheckBoxLeft;
        Vector2 PosCheckBoxRight;
        Vector2 vecSizeCheckBox;

        Color col;

        Rectangle recCheckBoxLeft;
        Rectangle recCheckBoxRight;
        float sizeW;
        float sizeH;
        bool stateCheckBoxLeft = false;
        //bool stateCheckBoxRight = true;
        bool mouseReleased = true;

        public TCheckBoxOption(StructOptionsMain structOptionsMain, StructCheckBox structCheckBox)
        {
            this.graphics = structOptionsMain.Graphics;
            this.txCheckedBox = structCheckBox.TxCheckedBox;
            this.txUnCheckedBox = structCheckBox.TxUnCheckedBox;
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
            this.PosCheckBoxLeft = structCheckBox.PosCheckBoxLeft;
            this.PosCheckBoxRight = structCheckBox.PosCheckBoxRight;
            this.vecSizeCheckBox = structCheckBox.VecSizeCheckBox;
            this.col = Color.White;
            Init();


        }

        public void Init()
        {
            
            sizeW = (graphics.PreferredBackBufferWidth / 900);
            sizeH = (graphics.PreferredBackBufferHeight / 500);
            recCheckBoxLeft = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / PosCheckBoxLeft.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / PosCheckBoxLeft.Y), Convert.ToInt32(sizeW * vecSizeCheckBox.X), Convert.ToInt32(sizeH * vecSizeCheckBox.Y));
            recCheckBoxRight = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / PosCheckBoxRight.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / PosCheckBoxRight.Y), Convert.ToInt32(sizeW * vecSizeCheckBox.X), Convert.ToInt32(sizeH * vecSizeCheckBox.Y));
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
            Rectangle mouseRec = new Rectangle((int)mouse.X, (int)mouse.Y, recCheckBoxLeft.Width, recCheckBoxLeft.Height);
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

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(txCheckBoxLeft, recCheckBoxLeft, col);
            sprite.Draw(txCheckBoxRight, recCheckBoxRight, col);
        }
    }
}
