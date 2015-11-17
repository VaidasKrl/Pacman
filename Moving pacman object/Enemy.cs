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
    public class Enemy: Mover
    {
        public Color GhostColor;
        public Bitmap BmpCharUp1;

        public List<Direction> DirectionList = new List<Direction>();

        public Point ImageCurrentLocation
        {
            get { return _imageCurrentLocation; }
            set { _imageCurrentLocation = value; }
        }

        public Point ImageStartingLocation
        {
            get { return _imageStartingLocation; }
            set { _imageStartingLocation = value; }
        }

        public Direction CurrentDirection
        {
            get { return _currentDirection; }
            set { _currentDirection = value; }
        }

    
        public void WhichDirectionCanMove(Point p, List<Point> _pathPoints)
        {

            if (CanMove(p, Direction.Right, _pathPoints))
            {
                DirectionList.Add(Direction.Right);
            }
            if (CanMove(p, Direction.Left, _pathPoints))
            {
                DirectionList.Add(Direction.Left);
            }
            if (CanMove(p, Direction.Up, _pathPoints))
            {
                DirectionList.Add(Direction.Up);
            }
            if (CanMove(p, Direction.Down, _pathPoints))
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

        public void DrawEnemyImage(Graphics graphics)
        {         
                graphics.DrawImageUnscaled(BmpCharUp1, _imageCurrentLocation.X - 15, _imageCurrentLocation.Y - 15);
            
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
