using SpreadsheetLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Simulador.Clases
{
    internal class LeeArchivo
    {

        public SLDocument sl; //Guarda la ruta
        private int muestrasTotales = 0; //Numero total de muestras

        //CAMPOS DEL EXCEL
        private ArrayList angulo;
        private ArrayList piernaIzquierda;
        private ArrayList piernaDerecha;
        private ArrayList velocidad;
        private ArrayList piernaCombinada;

        //Para recorrer el archivo
        int iRow = 1;

        public ArrayList Angulo { get => angulo; set => angulo = value; }
        public ArrayList PiernaIzquierda { get => piernaIzquierda; set => piernaIzquierda = value; }
        public ArrayList PiernaDerecha { get => piernaDerecha; set => piernaDerecha = value; }
        public ArrayList Velocidad { get => velocidad; set => velocidad = value; }
        public ArrayList PiernaCombinada { get => piernaCombinada; set => piernaCombinada = value; }
        public int MuestrasTotales { get => muestrasTotales; set => muestrasTotales = value; }



        /// <summary>
        /// LeerArchivo
        /// toma la ruta del archivo y extrae los datos encontrados: angulo, pierna Izquierda, pierna Derecha y velocidad.
        /// </summary>
        /// <param name="sl">Ruta del archivo</param>
        public LeeArchivo( SLDocument sl) { 
        
        this.sl = sl;
        LEER_ARCHIVO(); //se encarga de leer el archivo y sacar los datos

        }   



        /*******METODOS*********/

        public void LEER_ARCHIVO()
        {
            angulo = new ArrayList();
            PiernaIzquierda = new ArrayList();
            PiernaDerecha = new ArrayList();
            PiernaCombinada = new ArrayList();
            velocidad = new ArrayList();

            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                //Se van guardando los datos hasta que el muestras_sobrantes llegue al numero de pruebas que se debe ingresar por sectorCom

                angulo.Add(sl.GetCellValueAsString(iRow, 1));
                PiernaIzquierda.Add(sl.GetCellValueAsDecimal(iRow, 2));
                PiernaDerecha.Add(sl.GetCellValueAsDecimal(iRow, 3));
                PiernaCombinada.Add(sl.GetCellValueAsDecimal(iRow, 2) + sl.GetCellValueAsDecimal(iRow, 3));
                velocidad.Add(sl.GetCellValueAsString(iRow, 4));
                iRow++;
            }
            this.muestrasTotales = angulo.Count;
        }


    }
}
