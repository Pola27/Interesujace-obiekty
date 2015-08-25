using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace Zadanie01
{
    class Game
    {
        Pictures pictures = new Pictures();
        Timer timer;
        int points;
        int[] pictureNumbers;
        public int previousPictureNumber {get;  private set;}
        int picturesQuantity;

        public Game()
        {
            picturesQuantity = pictures.loadPictures();
            pictureNumbers = new int[picturesQuantity * 2];
            for (int i=0; i<picturesQuantity * 2;i++)
            {
                pictureNumbers[i] = i % picturesQuantity;
            }
            previousPictureNumber = -1;
        }

        public pictureState pictureSelect(int index)
        {
            if (previousPictureNumber == index) //kliniety ten sam
            {
                return pictureState.nicNieRob;
            }
            if (previousPictureNumber == -1)
            {
                previousPictureNumber = index;
                return pictureState.odslon;
            }

            if (previousPictureNumber != -1)
            {
                if (pictureNumbers[previousPictureNumber] == pictureNumbers[index])
                {
                    pictureNumbers[previousPictureNumber] = -1;
                    pictureNumbers[index] = -1;

                    int odkrytych = 0;
                    for (int i=0; i < pictureNumbers.Count();i++ )
                    {
                        if (pictureNumbers[i] != -1) odkrytych++;
                    }
                    if (odkrytych == 0) return pictureState.koniecGry;
                    /*
                    if (pictureNumbers.Count(x => pictureNumbers[x] == -1) == picturesQuantity)
                        {
                            return pictureState.koniecGry;
                        }
                      */
                    previousPictureNumber = -1;
                    return pictureState.odslon_usun;
                }
                else
                {
                    previousPictureNumber = -1;
                    return pictureState.odslon_zakryj;
                }
                    
                
            }

            return pictureState.odslon;
        }


        public int howManyPictures()
        {
            return picturesQuantity*2;
        }

        public Image fetchImage(int index)
        {
            return pictures.getPictures()[pictureNumbers[index]];
        } //żeby From mogl obrazki wyciągnać

        private void startTimer()
        {

        }

        private void stopTimer()
        {

        }



    }
}
