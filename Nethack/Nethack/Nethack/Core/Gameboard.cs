using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nethack.Core
{
  

    public class Gameboard
    {
        public tilesState[,] board;


        public Gameboard(int sizeX, int sizeY,int zombieNumb, int playersNumb)
        {
            board = new tilesState[sizeX, sizeY];
            generateBoard (zombieNumb,playersNumb);
        }

        public void setBoard(int i, int j, tilesState k)
        {
            board[i, j] = k;

        }
        public tilesState[,] getBoard()
        {
            return board;
        }

        private void generateBoard(int zombieNumb, int playersNumb)
    {
        Random rnd = new Random();
        int obstacleNumb = rnd.Next(1, 500);
        int piecesNumb = (board.GetLength(0) - 2) * (board.GetLength(1) - 2);
        for (int i = 1; i < board.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < board.GetLength(1)-1; j++)
            {
                int numb1 = rnd.Next(1, piecesNumb);
                if (numb1 <= zombieNumb)
                {
                    setBoard(i, j, tilesState.zombie);

                    zombieNumb--;
                }
                else
                {

                    if (numb1 > zombieNumb + obstacleNumb)
                    {
                        setBoard(i, j,tilesState.empty);



                    }
                    else
                    {
                        setBoard(i, j, tilesState.obstacle);
                        obstacleNumb--;
                    }
                }
                piecesNumb--;
            }



        }

        for (int i = 0; i < board.GetLength(0); i++)
        {
           
            setBoard(i, 0, tilesState.obstacle);
            
            setBoard(i, board.GetLength(1)-1, tilesState.obstacle);

        }

        for (int i = 0; i < board.GetLength(1); i++)
        {
            setBoard(0, i, tilesState.obstacle);
          
            setBoard(board.GetLength(0) - 1, i, tilesState.obstacle);
          

        }


        for (int i = 1; i < 5; i++)
        {
            for (int j = 1; j < playersNumb; j++)
            {
                if (i == 1)
                {
                    setBoard(i, j, tilesState.player);
                 
                }
                else {
                    setBoard(i, j, tilesState.empty);}
                }

            }


        }

        public tilesState checkPos(int x, int y)
        {
            return board[x, y];
        }

       }
     
    
}
