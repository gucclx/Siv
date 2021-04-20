namespace SivUI
{
    partial class BuscarClienteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarClienteForm));
            this.nombre_completo_tb = new System.Windows.Forms.TextBox();
            this.nombre_completo_cliente_label = new System.Windows.Forms.Label();
            this.resultados_listbox = new System.Windows.Forms.ListBox();
            this.buscar_cliente_button = new System.Windows.Forms.Button();
            this.seleccionar_button = new System.Windows.Forms.Button();
            this.resultados_label = new System.Windows.Forms.Label();
            this.header_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nombre_completo_tb
            // 
            this.nombre_completo_tb.Location = new System.Drawing.Point(12, 98);
            this.nombre_completo_tb.Name = "nombre_completo_tb";
            this.nombre_completo_tb.Size = new System.Drawing.Size(376, 33);
            this.nombre_completo_tb.TabIndex = 17;
            // 
            // nombre_completo_cliente_label
            // 
            this.nombre_completo_cliente_label.AutoSize = true;
            this.nombre_completo_cliente_label.Location = new System.Drawing.Point(12, 70);
            this.nombre_completo_cliente_label.Name = "nombre_completo_cliente_label";
            this.nombre_completo_cliente_label.Size = new System.Drawing.Size(157, 25);
            this.nombre_completo_cliente_label.TabIndex = 18;
            this.nombre_completo_cliente_label.Text = "Nombre a buscar";
            // 
            // resultados_listbox
            // 
            this.resultados_listbox.FormattingEnabled = true;
            this.resultados_listbox.ItemHeight = 25;
            this.resultados_listbox.Location = new System.Drawing.Point(12, 178);
            this.resultados_listbox.Name = "resultados_listbox";
            this.resultados_listbox.Size = new System.Drawing.Size(495, 104);
            this.resultados_listbox.TabIndex = 19;
            // 
            // buscar_cliente_button
            // 
            this.buscar_cliente_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar_cliente_button.Location = new System.Drawing.Point(396, 94);
            this.buscar_cliente_button.Name = "buscar_cliente_button";
            this.buscar_cliente_button.Size = new System.Drawing.Size(113, 37);
            this.buscar_cliente_button.TabIndex = 20;
            this.buscar_cliente_button.Text = "Buscar";
            this.buscar_cliente_button.UseVisualStyleBackColor = true;
            this.buscar_cliente_button.Click += new System.EventHandler(this.buscar_cliente_button_Click);
            // 
            // seleccionar_button
            // 
            this.seleccionar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seleccionar_button.Location = new System.Drawing.Point(381, 304);
            this.seleccionar_button.Name = "seleccionar_button";
            this.seleccionar_button.Size = new System.Drawing.Size(128, 37);
            this.seleccionar_button.TabIndex = 21;
            this.seleccionar_button.Text = "Seleccionar";
            this.seleccionar_button.UseVisualStyleBackColor = true;
            this.seleccionar_button.Click += new System.EventHandler(this.seleccionar_button_Click);
            // 
            // resultados_label
            // 
            this.resultados_label.AutoSize = true;
            this.resultados_label.Location = new System.Drawing.Point(7, 150);
            this.resultados_label.Name = "resultados_label";
            this.resultados_label.Size = new System.Drawing.Size(102, 25);
            this.resultados_label.TabIndex = 22;
            this.resultados_label.Text = "Resultados";
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(153, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(214, 30);
            this.header_label.TabIndex = 23;
            this.header_label.Text = "Búsqueda de clientes";
            // 
            // BuscarClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 353);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.resultados_label);
            this.Controls.Add(this.seleccionar_button);
            this.Controls.Add(this.buscar_cliente_button);
            this.Controls.Add(this.resultados_listbox);
            this.Controls.Add(this.nombre_completo_tb);
            this.Controls.Add(this.nombre_completo_cliente_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "BuscarClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombre_completo_tb;
        private System.Windows.Forms.Label nombre_completo_cliente_label;
        private System.Windows.Forms.ListBox resultados_listbox;
        private System.Windows.Forms.Button buscar_cliente_button;
        private System.Windows.Forms.Button seleccionar_button;
        private System.Windows.Forms.Label resultados_label;
        private System.Windows.Forms.Label header_label;
    }
}