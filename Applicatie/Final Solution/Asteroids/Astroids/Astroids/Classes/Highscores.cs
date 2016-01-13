using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids.Classes
{
    class Highscores
    {
        private string[] highScores;
        private string[] temp;
        private string lines;
        private string filePath;
        private int loops;

       public Highscores()
       {
           filePath = @"Content\Highscores.txt";
           loops = 0;
       }

       public void WriteHighscoreToFile(int score, string name)
       {
           highScores = System.IO.File.ReadAllLines(System.IO.Path.GetFullPath(filePath));
           string temp = string.Empty;

           foreach (string line in highScores)
           {
               temp += line;
           }

           string tempScore = score.ToString();
           string tempName = name;
           System.IO.File.WriteAllText(System.IO.Path.GetFullPath(filePath), temp + "Name: " + tempName + " " + "Score: " + tempScore + " >");
       }

       public void ReadHighscoresFromFile()
       {
           using (System.IO.StreamReader sr = new System.IO.StreamReader(System.IO.Path.GetFullPath(filePath)))
           {
               lines = sr.ReadToEnd();
           }
       }

       public void CutArray()
       {
           string temp2 = string.Empty;
           temp = new string[lines.Length];

           for (int i = 0; i < temp.Length; i++)
           {
               if (lines[i] == '>')
               {
                   temp[loops] = temp2;
                   loops++;
                   temp2 = string.Empty;
               }
               else
               {
                   temp2 += lines[i];
               }
           }
       }

       public void SortHighscores()
       {
           List<string> sortingList = temp.ToList<string>();
           sortingList.Sort();
       }
    }
}
