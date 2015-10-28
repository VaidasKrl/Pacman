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

        public Point imageLocation;
        public void Move(Direction direction)
        {
            if (direction == Direction.Right)
            {
                imageLocation.X += 1;
            }
            if (direction == Direction.Left)
            {
                imageLocation.X -= 1;
            }
            if (direction == Direction.Up)
            {
                imageLocation.Y -= 1;
            }
            if (direction == Direction.Down)
            {
                imageLocation.Y += 1;
            }
        }
    }
}
