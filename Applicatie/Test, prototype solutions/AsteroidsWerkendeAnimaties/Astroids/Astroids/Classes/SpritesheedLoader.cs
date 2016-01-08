using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Asteroids.Classes
{
    class SpritesheetLoader
    {
        ContentManager content;
        List<Texture2D> textures;
        public Texture2D tx;
        Texture2D error;
        DirectoryInfo dir;
        string spriteFolder;
        bool loopable;
        int currentFrame;
        int frameSkip;
        int frameSkipOld;
        public bool isRunning;

        public SpritesheetLoader(string spriteFolder, bool loopable,  int frameSkip, ContentManager content)
        {
            this.loopable = loopable;
            this.content = content;
            this.spriteFolder = spriteFolder;

            this.frameSkip = frameSkip;
            this.frameSkipOld = frameSkip;

            currentFrame = 0;
            isRunning = true;
            textures = new List<Texture2D>();

            LoadImages();
        }

        private void LoadImages()
        {
            dir = new DirectoryInfo(content.RootDirectory + "/" + spriteFolder);

            if (!dir.Exists)
                throw new DirectoryNotFoundException();

            FileInfo[] files = dir.GetFiles("*.*");

            foreach(FileInfo file in files)
            {
                string key = Path.GetFileNameWithoutExtension(file.Name);
                Texture2D texture = content.Load<Texture2D>(spriteFolder + "/" + key);
                textures.Add(texture);
            }
            tx = textures[0];

            //error = content.Load<Texture2D>("error");
        }


        //FIX THIS LOGIC PLEASE
        public void GetNextSprite()
        {
            isRunning = true;

            if (frameSkip == 0)
            {
                if (!loopable)
                {
                    if (currentFrame < textures.Count)
                    {
                        tx = textures[currentFrame];
                        currentFrame++;
                        frameSkip = frameSkipOld;
                    }
                    if (currentFrame == textures.Count)
                    {
                        isRunning = false;
                        currentFrame = 0;
                    }
                }
                else
                {
                    if (currentFrame < textures.Count)
                    {
                        tx = textures[currentFrame];
                        currentFrame++;
                        frameSkip = frameSkipOld;
                        if (currentFrame == textures.Count)
                            currentFrame = 0;
                    }
                }
            }
            frameSkip--;
        }
    }
}
