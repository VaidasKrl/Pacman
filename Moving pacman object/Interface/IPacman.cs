using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_pacman_object
{
   public  interface IPacman
    {
       void GeneratePacman();
       bool Alive { get; set; }

       int Lives { get; set; }

        void DrawPacmanImage(Graphics graphics);

        Point ImageCurrentLocation { get; set; }
        Point ImageStartingLocation { get; set; }
        Direction CurrentDirection { get; set; }

         void Move(Direction direction);

         bool CanMove(Point currentPathPoint, Direction currentDirection, List<Point> _pathPoints);
       
    }
}
