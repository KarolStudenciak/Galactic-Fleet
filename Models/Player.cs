using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwiezdnaFlota.Models
{
    class Player
    {
        public int x;
        public int y;
        public Image img;
        public Player(int x, int y, Image img)
        {
            this.x = x;
            this.y = y;
            this.img = img;
        }
    }
}
