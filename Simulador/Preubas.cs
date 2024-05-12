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


            // Ejemplo de uso
            ArrayList numeros = new ArrayList() { 1, 2, 3, 4, 5, 6 ,7,8,9,10,11,12,13,14,15,16,17,18};
            int saltos = 5;
            ArrayList nuevoArrayList = ObtenerNuevoArrayList(numeros, saltos);

            // Mostrar el nuevo ArrayList en un RichTextBox
            MostrarEnRichTextBox(nuevoArrayList);
        }


        static ArrayList ObtenerNuevoArrayList(ArrayList numeros, int saltos)
        {
            ArrayList nuevoArrayList = new ArrayList();
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

        public void MostrarEnRichTextBox(ArrayList lista)
        {
            
            // Agregar los elementos de la lista al RichTextBox
            foreach (var item in lista)
            {
                richTextBox1.AppendText(item.ToString() + "\n");
            }

         
        }



    }
}
