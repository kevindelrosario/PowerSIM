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
            //Prueba grafica de errores

            //  chartErrores.Series["fs_inicio"].Points.AddXY(0, 0);
            // chartErrores.Series["fs_fin"].Points.AddXY(0, 0);


            chartErrores.Series["fs_inicio"].Points.Clear();
            chartErrores.Series["fs_fin"].Points.Clear();
            chartErrores.ChartAreas[0].AxisX.Interval = 1;
            for (int i = 0; i < 10; i++)
            {
                chartErrores.Series["fs_inicio"].Points.AddXY(i, 3*i);
                chartErrores.Series["fs_fin"].Points.AddXY(i, 2+i);
            }

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
        

       

        //Metodo que mestra el valor de la barra en el label.
        private void barra_Scroll(object sender, EventArgs e)
        {
            valorBarra.Text = barra.Value.ToString(); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //VARIABLES
            int Fs = Convert.ToInt32(valorBarra.Text); // Toma la frecuencia de muestreo de los datos
            int numMuestras;//para tomar el numero de muestras
            SLDocument sl = new SLDocument(rutaArchivo);
            int Sp;
            int contador = 0;
            //variables para sumar los valores totales de cada pierna
            decimal totalIzquierda = 0;
            decimal totalDerecha = 0;

           


            richPotencia.Clear();
            richInfo.Clear();
            try
            {   //toma los valores de los textView y si no estan vacios llama la funcion promedio para que inicie
                //los calculos.
                fuerzaPico = Convert.ToDecimal(editFuerzaPico.Text.ToString());
                cadencia = Convert.ToDecimal(editCadencia.Text.ToString());
                longitudBiela = Convert.ToDecimal(editLongBiela.Text.ToString());
                if (fuerzaPico != decimal.Zero || cadencia != decimal.Zero || longitudBiela != decimal.Zero || Convert.ToInt32(valorBarra.ToString()) != 0)
                {


                    /**************************CALCULO SEGUN NUMERO DE MUESTREO******************************/

                    //While solo para saber la cantidad de datos con las que trabajara mas abajo.
                    int iRow = 1;
                    /*
                     * Aqui se hace el proceso de recorrer el archivo de texto hasta el final, pero esta vez es simplemente para sacar la cantidad
                     * de muestras que hay, luego al iRow(que contiene el numero de muestras) se le tiene que restar 1 ya que cuando empieza a contar
                     * lo hace desde uno y esto al final nos daria un valor de muestras erroneo (#muestras +1).
                     */
                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                    {
                        iRow++;
                    }
                    numMuestras = iRow - 1;// -1 parra corregir lo mencionado anteriormente...

                    Sp = (numMuestras / Fs) * (60/Convert.ToInt32(editCadencia.Text.ToString()) ); //Indicamos cada cuanto debe realizar el salto para tomar el valor siguiente.

                    //Info del archivo y la frecuencia de muestreo
                    richInfo.AppendText("\nMuestras totales: " + numMuestras);
                    richInfo.AppendText("\nNumero de muestras por pedalada(Sp): " + Sp); // La frecuencia con la que se tomaran las pruebas

                    int iRow2 = 1;


                  

                    //realiza la busqueda de los datos...
                    while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow2, 1)))
                    {
                        decimal izquierda = sl.GetCellValueAsDecimal(iRow2, 2);
                        decimal derecha = sl.GetCellValueAsDecimal(iRow2, 3);

                        if (contador == Sp + 1)
                        {
                            //Se toma el valor siguiente al sp (cada cuantas muestras nos indicaron que se deben guardar anteriormente).
                            totalIzquierda += izquierda; //se van sumando a la variable izq y der
                            totalDerecha += derecha;

                            contador = 0; // vuelve a cero para reinicial el conteo despues de tomar el valor y volver a tomar cada cierto momento el valor.
                        }

                        contador++;
                        iRow2++;

                    }

                    promedio(); // Lleva a la funcion de sacar promedio y cuando se realiza este llama a la funcion de potenciaIdeal
                    potenciaReal(totalIzquierda, totalDerecha, (totalIzquierda + totalDerecha));

                }

            }
            catch
            {
                MessageBox.Show("Por favor ingresa todos los campos con valores numericos.");
            }

           
          

        }

        /*********************************************************************/
        /*********************************************************************/
        //CALCULAR POTENCIA IDEAL
        /*********************************************************************/
        /*********************************************************************/
        public void potenciaIdeal(decimal fPromIzq, decimal fPromD, decimal fPromTOTAL)
        {
            //Toma el Pi (valor en double) y lo pasa a decimal para poder trabajar con el mas abajo.
            decimal pi = (Convert.ToDecimal(Math.PI));

            //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS21

            //los resultados se muestran en el rich.
            richPotencia.AppendText("\n" + "---- POTENCIA IDEAL ---- ");
            richPotencia.AppendText("\n" + "Potencia pierna izquierda: " + decimal.Round((fPromIzq * fuerzaPico * cadencia * pi * 2 * longitudBiela / 60000), 2));
            richPotencia.AppendText("\n" + "Potencia pierna derecha: " + decimal.Round((fPromD * fuerzaPico * cadencia * pi * 2 * longitudBiela / 60000), 2));
            richPotencia.AppendText("\n" + "Potencia total: " + decimal.Round((fPromTOTAL * fuerzaPico * cadencia * pi * 2 * longitudBiela / 60000), 2));


            decimal balanceIq = decimal.Round(((fPromIzq * 100) / fPromTOTAL), 1);
            decimal balanceDe = decimal.Round(((fPromD * 100) / fPromTOTAL), 1);

            richPotencia.AppendText("\nBalance Izq/dere: " + balanceIq + "/" + balanceDe);

        }

        /*********************************************************************/
        /*********************************************************************/
        //CALCULAR POTENCIA REAL 
        /*********************************************************************/
        /*********************************************************************/
        public void potenciaReal(decimal fIzqui, decimal fDere, decimal fTOTAL)
        {
            richPotencia.AppendText("\n\n ---- POTENCIA REAL ----");
              //toma los valores de los textView y si no estan vacios llama la funcion promedio para que inicie
                //los calculos.
                decimal pi = (Convert.ToDecimal(Math.PI));//Toma el Pi (valor en double) y lo pasa a decimal para poder trabajar con el mas abajo.

                fuerzaPico = Convert.ToDecimal(editFuerzaPico.Text.ToString());
                cadencia = Convert.ToDecimal(editCadencia.Text.ToString());
                longitudBiela = Convert.ToDecimal(editLongBiela.Text.ToString());
               
                    //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS
                    //los resultados se muestran en el rich.
                    richPotencia.AppendText("\nPotencia_Izquierda: " + (decimal.Round((fIzqui * fuerzaPico * cadencia * (2 * pi) * longitudBiela / 60000)/ Convert.ToInt32(valorBarra.Text), 2)) );
                    richPotencia.AppendText("\nPotencia_Derecha: " + (decimal.Round((fDere * fuerzaPico * cadencia * (pi * 2) * longitudBiela / 60000) / Convert.ToInt32(valorBarra.Text), 2)));
                    richPotencia.AppendText("\nPotencia_TOTAL: " + decimal.Round((fTOTAL * fuerzaPico * cadencia * (pi * 2) * longitudBiela / 60000) / Convert.ToInt32(valorBarra.Text), 2) + "\n");
                    decimal balanceIq = decimal.Round(((fIzqui*100)/fTOTAL),1);
                    decimal balanceDe = decimal.Round(((fDere * 100) / fTOTAL),1);

                    richPotencia.AppendText("\nBalance Izq/dere: "+balanceIq + "/"+ balanceDe);
                
            
        }

        /*********************************************************************/
        /*********************************************************************/
        //CALCULAR ERROR DE POTENCIA
        /*********************************************************************/
        /*********************************************************************/
        private void btErrorPotencia_Click(object sender, EventArgs e)
        {
            int fsInicio =Convert.ToInt32(txtFsInicio.Text.ToString());
            int fsFinal = Convert.ToInt32(txtFsFinal.Text.ToString());
            int numPuntos = Convert.ToInt32(txtPuntos.Text.ToString());

            /*******Dibujando en la grafica***********/

            chartErrores.Series[0].Points.Clear();
            

        }

      
    }
}
