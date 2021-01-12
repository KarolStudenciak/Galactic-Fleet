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
        readonly Random r = new Random();
        readonly Timer GenAllies = new Timer();
        readonly Timer GenEnemies = new Timer();

        public List<Ally> Allies = new List<Ally>();
        public List<Enemy> Enemies = new List<Enemy>();

        readonly Player player = new Player(30, 453);
        readonly GameStatus GameStatus = new GameStatus();
        readonly Laser Laser = new Laser();

        public GameWindow()
        {
            InitializeComponent();
            Graphics = GamePanel.CreateGraphics();
            Pen = new Pen(Color.Red, 3);
            GamePanel.Controls.Add(player);

            GenAllies.Tick += new EventHandler(TimTickGenerateAllies);
            GenAllies.Interval = 2000;
            GenAllies.Start();

            GenEnemies.Tick += new EventHandler(TimTickGenerateEnemies);
            GenEnemies.Interval = 1500;
            GenEnemies.Start();

            Laser.currX = player.Bounds.Right;
            Laser.currY = player.Bounds.Top;
        }

        private void TimTickGenerateEnemies(object sender, EventArgs e)
        {
            var enemy = new Enemy(r.Next(300, 600), r.Next(300, 600));

            Enemies.Add(enemy);

            GamePanel.Controls.Add(enemy);

            enemy.MouseClick += new MouseEventHandler(NpcClicked);

            if (Enemies.Count == 5) GenEnemies.Stop();
        }

        private void TimTickGenerateAllies(object sender, EventArgs e)
        {
            var ally = new Ally(r.Next(300,600), r.Next(300, 600));

            Allies.Add(ally);

            GamePanel.Controls.Add(ally);

            ally.MouseClick += new MouseEventHandler(NpcClicked);

            if (Allies.Count == 3) GenAllies.Stop();
        }

        //menu controls//
        private void RestartLevelButton_Click(object sender, EventArgs e)
        {
            GameStatus.ResetPoints();

            GamePanel.Controls.Clear();
            Allies.Clear();
            Enemies.Clear();

            GenAllies.Start();

            GamePanel.Controls.Add(player);
        }

        private void NpcClicked(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox.GetType() == typeof(Ally)) GameStatus.points -= 10;
            if (clickedPictureBox.GetType() == typeof(Enemy)) GameStatus.points += 10;

            Laser.Shoot(clickedPictureBox.Left, clickedPictureBox.Top, Pen, Graphics);

            GamePanel.Controls.Remove(clickedPictureBox);
            GameStatus.SaveScore();
          
            Refresh();
        }

        private void NextLevelButton_Click(object sender, EventArgs e)
        {
            GameStatus.NextLevel();

            GameStatus.ResetPoints();
            GamePanel.Controls.Clear();
            Allies.Clear();
        }
        //menu controls//

        // mouse movement and shooting//
        private void GamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (shooting != true) return;

            Laser.Shoot(e.X, e.Y, Pen, Graphics);

            Refresh();
        }

        private void GamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= player.Bounds.Right)
                shooting = true;
            else
                shooting = false;
        }
        //mouse movement and shooting//  
    }
}
