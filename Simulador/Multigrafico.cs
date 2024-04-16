using DocumentFormat.OpenXml.Spreadsheet;
using Simulador.Clases;
using SpreadsheetLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulador
{
    public partial class Multigrafico : Form
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

        public string rutaArchivo = string.Empty; 
        //La ruta obtenida en el Form principal entra aqui
        public Multigrafico(Inicio.Ruta ruta)
        {
            InitializeComponent();

            //se inicializa el chart con 0 valores cada que se abre esta pantalla
            chartDerecha.Series["Derecha"].Points.AddXY(0,0);
                chartIzquierda.Series["Izquierda"].Points.AddXY(0,0);
                chartVelocidad.Series["Velocidad"].Points.AddXY(0, 0);
                chartCombinacion.Series["Combinacion"].Points.AddXY(0, 0);
                rutaArchivo = ruta.ruta;
               
                limpiaChart();

            // Indica el numero de pruebas que se debe tomar por sectores
            sl = new SLDocument(rutaArchivo);

           leerArchivo = new LeeArchivo(sl);
            extraerInformacion();


            //se llama cada funcion para cada grafica.
            // derecho(rutaArchivo);
                derecha();
                combinacion(rutaArchivo);
                izquierda(rutaArchivo);
                velocidadG(rutaArchivo);
            

        }

            /// <summary>
        /// extraerInformacion
        /// Trae los datos obtenidos de la clase LeeArchivo
        /// </summary>
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

        public void derecha()
        {
            i = 1;
            while ( i <= angulo.Count)
            {
                chartDerecha.Series[0].Points.AddXY(angulo[i - 1], piernaDerecha[i - 1]);// rellena el chart
                //le resta un valor para que no hayan fallos por la longitud de la i 
                i++;
            }
           
        }
        public void combinacion(string rutaArchivo)
        {
            i = 1;
            while (i <= angulo.Count)
            {
                chartCombinacion.Series[0].Points.AddXY(angulo[i - 1], piernaCombinada[i - 1]);
                i++;
            }
        }

        public void izquierda(string rutaArchivo)
        {
            i = 1;
            while (i <= angulo.Count)
            {
                chartIzquierda.Series[0].Points.AddXY(angulo[i - 1], piernaIzquierda[i - 1]);
                i++;
            }
        }

        public void velocidadG(string rutaArchivo)
        {
            i = 1;
            while (i <= angulo.Count)
            {
                chartVelocidad.Series[0].Points.AddXY(angulo[i - 1], velocidad[i - 1]);
                i++;
            }

        }
        public void limpiaChart()
        {
            chartIzquierda.Series["Izquierda"].Points.Clear();
            chartDerecha.Series["Derecha"].Points.Clear();
            chartVelocidad.Series["Velocidad"].Points.Clear();
            chartCombinacion.Series["Combinacion"].Points.Clear();
        }

    }
}
