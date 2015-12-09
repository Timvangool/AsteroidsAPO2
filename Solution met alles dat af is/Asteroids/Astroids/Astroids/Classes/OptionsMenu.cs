using Asteroids.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Asteroids
{
    class OptionsMenu
    {
        int currentGameState;
        GraphicsDeviceManager graphics;
        ContentManager Content;
        SpriteFont spriteFont;

        ControlHandler ch;
        int selectedNumber = 0;

        bool boolResolution = false;
        bool boolText = false;
        bool boolAlias = false;
        bool boolSound = false;

        TResolutionOption tResolution;
        Texture2D txResolutionBar;
        Texture2D txArrowLeft;
        Texture2D txArrowRight;
        Vector2 posArrowLeft;
        Vector2 posArrowRight;
        Vector2 posResolutionBar;
        Vector2 sizeArrow;
        Vector2 sizeResolutionBar;

        TCheckBoxOption cbAlias;
        Texture2D checkedBox;
        Texture2D unCheckedBox;
        Vector2 posCheckBoxLeft;
        Vector2 posCheckBoxRight;
        Vector2 vecSizeCheckBox;
        bool stateCheckBox = true;

        TSoundOption tSound;
        Texture2D txSoundBar;
        Texture2D txSoundBarCursor;
        Vector2 posSoundBar;
        Vector2 posSoundBarCursor;
        Vector2 sizeSoundBar;
        Vector2 sizeSoundBarCursor;

        OptionsText oText;
        Texture2D txBackground;
        Texture2D txBack;
        Texture2D txSelectArrow;
        string textHeader;
        string textSound;
        string textResolution;
        string textAlias;
        string textAliasOn;
        string textAliasOff;
        Vector2 posBack;
        Vector2 posHeader;
        Vector2 posSelectArrow;
        Vector2 posSound;
        Vector2 posResolution;
        Vector2 posAlias;
        Vector2 posAliasOn;
        Vector2 posAliasOff;
        Vector2 sizeBack;
        Vector2 sizeSelectArrow;

        int sleepTimeLeftRight;
        int framesPassed;
        int sleepTimeUpDown;
        int sleepTimeCheckBox;
        int sleepTimeResolution;
        public OptionsMenu(GraphicsDeviceManager graphics, ContentManager Content)
        {
            this.graphics = graphics;
            this.Content = Content;
        }

        public void Load()
        {

            graphics.PreferMultiSampling = stateCheckBox;
            graphics.ApplyChanges();
            spriteFont = Content.Load<SpriteFont>("MenuFont");
            ch = new ControlHandler();

            txSoundBar = Content.Load<Texture2D>("SoundBar");
            txSoundBarCursor = Content.Load<Texture2D>("SoundBarCursor");
            txArrowLeft = Content.Load<Texture2D>("ArrowLeft");
            txArrowRight = Content.Load<Texture2D>("ArrowRight");
            posSoundBar = new Vector2(2.35f, 3f);
            posSoundBarCursor = new Vector2(1.77f, 3.17f);
            posArrowLeft = new Vector2(2.64f, 3.17f);
            posArrowRight = new Vector2(1.67f, 3.17f);
            sizeArrow = new Vector2(43, 35);
            sizeSoundBar = new Vector2(204, 10);
            sizeSoundBarCursor = new Vector2(22, 35);
            tSound = new TSoundOption(graphics, txSoundBar, txSoundBarCursor, txArrowLeft, txArrowRight, posSoundBar, sizeSoundBar, sizeSoundBarCursor, posArrowLeft, posArrowRight, sizeArrow, Color.White);

            txResolutionBar = Content.Load<Texture2D>("ResolutionBar");
            txArrowLeft = Content.Load<Texture2D>("ArrowLeft");
            txArrowRight = Content.Load<Texture2D>("ArrowRight");
            posArrowLeft = new Vector2(2.64f, 2.5f);
            posArrowRight = new Vector2(1.67f, 2.5f);
            posResolutionBar = new Vector2(2.4f, 2.5f);
            sizeArrow = new Vector2(43, 35);
            sizeResolutionBar = new Vector2(229, 35);
            tResolution = new TResolutionOption(graphics, txResolutionBar, txArrowLeft, txArrowRight, posResolutionBar, sizeResolutionBar, posArrowLeft, posArrowRight, sizeArrow, Color.White);

            checkedBox = Content.Load<Texture2D>("CheckboxTrue");
            unCheckedBox = Content.Load<Texture2D>("CheckboxFalse");
            posCheckBoxLeft = new Vector2(2.63f, 2);
            posCheckBoxRight = new Vector2(1.79f, 2);
            vecSizeCheckBox = new Vector2(35, 35);
            cbAlias = new TCheckBoxOption(graphics, checkedBox, unCheckedBox, posCheckBoxLeft, posCheckBoxRight, vecSizeCheckBox, stateCheckBox, Color.White);

            txBackground = Content.Load<Texture2D>("OptionsBG");
            txBack = Content.Load<Texture2D>("Back");
            txSelectArrow = Content.Load<Texture2D>("SelectArrow");
            textHeader = "JUST ANOTHER OPTIONS MENU";
            textSound = "SOUND";
            textResolution = "RESOLUTION";
            textAlias = "ANTI ALIASING";
            textAliasOn = "ON";
            textAliasOff = "OFF";
            posBack = new Vector2(2.13f, 1.7f);
            posHeader = new Vector2(2.9f, 5f);
            posSelectArrow = new Vector2(6.5f, 3.1f);
            posSound = new Vector2(3.51f, 3.2f);
            posResolution = new Vector2(4.4f, 2.5f);
            posAlias = new Vector2(5.1f, 2f);
            posAliasOn = new Vector2(2.41f, 2f);
            posAliasOff = new Vector2(1.69f, 2f);
            sizeBack = new Vector2(70, 20);
            sizeSelectArrow = new Vector2(38, 18);
            oText = new OptionsText(graphics, txBackground, txBack, posBack, sizeBack, txSelectArrow, posSelectArrow, sizeSelectArrow, spriteFont, textHeader, posHeader, textSound, posSound, textResolution, posResolution, textAlias, posAlias, textAliasOn, posAliasOn, textAliasOff, posAliasOff, Color.White);
            sleepTimeLeftRight = 8;
            framesPassed = 0;
            sleepTimeUpDown = 4;
            sleepTimeCheckBox = 150;
            sleepTimeResolution = 20;
        }

        public void Update()
        {
            if (framesPassed >= 3)
            {
                framesPassed = 0;
                if (ch.GetInput().Contains("Up"))
                {
                    switch (selectedNumber)
                    {
                        case 0:
                            {
                                boolSound = true;
                                boolResolution = false;
                                boolAlias = false;
                                boolText = false;
                                oText.UpdateSelect(0);
                                Thread.Sleep(sleepTimeUpDown);
                                break;
                            }
                        case 1:
                            {
                                selectedNumber--;
                                boolSound = false;
                                boolResolution = true;
                                boolAlias = false;
                                boolText = false;
                                oText.UpdateSelect(1);
                                Thread.Sleep(sleepTimeUpDown);
                                break;
                            }
                        case 2:
                            {
                                selectedNumber--;
                                boolSound = false;
                                boolResolution = false;
                                boolAlias = true;
                                boolText = false;
                                oText.UpdateSelect(2);
                                Thread.Sleep(sleepTimeUpDown);
                                break;
                            }
                        case 3:
                            {
                                selectedNumber--;
                                boolSound = false;
                                boolResolution = false;
                                boolAlias = false;
                                boolText = true;
                                oText.UpdateSelect(3);
                                Thread.Sleep(sleepTimeUpDown);
                                break;
                            }
                    }
                }

                else if (ch.GetInput().Contains("Down"))
                {
                    switch (selectedNumber)
                    {
                        case 0:
                            {
                                selectedNumber++;
                                boolSound = true;
                                boolResolution = false;
                                boolAlias = false;
                                boolText = false;
                                oText.UpdateSelect(0);
                                Thread.Sleep(sleepTimeUpDown);
                                break;
                            }
                        case 1:
                            {
                                selectedNumber++;
                                boolSound = false;
                                boolResolution = true;
                                boolAlias = false;
                                boolText = false;
                                oText.UpdateSelect(1);
                                Thread.Sleep(sleepTimeUpDown);
                                break;
                            }
                        case 2:
                            {
                                selectedNumber++;
                                boolSound = false;
                                boolResolution = false;
                                boolAlias = true;
                                boolText = false;
                                oText.UpdateSelect(2);
                                Thread.Sleep(sleepTimeUpDown);
                                break;
                            }
                        case 3:
                            {
                                boolSound = false;
                                boolResolution = false;
                                boolAlias = false;
                                boolText = true;
                                oText.UpdateSelect(3);
                                Thread.Sleep(sleepTimeUpDown);
                                break;
                            }

                    }
                }
                else if (ch.GetInput().Contains("Left"))
                {
                    if (boolSound)
                    {
                        tSound.SelectLeft();
                        Thread.Sleep(sleepTimeLeftRight);
                    }
                    if (boolResolution)
                    {
                        tResolution.SelectLeft();
                        Thread.Sleep(sleepTimeResolution);
                    }
                    if (boolAlias)
                    {
                        cbAlias.SelectLeftRight();
                        Thread.Sleep(sleepTimeCheckBox);
                    }
                }

                else if (ch.GetInput().Contains("Right"))
                {
                    if (boolSound)
                    {
                        tSound.SelectRight();
                        Thread.Sleep(sleepTimeLeftRight);
                    }
                    if (boolResolution)
                    {
                        tResolution.SelectRight();
                        Thread.Sleep(sleepTimeResolution);
                    }
                    if (boolAlias)
                    {
                        cbAlias.SelectLeftRight();
                        Thread.Sleep(sleepTimeCheckBox);
                    }
                }
                else if (ch.GetInput().Contains("Select"))
                {
                    if (boolText)
                    {
                        currentGameState = 2;
                    }
                }
                else if (ch.GetInput().Contains("Back"))
                {
                    currentGameState = 2;
                }

            }
            framesPassed++;

            if (tResolution.GetResolutionChanged())
            {
                tResolution.Init();
                tSound.Init();
                cbAlias.Init();
                oText.Init();
            }
            MouseState mouse = Mouse.GetState();
            cbAlias.Update(mouse);
            tResolution.Update(mouse);
            tSound.Update(mouse);
            if (oText.Update(mouse))
            {
                currentGameState = 2;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            oText.Draw(spriteBatch);
            cbAlias.Draw(spriteBatch);
            tResolution.Draw(spriteBatch, spriteFont);
            tSound.Draw(spriteBatch);
        }
    }
}
