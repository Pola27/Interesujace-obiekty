using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nethack.Core
{
 

     public class Player
    {
        private int hP = 100;
        private string name;
        private string ip;
        private playerType type;
        private Position position;

        public Player(playerType playertype)
        {
         this.IP = IP;
           this.Name = Name;
            this.Post = new Position(1, 1);
            this.Type = playertype;

     }

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
