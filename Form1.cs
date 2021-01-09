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
        bool deployed = false;
        bool shooting = false;
        private readonly Graphics Graphics;
        private readonly Pen Pen;
        readonly Random r = new Random();
        readonly Timer GenTim = new Timer();

        public List<Ally> Allies = new List<Ally>();
        public List<Enemy> Enemies = new List<Enemy>();

        GameStatus GameStatus = new GameStatus();
        public GameWindow()
        {
            InitializeComponent();
            Graphics = GamePanel.CreateGraphics();
            Pen = new Pen(Color.Red, 3);

            GenTim.Tick += new EventHandler(TimTickGenerateObjects);
            GenTim.Interval = 2000;
            GenTim.Start();

            for(int i = 0; i < 30; i++)
            {
                
                var enemy = new Enemy(100, 100);

              //  Allies.Add(ally);
                Enemies.Add(enemy);
                //GamePanel.Controls.Add(ally);
                //GamePanel.Controls.Add(enemy);
            }
        }

        private void TimTickGenerateObjects(object sender, EventArgs e)
        {
            if (Allies.Count == 3) GenTim.Stop();

            var ally = new Ally(r.Next(300,600), r.Next(300, 600));
            Allies.Add(ally);
            GamePanel.Controls.Add(ally);
            //var npc = Allies[r.Next(0, 29)];
            //GamePanel.Controls.Add(npc);
        }

        //menu controls//
        private void RestartLevelButton_Click(object sender, EventArgs e)
        {
            GameStatus.game = false;
            GameStatus.ResetPoints();
            Allies.Clear();
            GenTim.Start();
        }

        private void pb_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            GamePanel.Controls.Remove(clickedPictureBox);
            clickedPictureBox.Dispose();

            if (clickedPictureBox.GetType() == typeof(Ally)) GameStatus.points -= 100;
            if (clickedPictureBox.GetType() == typeof(Enemy)) GameStatus.points += 10;
            GameStatus.SaveScore();

            Refresh();
        }

        private void NextLevelButton_Click(object sender, EventArgs e)
        {
            GameStatus.NextLevel();
            GameStatus.ResetPoints();
            //Game();

            //var picture = new Ally(300, 200);
            //var picture2 = new Ally(400, 400);
            //var picture3 = new Ally(200, 200);
            //Allies.Add(picture);
            //Allies.Add(picture2);
            //Allies.Add(picture3);

            //GamePanel.Controls.Add(picture);
            //GamePanel.Controls.Add(picture2);
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

            foreach (Ally al in Allies)
            {
                if (e.X >= al.Left && e.X <= al.Right)
                {
                    GameStatus.points -= 10;
                    GameStatus.SaveScore();
                    GamePanel.Controls.Remove(al);
                   // al.Dispose();
                    //   Laser.Shoot();
                    Refresh();
                }

            }
            Console.WriteLine(Allies.Count);
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
        
        public void ClearLists()
        {
            foreach(Ally al in Allies)
            {
                Allies.Remove(al);
            }
        }

        public void Game()
        {
            while (GameStatus.game)
            {
                if (GameStatus.level == 1)
                {
                    foreach(Ally al in Allies)
                    {
                        GamePanel.Controls.Add(al);
                    }
                }
            }
        }
    }
}
