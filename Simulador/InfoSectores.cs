using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Simulador.Clases;
using System;
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
    public partial class InfoSectores : Form
    {
        List<DatosSectores> info_sectores;
        public InfoSectores(List<DatosSectores> info_sector)
        {
            InitializeComponent();
            info_sectores = info_sector;
            escribe();
        }

        public void escribe()
        {
            // Agregar los datos al RichTextBox
            foreach (DatosSectores info in info_sectores)
            {
                richTextBox1.AppendText(info.ToString() + Environment.NewLine);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
