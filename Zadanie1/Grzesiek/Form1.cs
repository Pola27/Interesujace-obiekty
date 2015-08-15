using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie01
{
    public partial class Form1 : Form
    {

        Game game;
        BoardBuilder bb;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            game = new Game();
            
            bb = new BoardBuilder(this, game);

         
        }


        public void pictureClick(object sender, EventArgs e)
        {
            PictureBoxExt pBox = sender as PictureBoxExt;
            if (pBox != null)
            {
                pBox.uncover = !(pBox.uncover);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



    }
}
