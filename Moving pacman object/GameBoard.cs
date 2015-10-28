using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moving_pacman_object
{
    class GameBoard
    {

        private List<Point> _pathPoints = new List<Point>();

        public List<Direction> directionList = new List<Direction>();

        public List<int> score = new List<int>();

        public void AddScorePoints(Point p, Label label, Pellets pellets)
        {
            if(pellets.pellets.Contains(p))
            {
                score.Add(10);
            }
            for (int i = 0; i < score.Count(); i++)
            {
                int sum = 0;
                sum += score[i];
                label.Text = sum.ToString();
                label.Refresh();
            }
            label.Refresh();
            
        }

        private void AddPathPoints(int x1, int y1, int x2, int y2)
        {
            Point p;

            if (x1 == x2)
            {
                if (y1 < y2)
                {
                    for (int y = (int)y1; y < y2 + 1; y++)
                    {
                        p = new Point((int)x1, y);
                        if (!_pathPoints.Contains(p)) _pathPoints.Add(p);
                    }
                }
                else
                {
                    for (int y = (int)y1; y > y2 - 1; y--)
                    {
                        p = new Point((int)x1, y);
                        if (!_pathPoints.Contains(p)) _pathPoints.Add(p);
                    }
                }
            }
            else
            {
                if (x1 < x2)
                {
                    for (int x = (int)x1; x < x2 + 1; x++)
                    {
                        p = new Point(x, (int)y1);
                        if (!_pathPoints.Contains(p)) _pathPoints.Add(p);
                    }
                }
                else
                {
                    for (int x = (int)x1; x > x2 - 1; x--)
                    {
                        p = new Point(x, (int)y1);
                        if (!_pathPoints.Contains(p)) _pathPoints.Add(p);
                    }
                }
            }
        }

        public bool CanMove(Point p, Direction d)
        {
            switch (d)
            {
                case Direction.Left:
                    p.X -= 1;
                    break;

                case Direction.Right:
                    p.X += 1;
                    break;

                case Direction.Up:
                    p.Y -= 1;
                    break;

                case Direction.Down:
                    p.Y += 1;
                    break;
            }

            return _pathPoints.Contains(p);
        }

        public void PaintGamePath(Graphics _graphics)
        {
            // Draw GamePath
            Pen p = new Pen(Color.Red);

            //Horizontal Lines
            _graphics.DrawLine(p, 23, 26, 199, 26);
            _graphics.DrawLine(p, 246, 26, 422, 26);
            _graphics.DrawLine(p, 23, 97, 422, 97);
            _graphics.DrawLine(p, 23, 150, 103, 150);
            _graphics.DrawLine(p, 151, 150, 199, 150);
            _graphics.DrawLine(p, 246, 150, 294, 150);
            _graphics.DrawLine(p, 342, 150, 422, 150);
            _graphics.DrawLine(p, 151, 203, 294, 203);
            _graphics.DrawLine(p, 0, 256, 151, 256);
            _graphics.DrawLine(p, 294, 256, 448, 256);
            _graphics.DrawLine(p, 151, 309, 294, 309);
            _graphics.DrawLine(p, 23, 362, 199, 362);
            _graphics.DrawLine(p, 246, 362, 422, 362);
            _graphics.DrawLine(p, 23, 416, 55, 416);
            _graphics.DrawLine(p, 103, 416, 342, 416);
            _graphics.DrawLine(p, 390, 416, 422, 416);
            _graphics.DrawLine(p, 23, 468, 103, 468);
            _graphics.DrawLine(p, 151, 468, 199, 468);
            _graphics.DrawLine(p, 246, 468, 294, 468);
            _graphics.DrawLine(p, 342, 468, 422, 468);
            _graphics.DrawLine(p, 23, 521, 422, 521);

            //Vertical Lines
            _graphics.DrawLine(p, 23, 27, 23, 150);
            _graphics.DrawLine(p, 23, 363, 23, 415);
            _graphics.DrawLine(p, 23, 469, 23, 520);
            _graphics.DrawLine(p, 55, 417, 55, 467);
            _graphics.DrawLine(p, 103, 26, 103, 467);
            _graphics.DrawLine(p, 151, 98, 151, 150);
            _graphics.DrawLine(p, 151, 204, 151, 361);
            _graphics.DrawLine(p, 151, 417, 151, 467);
            _graphics.DrawLine(p, 199, 27, 199, 97);
            _graphics.DrawLine(p, 199, 151, 199, 202);
            _graphics.DrawLine(p, 199, 363, 199, 416);
            _graphics.DrawLine(p, 199, 469, 199, 520);
            _graphics.DrawLine(p, 246, 27, 246, 97);
            _graphics.DrawLine(p, 246, 151, 246, 202);
            _graphics.DrawLine(p, 246, 363, 246, 416);
            _graphics.DrawLine(p, 246, 469, 246, 520);
            _graphics.DrawLine(p, 294, 98, 294, 150);
            _graphics.DrawLine(p, 294, 204, 294, 361);
            _graphics.DrawLine(p, 294, 417, 294, 467);
            _graphics.DrawLine(p, 342, 26, 342, 467);
            _graphics.DrawLine(p, 390, 417, 390, 467);
            _graphics.DrawLine(p, 422, 27, 422, 150);
            _graphics.DrawLine(p, 422, 363, 422, 415);
            _graphics.DrawLine(p, 422, 469, 422, 520);

            p.Dispose();
        }

        public void GeneratePathPoints()
        {
            //Horizontal lines
            AddPathPoints(23, 26, 199, 26);
            AddPathPoints(246, 26, 422, 26);
            AddPathPoints(23, 97, 422, 97);
            AddPathPoints(23, 150, 103, 150);
            AddPathPoints(151, 150, 199, 150);
            AddPathPoints(246, 150, 294, 150);
            AddPathPoints(342, 150, 422, 150);
            AddPathPoints(151, 203, 294, 203);
            AddPathPoints(0, 256, 151, 256);
            AddPathPoints(294, 256, 448, 256);
            AddPathPoints(151, 309, 294, 309);
            AddPathPoints(23, 362, 199, 362);
            AddPathPoints(246, 362, 422, 362);
            AddPathPoints(23, 416, 55, 416);
            AddPathPoints(103, 416, 342, 416);
            AddPathPoints(390, 416, 422, 416);
            AddPathPoints(23, 468, 103, 468);
            AddPathPoints(151, 468, 199, 468);
            AddPathPoints(246, 468, 294, 468);
            AddPathPoints(342, 468, 422, 468);
            AddPathPoints(23, 521, 422, 521);

            //Vertical Lines

            AddPathPoints(23, 27, 23, 150);
            AddPathPoints(23, 363, 23, 415);
            AddPathPoints(23, 469, 23, 520);
            AddPathPoints(55, 417, 55, 467);
            AddPathPoints(103, 26, 103, 467);
            AddPathPoints(151, 98, 151, 150);
            AddPathPoints(151, 204, 151, 361);
            AddPathPoints(151, 417, 151, 467);
            AddPathPoints(199, 27, 199, 97);
            AddPathPoints(199, 151, 199, 202);
            AddPathPoints(199, 363, 199, 416);
            AddPathPoints(199, 469, 199, 520);
            AddPathPoints(246, 27, 246, 97);
            AddPathPoints(246, 151, 246, 202);
            AddPathPoints(246, 363, 246, 416);
            AddPathPoints(246, 469, 246, 520);
            AddPathPoints(294, 98, 294, 150);
            AddPathPoints(294, 204, 294, 361);
            AddPathPoints(294, 417, 294, 467);
            AddPathPoints(342, 26, 342, 467);
            AddPathPoints(390, 417, 390, 467);
            AddPathPoints(422, 27, 422, 150);
            AddPathPoints(422, 363, 422, 415);
            AddPathPoints(422, 469, 422, 520);
        }

        public void PaintGameBoard(Graphics _graphics)
        {
            SolidBrush b = new SolidBrush(Color.FromArgb(0, 51, 255));

            Pen p = new Pen(b, 2);

            // Outer Box
            _graphics.DrawArc(p, 1, 1, 25, 25, 180, 90);
            _graphics.DrawLine(p, 13, 1, 434, 1);
            _graphics.DrawArc(p, 421, 1, 25, 25, 270, 90);
            _graphics.DrawLine(p, 446, 13, 446, 164);
            _graphics.DrawArc(p, 421, 151, 25, 25, 0, 90);
            _graphics.DrawLine(p, 434, 176, 370, 176);
            _graphics.DrawArc(p, 366, 176, 10, 10, 180, 90);
            _graphics.DrawLine(p, 366, 181, 366, 227);
            _graphics.DrawArc(p, 366, 221, 10, 10, 90, 90);
            _graphics.DrawLine(p, 370, 231, 448, 231);
            _graphics.DrawLine(p, 370, 282, 448, 282);
            _graphics.DrawArc(p, 366, 282, 10, 10, 180, 90);
            _graphics.DrawLine(p, 366, 284, 366, 333);
            _graphics.DrawArc(p, 366, 327, 10, 10, 90, 90);
            _graphics.DrawLine(p, 434, 337, 370, 337);
            _graphics.DrawArc(p, 421, 337, 25, 25, 270, 90);
            _graphics.DrawLine(p, 446, 347, 446, 535);
            _graphics.DrawArc(p, 421, 522, 25, 25, 0, 90);
            _graphics.DrawLine(p, 13, 547, 434, 547);
            _graphics.DrawArc(p, 1, 522, 25, 25, 90, 90);
            _graphics.DrawLine(p, 1, 535, 1, 347);
            _graphics.DrawArc(p, 1, 337, 25, 25, 180, 90);
            _graphics.DrawLine(p, 13, 337, 77, 337);
            _graphics.DrawArc(p, 71, 327, 10, 10, 0, 90);
            _graphics.DrawLine(p, 81, 333, 81, 287);
            _graphics.DrawArc(p, 71, 282, 10, 10, 270, 90);
            _graphics.DrawLine(p, 0, 282, 77, 282);
            _graphics.DrawLine(p, 0, 231, 77, 231);
            _graphics.DrawArc(p, 71, 221, 10, 10, 0, 90);
            _graphics.DrawLine(p, 81, 181, 81, 227);
            _graphics.DrawArc(p, 71, 176, 10, 10, 270, 90);
            _graphics.DrawLine(p, 13, 176, 77, 176);
            _graphics.DrawArc(p, 1, 151, 25, 25, 90, 90);
            _graphics.DrawLine(p, 1, 10, 1, 166);

            // Inner Box
            _graphics.DrawArc(p, 7, 8, 10, 10, 180, 90);
            _graphics.DrawLine(p, 11, 8, 212, 8);
            _graphics.DrawArc(p, 206, 8, 10, 10, 270, 90);
            _graphics.DrawLine(p, 216, 12, 216, 75);
            _graphics.DrawArc(p, 216, 69, 14, 10, 0, 180);
            _graphics.DrawLine(p, 230, 12, 230, 75);
            _graphics.DrawArc(p, 230, 8, 10, 10, 180, 90);
            _graphics.DrawLine(p, 234, 8, 436, 8);
            _graphics.DrawArc(p, 430, 8, 10, 10, 270, 90);
            _graphics.DrawLine(p, 440, 12, 440, 165);
            _graphics.DrawArc(p, 430, 159, 10, 10, 0, 90);
            _graphics.DrawLine(p, 368, 169, 436, 169);
            _graphics.DrawArc(p, 360, 169, 18, 18, 180, 90);
            _graphics.DrawLine(p, 360, 178, 360, 230);
            _graphics.DrawArc(p, 360, 220, 18, 18, 90, 90);
            _graphics.DrawLine(p, 368, 238, 448, 238);
            _graphics.DrawLine(p, 368, 275, 448, 275);
            _graphics.DrawArc(p, 360, 275, 18, 18, 180, 90);
            _graphics.DrawLine(p, 360, 284, 360, 336);
            _graphics.DrawArc(p, 360, 326, 18, 18, 90, 90);
            _graphics.DrawLine(p, 368, 344, 436, 344);
            _graphics.DrawArc(p, 430, 344, 10, 10, 270, 90);
            _graphics.DrawLine(p, 440, 349, 440, 430);
            _graphics.DrawArc(p, 430, 424, 10, 10, 0, 90);
            _graphics.DrawLine(p, 412, 434, 436, 434);
            _graphics.DrawArc(p, 407, 434, 11, 16, 90, 180);
            _graphics.DrawLine(p, 412, 450, 436, 450);
            _graphics.DrawArc(p, 430, 450, 10, 10, 270, 90);
            _graphics.DrawLine(p, 440, 455, 440, 536);
            _graphics.DrawArc(p, 430, 530, 10, 10, 0, 90);
            _graphics.DrawLine(p, 11, 540, 436, 540);
            _graphics.DrawArc(p, 7, 530, 10, 10, 90, 90);
            _graphics.DrawLine(p, 7, 455, 7, 536);
            _graphics.DrawArc(p, 7, 450, 10, 10, 180, 90);
            _graphics.DrawLine(p, 11, 450, 34, 450);
            _graphics.DrawArc(p, 28, 434, 11, 16, 270, 180);
            _graphics.DrawLine(p, 11, 434, 34, 434);
            _graphics.DrawArc(p, 7, 424, 10, 10, 90, 90);
            _graphics.DrawLine(p, 7, 349, 7, 430);
            _graphics.DrawArc(p, 7, 344, 10, 10, 180, 90);
            _graphics.DrawLine(p, 11, 344, 80, 344);
            _graphics.DrawArc(p, 69, 326, 18, 18, 0, 90);
            _graphics.DrawLine(p, 87, 284, 87, 336);
            _graphics.DrawArc(p, 69, 275, 18, 18, 270, 90);
            _graphics.DrawLine(p, 0, 275, 79, 275);
            _graphics.DrawLine(p, 0, 238, 79, 238);
            _graphics.DrawArc(p, 69, 220, 18, 18, 0, 90);
            _graphics.DrawLine(p, 87, 178, 87, 230);
            _graphics.DrawArc(p, 69, 169, 18, 18, 270, 90);
            _graphics.DrawLine(p, 11, 169, 79, 169);
            _graphics.DrawArc(p, 7, 159, 10, 10, 90, 90);
            _graphics.DrawLine(p, 7, 12, 7, 165);

            // Bumpers
            _graphics.DrawLine(p, 45, 45, 83, 45);
            _graphics.DrawArc(p, 77, 45, 10, 10, 270, 90);
            _graphics.DrawLine(p, 87, 50, 87, 75);
            _graphics.DrawArc(p, 77, 69, 10, 10, 0, 90);
            _graphics.DrawLine(p, 45, 79, 83, 79);
            _graphics.DrawArc(p, 41, 69, 10, 10, 90, 90);
            _graphics.DrawLine(p, 41, 50, 41, 75);
            _graphics.DrawArc(p, 41, 45, 10, 10, 180, 90);
            //
            _graphics.DrawLine(p, 125, 45, 179, 45);
            _graphics.DrawArc(p, 173, 45, 10, 10, 270, 90);
            _graphics.DrawLine(p, 183, 50, 183, 75);
            _graphics.DrawArc(p, 173, 69, 10, 10, 0, 90);
            _graphics.DrawLine(p, 125, 79, 179, 79);
            _graphics.DrawArc(p, 121, 69, 10, 10, 90, 90);
            _graphics.DrawLine(p, 121, 50, 121, 75);
            _graphics.DrawArc(p, 121, 45, 10, 10, 180, 90);
            //
            _graphics.DrawLine(p, 269, 45, 323, 45);
            _graphics.DrawArc(p, 316, 45, 10, 10, 270, 90);
            _graphics.DrawLine(p, 326, 50, 326, 75);
            _graphics.DrawArc(p, 316, 69, 10, 10, 0, 90);
            _graphics.DrawLine(p, 269, 79, 323, 79);
            _graphics.DrawArc(p, 265, 69, 10, 10, 90, 90);
            _graphics.DrawLine(p, 265, 50, 265, 75);
            _graphics.DrawArc(p, 265, 45, 10, 10, 180, 90);
            //
            _graphics.DrawLine(p, 364, 45, 403, 45);
            _graphics.DrawArc(p, 396, 45, 10, 10, 270, 90);
            _graphics.DrawLine(p, 406, 50, 406, 75);
            _graphics.DrawArc(p, 396, 69, 10, 10, 0, 90);
            _graphics.DrawLine(p, 364, 79, 404, 79);
            _graphics.DrawArc(p, 360, 69, 10, 10, 90, 90);
            _graphics.DrawLine(p, 360, 50, 360, 75);
            _graphics.DrawArc(p, 360, 45, 10, 10, 180, 90);
            //
            _graphics.DrawLine(p, 46, 116, 82, 116);
            _graphics.DrawArc(p, 76, 116, 11, 16, 270, 180);
            _graphics.DrawLine(p, 46, 132, 82, 132);
            _graphics.DrawArc(p, 41, 116, 11, 16, 90, 180);

            // Top Center "T"
            _graphics.DrawArc(p, 169, 116, 11, 16, 90, 180);
            _graphics.DrawLine(p, 174, 116, 274, 116);
            _graphics.DrawArc(p, 267, 116, 11, 16, 270, 180);
            _graphics.DrawLine(p, 174, 132, 214, 132);
            _graphics.DrawLine(p, 234, 132, 274, 132);
            _graphics.DrawArc(p, 230, 132, 10, 10, 180, 90);
            _graphics.DrawArc(p, 207, 132, 10, 10, 270, 90);
            _graphics.DrawLine(p, 217, 137, 217, 180);
            _graphics.DrawArc(p, 217, 174, 13, 11, 0, 180);
            _graphics.DrawLine(p, 230, 137, 230, 180);
            //
            _graphics.DrawLine(p, 365, 116, 401, 116);
            _graphics.DrawArc(p, 395, 116, 11, 16, 270, 180);
            _graphics.DrawLine(p, 365, 132, 401, 132);
            _graphics.DrawArc(p, 360, 116, 11, 16, 90, 180);
            //
            _graphics.DrawArc(p, 121, 116, 14, 11, 180, 180);
            _graphics.DrawLine(p, 121, 120, 121, 233);
            _graphics.DrawLine(p, 135, 120, 135, 165);
            _graphics.DrawArc(p, 135, 159, 10, 10, 90, 90);
            _graphics.DrawLine(p, 139, 169, 178, 169);
            _graphics.DrawArc(p, 172, 169, 11, 16, 270, 180);
            _graphics.DrawLine(p, 139, 185, 178, 185);
            _graphics.DrawArc(p, 135, 185, 10, 10, 180, 90);
            _graphics.DrawLine(p, 135, 190, 135, 233);
            _graphics.DrawArc(p, 121, 227, 14, 11, 0, 180);
            //
            _graphics.DrawArc(p, 312, 116, 14, 11, 180, 180);
            _graphics.DrawLine(p, 326, 120, 326, 233);
            _graphics.DrawLine(p, 312, 120, 312, 165);
            _graphics.DrawArc(p, 302, 159, 10, 10, 0, 90);
            _graphics.DrawLine(p, 308, 169, 268, 169);
            _graphics.DrawArc(p, 264, 169, 11, 16, 90, 180);
            _graphics.DrawLine(p, 308, 185, 268, 185);
            _graphics.DrawArc(p, 302, 185, 10, 10, 270, 90);
            _graphics.DrawLine(p, 312, 190, 312, 233);
            _graphics.DrawArc(p, 312, 227, 14, 11, 0, 180);

            //Box
            SolidBrush b2 = new SolidBrush(Color.FromArgb(255, 189, 228));
            _graphics.FillRectangle(b2, 207, 223, 33, 5);
            _graphics.DrawLine(p, 168, 222, 207, 222);
            _graphics.DrawLine(p, 169, 222, 169, 291);
            _graphics.DrawLine(p, 168, 291, 279, 291);
            _graphics.DrawLine(p, 278, 291, 278, 222);
            _graphics.DrawLine(p, 240, 222, 279, 222);
            _graphics.DrawLine(p, 241, 222, 241, 229);
            _graphics.DrawLine(p, 240, 229, 272, 229);
            _graphics.DrawLine(p, 272, 284, 272, 228);
            _graphics.DrawLine(p, 175, 284, 273, 284);
            _graphics.DrawLine(p, 175, 229, 175, 285);
            _graphics.DrawLine(p, 174, 229, 207, 229);
            _graphics.DrawLine(p, 206, 222, 206, 229);

            _graphics.DrawArc(p, 121, 275, 14, 11, 180, 180);
            _graphics.DrawLine(p, 121, 280, 121, 339);
            _graphics.DrawArc(p, 121, 333, 14, 11, 0, 180);
            _graphics.DrawLine(p, 135, 280, 135, 339);

            _graphics.DrawArc(p, 312, 275, 14, 11, 180, 180);
            _graphics.DrawLine(p, 312, 280, 312, 339);
            _graphics.DrawArc(p, 312, 333, 14, 11, 0, 180);
            _graphics.DrawLine(p, 326, 280, 326, 339);

            _graphics.DrawArc(p, 41, 381, 11, 16, 90, 180);
            _graphics.DrawLine(p, 46, 381, 83, 381);
            _graphics.DrawArc(p, 76, 381, 11, 16, 270, 90);
            _graphics.DrawLine(p, 46, 397, 68, 397);
            _graphics.DrawArc(p, 62, 397, 11, 16, 270, 90);
            _graphics.DrawLine(p, 73, 405, 73, 445);
            _graphics.DrawLine(p, 87, 389, 87, 445);
            _graphics.DrawArc(p, 73, 439, 14, 11, 0, 180);

            _graphics.DrawLine(p, 126, 381, 178, 381);
            _graphics.DrawArc(p, 171, 381, 11, 16, 270, 180);
            _graphics.DrawLine(p, 126, 397, 178, 397);
            _graphics.DrawArc(p, 121, 381, 11, 16, 90, 180);

            // Mid Center "T"
            _graphics.DrawArc(p, 169, 328, 11, 16, 90, 180);
            _graphics.DrawLine(p, 174, 328, 274, 328);
            _graphics.DrawArc(p, 267, 328, 11, 16, 270, 180);
            _graphics.DrawLine(p, 174, 344, 214, 344);
            _graphics.DrawLine(p, 234, 344, 274, 344);
            _graphics.DrawArc(p, 230, 344, 10, 10, 180, 90);
            _graphics.DrawArc(p, 207, 344, 10, 10, 270, 90);
            _graphics.DrawLine(p, 217, 349, 217, 392);
            _graphics.DrawArc(p, 217, 386, 13, 11, 0, 180);
            _graphics.DrawLine(p, 230, 349, 230, 392);

            _graphics.DrawLine(p, 270, 381, 322, 381);
            _graphics.DrawArc(p, 315, 381, 11, 16, 270, 180);
            _graphics.DrawLine(p, 270, 397, 322, 397);
            _graphics.DrawArc(p, 265, 381, 11, 16, 90, 180);

            _graphics.DrawArc(p, 360, 381, 11, 16, 180, 90);
            _graphics.DrawLine(p, 363, 381, 402, 381);
            _graphics.DrawArc(p, 395, 381, 11, 16, 270, 180);
            _graphics.DrawLine(p, 378, 397, 402, 397);
            _graphics.DrawArc(p, 374, 397, 11, 16, 180, 90);
            _graphics.DrawLine(p, 374, 405, 374, 445);
            _graphics.DrawLine(p, 360, 389, 360, 445);
            _graphics.DrawArc(p, 360, 439, 14, 11, 0, 180);

            _graphics.DrawArc(p, 41, 487, 11, 16, 90, 180);
            _graphics.DrawLine(p, 45, 487, 117, 487);
            _graphics.DrawArc(p, 111, 477, 10, 10, 0, 90);
            _graphics.DrawLine(p, 121, 438, 121, 483);
            _graphics.DrawArc(p, 121, 434, 14, 11, 180, 180);
            _graphics.DrawLine(p, 135, 438, 135, 483);
            _graphics.DrawArc(p, 135, 477, 10, 10, 90, 90);
            _graphics.DrawLine(p, 138, 487, 179, 487);
            _graphics.DrawArc(p, 171, 487, 11, 16, 270, 180);
            _graphics.DrawLine(p, 45, 503, 179, 503);

            // Bottom Center "T"
            _graphics.DrawArc(p, 169, 434, 11, 16, 90, 180);
            _graphics.DrawLine(p, 174, 434, 274, 434);
            _graphics.DrawArc(p, 267, 434, 11, 16, 270, 180);
            _graphics.DrawLine(p, 174, 450, 214, 450);
            _graphics.DrawLine(p, 234, 450, 274, 450);
            _graphics.DrawArc(p, 230, 450, 10, 10, 180, 90);
            _graphics.DrawArc(p, 207, 450, 10, 10, 270, 90);
            _graphics.DrawLine(p, 217, 455, 217, 498);
            _graphics.DrawArc(p, 217, 492, 13, 11, 0, 180);
            _graphics.DrawLine(p, 230, 455, 230, 498);

            _graphics.DrawArc(p, 265, 487, 11, 16, 90, 180);
            _graphics.DrawLine(p, 270, 487, 308, 487);
            _graphics.DrawArc(p, 302, 477, 10, 10, 0, 90);
            _graphics.DrawLine(p, 312, 438, 312, 483);
            _graphics.DrawArc(p, 312, 434, 14, 11, 180, 180);
            _graphics.DrawLine(p, 326, 438, 326, 483);
            _graphics.DrawArc(p, 326, 477, 10, 10, 90, 90);
            _graphics.DrawLine(p, 330, 487, 402, 487);
            _graphics.DrawArc(p, 395, 487, 11, 16, 270, 180);
            _graphics.DrawLine(p, 270, 503, 402, 503);
        }
    }
}
