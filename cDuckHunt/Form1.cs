using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cDuckHunt
{
    public partial class Form1 : Form
    {
        Label cEtieuqetaParaLosPuntosEnElForm;
        Label cEtiquetaParaLasValasQueMeQuedan;
        Label cTiempoDelJuegoLimite;

        cPatoVerde cPatoVerde;
        cPatoAzul cPatoAzul;
        cPatoRojo cPatoRojo;

        int cPuntoDelPatoVariableGlobal = 0;
        int cPuntosObtenidosPorPato = 0;

        int xTiempoEnMinutos = 1;
        int xTiempoEnSegundos = 60;

        Timer tiempoAgregarPato;
        Timer cTiempParaQueSeTermineElJuego;

        Timer cTiempoParaDesaparecerAlPerro;

        cPerro cPerro;

        cPistola cPistola;

        cDisparoFallido cDisparoFallido;
        int xCordenadasDelMouseEnX;
        int yCordenasdasDelMouseEnY;
        

        

        public Form1()
        {
            InitializeComponent();
            this.Cursor  = new Cursor("cMiraMiraMiraDelCursor.cur");  
                //Cursor.Handle = global::cDuckHunt.Properties.Resources.cMiraMiraMiraDelCursor;


            Button agregarPato = new Button();
            agregarPato.Location = new Point(586, 656);
            agregarPato.Size = new Size(225, 80);
            agregarPato.Name = "botonParaAgregarPato";
            agregarPato.Text = "COMENZAR";
            this.Controls.Add(agregarPato);
            agregarPato.Click += AgregarPato_Click;


            //ESTA ETIQUETA TE DICE CUANTOS PUNTOAS VAS A OBTENER 
            cEtieuqetaParaLosPuntosEnElForm = new Label();
            cEtieuqetaParaLosPuntosEnElForm.Text = "\nPUNTOS: ";
            cEtieuqetaParaLosPuntosEnElForm.Location = new Point(50,680);
            cEtieuqetaParaLosPuntosEnElForm.Size = new Size(195, 50);
            cEtieuqetaParaLosPuntosEnElForm.BackColor = Color.Transparent;
            this.Controls.Add(cEtieuqetaParaLosPuntosEnElForm);

            //ESTE ES LA IMAGEN DE LA PISTOLA CON LA PROPIEDAD DE BALAS
            cPistola = new cPistola();
            (cPistola).CBalas = 10;
            this.Controls.Add(cPistola);

            //ESTE ETIQUTEA TE DICE LAS VALAS QUE TIENES 
            cEtiquetaParaLasValasQueMeQuedan = new Label();
            cEtiquetaParaLasValasQueMeQuedan.Text = "\n10";
            cEtiquetaParaLasValasQueMeQuedan.Location = new Point(1240, 680);
            cEtiquetaParaLasValasQueMeQuedan.Size = new Size(50, 50);
            cEtiquetaParaLasValasQueMeQuedan.BackColor = Color.Transparent;
            this.Controls.Add(cEtiquetaParaLasValasQueMeQuedan);

            //ESTE ETIQUETA TE DICE EL TIEMPO RESTANTE
            cTiempoDelJuegoLimite = new Label();
            cTiempoDelJuegoLimite.Location = new Point(20, 20);
            cTiempoDelJuegoLimite.Text = "TIEMPO RESTANTE: 2:00";
            cTiempoDelJuegoLimite.Size = new Size(135, 20);
            cTiempoDelJuegoLimite.BackColor = Color.Transparent;
            this.Controls.Add(cTiempoDelJuegoLimite);
        }


        //CUADNDO SE DE EL EVENTO CLICK "COMENZAR" LA ACCION EN FUNCION ENTRA PARA CREAR UN OBJETO DE TIPO TIMER ESTE TIENE UN EVENTO DE TIPO TICK
        private void AgregarPato_Click(object sender, EventArgs e)
        {
            //TIMER PARA AGREGAR LOS PATOS CADA SIERTO TIEMPO AL MOENTO DE DAR CLIC
            tiempoAgregarPato = new Timer();
            tiempoAgregarPato.Enabled = true;
            tiempoAgregarPato.Interval = 8000;
            tiempoAgregarPato.Tick += TiempoAgregarPato_Tick;

            //TIMER PARA EL TIEMPO DE JEUGO LLEGUE A 0 SE CIERRE EL PROGRAMA 
            cTiempParaQueSeTermineElJuego = new Timer();
            cTiempParaQueSeTermineElJuego.Enabled = true;
            cTiempParaQueSeTermineElJuego.Interval = 1000;
            cTiempParaQueSeTermineElJuego.Tick += CTiempParaQueSeTermineElJuego_Tick;
        }

        //ESTE ES EL EVENTO DE TIEMPO, CADA SEGUNDO SE VAN A IR RESTANDO LOS SEGUNDO Y MINUTOS AL LLEGAR A 0 SE MOSTARAR EN LA PANTALLA UN MENSAJE CON TU PUNTAJE
        private void CTiempParaQueSeTermineElJuego_Tick(object sender, EventArgs e)
        {
            if (cPuntoDelPatoVariableGlobal == 0)
            {
                cTiempoDelJuegoLimite.Text = "TIEMPO RESTANTE: " + xTiempoEnMinutos + ":" + xTiempoEnSegundos;

                int xTiempoEnSegundosDos = xTiempoEnSegundos - 1;
                xTiempoEnSegundos = xTiempoEnSegundosDos;

                cTiempoDelJuegoLimite.Text = "TIEMPO RESTANTE: " + xTiempoEnMinutos + ":" + xTiempoEnSegundosDos;

                if (xTiempoEnMinutos == 0 && (xTiempoEnMinutos == 0 && xTiempoEnSegundosDos == 0))
                {
                    tiempoAgregarPato.Enabled = false;
                    cTiempParaQueSeTermineElJuego.Enabled = false;
                    MessageBox.Show("SE TERMINO EL TIEMPO ESTE ES TU PUNTAJE: \n " + cPuntosObtenidosPorPato);


                }

                else if (xTiempoEnSegundosDos == 0 || xTiempoEnSegundosDos == 0)
                {
                    xTiempoEnMinutos = 0;
                    xTiempoEnSegundos = 60;
                }

               


            }
        }


        //ESE ES DEL EVENTO DEL METODO CLICK AQUI ES CUANDO SE AGREGA UN PATO 
        private void TiempoAgregarPato_Tick(object sender, EventArgs e)
        {
            Random xPatoAElegirParaAgregarloAlForm = new Random();
            int x;

             cPatoVerde = new cPatoVerde();
             cPatoAzul = new cPatoAzul();
             cPatoRojo = new cPatoRojo();

            //ESTE SWITCH LO QUE HACE ES QUE CON UN NUMERO RANDOM VA A AGREGAR A UNO DE LOS TRES PATOS QUE TENEMOS
            switch (x = (xPatoAElegirParaAgregarloAlForm.Next(1,9)))
            {
                case 1:
                    this.Controls.Add(cPatoVerde); 
                    cPatoVerde.Click += CPatoVerde_Click;
                    break;


                case 2:
                case 4:
                case 8:
                    this.Controls.Add(cPatoAzul);
                    cPatoAzul.Click += CPatoAzul_Click;
                    break;


                case 3:
                case 6:
                case 9:
                    this.Controls.Add(cPatoRojo);
                    cPatoRojo.Click += CPatoRojo_Click;
                    break;
            }      
        }

        //EN ESTE EVENTO VAMOS A TENER LA ACCION/METODO PARA QUE SE PIMIRA EN LA ETIQUETA DE PUTNOS;
        private void CPatoRojo_Click(object sender, EventArgs e)
        {
            
            (cPistola).CBalas = (cPistola).CBalas - 1;
            (cPistola).CBalas = (cPistola).CBalas;

            cEtiquetaParaLasValasQueMeQuedan.Text = "\n" + (cPistola).CBalas;

            if ((cPistola).CBalas == 0)
            {
                tiempoAgregarPato.Enabled = false;
                cTiempParaQueSeTermineElJuego.Enabled = false;
                MessageBox.Show("SE TE TERMINARON LAS BALAS\n Y TU PUNTAJE ES DE: " + cPuntosObtenidosPorPato);
            }

            if (cPuntoDelPatoVariableGlobal == 0)
            {
                cPuntosObtenidosPorPato = (cPatoRojo).CPuntosDelPato + cPuntosObtenidosPorPato;
                (cPatoRojo).CPuntosDelPato = cPuntosObtenidosPorPato;
                cEtieuqetaParaLosPuntosEnElForm.Text = "\nPUNTOS: " + cPuntosObtenidosPorPato;
            }

            if (this.Location.Y >= 650)
            {
                this.cPatoRojo.Dispose();
            }
        }

        //EN ESTE EVENTO VAMOS A TENER LA ACCION/METODO PARA QUE SE PIMIRA EN LA ETIQUETA DE PUTNOS;
        private void CPatoAzul_Click(object sender, EventArgs e)
        {
            (cPistola).CBalas = (cPistola).CBalas - 1;
            (cPistola).CBalas = (cPistola).CBalas;

            cEtiquetaParaLasValasQueMeQuedan.Text = "\n" + (cPistola).CBalas;

            if ((cPistola).CBalas == 0)
            {
                tiempoAgregarPato.Enabled = false;
                cTiempParaQueSeTermineElJuego.Enabled = false;
                MessageBox.Show("SE TE TERMINARON LAS BALAS\n Y TU PUNTAJE ES DE: " + cPuntosObtenidosPorPato);
            }

            if (cPuntoDelPatoVariableGlobal == 0)
            {
                cPuntosObtenidosPorPato = (cPatoAzul).CPuntosDelPato + cPuntosObtenidosPorPato;
                (cPatoAzul).CPuntosDelPato = cPuntosObtenidosPorPato;
                cEtieuqetaParaLosPuntosEnElForm.Text = "\nPUNTOS: " + cPuntosObtenidosPorPato;
            }

            if (this.Location.Y >= 650)
            {
                this.cPatoAzul.Dispose();
            }
        }

        //EN ESTE EVENTO VAMOS A TENER LA ACCION/METODO PARA QUE SE PIMIRA EN LA ETIQUETA DE PUTNOS;
        private void CPatoVerde_Click(object sender, EventArgs e)
        {
            (cPistola).CBalas = (cPistola).CBalas - 1;
            (cPistola).CBalas = (cPistola).CBalas;

            cEtiquetaParaLasValasQueMeQuedan.Text = "\n" + (cPistola).CBalas;

            if ((cPistola).CBalas == 0)
            {
                tiempoAgregarPato.Enabled = false;
                cTiempParaQueSeTermineElJuego.Enabled = false;
                MessageBox.Show("SE TE TERMINARON LAS BALAS\n Y TU PUNTAJE ES DE: " + cPuntosObtenidosPorPato);
            }

            if (cPuntoDelPatoVariableGlobal == 0)
            {
                cPuntosObtenidosPorPato = (cPatoVerde).CPuntosDelPato + cPuntosObtenidosPorPato;
                (cPatoVerde).CPuntosDelPato = cPuntosObtenidosPorPato;
                cEtieuqetaParaLosPuntosEnElForm.Text = "\nPUNTOS: " + cPuntosObtenidosPorPato;
            }

            if (this.Location.Y >= 650)
            {
                this.cPatoVerde.Dispose();
            }

        }

        //ESTE ES EL EVETNO DEL FORM DENTRO DE ESTE TENEMOS EL METODO QUE CUANDO LE DEMOS CLIC NOS VA A SALIR EL PERRO, LOS VA A QUITAR UNA VALA Y VA A APARECER LA BALA.
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Click += Form1_Click;
            
        }

        //AQUI EN ESTE METODO LA ACCION QUE VA A REALIZAR ES QUE VA A APARECER EL PERRO Y TAMBIEN LA BALA
        private void Form1_Click(object sender, EventArgs e)
        {
            /*
            public cDisparoFallido()

                this.Location = new Point(xLoacionDelPerroEnx = x.Next(100, 1300), xLoacionDelPerroEny = x.Next(600, 650));
            }*/

            cDisparoFallido = new cDisparoFallido();
           
            xCordenadasDelMouseEnX = MousePosition.X;
            xCordenadasDelMouseEnX = xCordenadasDelMouseEnX - 6;
            yCordenasdasDelMouseEnY = MousePosition.Y;
            yCordenasdasDelMouseEnY = yCordenasdasDelMouseEnY - 22;
            cDisparoFallido.Location = new Point(xCordenadasDelMouseEnX, yCordenasdasDelMouseEnY);
            this.Controls.Add(cDisparoFallido);

            cPerro = new cPerro();
            this.Controls.Add(cPerro);
            cTiempoParaDesaparecerAlPerro = new Timer();
            cTiempoParaDesaparecerAlPerro.Enabled = true;
            cTiempoParaDesaparecerAlPerro.Interval = 2000;
            cTiempoParaDesaparecerAlPerro.Tick += CTiempoParaDesaparecerAlPerro_Tick;

            (cPistola).CBalas = (cPistola).CBalas - 1;
            (cPistola).CBalas = (cPistola).CBalas;

            cEtiquetaParaLasValasQueMeQuedan.Text = "\n" + (cPistola).CBalas;

            if ((cPistola).CBalas == 0)
            {
                tiempoAgregarPato.Enabled = false;
                cTiempParaQueSeTermineElJuego.Enabled = false;
                MessageBox.Show("SE TE TERMINARON LAS BALAS\n Y TU PUNTAJE ES DE: " + cPuntosObtenidosPorPato);
            }
        }

        private void CTiempoParaDesaparecerAlPerro_Tick(object sender, EventArgs e)
        {
            cTiempoParaDesaparecerAlPerro.Enabled = false;
            
            cPerro.Visible = false;
            
        }
    }
}
