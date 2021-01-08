using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwiezdnaFlota.Models
{
    public class Enemy : PictureBox
    {
        public int x, y;
        public int currX, currY;
        public bool isHit = false;
        public bool reachedBase = false;

        public Enemy(int x, int y)
        {
            this.Location = new Point(x, y);
            this.Image = Image.FromFile(@"C:\Users\karol\Desktop\C#\GwiezdnaFlota\Galactic-Fleet\Img\enemy.jpg");
            this.Size = new Size(32, 32);
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void ReachedBase()
        {
            var position = Location;

            if (position.X < 30)
                reachedBase = true;
            else
                reachedBase = false;
        }
    }
}
