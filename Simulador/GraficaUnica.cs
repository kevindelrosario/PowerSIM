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
       public string rutaArchivo = string.Empty;// Se inicializa la ruta en null para realizar las comprobaciones luego
        public GraficaUnica(Form1.Ruta ruta)
        {
            InitializeComponent();
           //Se inicializan los valores del chart a 0
           chart1.Series["Derecha"].Points.AddXY(0, 0);
           chart1.Series["Izquierda"].Points.AddXY(0, 0);
           chart1.Series["Velocidad"].Points.AddXY(0, 0);
           chart1.Series["Combinada"].Points.AddXY(0, 0);
           rutaArchivo = ruta.ruta;// Se toma la ruta enviada del form inicial

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
                    velocidad(rutaArchivo);
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
            //se crea un objeto SLDocument que toma la ruta del archivo a leer
            SLDocument sl = new SLDocument(rutaArchivo);
            int iRow = 1; //para indicar desde donde empezar a leer

            //recorre y toma los valores del archivo excel hasta no encontrar ningun valor
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1))) 
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1); //toma los valores de la columna 1 (angulo)
                decimal derecha = sl.GetCellValueAsDecimal(iRow, 3);//toma los valores de la columna 3 (derecha)
                chart1.Series["Derecha"].Points.AddXY(angulo,derecha); //va dibujando en la grafica los valores
                iRow++;//se suma un valor al iRow para ir indicando la posicion de la fila

            }
        }

        public void combinacion(string rutaArchivo)
        {
            SLDocument sl = new SLDocument(rutaArchivo);
            int iRow = 1;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);//toma los valores de la columna 1 (angulo)
                //toma los valores de la columna 2y 3 para sumarlos y sacar la suma de ambas que sera la combinada
                chart1.Series["Combinada"].Points.AddXY(angulo, sl.GetCellValueAsDecimal(iRow, 2) + sl.GetCellValueAsDecimal(iRow, 3));
                iRow++; 

            }
        }

        public void izquierda(string rutaArchivo)
        {
            SLDocument sl = new SLDocument(rutaArchivo);

            int iRow = 1;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);//toma los valores de la columna 1 (angulo)
                decimal izquierda = sl.GetCellValueAsDecimal(iRow, 2);//toma los valores de la columna 2 (Izquierda)
                chart1.Series["Izquierda"].Points.AddXY(angulo, izquierda);
                iRow++;

            }
        }

        public void velocidad(string rutaArchivo)
        {
            SLDocument sl = new SLDocument(rutaArchivo);

            int iRow = 1;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);
                decimal velocidad = sl.GetCellValueAsDecimal(iRow, 4);
                chart1.Series["Velocidad"].Points.AddXY(angulo, velocidad);
                iRow++;

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
