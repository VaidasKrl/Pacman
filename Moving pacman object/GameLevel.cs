using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Moving_pacman_object
{
    class GameLevel
    {
        public int level;
        public Pellets pellets;

        public void IncreaseLevel(Timer timer)
        {
            if(pellets.pellets.Count() == 0 && pellets.superPellets.Count() == 0)
            {
                timer.Interval -= 5;
                level++;
            }
        }
    }
}
