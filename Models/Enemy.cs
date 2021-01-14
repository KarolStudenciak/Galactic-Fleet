using GwiezdnaFlota.Game;
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

        readonly Timer MovEnemyTim = new Timer();

        public Enemy(int x, int y)
        {
            this.x = x;
            this.y = y;
            Location = new Point(x, y);
            Image = Image.FromFile(@"C:\Users\karol\Desktop\C#\GwiezdnaFlota\Galactic-Fleet\Img\enemytrans.png");
            Size = new Size(32, 32);
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;

            MovEnemyTim.Tick += new EventHandler(MoveX);
            MovEnemyTim.Interval = 100;
            MovEnemyTim.Start();
        }

        public void ReachedBase()
        {
            var position = Location;

            if (position.X <= 0)
                reachedBase = true;
            else
                reachedBase = false;
        }

        public void MoveX(object sender, EventArgs e)
        {
            x -= 10;
            Left = x;
        }
    }
}
