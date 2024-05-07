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
    public partial class prueba : Form
    {
        public prueba()
        {
            InitializeComponent();


        }

        public void button1_Click(object sender, EventArgs e)
        {
            int salta = Convert.ToInt32(salto.Text);

            ArrayList arrayList = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16,17,18 };
         

            ArrayList valoresSaltados = RealizarSaltos(arrayList, salta);

            PrintArrayList(valoresSaltados);
        }



      public  ArrayList RealizarSaltos(ArrayList arrayList, int numeroDeEntrada)
        {
            ArrayList valoresVisitados = new ArrayList();
            int count = 0;

            // 1. Recorrer todo (recorre hasta estar iguales en cantidad)
            while (arrayList.Count >= count)
            {
              
                //2. recorrer el array para tomar los datos
                    
                    for (int i = 1; i <= numeroDeEntrada; i++) //3. recorre la cantidad de veces que se indica de entrada.
                {
                    for(int j = 1; j <= numeroDeEntrada; j++)
                    {
                        if (i % numeroDeEntrada == 0)
                        {
                            // 3. tomar los primeros valores del primer array.
                            valoresVisitados.Add(arrayList[i - 1]);
                        }
                    }
                 
                }

                count++;

            }

            return valoresVisitados;
        }

      public  void PrintArrayList(ArrayList arrayList)
        {
            foreach (int item in arrayList)
            {
                //         Console.Write(item + " ");
                rich.AppendText("\n"+ item);
                int c = item;
            }
           // Console.WriteLine();
        }



        public ArrayList realizarSaltos()
        {
            ArrayList muestrasFS = new ArrayList();

            //AQUI DEBE RECORRER Y GUARDAR LOS VALORES SEGUN LA FRECUENCIA DE MUESTRO.


            return muestrasFS;
        }


    }
}
