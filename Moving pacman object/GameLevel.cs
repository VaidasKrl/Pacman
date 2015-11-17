using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Moving_pacman_object
{
    public class GameLevel
    {
        private int _level = 1;
        public int Level { get { return _level; } }

        public string PacmanLives;

        public bool IncreaseLevel(GameLogic gameLogic)
        {
            if (gameLogic.Pellets.Pellets.Count == 0 && gameLogic.Pellets.SuperPellets.Count == 0)
            {
                return true;
            }
            
            return false;
        }

        public int LoadNextLevel()
        {
            return _level++;
        }

        
    }
}
