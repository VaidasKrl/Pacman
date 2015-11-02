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
        GameLogic gameLogic;

        public Form1()
        {
            InitializeComponent();
            gameLogic = new GameLogic();
            gameLogic.GeneratePathPoints();
            gameLogic.InitializeCharacters();

            scoreLabel.Text = "";
            labelLives.Text = gameLogic.Pacman.Lives.ToString();
            levelLabel.Text = gameLogic.GameLevel.Level.ToString();

        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            gameLogic.DrawObjects(e.Graphics);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameLogic.Pacman.Alive)
            {      
                gameLogic.MovePacman(gameLogic.Pacman.CurrentDirection);
            }
            scoreLabel.Text = gameLogic.Pellets.Sum.ToString();

            if (gameLogic.GameLevel.IncreaseLevel(this.gameLogic))
            {
                enemyTimer.Interval -= 5;
                gameLogic.GameLevel.Level++;
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

            for (int i = 0; i < gameLogic.Enemies.Count(); i++)
            {
                gameLogic.Enemies[i].WhichDirectionCanMove(gameLogic.Enemies[i].ImageCurrentLocation, gameLogic);

                if (gameLogic.CanMove(gameLogic.Enemies[i].ImageCurrentLocation, gameLogic.Enemies[i].CurrentDirection))
                {
                    {
                        gameLogic.Enemies[i].Move(gameLogic.Enemies[i].CurrentDirection);

                        if (gameLogic.Enemies[i].ImageCurrentLocation == gameLogic.Pacman.ImageCurrentLocation)
                        {
                            gameLogic.Pacman.Lives -= 1;
                            gameLogic.Pacman.Alive = false;
                            gameLogic.GameLevel.ContinueLevel(labelLives, gameLogic.Pacman, gameLogic.Enemies);
                        }
                         
                    }
                }
                else
                {
                    gameLogic.Enemies[i].CurrentDirection = gameLogic.Enemies[i].GetRandomDirection();
                }

                gameLogic.Enemies[i].DirectionList.Clear();

                levelLabel.Text = gameLogic.GameLevel.Level.ToString();
            }

            Invalidate();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
 
    }
}
