using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids.Classes
{
    class GameOverMenu
    {
        ContentManager Content;
        string textUpHeader;
        Vector2 posUpHeader;

        Texture2D txHeader;
        Vector2 posHeader;
        Vector2 sizeHeader;
        Rectangle recHeader;

        string textDownHeader;
        Vector2 posDownHeader;

        string textUpScore;
        Vector2 posUpScore;

        string textScore;
        Vector2 posScore;

        Texture2D txMainMenu;
        Vector2 posMainMenu;
        Vector2 sizeMainMenu;
        Rectangle recMainMenu;

        Texture2D txRetry;
        Vector2 posRetry;
        Vector2 sizeRetry;
        Rectangle recRetry;

        public GameOverMenu(ContentManager Content, string textScore)
        {
            this.Content = Content;

            textUpHeader = "Just Another";
            posUpHeader = new Vector2(2f, 1f);

            txHeader = Content.Load<Texture2D>("HeaderMainMenu");
            posHeader = new Vector2(2f, 1.2f);
            sizeHeader = new Vector2(50f, 150);

            textDownHeader = "Screen";
            posDownHeader = new Vector2(2f, 2f);

            textUpScore = "Your Score:";
            posUpScore = new Vector2(2f, 2.2f);

            this.textScore = textScore;
            posScore = new Vector2(2f, 2.3f);

            txMainMenu = Content.Load<Texture2D>("BtnMainMenu");
            posMainMenu = new Vector2(1.5f, 1.5f);
            sizeMainMenu = new Vector2(50f, 50f);

            txRetry = Content.Load<Texture2D>("BtnRetry");
            posRetry = new Vector2(1.5f, 3f);
            sizeMainMenu = new Vector2(50f, 50f);
        }

        public void Update()
        {

        }
    }
}
