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
        /// <summary>
        /// Timer w takt którego generowani są sojusznicy
        /// </summary>
        readonly Timer GenAllies = new Timer();
        /// <summary>
        /// Timer w takt którego generowani są wrogowie
        /// </summary>
        readonly Timer GenEnemies = new Timer();
        /// <summary>
        /// Lista przechowująca sojuszników - tyle ile jest/było aktualnie w użyciu
        /// </summary>
        public List<Ally> Allies = new List<Ally>();
        /// <summary>
        /// Lista przechowująca wrogów - tyle ile jest/było aktualnie w użyciu
        /// </summary>
        public List<Enemy> Enemies = new List<Enemy>();

        readonly Player player; 
        readonly GameStatus GameStatus = new GameStatus();
        readonly Laser Laser = new Laser();
        /// <summary>
        /// Konstruktor konfigurujący timery, formularz, gracza, przygotowania do rozpoczęcia gry
        /// </summary>
        public GameWindow()
        {
            InitializeComponent();
            CenterToScreen();
        
            Graphics = GamePanel.CreateGraphics();

            Pen = new Pen(Color.Red, 4);
            player = new Player(GamePanel.Left, GamePanel.Bottom-64);
            
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
        /// <summary>
        /// Metoda generująca wrogów w takt timera w ilości zależnej od poziomu
        /// </summary>
        public void TimTickGenerateEnemies(object sender, EventArgs e)
        {
            var enemy = new Enemy(GamePanel.Right, r.Next(GamePanel.Top, player.Bounds.Top-32));

            enemy.MouseClick += new MouseEventHandler(NpcClicked);
            enemy.LocationChanged += new EventHandler(CheckLocation);
            
            Enemies.Add(enemy);

            GamePanel.Controls.Add(enemy);
            
            switch (GameStatus.level)
            {
                case 1:
                    if (Enemies.Count == 5)
                    {
                        GenEnemies.Stop();
                        GenEnemies.Dispose();
                    }
                    break;

                case 2:
                    if (Enemies.Count == 8)
                    {
                        GenEnemies.Stop();
                        GenEnemies.Dispose();
                    }
                    break;
            }
        }
        /// <summary>
        /// Metoda generująca sojuszników w takt timera, w ilości zależnej od poziomu
        /// </summary>
        public void TimTickGenerateAllies(object sender, EventArgs e)
        {
            var ally = new Ally(GamePanel.Right, r.Next(GamePanel.Top, player.Bounds.Top-32));

            ally.MouseClick += new MouseEventHandler(NpcClicked);
            ally.LocationChanged += new EventHandler(CheckLocation);

            Allies.Add(ally);

            GamePanel.Controls.Add(ally);
          
            switch (GameStatus.level)
            {
                case 1: if (Allies.Count == 3)
                    {
                        GenAllies.Stop();
                        GenAllies.Dispose();
                    }
                break;

                case 2: if (Allies.Count == 5)
                    {
                        GenAllies.Stop();
                        GenAllies.Dispose();
                    }
                break;
            }           
        }
        /// <summary>
        /// Metoda reagująca na dotarcie obiektów do bazy - liczy punkty, zwiększa poziom jeśli obiekty się skończyły
        /// </summary>
        public void CheckLocation(object sender, EventArgs e)
        {
            PictureBox npc = sender as PictureBox;

            if (npc.Bounds.IntersectsWith(GamePanel.Bounds) && npc.Left <= 0) 
            {
                GamePanel.Controls.Remove(npc);
                Refresh();
                Console.WriteLine(GamePanel.Controls.Count);
                npc.Location = new Point(5000, npc.Location.Y);

                if (npc.GetType() == typeof(Enemy)) GameStatus.points -= 10;
                if (npc.GetType() == typeof(Ally)) GameStatus.points += 10;


                 
                ScoreTextBox.Text = $"Score: {GameStatus.points}";

                if (GamePanel.Controls.Count == 1 && GameStatus.level < 2)
                {
                    GameStatus.level++;
                    Reset();
                }
            }         
        }
        /// <summary>
        /// Metoda obsługująca kliknięty obiekt - naliczanie punktów, usuwanie zestrzelonego obiektu
        /// </summary>
        public void NpcClicked(object sender, EventArgs e)
        {
            if (shooting != true) return;

            PictureBox clickedPictureBox = sender as PictureBox;

            if (clickedPictureBox.GetType() == typeof(Ally)) GameStatus.points -= 10;
            if (clickedPictureBox.GetType() == typeof(Enemy)) GameStatus.points += 10;

            Laser.Shoot(clickedPictureBox.Left, clickedPictureBox.Top, Pen, Graphics);
            
            GamePanel.Controls.Remove(clickedPictureBox);
            Console.WriteLine(GamePanel.Controls.Count);
            
            ScoreTextBox.Text = $"Score: {GameStatus.points}";
          
            Refresh();

            if (GamePanel.Controls.Count == 1 && GameStatus.level < 2)
            {
                GameStatus.level++;
                Reset();
            }

        }
        /// <summary>
        /// Metoda reset zostanie wywołana po naciśnięciu przycisku Restart Level
        /// </summary>
        public void RestartLevelButton_Click(object sender, EventArgs e)
        {
            Reset();
        }
        /// <summary>
        /// Metoda resetująca kontrolki oraz poziom i gracza
        /// </summary>
        public void Reset()
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
        /// <summary>
        /// Kliknięcie Next Level, wywołuje tę metodę zwiększającą poziom
        /// </summary>
        public void NextLevelButton_Click(object sender, EventArgs e)
        {
            if (GameStatus.level == 2) return;

            GameStatus.NextLevel();
            Reset();
        }
        /// <summary>
        /// Metoda strzelająca w miejsce kliknięcia myszką
        /// </summary>
        public void GamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (shooting != true) return;
            
            Laser.Shoot(e.X, e.Y, Pen, Graphics);
            Laser.PlayLaserSound();
        
            Refresh();
        }
        /// <summary>
        /// Metoda nie pozwalająca graczowi strzelać w obiekty, które dotarły do bazy. Gracz strzela tylko w stronę nadlatujących obiektów
        /// </summary>
        public void GamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= player.Bounds.Right)
                shooting = true;
            else
                shooting = false;
        }
        /// <summary>
        /// Po zamknięciu aplikacji, wynik i dane rozgrywki zapisywane są w pliku tekstowym
        /// </summary>
        public void GameWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameStatus.SaveScore();
        }
    }
}
