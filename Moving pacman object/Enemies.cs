using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moving_pacman_object
{
    class Enemies: Mover
    {
        public Color ghostColor;
        public Bitmap _bmpCharUp1;
        //GameBoard gameBoard;
        public Direction currentDirectionEnemy;
        public List<Direction> directionList = new List<Direction>();

        public void WhichDirectionCanMove(Point p, GameBoard gameBoard)
        {

            if (gameBoard.CanMove(p, Direction.Right))
            {
                directionList.Add(Direction.Right);
            }
            if (gameBoard.CanMove(p, Direction.Left))
            {
                directionList.Add(Direction.Left);
            }
            if (gameBoard.CanMove(p, Direction.Up))
            {
                directionList.Add(Direction.Up);
            }
            if (gameBoard.CanMove(p, Direction.Down))
            {
                directionList.Add(Direction.Down);
            }
        }

        public Direction GetRandomDirection()
        {
            Random random = new Random();

            int directionsCount = directionList.Count();

            int randomDirection = random.Next(directionsCount);

            return directionList[randomDirection];

        }

       /* public void MoveToNextDirection(Enemies enemy, Pacman pacman, GameBoard gameBoard)
        {
            enemy.WhichDirectionCanMove(enemy.imageLocation, gameBoard);

            if (gameBoard.CanMove(enemy.imageLocation, enemy.currentDirectionEnemy))
            {
                {
                    enemy.Move(enemy.currentDirectionEnemy);
                    if (enemy.imageLocation == enemy.imageLocation)
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
        }

        public void ContinueLevel(Pacman pacman, Enemies enemy1, Enemies enemy2, Label labelLives)
        {
            if (pacman.lives > 0)
            {
                pacman.imageLocation = new Point(23, 26);
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
        */

        
        public void GenerateCharacters()
        {
            Graphics g;
            SolidBrush b = new SolidBrush(ghostColor);
            SolidBrush EyeBrush = new SolidBrush(Color.White);
            SolidBrush PupilBrush = new SolidBrush(Color.FromArgb(34, 32, 216));
            SolidBrush CoverBrush = new SolidBrush(Color.Black);

            Point p = new Point(-1, -1);

            int _width = 30;
            int _height = 30;

            Bitmap bmpCharBase = new Bitmap(_width, _height);
            bmpCharBase = new Bitmap(_width, _height);
            g = Graphics.FromImage(bmpCharBase);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillEllipse(b, p.X + 3, p.Y, _width - 4, _height - 2);
            g.FillRectangle(b, p.X + 3, p.Y + _height / 2 - 1, _width - 4, _height / 2);


            _bmpCharUp1 = (Bitmap)bmpCharBase.Clone();
            g = Graphics.FromImage(_bmpCharUp1);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPie(CoverBrush, p.X + 3, p.Y + _height - 11, 10, 11, 45, 90);
            g.FillRectangle(CoverBrush, p.X + (_width / 2 - 1), p.Y + _height - 5, 4, 5);
            g.FillPie(CoverBrush, p.X + _width - 11, p.Y + _height - 11, 10, 11, 45, 90);

            _bmpCharUp1.MakeTransparent(Color.Black);
        }

    }
}
