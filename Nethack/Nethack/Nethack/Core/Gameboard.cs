using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nethack.Core
{
    public enum tilesState
    {
        empty = 0,
        player = 1,
        zombie = 3,
        obstacle = 4
    };


    public class Gameboard
    {
        public tilesState[,] board = new tilesState[50, 50];


        public Gameboard(int zombieNumb, int playersNumb)
        {
            generateBoard(zombieNumb, playersNumb);
        }

        private void setBoard(int i, int j, tilesState k)
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
        int piecesNumb = 48*48;
        for (int i = 1; i < 49; i++)
        {
            for (int j = 1; j < 49; j++)
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

        for (int i=0;i<50;i++)
        {
            setBoard(0, i, tilesState.obstacle);
            setBoard(i, 0, tilesState.obstacle);
            setBoard(49, i,tilesState.obstacle);
            setBoard(i, 49, tilesState.obstacle);

        }

        for (int i = 1; i < playersNumb; i++)
        {
            for (int j = 1; j < 5; j++)
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



       }


    
}
