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
        Master master;
        GuiAccess guiAccess;
        public int sizeX = 25;
        public int sizeY = 12;

        public Form1()
        {
            InitializeComponent();

            //
           
           // Game game = new Game();
          //  Player player = new Player();
         guiAccess = new GuiAccess(this.pictureBox1);
         //   Gameboard gameboard = new Gameboard(1, 2);

        //    guiAccess.RenderBoard(gameboard, player);
            //game.connect(this);

           this.richTextBox1.Enabled = false;
        }


        internal delegate void clickNewGame();
        internal event clickNewGame newGameClicked;

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //game
            putServer_Click(sender, e);
            startGame_Click(sender, e);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Directions directions = Directions.down;
            master.newGame.movePlayer(GetLocalIPAddress(), directions);
            guiAccess.RenderBoard(master.newGame.gameBoard, master.playerCont);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO Server::drop players
            //TODO Server::disconnect server
            //turn off game
            Application.Exit();
        }

        public static string GetLocalIPAddress()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void putServer_Click(object sender, EventArgs e)//start new game and wait for others
        {
            master = new Master(GetLocalIPAddress(), "JA");
            //pokazać okno z oczekiwaniem na graczy i opcja start
        }


        private void startGame_Click(object sender, EventArgs e)//let the hunger games begun
        {
            master.startGame(sizeX, sizeY);
            guiAccess.RenderBoard(master.newGame.gameBoard, master.playerCont);
           
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
            Directions directions = Directions.down;
            master.newGame.movePlayer(GetLocalIPAddress(), directions);
            guiAccess.RenderBoard(master.newGame.gameBoard, master.playerCont);
        }









    }
}
