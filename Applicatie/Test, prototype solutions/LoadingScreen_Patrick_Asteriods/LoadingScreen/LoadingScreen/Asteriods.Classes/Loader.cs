#define FakeLoading
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Asteroids.Classes;

namespace Asteroids.Classes
{
    class Loader : IEnumerable<float> 
    {
        ContentManager content;
        int loadedItems = 0;
        int totalItems = 0;

        SpriteFont fontSegoeUIMono;
        SpriteFont fontImpact;
        Player p = new Player();
        HUD hud = new HUD();
        BasicBullet basicBullet = new BasicBullet();
        Missile missile = new Missile();
        Asteroid ast = new Asteroid();

        public Loader(ContentManager content) 
        {
            this.content = content;
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }

        public IEnumerator<float> GetEnumerator() 
        {
            totalItems = 30;

            Debug.WriteLine("Loading player textures");
            p = PlayerTexture("player textures");

            Debug.WriteLine("Loading basic bullet textures");
            basicBullet = BasicBulletTexture("basic bullet textures");
            yield return progress();
#if FakeLoading
            yield return progress();
            yield return progress();
            yield return progress();
            yield return progress();
#endif
            Debug.WriteLine("Loading missile textures");
            missile = MissileTexture("missile textures");
            yield return progress();
#if FakeLoading
            yield return progress();
            yield return progress();
            yield return progress();
            yield return progress();
#endif
            Debug.WriteLine("Loading asteroid textures");
            ast = asteroidTexture("asteroid textures");
            yield return progress();
#if FakeLoading
            yield return progress();
            yield return progress();
            yield return progress();
            yield return progress();
#endif

            Debug.WriteLine("Loading HUD");
            hud = IHUD("HUD");
            yield return progress();
#if FakeLoading
            yield return progress();
            yield return progress();
            yield return progress();
            yield return progress();
#endif

            Debug.WriteLine("Loading Segoe UI Mono font");
            fontSegoeUIMono = content.Load<SpriteFont>("Font");
            yield return progress();
#if FakeLoading
            yield return progress();
            yield return progress();
            yield return progress();
            yield return progress();
#endif

            Debug.WriteLine("Loading Impact font");
            fontImpact = content.Load<SpriteFont>("Score");
            yield return progress();
#if FakeLoading
            yield return progress();
            yield return progress();
            yield return progress();
            yield return progress();
#endif

            string loadedCheckMessage = String.Format("Loaded {0} items. Expected {1} items.", loadedItems, totalItems);
            Debug.WriteLine(loadedCheckMessage);
            if (loadedItems == totalItems)
            {
            }
            else
            {
                System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show(loadedCheckMessage, "Failed loading components", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Game1.ExitGame.Exit();
                    //Debug.Assert(loadedItems == totalItems, "Components failed loading.\n", loadedCheckMessage);
                }
            }
            yield return 1;
        }

        float progress() 
        {
            ++loadedItems;
            return (float)loadedItems / totalItems;
        }

        Player PlayerTexture(string name)
        {
#if FakeLoading
            actBusy(name.Length);
#endif
            p.Load(content);
            return null;
        }

        HUD IHUD(string name)
        {
#if FakeLoading
            actBusy(name.Length);
#endif
            hud.Load(content);
            return null;
        }

        Asteroid asteroidTexture(string name)
        {
#if FakeLoading
            actBusy(name.Length);
#endif
            ast.Load(content);
            return null;
        }

        Missile MissileTexture(string name)
        {
#if FakeLoading
            actBusy(name.Length);
#endif
            missile.Load(content);
            return null;
        }

        BasicBullet BasicBulletTexture(string name)
        {
#if FakeLoading
            actBusy(name.Length);
#endif
            basicBullet.Load(content);
            return null;
        }

#if FakeLoading
        void actBusy(int howBusy) 
        {
            Thread.Sleep(500*howBusy);
        }
#endif
    }
}
