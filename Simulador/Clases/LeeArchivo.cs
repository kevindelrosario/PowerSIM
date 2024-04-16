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
        private List <decimal> angulo;
        private List<decimal> piernaIzquierda;
        private List<decimal> piernaDerecha;
        private List<decimal> velocidad;
        private List<decimal> piernaCombinada;

        //Para recorrer el archivo
        int iRow = 1;

        
        public int MuestrasTotales { get => muestrasTotales; set => muestrasTotales = value; }
        public List<decimal> Angulo { get => angulo; set => angulo = value; }
        public List<decimal> PiernaIzquierda { get => piernaIzquierda; set => piernaIzquierda = value; }
        public List<decimal> PiernaDerecha { get => piernaDerecha; set => piernaDerecha = value; }
        public List<decimal> Velocidad { get => velocidad; set => velocidad = value; }
        public List<decimal> PiernaCombinada { get => piernaCombinada; set => piernaCombinada = value; }



        /// <summary>
        /// LeerArchivo
        /// toma la ruta del archivo y extrae los datos encontrados: angulo, pierna Izquierda, pierna Derecha y velocidadG.
        /// </summary>
        /// <param name="sl">Ruta del archivo</param>
        public LeeArchivo( SLDocument sl) {
            angulo = new List<decimal>();
            PiernaIzquierda = new List<decimal>();
            PiernaDerecha = new List<decimal>();
            PiernaCombinada = new List<decimal>();
            Velocidad = new List<decimal>();
            this.sl = sl;
        LEER_ARCHIVO(); //se encarga de leer el archivo y sacar los datos

        }   



        /*******METODOS*********/

        public void LEER_ARCHIVO()
        {
            

            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                //Se van guardando los datos hasta que el muestras_sobrantes llegue al numero de pruebas que se debe ingresar por sectorCom
                decimal Angulo = sl.GetCellValueAsDecimal(iRow, 1);
                decimal Izquierda = sl.GetCellValueAsDecimal(iRow, 2);
                decimal derecha = sl.GetCellValueAsDecimal(iRow, 3);
                decimal velocidad = sl.GetCellValueAsDecimal(iRow, 4);

                angulo.Add(Angulo);
                PiernaIzquierda.Add(Izquierda);
                PiernaDerecha.Add(derecha);
                PiernaCombinada.Add(Izquierda + derecha);
                Velocidad.Add(velocidad);
                iRow++;
            }
            this.muestrasTotales = angulo.Count;
        }


    }
}
