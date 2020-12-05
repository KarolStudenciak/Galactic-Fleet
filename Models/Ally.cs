﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwiezdnaFlota.Models
{
    class Ally
    {
        public int x, y;
        public int currX, currY;
        public bool isHit;
        public Image img;

        public Ally(int x, int y, Image img)
        {
            this.x = x;
            this.y = y;
            this.img = img;
        }

        public bool ReachedBase()
        {
            if (this.x < 30)
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
