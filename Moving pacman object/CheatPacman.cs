using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_pacman_object
{
    class CheatPacman: Mover, IPacman
    {
    
        public Bitmap BmpCharClosed;

        public bool Alive;

        public int Lives;
       // public Direction CurrentDirection;

        public void DrawPacmanImage(Graphics _graphics)
        {
            _graphics.DrawImageUnscaled(BmpCharClosed, ImageCurrentLocation.X - 30, ImageCurrentLocation.Y - 30);
        }

        public override void Move(Direction direction)
        {
            //base.Move(direction);
            if (direction == Direction.Right)
            {
                ImageCurrentLocation.X += 3;
            }
            if (direction == Direction.Left)
            {
                ImageCurrentLocation.X -= 3;
            }
            if (direction == Direction.Up)
            {
                ImageCurrentLocation.Y -= 3;
            }
            if (direction == Direction.Down)
            {
                ImageCurrentLocation.Y += 3;
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
