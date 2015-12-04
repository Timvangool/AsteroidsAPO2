using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiimoteLib;
using System.Xml;
using System.IO;

using Microsoft.Xna.Framework.Input;

namespace Astroids.Classes
{
    public class WiimoteHandler
    {
        List<Wiimote> wmList = new List<Wiimote>();
        WiimoteCollection WMC = new WiimoteCollection();
        public bool[] connectedWMS = new bool[4];
        string[,] keyBinds = new string[10, 2] { { "Up", ""}, {"Down", ""}, {"Left", ""}, {"Right", ""}, {"Select",""}, 
                                               { "Back", ""}, {"Shoot", ""}, {"VolUp", ""}, {"VolDown", ""}, {"Pause", ""} };


        public WiimoteHandler()
        {
            ConnectWiimote();
            GetWMControls();
        }

        private void ConnectWiimote()
        {
            try
            {
                WMC.FindAllWiimotes();
                int index = 2;

                foreach (Wiimote wiimote in WMC)
                {
                    wiimote.Connect();
                    wiimote.SetLEDs(index++);
                    wmList.Add(wiimote);
                }
            }
            catch (WiimoteNotFoundException ex)
            {
                System.Windows.Forms.MessageBox.Show("Wiimote not found: ", ex.Message);
            }
            catch (WiimoteException ex)
            {
                System.Windows.Forms.MessageBox.Show("Wiimote error: ", ex.Message);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Unknown error: ", ex.Message);
            }
        }

        public bool CheckConnection()
        {
            WiimoteCollection wmc = new WiimoteCollection();
            bool connected = false;

            foreach(Wiimote wm in wmList)
            {
                wmc.Add(wm);

                try
                {
                    wmc.FindAllWiimotes();
                    wm.Connect();
                    connected = true;
                }
                catch (WiimoteNotFoundException e)
                {
                    connected = false;
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
            }

            return connected;
        }

        public List<string> GetButtonsPressed()
        {
            List<string> btnsPressed = new List<string>();
            string[] wmButtonsPressed = new string[11]; //Up, Down, Left, Right, A, B, One, Two, Plus, Minus, Home
            string[] keys = new string[10];

            foreach (Wiimote wm in wmList)
            {
                if (wm.WiimoteState.ButtonState.Up)
                    wmButtonsPressed[0] = "Up";
                if (wm.WiimoteState.ButtonState.Down)
                    wmButtonsPressed[1] = "Down";
                if (wm.WiimoteState.ButtonState.Left)
                    wmButtonsPressed[2] = "Left";
                if (wm.WiimoteState.ButtonState.Right)
                    wmButtonsPressed[3] = "Right";
                if (wm.WiimoteState.ButtonState.A)
                    wmButtonsPressed[4] = "A";
                if (wm.WiimoteState.ButtonState.B)
                    wmButtonsPressed[5] = "B";
                if (wm.WiimoteState.ButtonState.One)
                    wmButtonsPressed[6] = "One";
                if (wm.WiimoteState.ButtonState.Two)
                    wmButtonsPressed[7] = "Two";
                if (wm.WiimoteState.ButtonState.Plus)
                    wmButtonsPressed[8] = "Plus";
                if (wm.WiimoteState.ButtonState.Minus)
                    wmButtonsPressed[9] = "Minus";
                if (wm.WiimoteState.ButtonState.Home)
                    wmButtonsPressed[10] = "Home";
            }

            for (int i = 0; i < 10; i++)
            {
                keys[i] = keyBinds[i, 1];
            }

            for (int i = 0; i < 10; i++)
            {
                if (wmButtonsPressed.Contains(keys[i]))
                    btnsPressed.Add(keyBinds[i, 0]);
            }

            return btnsPressed;
        }
        private void GetWMControls()
        {
            StreamReader sr = new StreamReader(@"Content\Keybindings\WiimoteControls.txt");

            char separator = ':';
            for (int i = 0; i <= 9; i++)
            {
                string temp = sr.ReadLine();
                string[] tempArray = temp.Split(separator);
                keyBinds[i, 1] = tempArray[1];
            }
        }
        public void SetLeds(int wmIndex, int lives)
        {
            switch (lives)
            {
                case 4:
                    wmList[wmIndex].SetLEDs(true, true, true, true);
                    break;
                case 3:
                    wmList[wmIndex].SetLEDs(true, true, true, false);
                    break;
                case 2:
                    wmList[wmIndex].SetLEDs(true, true, false, false);
                    break;
                case 1:
                    wmList[wmIndex].SetLEDs(true, false, false, false);
                    break;
                default:
                    wmList[wmIndex].SetLEDs(false, false, false, false);
                    break;
            }
        }
    }
}