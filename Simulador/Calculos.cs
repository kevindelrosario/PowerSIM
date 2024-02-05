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
    

        }

        private void btCalcular_Click(object sender, EventArgs e)
        {
           // rich.Clear();
            richPotencia.Clear();

            try
            {   //toma los valores de los textView y si no estan vacios llama la funcion promedio para que inicie
                //los calculos.
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

        /*********Calcula promedio*************/
       /* Se encarga de tomar tomar todos los datos de cada columna y sacar el promedio de todo para 
        realizar los calculos de potencia de pedaladas.
        */
        public void promedio()
        {
          
            SLDocument sl = new SLDocument(rutaArchivo);
                int iRow = 1;
                int contador = 0;
                decimal Totalderecha = 0;
                decimal TotalIzquierda = 0;
            //toma los valores de las columnas del Excel.
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    decimal izquierda = sl.GetCellValueAsDecimal(iRow, 2);
                    decimal derecha = sl.GetCellValueAsDecimal(iRow, 3);
                    iRow++;
                    contador++; // Toma la cantidad de valores que son para sacar el promedio...
                    Totalderecha += derecha; //Va sumando los valores encontrados
                    TotalIzquierda += izquierda;
                }

                decimal fpromIzq = decimal.Round((TotalIzquierda / contador), 2);//redondea los datos y lo guardan en la variable para enviarlos
                decimal fpromDere = decimal.Round((Totalderecha / contador), 2);
                decimal fPromTOTAL = fpromIzq + fpromDere;
                potencia(fpromIzq, fpromDere, fPromTOTAL);//toma los datos y saca la potencia
            }
        

        public void potencia(decimal fPromIzq , decimal fPromD,decimal fPromTOTAL )
        {
            //Toma el Pi (valor en double) y lo pasa a decimal para poder trabajar con el mas abajo.
            decimal pi = (Convert.ToDecimal(Math.PI));
           
            //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS
            //los resultados se muestran en el rich.
            richPotencia.AppendText("\n \n" + "POTENCIA:\n  ");
            richPotencia.AppendText("\n \n" + "Potencia_Izquierda: " + decimal.Round(( fPromIzq *fuerzaPico * cadencia*(2*pi)* longitudBiela /60000) ,2));
            richPotencia.AppendText("\n \n" + "Potencia_Derecha: " + decimal.Round((fPromD * fuerzaPico * cadencia * (pi * 2) * longitudBiela / 60000), 2));
            richPotencia.AppendText("\n \n" + "Potencia_TOTAL: " + decimal.Round((fPromTOTAL * fuerzaPico * cadencia * (pi * 2) * longitudBiela / 60000), 2));
           
        }

        //Metodo que mestra el valor de la barra en el label.
        private void barra_Scroll(object sender, EventArgs e)
        {
            valorBarra.Text = barra.Value.ToString(); 

        }

   
    }
}
