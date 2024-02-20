namespace Simulador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtRutaArchivo1 = new System.Windows.Forms.TextBox();
            this.btRuta1 = new System.Windows.Forms.Button();
            this.buscarArchivo = new System.Windows.Forms.Button();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btCalculo = new System.Windows.Forms.Button();
            this.btMultigrafico = new System.Windows.Forms.Button();
            this.btUnico = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelBuscarArchivo = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panelSideMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelBuscarArchivo.SuspendLayout();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRutaArchivo1
            // 
            this.txtRutaArchivo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRutaArchivo1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtRutaArchivo1.Location = new System.Drawing.Point(405, 28);
            this.txtRutaArchivo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRutaArchivo1.Name = "txtRutaArchivo1";
            this.txtRutaArchivo1.Size = new System.Drawing.Size(580, 22);
            this.txtRutaArchivo1.TabIndex = 0;
            // 
            // btRuta1
            // 
            this.btRuta1.BackColor = System.Drawing.Color.DarkCyan;
            this.btRuta1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRuta1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btRuta1.Location = new System.Drawing.Point(1423, 15);
            this.btRuta1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRuta1.Name = "btRuta1";
            this.btRuta1.Size = new System.Drawing.Size(324, 38);
            this.btRuta1.TabIndex = 1;
            this.btRuta1.Text = "Lectura General";
            this.btRuta1.UseVisualStyleBackColor = false;
            // 
            // buscarArchivo
            // 
            this.buscarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarArchivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buscarArchivo.Location = new System.Drawing.Point(992, 23);
            this.buscarArchivo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buscarArchivo.Name = "buscarArchivo";
            this.buscarArchivo.Size = new System.Drawing.Size(159, 32);
            this.buscarArchivo.TabIndex = 9;
            this.buscarArchivo.Text = "Buscar Archivo";
            this.buscarArchivo.UseVisualStyleBackColor = true;
            this.buscarArchivo.Click += new System.EventHandler(this.buscarArchivo_Click);
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.Black;
            this.panelSideMenu.Controls.Add(this.button1);
            this.panelSideMenu.Controls.Add(this.btCalculo);
            this.panelSideMenu.Controls.Add(this.btMultigrafico);
            this.panelSideMenu.Controls.Add(this.btUnico);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(268, 967);
            this.panelSideMenu.TabIndex = 13;
            // 
            // btCalculo
            // 
            this.btCalculo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btCalculo.FlatAppearance.BorderSize = 0;
            this.btCalculo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btCalculo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btCalculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCalculo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btCalculo.Location = new System.Drawing.Point(0, 224);
            this.btCalculo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCalculo.Name = "btCalculo";
            this.btCalculo.Size = new System.Drawing.Size(268, 43);
            this.btCalculo.TabIndex = 3;
            this.btCalculo.Text = "Calculos Fs";
            this.btCalculo.UseVisualStyleBackColor = true;
            this.btCalculo.Click += new System.EventHandler(this.btCalculo_Click);
            // 
            // btMultigrafico
            // 
            this.btMultigrafico.Dock = System.Windows.Forms.DockStyle.Top;
            this.btMultigrafico.FlatAppearance.BorderSize = 0;
            this.btMultigrafico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btMultigrafico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btMultigrafico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMultigrafico.ForeColor = System.Drawing.Color.Gainsboro;
            this.btMultigrafico.Location = new System.Drawing.Point(0, 181);
            this.btMultigrafico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btMultigrafico.Name = "btMultigrafico";
            this.btMultigrafico.Size = new System.Drawing.Size(268, 43);
            this.btMultigrafico.TabIndex = 2;
            this.btMultigrafico.Text = "Multigrafico";
            this.btMultigrafico.UseVisualStyleBackColor = true;
            this.btMultigrafico.Click += new System.EventHandler(this.btMultigrafico_Click);
            // 
            // btUnico
            // 
            this.btUnico.Dock = System.Windows.Forms.DockStyle.Top;
            this.btUnico.FlatAppearance.BorderSize = 0;
            this.btUnico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btUnico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btUnico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUnico.ForeColor = System.Drawing.Color.Gainsboro;
            this.btUnico.Location = new System.Drawing.Point(0, 138);
            this.btUnico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btUnico.Name = "btUnico";
            this.btUnico.Size = new System.Drawing.Size(268, 43);
            this.btUnico.TabIndex = 1;
            this.btUnico.Text = "Grafico unico";
            this.btUnico.UseVisualStyleBackColor = true;
            this.btUnico.Click += new System.EventHandler(this.btUnico_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox2);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(268, 138);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(268, 137);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panelBuscarArchivo
            // 
            this.panelBuscarArchivo.BackColor = System.Drawing.Color.Black;
            this.panelBuscarArchivo.Controls.Add(this.buscarArchivo);
            this.panelBuscarArchivo.Controls.Add(this.txtRutaArchivo1);
            this.panelBuscarArchivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBuscarArchivo.Location = new System.Drawing.Point(268, 0);
            this.panelBuscarArchivo.Margin = new System.Windows.Forms.Padding(4);
            this.panelBuscarArchivo.Name = "panelBuscarArchivo";
            this.panelBuscarArchivo.Size = new System.Drawing.Size(1571, 70);
            this.panelBuscarArchivo.TabIndex = 14;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.White;
            this.panelChildForm.Controls.Add(this.pictureBox1);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(268, 70);
            this.panelChildForm.Margin = new System.Windows.Forms.Padding(4);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1571, 897);
            this.panelChildForm.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1571, 897);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(0, 267);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calculos Sectores";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1839, 967);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelBuscarArchivo);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.btRuta1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1533, 819);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelSideMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelBuscarArchivo.ResumeLayout(false);
            this.panelBuscarArchivo.PerformLayout();
            this.panelChildForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRutaArchivo1;
        private System.Windows.Forms.Button btRuta1;
        private System.Windows.Forms.Button buscarArchivo;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btUnico;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btMultigrafico;
        private System.Windows.Forms.Panel panelBuscarArchivo;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Button btCalculo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
    }
}

