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
            this.nombre_completo_tb = new System.Windows.Forms.TextBox();
            this.nombre_completo_cliente_label = new System.Windows.Forms.Label();
            this.resultados_listbox = new System.Windows.Forms.ListBox();
            this.buscar_cliente_button = new System.Windows.Forms.Button();
            this.aceptar_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nombre_completo_tb
            // 
            this.nombre_completo_tb.Location = new System.Drawing.Point(12, 70);
            this.nombre_completo_tb.Name = "nombre_completo_tb";
            this.nombre_completo_tb.Size = new System.Drawing.Size(376, 33);
            this.nombre_completo_tb.TabIndex = 17;
            // 
            // nombre_completo_cliente_label
            // 
            this.nombre_completo_cliente_label.AutoSize = true;
            this.nombre_completo_cliente_label.Location = new System.Drawing.Point(7, 39);
            this.nombre_completo_cliente_label.Name = "nombre_completo_cliente_label";
            this.nombre_completo_cliente_label.Size = new System.Drawing.Size(157, 25);
            this.nombre_completo_cliente_label.TabIndex = 18;
            this.nombre_completo_cliente_label.Text = "Nombre a buscar";
            // 
            // resultados_listbox
            // 
            this.resultados_listbox.FormattingEnabled = true;
            this.resultados_listbox.ItemHeight = 25;
            this.resultados_listbox.Location = new System.Drawing.Point(12, 109);
            this.resultados_listbox.Name = "resultados_listbox";
            this.resultados_listbox.Size = new System.Drawing.Size(497, 104);
            this.resultados_listbox.TabIndex = 19;
            this.resultados_listbox.Visible = false;
            // 
            // buscar_cliente_button
            // 
            this.buscar_cliente_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar_cliente_button.Location = new System.Drawing.Point(394, 66);
            this.buscar_cliente_button.Name = "buscar_cliente_button";
            this.buscar_cliente_button.Size = new System.Drawing.Size(115, 37);
            this.buscar_cliente_button.TabIndex = 20;
            this.buscar_cliente_button.Text = "Buscar";
            this.buscar_cliente_button.UseVisualStyleBackColor = true;
            this.buscar_cliente_button.Click += new System.EventHandler(this.buscar_cliente_button_Click);
            // 
            // aceptar_button
            // 
            this.aceptar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptar_button.Location = new System.Drawing.Point(394, 219);
            this.aceptar_button.Name = "aceptar_button";
            this.aceptar_button.Size = new System.Drawing.Size(115, 37);
            this.aceptar_button.TabIndex = 21;
            this.aceptar_button.Text = "Aceptar";
            this.aceptar_button.UseVisualStyleBackColor = true;
            this.aceptar_button.Visible = false;
            this.aceptar_button.Click += new System.EventHandler(this.aceptar_button_Click);
            // 
            // BuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 305);
            this.Controls.Add(this.aceptar_button);
            this.Controls.Add(this.buscar_cliente_button);
            this.Controls.Add(this.resultados_listbox);
            this.Controls.Add(this.nombre_completo_tb);
            this.Controls.Add(this.nombre_completo_cliente_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "BuscarCliente";
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
        private System.Windows.Forms.Button aceptar_button;
    }
}