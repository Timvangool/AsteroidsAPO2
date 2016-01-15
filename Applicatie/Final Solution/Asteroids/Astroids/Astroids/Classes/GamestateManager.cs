using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids.Classes
{
    class GamestateManager
    {
        GameState currentGameState;

        enum GameState
        {
            IntroScreen, MainMenu, PlayScreen, GameOverScreen, OptionScreen, Highscores, Keybindings, LoadingScreen, CreditScreen
        }

        public GamestateManager()
        {
            currentGameState = GameState.PlayScreen;
        }

        public void GameStateChanger(int gameStateNumber)
        {
            switch (gameStateNumber)
            {
                case 1:
                    //Intro
                    currentGameState = GameState.IntroScreen;
                    break;
                case 2:
                    //Main Menu
                    currentGameState = GameState.MainMenu;
                    break;
                case 3:
                    //The Game
                    currentGameState = GameState.PlayScreen;
                    break;
                case 4:
                    //Game Over
                    currentGameState = GameState.GameOverScreen;
                    break;
                case 5:
                    //Options
                    currentGameState = GameState.OptionScreen;
                    break;
                case 6:
                    //Highscores
                    currentGameState = GameState.Highscores;
                    break;
                case 7:
                    //Keybindings
                    currentGameState = GameState.Keybindings;
                    break;
                case 8:
                    //Loading Screen
                    currentGameState = GameState.LoadingScreen;
                    break;
                case 9:
                    //Credits
                    currentGameState = GameState.CreditScreen;
                    break;
            }
        }
    }
}
