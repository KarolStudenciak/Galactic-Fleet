using GwiezdnaFlota.Game;
using GwiezdnaFlota.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GwiezdnaFlota.Models
{
    /// <summary>
    /// Klasa odpowiedzialna za obsługę sojusznika
    /// </summary>
    public class Ally : PictureBox
    {
        public int x, y;
        /// <summary>
        /// W rytm tego timera, przesuwany bedzie obiekt sojusznika
        /// </summary>
        readonly Timer MovAllyTim = new Timer();
        /// <summary>
        /// Konstruktor konfigurujący parametry picture boxa - dodawanie EventHandler, obrazek etc.
        /// </summary>
        public Ally(int x, int y)
        {
            this.x = x;
            this.y = y;
            Name = "ally";
            Location = new Point(x, y);
            Image = Resources.allytrans;
            Size = new Size(32, 32);
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;
            MouseClick += new MouseEventHandler(Explode);
            
            MovAllyTim.Tick += new EventHandler(MoveX);
            MovAllyTim.Interval = 1200;
            MovAllyTim.Start();
        }
        /// <summary>
        /// Metoda przesuwająca obiekt w rytm timera
        /// </summary>
        public void MoveX(object sender, EventArgs e)
        {
            x -= 70;
            Left = x;
            Invalidate();
        }
        /// <summary>
        /// Metoda wywoływana gdy obiekt zostanie trafiony (kliknięty) - odtwarza dźwięk wybuchu
        /// </summary>
        public void Explode(object sender, MouseEventArgs e)
        {
            Stream str = Resources.explosionsound;
            using (str)
            {
                SoundPlayer explosionSound = new SoundPlayer(str);
                explosionSound.Play();
            }
        }
    }
}
