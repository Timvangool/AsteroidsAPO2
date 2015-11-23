using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WiimoteLib;
using System.Xml;

using Microsoft.Xna.Framework.Input;

namespace WiimoteTest2015
{
    public class WiimoteHandler

    {
        List<Wiimote> wmList = new List<Wiimote>();
        WiimoteCollection WMC = new WiimoteCollection();


        public WiimoteHandler()
        {
            ConnectWiimote();

        }

        private void ConnectWiimote()
        {
            try
            {
                WMC.FindAllWiimotes();
                int index = 1;

                foreach(Wiimote wiimote in WMC)
                {
                    wiimote.Connect();
                    wiimote.SetLEDs(index++);
                    wmList.Add(wiimote);
                }
            }
            catch(WiimoteNotFoundException ex)
            {
                MessageBox.Show("Wiimote not found: ", ex.Message);
            }
            catch(WiimoteException ex)
            {
                MessageBox.Show("Wiimote error: ", ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unknown error: ", ex.Message);
            }
        }

        public List<string> GetButtonsPressed()
        {
            List<string> btnsPressed = new List<string>();
           
            foreach (Wiimote wm in wmList)
            {
                if (wm.WiimoteState.ButtonState.Up)
                {
                    btnsPressed.Add("Up");
                }
                if (wm.WiimoteState.ButtonState.Down)
                {
                    btnsPressed.Add("Down");
                }
                if (wm.WiimoteState.ButtonState.Left)
                {
                    btnsPressed.Add("Left");
                }
                if (wm.WiimoteState.ButtonState.Right)
                {
                    btnsPressed.Add("Right");
                }
                if (wm.WiimoteState.ButtonState.Home)
                {
                    btnsPressed.Add("Home");
                }
                if (wm.WiimoteState.ButtonState.A)
                {
                    btnsPressed.Add("A");
                }
                if (wm.WiimoteState.ButtonState.B)
                {
                    btnsPressed.Add("B");
                }
                if (wm.WiimoteState.ButtonState.One)
                {
                    btnsPressed.Add("1");
                }
                if (wm.WiimoteState.ButtonState.Two)
                {
                    btnsPressed.Add("2");
                }
                if (wm.WiimoteState.ButtonState.Plus)
                {
                    btnsPressed.Add("+");
                }
                if (wm.WiimoteState.ButtonState.Minus)
                {
                    btnsPressed.Add("-");
                }                
            }

            return btnsPressed;
        }


    }
}




