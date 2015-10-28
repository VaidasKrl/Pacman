using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_pacman_object
{
    class Pacman: Mover
    {
        public Rectangle boundaries;
        public Bitmap _bmpCharClosed;
        Bitmap _bmpCharOpenAllLeft;
        Bitmap _bmpCharOpenAllRight;
        Bitmap _bmpCharOpenAllUp;
        Bitmap _bmpCharOpenAllDown;

        public bool Alive;

        public int lives;

        public void DrawPacmanImage(Graphics graphics, Direction direction)
        {
            Bitmap b = null;

            switch(direction)
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

            graphics.DrawImageUnscaled(b, imageLocation.X - 15, imageLocation.Y - 15);

        }


        public void GeneratePacman()
        {
            Graphics graphics;

            SolidBrush b = new SolidBrush(Color.FromArgb(255, 255, 0));
            SolidBrush CoverBrush = new SolidBrush(Color.Black);

            Point p = new Point(-1, -1);

            _bmpCharClosed = new Bitmap(30, 30);
            graphics = Graphics.FromImage(_bmpCharClosed);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillEllipse(b, p.X, p.Y, 30, 30);

            _bmpCharOpenAllLeft = new Bitmap(30, 30);
            graphics = Graphics.FromImage(_bmpCharOpenAllLeft);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillEllipse(b, p.X, p.Y, 30, 30);
            graphics.FillPie(CoverBrush, p.X - 2, p.Y, 41, 30, 135, 90);
            graphics.FillRectangle(CoverBrush, p.X + 2, p.Y, 6, 6);
            graphics.FillRectangle(CoverBrush, p.X + 2, p.Y + 25, 6, 6);
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
    }
}
