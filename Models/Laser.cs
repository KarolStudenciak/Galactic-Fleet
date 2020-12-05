using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwiezdnaFlota.Models
{
    class Laser
    {
        public int x, y;
        public int currX, currY;

        public Laser()
        {

        }

        public void PlaySound()
        {

        }

        public Point GetPosition()
        {
            Point result = new Point(this.currX, this.currY);
            return result;
        }

        public void Shoot()
        {

        }
    }
}
