using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace cDuckHunt
{
    class cPistola : PictureBox
    {
        private int cBalas;

        public int CBalas
        {
            get { return cBalas; }
            set { cBalas = value; }
        }


        public cPistola()
        {
            this.Image = global::cDuckHunt.Properties.Resources.cRifleImagenGrande;
            this.Width = 185;
            this.Height = 50;
            this.Location = new Point(1050, 680);
            this.BackColor = Color.Transparent;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
