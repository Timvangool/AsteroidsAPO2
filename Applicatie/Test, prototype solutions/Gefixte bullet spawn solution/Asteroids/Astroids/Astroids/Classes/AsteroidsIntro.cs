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
A long time ago in a galaxy 
far, far away....

There was a 2nd Corporal Space 
Meteor Destroyer called Dimitri.
He lived on Spacestation DS9.
He had a normal life and a 
normal job.
But then the station got attacked
by aliens.
The space station slowly got
destroyed.
But Dimitri escaped
from the station in a small
spaceship.
Now Dimitri is on his way
to another Space Staion/Planet
in search for safety.

Will he survive the dangers
of outer space?

And will he ever see 
civilisation again?





















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



Congratulations!!!
You've endured the Waiting
Exam!!!!

You are now ready to play a
game full of awesomeness
and Spaceness

Good luck, we'll see you on 
the other side.




System Message: 
The key to exit this video 
is to press E
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
