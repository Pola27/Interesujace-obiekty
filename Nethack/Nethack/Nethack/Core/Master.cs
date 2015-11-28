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


namespace Nethack.Core
{
    class Master
    {
        public Game newGame;
        public List<Player> playerCont = new List<Player>();

        int zombieNum;
        int playersNum = 1;
        
        public Master(string IP, string Name)
        {
            Player newplayer = new Player();
            newplayer.IP = IP;
            newplayer.Name = Name;
            newplayer.Type = playerType.player;
            playerCont.Add(newplayer);
            zombieNum = 10;


            for (int i = 0; i < zombieNum; i++)
            {

                newplayer.Type = playerType.zombie;
                playerCont.Add(newplayer);
            }

        }
        //game, containerPlayer
        public void addPlayer(string IP, string Name)
        {
            Player newplayer = new Player();
            newplayer.IP = IP;
            newplayer.Name = Name;
            newplayer.Type = playerType.player;
            playerCont.Add(newplayer);
            playersNum++;
        }
        //nasluch na innych graczy

        public void startGame()
        {
            newGame = new Game(playerCont,20,20,zombieNum);
           
            
           // GuiAccess.RenderB
        }

    }
}
