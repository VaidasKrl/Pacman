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
        public int Level;
       // public Pellet Pellets;
       // public GameLogic GameLogic;

        public bool IncreaseLevel(GameLogic gameLogic)
        {
            if (gameLogic.Pellets.Pellets.Count() == 0 && gameLogic.Pellets.SuperPellets.Count() == 0)
            {
                return true;
            }
            else
                return false;
        }

        public void ContinueLevel(System.Windows.Forms.Label labelLives, Pacman pacman, List<Enemy> enemies)
        {
            if (pacman.Lives > 0)
            {
                pacman.ImageCurrentLocation = pacman.ImageStartingLocation;
                for (int i = 0; i < enemies.Count(); i++)
                {
                    enemies[i].ImageCurrentLocation = enemies[i].ImageStartingLocation;
                }
                pacman.Alive = true;
                labelLives.Text = pacman.Lives.ToString();
            }
            else
            {
                pacman.Alive = false;
                labelLives.Text = "GAME OVER";
            }
        }
        
    }
}
