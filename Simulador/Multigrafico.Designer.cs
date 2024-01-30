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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartIzquierda = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDerecha = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCombinacion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVelocidad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartIzquierda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDerecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCombinacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVelocidad)).BeginInit();
            this.SuspendLayout();
            // 
            // chartIzquierda
            // 
            this.chartIzquierda.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea5.Name = "ChartArea1";
            this.chartIzquierda.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartIzquierda.Legends.Add(legend5);
            this.chartIzquierda.Location = new System.Drawing.Point(9, 1);
            this.chartIzquierda.Margin = new System.Windows.Forms.Padding(0);
            this.chartIzquierda.Name = "chartIzquierda";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series5.Color = System.Drawing.Color.DodgerBlue;
            series5.Legend = "Legend1";
            series5.Name = "Izquierda";
            this.chartIzquierda.Series.Add(series5);
            this.chartIzquierda.Size = new System.Drawing.Size(545, 361);
            this.chartIzquierda.TabIndex = 0;
            this.chartIzquierda.Text = "chartIzquierda";
            // 
            // chartDerecha
            // 
            this.chartDerecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea6.Name = "ChartArea1";
            this.chartDerecha.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartDerecha.Legends.Add(legend6);
            this.chartDerecha.Location = new System.Drawing.Point(9, 367);
            this.chartDerecha.Margin = new System.Windows.Forms.Padding(10);
            this.chartDerecha.Name = "chartDerecha";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series6.Legend = "Legend1";
            series6.Name = "Derecha";
            this.chartDerecha.Series.Add(series6);
            this.chartDerecha.Size = new System.Drawing.Size(545, 361);
            this.chartDerecha.TabIndex = 1;
            this.chartDerecha.Text = "chartDerecha";
            // 
            // chartCombinacion
            // 
            this.chartCombinacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea7.Name = "ChartArea1";
            this.chartCombinacion.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartCombinacion.Legends.Add(legend7);
            this.chartCombinacion.Location = new System.Drawing.Point(564, 367);
            this.chartCombinacion.Margin = new System.Windows.Forms.Padding(10);
            this.chartCombinacion.Name = "chartCombinacion";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series7.Legend = "Legend1";
            series7.Name = "Combinacion";
            this.chartCombinacion.Series.Add(series7);
            this.chartCombinacion.Size = new System.Drawing.Size(556, 361);
            this.chartCombinacion.TabIndex = 2;
            this.chartCombinacion.Text = "chartCombinacion";
            // 
            // chartVelocidad
            // 
            this.chartVelocidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea8.Name = "ChartArea1";
            this.chartVelocidad.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartVelocidad.Legends.Add(legend8);
            this.chartVelocidad.Location = new System.Drawing.Point(564, 1);
            this.chartVelocidad.Margin = new System.Windows.Forms.Padding(10);
            this.chartVelocidad.Name = "chartVelocidad";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series8.Legend = "Legend1";
            series8.Name = "Velocidad";
            this.chartVelocidad.Series.Add(series8);
            this.chartVelocidad.Size = new System.Drawing.Size(556, 361);
            this.chartVelocidad.TabIndex = 3;
            this.chartVelocidad.Text = "chartVelocidad";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(1051, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Mostrar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Multigrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1178, 729);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chartVelocidad);
            this.Controls.Add(this.chartCombinacion);
            this.Controls.Add(this.chartDerecha);
            this.Controls.Add(this.chartIzquierda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Multigrafico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multigrafico";
            ((System.ComponentModel.ISupportInitialize)(this.chartIzquierda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDerecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCombinacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVelocidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartIzquierda;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDerecha;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCombinacion;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVelocidad;
        private System.Windows.Forms.Button button1;
    }
}