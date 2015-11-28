using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Tuple;
using System.Threading.Tasks;

namespace Nethack.Core
{
    public enum playerType
    {

        player = 1,
        zombie = 3,

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

    public class Player
    {
        private int hP = 100;
        private string name;
        private string ip;
        private playerType type;
        private Position position;

        public int HP
        {
            get { return hP; }
            set { hP = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public playerType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }

        public Position Post
        {
            get { return position; }
            set { position = value; }
        }

    }
}
