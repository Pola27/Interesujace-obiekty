using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nethack.Core
{
    class Game
    {
        public List<Player> playerContainer = new List<Player>();
        public Gameboard gameBoard;
       // int k;

        public Game(List<Player> playerCont, int sizeX, int sizeY,int zombieNumb,int playersNum)
        {
            playerContainer = playerCont;
            gameBoard = new Gameboard(sizeX, sizeY, zombieNumb, playersNum);
        }
        public void positionUpdate(Position currentPosition, int k)
        {
            playerContainer[k].Post = currentPosition;
        }


        private void setPlayerPos()
        {
            int sizeOfPlayerC = playerContainer.Count;
            for (int i = 0; i < sizeOfPlayerC; i++)
            {
                Position newPos = new Position(1, i);
                positionUpdate(newPos, i);
            }
        }

        public void positionChange(int iD, int k, int j)
        {
            gameBoard.setBoard(playerContainer[iD].Post.x, playerContainer[iD].Post.y, tilesState.empty);
            Position newPos = new Position(k, j);
            positionUpdate(newPos, iD);
            gameBoard.setBoard(playerContainer[iD].Post.x, playerContainer[iD].Post.y, tilesState.player);
            //updatePosInNetwork

        }

        public void movePlayer(string currentIP, Directions currentDirection)
        {
            for (int i = 0; i < playerContainer.Count; i++)
            {
                if (playerContainer[i].IP == currentIP)
                {
                    Position tempPos = playerContainer[i].Post;
     
                    switch (currentDirection)
                    {
                        case Directions.left:
                            {
                                tempPos.x--;
                                break;
                            }

                        case Directions.right:
                            {
                                tempPos.x++;
                                break;
                            }
                        case Directions.down:
                            {
                                tempPos.y++;
                                break;
                            }
                        case Directions.up:
                            {
                                tempPos.y--;
                                break;
                            }
                        default: break;
                    }
                    switch (gameBoard.checkPos(tempPos.x, tempPos.y))
                    {
                        case tilesState.empty:
                            {
                                positionChange(i, tempPos.x, tempPos.y);
                                break;
                            }
                        case tilesState.player:
                            {
                                break;
                            }
                        case tilesState.zombie:
                            {
                                break;
                            }
                        default: break;
                    }

                }
            }

        }
    }
}
