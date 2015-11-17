using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_pacman_object
{
    public abstract class Mover
    {

        protected bool _alive;
        protected int _lives;
        protected Point _imageCurrentLocation;
        protected Point _imageStartingLocation;
        protected Direction _currentDirection;

        public virtual void Move(Direction direction)
        {
            if (direction == Direction.Right)
            {
                _imageCurrentLocation.X += 1;
            }
            if (direction == Direction.Left)
            {
                _imageCurrentLocation.X -= 1;
            }
            if (direction == Direction.Up)
            {
                _imageCurrentLocation.Y -= 1;
            }
            if (direction == Direction.Down)
            {
                _imageCurrentLocation.Y += 1;
            }
        }

        public bool CanMove(Point currentPathPoint, Direction currentDirection, List<Point> _pathPoints)
        {
            switch (currentDirection)
            {
                case Direction.Left:
                    currentPathPoint.X -= 1;
                    break;

                case Direction.Right:
                    currentPathPoint.X += 1;
                    break;

                case Direction.Up:
                    currentPathPoint.Y -= 1;
                    break;

                case Direction.Down:
                    currentPathPoint.Y += 1;
                    break;
            }

            return _pathPoints.Contains(currentPathPoint);
        }

    }
}
