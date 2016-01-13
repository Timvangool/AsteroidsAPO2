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

namespace Options_Menu


{
    #region StructSound
    public struct StructSound
    {
        Texture2D _txSoundBar;
        Texture2D _txSoundBarCursor;
        Texture2D _txArrowLeft;
        Texture2D _txArrowRight;
        Vector2 _posSoundBar;
        Vector2 _posSoundBarCursor;
        Vector2 _posArrowLeft;
        Vector2 _posArrowRight;
        Vector2 _sizeArrow;
        Vector2 _sizeSoundBar;
        Vector2 _sizeSoundBarCursor;

        public Texture2D TxSoundBar
        {
            get
            {
                return _txSoundBar;
            }

            set
            {
                _txSoundBar = value;
            }
        }

        public Texture2D TxSoundBarCursor
        {
            get
            {
                return _txSoundBarCursor;
            }

            set
            {
                _txSoundBarCursor = value;
            }
        }

        public Texture2D TxArrowLeft
        {
            get
            {
                return _txArrowLeft;
            }

            set
            {
                _txArrowLeft = value;
            }
        }

        public Texture2D TxArrowRight
        {
            get
            {
                return _txArrowRight;
            }

            set
            {
                _txArrowRight = value;
            }
        }

        public Vector2 PosSoundBar
        {
            get
            {
                return _posSoundBar;
            }

            set
            {
                _posSoundBar = value;
            }
        }

        public Vector2 PosSoundBarCursor
        {
            get
            {
                return _posSoundBarCursor;
            }

            set
            {
                _posSoundBarCursor = value;
            }
        }

        public Vector2 PosArrowLeft
        {
            get
            {
                return _posArrowLeft;
            }

            set
            {
                _posArrowLeft = value;
            }
        }

        public Vector2 PosArrowRight
        {
            get
            {
                return _posArrowRight;
            }

            set
            {
                _posArrowRight = value;
            }
        }

        public Vector2 SizeArrow
        {
            get
            {
                return _sizeArrow;
            }

            set
            {
                _sizeArrow = value;
            }
        }

        public Vector2 SizeSoundBar
        {
            get
            {
                return _sizeSoundBar;
            }

            set
            {
                _sizeSoundBar = value;
            }
        }

        public Vector2 SizeSoundBarCursor
        {
            get
            {
                return _sizeSoundBarCursor;
            }

            set
            {
                _sizeSoundBarCursor = value;
            }
        }
    }
    #endregion

    #region StructResolution
    struct StructResolution
    {
        Texture2D _txResolutionBar;
        Texture2D _txArrowLeft;
        Texture2D _txArrowRight;
        Vector2 _posArrowLeft;
        Vector2 _posArrowRight;
        Vector2 _posResolutionBar;
        Vector2 _sizeArrow;
        Vector2 _sizeResolutionBar;

        public Texture2D TxResolutionBar
        {
            get
            {
                return _txResolutionBar;
            }

            set
            {
                _txResolutionBar = value;
            }
        }

        public Texture2D TxArrowLeft
        {
            get
            {
                return _txArrowLeft;
            }

            set
            {
                _txArrowLeft = value;
            }
        }

        public Texture2D TxArrowRight
        {
            get
            {
                return _txArrowRight;
            }

            set
            {
                _txArrowRight = value;
            }
        }

        public Vector2 PosArrowLeft
        {
            get
            {
                return _posArrowLeft;
            }

            set
            {
                _posArrowLeft = value;
            }
        }

        public Vector2 PosArrowRight
        {
            get
            {
                return _posArrowRight;
            }

            set
            {
                _posArrowRight = value;
            }
        }

        public Vector2 PosResolutionBar
        {
            get
            {
                return _posResolutionBar;
            }

            set
            {
                _posResolutionBar = value;
            }
        }

        public Vector2 SizeArrow
        {
            get
            {
                return _sizeArrow;
            }

            set
            {
                _sizeArrow = value;
            }
        }

        public Vector2 SizeResolutionBar
        {
            get
            {
                return _sizeResolutionBar;
            }

            set
            {
                _sizeResolutionBar = value;
            }
        }
    }
    #endregion

    #region StructCheckBox

    public struct StructCheckBox
    {
        Texture2D _txCheckedBox;
        Texture2D _txUnCheckedBox;
        Vector2 _posCheckBoxLeft;
        Vector2 _posCheckBoxRight;
        Vector2 _vecSizeCheckBox;
        bool _stateCheckBox;

        public Texture2D TxCheckedBox
        {
            get
            {
                return _txCheckedBox;
            }

            set
            {
                _txCheckedBox = value;
            }
        }

        public Texture2D TxUnCheckedBox
        {
            get
            {
                return _txUnCheckedBox;
            }

            set
            {
                _txUnCheckedBox = value;
            }
        }

        public Vector2 PosCheckBoxLeft
        {
            get
            {
                return _posCheckBoxLeft;
            }

            set
            {
                _posCheckBoxLeft = value;
            }
        }

        public Vector2 PosCheckBoxRight
        {
            get
            {
                return _posCheckBoxRight;
            }

            set
            {
                _posCheckBoxRight = value;
            }
        }

        public Vector2 VecSizeCheckBox
        {
            get
            {
                return _vecSizeCheckBox;
            }

            set
            {
                _vecSizeCheckBox = value;
            }
        }

        public bool StateCheckBox
        {
            get
            {
                return _stateCheckBox;
            }

            set
            {
                _stateCheckBox = value;
            }
        }
    }
    #endregion

    #region StructOptionsTexts
    public struct StructOptionsText
    {
        Texture2D _txBackground;
        Texture2D _txBack;
        Texture2D _txKeybindings;
        Texture2D _txSelectArrow;
        string _textHeader;
        string _textSound;
        string _textResolution;
        string _textAlias;
        string _textAliasOn;
        string _textAliasOff;
        Vector2 _posBack;
        Vector2 _posKeybindings;
        Vector2 _posHeader;
        Vector2 _posSelectArrow;
        Vector2 _posSound;
        Vector2 _posResolution;
        Vector2 _posAlias;
        Vector2 _posAliasOn;
        Vector2 _posAliasOff;
        Vector2 _sizeBack;
        Vector2 _sizeKeybindings;
        Vector2 _sizeSelectArrow;

        public Texture2D TxBackground
        {
            get
            {
                return _txBackground;
            }

            set
            {
                _txBackground = value;
            }
        }

        public Texture2D TxBack
        {
            get
            {
                return _txBack;
            }

            set
            {
                _txBack = value;
            }
        }

        public Texture2D TxKeybindings
        {
            get
            {
                return _txKeybindings;
            }

            set
            {
                _txKeybindings = value;
            }
        }

        public Texture2D TxSelectArrow
        {
            get
            {
                return _txSelectArrow;
            }

            set
            {
                _txSelectArrow = value;
            }
        }

        public string TextHeader
        {
            get
            {
                return _textHeader;
            }

            set
            {
                _textHeader = value;
            }
        }

        public string TextSound
        {
            get
            {
                return _textSound;
            }

            set
            {
                _textSound = value;
            }
        }

        public string TextResolution
        {
            get
            {
                return _textResolution;
            }

            set
            {
                _textResolution = value;
            }
        }

        public string TextAlias
        {
            get
            {
                return _textAlias;
            }

            set
            {
                _textAlias = value;
            }
        }

        public string TextAliasOn
        {
            get
            {
                return _textAliasOn;
            }

            set
            {
                _textAliasOn = value;
            }
        }

        public string TextAliasOff
        {
            get
            {
                return _textAliasOff;
            }

            set
            {
                _textAliasOff = value;
            }
        }

        public Vector2 PosBack
        {
            get
            {
                return _posBack;
            }

            set
            {
                _posBack = value;
            }
        }

        public Vector2 PosKeybindings
        {
            get
            {
                return _posKeybindings;
            }

            set
            {
                _posKeybindings = value;
            }
        }

        public Vector2 PosHeader
        {
            get
            {
                return _posHeader;
            }

            set
            {
                _posHeader = value;
            }
        }

        public Vector2 PosSelectArrow
        {
            get
            {
                return _posSelectArrow;
            }

            set
            {
                _posSelectArrow = value;
            }
        }

        public Vector2 PosSound
        {
            get
            {
                return _posSound;
            }

            set
            {
                _posSound = value;
            }
        }

        public Vector2 PosResolution
        {
            get
            {
                return _posResolution;
            }

            set
            {
                _posResolution = value;
            }
        }

        public Vector2 PosAlias
        {
            get
            {
                return _posAlias;
            }

            set
            {
                _posAlias = value;
            }
        }

        public Vector2 PosAliasOn
        {
            get
            {
                return _posAliasOn;
            }

            set
            {
                _posAliasOn = value;
            }
        }

        public Vector2 PosAliasOff
        {
            get
            {
                return _posAliasOff;
            }

            set
            {
                _posAliasOff = value;
            }
        }

        public Vector2 SizeBack
        {
            get
            {
                return _sizeBack;
            }

            set
            {
                _sizeBack = value;
            }
        }

        public Vector2 SizeKeybindings
        {
            get
            {
                return _sizeKeybindings;
            }

            set
            {
                _sizeKeybindings = value;
            }
        }

        public Vector2 SizeSelectArrow
        {
            get
            {
                return _sizeSelectArrow;
            }

            set
            {
                _sizeSelectArrow = value;
            }
        }
    }
    #endregion
    class OptionsMenu
    {
        int currentGameState;
        StructOptionsMain structOptionsMain;
        GraphicsDeviceManager graphics;
        ContentManager Content;
        SpriteFont spriteFont;
        Song song;
        ControlHandler ch;
        int selectedNumber;
        StructSound strucSound;
        StructResolution structResolution;
        StructCheckBox structCheckBox;
        StructOptionsText structOptionsText;
        MouseState mouse;
        TResolutionOption tResolution;
        TCheckBoxOption cbAlias;
        TSoundOption tSound;
        OptionsText oText;
        int framesPassed;

        public OptionsMenu(StructOptionsMain structOptionsMain)
        {

            this.structOptionsMain = structOptionsMain;
            this.graphics = structOptionsMain.Graphics;
            this.Content = structOptionsMain.Content;
            this.ch = structOptionsMain.Ch;

        }


        public void Init()
        {
            structCheckBox = new StructCheckBox();
            graphics.PreferMultiSampling = structCheckBox.StateCheckBox;
            graphics.ApplyChanges();

            song = Content.Load<Song>("Ismo_Kan_Niet_Hangen_Met_Je");
            MediaPlayer.Play(song);
            MediaPlayer.Volume = 1f;
            this.spriteFont = structOptionsMain.SpriteFont;
            //spriteFont = Content.Load<SpriteFont>("MenuFont");

            strucSound = new StructSound();

            strucSound.PosArrowLeft = new Vector2(2.64f, 3.17f);
            strucSound.TxSoundBar = Content.Load<Texture2D>("SoundBar");
            strucSound.TxSoundBarCursor = Content.Load<Texture2D>("SoundBarCursor");
            strucSound.TxArrowLeft = Content.Load<Texture2D>("ArrowLeft");
            strucSound.TxArrowRight = Content.Load<Texture2D>("ArrowRight");
            strucSound.PosSoundBar = new Vector2(2.32f, 2.6f);
            strucSound.PosSoundBarCursor = new Vector2(1.77f, 3.30f);
            strucSound.PosArrowLeft = new Vector2(2.65f, 3.17f);
            strucSound.PosArrowRight = new Vector2(1.53f, 3.17f);
            strucSound.SizeArrow = new Vector2(43, 35);
            strucSound.SizeSoundBar = new Vector2(200, 10);
            strucSound.SizeSoundBarCursor = new Vector2(22, 35);

            tSound = new TSoundOption(structOptionsMain, strucSound);

            structResolution = new StructResolution();
            structResolution.TxResolutionBar = Content.Load<Texture2D>("ResolutionBar");
            structResolution.TxArrowLeft = Content.Load<Texture2D>("ArrowLeft");
            structResolution.TxArrowRight = Content.Load<Texture2D>("ArrowRight");
            structResolution.PosArrowLeft = new Vector2(2.65f, 2.5f);
            structResolution.PosArrowRight = new Vector2(1.53f, 2.5f);
            structResolution.PosResolutionBar = new Vector2(2.35f, 2.5f);
            structResolution.SizeArrow = new Vector2(43, 35);
            structResolution.SizeResolutionBar = new Vector2(200, 35);
            tResolution = new TResolutionOption(structOptionsMain, structResolution);
            //R.I.P. -> tResolution = new TResolutionOption(graphics, txResolutionBar, txArrowLeft, txArrowRight, posResolutionBar, sizeResolutionBar, posArrowLeft, posArrowRight, sizeArrow, Color.White);
            
            structCheckBox.TxCheckedBox = Content.Load<Texture2D>("CheckboxTrue");
            structCheckBox.TxUnCheckedBox = Content.Load<Texture2D>("CheckboxFalse");
            structCheckBox.PosCheckBoxLeft = new Vector2(2.63f, 2);
            structCheckBox.PosCheckBoxRight = new Vector2(1.79f, 2);
            structCheckBox.VecSizeCheckBox = new Vector2(35, 35);
            cbAlias = new TCheckBoxOption(structOptionsMain, structCheckBox);
            //cbAlias = new TCheckBoxOption(graphics, checkedBox, unCheckedBox, posCheckBoxLeft, posCheckBoxRight, vecSizeCheckBox, stateCheckBox, Color.White);

            structOptionsText.TxBackground = Content.Load<Texture2D>("OptionsBG");

            structOptionsText.TxBack = Content.Load<Texture2D>("Back");
            structOptionsText.TxKeybindings = Content.Load<Texture2D>("Keybindings");
            structOptionsText.TxSelectArrow = Content.Load<Texture2D>("SelectArrow");
            structOptionsText.TextHeader = "JUST ANOTHER OPTIONS MENU";
            structOptionsText.TextSound = "SOUND";
            structOptionsText.TextResolution = "RESOLUTION";
            structOptionsText.TextAlias = "ANTI ALIASING";
            structOptionsText.TextAliasOn = "ON";
            structOptionsText.TextAliasOff = "OFF";
            structOptionsText.PosBack = new Vector2(2.1f, 1.5f);
            structOptionsText.PosKeybindings = new Vector2(2.3f, 1.7f);
            structOptionsText.PosHeader = new Vector2(2.9f, 5f);
            structOptionsText.PosSelectArrow = new Vector2(18f, 3.3f);
            structOptionsText.PosSound = new Vector2(3.75f, 3.2f);
            structOptionsText.PosResolution = new Vector2(5.2f, 2.5f);
            structOptionsText.PosAlias = new Vector2(6.9f, 2f);
            structOptionsText.PosAliasOn = new Vector2(2.35f, 2f);
            structOptionsText.PosAliasOff = new Vector2(1.64f, 2f);
            structOptionsText.SizeBack = new Vector2(65, 20);
            structOptionsText.SizeKeybindings = new Vector2(172, 20);
            structOptionsText.SizeSelectArrow = new Vector2(46, 46);
            oText = new OptionsText(structOptionsMain, structOptionsText);
            //oText = new OptionsText(graphics, txBackground, txBack, posBack, sizeBack, txSelectArrow, posSelectArrow, sizeSelectArrow, spriteFont, textHeader, posHeader, textSound, posSound, textResolution, posResolution, textAlias, posAlias, textAliasOn, posAliasOn, textAliasOff, posAliasOff, Color.White);
            framesPassed = 0;
            selectedNumber = 0;
            tResolution.ChangeResolution(new Vector2(1024, 576));
        }

        public void Update(double gameTime)
        {
            framesPassed++;
            if(framesPassed % 7 == 0)
            {
                if (ch.GetInput().Contains("Up"))
                {
                    if (selectedNumber > 0)
                    {
                        selectedNumber--;
                        switch (selectedNumber)
                        {
                            case 0:
                                {
                                    oText.UpdateSelect(0);
                                    break;
                                }
                            case 1:
                                {
                                    oText.UpdateSelect(1);
                                    break;
                                }
                            case 2:
                                {
                                    oText.UpdateSelect(2);
                                    break;
                                }
                            case 3:
                                {
                                    oText.UpdateSelect(3);
                                    break;
                                }
                            case 4:
                                {
                                    oText.UpdateSelect(4);
                                    break;
                                }
                        }
                    }
                }

                else if (ch.GetInput().Contains("Down"))
                {
                    if (selectedNumber < 4)
                    {
                        selectedNumber++;
                        switch (selectedNumber)
                        {
                            case 0:
                                {
                                    oText.UpdateSelect(0);
                                    break;
                                }
                            case 1:
                                {
                                    oText.UpdateSelect(1);
                                    break;
                                }
                            case 2:
                                {
                                    oText.UpdateSelect(2);
                                    break;
                                }
                            case 3:
                                {
                                    oText.UpdateSelect(3);
                                    break;
                                }
                            case 4:
                                {
                                    oText.UpdateSelect(4);
                                    break;
                                }
                        }
                    }
                    
                }
                else if (ch.GetInput().Contains("Left"))
                {
                    switch(oText.GetMenuState())
                    {
                        case 0:
                            {
                                tSound.SelectLeft();
                                break;
                            }
                        case 1:
                            {
                                tResolution.SelectLeft();
                                break;
                            }
                        case 2:
                            {
                                cbAlias.SelectLeftRight();
                                break;
                            }
                    }
                }

                else if (ch.GetInput().Contains("Right"))
                {
                    switch (oText.GetMenuState())
                    {
                        case 0:
                            {
                                tSound.SelectRight();
                                break;
                            }
                        case 1:
                            {
                                tResolution.SelectRight();
                                break;
                            }
                        case 2:
                            {
                                cbAlias.SelectLeftRight();
                                break;
                            }
                    }
                    }
                else if (ch.GetInput().Contains("Select"))
                {
                    switch (oText.GetMenuState())
                    {
                        case 3:
                            {
                                currentGameState = 7;
                                break;
                            }
                        case 4:
                            {
                                currentGameState = 2;
                                break;
                            }
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
            mouse = Mouse.GetState();
            cbAlias.Update(mouse);
            tResolution.Update(mouse);
            tSound.Update(mouse);
            int oState = oText.Update(mouse);
            if (oState == 2)
            {
                currentGameState = 2;
            }
            else if (oState == 7)
            {
                currentGameState = 7;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            oText.Draw(spriteBatch);
            cbAlias.Draw(spriteBatch);
            tResolution.Draw(spriteBatch, spriteFont);
            tSound.Draw(spriteBatch);
        }

        public int GetCurrentGameState()
        {
            return currentGameState;
        }

    }


}
