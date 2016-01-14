using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Asteroids.Classes
{
    [Serializable()]
   public class Highscores
    {
        public int Score { get; set; }
        public string Name { get; set; }

        public List<Highscores> highscores = new List<Highscores>();

        public void AddHighscore(int score, string name)
        {
            var highscore = new Highscores() { Score = score, Name = name };
            highscores.Add(highscore);
        }

        public void SaveHighScores()
        {
            var serializer = new XmlSerializer(highscores.GetType(), "HighScores.Scores");
            using (var writer = new StreamWriter("Highscores.xml", false))
            {
                serializer.Serialize(writer.BaseStream, highscores);
            }
        }

        public void LoadHighScores()
        {
            var serializer = new XmlSerializer(highscores.GetType(), "HighScores.Scores");
            object obj;
            using (var reader = new StreamReader("highscores.xml"))
            {
                obj = serializer.Deserialize(reader.BaseStream);
            }
            highscores = (List<Highscores>)obj;
        }

        public void SortHighScores()
        {
            highscores.Sort(
            delegate(Highscores p1, Highscores p2)
            {
                return p1.Score.CompareTo(p2.Score);
            }
              );
            highscores.Reverse();

        }
    }
}
