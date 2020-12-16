using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzlegame
{
    class MyPictureBox : PictureBox
    {
        int index = 0;
        

        
        int imageIndex = 0;

        public int Index { get => index; set => index = value; }
        public int ImageIndex { get => imageIndex; set => imageIndex = value; }

        public bool isMatch()
        {
            return (Index == ImageIndex);
        }
    }
}
