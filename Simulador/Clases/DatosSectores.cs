using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador.Clases
{
    public class DatosSectores
    {
        public decimal errorPotencia { get; set; }
        public int sector { get; set; }
        //Agrega el dato
        public DatosSectores(int sector, decimal errorPotencia)
        {
            this.sector = sector;
            this.errorPotencia = errorPotencia;
        }

        //Escribe
        public override string ToString()
        {
            return $"# Sectores: {sector}\n Error de potencia: {errorPotencia}\n";
        }
    }

    
}
