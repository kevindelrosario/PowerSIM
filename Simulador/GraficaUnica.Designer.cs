namespace Simulador
{
    partial class GraficaUnica
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.checkDerecha = new System.Windows.Forms.CheckBox();
            this.checkIzquierda = new System.Windows.Forms.CheckBox();
            this.checkCombinada = new System.Windows.Forms.CheckBox();
            this.checkVelocidad = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.DarkGray;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, -2);
            this.chart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series1.Color = System.Drawing.Color.OrangeRed;
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Black;
            series1.Name = "Derecha";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series2.Color = System.Drawing.Color.DodgerBlue;
            series2.Legend = "Legend1";
            series2.Name = "Izquierda";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series3.Color = System.Drawing.Color.Gray;
            series3.LabelBorderWidth = 2;
            series3.Legend = "Legend1";
            series3.Name = "Combinada";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series4.Legend = "Legend1";
            series4.Name = "Velocidad";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(1178, 729);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(-11, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "Dibujar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkDerecha
            // 
            this.checkDerecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkDerecha.AutoSize = true;
            this.checkDerecha.Location = new System.Drawing.Point(1, 3);
            this.checkDerecha.Name = "checkDerecha";
            this.checkDerecha.Size = new System.Drawing.Size(67, 17);
            this.checkDerecha.TabIndex = 10;
            this.checkDerecha.Text = "Derecha";
            this.checkDerecha.UseVisualStyleBackColor = true;
            // 
            // checkIzquierda
            // 
            this.checkIzquierda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkIzquierda.AutoSize = true;
            this.checkIzquierda.Location = new System.Drawing.Point(1, 26);
            this.checkIzquierda.Name = "checkIzquierda";
            this.checkIzquierda.Size = new System.Drawing.Size(69, 17);
            this.checkIzquierda.TabIndex = 11;
            this.checkIzquierda.Text = "Izquierda";
            this.checkIzquierda.UseVisualStyleBackColor = true;
            // 
            // checkCombinada
            // 
            this.checkCombinada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkCombinada.AutoSize = true;
            this.checkCombinada.Location = new System.Drawing.Point(1, 49);
            this.checkCombinada.Name = "checkCombinada";
            this.checkCombinada.Size = new System.Drawing.Size(79, 17);
            this.checkCombinada.TabIndex = 12;
            this.checkCombinada.Text = "Combinada";
            this.checkCombinada.UseVisualStyleBackColor = true;
            // 
            // checkVelocidad
            // 
            this.checkVelocidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkVelocidad.AutoSize = true;
            this.checkVelocidad.Location = new System.Drawing.Point(1, 72);
            this.checkVelocidad.Name = "checkVelocidad";
            this.checkVelocidad.Size = new System.Drawing.Size(73, 17);
            this.checkVelocidad.TabIndex = 13;
            this.checkVelocidad.Text = "Velocidad";
            this.checkVelocidad.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.checkDerecha);
            this.panel1.Controls.Add(this.checkVelocidad);
            this.panel1.Controls.Add(this.checkIzquierda);
            this.panel1.Controls.Add(this.checkCombinada);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(1026, 272);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(119, 118);
            this.panel1.TabIndex = 14;
            // 
            // GraficaUnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 729);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GraficaUnica";
            this.Text = "GraficaUnica";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkDerecha;
        private System.Windows.Forms.CheckBox checkIzquierda;
        private System.Windows.Forms.CheckBox checkCombinada;
        private System.Windows.Forms.CheckBox checkVelocidad;
        private System.Windows.Forms.Panel panel1;
    }
}