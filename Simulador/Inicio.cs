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

namespace Simulador
{


    public partial class Inicio : Form
    {

       
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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "|*.xlsx", //Filtro para que solo lea archivos .xlsx (Los de tipo csv dan error, quizas por la libreria)
                CheckPathExists = true,
                CheckFileExists = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaArchivo = openFileDialog.FileName;
                txtRutaArchivo1.Text = rutaArchivo; // Obtiene la ruta del archivo con la que vamos a trabajar
             
            
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


   

        /*****LLAMADAS A LAS OTRAS VENTANAS******/
        private void btUnico_Click(object sender, EventArgs e)
        {
            borrarMensajeError();
            if (validarCampos())
            {
                Ruta ruta;
                ruta.ruta = txtRutaArchivo1.Text; //toma el valor que contiene el txt txtRutaArchivo1
              
                    //Si ya contiene la ruta de un archivo podra entrar al Form y ver los graficos
                    openChildForm(new GraficaUnica(ruta));
             
            }
           
           
             
        }

        private void btMultigrafico_Click(object sender, EventArgs e)
        {
            borrarMensajeError();
            if (validarCampos())
            {
                Ruta ruta;
                ruta.ruta = txtRutaArchivo1.Text;
                openChildForm(new Multigrafico(ruta));
            }
        }

        private void btCalculo_Click(object sender, EventArgs e)
        {
            borrarMensajeError();
            if (validarCampos())
            {
                Ruta ruta;
                ruta.ruta = txtRutaArchivo1.Text;
                openChildForm(new CalculosFs(ruta));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            borrarMensajeError();
            if (validarCampos())
            {
                Ruta ruta;
                ruta.ruta = txtRutaArchivo1.Text;
                openChildForm(new CalculosSectores(ruta));
            }
        }

        /******************************Funcion para el cambio de pantalla de los distintos botones************************************/
        private Form activeForm = null;
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
        private bool validarCampos()
        {
            bool ok = true;

            if(txtRutaArchivo1.Text == "")
            {
                ok = false;
                errorArchivoVacio.SetError(txtRutaArchivo1, "Ingresa ruta del archivo");
            }

            return ok;
        }
        /*****************LIMPIAR CAMPOS***************************/
        
        private void borrarMensajeError()
        {
            errorArchivoVacio.SetError(txtRutaArchivo1,"");
        }

    }
}
