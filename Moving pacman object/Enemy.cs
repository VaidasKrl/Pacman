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
    class Enemy: Mover
    {
        public Color GhostColor;
        public Bitmap BmpCharUp1;
        //GameBoard gameBoard;
        //public Direction CurrentDirection;
        public List<Direction> DirectionList = new List<Direction>();

        public void WhichDirectionCanMove(Point p, GameLogic gameBoard)
        {

            if (gameBoard.CanMove(p, Direction.Right))
            {
                DirectionList.Add(Direction.Right);
            }
            if (gameBoard.CanMove(p, Direction.Left))
            {
                DirectionList.Add(Direction.Left);
            }
            if (gameBoard.CanMove(p, Direction.Up))
            {
                DirectionList.Add(Direction.Up);
            }
            if (gameBoard.CanMove(p, Direction.Down))
            {
                DirectionList.Add(Direction.Down);
            }
            
        }

        public Direction GetRandomDirection()
        {
            Random _random = new Random();

            int directionsCount = DirectionList.Count();

            int randomDirection = _random.Next(directionsCount);

            return DirectionList[randomDirection];

        }

        public void DrawEnemyImage(Graphics _graphics, List<Enemy> _enemies)
        {
            for (int i = 0; i < _enemies.Count(); i++)
            {
                _graphics.DrawImageUnscaled(_enemies[i].BmpCharUp1, ImageCurrentLocation.X - 15, ImageCurrentLocation.Y - 15);
            }
        }



        
        public void GenerateEnemy()
        {
            Graphics _graphics;
            SolidBrush b = new SolidBrush(GhostColor);
            SolidBrush _eyeBrush = new SolidBrush(Color.White);
            SolidBrush _pupilBrush = new SolidBrush(Color.FromArgb(34, 32, 216));
            SolidBrush _coverBrush = new SolidBrush(Color.Black);

            Point _p = new Point(-1, -1);

            int _width = 30;
            int _height = 30;

            Bitmap _bmpCharBase = new Bitmap(_width, _height);
            _bmpCharBase = new Bitmap(_width, _height);
            _graphics = Graphics.FromImage(_bmpCharBase);
            _graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _graphics.FillEllipse(b, _p.X + 3, _p.Y, _width - 4, _height - 2);
            _graphics.FillRectangle(b, _p.X + 3, _p.Y + _height / 2 - 1, _width - 4, _height / 2);


            BmpCharUp1 = (Bitmap)_bmpCharBase.Clone();
            _graphics = Graphics.FromImage(BmpCharUp1);
            _graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _graphics.FillPie(_coverBrush, _p.X + 3, _p.Y + _height - 11, 10, 11, 45, 90);
            _graphics.FillRectangle(_coverBrush, _p.X + (_width / 2 - 1), _p.Y + _height - 5, 4, 5);
            _graphics.FillPie(_coverBrush, _p.X + _width - 11, _p.Y + _height - 11, 10, 11, 45, 90);

            BmpCharUp1.MakeTransparent(Color.Black);
        }

    }
}
