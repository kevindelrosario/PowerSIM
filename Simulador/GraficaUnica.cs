using Simulador.Clases;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulador
{
   
    public partial class GraficaUnica : Form
    {
        //DATOS DE LA CLASE LeeArchivo:
        LeeArchivo leerArchivo;
        List<decimal> angulo;
        List<decimal> piernaDerecha;
        List<decimal> piernaIzquierda;
        List<decimal> piernaCombinada;
        List<decimal> velocidad;
        int muestrasTotales = 0;

        // ruta 
        SLDocument sl;

        int i = 1;
        public string rutaArchivo = string.Empty;// Se inicializa la ruta en null para realizar las comprobaciones luego
        public GraficaUnica(Inicio.Ruta ruta)
        {
            InitializeComponent();
           //Se inicializan los valores del chart a 0
           chart1.Series["Derecha"].Points.AddXY(0, 0);
           chart1.Series["Izquierda"].Points.AddXY(0, 0);
           chart1.Series["Velocidad"].Points.AddXY(0, 0);
           chart1.Series["Combinada"].Points.AddXY(0, 0);
           rutaArchivo = ruta.ruta;// Se toma la ruta enviada del form inicial

            sl = new SLDocument(rutaArchivo);

            leerArchivo = new LeeArchivo(sl);
            extraerInformacion();
        }
        public void extraerInformacion()
        {
            //rellena los arrayList con cada campo
            angulo = leerArchivo.Angulo;
            piernaIzquierda = leerArchivo.PiernaIzquierda;
            piernaDerecha = leerArchivo.PiernaDerecha;
            piernaCombinada = leerArchivo.PiernaCombinada;
            velocidad = leerArchivo.Velocidad;

            //tomamos el total de las muestras
            muestrasTotales = leerArchivo.MuestrasTotales;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiaChart(); //Reinicia las graficas siempre que se presione el boton del check...
            try
            {
                //cuando algun valor del check este seleccionado(es true) hace la llamada a su respectiva funcion.
                //para dibujar la grafica indicada...
                if (checkDerecha.Checked == true)
                {
                    derecho(rutaArchivo);
                }
                if (checkIzquierda.Checked == true)
                {
                    izquierda(rutaArchivo);
                }
                if (checkCombinada.Checked == true)
                {
                    combinacion(rutaArchivo);
                }
                if (checkVelocidad.Checked == true)
                {
                    velocidadG(rutaArchivo);
                }
            }
            catch
            {
             //Si hubiera algun problema con la ruta se mostrara este mensaje para verificar que se haya seleccionado.
                MessageBox.Show("Verificar que se ha indicado correctamente la ruta del archivo.");
                chart1.Series["Derecha"].Points.AddXY(0, 0);
                chart1.Series["Izquierda"].Points.AddXY(0, 0);
                chart1.Series["Velocidad"].Points.AddXY(0, 0);
                chart1.Series["Combinada"].Points.AddXY(0, 0);
                this.Close();
            }
          
        }


        public void derecho(string rutaArchivo)
        {
            i = 1;
            while (i <= angulo.Count)
            {
                chart1.Series["Derecha"].Points.AddXY(angulo[i - 1], piernaDerecha[i - 1]);
                i++;
            }
        }

        public void combinacion(string rutaArchivo)
        {
            i = 1;
            while (i <= angulo.Count)
            {
                chart1.Series["Combinada"].Points.AddXY(angulo[i - 1], piernaCombinada[i - 1]);
                i++;
            }
        }

        public void izquierda(string rutaArchivo)
        {
            i = 1;
            while (i <= angulo.Count)
            {
                chart1.Series["Izquierda"].Points.AddXY(angulo[i - 1], piernaIzquierda[i - 1]);
                i++;
            }
        }

        public void velocidadG(string rutaArchivo)
        {
            i = 1;
            while (i <= angulo.Count)
            {
                chart1.Series["Velocidad"].Points.AddXY(angulo[i - 1], velocidad[i - 1]);
                i++;
            }
        }

        //Se encarga de limpiar la grafica...
        public void limpiaChart()
        {
            chart1.Series["Izquierda"].Points.Clear();
            chart1.Series["Derecha"].Points.Clear();
            chart1.Series["Velocidad"].Points.Clear();
            chart1.Series["Combinada"].Points.Clear();
        }

    }
}
