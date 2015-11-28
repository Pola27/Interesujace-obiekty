using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nethack.Core
{
    public enum Directions
    {
        right,
        left,
        up,
        down
    };

    public enum playerType
    {

        player = 1,
        zombie = 3,

    };
    public enum tilesState
    {
        empty = 0,
        player = 1,
        zombie = 3,
        obstacle = 4
    };

    public struct Position
    {
        public int x, y;

        public Position(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }

}
