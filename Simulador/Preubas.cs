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
    public partial class Preubas : Form
    {
        public Preubas()
        {
            InitializeComponent();

        }


        static List<decimal> ObtenerNuevoArrayList(List<decimal> numeros, int saltos)
        {
            List<decimal> nuevoArrayList = new List<decimal>();
      //      ArrayList nuevoArrayList = new ArrayList();
            int indiceInicial = -1;
            int contador = 0;
            int contador2 = 0;


            while (contador < saltos)
            {
                for (int i = indiceInicial ; i < numeros.Count ; i++)
                {
                    if ( contador== saltos)
                    {
                        nuevoArrayList.Add(numeros[i]);
                        contador = 0;
                    }
                    contador++;
                }
                contador2++;
            }

            return nuevoArrayList;
        }

        public void MostrarEnRichTextBox(List<decimal> lista, int saltos)
        {
            richTextBox1.Clear();
            decimal promedio = 0;
            // Agregar los elementos de la lista al RichTextBox
            foreach (var item in lista)
            {
                promedio += Convert.ToDecimal(item);
                richTextBox1.AppendText(item.ToString() + "\n");

            }
            promedio = decimal.Round(promedio / saltos, 2);
            //richTextBox1.AppendText("Promedio: \n" + promedio);
            MessageBox.Show("promedio: " + promedio);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int saltos = Convert.ToInt32(textBox1.Text);
            /* intento 1
            // Ejemplo de uso
           List<decimal> numeros = new List<decimal> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            int saltos = Convert.ToInt32(textBox1.Text);

           List <decimal> nuevoArrayList = ObtenerNuevoArrayList(numeros, saltos);
            // Mostrar el nuevo ArrayList en un RichTextBox
            MostrarEnRichTextBox(nuevoArrayList, saltos);*/



            // Ejemplo de uso
            List<int> inputList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };

            // int saltos = 2;

            List<int> result = CircularRead(inputList, saltos);

            richTextBox1.AppendText("\n\nInput List: " + string.Join(", ", inputList));
             richTextBox1.AppendText("\nResult List: " + string.Join(", ", result));
            richTextBox1.AppendText("\ntotal: " + result.Count);
        }


        public static List<int> CircularRead(List<int> inputList, int saltos)
        {
            // Nuevo List para almacenar los resultados
            List<int> resultList = new List<int>();
           
            int index = 0;
            int cont = 0;
            // Recorremos el List de entrada en un bucle circular
            while(cont < saltos)
            {
                for (int i = -1; i < inputList.Count; i++)
                {
                    if (index == saltos)
                    {
                        resultList.Add(inputList[i]);
                        index = 0;
                    }
                    index++;
                
                }
                cont++;
            }
           
            return resultList;
        }

    }
}
