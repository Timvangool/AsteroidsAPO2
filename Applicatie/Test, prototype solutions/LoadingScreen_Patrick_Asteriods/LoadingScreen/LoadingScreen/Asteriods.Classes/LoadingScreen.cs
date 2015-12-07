using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Asteroids.Classes 
{
    class LoadingScreen
    {
        Loader loader;
        SpriteBatch sb;
        IEnumerator<float> enumerator;
        Texture2D barTex;
        Texture2D backroundTex;

        public LoadingScreen(ContentManager content, GraphicsDevice gd) 
        {
            loader = new Loader(content);
            sb = new SpriteBatch(gd);
            enumerator = loader.GetEnumerator();

            backroundTex = content.Load<Texture2D>("loading-screen");
            barTex = new Texture2D(gd, 1, 1);
            uint[] texData = { 0xffffffff };
            barTex.SetData<uint>(texData);
        }

        public Loader Update() 
        {
            bool incomplete = enumerator.MoveNext();
            return incomplete ? null : loader;
        }

        public void Draw() 
        {
            Rectangle screenRect = new Rectangle(0, 0, sb.GraphicsDevice.Viewport.Width, sb.GraphicsDevice.Viewport.Height);
            Vector2 backroundTexPos = new Vector2(screenRect.Center.X - backroundTex.Width/2, screenRect.Center.Y - backroundTex.Height/2);

            Rectangle loadingBarPos = new Rectangle();
            loadingBarPos.Width = 400;
            loadingBarPos.Height = 20;
            loadingBarPos.X = backroundTex.Width/2 - loadingBarPos.Width/2;
            loadingBarPos.Y = 240;
            loadingBarPos.Offset((int)backroundTexPos.X, (int)backroundTexPos.Y);

            Color screenBackgroundColor = topLeftPixelColor(backroundTex);
            Color barColor = Color.Red;
            Color barBackgroundColor = Color.Blue;
            int barBackgroundExpand = 2;
            sb.GraphicsDevice.Clear(screenBackgroundColor);
            sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            sb.Draw(backroundTex, backroundTexPos, Color.White);

            Rectangle barBackground = loadingBarPos;
            barBackground.Inflate(barBackgroundExpand, barBackgroundExpand);
            sb.Draw(barTex, barBackground, barBackgroundColor);

            Rectangle bar = loadingBarPos;
            float completeness = enumerator.Current;
            bar.Width = (int)(loadingBarPos.Width * completeness);

            sb.Draw(barTex, bar, barColor);
            sb.End();
        }

        Color topLeftPixelColor(Texture2D tex) 
        {
            Color[] colors = { Color.Magenta };
            tex.GetData<Color>(0, new Rectangle(0, 0, 1, 1), colors, 0, 1);
            return colors[0];
        }
    }
}
