using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Options_Menu
{
    class OptionsText
    {
        GraphicsDeviceManager graphics;
        Texture2D txBackground;
        Texture2D txSelectArrow;
        Texture2D txBack;
        Texture2D txKeybindings;
        SpriteFont spriteFont;

        string textHeader;
        string textSound;
        string textResolution;
        string textAlias;
        string textAliasOn;
        string textAliasOff;

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
        Vector2 sizeBack;
        Vector2 sizeKeybindings;
        Vector2 sizeSelectArrow;

        Color col;

        Rectangle recBack;
        Rectangle recSelectArrow;
        Rectangle recKeybindings;

        bool mouseReleased = true;

        float sizeW;
        float sizeH;
        float graphicW;
        float graphicH;
        float scale;

        float newPos;

        public OptionsText(StructOptionsMain structOptionsMain, StructOptionsText structOptionsText)
        {
            this.graphics = structOptionsMain.Graphics;
            this.txBackground = structOptionsText.TxBackground;
            this.txBack = structOptionsText.TxBack;
            this.txKeybindings = structOptionsText.TxKeybindings;
            this.txSelectArrow = structOptionsText.TxSelectArrow;
            this.sizeSelectArrow = structOptionsText.SizeSelectArrow;
            this.posBack = structOptionsText.PosBack;
            this.posKeybindings = structOptionsText.PosKeybindings;
            this.sizeBack = structOptionsText.SizeBack;
            this.sizeKeybindings = structOptionsText.SizeKeybindings;
            this.spriteFont = structOptionsMain.SpriteFont;

            this.textHeader = structOptionsText.TextHeader;
            this.textSound = structOptionsText.TextSound;
            this.textResolution = structOptionsText.TextResolution;
            this.textAlias = structOptionsText.TextAlias;
            this.textAliasOn = structOptionsText.TextAliasOn;
            this.textAliasOff = structOptionsText.TextAliasOff;

            this.posSound = structOptionsText.PosSound;
            this.posHeader = structOptionsText.PosHeader;
            this.posSelectArrow = structOptionsText.PosSelectArrow;
            this.posResolution = structOptionsText.PosResolution;
            this.posAlias = structOptionsText.PosAlias;
            this.posAliasOn = structOptionsText.PosAliasOn;
            this.posAliasOff = structOptionsText.PosAliasOff;

            this.col = Color.White;
            newPos = posSelectArrow.Y;
            Init();
        }

        public void Init()
        {
            graphicW = graphics.PreferredBackBufferWidth;
            graphicH = graphics.PreferredBackBufferHeight;
            sizeW = (graphics.PreferredBackBufferWidth / 900);
            sizeH = (graphics.PreferredBackBufferHeight / 500);
            recBack = new Rectangle(Convert.ToInt32(graphicW / posBack.X), Convert.ToInt32(graphicH / posBack.Y), Convert.ToInt32(sizeW * sizeBack.X), Convert.ToInt32(sizeH * sizeBack.Y));
            recKeybindings = new Rectangle(Convert.ToInt32(graphicW / posKeybindings.X), Convert.ToInt32(graphicH / posKeybindings.Y), Convert.ToInt32(sizeW * sizeKeybindings.X), Convert.ToInt32(sizeH * sizeKeybindings.Y));
            recSelectArrow = new Rectangle(Convert.ToInt32(graphicW / posSelectArrow.X), Convert.ToInt32(graphicH / newPos), Convert.ToInt32(sizeW * sizeSelectArrow.X), Convert.ToInt32(sizeH * sizeSelectArrow.Y));
            posSoundConverted = new Vector2(graphicW / posSound.X, graphicH / posSound.Y);
            posHeaderConverted = new Vector2(graphicW / posHeader.X, graphicH / posHeader.Y);
            posResolutionConverted = new Vector2(graphicW / posResolution.X, graphicH / posResolution.Y);
            posAliasConverted = new Vector2(graphicW / posAlias.X, graphicH / posAlias.Y);
            posAliasOnConverted = new Vector2(graphicW / posAliasOn.X, graphicH / posAliasOn.Y);
            posAliasOffConverted = new Vector2(graphicW / posAliasOff.X, graphicH / posAliasOff.Y);
            scale = sizeW * 1.0f;
        }

        public void UpdateSelect(int number)
        {
            
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
            }
            recSelectArrow = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posSelectArrow.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / newPos), (int)sizeSelectArrow.X, (int)sizeSelectArrow.Y);
        }

        public int Update(MouseState mouse)
        {
            Rectangle mouseRec = new Rectangle((int)mouse.X, (int)mouse.Y, recBack.Width, recBack.Height);
            if (recBack.Intersects(mouseRec))
            {
                if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
                {
                    mouseReleased = false;
                    return 2;
                }

            }
            mouseRec = new Rectangle((int)mouse.X, (int)mouse.Y, recKeybindings.Width, recKeybindings.Height);
            if (recKeybindings.Intersects(mouseRec))
            {
                if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
                {
                    mouseReleased = false;
                    return 7;
                }

            }
            if (mouse.LeftButton == ButtonState.Released)
            {
                mouseReleased = true;
            }
            return 5;
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(txBackground, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
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
