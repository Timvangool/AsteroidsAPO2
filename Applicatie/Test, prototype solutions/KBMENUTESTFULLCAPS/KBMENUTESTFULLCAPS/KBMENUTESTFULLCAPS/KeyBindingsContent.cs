using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WiimoteLib;

namespace KBMENUTESTFULLCAPS
{
    class KeyBindingsContent
    {
        GraphicsDeviceManager graphics;
        ContentManager Content;
        SpriteFont font;
        Texture2D ship;
        Vector2 pointerPos;
        ControlHandler controlHandler;
        Wiimote wm;
        float scale;
        string[,] keyBindings;
        string[,] originalKeybindings;
        bool controlsEnabled;
        int[] xPositions = new int[2] { 725, 1300 };
        int[] yPositions = new int[11] { 207, 267, 327, 387, 447, 507, 567, 627, 687, 747, 818 };
        int count;
        WiimoteHandler wmHandler;
        int posX, posY;
        StreamWriter sw;
        Background bg;
        Color col;
        Color promptColor;

        bool savePrompt;
        int promptTimer;
        float fadeValue;

        bool canSave;
        int saveTimer;
        float saveFadeValue;

        bool reset;
        int resetTimer;
        float resetFadeValue;



        public KeyBindingsContent(GraphicsDeviceManager graphics, ContentManager Content)
        {
            this.graphics = graphics;
            this.Content = Content;
            scale = graphics.GraphicsDevice.Viewport.Width / 1600.0f;

            Initialize();
            Load();
        }

        private void Initialize()
        {
            LoadControls();
            bg = new Background(graphics.GraphicsDevice, Content);
            count = 0;
            col = Color.White;
            promptColor = new Color(255, 222, 0);

            savePrompt = false;
            promptTimer = 0;
            fadeValue = 0;

            reset = false;
            resetTimer = 0;
            resetFadeValue = 0;

            canSave = true;
            saveTimer = 0;
            saveFadeValue = 0;

            wmHandler = new WiimoteHandler();

            GameTime gameTime = new GameTime();
        }

        public void Load()
        {
            font = Content.Load<SpriteFont>("KBMenuFont");
            ship = Content.Load<Texture2D>("RocketIdle");
        }

        public void Update()
        {
            //Returning to Options Menu
            if (controlHandler.GetInput().Contains("Back"))
            {
                
            }

            count++;
            if (count % 5 == 0)
            {
                if (controlsEnabled)
                {
                    if (controlHandler.GetInput().Contains("Right") || controlHandler.GetInput().Contains("Left"))
                    {
                        if (posX < xPositions.Length - 1)
                            posX = 1;
                        else
                            posX = 0;
                    }
                    if (controlHandler.GetInput().Contains("Up"))
                    {
                        if (posY > 0)
                            posY--;
                        else
                            posY = 10;
                    }
                    if (controlHandler.GetInput().Contains("Down"))
                    {
                        if (posY > 9)
                            posY = 0;
                        else
                            posY++;
                    }
                }
            }

            if (controlHandler.GetInput().Contains("Select"))
            {
                if(count % 7 == 0)
                {
                    if (posY < 10 && (posX == 0 || posX == 1 && controlHandler.GetNumberOfWiimotes() > 0))
                    {
                        EmptyKeybind();
                    }
                    else
                    {
                        if (posX == 0)
                            DiscardChanges();
                        if (posX == 1)
                            SaveChanges();
                    }
                }                
            }

            if (count % 10 == 0)
            {
                if (!controlsEnabled)
                {
                    if (posX == 0)
                        RebindKBKey();
                    else if (posX == 1)
                        RebindWMKey();
                }
            }        
            
            pointerPos = new Vector2(xPositions[posX], yPositions[posY]);

            if(savePrompt == true)
            {
                promptTimer++;
                if (promptTimer > 75)
                {
                    fadeValue += 0.02f;
                    promptColor = Color.Lerp(new Color(255, 222, 0), new Color(0, 0, 0), fadeValue);
                }
                if(promptTimer > 150)
                {
                    savePrompt = false;
                    promptColor = new Color(255, 222, 0);
                    fadeValue = 0;
                    promptTimer = 0;
                }
            }

            if(canSave == false)
            {
                saveTimer++;
                if(saveTimer > 75)
                {
                    saveFadeValue += 0.02f;
                    promptColor = Color.Lerp(new Color(255, 222, 0), new Color(0, 0, 0), saveFadeValue);
                }
                if(saveTimer > 150)
                {
                    canSave = true;
                    promptColor = new Color(255, 222, 0);
                    saveFadeValue = 0;
                    saveTimer = 0;
                }
            }

            if(reset)
            {
                resetTimer++;
                if(resetTimer > 75)
                {
                    resetFadeValue += 0.02f;
                    promptColor = Color.Lerp(new Color(255, 222, 0), new Color(0, 0, 0), resetFadeValue);
                }
                if (resetTimer > 150)
                {
                    reset = false;
                    promptColor = new Color(255, 222, 0);
                    resetFadeValue = 0;
                    resetTimer = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //background
            bg.Draw(spriteBatch);

            // Title up top
            spriteBatch.DrawString(font, "KEYBINDINGS", new Vector2(536 * scale, 10), new Color(255,222, 0), 0, Vector2.Zero, 0.6f * scale, SpriteEffects.None, 0.0f);
            
            //Headers
            spriteBatch.DrawString(font, "Action", new Vector2(100 * scale, 125 * scale), new Color(255, 222, 0), 0, Vector2.Zero, 0.4f * scale, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(font, "Keyboard", new Vector2(672 * scale, 125 * scale), new Color(255, 222, 0), 0, Vector2.Zero, 0.4f * scale, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(font, "Wiimote", new Vector2(1276 * scale, 125 * scale), new Color(255, 222, 0), 0, Vector2.Zero, 0.4f * scale, SpriteEffects.None, 0);
            
            // All strings below it
            for (int i = 0; i < 10; i++)
            {
                if(pointerPos.Y == yPositions[i])
                {
                    col = Color.White;
                }
                else
                {
                    col = new Color(160, 160, 160);
                }
                spriteBatch.DrawString(font, keyBindings[i, 0], new Vector2(150 * scale, (200 + 60 * i) * scale), col, 0, Vector2.Zero, 0.25f * scale, SpriteEffects.None, 0.0f);
                spriteBatch.DrawString(font, keyBindings[i,1], new Vector2(775 * scale, (200 + 60 * i) * scale), col, 0, Vector2.Zero, 0.25f * scale, SpriteEffects.None, 0.0f);
                spriteBatch.DrawString(font, keyBindings[i,2], new Vector2(1350 * scale, (200 + 60 * i) * scale), col, 0, Vector2.Zero, 0.25f * scale, SpriteEffects.None, 0.0f);
            }

            spriteBatch.Draw(ship, pointerPos * scale, null, Color.White, 0, Vector2.Zero, 0.8f * scale, SpriteEffects.None, 0);

            spriteBatch.DrawString(font, "Reset", new Vector2(775 * scale, 800 * scale), new Color(255, 222, 0), 0, Vector2.Zero, 0.4f * scale, SpriteEffects.None, 0.0f);
            spriteBatch.DrawString(font, "Apply", new Vector2(1350 * scale, 800 * scale), new Color(255, 222, 0), 0, Vector2.Zero, 0.4f * scale, SpriteEffects.None, 0.0f);
            
            if(savePrompt == true)
                spriteBatch.DrawString(font, "Changes have been saved.", new Vector2(20 * scale, 850 * scale), promptColor, 0, Vector2.Zero, 0.20f * scale, SpriteEffects.None, 0.0f);
            if(canSave == false)
                spriteBatch.DrawString(font, "Cannot save with unbound keys.", new Vector2(20 * scale, 850 * scale), promptColor, 0, Vector2.Zero, 0.20f * scale, SpriteEffects.None, 0.0f);
            if(reset)
                spriteBatch.DrawString(font, "Keybindings have been reset.", new Vector2(20 * scale, 850 * scale), promptColor, 0, Vector2.Zero, 0.20f * scale, SpriteEffects.None, 0.0f);


        }

        private void EmptyKeybind()
        {
            controlsEnabled = false;
            keyBindings[posY, posX + 1] = "Press a key...";
        }

        private void RebindKBKey()
        {
            if (Keyboard.GetState().GetPressedKeys().Count() > 0)
            {                
                string pressedKey = Keyboard.GetState().GetPressedKeys()[0].ToString();

                for (int i = 0; i < keyBindings.Length / 3; i++)
                {
                    if (keyBindings[i, 1] == pressedKey)
                        keyBindings[i, 1] = "[NOT BOUND]";
                }
                
                keyBindings[posY, posX + 1] = pressedKey;

                controlsEnabled = true;
            }
        }

        private void SaveChanges()
        {
            if (CheckSavable())
            {
                CheckSavable();
                File.Delete(@"Content\KeyBindings\KeyboardControls.txt");
                File.Delete(@"Content\KeyBindings\WiimoteControls.txt");
                File.Create(@"Content\KeyBindings\KeyboardControls.txt").Close();
                File.Create(@"Content\KeyBindings\WiimoteControls.txt").Close();

                sw = new StreamWriter(@"Content\Keybindings\KeyboardControls.txt");
                for (int i = 0; i < keyBindings.Length / 3; i++)
                {
                    sw.WriteLine(keyBindings[i, 0] + ":" + keyBindings[i, 1]);
                }
                sw.Dispose();

                sw = new StreamWriter(@"Content\KeyBindings\WiimoteControls.txt");
                for (int i = 0; i < keyBindings.Length / 3; i++)
                {
                    sw.WriteLine(keyBindings[i, 0] + ":" + keyBindings[i, 2]);
                }
                sw.Dispose();

                LoadControls();
                savePrompt = true;
            }
        }
        private void DiscardChanges()
        {
            controlHandler = new ControlHandler();
            keyBindings = controlHandler.GetKeyBindings();
            reset = true;
        }

        private void LoadControls()
        {
            controlHandler = new ControlHandler();
            keyBindings = controlHandler.GetKeyBindings();
            originalKeybindings = controlHandler.GetKeyBindings();

            controlsEnabled = true;
            int posX = 0;
            int posY = 0;
            pointerPos = new Vector2(xPositions[posX], yPositions[posY]);

            if (controlHandler.GetNumberOfWiimotes() > 0)
                wm = controlHandler.GetWiimote(0);
        }




        private void RebindWMKey()
        {
            List<string> wmButtonsPressed = wmHandler.GetRawInput();
            if (wmButtonsPressed.Count() > 0)
            {
                string pressedKey = wmButtonsPressed[0];

                for (int i = 0; i < keyBindings.Length / 3; i++)
                {
                    if (keyBindings[i, 2] == pressedKey)
                        keyBindings[i, 2] = "[NOT BOUND]";
                }

                keyBindings[posY, posX + 1] = pressedKey;

                controlsEnabled = true;
            }
        }

        private bool CheckSavable()
        {
            for (int i = 0; i < keyBindings.Length / 3; i++)
            {
                if (keyBindings[i, 1] == "[NOT BOUND]" || keyBindings[i, 2] == "[NOT BOUND]")
                {
                    canSave = false;
                }
                if(!canSave)
                {                    
                    return false;
                }
            }
            return true;            
        }
    }
}
