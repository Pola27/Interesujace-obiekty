using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nethack.Core
{
    class Items// moze struktura byłaby lepsza?
    {
        private int ID;
        private itemNames name;
        private int weight;

        public int Id
        {
            get { return ID; }
            set { ID = value; }
        }
        public itemNames itemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Items(itemNames n, int w)
        {
            name = n;
            ID = (int)n;
            weight = w;
        }




    }
}
