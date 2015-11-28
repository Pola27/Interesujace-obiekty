using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nethack.Core
{
    public enum tilesState {
    empty=0,
    player=1,
    zombie=3,
    obstacle=4
    };


 public class Gameboard
    {
    tilesState  [,] board = new tilesState [50,50];

    }
}
