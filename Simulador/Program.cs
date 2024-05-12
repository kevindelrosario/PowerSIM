using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulador
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
           //  Application.Run(new Inicio());
           Application.Run(new Preubas());
=======
             Application.Run(new Inicio());
            // Application.Run(new prueba());
>>>>>>> f0b69c1f810f5a6ec8ec2a47735ec431931d7cca
        }
    }
}
