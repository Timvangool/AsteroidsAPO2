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
    class AsteroidsIntro : Microsoft.Xna.Framework.Game
    {
        string output;
        string title;
        
        ////Font Properties
        SpriteFont fontType;
        Vector2 fontPos;
        Vector2 fontPosTitle;
        Vector2 fontOriginTitle;
        Vector2 fontOrigin;

        public AsteroidsIntro()
        {

        }

        public void Load(ContentManager content, GraphicsDeviceManager graphics)
        {
            fontType = content.Load<SpriteFont>("Courier New");
            //Text
            fontOriginTitle.Y = -graphics.GraphicsDevice.Viewport.Height / 2 - 20;
            fontOriginTitle.X = graphics.GraphicsDevice.Viewport.Width / 3;

            fontOrigin.Y = -graphics.GraphicsDevice.Viewport.Height / 2 - 40;
            fontOrigin.X = graphics.GraphicsDevice.Viewport.Width / 2.6f;
            fontPosTitle = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                graphics.GraphicsDevice.Viewport.Height / 2);
            fontPos = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                graphics.GraphicsDevice.Viewport.Height / 2);
        }

        public void IntroText()
        {
                title = "JUST ANOTHER ASTEROIDS GAME";
                fontPosTitle.Y -= 0.5f;
                fontPos.Y -= 0.5f;

                output = @"


2nd Corporal Dimitri had just gotten the word
That spacestation DS9 was being attacked by Aliens

The Aliens had used their advanced technology
To slingshot a whole belt of astroids
into the spacestation: DS9

It is now Dimitri's job to destroy the astroids
And any alien blocking his path
before the Astroids reach the spacestation

Dimitri retracted his landing gear
and took off into the distance

Will he save DS9?
Will he return safely?





















You're still waiting right?








Did you try to press the 
Spacebar?


You just tried that didnt you......


Ok, I'll give you a hint....
It's not the Escape button!!

90% of the people who played
this game experienced the power
of Esc.

The other 10% are smart 
enough not to listen to some
text that appears in their
screen.



Good luck, we'll see you on 
the other side.




Oh... yeah... In case you haven't tried 
every key on your keyboard yet..

To skip this press E
";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw String
            spriteBatch.DrawString(fontType, title, fontPosTitle, Color.Yellow, 0, fontOriginTitle, 1.0f, SpriteEffects.None, 0.65f);
            spriteBatch.DrawString(fontType, output, fontPos, Color.Yellow, 0, fontOrigin, 1.0f, SpriteEffects.None, 0.65f);
            spriteBatch.DrawString(fontType, fontPos.Y.ToString(), new Vector2(10, 10), Color.White);
        }
    }
}
