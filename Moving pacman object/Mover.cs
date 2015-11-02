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

        public Point ImageCurrentLocation;
        public Point ImageStartingLocation;
        public Direction CurrentDirection;

        //public List<Point> _pathPoints = new List<Point>();
        public virtual void Move(Direction direction)
        {
            if (direction == Direction.Right)
            {
                ImageCurrentLocation.X += 1;
            }
            if (direction == Direction.Left)
            {
                ImageCurrentLocation.X -= 1;
            }
            if (direction == Direction.Up)
            {
                ImageCurrentLocation.Y -= 1;
            }
            if (direction == Direction.Down)
            {
                ImageCurrentLocation.Y += 1;
            }
        }

        public bool CanMove(List<Point> _p)
        {
            switch (CurrentDirection)
            {
                case Direction.Left:
                    ImageCurrentLocation.X -= 1;
                    break;

                case Direction.Right:
                    ImageCurrentLocation.X += 1;
                    break;

                case Direction.Up:
                    ImageCurrentLocation.Y -= 1;
                    break;

                case Direction.Down:
                    ImageCurrentLocation.Y += 1;
                    break;
            }

            return _p.Contains(ImageCurrentLocation);
        }

    }
}
