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
        //GRAPHICS
        GraphicsDeviceManager graphics;

        //TEXTURES
        Texture2D txCheckedBox;
        Texture2D txUnCheckedBox;
        Texture2D txCheckBoxLeft;
        Texture2D txCheckBoxRight;

        //TEXTURES POSITIONS
        Vector2 PosCheckBoxLeft;
        Vector2 PosCheckBoxRight;

        //TEXTURES SIZES
        Vector2 vecSizeCheckBox;

        //COLOUR
        Color col;

        //TEXTURES RECTANGLES
        Rectangle recCheckBoxLeft;
        Rectangle recCheckBoxRight;

        //VARIABLES
        float sizeW;
        float sizeH;
        bool stateCheckBoxLeft = false;

        public TCheckBoxOption(Game1.StructOptionsMain structOptionsMain, StructCheckBox structCheckBox)
        {
            //GRAPHICS
            this.graphics = structOptionsMain.Graphics;

            //TEXTURES
            this.txCheckedBox = structCheckBox.TxCheckedBox;
            this.txUnCheckedBox = structCheckBox.TxUnCheckedBox;
            if (stateCheckBoxLeft)
            {
                this.txCheckBoxLeft = txCheckedBox;
                this.txCheckBoxRight = txUnCheckedBox;
            }
            else
            {
                stateCheckBoxLeft = true;
                this.txCheckBoxLeft = txUnCheckedBox;
                this.txCheckBoxRight = txCheckedBox;
            }

            //TEXTURES POSITIONS
            this.PosCheckBoxLeft = structCheckBox.PosCheckBoxLeft;
            this.PosCheckBoxRight = structCheckBox.PosCheckBoxRight;

            //TEXTURES SIZES
            this.vecSizeCheckBox = structCheckBox.VecSizeCheckBox;

            //COLOUR
            this.col = Color.White;

            //INITIALIZE
            Init();
        }

        public void Init()
        {
            //SCREEN SCALE
            float graphicsW = graphics.PreferredBackBufferWidth;
            float graphicsH = graphics.PreferredBackBufferHeight;
            sizeW = (graphicsW / 900);
            sizeH = (graphicsH / 500);

            //RECTANGLES
            int recCheckBoxLeftX = Convert.ToInt32(graphicsW / PosCheckBoxLeft.X);
            int recCheckBoxY = Convert.ToInt32(graphicsH / PosCheckBoxLeft.Y);
            int recCheckBoxWidth = Convert.ToInt32(sizeW * vecSizeCheckBox.X);
            int recCheckBoxHeigth = Convert.ToInt32(sizeH * vecSizeCheckBox.Y);
            int recCheckBoxRightX = Convert.ToInt32(graphicsW / PosCheckBoxRight.X);
            recCheckBoxLeft = new Rectangle(recCheckBoxLeftX, recCheckBoxY, recCheckBoxWidth, recCheckBoxHeigth);
            recCheckBoxRight = new Rectangle(recCheckBoxRightX, recCheckBoxY, recCheckBoxWidth, recCheckBoxHeigth);
        }

        public void SelectLeftRight()
        {
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
                txCheckBoxLeft = txUnCheckedBox;
                txCheckBoxRight = txCheckedBox;
                AntiAliasingCheck();
            }
            else
            {
                stateCheckBoxLeft = true;
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

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(txCheckBoxLeft, recCheckBoxLeft, col);
            sprite.Draw(txCheckBoxRight, recCheckBoxRight, col);
        }
    }
}
