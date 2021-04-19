namespace SivUI
{
    partial class EditarClienteForm
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
            this.nombre_cliente_tb = new System.Windows.Forms.TextBox();
            this.buscar_cliente_linklabel = new System.Windows.Forms.LinkLabel();
            this.cliente_label = new System.Windows.Forms.Label();
            this.nuevo_nombre_tb = new System.Windows.Forms.TextBox();
            this.nuevo_nombre_label = new System.Windows.Forms.Label();
            this.numero_actual_tb = new System.Windows.Forms.TextBox();
            this.numero_cliente_label = new System.Windows.Forms.Label();
            this.nuevo_numero_tb = new System.Windows.Forms.TextBox();
            this.nuevo_numero_label = new System.Windows.Forms.Label();
            this.editar_button = new System.Windows.Forms.Button();
            this.header_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nombre_cliente_tb
            // 
            this.nombre_cliente_tb.Location = new System.Drawing.Point(23, 89);
            this.nombre_cliente_tb.Name = "nombre_cliente_tb";
            this.nombre_cliente_tb.ReadOnly = true;
            this.nombre_cliente_tb.Size = new System.Drawing.Size(414, 33);
            this.nombre_cliente_tb.TabIndex = 27;
            this.nombre_cliente_tb.TabStop = false;
            // 
            // buscar_cliente_linklabel
            // 
            this.buscar_cliente_linklabel.AutoSize = true;
            this.buscar_cliente_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_cliente_linklabel.Location = new System.Drawing.Point(386, 64);
            this.buscar_cliente_linklabel.Name = "buscar_cliente_linklabel";
            this.buscar_cliente_linklabel.Size = new System.Drawing.Size(56, 21);
            this.buscar_cliente_linklabel.TabIndex = 26;
            this.buscar_cliente_linklabel.TabStop = true;
            this.buscar_cliente_linklabel.Text = "Buscar";
            this.buscar_cliente_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buscar_cliente_linklabel_LinkClicked);
            // 
            // cliente_label
            // 
            this.cliente_label.AutoSize = true;
            this.cliente_label.Location = new System.Drawing.Point(18, 61);
            this.cliente_label.Name = "cliente_label";
            this.cliente_label.Size = new System.Drawing.Size(140, 25);
            this.cliente_label.TabIndex = 25;
            this.cliente_label.Text = "Cliente a editar";
            // 
            // nuevo_nombre_tb
            // 
            this.nuevo_nombre_tb.Location = new System.Drawing.Point(23, 227);
            this.nuevo_nombre_tb.Name = "nuevo_nombre_tb";
            this.nuevo_nombre_tb.Size = new System.Drawing.Size(414, 33);
            this.nuevo_nombre_tb.TabIndex = 29;
            // 
            // nuevo_nombre_label
            // 
            this.nuevo_nombre_label.AutoSize = true;
            this.nuevo_nombre_label.Location = new System.Drawing.Point(18, 199);
            this.nuevo_nombre_label.Name = "nuevo_nombre_label";
            this.nuevo_nombre_label.Size = new System.Drawing.Size(138, 25);
            this.nuevo_nombre_label.TabIndex = 28;
            this.nuevo_nombre_label.Text = "Nuevo nombre";
            // 
            // numero_actual_tb
            // 
            this.numero_actual_tb.Location = new System.Drawing.Point(23, 158);
            this.numero_actual_tb.Name = "numero_actual_tb";
            this.numero_actual_tb.ReadOnly = true;
            this.numero_actual_tb.Size = new System.Drawing.Size(414, 33);
            this.numero_actual_tb.TabIndex = 31;
            this.numero_actual_tb.TabStop = false;
            // 
            // numero_cliente_label
            // 
            this.numero_cliente_label.AutoSize = true;
            this.numero_cliente_label.Location = new System.Drawing.Point(18, 130);
            this.numero_cliente_label.Name = "numero_cliente_label";
            this.numero_cliente_label.Size = new System.Drawing.Size(241, 25);
            this.numero_cliente_label.TabIndex = 30;
            this.numero_cliente_label.Text = "Número de contacto actual";
            // 
            // nuevo_numero_tb
            // 
            this.nuevo_numero_tb.Location = new System.Drawing.Point(23, 296);
            this.nuevo_numero_tb.Name = "nuevo_numero_tb";
            this.nuevo_numero_tb.Size = new System.Drawing.Size(414, 33);
            this.nuevo_numero_tb.TabIndex = 33;
            // 
            // nuevo_numero_label
            // 
            this.nuevo_numero_label.AutoSize = true;
            this.nuevo_numero_label.Location = new System.Drawing.Point(18, 268);
            this.nuevo_numero_label.Name = "nuevo_numero_label";
            this.nuevo_numero_label.Size = new System.Drawing.Size(242, 25);
            this.nuevo_numero_label.TabIndex = 32;
            this.nuevo_numero_label.Text = "Nuevo número de contacto";
            // 
            // editar_button
            // 
            this.editar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editar_button.ForeColor = System.Drawing.Color.Gold;
            this.editar_button.Location = new System.Drawing.Point(330, 364);
            this.editar_button.Name = "editar_button";
            this.editar_button.Size = new System.Drawing.Size(107, 37);
            this.editar_button.TabIndex = 34;
            this.editar_button.Text = "Editar";
            this.editar_button.UseVisualStyleBackColor = true;
            this.editar_button.Click += new System.EventHandler(this.editar_button_Click);
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(133, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(189, 30);
            this.header_label.TabIndex = 35;
            this.header_label.Text = "Edición de clientes";
            // 
            // EditarClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(454, 413);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.editar_button);
            this.Controls.Add(this.nuevo_numero_tb);
            this.Controls.Add(this.nuevo_numero_label);
            this.Controls.Add(this.numero_actual_tb);
            this.Controls.Add(this.numero_cliente_label);
            this.Controls.Add(this.nuevo_nombre_tb);
            this.Controls.Add(this.nuevo_nombre_label);
            this.Controls.Add(this.nombre_cliente_tb);
            this.Controls.Add(this.buscar_cliente_linklabel);
            this.Controls.Add(this.cliente_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditarClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombre_cliente_tb;
        private System.Windows.Forms.LinkLabel buscar_cliente_linklabel;
        private System.Windows.Forms.Label cliente_label;
        private System.Windows.Forms.TextBox nuevo_nombre_tb;
        private System.Windows.Forms.Label nuevo_nombre_label;
        private System.Windows.Forms.TextBox numero_actual_tb;
        private System.Windows.Forms.Label numero_cliente_label;
        private System.Windows.Forms.TextBox nuevo_numero_tb;
        private System.Windows.Forms.Label nuevo_numero_label;
        private System.Windows.Forms.Button editar_button;
        private System.Windows.Forms.Label header_label;
    }
}