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

        public decimal fsMuestreo = decimal.Zero;
        public decimal longitudBiela = decimal.Zero;

        public string rutaArchivo = string.Empty;
        //La ruta obtenida en el Form principal entra aqui
        public CalculosSectores(Form1.Ruta ruta)
        {
            InitializeComponent();

            //toma la ruta
            rutaArchivo = ruta.ruta;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {   //toma los valores de los textView y si no estan vacios llama la funcion promedio para que inicie
                //los calculos.
                fsMuestreo = Convert.ToDecimal(txtMuestreo.Text.ToString());
             //   cadencia = Convert.ToDecimal(editCadencia.Text.ToString());
                longitudBiela = Convert.ToDecimal(txtBiela.Text.ToString());
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
          //  potenciaIdeal(fpromIzq, fpromDere, fPromTOTAL);//toma los datos y saca la potenciaIdeal
        }


        public void potenciaIdeal(decimal fPromIzq, decimal fPromD, decimal fPromTOTAL)
        {
            //Toma el Pi (valor en double) y lo pasa a decimal para poder trabajar con el mas abajo.
            decimal pi = (Convert.ToDecimal(Math.PI));

            //SE TOMAN LOS DATOS Y SE REALIZAN LOS CALCULOS
            //los resultados se muestran en el rich.
            richPotencia.AppendText("\n" + "---- POTENCIA IDEAL ---- ");
            richPotencia.AppendText("\n" + "Potencia pierna izquierda: " + decimal.Round((fPromIzq * fuerzaPico * cadencia * pi * 2 * longitudBiela / 60000), 2));
            richPotencia.AppendText("\n" + "Potencia pierna derecha: " + decimal.Round((fPromD * fuerzaPico * cadencia * pi * 2 * longitudBiela / 60000), 2));
            richPotencia.AppendText("\n" + "Potencia total: " + decimal.Round((fPromTOTAL * fuerzaPico * cadencia * pi * 2 * longitudBiela / 60000), 2));


            decimal balanceIq = decimal.Round(((fPromIzq * 100) / fPromTOTAL), 1);
            decimal balanceDe = decimal.Round(((fPromD * 100) / fPromTOTAL), 1);

            richPotencia.AppendText("\nBalance Izq/dere: " + balanceIq + "/" + balanceDe);

        }


    }
}
