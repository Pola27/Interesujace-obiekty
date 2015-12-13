using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nethack.Core
{
 

     public class Player
    {
        private int hP = 100, sightRange=2, mana=100,exp=0;
        private string name;
        private string ip;
        private playerType type;
        private Position position;
        private ItemContainer itemsContainer;
         // chyba nie powinien byc publiczny, ale nie mam pomysłu na jego metody,
                                           // get/set chyba nie wystarczy, a dublowanie tych z klasy nie ma sensu
         //item, FOV, kontener item, mana, exp



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


         //set lub update
    }
}
