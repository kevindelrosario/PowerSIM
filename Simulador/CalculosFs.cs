using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Simulador.Clases;
using SpreadsheetLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Simulador
{

    public partial class CalculosFs : Form
    {
        public string rutaArchivo = string.Empty;
        public decimal fuerzaPico = decimal.Zero;
        public decimal cadencia = decimal.Zero;
        public decimal longitudBiela = decimal.Zero;



        // ruta 

       
        //ARRAYLISTS para guardar los campos:
    

        List<decimal> angulo;
        List<decimal> piernaIzquierda;
        List<decimal> piernaDerecha;
        List<decimal> piernaCombinada;
        List<decimal> velocidad;
        int muestrasTotales = 0; //para saber el total de muestras en el archivo:
      

        //para recorrer el archivo
        int iRow = 1;



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
       // public decimal nMuestrasTotales = decimal.Zero;
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

        //INFORMACION PARA PESTAÑA infoFS:

        // Crear una lista para almacenar los datos
        List<Datos> info_fs = new List<Datos>();

        public CalculosFs(Inicio.Ruta ruta, List<decimal> anguloI, List<decimal> PiernaDerechaI, List<decimal> piernaIzquierdaI, List<decimal> piernaCombinadaI, List<decimal> velocidadI, int muestrasTotalesI)
        {
            InitializeComponent();
            //Igualamos la ruta que se ingresa desde la pestaña inicio con la variable ruta de esta clase para trabajar con ella en esta pestaña. 
            rutaArchivo = ruta.ruta;

            // Indica el numero de pruebas que se debe tomar por sectores
         //   sl = new SLDocument(rutaArchivo);


          //  leerArchivo = new LeeArchivo(sl);

            //Se encarga de guardar los datos del archivo leido en ArrayLists para trabajar con este en todo el codigo.
            extraerInformacion(anguloI, PiernaDerechaI, piernaIzquierdaI, piernaCombinadaI, velocidadI, muestrasTotalesI);

        }





        /// <summary>
        /// extraerInformacion
        /// Lee todo el archivo y guarda los campos por arraysList para que se pueda utilizar en todo
        /// </summary>
        public void extraerInformacion(List<decimal> anguloI, List<decimal> piernaDerechaI, List<decimal> PiernaIzquierdaI, List<decimal> piernaCombinadaI, List<decimal> velocidadI, int muestrasTotalesI)
        {
            //rellena los arrayList con cada campo
          //  angulo = anguloI;
            piernaIzquierda = PiernaIzquierdaI;
            piernaDerecha = piernaDerechaI;
            piernaCombinada = piernaCombinadaI;
            velocidad = velocidadI;
            muestrasTotales = muestrasTotalesI;
            //tomamos el total de las muestras
         //   muestrasTotales = leerArchivo.MuestrasTotales;

            //lee todo el archivo
          /*  for (int i = 1; i <= muestrasTotales; i++)
            {
                richPotencia.AppendText("-"+Convert.ToDecimal(piernaDerecha[i - 1])+"\n");

            }*/

            }


        /// <summary>
        /// promedioPotenciaIdeal
        /// Se encarga de tomar tomar todos los datos de cada columna y sacar el promedio con el que se trabajara en los calculos de la PotenciaIdeal.
        /// </summary>
        private void promedioPotenciaIdeal()
        {
            //Variables para guardar el valor total de la suma de las columna de cada pierna.
            decimal Totalderecha = 0; 
            decimal TotalIzquierda = 0;
          
            //toma los valores de las columnas del Excel.

            for (int i = 1; i <= muestrasTotales; i++)
            {
                //Ingresa cada columna en la variable correspondiente
                Totalderecha += Convert.ToDecimal(piernaDerecha[i - 1]); //Va sumando los valores encontrados
                TotalIzquierda += Convert.ToDecimal(piernaIzquierda[i -1]);
               
            }

            //se toma el promedio de cada columna:
            decimal fpromIzq = decimal.Round((TotalIzquierda / muestrasTotales), 2);//redondea los datos y lo guardan en la variable para enviarlos
            decimal fpromDere = decimal.Round((Totalderecha / muestrasTotales), 2);
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
                richInfo.AppendText("\n Muestras totales: " + muestrasTotales);
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

                MessageBox.Show("Muestras x frecuencia: " + factorCorreccion);
                MessageBox.Show("Muestras cogidas: " + nMuestrasCogidas);

             //   MostrarValoresEnRichTextBox();
            }


        }
        private void MostrarValoresEnRichTextBox()
        {
            // Limpiar el RichTextBox antes de agregar los nuevos valores
            

            // Iterar a través de los valores del ArrayList y agregarlos al RichTextBox
            for (int j = 1; j <= muestrasTotales; j++)
            {
               
                richMuestreo.AppendText(angulo[j-1] +"\n");
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
          
            calculaFuerzasPromediadas(i);
            potenciaReal(totalPiernaIzq_muestreo, totalPiernaDer_muestreo, totalCombinada_muestreo);

            decimal porErrorC = calcularPorcentajeError(totalCombinada_real_pError, totalCombinada_ideal_pError);

            chartErrores.Series["Combinada"].Points.AddXY(i, porErrorC);

            // Agregar elementos a la lista
            //para enviarla al final desde el otro boton (+info)
            info_fs.Add(new Datos(i, totalCombinada_real_pError, totalCombinada_ideal_pError, porErrorC));
       
        }

        //PRUEBA CON TIMER
   

        //Se le debe ingresar el valor del fs la funcion se encarga de enviar los datos necesarios
        public void calculaFuerzasPromediadas(int fs)
        {
            //VARIABLES
            // int fs = Convert.ToInt32(fs.Text); // Toma la frecuencia de muestreo de los datos
            //  int numMuestras;//para tomar el numero de muestras

            int Sp;
            int muestras_conteo = 0;
            int sigue_conteo = 1;
            //variables para sumar los valores totales de cada pierna
            decimal totalIzquierda = 0;
            decimal totalDerecha = 0;


            try
            {   //toma los valores de los textView y si no estan vacios llama la funcion promedioPotenciaIdeal para que inicie
                //los calculos.
              
                    /**************************CALCULO SEGUN NUMERO DE MUESTREO******************************/

                   
                 
                    Sp = (fs * 60) / Convert.ToInt32(editCadencia.Text.ToString()); //Indicamos cada cuanto debe realizar el salto para tomar el valor siguiente.

                    //Info del archivo y la frecuencia de muestreo

                    //Esta informacion solo se mostrara al dar clic en el boton calcular, de lo contrario es irrelevante.
                  
                    muestrasPorPedaladas = Sp;

                    //indica cada cuantos pruebas se tomaran:
                    int muestras_A_tomar = muestrasTotales / Sp;
                    int vueltas = muestrasTotales / Sp;
                    

                   // int iRow2 = 1;
                    nMuestrasCogidas = 0;

                //Toma el total de pruebas como referencia para saber cuantas muestras debe haber al final.
                //para saber donde deterlo.
                int v2 = 0;
                for (int i = 1; i <= vueltas; i++)
                {

                    // decimal derecha = piernaDerecha[i - 1];
                    //decimal izquierda = piernaIzquierda[i - 1];
                    // muestras_conteo++;
                    nMuestrasCogidas= i;
                  
                    //se encarga de recorrer y guardar las muestras.
                        for (int j = 1; j <= muestrasTotales; j++) { 
                       
                        decimal derecha = piernaDerecha[j-1 ];
                        decimal izquierda = piernaIzquierda[j -1 ];


                        //realiza los saltos y toma las muestras.
                        //  for (int e = 1; e <= muestras_A_tomar; e++)
                        // {

                        if (muestras_conteo == muestras_A_tomar)
                            {
                                    
                                    totalIzquierda += izquierda; //se van sumando a la variable izq y der
                                  totalDerecha += derecha;
                            //  angulo.Add(j-1);
                           
                         
                            muestras_conteo = sigue_conteo; //debe empezar desde el ultimo valor
                            v2++;
                        }
                    
                        muestras_conteo++;
                    }

                    sigue_conteo += 1;
                    muestras_A_tomar += 1;
                }

                //promediar x muestras_A_tomar
               
                //si no es igual a 0 al terminar significa que quedaron pruebas sin tomar
                factorCorreccion = v2;

                    totalPiernaIzq_muestreo = totalIzquierda / muestras_A_tomar; //valores para luego utilizarlos en la funcion potenciaReal()
                    totalPiernaDer_muestreo = totalDerecha / muestras_A_tomar;

               // totalPiernaIzq_muestreo = totalPiernaIzq_muestreo / (decimal) nMuestrasCogidas;
              //  totalPiernaDer_muestreo = totalPiernaDer_muestreo / (decimal) nMuestrasCogidas;
                totalCombinada_muestreo = (totalIzquierda+totalDerecha) / vueltas;

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
            if (Convert.ToInt32(txtFsInicio.Text) >= Convert.ToInt32(txtFsFinal.Text))
            {
                ok = false;
                errorCampoVacio.SetError(txtFsInicio, "El fs inicial no puede ser mayor al final.");
            }

            if (txtIncrementoFs.Text == "")
            {
                ok = false;
                errorCampoVacio.SetError(txtIncrementoFs, "Ingresa incremento.");
            }
            if (Convert.ToInt32(txtIncrementoFs.Text) <= 0)
            {
                ok = false;
                errorCampoVacio.SetError(txtIncrementoFs, "Ingresa incremento mayor a 0");
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            InfoFs info = new InfoFs(info_fs);
           info.ShowDialog();
        }
    }
}
