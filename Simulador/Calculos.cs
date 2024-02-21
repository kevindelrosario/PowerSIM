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
        realizar los calculos de potenciaIdeal de pedaladas.
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
                potenciaIdeal(fpromIzq, fpromDere, fPromTOTAL);//toma los datos y saca la potenciaIdeal
            }
        

        public void potenciaIdeal(decimal fPromIzq , decimal fPromD,decimal fPromTOTAL )
        {
            //Toma el Pi (valor en double) y lo pasa a decimal para poder trabajar con el mas abajo.
            decimal pi = (Convert.ToDecimal(Math.PI));
           
            //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS
            //los resultados se muestran en el rich.
            richPotencia.AppendText("\n" + "---- POTENCIA IDEAL ---- ");
            richPotencia.AppendText("\n" + "Potencia pierna izquierda: " + decimal.Round(( fPromIzq *fuerzaPico * cadencia * pi* 2*longitudBiela /60000) ,2));
            richPotencia.AppendText("\n" + "Potencia pierna derecha: " + decimal.Round((fPromD * fuerzaPico * cadencia * pi * 2 * longitudBiela / 60000), 2));
            richPotencia.AppendText("\n" + "Potencia total: " + decimal.Round((fPromTOTAL * fuerzaPico * cadencia * pi * 2 * longitudBiela / 60000), 2));


            decimal balanceIq = decimal.Round(((fPromIzq * 100) / fPromTOTAL), 1);
            decimal balanceDe = decimal.Round(((fPromD * 100) / fPromTOTAL), 1);

            richPotencia.AppendText("\nBalance Izq/dere: " + balanceIq + "/" + balanceDe);

        }

        //Metodo que mestra el valor de la barra en el label.
        private void barra_Scroll(object sender, EventArgs e)
        {
            valorBarra.Text = barra.Value.ToString(); 

        }

        private void button1_Click(object sender, EventArgs e)
        {


            /**********************CALCULO POTENCIA IDEAL**********************************/

            richPotencia.Clear();
            richInfo.Clear();
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


            /**************************CALCULO SEGUN NUMERO DE MUESTREO******************************/


            richPotencia.AppendText("\n\n ---- POTENCIA REALES ----");
            SLDocument sl = new SLDocument(rutaArchivo);
            int iRow = 1;
            //While solo para saber la cantidad de datos con las que trabajara mas abajo.
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                iRow++;
            }
          
            int Fs = Convert.ToInt32(valorBarra.Text); // Toma la frecuencia de muestreo de los datos
          
           
           
            int Sp = ((iRow-1) / Fs) * ( 60 /Convert.ToInt32(editCadencia.Text.ToString())); //Indicamos cada cuanto debe realizar el salto para tomar el valor siguiente.
            int iRow2 = 1;
            int contador = 0;
            int nValores = 0;
            //Datos de prueba
            richInfo.AppendText("Fs:" + Fs + "\nMuestras totales: " + (iRow - 1)); // -1 porque desde el inicio inicia en 1 para indicar desde que fila inicia todo el recorrido...
            richInfo.AppendText("\nNumero de muestras por pedalada: " + Sp); // La frecuencia con la que se tomaran las pruebas

            //variables para sumar los valores
            decimal totalIzquierda = 0;
            decimal totalDerecha = 0;

            //realiza la busqueda de los datos...
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow2, 1)))
            {
                decimal izquierda = sl.GetCellValueAsDecimal(iRow2, 2); 
                decimal derecha = sl.GetCellValueAsDecimal(iRow2, 3);

                if (contador == Sp + 1)
                {
                    totalIzquierda += izquierda;
                    totalDerecha += derecha;

                    contador = 0; // vuelve a cero para reinicial el conteo despues de tomar el valor...
                    nValores++;
                }
               
                contador++;
                iRow2++;
               
            }
            potenciaIndividual(totalIzquierda, totalDerecha, (totalIzquierda + totalDerecha));

        }

        public void potenciaIndividual(decimal fIzqui, decimal fDere, decimal fTOTAL)
        {
            try
            {   //toma los valores de los textView y si no estan vacios llama la funcion promedio para que inicie
                //los calculos.
                decimal pi = (Convert.ToDecimal(Math.PI));//Toma el Pi (valor en double) y lo pasa a decimal para poder trabajar con el mas abajo.


                fuerzaPico = Convert.ToDecimal(editFuerzaPico.Text.ToString());
                cadencia = Convert.ToDecimal(editCadencia.Text.ToString());
                longitudBiela = Convert.ToDecimal(editLongBiela.Text.ToString());
                if (fuerzaPico != decimal.Zero || cadencia != decimal.Zero || longitudBiela != decimal.Zero)
                {
                    //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS
                    //los resultados se muestran en el rich.
                    richPotencia.AppendText("\nPotencia_Izquierda: " + (decimal.Round((fIzqui * fuerzaPico * cadencia * (2 * pi) * longitudBiela / 60000)/ Convert.ToInt32(valorBarra.Text), 2)) );
                    richPotencia.AppendText("\nPotencia_Derecha: " + (decimal.Round((fDere * fuerzaPico * cadencia * (pi * 2) * longitudBiela / 60000) / Convert.ToInt32(valorBarra.Text), 2)));
                    richPotencia.AppendText("\nPotencia_TOTAL: " + decimal.Round((fTOTAL * fuerzaPico * cadencia * (pi * 2) * longitudBiela / 60000) / Convert.ToInt32(valorBarra.Text), 2) + "\n");

                    decimal balanceIq = decimal.Round(((fIzqui*100)/fTOTAL),1);
                    decimal balanceDe = decimal.Round(((fDere * 100) / fTOTAL),1);

                    richPotencia.AppendText("\nBalance Izq/dere: "+balanceIq + "/"+ balanceDe);
                }

            }
            catch
            {
                MessageBox.Show("Por favor ingresa todos los campos con valores numericos.");
            }
            
        }

      
    }
}
