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

namespace Asteroids.Classes.Perks
{
    class SpeedUpPerk : Perk
    {
        private ContentManager content;
        private Player p;
        private SpriteFont font;
        private int framesElapsed, maxFrames;

        public SpeedUpPerk()
        { }

        public SpeedUpPerk(ContentManager content, Player p)
        {
            this.content = content;
            this.p = p;
            maxFrames = 180;
        }

        public override void Activate()
        {
            p.SetMaxSpeed(5.0f);
        }

        public override void Load()
        {
            font = content.Load<SpriteFont>("LoadingScreen");
        }

        public override void Draw(SpriteBatch batch)
        {
            if (framesElapsed != maxFrames)
            {
                batch.DrawString(font, "Picked up : Speed up Perk", new Vector2(250, 20), Color.Yellow);
                framesElapsed++;
            }
        }

        public override void Update()
        {

        }

        public void SetElapsedFrames(int elapsedFrames)
        {
            this.framesElapsed = elapsedFrames;
        }

    }
}
