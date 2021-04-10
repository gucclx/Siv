namespace SivUI
{
    partial class ExportarForm
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
            this.filtros_button = new System.Windows.Forms.Button();
            this.exportar_inventario_button = new System.Windows.Forms.Button();
            this.exportar_ventas_button = new System.Windows.Forms.Button();
            this.exportando_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // filtros_button
            // 
            this.filtros_button.ForeColor = System.Drawing.SystemColors.Desktop;
            this.filtros_button.Location = new System.Drawing.Point(12, 12);
            this.filtros_button.Name = "filtros_button";
            this.filtros_button.Size = new System.Drawing.Size(98, 37);
            this.filtros_button.TabIndex = 15;
            this.filtros_button.Text = "Filtros";
            this.filtros_button.UseVisualStyleBackColor = true;
            this.filtros_button.Click += new System.EventHandler(this.filtros_button_Click);
            // 
            // exportar_inventario_button
            // 
            this.exportar_inventario_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportar_inventario_button.Location = new System.Drawing.Point(12, 125);
            this.exportar_inventario_button.Name = "exportar_inventario_button";
            this.exportar_inventario_button.Size = new System.Drawing.Size(497, 37);
            this.exportar_inventario_button.TabIndex = 16;
            this.exportar_inventario_button.Text = "Exportar inventario";
            this.exportar_inventario_button.UseVisualStyleBackColor = true;
            this.exportar_inventario_button.Click += new System.EventHandler(this.exportar_inventario_button_Click);
            // 
            // exportar_ventas_button
            // 
            this.exportar_ventas_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportar_ventas_button.Location = new System.Drawing.Point(12, 168);
            this.exportar_ventas_button.Name = "exportar_ventas_button";
            this.exportar_ventas_button.Size = new System.Drawing.Size(497, 37);
            this.exportar_ventas_button.TabIndex = 17;
            this.exportar_ventas_button.Text = "Exportar ventas";
            this.exportar_ventas_button.UseVisualStyleBackColor = true;
            this.exportar_ventas_button.Click += new System.EventHandler(this.exportar_ventas_button_Click);
            // 
            // exportando_label
            // 
            this.exportando_label.AutoSize = true;
            this.exportando_label.Location = new System.Drawing.Point(200, 18);
            this.exportando_label.Name = "exportando_label";
            this.exportando_label.Size = new System.Drawing.Size(121, 25);
            this.exportando_label.TabIndex = 25;
            this.exportando_label.Text = "Exportando...";
            this.exportando_label.Visible = false;
            // 
            // ExportarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 331);
            this.Controls.Add(this.exportando_label);
            this.Controls.Add(this.exportar_ventas_button);
            this.Controls.Add(this.exportar_inventario_button);
            this.Controls.Add(this.filtros_button);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ExportarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button filtros_button;
        private System.Windows.Forms.Button exportar_inventario_button;
        private System.Windows.Forms.Button exportar_ventas_button;
        private System.Windows.Forms.Label exportando_label;
    }
}