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
            this.txtRutaArchivo1 = new System.Windows.Forms.TextBox();
            this.btRuta1 = new System.Windows.Forms.Button();
            this.buscarArchivo = new System.Windows.Forms.Button();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btMultigrafico = new System.Windows.Forms.Button();
            this.btUnico = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelBuscarArchivo = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelSideMenu.SuspendLayout();
            this.panelBuscarArchivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRutaArchivo1
            // 
            this.txtRutaArchivo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRutaArchivo1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtRutaArchivo1.Location = new System.Drawing.Point(304, 23);
            this.txtRutaArchivo1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRutaArchivo1.Name = "txtRutaArchivo1";
            this.txtRutaArchivo1.Size = new System.Drawing.Size(436, 20);
            this.txtRutaArchivo1.TabIndex = 0;
            // 
            // btRuta1
            // 
            this.btRuta1.BackColor = System.Drawing.Color.DarkCyan;
            this.btRuta1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRuta1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btRuta1.Location = new System.Drawing.Point(1067, 12);
            this.btRuta1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btRuta1.Name = "btRuta1";
            this.btRuta1.Size = new System.Drawing.Size(243, 31);
            this.btRuta1.TabIndex = 1;
            this.btRuta1.Text = "Lectura General";
            this.btRuta1.UseVisualStyleBackColor = false;
            // 
            // buscarArchivo
            // 
            this.buscarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buscarArchivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buscarArchivo.Location = new System.Drawing.Point(744, 19);
            this.buscarArchivo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buscarArchivo.Name = "buscarArchivo";
            this.buscarArchivo.Size = new System.Drawing.Size(119, 26);
            this.buscarArchivo.TabIndex = 9;
            this.buscarArchivo.Text = "Buscar Archivo";
            this.buscarArchivo.UseVisualStyleBackColor = true;
            this.buscarArchivo.Click += new System.EventHandler(this.buscarArchivo_Click);
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.btMultigrafico);
            this.panelSideMenu.Controls.Add(this.btUnico);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(201, 786);
            this.panelSideMenu.TabIndex = 13;
            // 
            // btMultigrafico
            // 
            this.btMultigrafico.Dock = System.Windows.Forms.DockStyle.Top;
            this.btMultigrafico.FlatAppearance.BorderSize = 0;
            this.btMultigrafico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btMultigrafico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btMultigrafico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMultigrafico.ForeColor = System.Drawing.Color.Gainsboro;
            this.btMultigrafico.Location = new System.Drawing.Point(0, 224);
            this.btMultigrafico.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btMultigrafico.Name = "btMultigrafico";
            this.btMultigrafico.Size = new System.Drawing.Size(201, 35);
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
            this.btUnico.Location = new System.Drawing.Point(0, 189);
            this.btUnico.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btUnico.Name = "btUnico";
            this.btUnico.Size = new System.Drawing.Size(201, 35);
            this.btUnico.TabIndex = 1;
            this.btUnico.Text = "Grafico unico";
            this.btUnico.UseVisualStyleBackColor = true;
            this.btUnico.Click += new System.EventHandler(this.btUnico_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(201, 189);
            this.panelLogo.TabIndex = 0;
            // 
            // panelBuscarArchivo
            // 
            this.panelBuscarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelBuscarArchivo.Controls.Add(this.buscarArchivo);
            this.panelBuscarArchivo.Controls.Add(this.txtRutaArchivo1);
            this.panelBuscarArchivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBuscarArchivo.Location = new System.Drawing.Point(201, 0);
            this.panelBuscarArchivo.Name = "panelBuscarArchivo";
            this.panelBuscarArchivo.Size = new System.Drawing.Size(1178, 57);
            this.panelBuscarArchivo.TabIndex = 14;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.DarkGray;
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(201, 57);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1178, 729);
            this.panelChildForm.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1379, 786);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelBuscarArchivo);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.btRuta1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(1154, 675);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelBuscarArchivo.ResumeLayout(false);
            this.panelBuscarArchivo.PerformLayout();
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
    }
}

