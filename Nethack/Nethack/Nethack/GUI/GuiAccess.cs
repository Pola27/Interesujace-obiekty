using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
//using System.Drawing.Gra;
using Nethack.Core;


namespace Nethack.GUI
{
    public class GuiAccess : IGuiAccess
    {
        PictureBox picture;
        Bitmap iconAtlas = new Bitmap(@"d:\NOGR\csharp\Nethack\Nethack\Nethack\Nethack\data\absurd32_nethack.png");
        Bitmap originalBoard = new Bitmap(50 * 32, 50 * 32);
        
        Bitmap iconWall = new Bitmap(32,32);
        Bitmap iconFloor = new Bitmap(32, 32);
        Bitmap iconMedusa1 = new Bitmap(32, 32);
        Bitmap iconMedusa2 = new Bitmap(32, 32);
        Bitmap iconMedusa3 = new Bitmap(32, 32);
        Bitmap iconMedusa4 = new Bitmap(32, 32);
        Bitmap iconPlayer1 = new Bitmap(32, 32);

        Point pointMedusa1 = new Point(32, 160); //medusa1
        Point pointMedusa2 = new Point(64, 160); //medusa2
        Point pointMedusa3 = new Point(96, 160); //medusa3
        Point pointMedusa4 = new Point(128, 160); //medusa4
        Point pointWall = new Point(0, 21*32); //medusa4
        Point pointFloor = new Point(8*32, 21*32); //medusa4
        Point pointPlayer1 = new Point(11 * 32, 9 * 32); //medusa4


        //Image image = Image.FromFile(@"Nethack\data\absurd32_nethack.png");
        public GuiAccess(PictureBox picture)
        {
            this.picture = picture;
            Rectangle srcRect;

            srcRect = new Rectangle(pointWall, new Size(32, 32));
            iconWall = (Bitmap)iconAtlas.Clone(srcRect, iconAtlas.PixelFormat);

            srcRect = new Rectangle(pointFloor, new Size(32, 32));
            iconFloor = (Bitmap)iconAtlas.Clone(srcRect, iconAtlas.PixelFormat);

            srcRect = new Rectangle(pointPlayer1, new Size(32, 32));
            iconPlayer1 = (Bitmap)iconAtlas.Clone(srcRect, iconAtlas.PixelFormat);

            srcRect = new Rectangle(pointMedusa1, new Size(32, 32));
            iconMedusa1 = (Bitmap)iconAtlas.Clone(srcRect, iconAtlas.PixelFormat);
        }

        public Bitmap OverDraw(Bitmap largeBmp, Bitmap smallBmp, int x, int y)
        {
            Graphics g = Graphics.FromImage(largeBmp);
            //g.CompositingMode = Graphics. CompositingMode.SourceCopy;
            smallBmp.MakeTransparent();
            int margin = 5;
            //int x = largeBmp.Width - smallBmp.Width - margin;
            //int y = largeBmp.Height - smallBmp.Height - margin;
            g.DrawImage(smallBmp, new Point(x, y));
            return largeBmp;
        }

        public void RenderBoard(Gameboard board, Player player)
            // na przykald
        {
            Rectangle srcRect;
            Bitmap icon;
        //picture.Image = icon;
        //Bitmap = Graphics.Draw
            for (int x=0; x < 50; x++)
                for (int y=0; y < 50; y++)
                {
                    switch (board.getBoard()[x,y])
                    {
                        case tilesState.empty: 
                            {
                                OverDraw(originalBoard, iconFloor, x * 32, y * 32);
                                //picture.Paint(
                                break;
                            }
                        case tilesState.obstacle:
                            {
                                OverDraw(originalBoard, iconWall, x * 32, y * 32);
                                break;
                            }
                        case tilesState.player:
                            {
                                OverDraw(originalBoard, iconPlayer1, x * 32, y * 32);
                                break;
                            }
                        case tilesState.zombie:
                            {
                                OverDraw(originalBoard, iconMedusa1, x * 32, y * 32);
                                break;
                            }

                    }
                }

            picture.Image = originalBoard;
            picture.Invalidate();
        }
    }
}
