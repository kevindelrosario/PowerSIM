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
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.valorBarra = new System.Windows.Forms.TextBox();
            this.barra = new System.Windows.Forms.TrackBar();
            this.editLongBiela = new System.Windows.Forms.TextBox();
            this.editCadencia = new System.Windows.Forms.TextBox();
            this.editFuerzaPico = new System.Windows.Forms.TextBox();
            this.richPotencia = new System.Windows.Forms.RichTextBox();
            this.richInfo = new System.Windows.Forms.RichTextBox();
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
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(309, 27);
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
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Longitud Biela";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
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
            this.panel1.Size = new System.Drawing.Size(1571, 163);
            this.panel1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(309, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "F. S.";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(729, 124);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // valorBarra
            // 
            this.valorBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorBarra.Location = new System.Drawing.Point(1008, 64);
            this.valorBarra.Margin = new System.Windows.Forms.Padding(4);
            this.valorBarra.Name = "valorBarra";
            this.valorBarra.Size = new System.Drawing.Size(100, 31);
            this.valorBarra.TabIndex = 8;
            this.valorBarra.Text = "0";
            // 
            // barra
            // 
            this.barra.BackColor = System.Drawing.Color.White;
            this.barra.Location = new System.Drawing.Point(358, 51);
            this.barra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barra.Maximum = 1000;
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
            this.editCadencia.Location = new System.Drawing.Point(387, 23);
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
            this.richPotencia.Location = new System.Drawing.Point(12, 290);
            this.richPotencia.Margin = new System.Windows.Forms.Padding(4);
            this.richPotencia.Name = "richPotencia";
            this.richPotencia.Size = new System.Drawing.Size(534, 309);
            this.richPotencia.TabIndex = 5;
            this.richPotencia.Text = "";
            // 
            // richInfo
            // 
            this.richInfo.Location = new System.Drawing.Point(12, 181);
            this.richInfo.Name = "richInfo";
            this.richInfo.Size = new System.Drawing.Size(301, 88);
            this.richInfo.TabIndex = 6;
            this.richInfo.Text = "";
            // 
            // Calculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1571, 897);
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
    }
}