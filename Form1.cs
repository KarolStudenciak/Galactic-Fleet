using GwiezdnaFlota.Game;
using GwiezdnaFlota.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

        readonly Player player; 
        readonly GameStatus GameStatus = new GameStatus();
        readonly Laser Laser = new Laser();

        public GameWindow()
        {
            InitializeComponent();
            Graphics = GamePanel.CreateGraphics();
            Pen = new Pen(Color.Red, 4);
            player = new Player(GamePanel.Left, GamePanel.Bottom);

            GamePanel.Controls.Add(player);

            GenAllies.Tick += new EventHandler(TimTickGenerateAllies);
            GenAllies.Interval = 3000;
            GenAllies.Start();

            GenEnemies.Tick += new EventHandler(TimTickGenerateEnemies);
            GenEnemies.Interval = 1500;
            GenEnemies.Start();

            Laser.currX = player.Bounds.Right;
            Laser.currY = player.Bounds.Top;

            ScoreTextBox.Text = $"Score: {GameStatus.points}";
        }

        private void TimTickGenerateEnemies(object sender, EventArgs e)
        {
            var enemy = new Enemy(GamePanel.Right, r.Next(GamePanel.Top, player.Bounds.Top));

            enemy.MouseClick += new MouseEventHandler(NpcClicked);
            enemy.LocationChanged += new EventHandler(CheckLocation);

            Enemies.Add(enemy);

            GamePanel.Controls.Add(enemy);

            switch (GameStatus.level)
            {
                case 1:
                    if (Enemies.Count == 5) GenEnemies.Stop();
                    break;

                case 2:
                    if (Enemies.Count == 8) GenEnemies.Stop();
                    break;
            }
        }

        private void TimTickGenerateAllies(object sender, EventArgs e)
        {
            var ally = new Ally(GamePanel.Right-65, r.Next(GamePanel.Top, player.Bounds.Top));

            ally.MouseClick += new MouseEventHandler(NpcClicked);
            ally.LocationChanged += new EventHandler(CheckLocation);

            Allies.Add(ally);

            GamePanel.Controls.Add(ally);

            switch (GameStatus.level)
            {
                case 1: if (Allies.Count == 3) GenAllies.Stop();
                break;

                case 2: if (Allies.Count == 5) GenAllies.Stop();
                break;
            }           
        }

        private void CheckLocation(object sender, EventArgs e)
        {
            PictureBox npc = sender as PictureBox;

            if (npc.Bounds.IntersectsWith(GamePanel.Bounds) 
                    && npc.Bounds.Left <= player.Bounds.Left)
            {
                if (npc.GetType() == typeof(Enemy)) GameStatus.points -= 10;
                if (npc.GetType() == typeof(Ally)) GameStatus.points += 10;

                npc.Location = new Point(5000, npc.Location.Y);
                GamePanel.Controls.Remove(npc);
                npc.Dispose();
                 
                ScoreTextBox.Text = $"Score: {GameStatus.points}";
            }         
        }

        private void NpcClicked(object sender, EventArgs e)
        {
            if (shooting != true) return;

            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox.GetType() == typeof(Ally)) GameStatus.points -= 10;
            if (clickedPictureBox.GetType() == typeof(Enemy)) GameStatus.points += 10;

            Laser.Shoot(clickedPictureBox.Left, clickedPictureBox.Top, Pen, Graphics);
        
            GamePanel.Controls.Remove(clickedPictureBox);
            clickedPictureBox.Dispose();
            Console.WriteLine(GamePanel.Controls.Count);
            ScoreTextBox.Text = $"Score: {GameStatus.points}";
          
            Refresh();

        }

        private void RestartLevelButton_Click(object sender, EventArgs e)
        {
            GameStatus.ResetPoints();

            GamePanel.Controls.Clear();
            Allies.Clear();
            Enemies.Clear();

            GenAllies.Start();
            GenEnemies.Start();

            GamePanel.Controls.Add(player);
            ScoreTextBox.Text = $"Score: {GameStatus.points}";
        }

        private void NextLevelButton_Click(object sender, EventArgs e)
        {
            if (GameStatus.level == 2) return;

            GameStatus.NextLevel();
            RestartLevelButton_Click(sender, e);
        }

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

        private void GameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameStatus.SaveScore();
        }
    }
}
