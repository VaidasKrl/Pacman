using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moving_pacman_object
{
    public partial class Form1 : Form
    {
        private GameLogic gameLogic;

        public Form1()
        {
            InitializeComponent();
            gameLogic = new GameLogic();

        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {

            for (int i = 0; i < gameLogic.Enemies.Count(); i++)
            {
                gameLogic.Enemies[i].DrawEnemyImage(e.Graphics);
            }
            gameLogic.Pellets.DrawPellets(e.Graphics);
            gameLogic.PaintGameBoard(e.Graphics);
            gameLogic.Pacman.DrawPacmanImage(e.Graphics);

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            if (gameLogic.Pacman.Alive)
            {
                gameLogic.MovePacman(gameLogic.Pacman.CurrentDirection);
            }

            scoreLabel.Text = gameLogic.Pellets.Sum.ToString();

            if (gameLogic.GameLevel.IncreaseLevel(gameLogic))
            {
                enemyTimer.Interval -= 5;
                gameLogic.GameLevel.LoadNextLevel();
                gameLogic.Pellets.GeneratePellets();
            }

            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                gameLogic.Pacman.CurrentDirection = Direction.Right;
            }
            else if (e.KeyCode == Keys.Left)
            {
                gameLogic.Pacman.CurrentDirection = Direction.Left;
            }
            if (e.KeyCode == Keys.Up)
            {
                gameLogic.Pacman.CurrentDirection = Direction.Up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                gameLogic.Pacman.CurrentDirection = Direction.Down;
            }
        }
        
        private void enemyTimer_Tick(object sender, EventArgs e)
        {

                gameLogic.MoveEnemies();

                for (int i = 0; i < gameLogic.Enemies.Count(); i++)
                {
                    gameLogic.Enemies[i].DirectionList.Clear();
                }

                levelLabel.Text = gameLogic.GameLevel.Level.ToString();
                labelLives.Text = gameLogic.Pacman.Lives.ToString();

            Invalidate();
        }

        //drawpacman
        //drawpellets
        //drawgameboard
 
    }
}
