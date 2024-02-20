﻿using System;
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
    public partial class CalculosSectores : Form
    {
        public string rutaArchivo = string.Empty;
        //La ruta obtenida en el Form principal entra aqui
        public CalculosSectores(Form1.Ruta ruta)
        {
            InitializeComponent();

            //toma la ruta
            rutaArchivo = ruta.ruta;
        }
    }
}
