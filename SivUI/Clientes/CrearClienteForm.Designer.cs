namespace SivUI
{
    partial class CrearClienteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearClienteForm));
            this.header_label = new System.Windows.Forms.Label();
            this.crear_cliente_button = new System.Windows.Forms.Button();
            this.nombre_cliente_tb = new System.Windows.Forms.TextBox();
            this.nombre_cliente_label = new System.Windows.Forms.Label();
            this.apellido_cliente_tb = new System.Windows.Forms.TextBox();
            this.apellido_cliente_label = new System.Windows.Forms.Label();
            this.numero_contacto_cliente_tb = new System.Windows.Forms.TextBox();
            this.numero_contacto_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(188, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(144, 30);
            this.header_label.TabIndex = 15;
            this.header_label.Text = "Nuevo cliente";
            // 
            // crear_cliente_button
            // 
            this.crear_cliente_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crear_cliente_button.Location = new System.Drawing.Point(396, 294);
            this.crear_cliente_button.Name = "crear_cliente_button";
            this.crear_cliente_button.Size = new System.Drawing.Size(115, 37);
            this.crear_cliente_button.TabIndex = 3;
            this.crear_cliente_button.Text = "Crear";
            this.crear_cliente_button.UseVisualStyleBackColor = true;
            this.crear_cliente_button.Click += new System.EventHandler(this.crear_cliente_button_Click);
            // 
            // nombre_cliente_tb
            // 
            this.nombre_cliente_tb.Location = new System.Drawing.Point(14, 85);
            this.nombre_cliente_tb.Name = "nombre_cliente_tb";
            this.nombre_cliente_tb.Size = new System.Drawing.Size(497, 33);
            this.nombre_cliente_tb.TabIndex = 0;
            // 
            // nombre_cliente_label
            // 
            this.nombre_cliente_label.AutoSize = true;
            this.nombre_cliente_label.Location = new System.Drawing.Point(9, 54);
            this.nombre_cliente_label.Name = "nombre_cliente_label";
            this.nombre_cliente_label.Size = new System.Drawing.Size(81, 25);
            this.nombre_cliente_label.TabIndex = 16;
            this.nombre_cliente_label.Text = "Nombre";
            // 
            // apellido_cliente_tb
            // 
            this.apellido_cliente_tb.Location = new System.Drawing.Point(14, 155);
            this.apellido_cliente_tb.Name = "apellido_cliente_tb";
            this.apellido_cliente_tb.Size = new System.Drawing.Size(497, 33);
            this.apellido_cliente_tb.TabIndex = 1;
            // 
            // apellido_cliente_label
            // 
            this.apellido_cliente_label.AutoSize = true;
            this.apellido_cliente_label.Location = new System.Drawing.Point(9, 124);
            this.apellido_cliente_label.Name = "apellido_cliente_label";
            this.apellido_cliente_label.Size = new System.Drawing.Size(175, 25);
            this.apellido_cliente_label.TabIndex = 19;
            this.apellido_cliente_label.Text = "Apellido (Opcional)";
            // 
            // numero_contacto_cliente_tb
            // 
            this.numero_contacto_cliente_tb.Location = new System.Drawing.Point(14, 225);
            this.numero_contacto_cliente_tb.Name = "numero_contacto_cliente_tb";
            this.numero_contacto_cliente_tb.Size = new System.Drawing.Size(497, 33);
            this.numero_contacto_cliente_tb.TabIndex = 2;
            // 
            // numero_contacto_label
            // 
            this.numero_contacto_label.AutoSize = true;
            this.numero_contacto_label.Location = new System.Drawing.Point(9, 194);
            this.numero_contacto_label.Name = "numero_contacto_label";
            this.numero_contacto_label.Size = new System.Drawing.Size(278, 25);
            this.numero_contacto_label.TabIndex = 21;
            this.numero_contacto_label.Text = "Número de contacto (Opcional)";
            // 
            // CrearClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 343);
            this.Controls.Add(this.numero_contacto_cliente_tb);
            this.Controls.Add(this.numero_contacto_label);
            this.Controls.Add(this.apellido_cliente_tb);
            this.Controls.Add(this.apellido_cliente_label);
            this.Controls.Add(this.crear_cliente_button);
            this.Controls.Add(this.nombre_cliente_tb);
            this.Controls.Add(this.nombre_cliente_label);
            this.Controls.Add(this.header_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "CrearClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.Button crear_cliente_button;
        private System.Windows.Forms.TextBox nombre_cliente_tb;
        private System.Windows.Forms.Label nombre_cliente_label;
        private System.Windows.Forms.TextBox apellido_cliente_tb;
        private System.Windows.Forms.Label apellido_cliente_label;
        private System.Windows.Forms.TextBox numero_contacto_cliente_tb;
        private System.Windows.Forms.Label numero_contacto_label;
    }
}