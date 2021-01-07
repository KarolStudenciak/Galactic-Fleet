using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwiezdnaFlota.Models
{
    class Ally : PictureBox
    {
        public int x, y;
        public int currX, currY;
        public bool isHit = false;

        public Ally(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.Name = "pb";
            this.Location = new Point(x, y);
            this.Image = Image.FromFile(@"C:\Users\karol\Desktop\C#\GwiezdnaFlota\Galactic-Fleet\Img\ally.jpg");
            this.Size = new Size(32, 32);
        }

        public bool ReachedBase()
        {
            var position = GetPosition();

            if (position.X < 30)
                return true;
            else
                return false;
        }

        public Point GetPosition()
        {
            Point result = new Point(this.currX, this.currY);
            return result;
        }

        public void MoveX()
        {
           
                this.Location = new Point(x + 100, y);
           
        }
    }
}
