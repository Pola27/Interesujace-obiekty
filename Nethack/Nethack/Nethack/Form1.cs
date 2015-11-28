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
            Player player = new Player();
            GuiAccess guiAccess = new GuiAccess(this.pictureBox1);
            Gameboard gameboard = new Gameboard(1,2);

            guiAccess.RenderBoard(gameboard, player);
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


        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)49:
                case (char)52:
                case (char)55:
                    MessageBox.Show("Form.KeyPress: '" +
                        e.KeyChar.ToString() + "' consumed.");
                    e.Handled = true;
                    break;
            }
        }

    }
}
