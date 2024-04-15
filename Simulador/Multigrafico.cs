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
        ArrayList angulo;
        ArrayList piernaIzquierda;
        ArrayList piernaDerecha;
        ArrayList piernaCombinada;
        ArrayList velocidad;
        int muestrasTotales = 0;

        // ruta 
        SLDocument sl;


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
            derecho(rutaArchivo);
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


        public void derecho(string rutaArchivo)
        {
            //se lee el archivo y se dibuja la grafica
            SLDocument sl = new SLDocument(rutaArchivo);
            int iRow = 1;

            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);
                decimal derecha = sl.GetCellValueAsDecimal(iRow, 3);
                chartDerecha.Series["Derecha"].Points.AddXY(angulo, derecha);
                iRow++;
            }
        }

        public void combinacion(string rutaArchivo)
        {
            SLDocument sl = new SLDocument(rutaArchivo);
            int iRow = 1;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);
                chartCombinacion.Series["Combinacion"].Points.AddXY(angulo, sl.GetCellValueAsDecimal(iRow, 2) + sl.GetCellValueAsDecimal(iRow, 3));
                iRow++;
            }
        }

        public void izquierda(string rutaArchivo)
        {
            SLDocument sl = new SLDocument(rutaArchivo);

            int iRow = 1;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);
                decimal izquierda = sl.GetCellValueAsDecimal(iRow, 2);
                chartIzquierda.Series["Izquierda"].Points.AddXY(angulo, izquierda);
                iRow++;

            }
        }

        public void velocidadG(string rutaArchivo)
        {
            SLDocument sl = new SLDocument(rutaArchivo);

            int iRow = 1;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);
                decimal velocidad = sl.GetCellValueAsDecimal(iRow, 4);
                chartVelocidad.Series["Velocidad"].Points.AddXY(angulo, velocidad);
                iRow++;

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
