using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_INF1008.Enum
{
    class Direction
    {
        int direction;
        public enum Directions
        {
            HAUT = 0,
            DROITE = 1,
            BAS = 2,
            GAUCHE = 3
        }

        Direction(int i)
        {
            direction = i;
        }
    }
}

