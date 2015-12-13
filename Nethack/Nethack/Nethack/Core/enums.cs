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
   
    public enum itemNames // Item -Int ID- chyba lepiej enuma
    {
        sword=0,
        totch=1,
        mannaPition=2,
        healthPotion=3
    }
    

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
        obstacle = 4,
        door = 2,
        sairsUp = 5,
        stairsDown = 6,
        wallDamaged = 7,
        wallWood = 8,
        wallStone = 9,
        portal = 10,
        plains = 11,
        riverNS = 12,
        riverEW = 13,
        forest = 14,
        pathNS = 15,
        pathEW = 16
        
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
