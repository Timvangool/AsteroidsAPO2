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
        SpriteFont fontSegoeUIMono;
        SpriteFont scoreFont;
        SpriteFont loadingScreenFont;
        public int loadedItems;
        public int totalItems = 0;
        const int sleepTime = 300;

        //Player p = new Player();
       // HUD hud = new HUD();
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
            totalItems = 7;
#if FakeLoading
            totalItems = 35;

#endif
            //p = PlayerTexture("player textures");
            yield return progress();
#if FakeLoading
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(2000);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
#endif

            basicBullet = BasicBulletTexture("basic bullet textures");
            yield return progress();
#if FakeLoading
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
#endif
            missile = MissileTexture("missile textures");
            yield return progress();
#if FakeLoading
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(2000);
            yield return progress();
            Thread.Sleep(sleepTime);
#endif
            ast = asteroidTexture("asteroid textures");
            yield return progress();
#if FakeLoading
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(2000);
#endif
            //hud = IHUD("HUD");
            yield return progress();
#if FakeLoading
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
#endif
            fontSegoeUIMono = content.Load<SpriteFont>("Font");
            yield return progress();
#if FakeLoading
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
#endif
            scoreFont = content.Load<SpriteFont>("Score");
            yield return progress();
#if FakeLoading
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(sleepTime);
            yield return progress();
            Thread.Sleep(3000);
            //System.Windows.Forms.DialogResult windirResult = System.Windows.Forms.MessageBox.Show("Do you really want to delete System32 in " + Environment.GetEnvironmentVariable("windir"), "Removing System32", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);
            //if (windirResult == System.Windows.Forms.DialogResult.Yes)
            //{
            //    System.Windows.Forms.MessageBox.Show("System32 has been deleted in " + Environment.GetEnvironmentVariable("windir"), "Removing System32", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            //    if (windirResult == System.Windows.Forms.DialogResult.OK)
            //    {
            //        Game1.ExitGame.Exit();
            //    }
            //}
            //else
            //Game1.ExitGame.Exit();


            yield return progress();
            Thread.Sleep(sleepTime);
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
            //p.Load(content);
            return null;
        }

        HUD IHUD(string name)
        {
#if FakeLoading
            actBusy(name.Length);
#endif
            //hud.Load(content);
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
            //missile.Load(content);
            return null;
        }

        BasicBullet BasicBulletTexture(string name)
        {
#if FakeLoading
            actBusy(name.Length);
#endif
            //basicBullet.Load(content);
            return null;
        }

#if FakeLoading
        void actBusy(int howBusy) 
        {
            Thread.Sleep(300 * howBusy);
        }
#endif
    }
}
