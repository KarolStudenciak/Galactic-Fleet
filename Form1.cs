using GwiezdnaFlota.Game;
using GwiezdnaFlota.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GwiezdnaFlota
{
    public partial class GameWindow : Form
    {
        bool shooting = false;
        private readonly Graphics Graphics;
        private readonly Pen Pen;

        private List<Ally> Allies = new List<Ally>();
        private List<Enemy> Enemies = new List<Enemy>();

        GameStatus GameStatus = new GameStatus();
        public GameWindow()
        {
            InitializeComponent();
            Graphics = GamePanel.CreateGraphics();
            Pen = new Pen(Color.Red, 3);
        }

        //menu controls//
        private void RestartLevelButton_Click(object sender, EventArgs e)
        {
            GameStatus.game = false;
            GameStatus.ResetPoints();
            Game();
        }

        private void NextLevelButton_Click(object sender, EventArgs e)
        {
            GameStatus.NextLevel();
            GameStatus.ResetPoints();
            //Game();

            var picture = new Ally(300, 200);
          
            GamePanel.Controls.Add(picture);
        }
        //menu controls//

        // mouse movement and shooting//
        private void GamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (shooting != true) return;

            var Laser = new Laser(e.X, e.Y, Pen, Graphics);

            Laser.currX = pictureBox1.Bounds.Right;
            Laser.currY = pictureBox1.Bounds.Top;

            Laser.Shoot();
            Refresh();
        }

        private void GamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= pictureBox1.Bounds.Right)
                shooting = true;
            else
                shooting = false;
        }
        //mouse movement and shooting//            
        public void Game()
        {
            while (GameStatus.game)
            {
                if (GameStatus.level == 1)
                {

                }
            }
        }
    }
}
