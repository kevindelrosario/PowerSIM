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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtConteo = new System.Windows.Forms.Label();
            this.valorBarra = new System.Windows.Forms.TextBox();
            this.barra = new System.Windows.Forms.TrackBar();
            this.btCalcular = new System.Windows.Forms.Button();
            this.editLongBiela = new System.Windows.Forms.TextBox();
            this.editCadencia = new System.Windows.Forms.TextBox();
            this.editFuerzaPico = new System.Windows.Forms.TextBox();
            this.richPotencia = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fuerza Pico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(232, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cadencia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Longitud Biela";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtConteo);
            this.panel1.Controls.Add(this.valorBarra);
            this.panel1.Controls.Add(this.barra);
            this.panel1.Controls.Add(this.btCalcular);
            this.panel1.Controls.Add(this.editLongBiela);
            this.panel1.Controls.Add(this.editCadencia);
            this.panel1.Controls.Add(this.editFuerzaPico);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1178, 153);
            this.panel1.TabIndex = 3;
            // 
            // txtConteo
            // 
            this.txtConteo.AutoSize = true;
            this.txtConteo.Location = new System.Drawing.Point(433, 60);
            this.txtConteo.Name = "txtConteo";
            this.txtConteo.Size = new System.Drawing.Size(13, 13);
            this.txtConteo.TabIndex = 9;
            this.txtConteo.Text = "0";
            // 
            // valorBarra
            // 
            this.valorBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorBarra.Location = new System.Drawing.Point(641, 94);
            this.valorBarra.Name = "valorBarra";
            this.valorBarra.Size = new System.Drawing.Size(55, 26);
            this.valorBarra.TabIndex = 8;
            this.valorBarra.Text = "0";
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.White;
            this.barra.Location = new System.Drawing.Point(11, 94);
            this.barra.Margin = new System.Windows.Forms.Padding(2);
            this.barra.Maximum = 300;
            this.barra.Name = "barra";
            this.barra.Size = new System.Drawing.Size(616, 45);
            this.barra.TabIndex = 6;
            this.barra.Scroll += new System.EventHandler(this.barra_Scroll);
            // 
            // btCalcular
            // 
            this.btCalcular.BackColor = System.Drawing.Color.Aquamarine;
            this.btCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCalcular.ForeColor = System.Drawing.Color.Black;
            this.btCalcular.Location = new System.Drawing.Point(290, 53);
            this.btCalcular.Name = "btCalcular";
            this.btCalcular.Size = new System.Drawing.Size(121, 26);
            this.btCalcular.TabIndex = 6;
            this.btCalcular.Text = "Calcular datos";
            this.btCalcular.UseVisualStyleBackColor = false;
            this.btCalcular.Click += new System.EventHandler(this.btCalcular_Click);
            // 
            // editLongBiela
            // 
            this.editLongBiela.Location = new System.Drawing.Point(105, 53);
            this.editLongBiela.Name = "editLongBiela";
            this.editLongBiela.Size = new System.Drawing.Size(121, 20);
            this.editLongBiela.TabIndex = 5;
            // 
            // editCadencia
            // 
            this.editCadencia.Location = new System.Drawing.Point(290, 19);
            this.editCadencia.Name = "editCadencia";
            this.editCadencia.Size = new System.Drawing.Size(121, 20);
            this.editCadencia.TabIndex = 4;
            // 
            // editFuerzaPico
            // 
            this.editFuerzaPico.Location = new System.Drawing.Point(105, 19);
            this.editFuerzaPico.Name = "editFuerzaPico";
            this.editFuerzaPico.Size = new System.Drawing.Size(121, 20);
            this.editFuerzaPico.TabIndex = 3;
            // 
            // richPotencia
            // 
            this.richPotencia.Location = new System.Drawing.Point(61, 180);
            this.richPotencia.Name = "richPotencia";
            this.richPotencia.Size = new System.Drawing.Size(408, 398);
            this.richPotencia.TabIndex = 5;
            this.richPotencia.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(632, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "ls";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Calculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1178, 729);
            this.Controls.Add(this.richPotencia);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Calculos";
            this.Text = "Calculos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barra)).EndInit();
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
        private System.Windows.Forms.Button btCalcular;
        private System.Windows.Forms.RichTextBox richPotencia;
        private System.Windows.Forms.TrackBar barra;
        private System.Windows.Forms.TextBox valorBarra;
        private System.Windows.Forms.Label txtConteo;
        private System.Windows.Forms.Button button1;
    }
}