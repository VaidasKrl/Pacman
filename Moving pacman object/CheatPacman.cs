using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_pacman_object
{
    public class CheatPacman: Mover, IPacman
    {
    
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


        public void DrawPacmanImage(Graphics _graphics)
        {
            _graphics.DrawImageUnscaled(BmpCharClosed, _imageCurrentLocation.X - 30, _imageCurrentLocation.Y - 30);
        }

        public override void Move(Direction direction)
        {
            if (direction == Direction.Right)
            {
                _imageCurrentLocation.X += 3;
            }
            if (direction == Direction.Left)
            {
                _imageCurrentLocation.X -= 3;
            }
            if (direction == Direction.Up)
            {
                _imageCurrentLocation.Y -= 3;
            }
            if (direction == Direction.Down)
            {
                _imageCurrentLocation.Y += 3;
            }
        }
        public void GeneratePacman()
        {
            Graphics _graphics;

            SolidBrush _b = new SolidBrush(Color.FromArgb(255, 255, 0));
            SolidBrush _coverBrush = new SolidBrush(Color.Black);

            Point _p = new Point(-1, -1);

            BmpCharClosed = new Bitmap(60, 60);
            _graphics = Graphics.FromImage(BmpCharClosed);
            _graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _graphics.FillEllipse(_b, _p.X, _p.Y, 60, 60);
      
        }
      
    }
}
