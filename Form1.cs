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

        GameStatus GameStatus = new GameStatus();
        public GameWindow()
        {
            InitializeComponent();
            Graphics = GamePanel.CreateGraphics();
            Pen = new Pen(Color.Red, 3);
        }

        public void Game()
        {
            while (GameStatus.game)
            {
                if (GameStatus.level == 1)
                {

                }
            }
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
            Game();
        }
        //menu controls//

        // mouse movement and shooting//
        private void GamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (shooting != true) return;
            Graphics.DrawLine(Pen, 30, 453, e.X, e.Y);
            Refresh();
        }

        private void GamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= 30)
                shooting = true;
            else
                shooting = false;
        }
        //mouse movement and shooting//            
        
    }
}
