using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;


namespace Zadanie01
{
    class PictureBoxExt : PictureBox
    {

        private bool show;
        public int number;

        public void select()
        {
           this.show = true;
           this.BackColor = Color.Brown;
        }
        public void unselect()
        {
           this.show = false;
           this.BackColor = Color.AliceBlue;
        }


        public void hidePictureBox_onTimer(object sender, EventArgs e)
        {
            this.unselect();
        }

        public void removePictureBox_onTimer(object sender, EventArgs e)
        {
            this.unselect();
            this.Visible = false;

        }


    }
}
