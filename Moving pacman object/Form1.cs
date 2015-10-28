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
        Pacman pacman;
        GameBoard gameBoard;
        Pellets pellets;
        Enemies enemy1;
        Enemies enemy2;
        Direction currentPacmanDirection;
        GameLevel gameLevel;
        
        public Rectangle FormArea { get { return this.ClientRectangle; } }

        private Bitmap _bmpPacman;

        public Form1()
        {
            InitializeComponent();
            gameBoard = new GameBoard();
            gameBoard.GeneratePathPoints();

            pacman = new Pacman();
            pacman.imageLocation = new Point(220, 416);
            pacman.boundaries = FormArea;
            pacman.GeneratePacman();
            pacman.alive = true;
            pacman.lives = 3;

            pellets = new Pellets();
            pellets.GeneratePellets();

            enemy1 = new Enemies();
            enemy1.imageLocation = new Point(220, 203);
            enemy1.ghostColor = Color.FromArgb(255, 0, 0);
            enemy1.GenerateCharacters();
            enemy1.currentDirectionEnemy = Direction.Left;

            enemy2 = new Enemies();
            enemy2.imageLocation = new Point(205, 203);
            enemy2.ghostColor = Color.FromArgb(255, 184, 71);
            enemy2.GenerateCharacters();
            enemy2.currentDirectionEnemy = Direction.Right;

            gameLevel = new GameLevel();
            gameLevel.level = 1;

            currentPacmanDirection = new Direction();


            scoreLabel.Text = "";
            labelLives.Text = pacman.lives.ToString();
            levelLabel.Text = gameLevel.level.ToString();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);          

            gameBoard.PaintGameBoard(e.Graphics);
            pellets.DrawPellets(e.Graphics);
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            pacman.DrawPacmanImage(e.Graphics, currentPacmanDirection);
            e.Graphics.DrawImageUnscaled(enemy1._bmpCharUp1, enemy1.imageLocation.X - 15, enemy1.imageLocation.Y - 15);
            e.Graphics.DrawImageUnscaled(enemy2._bmpCharUp1, enemy2.imageLocation.X - 15, enemy2.imageLocation.Y - 15);
            gameBoard.PaintGamePath(e.Graphics);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (pacman.alive)
            {
                if (currentPacmanDirection == Direction.Right)
                {
                    if (gameBoard.CanMove(pacman.imageLocation, currentPacmanDirection))
                        pacman.Move(currentPacmanDirection);

                    pellets.RemovePellet(pacman.imageLocation, scoreLabel);


                }
                else if (currentPacmanDirection == Direction.Left)
                {
                    if (gameBoard.CanMove(pacman.imageLocation, currentPacmanDirection))
                        pacman.Move(currentPacmanDirection);

                    pellets.RemovePellet(pacman.imageLocation, scoreLabel);

                }
                else if (currentPacmanDirection == Direction.Up)
                {
                    if (gameBoard.CanMove(pacman.imageLocation, currentPacmanDirection))
                        pacman.Move(currentPacmanDirection);

                    pellets.RemovePellet(pacman.imageLocation, scoreLabel);

                }
                else if (currentPacmanDirection == Direction.Down)
                {
                    if (gameBoard.CanMove(pacman.imageLocation, currentPacmanDirection))
                        pacman.Move(currentPacmanDirection);

                    pellets.RemovePellet(pacman.imageLocation, scoreLabel);
                }
            }

           // gameLevel.IncreaseLevel(enemyTimer);

            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right)
            {
                currentPacmanDirection = Direction.Right;
            }
            else if (e.KeyCode == Keys.Left)
            {
                currentPacmanDirection = Direction.Left;
            }
            if (e.KeyCode == Keys.Up)
            {
                currentPacmanDirection = Direction.Up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                currentPacmanDirection = Direction.Down;
            }
        }
        
        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            //MoveEnemyToNextPoint(enemy1, pacman, gameBoard);
            //MoveEnemyToNextPoint(enemy2, pacman, gameBoard);
            enemy1.WhichDirectionCanMove(enemy1.imageLocation, gameBoard);

            if (gameBoard.CanMove(enemy1.imageLocation, enemy1.currentDirectionEnemy))
            {
                {
                       enemy1.Move(enemy1.currentDirectionEnemy);
                    if(enemy1.imageLocation == pacman.imageLocation)
                    {
                        pacman.lives -= 1;
                        pacman.alive = false;
                        ContinueLevel();
                    }
                }
            }
            else
            {
                enemy1.currentDirectionEnemy = enemy1.GetRandomDirection();
            }

            enemy1.directionList.Clear();

            enemy2.WhichDirectionCanMove(enemy2.imageLocation, gameBoard);

            if (gameBoard.CanMove(enemy2.imageLocation, enemy2.currentDirectionEnemy))
            {
                {
                    enemy2.Move(enemy2.currentDirectionEnemy);
                    if (enemy2.imageLocation == pacman.imageLocation)
                    {
                        pacman.lives -= 1;
                        pacman.alive = false;
                        ContinueLevel();
                    }
                }
            }
            else
            {
                enemy2.currentDirectionEnemy = enemy2.GetRandomDirection();
            }

            enemy2.directionList.Clear();
            


            
            Invalidate();
        }

        /*public void MoveEnemyToNextPoint(Enemies enemy, Pacman pacman, GameBoard gameBoard)
        {
            enemy.WhichDirectionCanMove(enemy.imageLocation, gameBoard);

            if (gameBoard.CanMove(enemy.imageLocation, enemy.currentDirectionEnemy))
            {
                {
                    enemy.Move(enemy.currentDirectionEnemy);
                    if (enemy.imageLocation == pacman.imageLocation)
                    {
                        pacman.lives -= 1;
                        pacman.alive = false;
                        ContinueLevel();
                    }
                }
            }
            else
            {
                enemy.currentDirectionEnemy = enemy.GetRandomDirection();
            }

            enemy.directionList.Clear();
        }*/

        public void ContinueLevel()
        {
            if(pacman.lives > 0)
            {
                pacman.imageLocation = new Point(220, 416);
                enemy1.imageLocation = new Point(220, 203);
                enemy2.imageLocation = new Point(205, 203);
                pacman.alive = true;
                labelLives.Text = pacman.lives.ToString();
            }
            else
            {
                pacman.alive = false;
                labelLives.Text = "GAME OVER";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
 
    }
}
