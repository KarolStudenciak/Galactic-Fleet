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
    public class Ally : PictureBox
    {
        public int x, y;

        readonly Timer MovAllyTim = new Timer();
 
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

        public void MoveX(object sender, EventArgs e)
        {
            x -= 70;
            Left = x;
            Invalidate();
        }

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
