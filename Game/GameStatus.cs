using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwiezdnaFlota.Game
{
    class GameStatus
    {
        public int points = 10;
        public int level;
        public bool game = true;

        public GameStatus()
        {

        }

        public void Game()
        {
            while (game)
            {
                if (level == 1)
                {

                }
            }
        }

        public void ResetPoints()
        {
            points = 0;
        }

        public void NextLevel()
        {
            level++;
        }

        public void SaveScore()
        {            
            StreamWriter str = new StreamWriter(@"C:\Users\karol\Desktop\C#\GwiezdnaFlota\Wyniki.txt");
            int sesja = 0;

            using (str)
            {
                sesja = sesja + 1;
                str.WriteLine($"Sesja {sesja}: " + "Wynik: " + points + "\n\r");
            }
        }
    }
}
