using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace cDuckHunt
{
    class cPato : PictureBox
    {
        //ESTA ES LA PROPIEDAD DE VIDA DE UN PATO 
        private int cVidaDelPato;

        public int CVidaDelPato
        {
            get { return cVidaDelPato; }
            set { cVidaDelPato = value; }
        }

        //ESTA ES LA PROPIEDAD PUTNOS QUE DARAN LOS PATOS 
        private int cPutnosDelPato;

        public int CPuntosDelPato
        {
            get { return cPutnosDelPato; }
            set { cPutnosDelPato = value; }
        }
    }
}
