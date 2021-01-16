using GwiezdnaFlota.Models;
using GwiezdnaFlota.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwiezdnaFlota.Game
{
    /// <summary>
    /// Klasa sterująca poziomem, punktacją i dokumentowaniem rozgrywki
    /// </summary>
    public class GameStatus 
    {
        public int points;
        public int level = 1;
        public DateTime session = DateTime.Now;
      
        public GameStatus()
        {

        }

        public void ResetPoints()
        {
            points = 0;
        }

        public void NextLevel()
        {
            level++;
        }
        /// <summary>
        /// Metoda otwiera strumień do pliku tekstowego, zanotowuje dane rozgrywki po czym zamyka strumień
        /// </summary>
        public void SaveScore()
        {
            string path = Environment.CurrentDirectory + "Score.txt";

            StreamWriter str = new StreamWriter(path, true);
            
            using (str)
            {
                str.WriteLine($"\nSesja : {session} \n" + "Wynik: " + points + "\n" + $"Level: {level}");
            }
        }
    }
}
