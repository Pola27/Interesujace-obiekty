using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nethack.Core;
using Nethack.GUI;


namespace Nethack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Game game = new Game();
            GuiAccess guiAccess = new GuiAccess(this.pictureBox1);
            //game.connect(this);

        }


        internal delegate void clickNewGame();
        internal event clickNewGame newGameClicked;

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //game
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO Server::drop players
            //TODO Server::disconnect server
            //turn off game
            Application.Exit();
        }
    }
}
