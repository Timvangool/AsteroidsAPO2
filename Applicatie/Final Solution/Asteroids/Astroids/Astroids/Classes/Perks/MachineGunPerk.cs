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

namespace Asteroids.Classes.Perks
{
    class MachineGunPerk : Perk
    {
        private ContentManager content;
        private Player p;
        private SpriteFont font;
        private int framesElapsed, maxFrames;

        public MachineGunPerk()
        { }

        public MachineGunPerk(ContentManager content, Player p)
        {
            this.content = content;
            this.p = p;
            maxFrames = 180;
        }

        public override void Activate()
        {
            p.SetMaxDelay(10);
        }

        public override void Draw(SpriteBatch batch)
        {
            if (framesElapsed != maxFrames)
            {
                batch.DrawString(font, "Picked up : Machinegun Perk", new Vector2(250, 20), Color.Yellow);
                framesElapsed++;
            }
        }

        public override void Load()
        {
            font = content.Load<SpriteFont>("LoadingScreen");
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
