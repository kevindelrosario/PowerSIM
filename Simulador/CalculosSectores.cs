using Simulador.Clases;
using SpreadsheetLight;
using System;
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
            //toma los valores de los textView y si no estan vacios llama la funcion promedio para que inicie
            //los calculos.

            if (validarCamposCalculos())
            {
                borrarMensajeErrorCalculos();
                tomaDatos();
                //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS
                //los resultados se muestran en el rich.
                calculaFrecuenciaMuestreo(Convert.ToInt32(editMuestreo.Text.ToString()));
                potenciaReal(totalPiernaIzq_muestreo, totalPiernaDer_muestreo, totalCombinada_muestreo, Convert.ToInt32(editMuestreo.Text.ToString()));

            }



        }


        public void potenciaReal(decimal fIzqui, decimal fDere, decimal fCombinada, int fsMuestreo)
        {
            richReal.Clear();

            //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS
            //los resultados se muestran en el rich.

            richReal.AppendText("\n Muestras totales: " + nMuestrasTotales);
            richReal.AppendText("\n Numero de muestras por pedalada(Sp): " + muestrasPorPedaladas); // La frecuencia con la que se tomaran las pruebas

            richReal.AppendText("\n" + "---- POTENCIA REAL ---- ");
            richReal.AppendText("\n" + " potenciaClase pierna izquierda: " + potenciaClase.calculaPotenciaReal(fIzqui, fsMuestreo, fuerzaPico, cadencia, longitudBiela));
            richReal.AppendText("\n" + " potenciaClase pierna derecha: " + potenciaClase.calculaPotenciaReal(fDere, fsMuestreo, fuerzaPico, cadencia, longitudBiela));
            richReal.AppendText("\n" + " potenciaClase total: " + potenciaClase.calculaPotenciaReal(fCombinada, fsMuestreo, fuerzaPico, cadencia, longitudBiela));



            decimal balanceIq = potenciaClase.calcularPorcentajeError(fIzqui, fCombinada);
            decimal balanceDe = potenciaClase.calcularPorcentajeError(fDere, fCombinada);

            richReal.AppendText("\n\n Balance Izq/dere: " + balanceIq + "/" + balanceDe);

        }


        public void calculaFrecuenciaMuestreo(int fs)
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



        /**********Toma los datos*************/
        public void tomaDatos()
        {
            int fsMuestreo = Convert.ToInt32(editMuestreo.Text.ToString());
            fuerzaPico = Convert.ToDecimal(editFuerzaPico.Text.ToString());
            cadencia = Convert.ToDecimal(editCadencia.Text.ToString());
            longitudBiela = Convert.ToDecimal(editLongBiela.Text.ToString());
        }


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

        private void btCalcularConfi_Click(object sender, EventArgs e)
        {
            // int numSectores = Convert.ToInt32(editNumeroSectores.Text);
            borrarMensajeErrorCalculos();

            if (verificarCampoConf() && divisor360())
            {
                MessageBox.Show("valido.");
            }
            else
            {
                MessageBox.Show("no valido");
            }
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




    }
}