using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Nethack.Core;


namespace Nethack.GUI
{
    public class GuiAccess : IGuiAccess
    {
        PictureBox picture;
        Bitmap original = new Bitmap(@"d:\NOGR\csharp\Nethack\Nethack\Nethack\Nethack\data\absurd32_nethack.png");
  
        //Image image = Image.FromFile(@"Nethack\data\absurd32_nethack.png");
        public GuiAccess(PictureBox picture)
        {
            this.picture = picture;
        }


        public void RenderBoard(Gameboard board, Player player)
            // na przykald
        {
        Rectangle srcRect = new Rectangle(0, 0, 32, 32);
        Bitmap cropped = (Bitmap)original.Clone(srcRect, original.PixelFormat);
        picture.Image = cropped;
        //Bitmap = Graphics.Draw
            for (int x=0; x < 50; x++)
                for (int y=0; y < 50; y++)
                {
                    switch (board.getBoard()[x,y])
                    {
                        case tilesState.empty: 
                            {
                                picture.Paint(
                                break;
                            }
                        case tilesState.obstacle:
                            {
                                //picture.Pa
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

                    }
                }
    }
    }
}
