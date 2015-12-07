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
        public SpriteFont font;
        List<Asteroid>asteroidList = new List<Asteroid>();
        List<Asteroid>asteroid= new List<Asteroid>();
        List<Asteroid>newAsteroidList = new List<Asteroid>();
        List<Weapon> killListWep = new List<Weapon>();
        Player p = new Player();
        HUD hud = new HUD();
        Weapon wep;

        ContentManager content;
        int loadedItems = 0;
        int totalItems;

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
            totalItems = 4;

            Debug.WriteLine("Loading player textures");
            p = PlayerTexture("player textures");
            yield return progress();

            Debug.WriteLine("Loading weapon textures");
            wep = WeaponTexture("weapon textures");
            yield return progress();

            Debug.WriteLine("Loading HUD");
            hud = IHUD("HUD");
            yield return progress();

            Debug.WriteLine("Loading font");
            font = content.Load<SpriteFont>("Segoe UI Mono");
            yield return progress();

            string loadedCheckMessage = String.Format("Loaded {0} items. Expected {1} items.", loadedItems, totalItems);
            Debug.WriteLine(loadedCheckMessage);
            Debug.Assert(loadedItems == totalItems, "Loader.totalItems needs adjusting.", loadedCheckMessage);
            yield return 1;
        }

        float progress() 
        {
            ++loadedItems;
            return (float)loadedItems / totalItems;
        }

        Player PlayerTexture(string name)
        {
            actBusy(name.Length);
            p.Load(content);
            return null;
        }

        HUD IHUD(string name)
        {
            actBusy(name.Length);
            hud.Load(content);
            return null;
        }

        Weapon WeaponTexture(string name)
        {
            actBusy(name.Length);
            //foreach (Weapon wep in p.weapList)
            //{
            //    wep.Load(content, p.GetDirection());
            //}
            return null;
        }

        void actBusy(int howBusy) 
        {
            Thread.Sleep(100*howBusy);
        }
    }
}
