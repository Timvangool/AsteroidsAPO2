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
        Texture2D txBack;
        SpriteFont spriteFont;

        string textHeader;
        string textSound;
        string textResolution;
        string textAlias;
        string textAliasOn;
        string textAliasOff;

        Vector2 posBack;
        Vector2 posHeader;
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

        Color col;

        Rectangle recBack;

        bool mouseReleased = true;

        public OptionsText(GraphicsDeviceManager graphics, Texture2D txBackground, Texture2D txBack, Vector2 posBack, Vector2 sizeBack, SpriteFont spriteFont, string textHeader, Vector2 posHeader, string textSound, Vector2 posSound, string textResolution, Vector2 posResolution, string textAlias, Vector2 posAlias, string textAliasOn, Vector2 posAliasOn, string textAliasOff, Vector2 posAliasOff, Color col)
        {
            this.graphics = graphics;
            this.txBackground = txBackground;
            this.txBack = txBack;
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
            this.posResolution = posResolution;
            this.posAlias = posAlias;
            this.posAliasOn = posAliasOn;
            this.posAliasOff = posAliasOff;

            this.col = col;
            Init();
        }

        public void Init()
        {
            recBack = new Rectangle(Convert.ToInt32(graphics.PreferredBackBufferWidth / posBack.X), Convert.ToInt32(graphics.PreferredBackBufferHeight / posBack.Y), (int)sizeBack.X, (int)sizeBack.Y);
            posSoundConverted = new Vector2(graphics.PreferredBackBufferWidth / posSound.X, graphics.PreferredBackBufferHeight / posSound.Y);
            posHeaderConverted = new Vector2(graphics.PreferredBackBufferWidth / posHeader.X, graphics.PreferredBackBufferHeight / posHeader.Y);
            posResolutionConverted = new Vector2(graphics.PreferredBackBufferWidth / posResolution.X, graphics.PreferredBackBufferHeight / posResolution.Y);
            posAliasConverted = new Vector2(graphics.PreferredBackBufferWidth / posAlias.X, graphics.PreferredBackBufferHeight / posAlias.Y);
            posAliasOnConverted = new Vector2(graphics.PreferredBackBufferWidth / posAliasOn.X, graphics.PreferredBackBufferHeight / posAliasOn.Y);
            posAliasOffConverted = new Vector2(graphics.PreferredBackBufferWidth / posAliasOff.X, graphics.PreferredBackBufferHeight / posAliasOff.Y);
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

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(txBackground, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            sprite.Draw(txBack, recBack, Color.White);
            sprite.DrawString(spriteFont, textHeader, posHeaderConverted, col);
            sprite.DrawString(spriteFont, textResolution, posResolutionConverted, col);
            sprite.DrawString(spriteFont, textSound, posSoundConverted, col);
            sprite.DrawString(spriteFont, textAlias, posAliasConverted, col);
            sprite.DrawString(spriteFont, textAliasOn, posAliasOnConverted, col);
            sprite.DrawString(spriteFont, textAliasOff, posAliasOffConverted, col);
        }
    }
}
