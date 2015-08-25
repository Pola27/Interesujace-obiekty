using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie01
{
    class Pictures
    {
        List<Image> pictures;

        public Pictures()
        {
            pictures = new List<Image>();
        }


        public List<Image> getPictures()
        {
            return pictures;
        }
        public int loadPictures()
        {
            pictures.Add(Image.FromFile(@"d:\rower01.jpg"));
            pictures.Add(Image.FromFile(@"d:\rower02.jpg"));
            pictures.Add(Image.FromFile(@"d:\rower03.jpg"));
            pictures.Add(Image.FromFile(@"d:\rower04.jpg"));
            pictures.Add(Image.FromFile(@"d:\rower05.jpg"));
            pictures.Add(Image.FromFile(@"d:\rower06.jpg"));
            pictures.Add(Image.FromFile(@"d:\rower07.jpg"));
            pictures.Add(Image.FromFile(@"d:\rower08.jpg"));
            return 8;
        }
    }
}
