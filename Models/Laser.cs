using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwiezdnaFlota.Models
{
    public class Laser 
    {
        public int x, y;
        public int currX, currY;

        public Laser()
        {

        }

        public void PlaySound()
        {

        }

        public void Shoot(int x, int y, Pen pen, Graphics line)
        {
            line.DrawLine(pen, currX, currY, x, y);
        }
    }
}
