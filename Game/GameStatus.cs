using GwiezdnaFlota.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwiezdnaFlota.Game
{
    public class GameStatus 
    {
        public int points;
        public int level = 1;
      
        public GameStatus()
        {

        }

        public void ResetPoints()
        {
            points = 0;
            SaveScore();
        }

        public void NextLevel()
        {
            level++;
        }

        public void SaveScore()
        {            
            StreamWriter str = new StreamWriter(@"C:\Users\karol\Desktop\C#\GwiezdnaFlota\Galactic-Fleet\Wyniki.txt");
            int sesja = 0;

            using (str)
            {
                sesja = sesja + 1;
                str.WriteLine($"Sesja {sesja}: " + "Wynik: " + points + "\n\r");
            }
        }
    }
}
