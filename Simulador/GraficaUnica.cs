using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
       public string rutaArchivo = string.Empty;
       // rutaArchivo = ruta.ruta;
        public GraficaUnica(Form1.Ruta ruta)
        {
            InitializeComponent();
            chart1.Series["Derecha"].Points.AddXY(0, 0);
            chart1.Series["Izquierda"].Points.AddXY(0, 0);
            chart1.Series["Velocidad"].Points.AddXY(0, 0);
            chart1.Series["Combinada"].Points.AddXY(0, 0);
            rutaArchivo = ruta.ruta;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            limpiaChart();
            try
            {
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

            SLDocument sl = new SLDocument(rutaArchivo);
            int iRow = 1;

            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);
                decimal derecha = sl.GetCellValueAsDecimal(iRow, 3);
                chart1.Series["Derecha"].Points.AddXY(angulo,derecha);
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
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);
                decimal izquierda = sl.GetCellValueAsDecimal(iRow, 2);
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


        public void limpiaChart()
        {
            chart1.Series["Izquierda"].Points.Clear();
            chart1.Series["Derecha"].Points.Clear();
            chart1.Series["Velocidad"].Points.Clear();
            chart1.Series["Combinada"].Points.Clear();
        }

    }
}
