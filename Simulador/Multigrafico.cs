﻿using SpreadsheetLight;
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
    public partial class Multigrafico : Form
    {
        public Multigrafico(Form1.Ruta ruta)
        {
            InitializeComponent();
            chartDerecha.Series["Derecha"].Points.AddXY(0, 0);
            chartIzquierda.Series["Izquierda"].Points.AddXY(0, 0);
            chartVelocidad.Series["Velocidad"].Points.AddXY(0, 0);
            chartCombinacion.Series["Combinacion"].Points.AddXY(0, 0);

            string rutaArchivo = string.Empty;
            rutaArchivo = ruta.ruta;
            limpiaChart();
            derecho(rutaArchivo);
            combinacion(rutaArchivo);
            izquierda(rutaArchivo);
            velocidad(rutaArchivo);

        }

        public void derecho(string rutaArchivo)
        {
            SLDocument sl = new SLDocument(rutaArchivo);
            int iRow = 1;

            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);
                decimal derecha = sl.GetCellValueAsDecimal(iRow, 3);
                chartDerecha.Series["Derecha"].Points.AddXY(angulo, derecha);
                iRow++;

            }
        }

        public void combinacion(string rutaArchivo)
        {
            SLDocument sl = new SLDocument(rutaArchivo);
            int iRow = 1;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);
                chartCombinacion.Series["Combinacion"].Points.AddXY(angulo, sl.GetCellValueAsDecimal(iRow, 2) + sl.GetCellValueAsDecimal(iRow, 3));
                iRow++;

            }
        }

        public void izquierda(string rutaArchivo)
        {
            SLDocument sl = new SLDocument(rutaArchivo);

            int iRow = 1;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);
                decimal izquierda = sl.GetCellValueAsDecimal(iRow, 2);
                chartIzquierda.Series["Izquierda"].Points.AddXY(angulo, izquierda);
                iRow++;

            }
        }

        public void velocidad(string rutaArchivo)
        {
            SLDocument sl = new SLDocument(rutaArchivo);

            int iRow = 1;
            while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
            {
                decimal angulo = sl.GetCellValueAsDecimal(iRow, 1);
                decimal velocidad = sl.GetCellValueAsDecimal(iRow, 4);
                chartVelocidad.Series["Velocidad"].Points.AddXY(angulo, velocidad);
                iRow++;

            }
        }
        public void limpiaChart()
        {
            chartIzquierda.Series["Izquierda"].Points.Clear();
            chartDerecha.Series["Derecha"].Points.Clear();
            chartVelocidad.Series["Velocidad"].Points.Clear();
            chartCombinacion.Series["Combinacion"].Points.Clear();
        }

    }
}
