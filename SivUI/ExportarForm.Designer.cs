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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportarForm));
            this.exportar_lotes_button = new System.Windows.Forms.Button();
            this.exportar_ventas_button = new System.Windows.Forms.Button();
            this.tarea_label = new System.Windows.Forms.Label();
            this.exportar_inventario_button = new System.Windows.Forms.Button();
            this.header_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exportar_lotes_button
            // 
            this.exportar_lotes_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportar_lotes_button.Location = new System.Drawing.Point(12, 147);
            this.exportar_lotes_button.Name = "exportar_lotes_button";
            this.exportar_lotes_button.Size = new System.Drawing.Size(497, 37);
            this.exportar_lotes_button.TabIndex = 1;
            this.exportar_lotes_button.Text = "Exportar historial de lotes";
            this.exportar_lotes_button.UseVisualStyleBackColor = true;
            this.exportar_lotes_button.Click += new System.EventHandler(this.exportar_lotes_button_Click);
            // 
            // exportar_ventas_button
            // 
            this.exportar_ventas_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportar_ventas_button.Location = new System.Drawing.Point(12, 82);
            this.exportar_ventas_button.Name = "exportar_ventas_button";
            this.exportar_ventas_button.Size = new System.Drawing.Size(497, 37);
            this.exportar_ventas_button.TabIndex = 0;
            this.exportar_ventas_button.Text = "Exportar historial de ventas";
            this.exportar_ventas_button.UseVisualStyleBackColor = true;
            this.exportar_ventas_button.Click += new System.EventHandler(this.exportar_ventas_button_Click);
            // 
            // tarea_label
            // 
            this.tarea_label.AutoSize = true;
            this.tarea_label.Location = new System.Drawing.Point(442, 9);
            this.tarea_label.Name = "tarea_label";
            this.tarea_label.Size = new System.Drawing.Size(67, 25);
            this.tarea_label.TabIndex = 25;
            this.tarea_label.Text = "[tarea]";
            this.tarea_label.Visible = false;
            // 
            // exportar_inventario_button
            // 
            this.exportar_inventario_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportar_inventario_button.Location = new System.Drawing.Point(12, 212);
            this.exportar_inventario_button.Name = "exportar_inventario_button";
            this.exportar_inventario_button.Size = new System.Drawing.Size(497, 37);
            this.exportar_inventario_button.TabIndex = 3;
            this.exportar_inventario_button.Text = "Exportar inventario";
            this.exportar_inventario_button.UseVisualStyleBackColor = true;
            this.exportar_inventario_button.Click += new System.EventHandler(this.exportar_inventario_button_Click);
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(182, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(157, 30);
            this.header_label.TabIndex = 27;
            this.header_label.Text = "Exportar datos";
            // 
            // ExportarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(521, 331);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.tarea_label);
            this.Controls.Add(this.exportar_inventario_button);
            this.Controls.Add(this.exportar_ventas_button);
            this.Controls.Add(this.exportar_lotes_button);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "ExportarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exportar_lotes_button;
        private System.Windows.Forms.Button exportar_ventas_button;
        private System.Windows.Forms.Label tarea_label;
        private System.Windows.Forms.Button exportar_inventario_button;
        private System.Windows.Forms.Label header_label;
    }
}