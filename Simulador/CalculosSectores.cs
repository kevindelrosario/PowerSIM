using Simulador.Clases;
using SpreadsheetLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Simulador
{
    public partial class CalculosSectores : Form
    {
        
     
        //DATOS QUE INGRESA EL USUARIO
        public decimal fsMuestreo = decimal.Zero;
        public decimal fuerzaPico = decimal.Zero;
        public decimal cadencia = decimal.Zero;
        public decimal longitudBiela = decimal.Zero;

        public string rutaArchivo = string.Empty;
        //La ruta obtenida en el Form principal entra aqui


        //DATOS DEL EXCEL
        //Aun no lo estoy usando.
        public decimal totalPiernaIzq = decimal.Zero;
        public decimal totalPiernaDer = decimal.Zero;
        public decimal totalCombinada = decimal.Zero;

        List<decimal> angulo;
        List<decimal> piernaIzquierda;
        List<decimal> piernaDerecha;
        List<decimal> piernaCombinada;
        List<decimal> velocidad;
        int muestrasTotales = 0;


        // ruta 

        SLDocument sl;

        //DATOS DEL MUESTREO
        public decimal totalPiernaIzq_muestreo = decimal.Zero;
        public decimal totalPiernaDer_muestreo = decimal.Zero;
        public decimal totalCombinada_muestreo = decimal.Zero;

        //Variables para tomar los valores de muestreo que entran al realizar los calculos de potencia ideal y real.
        //Se utilizan luego para guardar los datos de muestreo y para luego mostrarlo al realizarse el calculo de potencia(real/ideal)
        public decimal nMuestrasTotales = decimal.Zero;
        public decimal muestrasPorPedaladas = decimal.Zero;


        /****************RESULTADO DE POTENCIA IDEAL************************************/
        public decimal pTotal_pIzquierda_ideal = decimal.Zero; //Aqui se guardara el resultado que se obtenga para poder trabajar con el sin problema por toda la clase
        public decimal pTotal_pDercha_ideal = decimal.Zero;
        public decimal pTotal_pCombinada_ideal = decimal.Zero;

        //Variables Balance  IDEAL
        public decimal balanceIq_ideal = decimal.Zero;
        public decimal balanceDe_ideal = decimal.Zero;

        //variables para obtener el total de las potencias ideales con las que se realizara el calculo de porcentaje de error y mostrar por pantalla las
        //potencias totales de cada pierna:
        public decimal totalPiernaD_ideal_pError = decimal.Zero;
        public decimal totalPiernaIzq_ideal_pError = decimal.Zero;
        public decimal totalCombinada_ideal_pError = decimal.Zero;

        //Factor correcion para saber cuantas muestras faltarian por tomar en caso de que no se recorra toda la circunferencia.
        public decimal factorCorreccion = decimal.Zero;

        // Número de muestras del archivo:
       // int numMuestras;

        //VARIABLES PARA TOMAR LOS VALORES QUE SE UTILIZAN PARA DIBUJAR EL PORCENTAJE DE ERROR
        int nMuestrasCogidas = 0;
        /************CLASES***************/
        //potencia
        Potencia potenciaClase = new Potencia();

        

        //Prueba ARRAYLIST
        //para no repetir codigo innecesario
        ArrayList sectorCom;
        ArrayList sectorIzq;
        ArrayList sectorDe;


        //*******GUARDAN LAS MUESTRAS DEL ANGULO DE INICIO INDICADO**********
        List<decimal> mInicioDerecha;
        List<decimal> mInicioIzquierda;
        //no las utilizado aun...
        List<decimal> mInicioVelocidad;
        List<decimal> mInicioAngulo;
        List<decimal> mInicioCombinada;


        public CalculosSectores(Inicio.Ruta ruta, List<decimal> anguloI, List<decimal> PiernaDerechaI, List<decimal> piernaIzquierdaI, List<decimal> piernaCombinadaI, List<decimal> velocidadI, int muestrasTotalesI)
        {

            InitializeComponent();

            //toma la ruta
            rutaArchivo = ruta.ruta;

            // Indica el numero de pruebas que se debe tomar por sectores
          //  sl = new SLDocument(rutaArchivo);

            //Se encarga de guardar los datos del archivo leido en ArrayLists para trabajar con este en todo el codigo.
        
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
            angulo = anguloI;
            piernaIzquierda = PiernaIzquierdaI;
            piernaDerecha = piernaDerechaI;
            piernaCombinada = piernaCombinadaI;
            velocidad = velocidadI;
            muestrasTotales = muestrasTotalesI;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // extraerInformacion();
            //toma los valores de los textView y si no estan vacios llama la funcion promedioPotenciaIdeal para que inicie
            //los calculos.

            if (validarCamposCalculosPotencia())
            {
                borrarMensajeErrorCalculos();
                tomaDatos();
                //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS


                //POTENCIA IDEAL
                promedioPotenciaIdeal();
                //los resultados de la POTENCIA IDEAL se muestran en el rich.
              

                //los resultados se muestran en el rich.
                calculaFuerzasPromediadas(Convert.ToInt32(editMuestreo.Text.ToString()));
                potenciaReal(totalPiernaIzq_muestreo, totalPiernaDer_muestreo, totalCombinada_muestreo);
        
            }



        }

        private void promedioPotenciaIdeal()
        {

          //  SLDocument sl = new SLDocument(rutaArchivo);
           // int iRow = 1;
          //  int muestras_sobrantes = 0;
            decimal Totalderecha = 0;
            decimal TotalIzquierda = 0;
            //toma los valores de las columnas del Excel.



            int total = 0;
            int  totali = 0;
           
            //ahora ya no lee el archivo, sino que trabaja con el arrayList de cada uno....

            for (int i= 1; i <= muestrasTotales; i++) 
            {
                Totalderecha += Convert.ToDecimal(piernaDerecha[i-1]); //Va sumando los valores encontrados
                TotalIzquierda += Convert.ToDecimal(piernaIzquierda[i -1]);
              
                totali = i;
            }
            total = totali; //para comprobar si funciona (recorre las 7200)



            decimal fpromIzq = decimal.Round((TotalIzquierda / muestrasTotales), 2);//redondea los datos y lo guardan en la variable para enviarlos
            decimal fpromDere = decimal.Round((Totalderecha / muestrasTotales), 2);
            decimal fPromTOTAL = fpromIzq + fpromDere;
            potenciaIdeal(fpromIzq, fpromDere, fPromTOTAL);//toma los datos y saca la potenciaIdeal
        }

        public void potenciaIdeal(decimal fPromIzq, decimal fPromD, decimal fPromCombinada)
        {
            richIdeal.Clear();
            tomaDatos();

            //Toma el Pi (valor en double) y lo pasa a decimal para poder trabajar con el mas abajo.
            // decimal pi = (Convert.ToDecimal(Math.PI));

            //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS21
            //  pTotal_pIzquierda_ideal = decimal.Round((fPromIzq * fuerzaPico * cadencia * pi * 2 * longitudBiela / 60000), 2);
            //    pTotal_pDercha_ideal = decimal.Round((fPromD * fuerzaPico * cadencia * pi * 2 * longitudBiela / 60000), 2);
            //   pTotal_pCombinada_ideal = decimal.Round((fPromCombinada * fuerzaPico * cadencia * pi * 2 * longitudBiela / 60000), 2);

            pTotal_pIzquierda_ideal = potenciaClase.calculaPotencia(fPromIzq, fuerzaPico, cadencia, longitudBiela);
            pTotal_pDercha_ideal = potenciaClase.calculaPotencia(fPromD, fuerzaPico, cadencia, longitudBiela);
            pTotal_pCombinada_ideal = potenciaClase.calculaPotencia(fPromCombinada, fuerzaPico, cadencia, longitudBiela);
            //balance
            balanceIq_ideal = potenciaClase.calcularPorcentajeError(fPromIzq, fPromCombinada);
            balanceDe_ideal = potenciaClase.calcularPorcentajeError(fPromD, fPromCombinada);

            //variable para poder tomar los datos de cada variable por separado y no tener que crear un return ni funciones independientes
            totalPiernaIzq_ideal_pError = pTotal_pIzquierda_ideal;
            totalPiernaD_ideal_pError = pTotal_pDercha_ideal;
            totalCombinada_ideal_pError = pTotal_pCombinada_ideal;

            
           // richIdeal.AppendText("\n" + "---- POTENCIA IDEAL ---- ");
            richIdeal.AppendText("\n" + " potencia pierna izquierda: " + pTotal_pIzquierda_ideal);
            richIdeal.AppendText("\n" + " potencia pierna derecha: " + pTotal_pDercha_ideal);
            richIdeal.AppendText("\n" + " potencia combinada: " + pTotal_pCombinada_ideal);


            // Se muestra el balance de error IDEAL
            richIdeal.AppendText("\n\n Balance Izq/dere: " + balanceIq_ideal + " / " + balanceDe_ideal);
        }


        public void potenciaReal(decimal fIzqui, decimal fDere, decimal fCombinada)
        {
            richReal.Clear();
            richMuestraReal.Clear();
            //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS
            //los resultados se muestran en el rich.

            richMuestraReal.AppendText("\n Muestras totales: " + muestrasTotales);
            richMuestraReal.AppendText("\n Numero de muestras por pedalada(Sp): " + muestrasPorPedaladas); // La frecuencia con la que se tomaran las pruebas

            //Muestra los resultados
            richReal.AppendText("\n" + " potencia pierna izquierda: " + potenciaClase.calculaPotencia(fIzqui, fuerzaPico, cadencia, longitudBiela));
            richReal.AppendText("\n" + " potencia pierna derecha: " + potenciaClase.calculaPotencia(fDere, fuerzaPico, cadencia, longitudBiela));
            richReal.AppendText("\n" + " potencia Combinada: " + potenciaClase.calculaPotencia(fCombinada, fuerzaPico, cadencia, longitudBiela));



            decimal balanceIq = potenciaClase.calcularPorcentajeError(fIzqui, fCombinada);
            decimal balanceDe = potenciaClase.calcularPorcentajeError(fDere, fCombinada);

            richReal.AppendText("\n\n Balance Izq/dere: " + balanceIq + " / " + balanceDe);

        }




        /// <summary>
        /// FUERZAS PROMEDIADAS
        /// Nos indica la cantidad de muestras a tomar segun la frecuencia de muestreo indicada....
        /// </summary>
        /// <param name="fs"></param>
        public void calculaFuerzasPromediadas(int fs)
        {
            //VARIABLES
            // int fs = Convert.ToInt32(fs.Text); // Toma la frecuencia de muestreo de los datos
          //  int numMuestras;//para tomar el numero de muestras
            SLDocument sl = new SLDocument(rutaArchivo);
            int Sp;
            int muestras_sobrantes = 0;
            //variables para sumar los valores totales de cada pierna
            decimal totalIzquierda = 0;
            decimal totalDerecha = 0;


            try
            {


                Sp = (fs * 60) / Convert.ToInt32(editCadencia.Text.ToString()); // Sp es el número de muestras por pedalada.

                //Info del archivo y la frecuencia de muestreo
                
                muestrasPorPedaladas = Sp;

                //indica cada cuantos pruebas se tomaran:
                int muestras_A_tomar = muestrasTotales / Sp;
                MessageBox.Show("Muestras a tomar: "+ muestras_A_tomar);
               // int iRow2 = 1;
                nMuestrasCogidas = 0;

                //realiza la busqueda de los datos...
                
                //ahora ya no lee el archivo, sino que trabaja con el arrayList de cada uno....

                for (int i = 1; i <= muestrasTotales; i++)
                {
                    
                    decimal derecha = Convert.ToDecimal(piernaDerecha[i - 1]);
                    decimal izquierda = Convert.ToDecimal(piernaIzquierda[i - 1]);
                    muestras_sobrantes++;
                    //  if (muestras_sobrantes == muestras_A_tomar ) //toma no cada valor que indica el sp sino ese valor +1
                    if (muestras_sobrantes == muestras_A_tomar)
                    {
                        //Se toma el valor siguiente al sp (cada cuantas muestras nos indicaron que se deben guardar anteriormente).
                        totalIzquierda += izquierda; //se van sumando a la variable izq y der
                        totalDerecha += derecha;

                        muestras_sobrantes = 0; // vuelve a cero para reinicial el conteo despues de tomar el valor y volver a tomar cada cierto momento el valor.
                        nMuestrasCogidas++;
                    }
                   
                }
            
                //si no es igual a 0 al terminar significa que quedaron pruebas sin tomar
                factorCorreccion = (decimal)muestrasTotales / (decimal)(muestrasTotales - muestras_sobrantes);

                totalPiernaIzq_muestreo = totalIzquierda * factorCorreccion; //valores para luego utilizarlos en la funcion potenciaReal()
                totalPiernaDer_muestreo = totalDerecha * factorCorreccion;

                //valores para luego utilizarlos en la funcion potenciaReal()
                totalPiernaIzq_muestreo = totalPiernaIzq_muestreo / (decimal)nMuestrasCogidas;
                totalPiernaDer_muestreo = totalPiernaDer_muestreo / (decimal)nMuestrasCogidas;
                totalCombinada_muestreo = (totalIzquierda + totalDerecha) / (decimal)nMuestrasCogidas;
            }
            catch
            {
                MessageBox.Show("Error con alguno de los valores numericos.");
            }


        }


        private void btCalcularConfi_Click(object sender, EventArgs e)
        {
            // int numSectores = Convert.ToInt32(editNumeroSectores.Text);
            borrarMensajeErrorCalculos();

            if (verificarCampoConf() && validarCamposCalculosPotencia())
            {
               //Muestras que se saltaran por el grado de inicio indicado
                MessageBox.Show("Muestras a tomar por el angulo " + dividirCircunferencia(Convert.ToInt32(editGradoInicial.Text)));

                //Lleva los datos a la grafica
           //     graficaAngulo((int)dividirCircunferencia(Convert.ToInt32(editAnguloInicio.Text)));

                
                //tomamos los datos de configuracion:
                int numSectores = Convert.ToInt32(editNumeroSectores.Text);
                int anguloInicio = Convert.ToInt32(editGradoInicial.Text);

                //Ingresa las muestras indicadas segun el grado de inicio
                muestrasPorAngulo((int)dividirCircunferencia(Convert.ToInt32(editGradoInicial.Text)));
            
                //Comprobamos cuantas pruebas debe haber por sectores.
                // MessageBox.Show("resultado de la division: " + dividirMuestras(numSectores));
                //segun el numero de muestras por sector se empiza a dividir y calcular
                dividirSectores(dividirMuestras(numSectores), anguloInicio); //Entra: cantidad de pruebas por sectores y el sectore de inicio        
                
                
            }
            else
            {
                MessageBox.Show("no valido");
            }
        }



        /// <summary>
        /// SECTORES
        /// Se encarga de tomar el numero de muestras por sectorCom y guardar los datos segun el numero de sectores que se indiquen.
        /// </summary>
        /// <returns></returns>
        public void dividirSectores(int nMuestras, int angInicio)
        {
            tomaDatos();
            richSectores.Clear();
            sectorCom = new ArrayList();
           sectorIzq = new ArrayList();
           sectorDe = new ArrayList();

            decimal sumaSectorDe = 0;
            decimal sumaSectorIz = 0;
            decimal sumaSectorCom = 0;


          
            //int cont = 0; //para reinicial el conteo de las pruebas
            //              //variables para potencia Ideal
            decimal izquierdaReal = 0;
            decimal derechaReal = 0;


            int numSectores = Convert.ToInt32(editNumeroSectores.Text);
            int fs = Convert.ToInt32(editMuestreo.Text);
            int Sp, Ss;

            Sp = (fs * 60) / Convert.ToInt32(editCadencia.Text.ToString()); // Sp es el número de muestras por pedalada.
            Ss = Sp / numSectores;
            int espacioEntreMuestras = nMuestras / Sp; // Indica las muestras a desechar entre cada muyestra válida.

            int n_muestrasSector = 0;


          
            chartAngulo.Series[0].Points.Clear();
            // Calcular el ángulo equivalente en el rango de 0 a 360 grados
            int startAngle;

            startAngle = AdjustAngle(angInicio-90);
            //PieStartAngle sirve para indicar el grado desde donde debe empezar 
            chartAngulo.Series[0]["PieStartAngle"] = startAngle.ToString();

            for (int i = 1; i <= muestrasTotales; i++)
            {
                // Vamos guardando las muestras válidfas hasta completar el sector:
                if (i % espacioEntreMuestras == 0)
                {
                    //anterior:
                   // izquierdaReal += Convert.ToDecimal(piernaIzquierda[i - 1]);
                  //  derechaReal += Convert.ToDecimal(piernaDerecha[i - 1]);

                    //segun angulo de inicio:
                    izquierdaReal += Convert.ToDecimal(mInicioIzquierda[i - 1]);
                    derechaReal += Convert.ToDecimal(mInicioDerecha[i - 1]);

                    ////Se van guardando los datos hasta que el muestras_sobrantes llegue al numero de pruebas que se debe ingresar por sectorCom
                    //if (cont < nMuestras)
                    //{
                    //    izquierdaReal += sl.GetCellValueAsDecimal(iRow, 2);
                    //    derechaReal += sl.GetCellValueAsDecimal(iRow, 3);
                    //    cont++;
                    n_muestrasSector++;
                }
                if (i % nMuestras == 0)
                {

                    //Se saca el promedio al sumar todas y dividir entre la cantidad total

                 

                    //extraerInformacion (VERIFICAR SI ES CORRECTA LA FORMA DE SACAR EL PROMEDIO)

                    decimal combP = decimal.Round(((izquierdaReal + derechaReal) / n_muestrasSector), 2); //puede que tenga que dividir entre numero de sectores
                    decimal dereP = decimal.Round((derechaReal / n_muestrasSector), 2);
                    decimal izqP = decimal.Round((izquierdaReal / n_muestrasSector), 2);


                    decimal combinada = potenciaClase.calculaPotencia(combP, fuerzaPico,cadencia,longitudBiela);
                    decimal Derecha = potenciaClase.calculaPotencia(dereP, fuerzaPico, cadencia, longitudBiela);
                    decimal Izquierda = potenciaClase.calculaPotencia(izqP, fuerzaPico, cadencia, longitudBiela);



                    sectorCom.Add(combinada);
                    sectorDe.Add(Derecha);
                    sectorIzq.Add(Izquierda);


                    //   MessageBox.Show("\n-Num. Sector: "+ sectorCom.Count +"\n-Potencia: "+combinada);
                    richSectores.AppendText("\nNUMERO SECTOR: " + sectorCom.Count);
                    richSectores.AppendText("\n ------ Potencia Derecha: " + Derecha);
                    richSectores.AppendText("\n ------ Potencia Izquierda: " + Izquierda);
                    richSectores.AppendText("\n ------ Potencia Combinada: "+combinada+"\n");

                    //PORCENTAJE DE ERROR POR SECTORES

                    //*******************OJO AQUIIIIII abajo ALGO ESTA MAL************************

                   
                    //LLAMADA A LA FUNCION QUE DIBUJA EN LA GRAFICA
                   
                    chartAngulo.Series[0].Points.AddXY(sectorCom.Count, nMuestras);

                    izquierdaReal = 0;
                    derechaReal = 0;
                    n_muestrasSector = 0;
                }
                
               
            }

            int contS = 0;

            //Segun el grado de inicio que se indique se empezaran a sumar los valores que haya dentro del arrayList.
            for (int i = 1; i <= sectorCom.Count; i++) //i = angulo - 1 porque asi los angulos no empizan desde el cero.
            {
                sumaSectorDe += Convert.ToDecimal(sectorDe[i - 1]); //guarda la suma de sectores segun se indica con el grado de inicio
                sumaSectorIz += Convert.ToDecimal(sectorIzq[i - 1]);
                sumaSectorCom += Convert.ToDecimal(sectorCom[i - 1]);
                contS++;
               
            }
            richSectores.AppendText("\n*******SUMA TOTAL DE " + contS + "  SECTORES*******" +
                "\n*** Derecha: " + decimal.Round(sumaSectorDe / numSectores, 2)
               + "\n*** Izquierda: " + decimal.Round(sumaSectorIz / numSectores, 2)
                + "\n*** Combinada: " + decimal.Round(sumaSectorCom / numSectores, 2) + "\n"
            + "*** Balance izq/der: " + decimal.Round(potenciaClase.balanceDeError(sumaSectorIz, sumaSectorCom),1) + " / " + decimal.Round(potenciaClase.balanceDeError(sumaSectorDe, sumaSectorCom),1) + "\n\n"); ;

           porcentajeErrorPotencias();
            richSectores.AppendText("Porcentaje de error:\n" +
                "- % Error combinada: "+ potenciaClase.calcularPorcentajeError(decimal.Round(sumaSectorCom / numSectores, 2), totalCombinada_ideal_pError)
                +"\n"+ "- % Error Derecha: "+ potenciaClase.calcularPorcentajeError(decimal.Round(sumaSectorDe / numSectores, 2), totalPiernaD_ideal_pError)
                 + "\n" + "- % Error Izquierda: " + potenciaClase.calcularPorcentajeError(decimal.Round(sumaSectorIz / numSectores, 2), totalPiernaIzq_ideal_pError));
        }
        public void porcentajeErrorPotencias()
        {
            decimal combinada = 0;
            decimal Totalderecha = 0;
            decimal TotalIzquierda = 0;
          
            // trabaja con el arrayList de cada uno....

            for (int i = 1; i <= muestrasTotales; i++)
            {
                combinada += Convert.ToDecimal(piernaCombinada[i - 1]);
                Totalderecha += Convert.ToDecimal(piernaDerecha[i - 1]); //Va sumando los valores encontrados
                TotalIzquierda += Convert.ToDecimal(piernaIzquierda[i - 1]);
            }
            decimal fpromComb = decimal.Round((combinada / muestrasTotales), 2);//redondea los datos y lo guardan en la variable para enviarlos

            decimal fpromIzq = decimal.Round((TotalIzquierda / muestrasTotales), 2);//redondea los datos y lo guardan en la variable para enviarlos

            decimal fpromDer = decimal.Round((Totalderecha / muestrasTotales), 2);//redondea los datos y lo guardan en la variable para enviarlos

         

             totalPiernaD_ideal_pError = potenciaClase.calculaPotencia(fpromDer, fuerzaPico, cadencia, longitudBiela);
            totalPiernaIzq_ideal_pError = potenciaClase.calculaPotencia(fpromIzq, fuerzaPico, cadencia, longitudBiela);
            totalCombinada_ideal_pError = potenciaClase.calculaPotencia(fpromComb, fuerzaPico, cadencia, longitudBiela);
          
        }

        private int AdjustAngle(int angle)
        {
            // Ajustar el ángulo dentro del rango de 0 a 360 grados
            while (angle < 0)
            {
                angle += 360;
            }

            return angle % 360;
        }
        public bool verificarCampoConf()
        {
            bool ok = true;
            
          
            //sectores
            if (editNumeroSectores.Text == "")
            {
                ok = false;
                errorConfi.SetError(editNumeroSectores, "Indicar numero de sectores");
            }
            else
            {
                if ((Convert.ToInt32(editNumeroSectores.Text) % 2 != 0))
                {
                    ok = false;
                    errorConfi.SetError(editNumeroSectores, "El numero de sector debe ser par.");
                }
                else
                {
                    if (!divisor360(Convert.ToInt32(editNumeroSectores.Text)))
                    {
                        ok = false;
                        errorConfi.SetError(editNumeroSectores, "El numero de sector debe ser divisor de 360.");
                    }
                } 

                if (Convert.ToInt32(editNumeroSectores.Text) > 12)
                {
                    ok = false;
                    errorConfi.SetError(editNumeroSectores, "Numero maximo de sectores: 12");
                }
            }

            //angulo
            if (editGradoInicial.Text == "")
            {
                ok = false;
                errorConfi.SetError(editGradoInicial, "Indicar angulo de inicio");
            }
          

            return ok;

        }

        /// <summary>
        /// DIVISOR 369
        /// Se asegura que el valor ingresado sea un divisaor exacto del 360
        /// </summary>
        /// <returns></returns>
        public bool numeroSectoresError()
        {
            bool ok = true;

            //numero % 360 = num
            //if (num * numero = 360) = divisor 

         
         //   int divisor =  360/ numero;

            if (!divisor360(Convert.ToInt32(editNumeroSectores.Text)))
            {
                ok = false;
            }
            return ok;

        }

        public bool divisor360(int num)
        {
            bool ok = true;
           
            //numero % 360 = num
            //if (num * numero = 360) = divisor 

           
            int divisor = 360 / num;

            if (divisor * num != 360)
            {
                ok = false;
            }
            return ok;

        }
      
        public int dividirMuestras(int sectores)
        {
            return  muestrasTotales / sectores;

        }

        /// <summary>
        /// tomaDatos
        /// Toma los datos de la interfaz para realizar los calculos de potencia Real e Ideal que se mostrara por pantalla.
        /// </summary>
        public void tomaDatos()
        {
            fsMuestreo = Convert.ToDecimal(editMuestreo.Text.ToString());
            fuerzaPico = Convert.ToDecimal(editFuerzaPico.Text.ToString());
            cadencia = Convert.ToDecimal(editCadencia.Text.ToString());
            longitudBiela = Convert.ToDecimal(editLongBiela.Text.ToString());
        }

    

        /********************************************************************/
        /************************CONTROL DE ERRORES**************************/
        /********************************************************************/

       /// <summary>
       /// validaCamposCalculos
       /// Verifica que los campos donde se ingresan los valores utilizados para calcular las potencias ideal/real esten correctos.
       /// </summary>
       /// <returns></returns>
        private bool validarCamposCalculosPotencia()
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
            if (editMuestreo.Text == "" || Convert.ToInt32(editMuestreo.Text.ToString()) < 3)
            {
                ok = false;
                errorCampoVacio.SetError(editMuestreo, "El valor fs debe ser mayor a 2.");
            }

            return ok;
        }

        /// <summary>
        /// borrarMensajeErrorCalculos
        /// Borrar el mensaje de error que aparece al usuario ingresar un valor erroneo en los campos para el calculo de potencia.
        /// </summary>
        private void borrarMensajeErrorCalculos()
        {
            errorCampoVacio.SetError(editFuerzaPico, "");
            errorCampoVacio.SetError(editLongBiela, "");
            errorCampoVacio.SetError(editCadencia, "");
            errorCampoVacio.SetError(editMuestreo, "");

            //error campo configuracion
            errorConfi.SetError(editNumeroSectores, "");
            errorConfi.SetError(editGradoInicial, "");
        }

        private void btGraficarSectorizacion_Click(object sender, EventArgs e)
        {
            borrarMensajeErrorGraficaSectores();
            borrarMensajeErrorCalculos();
            chartSectorizacion.Series["sectores"].Points.Clear();
          
            if (validarCamposCalculosPotencia() && verificarCampoGrafica()) //verificamos que los campos cumplan los requisitos.
            {
               
                int sectorMaximo = Convert.ToInt32(editMaximoSectorG.Text);
                int sectorInicial = Convert.ToInt32(editInicioSectorG.Text);

                //Ingresa las muestras indicadas segun el grado de inicio
                muestrasPorAngulo((int)dividirCircunferencia(Convert.ToInt32(gradoInicialGrafica.Text)));

                //lo lleva a la grafica
                graficarSectores(sectorInicial, sectorMaximo);
            }
        }


        public void graficarSectores( int angInicio, int agMaximo)
        {
            chartSectorizacion.Series["sectores"].Points.Clear();
            tomaDatos();
            richSectores.Clear();
            sectorCom = new ArrayList();
            sectorIzq = new ArrayList();
            sectorDe = new ArrayList();

            if (angInicio > agMaximo)
            {
                MessageBox.Show("El anguno inicial no puede ser mayor al maximo.");
            }
            else
            {
                for (int i = angInicio; i <= agMaximo; i++)
                {
                    if ((divisor360(i)) && (i % 2 == 0))
                    {
                        //hasta aqui funciona correctamente...
                        //  MessageBox.Show("Es divisor: " + i);

                        /***********************************divide sectores y calcula*******************************************************/
                        
                        
                        int nMuestras = dividirMuestras(i);  //divide las muestras segun el numero de sectores que indica la i.


                      //  decimal sumaSectorDe = 0;
                        //decimal sumaSectorIz = 0;
                        decimal sumaSectorCom = 0;


                        decimal izquierdaReal = 0;
                        decimal derechaReal = 0;


                        int numSectores = i;
                        int fs = Convert.ToInt32(editMuestreo.Text);
                        int Sp, Ss;

                        Sp = (fs * 60) / Convert.ToInt32(editCadencia.Text.ToString()); // Sp es el número de muestras por pedalada.
                        Ss = Sp / numSectores;
                        int espacioEntreMuestras = nMuestras / Sp; // Indica las muestras a desechar entre cada muestra válida.

                        int n_muestrasSector = 0;



                    
                        // Calcular el ángulo equivalente en el rango de 0 a 360 grados
                   //     int startAngle;

                      //  startAngle = AdjustAngle(angInicio - 90);
                        //PieStartAngle sirve para indicar el grado desde donde debe empezar 
                     //   chartAngulo.Series[0]["PieStartAngle"] = startAngle.ToString();

                        for (int e = 1; e <= muestrasTotales; e++)
                        {
                            // Vamos guardando las muestras válidfas hasta completar el sector:
                            if (e % espacioEntreMuestras == 0)
                            {
                                //segun angulo de inicio:
                                izquierdaReal += Convert.ToDecimal(mInicioIzquierda[e - 1]);
                                derechaReal += Convert.ToDecimal(mInicioDerecha[e - 1]);
                               
                                n_muestrasSector++;
                            }
                            if (e % nMuestras == 0)
                            {

                                //Se saca el promedio al sumar todas y dividir entre la cantidad total
                                //extraerInformacion (VERIFICAR SI ES CORRECTA LA FORMA DE SACAR EL PROMEDIO)

                                decimal combP = decimal.Round(((izquierdaReal + derechaReal) / n_muestrasSector), 2); //puede que tenga que dividir entre numero de sectores
                                decimal dereP = decimal.Round((derechaReal / n_muestrasSector), 2);
                                decimal izqP = decimal.Round((izquierdaReal / n_muestrasSector), 2);


                                decimal combinada = potenciaClase.calculaPotencia(combP, fuerzaPico, cadencia, longitudBiela);
                                decimal Derecha = potenciaClase.calculaPotencia(dereP, fuerzaPico, cadencia, longitudBiela);
                                decimal Izquierda = potenciaClase.calculaPotencia(izqP, fuerzaPico, cadencia, longitudBiela);



                                sectorCom.Add(combinada);
                                sectorDe.Add(Derecha);
                                sectorIzq.Add(Izquierda);


                                //   MessageBox.Show("\n-Num. Sector: "+ sectorCom.Count +"\n-Potencia: "+combinada);
                       //         richSectores.AppendText("\nNUMERO SECTOR: " + sectorCom.Count);
                          //      richSectores.AppendText("\n ------ Potencia Derecha: " + Derecha);
                          //      richSectores.AppendText("\n ------ Potencia Izquierda: " + Izquierda);
                         //       richSectores.AppendText("\n ------ Potencia Combinada: " + combinada + "\n");

                                //PORCENTAJE DE ERROR POR SECTORES

                                //*******************OJO AQUIIIIII abajo ALGO ESTA MAL************************


                                //LLAMADA A LA FUNCION QUE DIBUJA EN LA GRAFICA

                           //     chartAngulo.Series[0].Points.AddXY(sectorCom.Count, nMuestras);

                                izquierdaReal = 0;
                                derechaReal = 0;
                                n_muestrasSector = 0;
                            }


                        }

                        int contS = 0;

                        //Segun el grado de inicio que se indique se empezaran a sumar los valores que haya dentro del arrayList.
                        for (int o = 1; o <= sectorCom.Count; o++) //i = angulo - 1 porque asi los angulos no empizan desde el cero.
                        {
                          //  sumaSectorDe += Convert.ToDecimal(sectorDe[o - 1]); //guarda la suma de sectores segun se indica con el angulo de inicio
                        //    sumaSectorIz += Convert.ToDecimal(sectorIzq[o - 1]);
                            sumaSectorCom += Convert.ToDecimal(sectorCom[o - 1]);
                            contS++;

                        }
              /*          richSectores.AppendText("\n*******SUMA TOTAL DE " + contS + "  SECTORES*******" +
                            "\n*** Derecha: " + decimal.Round(sumaSectorDe / numSectores, 2)
                           + "\n*** Izquierda: " + decimal.Round(sumaSectorIz / numSectores, 2)
                            + "\n*** Combinada: " + decimal.Round(sumaSectorCom / numSectores, 2) + "\n"
                        + "*** Balance izq/der: " + decimal.Round(potenciaClase.balanceDeError(sumaSectorIz, sumaSectorCom), 1) + " / " + decimal.Round(potenciaClase.balanceDeError(sumaSectorDe, sumaSectorCom), 1) + "\n\n"); ;
              */
                        porcentajeErrorPotencias();
                        richSectores.AppendText("\n sectores = "+i+
                            "\n- % Error combinada: " + potenciaClase.calcularPorcentajeError(decimal.Round(sumaSectorCom / numSectores, 2), totalCombinada_ideal_pError));
                        // + "\n" + "- % Error Derecha: " + potenciaClase.calcularPorcentajeError(decimal.Round(sumaSectorDe / numSectores, 2), totalPiernaD_ideal_pError)
                        //  + "\n" + "- % Error Izquierda: " + potenciaClase.calcularPorcentajeError(decimal.Round(sumaSectorIz / numSectores, 2), totalPiernaIzq_ideal_pError));

                        chartSectorizacion.Series["sectores"].Points.AddXY(i, potenciaClase.calcularPorcentajeError(decimal.Round(sumaSectorCom / numSectores, 2), totalCombinada_ideal_pError));
                        /******************************************************************************************/

                    }
                }
            }
           
           

            /*
                 int cont = 0; //para reinicial el conteo de las pruebas
                               //variables para potencia Ideal
                 decimal izquierdaIdeal = 0;
                 decimal derechaIdeal = 0;

                // int iRow = 1;

                // int numSectores = Convert.ToInt32(editMaximoSectorG.Text);

                 //realiza la busqueda de los datos...
                 for (int i = 1; i <= muestrasTotales; i++)
                 {

                     //Se van guardando los datos hasta que el muestras_sobrantes llegue al numero de pruebas que se debe ingresar por sectorCom
                     if (i % nMuestras == 0)
                     {
                         izquierdaIdeal += piernaDerecha[i - 1];
                         derechaIdeal += piernaIzquierda[i - 1];
                         cont++;
                     }
                     if (i == nMuestras)
                     {

                         //Se saca el promedio al sumar todas y dividir entre la cantidad total


                         //extraerInformacion 2 con numero de muestras
                         decimal combP = decimal.Round(((izquierdaIdeal + derechaIdeal) / nMuestras), 2);
                         decimal dereP = decimal.Round((derechaIdeal / nMuestras), 2);
                         decimal izqP = decimal.Round((izquierdaIdeal / nMuestras), 2);

                         // fuerzaPico = Convert.ToDecimal(editFuerzaPico.Text.ToString());
                         //  cadencia = Convert.ToDecimal(editCadencia.Text.ToString());
                         //  longitudBiela = Convert.ToDecimal(editLongBiela.Text.ToString());

                         decimal combinada = potenciaClase.calculaPotencia(combP, fuerzaPico, cadencia, longitudBiela);
                         decimal Derecha = potenciaClase.calculaPotencia(dereP, fuerzaPico, cadencia, longitudBiela);
                         decimal Izquierda = potenciaClase.calculaPotencia(izqP, fuerzaPico, cadencia, longitudBiela);



                         sectorCom.Add(combinada);
                         sectorDe.Add(Derecha);
                         sectorIzq.Add(Izquierda);


                         cont = 0;
                     }

                  //   iRow++;

                 }

                 chartSectorizacion.Series["sectores"].Points.Clear();

                 //Segun el angulo de inicio que se indique se empezaran a graficar los valores que haya dentro del arrayList.
                // chartSectorizacion.ChartAreas[0].AxisY.Interval = 1;
                 for (int i = angInicio; i <= sectorCom.Count; i++)
                 {
                     //i = angulo - 1 poque asi los angulos no empizan desde el cero.


                     //  decimal porErrorC = calcularPorcentajeError(totalCombinada_real_pError, totalCombinada_ideal_pError);

                     decimal sumaSectorCom = Convert.ToDecimal(sectorCom[i - 1]);
                     chartSectorizacion.Series["sectores"].Points.AddXY( i, sumaSectorCom); // se debe cambiar el valor a grafical por el correcto (Error Potencia)



                 }
                 */

        }

        private void borrarMensajeErrorGraficaSectores()
        {
            errorCampoVacio.SetError(editMaximoSectorG, "");
            errorCampoVacio.SetError(editInicioSectorG, "");
        }
            public bool verificarCampoGrafica()
        {
            bool ok = true;


            //sectores
            if (editMaximoSectorG.Text.Equals(""))
            {
                ok = false;
                errorConfi.SetError(editMaximoSectorG, "Indicar numero Maximo de sectores");
            }
            if (editInicioSectorG.Text.Equals(""))
            {
                ok = false;
                errorConfi.SetError(editInicioSectorG, "Indicar numero incial de sector");
            }
            return ok;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //tomamos el angulo inicial para saber desde donde se empieza
            MessageBox.Show("Muestras a tomar por el angulo "+ dividirCircunferencia(Convert.ToInt32(editGradoInicial.Text) ));

            //Lleva los datos a la grafica
            graficaAngulo((int)dividirCircunferencia(Convert.ToInt32(editGradoInicial.Text)));

            
        }

        public int dividirCircunferencia(int angulo)
        {
            //toma el angulo que indica el usuario y lo envia para saber en que punto empezar
            //devuelve ese punto para empezar a graficar
            return  (angulo * muestrasTotales) / 360; ;
            //formula: (grado * total valores en la circunferencia) / 360 = valores a tomar
        }


        public void graficaAngulo(int inicio)
        {
            chartAngulo.Series[0].Points.Clear();
            //******************DIBUJA LA GRAFICA PASTEL**************
          //  chartAngulo.Series[0]["PieStartAngle"] = "0";
            // ***Parte tomada de la circunferencia segun el angulo que se nos indica.
            chartAngulo.Series[0].Points.AddXY("inicio", inicio);

            //***valor restante de la grafica
            if (inicio > 0)
            {
                chartAngulo.Series[0].Points.AddXY("Sobrante", (muestrasTotales - inicio));
            }
            else
            {
                int inicioNaP = Math.Abs(inicio); //lo pasa a positivo para restar 
                chartAngulo.Series[0].Points.AddXY("Sobrante", (muestrasTotales - inicioNaP));//lo pasa a negativo para graficar
            }
          

          
        }
        /// <summary>
        /// muestrasPorAngulo
        /// Este metodo se encarga de realizar los saltos en positivo o negativo segun el grado de inicio que se le indique
        /// y con esos datos ingresar en sus respectivos arrayList para poder trabajar con ellos en los calculos de porcentaje de error.
        /// </summary>
        /// <param name="inicio"></param>
        public void muestrasPorAngulo(int inicio)
        {
            //*******GUARDAN LAS MUESTRAS DEL ANGULO DE INICIO INDICADO**********
            mInicioDerecha = new List<decimal>();
            mInicioIzquierda = new List<decimal>();
            //no las utilizado aun...
            mInicioVelocidad = new List<decimal>();
            mInicioAngulo = new List<decimal>();
            mInicioCombinada = new List<decimal>();

         
          //  richSectores.Clear();
           // int e ;
            
            //cuando el angulos esta en positivo:

            if(inicio > 0)
            {
            //    e = 0;
            //    richSectores.AppendText("\n******************GRADO INICIAL****************");
                //toma los valores desde el grado que se haya indicado hasta el final.
                for (int i = inicio; i <= muestrasTotales; i++)
                {
                    //Agrega el valor del otro arrayList
                    mInicioIzquierda.Add(piernaIzquierda[i - 1]); //tama desde el valor que inicia el angulo indicado y llega al final de la circunferencia. 
                    mInicioDerecha.Add(piernaDerecha[i - 1]);
                  //  richSectores.AppendText("\n- #" + (i) + "  " + mInicioIzquierda[e]);//para verificar que funciona.
                //    e++;

                }
                //     richSectores.AppendText("**********************SOBRANTES*******************");
                //toma los valores que no se utilizaron(en este caso de 0 hasta el valor anterior a donde inicia el angulo a guardar muestras):
                for (int i = 1; i < inicio; i++)
                {
                    
                    mInicioIzquierda.Add(piernaIzquierda[i - 1]);
                    mInicioDerecha.Add(piernaDerecha[i - 1]);
              //      richSectores.AppendText("\n- #" + (i) + "  " + mInicioIzquierda[e]);
            //        e++;
                }


            }else if (inicio == 0)
            {
        
           //     richSectores.AppendText("\n******************GRADO INICIAL****************");
                //toma los valores desde el grado que se haya indicado hasta el final.
                for (int i = 1; i < muestrasTotales+1; i++)
                {
                    //Agrega el valor del otro arrayList
                    mInicioIzquierda.Add(piernaIzquierda[i-1]); //tama desde el valor que inicia el angulo indicado y llega al final de la circunferencia. 
                    mInicioDerecha.Add(piernaDerecha[i-1]);
               //     richSectores.AppendText("\n- #" + (i) + "  " + mInicioIzquierda[e]);//para verificar que funciona.
               //     e++;
                }
            }
            else
            {
             //   int nMuestras = muestrasTotales;


                  int inicioNaP = Math.Abs(inicio); //lo pasa a positivo 
                int gradoInicio = muestrasTotales - inicioNaP; // se resta el valor y desde el resultado que nos indique se empieza a contar.

               // e = 0;
             //   richSectores.AppendText("\n******************GRADO INICIAL****************");
                //toma los valores desde el grado que se haya indicado hasta el final.
                for (int i = gradoInicio; i <= muestrasTotales; i++)
                {
                    //se recorre el array desde el valor indicado hasta el final del arrayList 

                    //Agrega el valor del otro arrayList
                    mInicioIzquierda.Add(piernaIzquierda[i - 1]); //tama desde el valor que inicia el angulo indicado y llega al final de la circunferencia. 
                    mInicioDerecha.Add(piernaDerecha[i - 1]);
             //       richSectores.AppendText("\n- #" + (i) + "  " + mInicioIzquierda[e]);//para verificar que funciona.
            //        e++;
                }
           //     richSectores.AppendText("**********************SOBRANTES*******************");
                //toma los valores que no se utilizaron(en este caso de 0 hasta el valor anterior a donde inicia el angulo a guardar muestras):
              
                for (int i = 1; i < gradoInicio; i++)
                {
                 //Recorre desde el inicio hasta un valor menos al resultado de la resta que se realizo arriba.
                    mInicioIzquierda.Add(piernaIzquierda[i - 1]);
                    mInicioDerecha.Add(piernaDerecha[i - 1]);
              //      richSectores.AppendText("\n- #" + (i) + "  " + mInicioIzquierda[e]);
              //      e++;
                }

            }



        }


    }
}