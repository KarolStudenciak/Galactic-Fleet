using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwiezdnaFlota.Models
{
    class Enemy
    {
        public int x, y;
        public int currX, currY;
        public bool isHit;
        public Image img;

        public Enemy(int x, int y, Image img)
        {
            this.x = x;
            this.y = y;
            this.img = img;
        }

        public bool ReachedBase()
        {
            if (x < 30)
                return true;
            else
                return false;
        }

        public Point GetPosition()
        {
            Point result = new Point(this.currX, this.currY);
            return result;
        }
    }
}
