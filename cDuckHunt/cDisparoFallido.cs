using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace cDuckHunt
{
    class cDisparoFallido : PictureBox
    {
        public cDisparoFallido()
        {
            this.Image = global::cDuckHunt.Properties.Resources.cMiraDelCursor;
            this.Height = 15;
            this.Width = 15;
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
