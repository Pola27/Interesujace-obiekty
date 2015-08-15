using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Zadanie01
{
    class PictureBoxExt : PictureBox
    {

        private bool show;

        public bool uncover {
            get
            {
                return this.show;
            }
            
            set
            {
                this.show = !this.show;
                if (this.show)
                {
                    this.BackColor = Color.Brown;
                    //    Size = new Size(100, 100);
                }

                if (!this.show)
                {
                    this.BackColor = Color.AliceBlue;
                }
            }
        
        }
    }
}
