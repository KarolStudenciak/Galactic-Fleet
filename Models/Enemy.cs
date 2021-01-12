﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwiezdnaFlota.Models
{
    public class Enemy : PictureBox
    {
        public int x, y;
        public int currX, currY;
        public bool isHit = false;
        public bool reachedBase = false;

        readonly Timer MovTim = new Timer();

        public Enemy(int x, int y)
        {
            this.x = x;
            this.y = y;
            Location = new Point(x, y);
            Image = Image.FromFile(@"C:\Users\karol\Desktop\C#\GwiezdnaFlota\Galactic-Fleet\Img\enemy.jpg");
            Size = new Size(32, 32);
            SizeMode = PictureBoxSizeMode.StretchImage;

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
            Left = x;

            //ReachedBase();

            //if (reachedBase)
            //{
            //    gm.points -= 100;
            //    gm.SaveScore();
            //}
        }
    }
}
