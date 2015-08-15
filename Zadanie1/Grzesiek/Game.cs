using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zadanie01
{
    class Game
    {
        List<Image> cards;
        

        public Game()
        {
            cards = new List<Image>();
            loadCards();
            
        }


        private void loadCards()
        {
            cards.Add(Image.FromFile(@"d:\rower01.jpg"));
            cards.Add(Image.FromFile(@"d:\rower02.jpg"));
            cards.Add(Image.FromFile(@"d:\rower03.jpg"));
            cards.Add(Image.FromFile(@"d:\rower04.jpg"));
            cards.Add(Image.FromFile(@"d:\rower05.jpg"));
            cards.Add(Image.FromFile(@"d:\rower06.jpg"));
            cards.Add(Image.FromFile(@"d:\rower07.jpg"));
            cards.Add(Image.FromFile(@"d:\rower08.jpg"));
            
        }

        public List<Image> getCardsImage()
        {
            return cards;
        }




    }
}
