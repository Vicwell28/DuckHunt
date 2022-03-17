using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace cDuckHunt
{
    class cPatoVerde : cPato
    {
        //VARIABLE GLOBAL PARA SABER Y MOVER POSICION 
        int xValorEnXDI, xValorEnXID, xValorEnXAD, xValorEnXAI, xValorEnXAA;
        int yValorEnYDI, yValorEnYID, yValorEnYAD, yValorEnYAI, yValorEnYAA;

        Random xNumeroRandom;

        Timer xMoviemientoDelPato;

        public cPatoVerde()
        {
            //PROPIEDADES DEL PATO
            this.Height = 40;
            this.Width = 40;
            xNumeroRandom = new Random();
            int xNumeroElegidoEnElSwitch;
            CVidaDelPato = 100;
            CPuntosDelPato = 50;

            //xNumeroElegidoEnElSwitch = (xNumeroRandom.Next(1, 5))

            switch (xNumeroElegidoEnElSwitch = (xNumeroRandom.Next(1,5)))
            {
                //PARA QUE EL PATO VALLA DE IZQUIERDA A DERECAH
                case 1:
                    this.Image = global::cDuckHunt.Properties.Resources.pVerdeDerechaIzquierda; 
                    this.Location = new Point(xValorEnXID = (xNumeroRandom.Next(1200, 1300)), yValorEnYID = (xNumeroRandom.Next(50, 600)));
                    this.BackColor = Color.Transparent;
                    this.SizeMode = PictureBoxSizeMode.StretchImage;
                    xMoviemientoDelPato = new Timer();
                    xMoviemientoDelPato.Enabled = true;
                    xMoviemientoDelPato.Interval = 2000;
                    xMoviemientoDelPato.Tick += XMoviemientoDelPato_Tick;

                    break;

                //PARA QUE EL PATO VALLA DE DERECAH A IZQUEIRDA pVerdeIzquierdaDerecha
                case 2:
                    this.Image = global::cDuckHunt.Properties.Resources.pVerdeIzquierdaDerecha;
                    this.Location = new Point(xValorEnXDI = (xNumeroRandom.Next(50, 100)), yValorEnYDI = (xNumeroRandom.Next(50, 600)));
                    this.BackColor = Color.Transparent;
                    this.SizeMode = PictureBoxSizeMode.StretchImage;
                    xMoviemientoDelPato = new Timer();
                    xMoviemientoDelPato.Enabled = true;
                    xMoviemientoDelPato.Interval = 2000;
                    xMoviemientoDelPato.Tick += XMoviemientoDelPato_Tick1;
                    break;

                //PARA QUE EL PATO VALLA DE ARRIBA IZQUERDA 
                case 3:
                    this.Image = global::cDuckHunt.Properties.Resources.pVerdeArribaIzquierda;
                    this.Location = new Point(xValorEnXAI = (xNumeroRandom.Next(50, 100)), yValorEnYAI = (xNumeroRandom.Next(550, 600)));
                    this.BackColor = Color.Transparent;
                    this.SizeMode = PictureBoxSizeMode.StretchImage;
                    xMoviemientoDelPato = new Timer();
                    xMoviemientoDelPato.Enabled = true;
                    xMoviemientoDelPato.Interval = 2000;
                    xMoviemientoDelPato.Tick += XMoviemientoDelPato_Tick2;
                    break;

                //PARA QUE EL PATO VALLA DE ARRIBA DERECAH
                case 4:
                    this.Image = global::cDuckHunt.Properties.Resources.pVerdeArribaDerecha;
                    this.Location = new Point(xValorEnXAD = (xNumeroRandom.Next(650,1300)), yValorEnYAD = (xNumeroRandom.Next(550, 600)));
                    this.BackColor = Color.Transparent;
                    this.SizeMode = PictureBoxSizeMode.StretchImage;
                    xMoviemientoDelPato = new Timer();
                    xMoviemientoDelPato.Enabled = true;
                    xMoviemientoDelPato.Interval = 2000;
                    xMoviemientoDelPato.Tick += XMoviemientoDelPato_Tick3;
                    break;

                //PARA QUE EL PATO VALLA SOLO HACIA ARRIBA
                case 5:
                    this.Image = global::cDuckHunt.Properties.Resources.pVerdeArribaArriba;
                    this.Location = new Point(xValorEnXAA = (xNumeroRandom.Next(50, 1300)), yValorEnYAA = (xNumeroRandom.Next(550, 600)));
                    this.BackColor = Color.Transparent;
                    this.SizeMode = PictureBoxSizeMode.StretchImage;
                    xMoviemientoDelPato = new Timer();
                    xMoviemientoDelPato.Enabled = true;
                    xMoviemientoDelPato.Interval = 2000;
                    xMoviemientoDelPato.Tick += XMoviemientoDelPato_Tick4;
                    break;
            }
            this.Click += CPatoVerde_Click;
        }

        //PARA QUE EL PATO VALLA SOLO HACIA ARRIBA
        private void XMoviemientoDelPato_Tick4(object sender, EventArgs e)
        {
            this.Location = new Point(xValorEnXAA, yValorEnYAA = yValorEnYAA -= 20);
        }


        //PARA QUE EL PATO VALLA DE ARRIBA DERECAH
        private void XMoviemientoDelPato_Tick3(object sender, EventArgs e)
        {
            this.Location = new Point(xValorEnXAD, yValorEnYAD = yValorEnYAD -= 20);
            this.Location = new Point(xValorEnXAD = xValorEnXAD -= 20, yValorEnYAD);
        }


        //PARA QUE EL PATO VALLA DE ARRIBA IZQUERDA 
        private void XMoviemientoDelPato_Tick2(object sender, EventArgs e)
        {
            this.Location = new Point(xValorEnXAI, yValorEnYAI = yValorEnYAI -= 20);
            this.Location = new Point(xValorEnXAI = xValorEnXAI += 20, yValorEnYAI);

        }

        //PARA QUE EL PATO VALLA DE DERECAH A IZQUEIRDA 
        private void XMoviemientoDelPato_Tick1(object sender, EventArgs e)
        {
            this.Location = new Point(xValorEnXDI = xValorEnXDI += 20, yValorEnYDI);
        }

        //PARA QUE EL PATO VALLA DE IZQUIERDA A DERECAH
        private void XMoviemientoDelPato_Tick(object sender, EventArgs e)
        {
            this.Location = new Point(xValorEnXID = xValorEnXID -= 20, yValorEnYID);
        }

        private void CPatoVerde_Click(object sender, EventArgs e)
        {
            cPatoVerde cPatoVerdeDisparo = (cPatoVerde)sender;
            cPatoVerdeDisparo.Image = global::cDuckHunt.Properties.Resources.pVerdeDisparoDisparo;
            cPatoVerdeDisparo.SizeMode = PictureBoxSizeMode.StretchImage;
            xMoviemientoDelPato.Enabled = false;

            Timer cTimerDeCaidaDelPato = new Timer();
            cTimerDeCaidaDelPato.Enabled = true;
            cTimerDeCaidaDelPato.Interval = 800;
            cTimerDeCaidaDelPato.Tick += CTimerDeCaidaDelPato_Tick;
            
        }

        private void CTimerDeCaidaDelPato_Tick(object sender, EventArgs e)
        {
           
            this.Image = global::cDuckHunt.Properties.Resources.pVerdeCaidaMuerte;
            this.Location = new Point(this.Location.X, this.Location.Y + 20);
            /*if (yValorEnY >= 700)
            {
                //this.Dispose;
            }*/
        }
    }
}
