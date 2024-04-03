using System;
using System.Windows.Forms;

namespace Simulador.Clases
{
    internal class Potencia
    {
   
        // forma de calcular la potencia real anterior
        /// <summary>
        /// CALCULAR POTENCIA REAL (con frecuencia de muestro) 
        /// (Calcula la potencia real despues de haber realizado antes el muestreo)...
        /// Formula: (totalFuerza * fuerzaPico * cadencia * (2 * pi) * longitudBiela / 60000) / frecuenciaMuestreo(fs)
        /// </summary>
        /// <param name="totalFuerza">fuerza total que se obtuvo despues del muestreo</param>
        /// <param name="fs">Frecuencia de muestro</param>
        /// <param name="fuerzaPico">Fuerza pico</param>
        /// <param name="cadencia">Cadencia ingresada por pantalla</param>
        /// <param name="longitudBiela">Longitud de biela</param>
        /// <returns>potenciaClase real</returns>
    /*   public decimal calculaPotenciaReal(decimal totalFuerza, int fs, decimal fuerzaPico,decimal cadencia, decimal longitudBiela, decimal factor)
        {
            decimal pi = (Convert.ToDecimal(Math.PI));
            //  return decimal.Round( ((totalFuerza * fuerzaPico * cadencia * (2 * pi) * longitudBiela / 60000) / fs) ,2);
            decimal formula = factor* ((totalFuerza * fuerzaPico * cadencia * 2 * pi * longitudBiela) / 60000);
            return decimal.Round(formula/fs, 2);
        }
    
        */



        /// <summary>
        /// CALCULAR POTENCIA IDEAL 
        /// Formula: totalFuerza * fuerzaPico * cadencia * (2 * pi) * longitudBiela / 60000
        /// </summary>
        /// <param name="totalFuerza">Promedio de fuerza</param>
        /// <param name="fs">Frecuencia de muestro</param>
        /// <param name="fuerzaPico">Fuerza pico</param>
        /// <param name="cadencia">Cadencia ingresada por pantalla</param>
        /// <param name="longitudBiela">Longitud de biela</param>
        /// <returns>potenciaClase real</returns>
        public decimal calculaPotencia(decimal totalFuerza, decimal fuerzaPico, decimal cadencia, decimal longitudBiela)
        {
            decimal pi = (Convert.ToDecimal(Math.PI));
            return decimal.Round((totalFuerza * fuerzaPico * cadencia * 2 * pi * longitudBiela / 60000), 2);
        }



        public decimal balanceDeError(decimal fuerza, decimal fCombinada)
        {
           return decimal.Round(((fuerza * 100) / fCombinada), 1);
        }



        /// <summary>
        /// CALCULAR EL PORCENTAJE ERROR
        /// Recibe el total de la potencia real y el total de la potencia ideal...
        /// Formula 
        /// (%Error = (pReal - pIdeal) / pIdeal)
        /// </summary>
        /// <param name="pReal">Total de potencia real</param>
        /// <param name="pIdeal">Total de potencia ideal</param>
        /// <returns>Porcentaje de error</returns>
        public decimal calcularPorcentajeError(decimal pReal, decimal pIdeal)
        {
            return Decimal.Round(((pReal - pIdeal) / pIdeal) * 100, 2);
        }


    }


}
