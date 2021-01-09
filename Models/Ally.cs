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
    
        readonly Timer MovTim = new Timer();

        public Ally(int x, int y)
        {
            this.x = x;
            this.y = y;
            Name = "pb";
            Location = new Point(x, y);
            Image = Image.FromFile(@"C:\Users\karol\Desktop\C#\GwiezdnaFlota\Galactic-Fleet\Img\ally.jpg");
            Size = new Size(32, 32);
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;

            MovTim.Tick += new EventHandler(TimTickMoveX);
            MovTim.Interval = 100;
            MovTim.Start();
        }

        public void ReachedBase()
        {
            var position = Location;

            if (position.X < 30)
                reachedBase = true;
            else
                reachedBase = false;
        }

        public void TimTickMoveX(object sender, EventArgs e)
        {
            x -= 10;
            Location = new Point(x, y);
            
            //ReachedBase();
           
            //if (reachedBase)
            //{
            //    gm.points -= 100;
            //    gm.SaveScore();
            //}
        }
    }
}
