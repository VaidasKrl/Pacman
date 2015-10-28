using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moving_pacman_object
{
    class Pellets
    {
        public List<Point> pellets;
        public List<Point> superPellets;
        public List<int> score = new List<int>();
        int sum = 0;

        public int gameScore;
        
        private SolidBrush brushPowerPellet = new SolidBrush(Color.FromArgb(255, 194, 159));

        public void DrawPellets(Graphics graphics)
        {
            //Pellets
            SolidBrush b = new SolidBrush(Color.FromArgb(255, 194, 159));

            foreach (Point p in pellets)
            {
                graphics.FillEllipse(b, p.X, p.Y, 5, 5);
            }

            foreach (Point p in superPellets)
            {
                graphics.FillEllipse(brushPowerPellet, p.X - 5, p.Y - 5, 15, 15);
            }
        }


        public void RemovePellet(Point Location, Label label)
        {
            Point pntPelletEaten = Point.Empty;
            Point pntPowerPelletEaten = Point.Empty;

            if (pellets.Contains(new Point(Location.X - 2, Location.Y - 2)))
            {
                pntPelletEaten = new Point(Location.X - 2, Location.Y - 2);
                sum += 10;
            }
            else if (superPellets.Contains(new Point(Location.X - 2, Location.Y - 2)))
            {
                pntPowerPelletEaten = new Point(Location.X - 2, Location.Y - 2);
                sum += 50;
            }
            else if (pellets.Contains(new Point(Location.X - 12, Location.Y - 2)))
            {
                pntPelletEaten = new Point(Location.X - 12, Location.Y - 2);
                sum += 10;

            }
            else if (superPellets.Contains(new Point(Location.X - 12, Location.Y - 2)))
            {
                pntPowerPelletEaten = new Point(Location.X - 12, Location.Y - 2);
                sum += 50;
            }
            else if (pellets.Contains(new Point(Location.X + 12, Location.Y - 2)))
            {
                pntPelletEaten = new Point(Location.X + 12, Location.Y - 2);
                sum += 10;
            }
            else if (superPellets.Contains(new Point(Location.X + 12, Location.Y - 2)))
            {
                pntPowerPelletEaten = new Point(Location.X + 12, Location.Y - 2);
                sum += 50;
            }
            else if (pellets.Contains(new Point(Location.X - 2, Location.Y - 12)))
            {
                pntPelletEaten = new Point(Location.X - 2, Location.Y - 12);
                sum += 10;
            }
            else if (superPellets.Contains(new Point(Location.X - 2, Location.Y - 12)))
            {
                pntPowerPelletEaten = new Point(Location.X - 2, Location.Y - 12);
                sum += 50;
            }
            else if (pellets.Contains(new Point(Location.X - 2, Location.Y + 12)))
            {
                pntPelletEaten = new Point(Location.X - 2, Location.Y + 12);
                sum += 10;
            }
            else if (superPellets.Contains(new Point(Location.X - 2, Location.Y + 12)))
            {
                pntPowerPelletEaten = new Point(Location.X - 2, Location.Y + 12);
                sum += 50;
            }

            label.Text = sum.ToString();
            label.Refresh();

            if (pntPelletEaten != Point.Empty)
            {
                pellets.Remove(pntPelletEaten);
            }
            else if (pntPowerPelletEaten != Point.Empty)
            {
                superPellets.Remove(pntPowerPelletEaten);
            }

        }

        public void GeneratePellets()
        {
            // Add Power Pellets
            superPellets = new List<Point>();
            superPellets.Add(new Point(21, 60));
            superPellets.Add(new Point(420, 60));
            superPellets.Add(new Point(21, 414));
            superPellets.Add(new Point(420, 414));

            // Row 1 Accross
            pellets = new List<Point>();
            pellets.Add(new Point(21, 24));
            pellets.Add(new Point(37, 24));
            pellets.Add(new Point(53, 24));
            pellets.Add(new Point(69, 24));
            pellets.Add(new Point(85, 24));
            pellets.Add(new Point(101, 24));
            pellets.Add(new Point(117, 24));
            pellets.Add(new Point(133, 24));
            pellets.Add(new Point(149, 24));
            pellets.Add(new Point(165, 24));
            pellets.Add(new Point(181, 24));
            pellets.Add(new Point(197, 24));
            pellets.Add(new Point(244, 24));
            pellets.Add(new Point(260, 24));
            pellets.Add(new Point(276, 24));
            pellets.Add(new Point(292, 24));
            pellets.Add(new Point(308, 24));
            pellets.Add(new Point(324, 24));
            pellets.Add(new Point(340, 24));
            pellets.Add(new Point(356, 24));
            pellets.Add(new Point(372, 24));
            pellets.Add(new Point(388, 24));
            pellets.Add(new Point(404, 24));
            pellets.Add(new Point(420, 24));

            // Row 2 Accross
            pellets.Add(new Point(21, 42));
            pellets.Add(new Point(101, 42));
            pellets.Add(new Point(197, 42));
            pellets.Add(new Point(244, 42));
            pellets.Add(new Point(340, 42));
            pellets.Add(new Point(420, 42));

            // Row 3 Accorss
            pellets.Add(new Point(101, 60));
            pellets.Add(new Point(197, 60));
            pellets.Add(new Point(244, 60));
            pellets.Add(new Point(340, 60));

            // Row 4 Accorss
            pellets.Add(new Point(21, 77));
            pellets.Add(new Point(101, 77));
            pellets.Add(new Point(197, 77));
            pellets.Add(new Point(244, 77));
            pellets.Add(new Point(340, 77));
            pellets.Add(new Point(420, 77));

            // Row 5 Across
            pellets.Add(new Point(21, 95));
            pellets.Add(new Point(37, 95));
            pellets.Add(new Point(53, 95));
            pellets.Add(new Point(69, 95));
            pellets.Add(new Point(85, 95));
            pellets.Add(new Point(101, 95));
            pellets.Add(new Point(117, 95));
            pellets.Add(new Point(133, 95));
            pellets.Add(new Point(149, 95));
            pellets.Add(new Point(165, 95));
            pellets.Add(new Point(181, 95));
            pellets.Add(new Point(197, 95));
            pellets.Add(new Point(213, 95));
            pellets.Add(new Point(229, 95));
            pellets.Add(new Point(244, 95));
            pellets.Add(new Point(260, 95));
            pellets.Add(new Point(276, 95));
            pellets.Add(new Point(292, 95));
            pellets.Add(new Point(308, 95));
            pellets.Add(new Point(324, 95));
            pellets.Add(new Point(340, 95));
            pellets.Add(new Point(356, 95));
            pellets.Add(new Point(372, 95));
            pellets.Add(new Point(388, 95));
            pellets.Add(new Point(404, 95));
            pellets.Add(new Point(420, 95));

            // Row 6 Across
            pellets.Add(new Point(21, 112));
            pellets.Add(new Point(101, 112));
            pellets.Add(new Point(149, 112));
            pellets.Add(new Point(292, 112));
            pellets.Add(new Point(340, 112));
            pellets.Add(new Point(420, 112));

            // Row 7 Across
            pellets.Add(new Point(21, 130));
            pellets.Add(new Point(101, 130));
            pellets.Add(new Point(149, 130));
            pellets.Add(new Point(292, 130));
            pellets.Add(new Point(340, 130));
            pellets.Add(new Point(420, 130));

            // Row 8 Across
            pellets.Add(new Point(21, 148));
            pellets.Add(new Point(37, 148));
            pellets.Add(new Point(53, 148));
            pellets.Add(new Point(69, 148));
            pellets.Add(new Point(85, 148));
            pellets.Add(new Point(101, 148));
            pellets.Add(new Point(149, 148));
            pellets.Add(new Point(165, 148));
            pellets.Add(new Point(181, 148));
            pellets.Add(new Point(197, 148));
            pellets.Add(new Point(244, 148));
            pellets.Add(new Point(260, 148));
            pellets.Add(new Point(276, 148));
            pellets.Add(new Point(292, 148));
            pellets.Add(new Point(340, 148));
            pellets.Add(new Point(356, 148));
            pellets.Add(new Point(372, 148));
            pellets.Add(new Point(388, 148));
            pellets.Add(new Point(404, 148));
            pellets.Add(new Point(420, 148));

            // Row 9 Across
            pellets.Add(new Point(101, 166));
            pellets.Add(new Point(340, 166));

            // Row 10 Across
            pellets.Add(new Point(101, 183));
            pellets.Add(new Point(340, 183));

            // Row 11 Across
            pellets.Add(new Point(101, 201));
            pellets.Add(new Point(340, 201));

            // Row 12 Across
            pellets.Add(new Point(101, 219));
            pellets.Add(new Point(340, 219));

            // Row 13 Across
            pellets.Add(new Point(101, 236));
            pellets.Add(new Point(340, 236));

            // Row 14 Across
            pellets.Add(new Point(101, 254));
            pellets.Add(new Point(340, 254));

            // Row 15 Across
            pellets.Add(new Point(101, 272));
            pellets.Add(new Point(340, 272));

            // Row 16 Across
            pellets.Add(new Point(101, 290));
            pellets.Add(new Point(340, 290));

            // Row 17 Across
            pellets.Add(new Point(101, 307));
            pellets.Add(new Point(340, 307));

            // Row 18 Across
            pellets.Add(new Point(101, 325));
            pellets.Add(new Point(340, 325));

            // Row 19 Across
            pellets.Add(new Point(101, 343));
            pellets.Add(new Point(340, 343));

            // Row 20 Across
            pellets.Add(new Point(21, 360));
            pellets.Add(new Point(37, 360));
            pellets.Add(new Point(53, 360));
            pellets.Add(new Point(69, 360));
            pellets.Add(new Point(85, 360));
            pellets.Add(new Point(101, 360));
            pellets.Add(new Point(117, 360));
            pellets.Add(new Point(133, 360));
            pellets.Add(new Point(149, 360));
            pellets.Add(new Point(165, 360));
            pellets.Add(new Point(181, 360));
            pellets.Add(new Point(197, 360));
            pellets.Add(new Point(244, 360));
            pellets.Add(new Point(260, 360));
            pellets.Add(new Point(276, 360));
            pellets.Add(new Point(292, 360));
            pellets.Add(new Point(308, 360));
            pellets.Add(new Point(324, 360));
            pellets.Add(new Point(340, 360));
            pellets.Add(new Point(356, 360));
            pellets.Add(new Point(372, 360));
            pellets.Add(new Point(388, 360));
            pellets.Add(new Point(404, 360));
            pellets.Add(new Point(420, 360));

            // Row 21 Across
            pellets.Add(new Point(21, 378));
            pellets.Add(new Point(101, 378));
            pellets.Add(new Point(197, 378));
            pellets.Add(new Point(244, 378));
            pellets.Add(new Point(340, 378));
            pellets.Add(new Point(420, 378));

            // Row 22 Across
            pellets.Add(new Point(21, 396));
            pellets.Add(new Point(101, 396));
            pellets.Add(new Point(197, 396));
            pellets.Add(new Point(244, 396));
            pellets.Add(new Point(340, 396));
            pellets.Add(new Point(420, 396));

            // Row 23 Across
            pellets.Add(new Point(37, 414));
            pellets.Add(new Point(53, 414));
            pellets.Add(new Point(101, 414));
            pellets.Add(new Point(117, 414));
            pellets.Add(new Point(133, 414));
            pellets.Add(new Point(149, 414));
            pellets.Add(new Point(165, 414));
            pellets.Add(new Point(181, 414));
            pellets.Add(new Point(197, 414));
            pellets.Add(new Point(244, 414));
            pellets.Add(new Point(260, 414));
            pellets.Add(new Point(276, 414));
            pellets.Add(new Point(292, 414));
            pellets.Add(new Point(308, 414));
            pellets.Add(new Point(324, 414));
            pellets.Add(new Point(340, 414));
            pellets.Add(new Point(388, 414));
            pellets.Add(new Point(404, 414));

            // Row 24 Across
            pellets.Add(new Point(53, 431));
            pellets.Add(new Point(101, 431));
            pellets.Add(new Point(149, 431));
            pellets.Add(new Point(292, 431));
            pellets.Add(new Point(340, 431));
            pellets.Add(new Point(388, 431));

            // Row 25 Across
            pellets.Add(new Point(53, 449));
            pellets.Add(new Point(101, 449));
            pellets.Add(new Point(149, 449));
            pellets.Add(new Point(292, 449));
            pellets.Add(new Point(340, 449));
            pellets.Add(new Point(388, 449));

            // Row 26 Across
            pellets.Add(new Point(21, 466));
            pellets.Add(new Point(37, 466));
            pellets.Add(new Point(53, 466));
            pellets.Add(new Point(69, 466));
            pellets.Add(new Point(85, 466));
            pellets.Add(new Point(101, 466));
            pellets.Add(new Point(149, 466));
            pellets.Add(new Point(165, 466));
            pellets.Add(new Point(181, 466));
            pellets.Add(new Point(197, 466));
            pellets.Add(new Point(244, 466));
            pellets.Add(new Point(260, 466));
            pellets.Add(new Point(276, 466));
            pellets.Add(new Point(292, 466));
            pellets.Add(new Point(340, 466));
            pellets.Add(new Point(356, 466));
            pellets.Add(new Point(372, 466));
            pellets.Add(new Point(388, 466));
            pellets.Add(new Point(404, 466));
            pellets.Add(new Point(420, 466));

            // Row 27 Across
            pellets.Add(new Point(21, 484));
            pellets.Add(new Point(197, 484));
            pellets.Add(new Point(244, 484));
            pellets.Add(new Point(420, 484));

            // Row 28 Across
            pellets.Add(new Point(21, 502));
            pellets.Add(new Point(197, 502));
            pellets.Add(new Point(244, 502));
            pellets.Add(new Point(420, 502));

            // Row 29 Across
            pellets.Add(new Point(21, 519));
            pellets.Add(new Point(37, 519));
            pellets.Add(new Point(53, 519));
            pellets.Add(new Point(69, 519));
            pellets.Add(new Point(85, 519));
            pellets.Add(new Point(101, 519));
            pellets.Add(new Point(117, 519));
            pellets.Add(new Point(133, 519));
            pellets.Add(new Point(149, 519));
            pellets.Add(new Point(165, 519));
            pellets.Add(new Point(181, 519));
            pellets.Add(new Point(197, 519));
            pellets.Add(new Point(213, 519));
            pellets.Add(new Point(229, 519));
            pellets.Add(new Point(244, 519));
            pellets.Add(new Point(260, 519));
            pellets.Add(new Point(276, 519));
            pellets.Add(new Point(292, 519));
            pellets.Add(new Point(308, 519));
            pellets.Add(new Point(324, 519));
            pellets.Add(new Point(340, 519));
            pellets.Add(new Point(356, 519));
            pellets.Add(new Point(372, 519));
            pellets.Add(new Point(388, 519));
            pellets.Add(new Point(404, 519));
            pellets.Add(new Point(420, 519));
            pellets.Add(new Point(420, 519));
        }
    }
}
