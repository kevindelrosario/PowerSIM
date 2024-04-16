using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SpreadsheetLight;
using System.Windows;
using DocumentFormat.OpenXml.Bibliography;
using static Simulador.Inicio;
using Simulador.Clases;

namespace Simulador
{


    public partial class Inicio : Form
    {

        //DATOS DE LA CLASE LeeArchivo:
        //Aqui se rellenaran los datos que luego se enviaran a las demas pestañas, esto para corregir que se congele por un instante el software.
        LeeArchivo leerArchivo;
        List<decimal> angulo;
        List<decimal> piernaDerecha;
        List<decimal> piernaIzquierda;
        List<decimal> piernaCombinada;
        List<decimal> velocidad;
        int muestrasTotales = 0;

        // ruta 
        SLDocument sl;


        public Inicio()
        {
            InitializeComponent();
           

        }

        //Boton para buscar la ruta del archivo...
   
      

        private void buscarArchivo_Click(object sender, EventArgs e)
        {
            borrarMensajeError();
            string rutaArchivo = string.Empty;
            //Abre una ventana de Dialogo para buscar la ruta del archivo
            OpenFileDialog openFileDialog = new OpenFileDialog //Abre una pestaña de dialogo donde se debe buscar la ruta del archivo a leer.
            {
                Filter = "|*.xlsx", //Filtro para que solo lea archivos .xlsx (Los de tipo csv dan error, quizas por la libreria)
                CheckPathExists = true, //verifica que exista.
                CheckFileExists = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK) //Al dar en OK tomamos esa ruta que debe haber seleccionado el usuario.
            {
                rutaArchivo = openFileDialog.FileName;
                editRutaArchivo1.Text = rutaArchivo; // Igualado al editRutaArchibo para que se muestre la ruta por pantalla.


                //TOMA TODA LA INFORMACION PARA PODER ENVIARLA A TODAS LAS PESTAÑAS...
                sl = new SLDocument(rutaArchivo);
                leerArchivo = new LeeArchivo(sl);
                extraerInformacion();//rellenamos


            }
        }

        //constructor utilizado para tomar la ruta que se enviara a cada clase....
        public struct Ruta
        {
            public string ruta; 
        }



        /**************************************************************************************************************************/
        /***************************************FUNCIONES DE DIBUJADO Y LECTURA****************************************************/
        /**************************************************************************************************************************/

        public void extraerInformacion()
        {
            //rellena los arrayList con cada campo
            angulo = leerArchivo.Angulo;
            piernaIzquierda = leerArchivo.PiernaIzquierda;
            piernaDerecha = leerArchivo.PiernaDerecha;
            piernaCombinada = leerArchivo.PiernaCombinada;
            velocidad = leerArchivo.Velocidad;

            //tomamos el total de las muestras
            muestrasTotales = leerArchivo.MuestrasTotales;
        }


        /*****LLAMADAS A LAS OTRAS VENTANAS******/
        private void btUnico_Click(object sender, EventArgs e)
        {
            borrarMensajeError();

           
            if (validarCampos())
            {
                Ruta ruta;
                ruta.ruta = editRutaArchivo1.Text; //toma el valor que contiene el txt txtRutaArchivo1
              
                    //Si ya contiene la ruta de un archivo podra entrar al Form y ver los graficos
                    openChildForm(new GraficaUnica(ruta, angulo, piernaDerecha, piernaIzquierda, piernaCombinada, velocidad));

            }
           
           
           
             
        }

        private void btMultigrafico_Click(object sender, EventArgs e)
        {
            borrarMensajeError();
            if (validarCampos())
            {
                Ruta ruta;
                ruta.ruta = editRutaArchivo1.Text;
                openChildForm(new Multigrafico(ruta,angulo, piernaDerecha,piernaIzquierda,piernaCombinada,velocidad));
            }
        }

        private void btCalculo_Click(object sender, EventArgs e)
        {
            borrarMensajeError();
            if (validarCampos())
            {
                Ruta ruta;
                ruta.ruta = editRutaArchivo1.Text;
                openChildForm(new CalculosFs(ruta));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            borrarMensajeError();
            if (validarCampos()) //verifica que el archivo este seleccionado para poder trabajar con el en las demas pestañas.
            {
                Ruta ruta;
                ruta.ruta = editRutaArchivo1.Text; //toma la ruta del archivo seleccionado.
                openChildForm(new CalculosSectores(ruta)); // abre la nueva pestaña y le ingresa esa ruta obtenida.
            }
        }

        /******************************Funcion para el cambio de pantalla de los distintos botones************************************/
        private Form activeForm = null;
        /// <summary>
        /// OpenChildForm
        /// Se encargar de abrir y cerrar los paneles que aparecen en la pestaña principal sin "cambiar" de esta pestaña, dejando siempre a mano el 
        /// menu del inicio.
        /// </summary>
        /// <param name="childForm"></param>
        private void openChildForm(Form childForm)//toma el form indicado y lo muestra en el panel central...
        {
            if (activeForm != null) //cierra el ultimo panel que se haya abierto y muestra el
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        /****************************************************/
        /*************VERIFICAR CAMPOS VACIOS****************/
        /****************************************************/

        /// <summary>
        /// ValidarCampos
        /// Comprobamos que el campo ruta no este vacio
        /// </summary>
        /// <returns></returns>
        private bool validarCampos()
        {
            bool ok = true;

            if(editRutaArchivo1.Text == "")
            {
                ok = false;
                MessageBox.Show("Es necesario seleccionar el archivo EXCEL.");
                errorArchivoVacio.SetError(editRutaArchivo1, "Ingresa ruta del archivo");
            }

            return ok;
        }
        /*****************LIMPIAR CAMPOS***************************/
        /// <summary>
        /// borrarMensajeError
        /// Si los campos se rellenan correctamente despues de aparecer el error esta funcion borra esa alerta.
        /// </summary>
        private void borrarMensajeError()
        {
            errorArchivoVacio.SetError(editRutaArchivo1,"");
        }

    }
}
