using GwiezdnaFlota.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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

        public void PlayLaserSound()
        {
            Stream str = Resources.lasersound;
            using (str)
            {
                SoundPlayer laserSound = new SoundPlayer(str);
                laserSound.Play();
            }
        }

        public void Shoot(int x, int y, Pen pen, Graphics line)
        {
            line.DrawLine(pen, currX, currY, x, y);
        }
    }
}
