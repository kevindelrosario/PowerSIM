namespace Simulador
{
    partial class Multigrafico
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartIzquierda = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDerecha = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCombinacion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVelocidad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartIzquierda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDerecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCombinacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVelocidad)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartIzquierda
            // 
            this.chartIzquierda.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea1.Name = "ChartArea1";
            this.chartIzquierda.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartIzquierda.Legends.Add(legend1);
            this.chartIzquierda.Location = new System.Drawing.Point(739, 0);
            this.chartIzquierda.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.chartIzquierda.Name = "chartIzquierda";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series1.Color = System.Drawing.Color.DodgerBlue;
            series1.Legend = "Legend1";
            series1.Name = "Izquierda";
            this.chartIzquierda.Series.Add(series1);
            this.chartIzquierda.Size = new System.Drawing.Size(830, 452);
            this.chartIzquierda.TabIndex = 0;
            this.chartIzquierda.Text = "chartIzquierda";
            // 
            // chartDerecha
            // 
            this.chartDerecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea2.Name = "ChartArea1";
            this.chartDerecha.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDerecha.Legends.Add(legend2);
            this.chartDerecha.Location = new System.Drawing.Point(739, 452);
            this.chartDerecha.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.chartDerecha.Name = "chartDerecha";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "Derecha";
            this.chartDerecha.Series.Add(series2);
            this.chartDerecha.Size = new System.Drawing.Size(830, 446);
            this.chartDerecha.TabIndex = 1;
            this.chartDerecha.Text = "chartDerecha";
            // 
            // chartCombinacion
            // 
            this.chartCombinacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea3.Name = "ChartArea1";
            this.chartCombinacion.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartCombinacion.Legends.Add(legend3);
            this.chartCombinacion.Location = new System.Drawing.Point(-5, 0);
            this.chartCombinacion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.chartCombinacion.Name = "chartCombinacion";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series3.Legend = "Legend1";
            series3.Name = "Combinacion";
            this.chartCombinacion.Series.Add(series3);
            this.chartCombinacion.Size = new System.Drawing.Size(744, 452);
            this.chartCombinacion.TabIndex = 2;
            this.chartCombinacion.Text = "chartCombinacion";
            // 
            // chartVelocidad
            // 
            this.chartVelocidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea4.Name = "ChartArea1";
            this.chartVelocidad.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartVelocidad.Legends.Add(legend4);
            this.chartVelocidad.Location = new System.Drawing.Point(0, 452);
            this.chartVelocidad.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.chartVelocidad.Name = "chartVelocidad";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series4.Legend = "Legend1";
            series4.Name = "Velocidad";
            this.chartVelocidad.Series.Add(series4);
            this.chartVelocidad.Size = new System.Drawing.Size(739, 446);
            this.chartVelocidad.TabIndex = 3;
            this.chartVelocidad.Text = "chartVelocidad";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chartIzquierda);
            this.panel1.Controls.Add(this.chartDerecha);
            this.panel1.Controls.Add(this.chartCombinacion);
            this.panel1.Controls.Add(this.chartVelocidad);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1878, 1072);
            this.panel1.TabIndex = 4;
            // 
            // Multigrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1571, 897);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Multigrafico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multigrafico";
            ((System.ComponentModel.ISupportInitialize)(this.chartIzquierda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDerecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCombinacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVelocidad)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartIzquierda;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDerecha;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCombinacion;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVelocidad;
        private System.Windows.Forms.Panel panel1;
    }
}