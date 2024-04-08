using DocumentFormat.OpenXml.Drawing;
using Simulador.Clases;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Simulador
{
    
    public partial class CalculosFs : Form
    {
        public string rutaArchivo = string.Empty;
        public decimal fuerzaPico = decimal.Zero;
        public decimal cadencia = decimal.Zero;
        public decimal longitudBiela = decimal.Zero;



        //VARIABLES PARA OBTENER EL TOTAL DE LAS POTENCIAS REALES E IDEALES DE CADA PIERNA

        /****************IDEAL************************************/
        public decimal pTotal_pIzquierda_ideal = decimal.Zero;
        public decimal pTotal_pDercha_ideal = decimal.Zero;
        public decimal pTotal_pCombinada_ideal = decimal.Zero;

        //Variables Balance  IDEAL
        public decimal balanceIq_ideal = decimal.Zero;
        public decimal balanceDe_ideal = decimal.Zero;

        /*****************REAL*************************************/
        public decimal pTotal_pIzquierda_real = decimal.Zero;
        public decimal pTotal_pDercha_real = decimal.Zero;
        public decimal pTotal_pCombinada_real = decimal.Zero;

        //Variables Balance  REAL
        public decimal balanceIq_real = decimal.Zero;
        public decimal balanceDe_real = decimal.Zero;


        //variables para sacar el porcentaje de error
        //Inicializadas aqui para poder obtener los datos de cada funcion y luego realizar los calculos con la funcion:
        //calcularPorcentajeError().

        //variables para obtener el total de las potencias ideales con las que se realizara el calculo de porcentaje de error y mostrar por pantalla las
        //potencias totales de cada pierna:
        public decimal totalPiernaD_ideal_pError = decimal.Zero;
        public decimal totalPiernaIzq_ideal_pError = decimal.Zero;
        public decimal totalCombinada_ideal_pError = decimal.Zero;

        //variables para obtener el total de las potencias reales con las que se realizara el calculo de porcentaje de error y mostrar por pantalla las
        //potencias totales de cada pierna:
        public decimal totalPiernaD_real_pError = decimal.Zero;
        public decimal totalPiernaIzq_real_pError = decimal.Zero;
        public decimal totalCombinada_real_pError = decimal.Zero;

        //Variables para tomar los valores de muestreo que entran al realizar los calculos de potencia ideal y real.
        //Se utilizan luego para guardar los datos de muestreo y para luego mostrarlo al realizarse el calculo de potencia(real/ideal)
        public decimal nMuestrasTotales = decimal.Zero;
        public decimal muestrasPorPedaladas = decimal.Zero;


        //Variables para tomar el valor total de cada pierna de la funcion  "calculaFuerzasPromediadas()" (segun la frecuencia de muestreo).
        //para realizar los calculos de la potencia real, teniendo en cuenta que este valor no es de todos los datos, sino que es de las que nos indique el fs

         public decimal totalPiernaIzq_muestreo = decimal.Zero;
         public decimal totalPiernaDer_muestreo = decimal.Zero;
         public decimal totalCombinada_muestreo = decimal.Zero;
        public decimal  factorCorreccion = decimal.Zero;

        //VARIABLES PARA TOMAR LOS VALORES QUE SE UTILIZAN PARA DIBUJAR EL PORCENTAJE DE ERROR
        int nMuestrasCogidas = 0;


        /************CLASES***************/
        //potencia
        Potencia potenciaClase = new Potencia(); //Clase potencia inicializada para utilizar sus metodos.



        public CalculosFs(Inicio.Ruta ruta)
        {
            InitializeComponent();
            //Igualamos la ruta que se ingresa desde la pestaña inicio con la variable ruta de esta clase para trabajar con ella en esta pestaña. 
            rutaArchivo = ruta.ruta; 

        }



       
        /// <summary>
        /// promedioPotenciaIdeal
        /// Se encarga de tomar tomar todos los datos de cada columna y sacar el promedio con el que se trabajara en los calculos de la PotenciaIdeal.
        /// </summary>
        private void promedioPotenciaIdeal()
        {

            SLDocument sl = new SLDocument(rutaArchivo);
            int iRow = 1; //indica la columna que se tomara como referencia a la hora de leer el archivo, basicamente indica desde donde empieza y donde terminara cuando no hayan datos.
            int contador = 0;
            //Variables para guardar el valor total de la suma de las columna de cada pierna.
            decimal Totalderecha = 0; 
            decimal TotalIzquierda = 0;

            //toma los valores de las columnas del Excel.
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1))) //Recorre el archivo hasta que no haya ningun valor para extraer.
            {
                //Ingresa cada columna en la variable correspondiente
                decimal izquierda = sl.GetCellValueAsDecimal(iRow, 2); 
                decimal derecha = sl.GetCellValueAsDecimal(iRow, 3);
                iRow++;
                contador++; // Toma la cantidad de valores que son para sacar el promedioPotenciaIdeal...
                Totalderecha += derecha; //Va sumando los valores encontrados
                TotalIzquierda += izquierda;
            }

            //se toma el promedio de cada columna:
            decimal fpromIzq = decimal.Round((TotalIzquierda / contador), 2);//redondea los datos y lo guardan en la variable para enviarlos
            decimal fpromDere = decimal.Round((Totalderecha / contador), 2);
            decimal fPromTOTAL = fpromIzq + fpromDere;
            potenciaIdeal(fpromIzq, fpromDere, fPromTOTAL );//toma los datos y saca la potenciaIdeal
        }




        /// <summary>
        /// barra_Scroll
        /// Metodo que muestra el valor de la barra en el label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barra_Scroll(object sender, EventArgs e)
        {
            valorBarra.Text = barra.Value.ToString();

        }

        /// <summary>
        /// BOTON CALCULAR 
        /// Llama los metodos necesarios para realizar los calculos de potencia real e ideal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            borrarMensajeErrorCalculos(); //Borra el aviso del error
            if (validarCamposCalculos() && validarCampoBarraFs())
            { //Solo si los campos necesarrios estan completos se podra entrar...
                richPotencia.Clear();
                richInfo.Clear();

                //Realiza el calculo de muestreo para saber las cantidades de muestras a tomar para el calculo
                //de potencia real.

                //obtiene el valor de frecuencia de muestrado FS ingresado por pantalla e indica la frecuencia con la que se iran tomando las muestras.
                calculaFuerzasPromediadas(Convert.ToInt32(valorBarra.Text));




                /**************************CALCULO SEGUN NUMERO DE MUESTREO******************************/

                //Info del archivo y la frecuencia de muestreo
                richInfo.AppendText("\n Muestras totales: " + nMuestrasTotales);
                richInfo.AppendText("\n Numero de muestras por pedalada(Sp): " + muestrasPorPedaladas); // La frecuencia con la que se tomaran las pruebas

              
                promedioPotenciaIdeal(); // Lleva a la funcion de sacar promedioPotenciaIdeal y cuando se realiza este llama a la funcion de potenciaReal

                //los resultados de la POTENCIA IDEAL se muestran en el rich.
                richPotencia.AppendText("\n" + "---- POTENCIA IDEAL ---- ");
                richPotencia.AppendText("\n" + " potencia pierna izquierda: " + pTotal_pIzquierda_ideal);
                richPotencia.AppendText("\n" + " potencia pierna derecha: " + pTotal_pDercha_ideal);
                richPotencia.AppendText("\n" + " potencia combinada: " + pTotal_pCombinada_ideal);


                // Se muestra el balance de error IDEAL
                richPotencia.AppendText("\n Balance Izq/dere: " + balanceIq_ideal + "/" + balanceDe_ideal);

               
                potenciaReal(totalPiernaIzq_muestreo, totalPiernaDer_muestreo, totalCombinada_muestreo);

                //escribiendo en rich POTENCIA REAL
                richPotencia.AppendText("\n\n ---- POTENCIA REAL ----");
                richPotencia.AppendText("\n potencia pierna izquierda: " + pTotal_pIzquierda_real);
                richPotencia.AppendText("\n potencia pierna derecha: " + pTotal_pDercha_real);
                richPotencia.AppendText("\n potencia combinada: " + pTotal_pCombinada_real);

                // Se muestra el balance de error REAL
                richPotencia.AppendText("\n Balance pierna Izq/dere: " + balanceIq_real + "/" + balanceDe_real);


                //Sacar porcentaje de error de: pierna izquierda, derecha y la combinacion de estas...
                richPotencia.AppendText("\n\n---PORCENTAJE DE ERROR--- " +
                            "\n % Error Pierna izquierda: " + calcularPorcentajeError(totalPiernaIzq_real_pError, totalPiernaIzq_ideal_pError)
                            + "\n % Error Pierna derecha: " +calcularPorcentajeError(totalPiernaD_real_pError, totalPiernaD_ideal_pError)
                            + "\n % Error combinada: " + calcularPorcentajeError(totalCombinada_real_pError, totalCombinada_ideal_pError)
                            );

                MessageBox.Show("Muestras sin tomar: " + factorCorreccion);


            }




        }

        /*********************************************************************/
        /*********************************************************************/
        //CALCULAR POTENCIA IDEAL
        /*********************************************************************/
        /*********************************************************************/
        public void potenciaIdeal(decimal fPromIzq, decimal fPromD, decimal fPromCombinada)
        {
            tomaDatos(); //Metodo encargado de extraer los datos ingresados en la interfaz y que se utilizaran en la formula.

            
            //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS
           //Utilizamos el metodo calculaPotencia que pertenece a la clase Potencia, este nos da los resultados obtenidos con la formula.
            pTotal_pIzquierda_ideal =   potenciaClase.calculaPotencia(fPromIzq ,fuerzaPico , cadencia, longitudBiela);
            pTotal_pDercha_ideal = potenciaClase.calculaPotencia(fPromD, fuerzaPico, cadencia, longitudBiela);
            pTotal_pCombinada_ideal = potenciaClase.calculaPotencia(fPromCombinada, fuerzaPico, cadencia, longitudBiela);
            //balance
            balanceIq_ideal = potenciaClase.calcularPorcentajeError(fPromIzq, fPromCombinada);
            balanceDe_ideal = potenciaClase.calcularPorcentajeError(fPromD, fPromCombinada);
           
            //variable para poder tomar los datos de cada variable por separado y no tener que crear un return ni funciones independientes
            totalPiernaIzq_ideal_pError = pTotal_pIzquierda_ideal;
            totalPiernaD_ideal_pError = pTotal_pDercha_ideal;
            totalCombinada_ideal_pError = pTotal_pCombinada_ideal;

        }

        /*********************************************************************/
        /*********************************************************************/
        //CALCULAR POTENCIA REAL 
        /*********************************************************************/
        /*********************************************************************/
        public void potenciaReal(decimal fIzqui, decimal fDere, decimal fCombinada)
        {
            tomaDatos();
            //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS
            //los resultados se muestran en el rich.
            pTotal_pIzquierda_real = potenciaClase.calculaPotencia(fIzqui, fuerzaPico, cadencia, longitudBiela); //Llama a la funcion encargada de realizar los calculos.
            pTotal_pDercha_real = potenciaClase.calculaPotencia(fDere, fuerzaPico, cadencia, longitudBiela);
            pTotal_pCombinada_real = potenciaClase.calculaPotencia(fCombinada, fuerzaPico, cadencia, longitudBiela);

            balanceIq_real = potenciaClase.calcularPorcentajeError(fIzqui, fCombinada);
            balanceDe_real = potenciaClase.calcularPorcentajeError(fDere, fCombinada);

            totalPiernaIzq_real_pError = pTotal_pIzquierda_real;
            totalPiernaD_real_pError = pTotal_pDercha_real;
            totalCombinada_real_pError = pTotal_pCombinada_real;

        }
        //TOMA LOS DATOS DE INTERFAZ

        public void tomaDatos()
        {
            fuerzaPico = Convert.ToDecimal(editFuerzaPico.Text.ToString());
            cadencia = Convert.ToDecimal(editCadencia.Text.ToString());
            longitudBiela = Convert.ToDecimal(editLongBiela.Text.ToString());
        }


        /*********************************************************************/
        /*********************************************************************/
        //DUBUJAR CURVA PORCENTAJE DE ERROR
        /*********************************************************************/
        /*********************************************************************/
        private void btErrorPotencia_Click(object sender, EventArgs e)
        {
          
            if (validarCamposGraficaError() && validarCamposCalculos())
            {
                int fsInicio = Convert.ToInt32(txtFsInicio.Text.ToString());
                int fsFinal = Convert.ToInt32(txtFsFinal.Text.ToString());
                int numPuntos = Convert.ToInt32(txtIncrementoFs.Text.ToString());


                tomaDatos();//Empezamos tomando los valores


              // fuerzaPico = Convert.ToDecimal(editFuerzaPico.Text.ToString());
              //  cadencia = Convert.ToDecimal(editCadencia.Text.ToString());
                /****************************** TOMANDO VALORES DE PONTENCIA IDEAL *****************************************/

                //LLamamos a la funcion promedioPotenciaIdeal para que se encargue de sacar el promedioPotenciaIdeal de todos los datos que se encuentran en
                //el archivo seleccionado anteriormente...
                promedioPotenciaIdeal(); //funcion que ya esta llamando por su cuenta a potenciaReal(), que es la encargada de 
                            //sacar la potencia ideal a los resultados que nos dio promedioPotenciaIdeal() para cada pierna y su combinacion.

                //al realizar la llamada de promedioPotenciaIdeal() ya se pueden usar las variables globales.
                //la que necesitamos son los totales de cada pierna, esto para llamar a calcularPorcentajeError() y nos los valores
                //necesarios para el grafico del porcentaje de error de la ideal.
                /*
                 * Variables a utilizar:
                 * 
                 *   totalPiernaIzq_ideal_pError
                 *   totalPiernaD_ideal_pError  
                 *   totalCombinada_ideal_pError
                 */

                //En este punto ya se podrian utilizar:



                /*******Dibujando en la grafica***********/
                chartErrores.Series["Combinada"].Points.Clear();
           
               // chartErrores.ChartAreas[0].AxisY.Interval = 0.50;
                /*
                for (int i = fsInicio; i < fsFinal; i += numPuntos) //hasta aqui funciona
                {
                    dibujarError(i);
                }*/

                int inicio = fsInicio;
                while(inicio <= fsFinal)
                {
                   
                    dibujarError(inicio);
                    inicio += numPuntos;
                }


            }
        }
        public void dibujarError(int i)
        {
            /*Si todo funciona tendrian que valer con usar estos valores

                       totalPiernaIzq_real_pError = pTotal_pIzquierda_real;
                       totalPiernaD_real_pError = pTotal_pDercha_real;
                       totalCombinada_real_pError = pTotal_pCombinada_real;
             */
            calculaFuerzasPromediadas(i);
            potenciaReal(totalPiernaIzq_muestreo, totalPiernaDer_muestreo, totalCombinada_muestreo);

            decimal porErrorC = calcularPorcentajeError(totalCombinada_real_pError, totalCombinada_ideal_pError);

            chartErrores.Series["Combinada"].Points.AddXY(i, porErrorC);
        }

        //PRUEBA CON TIMER
   

        //Se le debe ingresar el valor del fs la funcion se encarga de enviar los datos necesarios
        public void calculaFuerzasPromediadas(int fs)
        {
            //VARIABLES
          // int fs = Convert.ToInt32(fs.Text); // Toma la frecuencia de muestreo de los datos
            int numMuestras;//para tomar el numero de muestras
            SLDocument sl = new SLDocument(rutaArchivo);
            int Sp;
            int contador = 0;
            //variables para sumar los valores totales de cada pierna
            decimal totalIzquierda = 0;
            decimal totalDerecha = 0;


            try
            {   //toma los valores de los textView y si no estan vacios llama la funcion promedioPotenciaIdeal para que inicie
                //los calculos.
              
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

                    Sp = (fs * 60) / Convert.ToInt32(editCadencia.Text.ToString()); //Indicamos cada cuanto debe realizar el salto para tomar el valor siguiente.

                    //Info del archivo y la frecuencia de muestreo

                    //Esta informacion solo se mostrara al dar clic en el boton calcular, de lo contrario es irrelevante.
                    nMuestrasTotales = numMuestras;
                    muestrasPorPedaladas = Sp;


                    //indica cada cuantos pruebas se tomaran:
                    int muestras_A_tomar = numMuestras / Sp;

                    int iRow2 = 1;
                    nMuestrasCogidas = 0;

                //realiza la busqueda de los datos...
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow2, 1)))
                    {
                        decimal izquierda = sl.GetCellValueAsDecimal(iRow2, 2);
                        decimal derecha = sl.GetCellValueAsDecimal(iRow2, 3);
                        contador++;
                        iRow2++;


                    //  if (contador == muestras_A_tomar ) //toma no cada valor que indica el sp sino ese valor +1
                    if (contador == muestras_A_tomar )
                        {
                            //Se toma el valor siguiente al sp (cada cuantas muestras nos indicaron que se deben guardar anteriormente).
                            totalIzquierda += izquierda; //se van sumando a la variable izq y der
                            totalDerecha += derecha;

                            contador = 0; // vuelve a cero para reinicial el conteo despues de tomar el valor y volver a tomar cada cierto momento el valor.
                            nMuestrasCogidas++;
                        }
                    }


                    //si no es igual a 0 al terminar significa que quedaron pruebas sin tomar
                    factorCorreccion = (decimal) numMuestras / (decimal) (numMuestras - contador); 
                    

                    totalPiernaIzq_muestreo = totalIzquierda * factorCorreccion; //valores para luego utilizarlos en la funcion potenciaReal()
                    totalPiernaDer_muestreo = totalDerecha * factorCorreccion;

                totalPiernaIzq_muestreo = totalPiernaIzq_muestreo / (decimal) nMuestrasCogidas;
                totalPiernaDer_muestreo = totalPiernaDer_muestreo / (decimal) nMuestrasCogidas;
                totalCombinada_muestreo = totalIzquierda+totalDerecha / (decimal)nMuestrasCogidas;

            }
            catch
            {
                MessageBox.Show("Error con alguno de los valores numericos.");
            }



}

        
        //CALCULAR PORCENTAJE DE ERROR  (aHORA EN LA CLASE POTENCIA)
        /*********************************************************************/
        //Recibe el total de la potencia real y el total de la potencia ideal
        //El porcentaje de error:
        // %Error = (pReal - pIdeal) / pIdeal
        /*********************************************************************/
        private decimal calcularPorcentajeError(decimal pReal, decimal pIdeal)
        {
            return potenciaClase.calcularPorcentajeError(pReal,pIdeal);
        }

      
        //CALCULAR POTENCIA REAL
        /*********************************************************************/
        //Se le ingresa una fuerza total(real) y retorna el resultado al implementar la formula.
      /*  private decimal calculaPotenciaReal(decimal fTotal_real, int fs)
        {
            return potenciaClase.calculaPotenciaReal(fTotal_real, fs, fuerzaPico, cadencia,longitudBiela);
        }*/


        /****************************************************/
        /*************VERIFICAR CAMPOS VACIOS****************/
        /****************************************************/
        private bool validarCamposCalculos()
        {
            bool ok = true;

            if (editFuerzaPico.Text == "")
            {
                ok = false;
                errorCampoVacio.SetError(editFuerzaPico, "Ingresa Fuerza Pico.");
            }
            if (editLongBiela.Text == "")
            {
                ok = false;
                errorCampoVacio.SetError(editLongBiela, "Ingresa Longitud de Biela.");
            }

            if (editCadencia.Text == "")
            {
                ok = false;
                errorCampoVacio.SetError(editCadencia, "Ingresa la Cadencia.");
            }
          
            return ok;
        }
        //Solo verifica que la barra fs no este vacia.
        private bool validarCampoBarraFs()
        {
            bool ok = true;
            if (valorBarra.Text == "" || Convert.ToInt32(valorBarra.Text.ToString()) < 3)
            {
                ok = false;
                errorCampoVacio.SetError(valorBarra, "El valor fs debe ser mayor a 2.");
            }
            return ok;
        }


        /****************************************************/
        /*************VERIFICAR CAMPOS VACIOS PARA GRAFICA DE ERROR****************/
        /****************************************************/

        private bool validarCamposGraficaError()
        {

            bool ok = true;

            if (txtFsInicio.Text == "")
            {
                ok = false;
                errorCampoVacio.SetError(txtFsInicio, "Ingresa fs de inicio.");
            }
            if (txtFsFinal.Text == "")
            {
                ok = false;
                errorCampoVacio.SetError(txtFsFinal, "Ingresa fs final.");
            }

            if (txtIncrementoFs.Text == "")
            {
                ok = false;
                errorCampoVacio.SetError(txtIncrementoFs, "Ingresa incremento.");
            }
           
            return ok;
        }
        /*****************LIMPIAR CAMPOS***************************/

        private void borrarMensajeErrorCalculos()
        {
            errorCampoVacio.SetError(editFuerzaPico, "");
            errorCampoVacio.SetError(editLongBiela, "");
            errorCampoVacio.SetError(editCadencia, "");
            errorCampoVacio.SetError(valorBarra, "");
            errorCampoVacio.SetError(txtFsFinal, "");
            errorCampoVacio.SetError(txtFsFinal, "");
            errorCampoVacio.SetError(txtIncrementoFs, "");
        }

      
    }
}
