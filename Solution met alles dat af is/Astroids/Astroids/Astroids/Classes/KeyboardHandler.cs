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
using System.IO;

namespace Astroids.Classes
{
    class KeyboardHandler
    {
        string[,] keyBinds = new string[10, 2] { { "Up", ""}, {"Down", ""}, {"Left", ""}, {"Right", ""}, {"Select",""}, 
                                               { "Back", ""}, {"Shoot", ""}, {"VolUp", ""}, {"VolDown", ""}, {"Pause", ""} };
        public KeyboardHandler()
        {
            GetKBControls();
        }        
        
        public List<string> GetButtonsPressed(/*string[,] keyBinds*/)
        {
            List<string> btnsPressed = new List<string>();
            Keys[] kbState = Keyboard.GetState().GetPressedKeys();

            Keys[] keys = new Keys[10]; //up, down, left, right, select, back, shoot, volUp, volDown, pause

            for (int i = 0; i < 10; i++)
            {
                Enum.TryParse(keyBinds[i, 1], out keys[i]);
            }

            for (int i = 0; i < 10; i++)
            {
                if (kbState.Contains(keys[i]))
                    btnsPressed.Add(keyBinds[i, 0]);
            }

            return btnsPressed;
        }
        private void GetKBControls()
        {
            StreamReader sr = new StreamReader(@"Content\Keybindings\KeyboardControls.txt");

            char separator = ':';
            for (int i = 0; i <= 9; i++)
            {
                string temp = sr.ReadLine();
                string[] tempArray = temp.Split(separator);
                keyBinds[i, 1] = tempArray[1];
            }
        }
    }
}
