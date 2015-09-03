using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading;
//using System.Timers;
using System.Windows.Forms;

namespace Zadanie01
{
    public partial class Form1 : Form
    {

        Game game;
        BoardBuilder bb;
        int previousPictureBox;
        Timer mainTimer;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            game = new Game();
            mainTimer = new Timer();
            bb = new BoardBuilder(this, game);
            this.button1.Enabled = false;
         
        }


        public void pictureClick(object sender, EventArgs e)
        {
            if (!mainTimer.Enabled) mainTimer.Start();
            PictureBoxExt pBox = sender as PictureBoxExt;
            if (pBox != null)
            {
                pictureState result = game.pictureSelect(pBox.number);

                if (result == pictureState.odslon)
                {
                    pBox.select();
                    previousPictureBox = pBox.number;
                    //pBox.Visible = true;
                }
                if (result == pictureState.odslon_zakryj)
                {
                    //pBox.Visible = true;
                    pBox.select();
                    this.Invalidate();
                    //WaitHandle.WaitAll();
                    
                    //System.Windows.Forms.Timer
                    System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
                    t1.Interval = 1000;
                    System.Windows.Forms.Timer t2 = new System.Windows.Forms.Timer();
                    t2.Interval = 1000;
                    t1.Tick += new EventHandler(pBox.hidePictureBox_onTimer);
                    //znajdzmy poprzedniego
                    object o1 = this.Controls.Find("pb" + previousPictureBox.ToString(), true)[0];
                    PictureBoxExt pb = o1 as PictureBoxExt;
                    if (pb.number == previousPictureBox)
                    {
                        t2.Tick += new EventHandler(pb.hidePictureBox_onTimer);
                        previousPictureBox = -1;
                        t1.Start();
                        t2.Start();

                    }
                   


                    previousPictureBox = -1;
                }

                if (result == pictureState.odslon_usun)
                {
                    pBox.select();
                    this.Invalidate();

                    System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
                    System.Windows.Forms.Timer t2 = new System.Windows.Forms.Timer();
                    t1.Interval = 1000;
                    t1.Tick += new EventHandler(pBox.removePictureBox_onTimer);
                                        
                    t2.Interval = 1000;
                    
                    //znajdzmy poprzedniego
                    object o1 = this.Controls.Find("pb" + previousPictureBox.ToString(), true)[0];
                    PictureBoxExt pb = o1 as PictureBoxExt;
                    if (pb.number == previousPictureBox)
                    {
                        t2.Tick += new EventHandler(pb.removePictureBox_onTimer);
                        t1.Start();
                        t2.Start();
                        previousPictureBox = -1;

                    }


                }

                //pBox.uncover = !(pBox.uncover);

                if (result == pictureState.koniecGry)
                {
                    pBox.unselect();
                    pBox.Visible = false;
                    //znajdzmy poprzedniego
                    foreach (object o1 in this.Controls)
                    {
                        if (o1 is PictureBoxExt)
                        {
                            PictureBoxExt pb = o1 as PictureBoxExt;
                            if (pb.number == previousPictureBox)
                            {
                                previousPictureBox = -1;
                                pb.Visible = false;
                                pb.unselect();
                            }
                        }

                    }
                    this.button1.Enabled = true;

                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



    }
}
