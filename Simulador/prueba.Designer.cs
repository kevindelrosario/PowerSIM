namespace Simulador
{
    partial class prueba
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
            this.rich = new System.Windows.Forms.RichTextBox();
            this.btn = new System.Windows.Forms.Button();
            this.salto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rich
            // 
            this.rich.Location = new System.Drawing.Point(332, 64);
            this.rich.Name = "rich";
            this.rich.Size = new System.Drawing.Size(518, 680);
            this.rich.TabIndex = 0;
            this.rich.Text = "";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(133, 406);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(111, 39);
            this.btn.TabIndex = 1;
            this.btn.Text = "button1";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // salto
            // 
            this.salto.Location = new System.Drawing.Point(133, 335);
            this.salto.Name = "salto";
            this.salto.Size = new System.Drawing.Size(101, 22);
            this.salto.TabIndex = 2;
            // 
            // prueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 869);
            this.Controls.Add(this.salto);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.rich);
            this.Name = "prueba";
            this.Text = "prueba";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rich;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.TextBox salto;
    }
}