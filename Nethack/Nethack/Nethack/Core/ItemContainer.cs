using Nethack.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nethack
{
    class ItemContainer // ta klasa chyba nie jest potrzebna 
    {
        private List<Items> itemContainer;
        int weight = 0;
        int capacity = 50;

        public void grabItem(Items i)
        {
            if (i.Weight + weight < capacity) { itemContainer.Add(i); }
            else
            {
                System.Windows.Forms.MessageBox.Show("You cannot carry any more","Capacity exceeded");
            }
        }

        public Items seeItem(int id)
        {
            return itemContainer[id];
        }

        public void throwItem(Items id)
        {
            itemContainer.Remove(id);
            weight -= id.Weight;
        }
    
    
    
    
    
    }
}
