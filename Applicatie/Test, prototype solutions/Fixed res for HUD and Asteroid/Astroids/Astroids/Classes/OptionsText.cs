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
        GraphicsDeviceManager graphics;
        Texture2D txBackground;
        Texture2D txSelectArrow;
        Texture2D txBack;
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
        Vector2 sizeSelectArrow;

        Color col;

        Rectangle recBack;
        Rectangle recSelectArrow;

        bool mouseReleased = true;

        float newPos;

        public OptionsText(GraphicsDeviceManager graphics, Texture2D txBackground, Texture2D txBack, Vector2 posBack, Vector2 sizeBack, Texture2D txSelectArrow, Vector2 posSelectArrow, Vector2 sizeSelectArrow, SpriteFont spriteFont, string textHeader, Vector2 posHeader, string textSound, Vector2 posSound, string textResolution, Vector2 posResolution, string textAlias, Vector2 posAlias, string textAliasOn, Vector2 posAliasOn, string textAliasOff, Vector2 posAliasOff, Color col)
        {
            this.graphics = graphics;
            this.txBackground = txBackground;
            this.txBack = txBack;
            this.txSelectArrow = txSelectArrow;
            this.sizeSelectArrow = sizeSelectArrow;
            this.posBack = posBack;
            this.sizeBack = sizeBack;
            this.spriteFont = spriteFont;

            this.textHeader = textHeader;
            this.textSound = textSound;
            this.textResolution = textResolution;
            this.textAlias = textAlias;
            this.textAliasOn = textAliasOn;
            this.textAliasOff = textAliasOff;

            this.posSound = posSound;
            this.posHeader = posHeader;
            this.posSelectArrow = posSelectArrow;
            this.posResolution = posResolution;
            this.posAlias = posAlias;
            this.posAliasOn = posAliasOn;
            this.posAliasOff = posAliasOff;

            this.col = col;
            newPos = posSelectArrow.Y;
            Init();
        }

        public void Init()
        {
            recBack = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posBack.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posBack.Y), (int)sizeBack.X, (int)sizeBack.Y);
            recSelectArrow = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posSelectArrow.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / newPos), (int)sizeSelectArrow.X, (int)sizeSelectArrow.Y);
            posSoundConverted = new Vector2(graphics.PreferredBackBufferWidth / posSound.X, graphics.PreferredBackBufferHeight / posSound.Y);
            posHeaderConverted = new Vector2(graphics.PreferredBackBufferWidth / posHeader.X, graphics.PreferredBackBufferHeight / posHeader.Y);
            posResolutionConverted = new Vector2(graphics.PreferredBackBufferWidth / posResolution.X, graphics.PreferredBackBufferHeight / posResolution.Y);
            posAliasConverted = new Vector2(graphics.PreferredBackBufferWidth / posAlias.X, graphics.PreferredBackBufferHeight / posAlias.Y);
            posAliasOnConverted = new Vector2(graphics.PreferredBackBufferWidth / posAliasOn.X, graphics.PreferredBackBufferHeight / posAliasOn.Y);
            posAliasOffConverted = new Vector2(graphics.PreferredBackBufferWidth / posAliasOff.X, graphics.PreferredBackBufferHeight / posAliasOff.Y);
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
                        newPos = posSelectArrow.Y - 0.68f;
                        break;
                    }
                case 2:
                    {
                        newPos = posSelectArrow.Y - 1.15f;
                        break;
                    }
                case 3:
                    {
                        newPos = posSelectArrow.Y - 1.4f;
                        break;
                    }
            }
            recSelectArrow = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posSelectArrow.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / newPos), (int)sizeSelectArrow.X, (int)sizeSelectArrow.Y);
        }

        public bool Update(MouseState mouse)
        {
            Rectangle mouseRec = new Rectangle((int)mouse.X, (int)mouse.Y, (int)sizeBack.X, (int)sizeBack.Y);
            if (recBack.Intersects(mouseRec))
            {
                if (mouse.LeftButton == ButtonState.Pressed && mouseReleased == true)
                {
                    mouseReleased = false;
                    return true;
                }

            }
            if (mouse.LeftButton == ButtonState.Released)
            {
                mouseReleased = true;
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(txBackground, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.Draw(txBack, recBack, Color.White);
            spriteBatch.Draw(txSelectArrow, recSelectArrow, Color.White);
            spriteBatch.DrawString(spriteFont, textHeader, posHeaderConverted, col);
            spriteBatch.DrawString(spriteFont, textResolution, posResolutionConverted, col);
            spriteBatch.DrawString(spriteFont, textSound, posSoundConverted, col);
            spriteBatch.DrawString(spriteFont, textAlias, posAliasConverted, col);
            spriteBatch.DrawString(spriteFont, textAliasOn, posAliasOnConverted, col);
            spriteBatch.DrawString(spriteFont, textAliasOff, posAliasOffConverted, col);
            spriteBatch.End();
        }
    }
}
