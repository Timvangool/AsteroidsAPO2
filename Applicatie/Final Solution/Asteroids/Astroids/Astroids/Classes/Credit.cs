using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Asteroids.Classes
{
    class Credit : Microsoft.Xna.Framework.Game
    {
        string output;
        string title;
        
        //Font Properties
        SpriteFont fontType;
        Vector2 fontPos;
        Vector2 fontPosTitle;
        Vector2 fontOriginTitle;
        Vector2 fontOrigin;

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                fontPosTitle.Y -= 1.5f;
                fontPos.Y -= 1.5f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                fontPosTitle.Y += 3.0f;
                fontPos.Y += 3.0f;
            }
        }

        public void Load(ContentManager content, GraphicsDeviceManager graphics)
        {
            fontType = content.Load<SpriteFont>("Courier New");
            //Text
            fontOriginTitle.Y = -graphics.GraphicsDevice.Viewport.Height / 2 - 20;
            fontOriginTitle.X = graphics.GraphicsDevice.Viewport.Width / 3;

            fontOrigin.Y = -graphics.GraphicsDevice.Viewport.Height / 2 - 40;
            fontOrigin.X = graphics.GraphicsDevice.Viewport.Width / 2.6f;
            fontPosTitle = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 75,
                graphics.GraphicsDevice.Viewport.Height / 2);
            fontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - 30,
                graphics.GraphicsDevice.Viewport.Height / 2);
        }

        public void IntroText()
        {
                title = "JUST ANOTHER CREDITS SCREEN";
                fontPosTitle.Y -= 0.5f;
                fontPos.Y -= 0.5f;

                output = @"


Cyka Shpinat Productions


Team Members:

Yannick van Dolen,
    Project Lead,
    Git Manager

Thijmen Boot,
    Notulist,
    Git Manager

Rudyard 'Jeebes' Meijsen,
    Project Lead,
    Notulist

Steven Logghe,
    Visual Designer

Tarik Hacialiogullari,
    Code Manager,
    Git Manager

Patrick van Batenburg,
    Git Manager

Thom 'Skarin' Martens,
    Project Lead,
    Code Manager

Tim van Gool,
    Project Lead,
    Notulist

Floris 'MadBro' van Broekhoven,
    Code Manager

Kees 'GunWolf' Elsman,
    Notulist,
    Code Manager


THANKS FOR PLAYING!

Press E to EXIT.

";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw String
            spriteBatch.DrawString(fontType, title, fontPosTitle, Color.Yellow, 0, fontOriginTitle, 1.0f, SpriteEffects.None, 0.65f);
            spriteBatch.DrawString(fontType, output, fontPos, Color.Yellow, 0, fontOrigin, 1.0f, SpriteEffects.None, 0.65f);
        }
    }
}
