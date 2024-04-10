namespace Simulador
{
    partial class CalculosSectores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btCalcularConfi = new System.Windows.Forms.Button();
            this.editAnguloInicio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.editNumeroSectores = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.editCadencia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.editFuerzaPico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btCalcular = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editMuestreo = new System.Windows.Forms.TextBox();
            this.editLongBiela = new System.Windows.Forms.TextBox();
            this.richReal = new System.Windows.Forms.RichTextBox();
            this.errorCampoVacio = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorConfi = new System.Windows.Forms.ErrorProvider(this.components);
            this.richIdeal = new System.Windows.Forms.RichTextBox();
            this.richSectores = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.richMuestraReal = new System.Windows.Forms.RichTextBox();
            this.chartSectorizacion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btGraficarSectorizacion = new System.Windows.Forms.Button();
            this.editInicioSectorG = new System.Windows.Forms.TextBox();
            this.editMaximoSectorG = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorCampoVacio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorConfi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSectorizacion)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.btCalcularConfi);
            this.panel1.Controls.Add(this.editAnguloInicio);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.editNumeroSectores);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.editCadencia);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.editFuerzaPico);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btCalcular);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.editMuestreo);
            this.panel1.Controls.Add(this.editLongBiela);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 896);
            this.panel1.TabIndex = 0;
            // 
            // btCalcularConfi
            // 
            this.btCalcularConfi.BackColor = System.Drawing.Color.Gold;
            this.btCalcularConfi.ForeColor = System.Drawing.Color.Black;
            this.btCalcularConfi.Location = new System.Drawing.Point(92, 641);
            this.btCalcularConfi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCalcularConfi.Name = "btCalcularConfi";
            this.btCalcularConfi.Size = new System.Drawing.Size(84, 30);
            this.btCalcularConfi.TabIndex = 15;
            this.btCalcularConfi.Text = "Sectorizar";
            this.btCalcularConfi.UseVisualStyleBackColor = false;
            this.btCalcularConfi.Click += new System.EventHandler(this.btCalcularConfi_Click);
            // 
            // editAnguloInicio
            // 
            this.editAnguloInicio.Location = new System.Drawing.Point(43, 604);
            this.editAnguloInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editAnguloInicio.Name = "editAnguloInicio";
            this.editAnguloInicio.Size = new System.Drawing.Size(187, 22);
            this.editAnguloInicio.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(76, 561);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 32);
            this.label8.TabIndex = 13;
            this.label8.Text = "Angulo de inicio \r\nde sectorización:";
            // 
            // editNumeroSectores
            // 
            this.editNumeroSectores.Location = new System.Drawing.Point(43, 516);
            this.editNumeroSectores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editNumeroSectores.Name = "editNumeroSectores";
            this.editNumeroSectores.Size = new System.Drawing.Size(187, 22);
            this.editNumeroSectores.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(65, 494);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Numero de sectores:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gold;
            this.label6.Location = new System.Drawing.Point(12, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(244, 44);
            this.label6.TabIndex = 10;
            this.label6.Text = "Configuración de sectores\r\n de cálculo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(12, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "POTENCIA REAL / IDEAL";
            // 
            // editCadencia
            // 
            this.editCadencia.Location = new System.Drawing.Point(43, 222);
            this.editCadencia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editCadencia.Name = "editCadencia";
            this.editCadencia.Size = new System.Drawing.Size(187, 22);
            this.editCadencia.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(96, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cadencia:";
            // 
            // editFuerzaPico
            // 
            this.editFuerzaPico.Location = new System.Drawing.Point(43, 97);
            this.editFuerzaPico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editFuerzaPico.Name = "editFuerzaPico";
            this.editFuerzaPico.Size = new System.Drawing.Size(187, 22);
            this.editFuerzaPico.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(89, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fuerza pico:";
            // 
            // btCalcular
            // 
            this.btCalcular.BackColor = System.Drawing.Color.Gold;
            this.btCalcular.ForeColor = System.Drawing.Color.Black;
            this.btCalcular.Location = new System.Drawing.Point(99, 327);
            this.btCalcular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCalcular.Name = "btCalcular";
            this.btCalcular.Size = new System.Drawing.Size(84, 30);
            this.btCalcular.TabIndex = 4;
            this.btCalcular.Text = "Calcular";
            this.btCalcular.UseVisualStyleBackColor = false;
            this.btCalcular.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(59, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Frecuencia de Muestreo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(76, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Longitud de biela:";
            // 
            // editMuestreo
            // 
            this.editMuestreo.Location = new System.Drawing.Point(43, 288);
            this.editMuestreo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editMuestreo.Name = "editMuestreo";
            this.editMuestreo.Size = new System.Drawing.Size(187, 22);
            this.editMuestreo.TabIndex = 1;
            // 
            // editLongBiela
            // 
            this.editLongBiela.Location = new System.Drawing.Point(43, 164);
            this.editLongBiela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editLongBiela.Name = "editLongBiela";
            this.editLongBiela.Size = new System.Drawing.Size(187, 22);
            this.editLongBiela.TabIndex = 0;
            // 
            // richReal
            // 
            this.richReal.Location = new System.Drawing.Point(332, 330);
            this.richReal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richReal.Name = "richReal";
            this.richReal.Size = new System.Drawing.Size(328, 142);
            this.richReal.TabIndex = 1;
            this.richReal.Text = "";
            // 
            // errorCampoVacio
            // 
            this.errorCampoVacio.ContainerControl = this;
            // 
            // errorConfi
            // 
            this.errorConfi.ContainerControl = this;
            // 
            // richIdeal
            // 
            this.richIdeal.Location = new System.Drawing.Point(332, 71);
            this.richIdeal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richIdeal.Name = "richIdeal";
            this.richIdeal.Size = new System.Drawing.Size(328, 148);
            this.richIdeal.TabIndex = 2;
            this.richIdeal.Text = "";
            // 
            // richSectores
            // 
            this.richSectores.Location = new System.Drawing.Point(317, 540);
            this.richSectores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richSectores.Name = "richSectores";
            this.richSectores.Size = new System.Drawing.Size(368, 333);
            this.richSectores.TabIndex = 3;
            this.richSectores.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gold;
            this.label9.Location = new System.Drawing.Point(467, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 18);
            this.label9.TabIndex = 4;
            this.label9.Text = "IDEAL:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Gold;
            this.label10.Location = new System.Drawing.Point(472, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 23);
            this.label10.TabIndex = 5;
            this.label10.Text = "REAL:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Gold;
            this.label11.Location = new System.Drawing.Point(427, 502);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 36);
            this.label11.TabIndex = 6;
            this.label11.Text = "Por configuración \r\nde sectores:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // richMuestraReal
            // 
            this.richMuestraReal.Location = new System.Drawing.Point(332, 262);
            this.richMuestraReal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richMuestraReal.Name = "richMuestraReal";
            this.richMuestraReal.Size = new System.Drawing.Size(328, 64);
            this.richMuestraReal.TabIndex = 7;
            this.richMuestraReal.Text = "";
            // 
            // chartSectorizacion
            // 
            this.chartSectorizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartSectorizacion.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSectorizacion.Legends.Add(legend1);
            this.chartSectorizacion.Location = new System.Drawing.Point(14, 29);
            this.chartSectorizacion.Name = "chartSectorizacion";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series1.LabelBorderWidth = 2;
            series1.Legend = "Legend1";
            series1.Name = "sectores";
            this.chartSectorizacion.Series.Add(series1);
            this.chartSectorizacion.Size = new System.Drawing.Size(854, 717);
            this.chartSectorizacion.TabIndex = 8;
            this.chartSectorizacion.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btGraficarSectorizacion);
            this.panel2.Controls.Add(this.editInicioSectorG);
            this.panel2.Controls.Add(this.editMaximoSectorG);
            this.panel2.Controls.Add(this.chartSectorizacion);
            this.panel2.Location = new System.Drawing.Point(691, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(880, 896);
            this.panel2.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(48, 829);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 16);
            this.label13.TabIndex = 18;
            this.label13.Text = "Sector inicial:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(48, 764);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 32);
            this.label12.TabIndex = 17;
            this.label12.Text = "Numero de sectores\r\nmaximo:";
            // 
            // btGraficarSectorizacion
            // 
            this.btGraficarSectorizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btGraficarSectorizacion.BackColor = System.Drawing.Color.Gold;
            this.btGraficarSectorizacion.ForeColor = System.Drawing.Color.Black;
            this.btGraficarSectorizacion.Location = new System.Drawing.Point(262, 815);
            this.btGraficarSectorizacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btGraficarSectorizacion.Name = "btGraficarSectorizacion";
            this.btGraficarSectorizacion.Size = new System.Drawing.Size(156, 30);
            this.btGraficarSectorizacion.TabIndex = 16;
            this.btGraficarSectorizacion.Text = "Graficar sectorización";
            this.btGraficarSectorizacion.UseVisualStyleBackColor = false;
            this.btGraficarSectorizacion.Click += new System.EventHandler(this.btGraficarSectorizacion_Click);
            // 
            // editInicioSectorG
            // 
            this.editInicioSectorG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editInicioSectorG.Location = new System.Drawing.Point(48, 851);
            this.editInicioSectorG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editInicioSectorG.Name = "editInicioSectorG";
            this.editInicioSectorG.Size = new System.Drawing.Size(187, 22);
            this.editInicioSectorG.TabIndex = 14;
            // 
            // editMaximoSectorG
            // 
            this.editMaximoSectorG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editMaximoSectorG.Location = new System.Drawing.Point(48, 798);
            this.editMaximoSectorG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editMaximoSectorG.Name = "editMaximoSectorG";
            this.editMaximoSectorG.Size = new System.Drawing.Size(187, 22);
            this.editMaximoSectorG.TabIndex = 13;
            // 
            // CalculosSectores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1571, 896);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.richMuestraReal);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.richSectores);
            this.Controls.Add(this.richIdeal);
            this.Controls.Add(this.richReal);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CalculosSectores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = " ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorCampoVacio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorConfi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSectorizacion)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btCalcular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox editMuestreo;
        private System.Windows.Forms.TextBox editLongBiela;
        private System.Windows.Forms.RichTextBox richReal;
        private System.Windows.Forms.TextBox editFuerzaPico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox editCadencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorCampoVacio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox editNumeroSectores;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox editAnguloInicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btCalcularConfi;
        private System.Windows.Forms.ErrorProvider errorConfi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richSectores;
        private System.Windows.Forms.RichTextBox richIdeal;
        private System.Windows.Forms.RichTextBox richMuestraReal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSectorizacion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btGraficarSectorizacion;
        private System.Windows.Forms.TextBox editInicioSectorG;
        private System.Windows.Forms.TextBox editMaximoSectorG;
    }
}