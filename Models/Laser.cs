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
        public int dx = 10, dy = 10;
        Graphics line;
        Pen pen;

        public Laser()//int x, int y, Pen pen, Graphics line)
        {
            //this.x = x;
            //this.y = y;
            //this.pen = pen;
            //this.line = line;
        }

        public void PlaySound()
        {

        }

        public Point GetPosition()
        {
            Point result = new Point(this.currX, this.currY);
            return result;
        }

        public void Shoot(int x, int y, Pen pen, Graphics line)
        {
            line.DrawLine(pen, currX, currY, x, y);
        }
    }
}
