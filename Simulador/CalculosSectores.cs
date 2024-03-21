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
    public partial class CalculosSectores : Form
    {
        //ojo aqui
     
        public decimal fsMuestreo = decimal.Zero;
        public decimal fuerzaPico = decimal.Zero;
        public decimal cadencia = decimal.Zero;
        public decimal longitudBiela = decimal.Zero;

        public string rutaArchivo = string.Empty;
        //La ruta obtenida en el Form principal entra aqui


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



        /************CLASES***************/
        //potencia
        Potencia potenciaClase = new Potencia();


        public CalculosSectores(Inicio.Ruta ruta)
        {
            InitializeComponent();

            //toma la ruta
            rutaArchivo = ruta.ruta;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //toma los valores de los textView y si no estan vacios llama la funcion promedioPotenciaIdeal para que inicie
            //los calculos.

            if (validarCamposCalculos())
            {
                borrarMensajeErrorCalculos();
                tomaDatos();
                //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS


                //POTENCIA IDEAL
                promedioPotenciaIdeal();
                //los resultados de la POTENCIA IDEAL se muestran en el rich.
              

                //los resultados se muestran en el rich.
                calculaFuerzasPromediadas(Convert.ToInt32(editMuestreo.Text.ToString()));
                potenciaReal(totalPiernaIzq_muestreo, totalPiernaDer_muestreo, totalCombinada_muestreo, Convert.ToInt32(editMuestreo.Text.ToString()));
        
            }



        }







        private void promedioPotenciaIdeal()
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
                contador++; // Toma la cantidad de valores que son para sacar el promedioPotenciaIdeal...
                Totalderecha += derecha; //Va sumando los valores encontrados
                TotalIzquierda += izquierda;
            }

            decimal fpromIzq = decimal.Round((TotalIzquierda / contador), 2);//redondea los datos y lo guardan en la variable para enviarlos
            decimal fpromDere = decimal.Round((Totalderecha / contador), 2);
            decimal fPromTOTAL = fpromIzq + fpromDere;
            potenciaIdeal(fpromIzq, fpromDere, fPromTOTAL);//toma los datos y saca la potenciaReal
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

            pTotal_pIzquierda_ideal = potenciaClase.calculaPotenciaIdeal(fPromIzq, fuerzaPico, cadencia, longitudBiela);
            pTotal_pDercha_ideal = potenciaClase.calculaPotenciaIdeal(fPromD, fuerzaPico, cadencia, longitudBiela);
            pTotal_pCombinada_ideal = potenciaClase.calculaPotenciaIdeal(fPromCombinada, fuerzaPico, cadencia, longitudBiela);
            //balance
            balanceIq_ideal = potenciaClase.calcularPorcentajeError(fPromIzq, fPromCombinada);
            balanceDe_ideal = potenciaClase.calcularPorcentajeError(fPromD, fPromCombinada);

            //variable para poder tomar los datos de cada variable por separado y no tener que crear un return ni funciones independientes
            totalPiernaIzq_ideal_pError = pTotal_pIzquierda_ideal;
            totalPiernaD_ideal_pError = pTotal_pDercha_ideal;
            totalCombinada_ideal_pError = pTotal_pCombinada_ideal;

            
           // richIdeal.AppendText("\n" + "---- POTENCIA IDEAL ---- ");
            richIdeal.AppendText("\n" + " potenciaClase pierna izquierda: " + pTotal_pIzquierda_ideal);
            richIdeal.AppendText("\n" + " potenciaClase pierna derecha: " + pTotal_pDercha_ideal);
            richIdeal.AppendText("\n" + " potenciaClase combinada: " + pTotal_pCombinada_ideal);


            // Se muestra el balance de error IDEAL
            richIdeal.AppendText("\n\n Balance Izq/dere: " + balanceIq_ideal + "/" + balanceDe_ideal);
        }


        public void potenciaReal(decimal fIzqui, decimal fDere, decimal fCombinada, int fsMuestreo)
        {
            richReal.Clear();

            //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS
            //los resultados se muestran en el rich.

            richMuestraReal.AppendText("\n Muestras totales: " + nMuestrasTotales);
            richMuestraReal.AppendText("\n Numero de muestras por pedalada(Sp): " + muestrasPorPedaladas); // La frecuencia con la que se tomaran las pruebas
/***********OJO AQUI*******************/
          //  richReal.AppendText("\n" + "---- POTENCIA REAL ---- ");
          //  richReal.AppendText("\n" + " potenciaClase pierna izquierda: " + potenciaClase.calculaPotenciaReal(fIzqui, fsMuestreo, fuerzaPico, cadencia, longitudBiela));
         //   richReal.AppendText("\n" + " potenciaClase pierna derecha: " + potenciaClase.calculaPotenciaReal(fDere, fsMuestreo, fuerzaPico, cadencia, longitudBiela));
         //   richReal.AppendText("\n" + " potenciaClase total: " + potenciaClase.calculaPotenciaReal(fCombinada, fsMuestreo, fuerzaPico, cadencia, longitudBiela));



            decimal balanceIq = potenciaClase.calcularPorcentajeError(fIzqui, fCombinada);
            decimal balanceDe = potenciaClase.calcularPorcentajeError(fDere, fCombinada);

            richReal.AppendText("\n\n Balance Izq/dere: " + balanceIq + "/" + balanceDe);

        }





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
            {
                int iRow = 1;
                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    iRow++;
                }
                numMuestras = iRow - 1;// -1 parra corregir lo mencionado anteriormente...

                Sp = (numMuestras / fs) * (60 / Convert.ToInt32(editCadencia.Text.ToString())); //Indicamos cada cuanto debe realizar el salto para tomar el valor siguiente.

                //Info del archivo y la frecuencia de muestreo

                //Esta informacion solo se mostrara al dar clic en el boton calcular, de lo contrario es irrelevante.
                nMuestrasTotales = numMuestras;
                muestrasPorPedaladas = Sp;


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

                totalPiernaIzq_muestreo = totalIzquierda; //valores para luego utilizarlos en la funcion potenciaReal()
                totalPiernaDer_muestreo = totalDerecha;
                totalCombinada_muestreo = totalIzquierda + totalDerecha;

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

            if (verificarCampoConf() && divisor360())
            {
                MessageBox.Show("valido.");
                //tomaDatos(); //toma los datos con los que se trabajo en la potencia real.

                //tomamos los datos de configuracion:
                int numSectores = Convert.ToInt32(editNumeroSectores.Text); 
                int anguloInicio = Convert.ToInt32(editAnguloInicio.Text);
               
                //Comprobamos cuantas pruebas debe haber por sectores.
                MessageBox.Show("resultado de la division: " + dividirMuestras(numSectores));

                Sectores(dividirMuestras(numSectores), anguloInicio); //Entra: cantidad de pruebas por sectores y el sectore de inicio
            }
            else
            {
                MessageBox.Show("no valido");
            }
        }

        /// <summary>
        /// SECTORES
        /// Se encarga de tomar el numero de muestras por sector y guardar los datos segun el numero de sectores que se indiquen.
        /// </summary>
        /// <returns></returns>
        public void Sectores(int nMuestras, int angInicio)
        {
            ArrayList sector = new ArrayList();
            int sumaSectores = 0;

            //datos de prueba
           // sector.Add(1);
         //   sector.Add(20);
         //   sector.Add(80);
         //   sector.Add(500);
         //   sector.Add(500);
            //suma de todo: 1101

            // Indica el numero de pruebas que se debe tomar por sectores
            SLDocument sl = new SLDocument(rutaArchivo);

            int cont = 0; //para reinicial el conteo de las pruebas
                          //variables para potencia Ideal
            decimal izquierdaIdeal = 0;
            decimal derechaIdeal = 0;

            int iRow = 1;

            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                cont++;

                //Se van guardando los datos hasta que el contador llegue al numero de pruebas que se debe ingresar por sector
                if(cont < nMuestras)
                {
                    izquierdaIdeal += sl.GetCellValueAsDecimal(iRow, 2);
                    derechaIdeal += sl.GetCellValueAsDecimal(iRow, 3);

                }
                else
                {

                    //Se saca el promedio al sumar todas y dividir entre la cantidad total
                    decimal combinada = decimal.Round((izquierdaIdeal+derechaIdeal)/nMuestras,2); 
                     sector.Add( combinada);
                 //   MessageBox.Show("\n-Num. Sector: "+ sector.Count +"\n-Potencia: "+combinada);
                    richSectores.AppendText("-Num.Sector: "+ sector.Count +"\n - Potencia: "+combinada);
                    cont = 0;
                }
               
                iRow++;
            }

            

          


            //Segun el angulo de inicio que se indique se empezaran a sumar los valores que haya dentro del arrayList.
            for (int i = angInicio; i <= sector.Count; i++) //i = angulo - 1 poque asi los angulos no empizan desde el cero.
            {
                sumaSectores += Convert.ToInt32(sector[i-1]); //guarda la suma de sectores segun se indica con el angulo de inicio
               
            }

            MessageBox.Show("#sectores: "+sector.Count+"\nResultado de suma de sectores: "+sumaSectores);
            //  return sector;
        }


        public bool verificarCampoConf()
        {
            bool ok = true;
            
          

            if (editNumeroSectores.Text == "")
            {
                ok = false;
                errorConfi.SetError(editNumeroSectores, "Indicar numero de sectores");
            }
            else
            {
                if (Convert.ToInt32(editNumeroSectores.Text) % 2 != 0)
                {
                    ok = false;
                    errorConfi.SetError(editNumeroSectores, "El numero de sector debe ser par.");
                }
            }

            if (editAnguloInicio.Text == "")
            {
                ok = false;
                errorConfi.SetError(editAnguloInicio, "Indicar angulo de inicio");
            }

            return ok;

        }

        public bool divisor360()
        {
            bool ok = true;


            //numero % 360 = num
            //if (num * numero = 360) = divisor 

            int numero = Convert.ToInt32(editNumeroSectores.Text);


            int divisor =  360/ numero;

            if (divisor * numero != 360)
            {
                ok = false;
                errorConfi.SetError(editNumeroSectores, "El numero de sector debe ser divisor de 360.");
            }
            return ok;

        }

        /// <summary>
        /// DIVIDIR MUESTRAS
        /// Se encarga de indicar el # de muestras con la que se debe trabajarse en cada sector.
        /// </summary>
        /// <param name="sectores">sectores en los que se debe dividir la circunferencia</param>
        /// <returns>Total de pruebas por sector</returns>
        public int dividirMuestras(int sectores)
        {
            /*aqui tomamos el numero de sectores que nos indique y dividimos las pruebas en ese numero, 
            luego se debe trabajar con ellas por separado y el resultado de estas se ingresara en un array
            para luego segun lo que se indique por pantalla se sumen los sectores que quieran, esto ya 
            trabajando con los valores en las posiciones que tenga el array. el array se debe incrementar segun
            sea necesario.

            De primeras usaria un arrayList para que se agregue todo lo necesario.
            */
            SLDocument sl = new SLDocument(rutaArchivo);

            int iRow = 1;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                iRow++;
            }

            int numMuestras = iRow - 1;

            return  numMuestras / sectores;

        }

        /**********Toma los datos*************/
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

        /*****VALIDAR CAMPOS*********/
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
            if (editMuestreo.Text == "" || Convert.ToInt32(editMuestreo.Text.ToString()) < 3)
            {
                ok = false;
                errorCampoVacio.SetError(editMuestreo, "El valor fs debe ser mayor a 2.");
            }

            return ok;
        }


        private void borrarMensajeErrorCalculos()
        {
            errorCampoVacio.SetError(editFuerzaPico, "");
            errorCampoVacio.SetError(editLongBiela, "");
            errorCampoVacio.SetError(editCadencia, "");
            errorCampoVacio.SetError(editMuestreo, "");

            //error campo configuracion
            errorConfi.SetError(editNumeroSectores, "");
            errorConfi.SetError(editAnguloInicio, "");
        }
    }
}