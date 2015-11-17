using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moving_pacman_object
{
    public class Pellet
    {
        private SolidBrush _brushPowerPellet = new SolidBrush(Color.FromArgb(255, 194, 159));

        public List<Point> Pellets;
        public List<Point> SuperPellets;
        public List<int> score = new List<int>();
        public int Sum = 0;
        public int GameScore;
 

        public void DrawPellets(Graphics _graphics)
        {
            //Pellets
            SolidBrush _b = new SolidBrush(Color.FromArgb(255, 194, 159));

            foreach (Point p in Pellets)
            {
                _graphics.FillEllipse(_b, p.X, p.Y, 5, 5);
            }

            foreach (Point p in SuperPellets)
            {
                _graphics.FillEllipse(_brushPowerPellet, p.X - 5, p.Y - 5, 15, 15);
            }
        }


        public void RemovePellet(Point Location)
        {
            Point _pntPelletEaten = Point.Empty;
            Point _pntPowerPelletEaten = Point.Empty;

            if (Pellets.Contains(new Point(Location.X - 2, Location.Y - 2)))
            {
                _pntPelletEaten = new Point(Location.X - 2, Location.Y - 2);
                Sum += 10;
            }
            else if (SuperPellets.Contains(new Point(Location.X - 2, Location.Y - 2)))
            {
                _pntPowerPelletEaten = new Point(Location.X - 2, Location.Y - 2);
                Sum += 50;
            }
            else if (Pellets.Contains(new Point(Location.X - 12, Location.Y - 2)))
            {
                _pntPelletEaten = new Point(Location.X - 12, Location.Y - 2);
                Sum += 10;

            }
            else if (SuperPellets.Contains(new Point(Location.X - 12, Location.Y - 2)))
            {
                _pntPowerPelletEaten = new Point(Location.X - 12, Location.Y - 2);
                Sum += 50;
            }
            else if (Pellets.Contains(new Point(Location.X + 12, Location.Y - 2)))
            {
                _pntPelletEaten = new Point(Location.X + 12, Location.Y - 2);
                Sum += 10;
            }
            else if (SuperPellets.Contains(new Point(Location.X + 12, Location.Y - 2)))
            {
                _pntPowerPelletEaten = new Point(Location.X + 12, Location.Y - 2);
                Sum += 50;
            }
            else if (Pellets.Contains(new Point(Location.X - 2, Location.Y - 12)))
            {
                _pntPelletEaten = new Point(Location.X - 2, Location.Y - 12);
                Sum += 10;
            }
            else if (SuperPellets.Contains(new Point(Location.X - 2, Location.Y - 12)))
            {
                _pntPowerPelletEaten = new Point(Location.X - 2, Location.Y - 12);
                Sum += 50;
            }
            else if (Pellets.Contains(new Point(Location.X - 2, Location.Y + 12)))
            {
                _pntPelletEaten = new Point(Location.X - 2, Location.Y + 12);
                Sum += 10;
            }
            else if (SuperPellets.Contains(new Point(Location.X - 2, Location.Y + 12)))
            {
                _pntPowerPelletEaten = new Point(Location.X - 2, Location.Y + 12);
                Sum += 50;
            }

            //label.Text = sum.ToString();
            //label.Refresh();

            if (_pntPelletEaten != Point.Empty)
            {
                Pellets.Remove(_pntPelletEaten);
            }
            else if (_pntPowerPelletEaten != Point.Empty)
            {
                SuperPellets.Remove(_pntPowerPelletEaten);
            }

        }

        public void GeneratePellets()
        {
            // Add Power Pellets
            SuperPellets = new List<Point>();
            SuperPellets.Add(new Point(21, 60));
            SuperPellets.Add(new Point(420, 60));
            SuperPellets.Add(new Point(21, 414));
            SuperPellets.Add(new Point(420, 414));

            // Row 1 Accross
            Pellets = new List<Point>();
            Pellets.Add(new Point(21, 24));
            Pellets.Add(new Point(37, 24));
            Pellets.Add(new Point(53, 24));
            Pellets.Add(new Point(69, 24));
            Pellets.Add(new Point(85, 24));
            Pellets.Add(new Point(101, 24));
            Pellets.Add(new Point(117, 24));
            Pellets.Add(new Point(133, 24));
            Pellets.Add(new Point(149, 24));
            Pellets.Add(new Point(165, 24));
            Pellets.Add(new Point(181, 24));
            Pellets.Add(new Point(197, 24));
            Pellets.Add(new Point(244, 24));
            Pellets.Add(new Point(260, 24));
            Pellets.Add(new Point(276, 24));
            Pellets.Add(new Point(292, 24));
            Pellets.Add(new Point(308, 24));
            Pellets.Add(new Point(324, 24));
            Pellets.Add(new Point(340, 24));
            Pellets.Add(new Point(356, 24));
            Pellets.Add(new Point(372, 24));
            Pellets.Add(new Point(388, 24));
            Pellets.Add(new Point(404, 24));
            Pellets.Add(new Point(420, 24));

            // Row 2 Accross
            Pellets.Add(new Point(21, 42));
            Pellets.Add(new Point(101, 42));
            Pellets.Add(new Point(197, 42));
            Pellets.Add(new Point(244, 42));
            Pellets.Add(new Point(340, 42));
            Pellets.Add(new Point(420, 42));

            // Row 3 Accorss
            Pellets.Add(new Point(101, 60));
            Pellets.Add(new Point(197, 60));
            Pellets.Add(new Point(244, 60));
            Pellets.Add(new Point(340, 60));

            // Row 4 Accorss
            Pellets.Add(new Point(21, 77));
            Pellets.Add(new Point(101, 77));
            Pellets.Add(new Point(197, 77));
            Pellets.Add(new Point(244, 77));
            Pellets.Add(new Point(340, 77));
            Pellets.Add(new Point(420, 77));

            // Row 5 Across
            Pellets.Add(new Point(21, 95));
            Pellets.Add(new Point(37, 95));
            Pellets.Add(new Point(53, 95));
            Pellets.Add(new Point(69, 95));
            Pellets.Add(new Point(85, 95));
            Pellets.Add(new Point(101, 95));
            Pellets.Add(new Point(117, 95));
            Pellets.Add(new Point(133, 95));
            Pellets.Add(new Point(149, 95));
            Pellets.Add(new Point(165, 95));
            Pellets.Add(new Point(181, 95));
            Pellets.Add(new Point(197, 95));
            Pellets.Add(new Point(213, 95));
            Pellets.Add(new Point(229, 95));
            Pellets.Add(new Point(244, 95));
            Pellets.Add(new Point(260, 95));
            Pellets.Add(new Point(276, 95));
            Pellets.Add(new Point(292, 95));
            Pellets.Add(new Point(308, 95));
            Pellets.Add(new Point(324, 95));
            Pellets.Add(new Point(340, 95));
            Pellets.Add(new Point(356, 95));
            Pellets.Add(new Point(372, 95));
            Pellets.Add(new Point(388, 95));
            Pellets.Add(new Point(404, 95));
            Pellets.Add(new Point(420, 95));

            // Row 6 Across
            Pellets.Add(new Point(21, 112));
            Pellets.Add(new Point(101, 112));
            Pellets.Add(new Point(149, 112));
            Pellets.Add(new Point(292, 112));
            Pellets.Add(new Point(340, 112));
            Pellets.Add(new Point(420, 112));

            // Row 7 Across
            Pellets.Add(new Point(21, 130));
            Pellets.Add(new Point(101, 130));
            Pellets.Add(new Point(149, 130));
            Pellets.Add(new Point(292, 130));
            Pellets.Add(new Point(340, 130));
            Pellets.Add(new Point(420, 130));

            // Row 8 Across
            Pellets.Add(new Point(21, 148));
            Pellets.Add(new Point(37, 148));
            Pellets.Add(new Point(53, 148));
            Pellets.Add(new Point(69, 148));
            Pellets.Add(new Point(85, 148));
            Pellets.Add(new Point(101, 148));
            Pellets.Add(new Point(149, 148));
            Pellets.Add(new Point(165, 148));
            Pellets.Add(new Point(181, 148));
            Pellets.Add(new Point(197, 148));
            Pellets.Add(new Point(244, 148));
            Pellets.Add(new Point(260, 148));
            Pellets.Add(new Point(276, 148));
            Pellets.Add(new Point(292, 148));
            Pellets.Add(new Point(340, 148));
            Pellets.Add(new Point(356, 148));
            Pellets.Add(new Point(372, 148));
            Pellets.Add(new Point(388, 148));
            Pellets.Add(new Point(404, 148));
            Pellets.Add(new Point(420, 148));

            // Row 9 Across
            Pellets.Add(new Point(101, 166));
            Pellets.Add(new Point(340, 166));

            // Row 10 Across
            Pellets.Add(new Point(101, 183));
            Pellets.Add(new Point(340, 183));

            // Row 11 Across
            Pellets.Add(new Point(101, 201));
            Pellets.Add(new Point(340, 201));

            // Row 12 Across
            Pellets.Add(new Point(101, 219));
            Pellets.Add(new Point(340, 219));

            // Row 13 Across
            Pellets.Add(new Point(101, 236));
            Pellets.Add(new Point(340, 236));

            // Row 14 Across
            Pellets.Add(new Point(101, 254));
            Pellets.Add(new Point(340, 254));

            // Row 15 Across
            Pellets.Add(new Point(101, 272));
            Pellets.Add(new Point(340, 272));

            // Row 16 Across
            Pellets.Add(new Point(101, 290));
            Pellets.Add(new Point(340, 290));

            // Row 17 Across
            Pellets.Add(new Point(101, 307));
            Pellets.Add(new Point(340, 307));

            // Row 18 Across
            Pellets.Add(new Point(101, 325));
            Pellets.Add(new Point(340, 325));

            // Row 19 Across
            Pellets.Add(new Point(101, 343));
            Pellets.Add(new Point(340, 343));

            // Row 20 Across
            Pellets.Add(new Point(21, 360));
            Pellets.Add(new Point(37, 360));
            Pellets.Add(new Point(53, 360));
            Pellets.Add(new Point(69, 360));
            Pellets.Add(new Point(85, 360));
            Pellets.Add(new Point(101, 360));
            Pellets.Add(new Point(117, 360));
            Pellets.Add(new Point(133, 360));
            Pellets.Add(new Point(149, 360));
            Pellets.Add(new Point(165, 360));
            Pellets.Add(new Point(181, 360));
            Pellets.Add(new Point(197, 360));
            Pellets.Add(new Point(244, 360));
            Pellets.Add(new Point(260, 360));
            Pellets.Add(new Point(276, 360));
            Pellets.Add(new Point(292, 360));
            Pellets.Add(new Point(308, 360));
            Pellets.Add(new Point(324, 360));
            Pellets.Add(new Point(340, 360));
            Pellets.Add(new Point(356, 360));
            Pellets.Add(new Point(372, 360));
            Pellets.Add(new Point(388, 360));
            Pellets.Add(new Point(404, 360));
            Pellets.Add(new Point(420, 360));

            // Row 21 Across
            Pellets.Add(new Point(21, 378));
            Pellets.Add(new Point(101, 378));
            Pellets.Add(new Point(197, 378));
            Pellets.Add(new Point(244, 378));
            Pellets.Add(new Point(340, 378));
            Pellets.Add(new Point(420, 378));

            // Row 22 Across
            Pellets.Add(new Point(21, 396));
            Pellets.Add(new Point(101, 396));
            Pellets.Add(new Point(197, 396));
            Pellets.Add(new Point(244, 396));
            Pellets.Add(new Point(340, 396));
            Pellets.Add(new Point(420, 396));

            // Row 23 Across
            Pellets.Add(new Point(37, 414));
            Pellets.Add(new Point(53, 414));
            Pellets.Add(new Point(101, 414));
            Pellets.Add(new Point(117, 414));
            Pellets.Add(new Point(133, 414));
            Pellets.Add(new Point(149, 414));
            Pellets.Add(new Point(165, 414));
            Pellets.Add(new Point(181, 414));
            Pellets.Add(new Point(197, 414));
            Pellets.Add(new Point(244, 414));
            Pellets.Add(new Point(260, 414));
            Pellets.Add(new Point(276, 414));
            Pellets.Add(new Point(292, 414));
            Pellets.Add(new Point(308, 414));
            Pellets.Add(new Point(324, 414));
            Pellets.Add(new Point(340, 414));
            Pellets.Add(new Point(388, 414));
            Pellets.Add(new Point(404, 414));

            // Row 24 Across
            Pellets.Add(new Point(53, 431));
            Pellets.Add(new Point(101, 431));
            Pellets.Add(new Point(149, 431));
            Pellets.Add(new Point(292, 431));
            Pellets.Add(new Point(340, 431));
            Pellets.Add(new Point(388, 431));

            // Row 25 Across
            Pellets.Add(new Point(53, 449));
            Pellets.Add(new Point(101, 449));
            Pellets.Add(new Point(149, 449));
            Pellets.Add(new Point(292, 449));
            Pellets.Add(new Point(340, 449));
            Pellets.Add(new Point(388, 449));

            // Row 26 Across
            Pellets.Add(new Point(21, 466));
            Pellets.Add(new Point(37, 466));
            Pellets.Add(new Point(53, 466));
            Pellets.Add(new Point(69, 466));
            Pellets.Add(new Point(85, 466));
            Pellets.Add(new Point(101, 466));
            Pellets.Add(new Point(149, 466));
            Pellets.Add(new Point(165, 466));
            Pellets.Add(new Point(181, 466));
            Pellets.Add(new Point(197, 466));
            Pellets.Add(new Point(244, 466));
            Pellets.Add(new Point(260, 466));
            Pellets.Add(new Point(276, 466));
            Pellets.Add(new Point(292, 466));
            Pellets.Add(new Point(340, 466));
            Pellets.Add(new Point(356, 466));
            Pellets.Add(new Point(372, 466));
            Pellets.Add(new Point(388, 466));
            Pellets.Add(new Point(404, 466));
            Pellets.Add(new Point(420, 466));

            // Row 27 Across
            Pellets.Add(new Point(21, 484));
            Pellets.Add(new Point(197, 484));
            Pellets.Add(new Point(244, 484));
            Pellets.Add(new Point(420, 484));

            // Row 28 Across
            Pellets.Add(new Point(21, 502));
            Pellets.Add(new Point(197, 502));
            Pellets.Add(new Point(244, 502));
            Pellets.Add(new Point(420, 502));

            // Row 29 Across
            Pellets.Add(new Point(21, 519));
            Pellets.Add(new Point(37, 519));
            Pellets.Add(new Point(53, 519));
            Pellets.Add(new Point(69, 519));
            Pellets.Add(new Point(85, 519));
            Pellets.Add(new Point(101, 519));
            Pellets.Add(new Point(117, 519));
            Pellets.Add(new Point(133, 519));
            Pellets.Add(new Point(149, 519));
            Pellets.Add(new Point(165, 519));
            Pellets.Add(new Point(181, 519));
            Pellets.Add(new Point(197, 519));
            Pellets.Add(new Point(213, 519));
            Pellets.Add(new Point(229, 519));
            Pellets.Add(new Point(244, 519));
            Pellets.Add(new Point(260, 519));
            Pellets.Add(new Point(276, 519));
            Pellets.Add(new Point(292, 519));
            Pellets.Add(new Point(308, 519));
            Pellets.Add(new Point(324, 519));
            Pellets.Add(new Point(340, 519));
            Pellets.Add(new Point(356, 519));
            Pellets.Add(new Point(372, 519));
            Pellets.Add(new Point(388, 519));
            Pellets.Add(new Point(404, 519));
            Pellets.Add(new Point(420, 519));
            Pellets.Add(new Point(420, 519));
        }
    }
}
