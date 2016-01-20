using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;


namespace Asteroids.Classes
{

    public class KeyBindingsMenu : Microsoft.Xna.Framework.GameComponent
    {
        GraphicsDeviceManager graphics;
        KeyBindingsContent keyBindingsContent;
        ContentManager Content;
        ControlHandler cHandler;

        public KeyBindingsMenu(GraphicsDeviceManager graphics, ContentManager Content, Game game)
            :base(game)
        {
            this.graphics = graphics;
            this.Content = Content;

            Initialize();
        }

        public override void Initialize()
        {
            cHandler = new ControlHandler();
            keyBindingsContent = new KeyBindingsContent(graphics, Content);
        }
        public void Load()
        {
            keyBindingsContent.Load();
        }

        public void Update()
        {
            keyBindingsContent.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            keyBindingsContent.Draw(spriteBatch);
        }

        public bool GetBackKeyPress()
        {
            return keyBindingsContent.GetBackKeyPress();
        }
    }
}
