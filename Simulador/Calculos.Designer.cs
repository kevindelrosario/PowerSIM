namespace Simulador
{
    partial class Calculos
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
            System.Windows.Forms.Button btRepresentarG;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.valorBarra = new System.Windows.Forms.TextBox();
            this.barra = new System.Windows.Forms.TrackBar();
            this.editLongBiela = new System.Windows.Forms.TextBox();
            this.editCadencia = new System.Windows.Forms.TextBox();
            this.editFuerzaPico = new System.Windows.Forms.TextBox();
            this.richPotencia = new System.Windows.Forms.RichTextBox();
            this.richInfo = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIncrementoFs = new System.Windows.Forms.TextBox();
            this.txtFsFinal = new System.Windows.Forms.TextBox();
            this.txtFsInicio = new System.Windows.Forms.TextBox();
            this.chartErrores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btRepresentarG = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barra)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // btRepresentarG
            // 
            btRepresentarG.BackColor = System.Drawing.Color.Gold;
            btRepresentarG.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btRepresentarG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            btRepresentarG.Location = new System.Drawing.Point(33, 295);
            btRepresentarG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btRepresentarG.Name = "btRepresentarG";
            btRepresentarG.Size = new System.Drawing.Size(101, 30);
            btRepresentarG.TabIndex = 1;
            btRepresentarG.Text = "Representar";
            btRepresentarG.UseVisualStyleBackColor = false;
            btRepresentarG.Click += new System.EventHandler(this.btErrorPotencia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fuerza Pico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cadencia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Longitud Biela";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.valorBarra);
            this.panel1.Controls.Add(this.barra);
            this.panel1.Controls.Add(this.editLongBiela);
            this.panel1.Controls.Add(this.editCadencia);
            this.panel1.Controls.Add(this.editFuerzaPico);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1571, 170);
            this.panel1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(337, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "F. S.";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(1190, 105);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 41);
            this.button1.TabIndex = 10;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // valorBarra
            // 
            this.valorBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorBarra.Location = new System.Drawing.Point(1045, 115);
            this.valorBarra.Margin = new System.Windows.Forms.Padding(4);
            this.valorBarra.Name = "valorBarra";
            this.valorBarra.Size = new System.Drawing.Size(88, 31);
            this.valorBarra.TabIndex = 8;
            this.valorBarra.Text = "0";
            this.valorBarra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.White;
            this.barra.Location = new System.Drawing.Point(386, 90);
            this.barra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barra.Maximum = 5000;
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(643, 56);
            this.barra.TabIndex = 6;
            this.barra.Scroll += new System.EventHandler(this.barra_Scroll);
            // 
            // editLongBiela
            // 
            this.editLongBiela.Location = new System.Drawing.Point(140, 78);
            this.editLongBiela.Margin = new System.Windows.Forms.Padding(4);
            this.editLongBiela.Name = "editLongBiela";
            this.editLongBiela.Size = new System.Drawing.Size(160, 22);
            this.editLongBiela.TabIndex = 5;
            // 
            // editCadencia
            // 
            this.editCadencia.Location = new System.Drawing.Point(140, 124);
            this.editCadencia.Margin = new System.Windows.Forms.Padding(4);
            this.editCadencia.Name = "editCadencia";
            this.editCadencia.Size = new System.Drawing.Size(160, 22);
            this.editCadencia.TabIndex = 4;
            // 
            // editFuerzaPico
            // 
            this.editFuerzaPico.Location = new System.Drawing.Point(140, 23);
            this.editFuerzaPico.Margin = new System.Windows.Forms.Padding(4);
            this.editFuerzaPico.Name = "editFuerzaPico";
            this.editFuerzaPico.Size = new System.Drawing.Size(160, 22);
            this.editFuerzaPico.TabIndex = 3;
            // 
            // richPotencia
            // 
            this.richPotencia.Location = new System.Drawing.Point(13, 314);
            this.richPotencia.Margin = new System.Windows.Forms.Padding(4);
            this.richPotencia.Name = "richPotencia";
            this.richPotencia.Size = new System.Drawing.Size(401, 309);
            this.richPotencia.TabIndex = 5;
            this.richPotencia.Text = "";
            // 
            // richInfo
            // 
            this.richInfo.Location = new System.Drawing.Point(13, 200);
            this.richInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richInfo.Name = "richInfo";
            this.richInfo.Size = new System.Drawing.Size(301, 88);
            this.richInfo.TabIndex = 6;
            this.richInfo.Text = "";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtIncrementoFs);
            this.panel2.Controls.Add(this.txtFsFinal);
            this.panel2.Controls.Add(this.txtFsInicio);
            this.panel2.Controls.Add(btRepresentarG);
            this.panel2.Controls.Add(this.chartErrores);
            this.panel2.Location = new System.Drawing.Point(421, 173);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1147, 722);
            this.panel2.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(3, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "Curva de error";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(4, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "Incremento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(3, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Fs final:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fs inicio:";
            // 
            // txtIncrementoFs
            // 
            this.txtIncrementoFs.Location = new System.Drawing.Point(32, 235);
            this.txtIncrementoFs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIncrementoFs.Name = "txtIncrementoFs";
            this.txtIncrementoFs.Size = new System.Drawing.Size(101, 22);
            this.txtIncrementoFs.TabIndex = 4;
            // 
            // txtFsFinal
            // 
            this.txtFsFinal.Location = new System.Drawing.Point(32, 180);
            this.txtFsFinal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFsFinal.Name = "txtFsFinal";
            this.txtFsFinal.Size = new System.Drawing.Size(101, 22);
            this.txtFsFinal.TabIndex = 3;
            // 
            // txtFsInicio
            // 
            this.txtFsInicio.Location = new System.Drawing.Point(32, 125);
            this.txtFsInicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFsInicio.Name = "txtFsInicio";
            this.txtFsInicio.Size = new System.Drawing.Size(101, 22);
            this.txtFsInicio.TabIndex = 2;
            // 
            // chartErrores
            // 
            this.chartErrores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartErrores.BackColor = System.Drawing.Color.Snow;
            this.chartErrores.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.InterlacedColor = System.Drawing.Color.Black;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.BackColor = System.Drawing.Color.Silver;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderWidth = 2;
            chartArea1.CursorX.LineColor = System.Drawing.Color.Black;
            chartArea1.CursorX.SelectionColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            this.chartErrores.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartErrores.Legends.Add(legend1);
            this.chartErrores.Location = new System.Drawing.Point(193, -1);
            this.chartErrores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartErrores.Name = "chartErrores";
            this.chartErrores.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.Navy;
            series1.Legend = "Legend1";
            series1.Name = "fs";
            series1.YValuesPerPoint = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Recorrido";
            series2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chartErrores.Series.Add(series1);
            this.chartErrores.Series.Add(series2);
            this.chartErrores.Size = new System.Drawing.Size(949, 725);
            this.chartErrores.TabIndex = 0;
            this.chartErrores.Text = "chart1";
            // 
            // Calculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1571, 896);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.richInfo);
            this.Controls.Add(this.richPotencia);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Calculos";
            this.Text = "Calculos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barra)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartErrores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox editLongBiela;
        private System.Windows.Forms.TextBox editCadencia;
        private System.Windows.Forms.TextBox editFuerzaPico;
        private System.Windows.Forms.RichTextBox richPotencia;
        private System.Windows.Forms.TrackBar barra;
        private System.Windows.Forms.TextBox valorBarra;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartErrores;
        private System.Windows.Forms.TextBox txtIncrementoFs;
        private System.Windows.Forms.TextBox txtFsFinal;
        private System.Windows.Forms.TextBox txtFsInicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
    }
}