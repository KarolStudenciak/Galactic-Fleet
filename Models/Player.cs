using GwiezdnaFlota.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwiezdnaFlota.Models
{
    public class Player : PictureBox
    {
        public int x;
        public int y;

        public Player(int x, int y) 
        {
            this.x = x;
            this.y = y;
            Name = "player";
            Location = new Point(x, y);
            Image = Resources.playertrans;
            Size = new Size(64, 64);
            SizeMode = PictureBoxSizeMode.StretchImage;
            BackColor = Color.Transparent;
        }
    }
}
