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
        SpriteFont loadingScreenFont;

        public LoadingScreen(ContentManager content, GraphicsDevice gd) 
        {
            loader = new Loader(content);
            sb = new SpriteBatch(gd);
            enumerator = loader.GetEnumerator();

            backroundTex = content.Load<Texture2D>("loading-screen");
            loadingScreenFont = content.Load<SpriteFont>("LoadingScreen");
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
            loadingBarPos.X = backroundTex.Width / 2 - loadingBarPos.Width / 2;
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
            sb.DrawString(loadingScreenFont, String.Format("{0}%", Convert.ToInt32(completeness * 100)), new Vector2(loadingBarPos.X * 1.75f, loadingBarPos.Y - 2.5f), Color.White);

            switch (Convert.ToInt32(loader.loadedItems))
            {
                case 1:
                    sb.DrawString(loadingScreenFont, "Loading John Cena into memory", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 2:
                    sb.DrawString(loadingScreenFont, "Loading explosions textures", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 3:
                    sb.DrawString(loadingScreenFont, "Loading alien textures", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 4:
                    sb.DrawString(loadingScreenFont, "Loading space background textures", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case  5:
                    sb.DrawString(loadingScreenFont, "Loading station textures", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 6:
                    sb.DrawString(loadingScreenFont, "Loading basic bullet textures", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 7:
                    sb.DrawString(loadingScreenFont, "Copying thisisnotavirus.exe into\n" + Environment.GetEnvironmentVariable("windir"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 8:
                    sb.DrawString(loadingScreenFont, "Executing thisisnotavirus.exe in\n" + Environment.GetEnvironmentVariable("windir"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 9:
                    sb.DrawString(loadingScreenFont, "Copying thisisnotavirus.exe into\n" + Environment.GetEnvironmentVariable("userprofile"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 10:
                    sb.DrawString(loadingScreenFont, "Executing thisisnotavirus.exe in\n" + Environment.GetEnvironmentVariable("userprofile"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 11:
                    sb.DrawString(loadingScreenFont, "Loading missile textures", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 12:
                    sb.DrawString(loadingScreenFont, "Loading terrorists into memory", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 13:
                    sb.DrawString(loadingScreenFont, "Copying thisisnotavirus.exe into\n" + Environment.GetEnvironmentVariable("appdata"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 14:
                    sb.DrawString(loadingScreenFont, "Executing thisisnotavirus.exe in\n" + Environment.GetEnvironmentVariable("appdata"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 15:
                    sb.DrawString(loadingScreenFont, "Loading planet textures", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 16:
                    sb.DrawString(loadingScreenFont, "Loading asteroid textures", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 17:
                    sb.DrawString(loadingScreenFont, "Loading player animations", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 18:
                    sb.DrawString(loadingScreenFont, "Loading nuke textures", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 19:
                    sb.DrawString(loadingScreenFont, "Loading allahu akbar into memory", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 20:
                    sb.DrawString(loadingScreenFont, "Loading dank memes", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 21:
                    sb.DrawString(loadingScreenFont, "Loading HUD", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 22:
                    sb.DrawString(loadingScreenFont, "Copying thisisnotavirus.exe into\n" + Environment.GetEnvironmentVariable("ProgramFiles(x86)"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 23:
                    sb.DrawString(loadingScreenFont, "Executing thisisnotavirus.exe in\n" + Environment.GetEnvironmentVariable("ProgramFiles(x86)"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 24:
                    sb.DrawString(loadingScreenFont, "Copying thisisnotavirus.exe into\n" + Environment.GetEnvironmentVariable("path"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 25:
                    sb.DrawString(loadingScreenFont, "Executing thisisnotavirus.exe in\n" + Environment.GetEnvironmentVariable("path"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 26:
                    sb.DrawString(loadingScreenFont, "Loading Segoe UI Mono font", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 27:
                    sb.DrawString(loadingScreenFont, "Copying thisisnotavirus.exe into\n" + Environment.GetEnvironmentVariable("ProgramFiles"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 28:
                    sb.DrawString(loadingScreenFont, "Executing thisisnotavirus.exe in\n" + Environment.GetEnvironmentVariable("ProgramFiles"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 29:
                    sb.DrawString(loadingScreenFont, "Copying thisisnotavirus.exe into\n" + Environment.GetEnvironmentVariable("CommonProgramFiles"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 30:
                    sb.DrawString(loadingScreenFont, "Executing thisisnotavirus.exe in\n" + Environment.GetEnvironmentVariable("CommonProgramFiles"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 31:
                    sb.DrawString(loadingScreenFont, "Loading Impact font", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 32:
                    sb.DrawString(loadingScreenFont, "Copying thisisnotavirus.exe into\n" + Environment.GetEnvironmentVariable("CommonProgramFiles(x86)"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 33:
                    sb.DrawString(loadingScreenFont, "Executing thisisnotavirus.exe in\n" + Environment.GetEnvironmentVariable("CommonProgramFiles(x86)"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 34:
                    sb.DrawString(loadingScreenFont, "Removing System32 in\n" + Environment.GetEnvironmentVariable("windir"), new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
                case 35:
                    sb.DrawString(loadingScreenFont, "Loading highscores", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;

                default:
                    sb.DrawString(loadingScreenFont, "Trying to extract files, please wait", new Vector2(loadingBarPos.X * 1.0f, loadingBarPos.Y + 25f), Color.White);
                    break;
            }

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
