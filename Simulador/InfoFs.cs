using Simulador.Clases;
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
    public partial class InfoFs : Form
    {
        List<Datos> info_fs;

        public InfoFs(List<Datos> info_fs_e)
        {
            InitializeComponent();
           info_fs = info_fs_e;
            escribe();
        }

        public void escribe()
        {
            // Agregar los datos al RichTextBox
            foreach (Datos dato in info_fs)
            {
                richTextBox1.AppendText(dato.ToString() + Environment.NewLine);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
