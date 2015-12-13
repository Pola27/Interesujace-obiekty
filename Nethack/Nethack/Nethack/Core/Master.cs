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

        public delegate void Del(int id, Position p);


        int zombieNum;
        int playersNum = 1;
        
        public Master(string IP, string Name)
        {
            Player newplayer = new Player();
            newplayer.IP = IP;
            newplayer.Name = Name;
            newplayer.Post =new  Position(1, 1);
            newplayer.Type = playerType.player;
            playerCont.Add(newplayer);
            zombieNum = 12;


            for (int i = 1; i < zombieNum+1; i++)
            {
                Player newplayer2 = new Player();
                newplayer2.IP = "zombie";
                newplayer2.Type = playerType.zombie;
                playerCont.Add(newplayer2);
            }

        }
        //game, containerPlayer
        public void addPlayer(string IP, string Name)
        {
            Player newplayer = new Player();
            newplayer.IP = IP;
            newplayer.Name = Name;
            newplayer.Type = playerType.player;
            newplayer.Post = new Position(1, playersNum + 1);
            playerCont.Add(newplayer);
            playersNum++;
        
}
        //nasluch na innych graczy

        public void startGame(int sizeX, int sizeY)
        {
            newGame = new Game(playerCont, sizeX, sizeY, zombieNum, playersNum);
            newGame.DelegatedPos += DelegatedPos;
            
           // GuiAccess.RenderB
        }

        public void DelegatedPos(Position p, int id)
        {
            playerCont[id].Post = p;
        }

    }
}
