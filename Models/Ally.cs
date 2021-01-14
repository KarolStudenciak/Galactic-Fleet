using GwiezdnaFlota.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwiezdnaFlota.Models
{
    public class Ally : PictureBox
    {
        public int x, y;
        public int currX, currY;
        public bool isHit = false;
        public bool reachedBase = false;
    
        readonly Timer MovAllyTim = new Timer();

        public Ally(int x, int y)
        {
            this.x = x;
            this.y = y;
            Name = "pb";
            Location = new Point(x, y);
            Image = Image.FromFile(@"C:\Users\karol\Desktop\C#\GwiezdnaFlota\Galactic-Fleet\Img\allytrans.png");
            Size = new Size(32, 32);
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;

            MovAllyTim.Tick += new EventHandler(MoveX);
            MovAllyTim.Interval = 100;
            MovAllyTim.Start();
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
