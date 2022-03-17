using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace cDuckHunt
{
    class cPerro : PictureBox
    {
        int xLoacionDelPerroEnx;
        int xLoacionDelPerroEny;
        Random x;

        public cPerro()
        {
            this.Image = global::cDuckHunt.Properties.Resources.cPerronPerron;
            this.Height = 100;
            this.Width = 100;
            x = new Random();
            this.Location = new Point(xLoacionDelPerroEnx = x.Next(100, 1300), xLoacionDelPerroEny = x.Next(600, 650));
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
