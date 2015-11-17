using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_pacman_object
{
    public class Pacman: Mover, IPacman
    {
        
        Bitmap _bmpCharOpenAllLeft;
        Bitmap _bmpCharOpenAllRight;
        Bitmap _bmpCharOpenAllUp;
        Bitmap _bmpCharOpenAllDown;

        public string LivesLeft;
        public Bitmap BmpCharClosed;

        public bool Alive
        {
            get { return _alive; }
            set { _alive = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

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

        public void DrawPacmanImage(Graphics graphics)
        {
            Bitmap b = null;

            switch(_currentDirection)
            {
                case Direction.Right:
                    b = _bmpCharOpenAllRight;
                    break;
                case Direction.Left:
                    b = _bmpCharOpenAllLeft;
                    break;
                case Direction.Up:
                    b = _bmpCharOpenAllUp;
                    break;
                case Direction.Down:
                    b = _bmpCharOpenAllDown;
                    break;
            }

            graphics.DrawImageUnscaled(b, _imageCurrentLocation.X - 15, _imageCurrentLocation.Y - 15 );

        }


        public void GeneratePacman()
        {
            Graphics _graphics;

            SolidBrush _b = new SolidBrush(Color.FromArgb(255, 255, 0));
            SolidBrush _coverBrush = new SolidBrush(Color.Black);

            Point p = new Point(-1, -1);

            BmpCharClosed = new Bitmap(30, 30);
            _graphics = Graphics.FromImage(BmpCharClosed);
            _graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _graphics.FillEllipse(_b, p.X, p.Y, 30, 30);

            _bmpCharOpenAllLeft = new Bitmap(30, 30);
            _graphics = Graphics.FromImage(_bmpCharOpenAllLeft);
            _graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _graphics.FillEllipse(_b, p.X, p.Y, 30, 30);
            _graphics.FillPie(_coverBrush, p.X - 2, p.Y, 41, 30, 135, 90);
            _graphics.FillRectangle(_coverBrush, p.X + 2, p.Y, 6, 6);
            _graphics.FillRectangle(_coverBrush, p.X + 2, p.Y + 25, 6, 6);
            _bmpCharOpenAllLeft.MakeTransparent(Color.Black);

            _bmpCharOpenAllRight = (Bitmap)_bmpCharOpenAllLeft.Clone();
            _bmpCharOpenAllRight.RotateFlip(RotateFlipType.Rotate180FlipNone);
            _bmpCharOpenAllRight.MakeTransparent(Color.Black);

            _bmpCharOpenAllUp = (Bitmap)_bmpCharOpenAllLeft.Clone();
            _bmpCharOpenAllUp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            _bmpCharOpenAllUp.MakeTransparent(Color.Black);

            _bmpCharOpenAllDown = (Bitmap)_bmpCharOpenAllLeft.Clone();
            _bmpCharOpenAllDown.RotateFlip(RotateFlipType.Rotate270FlipNone);
            _bmpCharOpenAllDown.MakeTransparent(Color.Black);
        }


        public override void Move(Direction direction)
        {
            base.Move(direction);
        }
        
    }
}
