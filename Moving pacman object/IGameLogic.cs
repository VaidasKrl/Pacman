using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moving_pacman_object
{
    public interface IGameLogic
    {
        
        void DrawObjects(Graphics _graphics);

        void InitializeCharacters();

    }
}
