using GwiezdnaFlota.Game;
using System;
using System.Collections.Generic;
using GwiezdnaFlota.Properties;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace GwiezdnaFlota.Models
{
    /// <summary>
    /// Klasa odpowiedzialna za obsługę wroga
    /// </summary>
    public class Enemy : PictureBox
    {
        public int x, y;
        /// <summary>
        /// Timer w takt którego wróg będzie przesuwany
        /// </summary>
        readonly Timer MovEnemyTim = new Timer();
        /// <summary>
        /// Konstruktor konfiguruje parametry obiektu, obrazek położenie, reakcja na zdarzenia etc.
        /// </summary>
        public Enemy(int x, int y)
        {
            this.x = x;
            this.y = y;
            Name = "enemy";
            Location = new Point(x, y);
            Image = Resources.enemytrans;
            Size = new Size(32, 32);
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;
            MouseClick += new MouseEventHandler(Explode);

            MovEnemyTim.Tick += new EventHandler(MoveX);
            MovEnemyTim.Interval = 1300;
            MovEnemyTim.Start();
        }
        /// <summary>
        /// Metoda porusza wroga w takt zegara
        /// </summary>
        public void MoveX(object sender, EventArgs e)
        {
            x -= 70;
            Left = x;
            Invalidate();
        }
        /// <summary>
        /// Metoda przywołana gdy wróg zostaje trafiony, odtwarza dźwięk wybuchu
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
