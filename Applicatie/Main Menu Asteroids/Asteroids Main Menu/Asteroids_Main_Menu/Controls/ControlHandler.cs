using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Asteroids_Main_Menu
{
    class ControlHandler
    {
        List<string> cActions;
        KeyboardHandler kbHandler;
        WiimoteHandler wmHandler;
        string[,] keyBindings = new string[10, 3] { { "Up", "", ""}, {"Down", "", ""}, {"Left", "", ""}, {"Right", "", ""}, {"Select","", ""}, 
                                                  { "Back", "", ""}, {"Shoot", "", ""}, {"VolUp", "", ""}, {"VolDown", "", ""}, {"Pause", "", ""} };
        public ControlHandler()
        {
            cActions = new List<string>();
            kbHandler = new KeyboardHandler();
            wmHandler = new WiimoteHandler();
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
    }
}
