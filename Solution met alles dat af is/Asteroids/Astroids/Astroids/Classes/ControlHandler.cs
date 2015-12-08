using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Asteroids.Classes
{
    class ControlHandler
    {
        List<string> cActions;
        KeyboardHandler kbHandler;
        WiimoteHandler wmHandler;
        string[,] keyBindings = new string[10, 3] { { "Up", "", ""}, {"Down", "", ""}, {"Left", "", ""}, {"Right", "", ""}, {"Select","", ""}, 
                                                  { "Back", "", ""}, {"Shoot", "", ""}, {"VolUp", "", ""}, {"VolDown", "", ""}, {"Pause", "", ""} };
        bool wiimoteIsConnected;

        public ControlHandler()
        {
            cActions = new List<string>();
            kbHandler = new KeyboardHandler();
            wmHandler = new WiimoteHandler();
            wiimoteIsConnected = wmHandler.CheckConnection();
        }

        public List<string> GetInput()
        {
            List<string> allInput = new List<string>();
            List<string> wmInput;
            List<string> kbInput;

         //   if (wmHandler.CheckConnection())
            {
            wmInput = wmHandler.GetButtonsPressed();
            foreach (string input in wmInput)
            {
                allInput.Add(input);
            }
            }

            kbInput = kbHandler.GetButtonsPressed();
            foreach (string input in kbInput)
            {
                allInput.Add(input);
            }
            
            return allInput;
        }

        public void SetWiimoteLeds(int wmIndex, int lives)
        {
            if (wiimoteIsConnected)
                wmHandler.SetLeds(wmIndex, lives);
        }
    }
}
