using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Zadanie01
{
    class BoardBuilder
    {
       // private static Random rng = new Random(); 

        public BoardBuilder (Form1 form, Game game)
        {

            int i = 0;
            while (i <  game.howManyPictures())
            {
                PictureBoxExt pictureBox = new PictureBoxExt();
                pictureBox.Name = "pb" + i.ToString();
                pictureBox.Size = new Size(104, 104);
                pictureBox.Image = game.fetchImage(i);
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox.number = i;
                pictureBox.Visible = true;
                pictureBox.Location = new Point(12+ ((i % 4) * 100 + (i % 4) * 10), 40 + (i / 4) * 100 + ((i/4) % 4 )* 10);
                pictureBox.Click += new EventHandler(form.pictureClick);
                pictureBox.DoubleClick += new EventHandler(form.pictureClick);
                pictureBox.Margin = new Padding(2,2,2,2);
                pictureBox.BackColor = Color.AliceBlue;
                form.Controls.Add(pictureBox);
                i++;
                PictureBoxExt pictureBox1 = new PictureBoxExt();
                pictureBox1.Name = "pb" + i.ToString();
                pictureBox1.Size = new Size(104, 104);
                pictureBox1.Image = game.fetchImage(i);
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox1.number = i;
                pictureBox1.Visible = true;
                pictureBox1.Location = new Point(12 + ((i % 4) * 100 + (i % 4) * 10), 40 + (i / 4) * 100 + ((i / 4) % 4) * 10);
                pictureBox1.Click += new EventHandler(form.pictureClick);
                pictureBox1.DoubleClick += new EventHandler(form.pictureClick);
                pictureBox1.Margin = new Padding(2, 2, 2, 2);
                pictureBox1.BackColor = Color.AliceBlue;
                form.Controls.Add(pictureBox1);
                i++;
                Console.WriteLine(i.ToString());
            }

            /*
            int n = form.Controls.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Control value = form.Controls[k];
                form.Controls[k] = form.Controls[n];
                form.Controls[n] = value;
            }
             */
        


            form.Size = new Size(12 + 4 * 110 + 12, 40 + 4 * 110 + 12+12);
        }
    }
}
