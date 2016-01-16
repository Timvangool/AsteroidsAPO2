using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids
{
    class OptionsText
    {
        //GRAPHICS
        GraphicsDeviceManager graphics;

        //TEXTURES
        Texture2D txBackground;
        Texture2D txSelectArrow;
        Texture2D txBack;
        Texture2D txKeybindings;
        SpriteFont spriteFont;

        //TEXTS
        string textHeader;
        string textSound;
        string textResolution;
        string textAlias;
        string textAliasOn;
        string textAliasOff;

        //POSITIONS
        Vector2 posHeader;
        Vector2 posSelectArrow;
        Vector2 posBack;
        Vector2 posKeybindings;
        Vector2 posSound;
        Vector2 posResolution;
        Vector2 posAlias;
        Vector2 posAliasOn;
        Vector2 posAliasOff;
        Vector2 posHeaderConverted;
        Vector2 posSoundConverted;
        Vector2 posResolutionConverted;
        Vector2 posAliasConverted;
        Vector2 posAliasOnConverted;
        Vector2 posAliasOffConverted;

        //TEXTURES SIZES
        Vector2 sizeBack;
        Vector2 sizeKeybindings;
        Vector2 sizeSelectArrow;

        //COLOUR
        Color col;

        //TEXTURES RECTANGLES
        Rectangle recBack;
        Rectangle recSelectArrow;
        Rectangle recKeybindings;

        //VARIABLES
        float sizeW;
        float sizeH;
        float scale;
        float newPos;
        int menuState;

        public OptionsText(Game1.StructOptionsMain structOptionsMain, StructOptionsText structOptionsText)
        {
            //GRAPHICS
            this.graphics = structOptionsMain.Graphics;

            //TEXTURES
            this.txBackground = structOptionsText.TxBackground;
            this.txBack = structOptionsText.TxBack;
            this.txKeybindings = structOptionsText.TxKeybindings;
            this.txSelectArrow = structOptionsText.TxSelectArrow;

            //TEXTURES POSITIONS
            this.posKeybindings = structOptionsText.PosKeybindings;
            this.posBack = structOptionsText.PosBack;

            //TEXTURES SIZES
            this.sizeSelectArrow = structOptionsText.SizeSelectArrow;
            this.sizeBack = structOptionsText.SizeBack;
            this.sizeKeybindings = structOptionsText.SizeKeybindings;
            this.spriteFont = structOptionsMain.SpriteFont;

            //TEXTS
            this.textHeader = structOptionsText.TextHeader;
            this.textSound = structOptionsText.TextSound;
            this.textResolution = structOptionsText.TextResolution;
            this.textAlias = structOptionsText.TextAlias;
            this.textAliasOn = structOptionsText.TextAliasOn;
            this.textAliasOff = structOptionsText.TextAliasOff;

            //TEXTS POSITIONS
            this.posSound = structOptionsText.PosSound;
            this.posHeader = structOptionsText.PosHeader;
            this.posSelectArrow = structOptionsText.PosSelectArrow;
            this.posResolution = structOptionsText.PosResolution;
            this.posAlias = structOptionsText.PosAlias;
            this.posAliasOn = structOptionsText.PosAliasOn;
            this.posAliasOff = structOptionsText.PosAliasOff;
            
            //COLOUR
            this.col = Color.White;

            //INITIALIZE
            newPos = posSelectArrow.Y;
            Init();
        }

        public void Init()
        {
            //SCREEN SIZE
            float graphicsW = graphics.PreferredBackBufferWidth;
            float graphicsH = graphics.PreferredBackBufferHeight;
            sizeW = (graphicsW / 900);
            sizeH = (graphicsH / 500);

            //RECTANGLE BACK
            int recBackX = Convert.ToInt32(graphicsW / posBack.X);
            int recBackY = Convert.ToInt32(graphicsH / posBack.Y);
            int recBackWidth = Convert.ToInt32(sizeW * sizeBack.X);
            int recBackHeight = Convert.ToInt32(sizeH * sizeBack.Y);
            recBack = new Rectangle(recBackX, recBackY, recBackWidth, recBackHeight);

            //RECTANGLE KEYBINDINGS
            int recKeybidingsX = Convert.ToInt32(graphicsW / posKeybindings.X);
            int recKeybindingsY = Convert.ToInt32(graphicsH / posKeybindings.Y);
            int recKeybidingsWidth = Convert.ToInt32(sizeW * sizeKeybindings.X);
            int recKeybindingsHeigth = Convert.ToInt32(sizeH * sizeKeybindings.Y);
            recKeybindings = new Rectangle(recKeybidingsX, recKeybindingsY, recKeybidingsWidth, recKeybindingsHeigth);

            //RECTANGLE SELECTARROW
            int recSelectArrowX = Convert.ToInt32(graphicsW / posSelectArrow.X);
            int recSelectArrowY = Convert.ToInt32(graphicsH / newPos);
            int recSelectArrowWidth = Convert.ToInt32(sizeW * sizeSelectArrow.X);
            int recSelectArrowHeigth = Convert.ToInt32(sizeH * sizeSelectArrow.Y);
            recSelectArrow = new Rectangle(recSelectArrowX, recSelectArrowY, recSelectArrowWidth, recSelectArrowHeigth);

            //POSITIONS
            posSoundConverted = new Vector2(graphicsW / posSound.X, graphicsH / posSound.Y);
            posHeaderConverted = new Vector2(graphicsW / posHeader.X, graphicsH / posHeader.Y);
            posResolutionConverted = new Vector2(graphicsW / posResolution.X, graphicsH / posResolution.Y);
            posAliasConverted = new Vector2(graphicsW / posAlias.X, graphicsH / posAlias.Y);
            posAliasOnConverted = new Vector2(graphicsW / posAliasOn.X, graphicsH / posAliasOn.Y);
            posAliasOffConverted = new Vector2(graphicsW / posAliasOff.X, graphicsH / posAliasOff.Y);

            //SCALE
            scale = sizeW * 0.4f;
        }

        public void UpdateSelect(int number)
        {
            menuState = number;
            switch (number)
            {
                case 0:
                    {
                        newPos = posSelectArrow.Y;
                        break;
                    }
                case 1:
                    {
                        newPos = posSelectArrow.Y - 0.72f;
                        break;
                    }
                case 2:
                    {
                        newPos = posSelectArrow.Y - 1.28f;
                        break;
                    }
                case 3:
                    {
                        newPos = posSelectArrow.Y - 1.52f;
                        break;
                    }
                case 4:
                    {
                        newPos = posSelectArrow.Y - 1.78f;
                        break;
                    }
                default:
                    {
                        System.Windows.Forms.MessageBox.Show("Oops, something failed with the Selection.");
                        break;
                    }
            }
            int newPosition = Convert.ToInt32((float)graphics.PreferredBackBufferHeight / newPos);
            recSelectArrow = new Rectangle(recSelectArrow.X, newPosition, recSelectArrow.Width, recSelectArrow.Height);
        }

        public int GetMenuState()
        {
            return menuState;
        }


        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(txBack, recBack, Color.White);
            sprite.Draw(txKeybindings, recKeybindings, Color.White);
            sprite.Draw(txSelectArrow, recSelectArrow, Color.White);
            sprite.DrawString(spriteFont, textHeader, posHeaderConverted, col, 0, Vector2.Zero, scale, SpriteEffects.None, 0f);
            sprite.DrawString(spriteFont, textResolution, posResolutionConverted, col, 0, Vector2.Zero, scale, SpriteEffects.None, 0f);
            sprite.DrawString(spriteFont, textSound, posSoundConverted, col, 0, Vector2.Zero, scale, SpriteEffects.None, 0f);
            sprite.DrawString(spriteFont, textAlias, posAliasConverted, col, 0, Vector2.Zero, scale, SpriteEffects.None, 0f);
            sprite.DrawString(spriteFont, textAliasOn, posAliasOnConverted, col, 0, Vector2.Zero, scale, SpriteEffects.None, 0f);
            sprite.DrawString(spriteFont, textAliasOff, posAliasOffConverted, col, 0, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}
