using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador.Clases
{
    public class Datos
    {
        public int fs { get; set; }
        public decimal totalCombReal { get; set; }
        public decimal totalCombIdeal { get; set; }

        public decimal errorPotencia { get; set; }

        // Constructor para inicializar los valores
        public Datos(int fs, decimal combReal, decimal combIdeal, decimal errorPotencia)
        {
            this.fs = fs;
            totalCombReal = combReal;
            totalCombIdeal = combIdeal;
            this.errorPotencia = errorPotencia;
        }
        // Método para convertir los datos a una cadena de texto
        public override string ToString()
        {
            return $"Fs: {fs}\n Total Combinada Ideal: {totalCombIdeal} \n Total Combinada Real: {totalCombReal} " +
                $"\nError de potencia: {errorPotencia}\n";
        }
    }
}
