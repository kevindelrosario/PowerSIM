using DocumentFormat.OpenXml.Drawing;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulador
{
    public partial class Calculos : Form
    {
        public string rutaArchivo = string.Empty;
        public decimal fuerzaPico = decimal.Zero;
        public decimal cadencia = decimal.Zero;
        public decimal longitudBiela = decimal.Zero;
        public Calculos(Form1.Ruta ruta)
        {
            InitializeComponent();
            rutaArchivo = ruta.ruta;
            rich.Clear();

          


        }

        private void btCalcular_Click(object sender, EventArgs e)
        {
            rich.Clear();

            try
            {
                fuerzaPico = Convert.ToDecimal(editFuerzaPico.Text.ToString());
                cadencia = Convert.ToDecimal(editCadencia.Text.ToString());
                longitudBiela = Convert.ToDecimal(editLongBiela.Text.ToString());
                if (fuerzaPico != decimal.Zero || cadencia != decimal.Zero || longitudBiela != decimal.Zero)
                {
                    promedio();
                }
               
            }
            catch
            {
                MessageBox.Show("Por favor ingresa todos los campos con valores numericos.");
            }
           
        
        }


        public void promedio()
        {
            try
            {
                SLDocument sl = new SLDocument(rutaArchivo);
                int iRow = 1;
                int contador = 0;
                decimal Totalderecha = 0;
                decimal TotalIzquierda = 0;

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    decimal izquierda = sl.GetCellValueAsDecimal(iRow, 2);
                    decimal derecha = sl.GetCellValueAsDecimal(iRow, 3);
                    iRow++;
                    contador++; // para ver cuantos valores son...
                    Totalderecha += derecha;
                    TotalIzquierda += izquierda;
                }

                rich.AppendText("\n \n" + "       PROMEDIO:\n  ");
                //promedio pierna IZQUIERDA
                rich.AppendText("\n PROMEDIO IZQUIERDA: " + decimal.Round((TotalIzquierda / contador), 2) + ";");
                //promedio pierna DERECHA
                rich.AppendText("\n PROMEDIO DERECHA: " + decimal.Round((Totalderecha / contador), 2) + ";");


                decimal fpromIzq = decimal.Round((TotalIzquierda / contador), 2);
                decimal fpromDere = decimal.Round((Totalderecha / contador), 2);
                decimal fPromTOTAL = fpromIzq + fpromDere;
                rich.AppendText("\n PROMEDIO TOTAL: " + decimal.Round(fPromTOTAL, 2) + ";");
                potencia(fpromIzq, fpromDere, fPromTOTAL);
            }
            catch
            {
                MessageBox.Show("Asegurate de haber seleccionado el archivo...");
                this.Close();
            }



        }



        public void potencia(decimal fPromIzq , decimal fPromD,decimal fPromTOTAL )
        {
            decimal pi = decimal.Round(Convert.ToDecimal(Math.PI),2);
           

            richPotencia.AppendText("\n \n" + "POTENCIA:\n  ");

           // richPotencia.AppendText("\n \n" + "PI: "+ pi );

            richPotencia.AppendText("\n \n" + "Potencia_Izquierda: " + decimal.Round(( fPromIzq *fuerzaPico * cadencia*(2*pi)* longitudBiela /60000) ,2));
            richPotencia.AppendText("\n \n" + "Potencia_Derecha: " + decimal.Round((fPromD * fuerzaPico * cadencia * (pi * 2) * longitudBiela / 60000), 2));

            richPotencia.AppendText("\n \n" + "Potencia_TOTAL: " + decimal.Round((fPromTOTAL * fuerzaPico * cadencia * (pi * 2) * longitudBiela / 60000), 2));

        }

        private void barra_Scroll(object sender, EventArgs e)
        {
            valorBarra.Text = barra.Value.ToString();

        }
      
    }
}
