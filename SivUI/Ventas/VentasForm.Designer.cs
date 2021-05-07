namespace SivUI.Ventas
{
    partial class VentasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasForm));
            this.cargar_reporte_button = new System.Windows.Forms.Button();
            this.contenedor_panel = new System.Windows.Forms.Panel();
            this.resultados_dtgv = new System.Windows.Forms.DataGridView();
            this.filtros_button = new System.Windows.Forms.Button();
            this.header_label = new System.Windows.Forms.Label();
            this.total_ganancia_tb = new System.Windows.Forms.TextBox();
            this.total_ganancia_label = new System.Windows.Forms.Label();
            this.total_ingreso_tb = new System.Windows.Forms.TextBox();
            this.total_ingreso_label = new System.Windows.Forms.Label();
            this.total_inversion_tb = new System.Windows.Forms.TextBox();
            this.total_inversion_label = new System.Windows.Forms.Label();
            this.exportar_button = new System.Windows.Forms.Button();
            this.limpiar_button = new System.Windows.Forms.Button();
            this.tarea_label = new System.Windows.Forms.Label();
            this.ventas_cantidad_tb = new System.Windows.Forms.TextBox();
            this.cantidad_ventas_label = new System.Windows.Forms.Label();
            this.contenedor_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultados_dtgv)).BeginInit();
            this.SuspendLayout();
            // 
            // cargar_reporte_button
            // 
            this.cargar_reporte_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cargar_reporte_button.Location = new System.Drawing.Point(13, 416);
            this.cargar_reporte_button.Name = "cargar_reporte_button";
            this.cargar_reporte_button.Size = new System.Drawing.Size(156, 37);
            this.cargar_reporte_button.TabIndex = 12;
            this.cargar_reporte_button.Text = "Cargar";
            this.cargar_reporte_button.UseVisualStyleBackColor = true;
            this.cargar_reporte_button.Click += new System.EventHandler(this.cargar_reporte_button_Click);
            // 
            // contenedor_panel
            // 
            this.contenedor_panel.Controls.Add(this.resultados_dtgv);
            this.contenedor_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contenedor_panel.Location = new System.Drawing.Point(13, 63);
            this.contenedor_panel.Name = "contenedor_panel";
            this.contenedor_panel.Size = new System.Drawing.Size(959, 322);
            this.contenedor_panel.TabIndex = 13;
            // 
            // resultados_dtgv
            // 
            this.resultados_dtgv.AllowUserToAddRows = false;
            this.resultados_dtgv.AllowUserToDeleteRows = false;
            this.resultados_dtgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultados_dtgv.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.resultados_dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultados_dtgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultados_dtgv.Location = new System.Drawing.Point(0, 0);
            this.resultados_dtgv.Name = "resultados_dtgv";
            this.resultados_dtgv.ReadOnly = true;
            this.resultados_dtgv.Size = new System.Drawing.Size(959, 322);
            this.resultados_dtgv.TabIndex = 0;
            this.resultados_dtgv.TabStop = false;
            // 
            // filtros_button
            // 
            this.filtros_button.ForeColor = System.Drawing.SystemColors.Desktop;
            this.filtros_button.Location = new System.Drawing.Point(13, 20);
            this.filtros_button.Name = "filtros_button";
            this.filtros_button.Size = new System.Drawing.Size(98, 37);
            this.filtros_button.TabIndex = 14;
            this.filtros_button.Text = "Filtros";
            this.filtros_button.UseVisualStyleBackColor = true;
            this.filtros_button.Click += new System.EventHandler(this.filtros_button_Click);
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.header_label.Location = new System.Drawing.Point(397, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(190, 30);
            this.header_label.TabIndex = 15;
            this.header_label.Text = "Historial de ventas";
            // 
            // total_ganancia_tb
            // 
            this.total_ganancia_tb.Location = new System.Drawing.Point(843, 416);
            this.total_ganancia_tb.Name = "total_ganancia_tb";
            this.total_ganancia_tb.ReadOnly = true;
            this.total_ganancia_tb.Size = new System.Drawing.Size(129, 33);
            this.total_ganancia_tb.TabIndex = 17;
            this.total_ganancia_tb.Text = "N/A";
            // 
            // total_ganancia_label
            // 
            this.total_ganancia_label.AutoSize = true;
            this.total_ganancia_label.Location = new System.Drawing.Point(838, 388);
            this.total_ganancia_label.Name = "total_ganancia_label";
            this.total_ganancia_label.Size = new System.Drawing.Size(134, 25);
            this.total_ganancia_label.TabIndex = 16;
            this.total_ganancia_label.Text = "Ganancia total";
            // 
            // total_ingreso_tb
            // 
            this.total_ingreso_tb.Location = new System.Drawing.Point(722, 416);
            this.total_ingreso_tb.Name = "total_ingreso_tb";
            this.total_ingreso_tb.ReadOnly = true;
            this.total_ingreso_tb.Size = new System.Drawing.Size(115, 33);
            this.total_ingreso_tb.TabIndex = 19;
            this.total_ingreso_tb.Text = "N/A";
            // 
            // total_ingreso_label
            // 
            this.total_ingreso_label.AutoSize = true;
            this.total_ingreso_label.Location = new System.Drawing.Point(717, 388);
            this.total_ingreso_label.Name = "total_ingreso_label";
            this.total_ingreso_label.Size = new System.Drawing.Size(118, 25);
            this.total_ingreso_label.TabIndex = 18;
            this.total_ingreso_label.Text = "Ingreso total";
            this.total_ingreso_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total_inversion_tb
            // 
            this.total_inversion_tb.Location = new System.Drawing.Point(587, 416);
            this.total_inversion_tb.Name = "total_inversion_tb";
            this.total_inversion_tb.ReadOnly = true;
            this.total_inversion_tb.Size = new System.Drawing.Size(129, 33);
            this.total_inversion_tb.TabIndex = 21;
            this.total_inversion_tb.Text = "N/A";
            // 
            // total_inversion_label
            // 
            this.total_inversion_label.AutoSize = true;
            this.total_inversion_label.Location = new System.Drawing.Point(582, 388);
            this.total_inversion_label.Name = "total_inversion_label";
            this.total_inversion_label.Size = new System.Drawing.Size(132, 25);
            this.total_inversion_label.TabIndex = 20;
            this.total_inversion_label.Text = "Inversión total";
            // 
            // exportar_button
            // 
            this.exportar_button.ForeColor = System.Drawing.SystemColors.Desktop;
            this.exportar_button.Location = new System.Drawing.Point(874, 20);
            this.exportar_button.Name = "exportar_button";
            this.exportar_button.Size = new System.Drawing.Size(98, 37);
            this.exportar_button.TabIndex = 22;
            this.exportar_button.Text = "Exportar";
            this.exportar_button.UseVisualStyleBackColor = true;
            this.exportar_button.Click += new System.EventHandler(this.exportar_button_Click);
            // 
            // limpiar_button
            // 
            this.limpiar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiar_button.Location = new System.Drawing.Point(175, 416);
            this.limpiar_button.Name = "limpiar_button";
            this.limpiar_button.Size = new System.Drawing.Size(156, 37);
            this.limpiar_button.TabIndex = 23;
            this.limpiar_button.Text = "Limpiar";
            this.limpiar_button.UseVisualStyleBackColor = true;
            this.limpiar_button.Click += new System.EventHandler(this.limpiar_button_Click);
            // 
            // tarea_label
            // 
            this.tarea_label.AutoSize = true;
            this.tarea_label.Location = new System.Drawing.Point(747, 26);
            this.tarea_label.Name = "tarea_label";
            this.tarea_label.Size = new System.Drawing.Size(67, 25);
            this.tarea_label.TabIndex = 24;
            this.tarea_label.Text = "[tarea]";
            this.tarea_label.Visible = false;
            // 
            // ventas_cantidad_tb
            // 
            this.ventas_cantidad_tb.Location = new System.Drawing.Point(498, 416);
            this.ventas_cantidad_tb.Name = "ventas_cantidad_tb";
            this.ventas_cantidad_tb.ReadOnly = true;
            this.ventas_cantidad_tb.Size = new System.Drawing.Size(83, 33);
            this.ventas_cantidad_tb.TabIndex = 26;
            this.ventas_cantidad_tb.Text = "N/A";
            // 
            // cantidad_ventas_label
            // 
            this.cantidad_ventas_label.AutoSize = true;
            this.cantidad_ventas_label.Location = new System.Drawing.Point(493, 388);
            this.cantidad_ventas_label.Name = "cantidad_ventas_label";
            this.cantidad_ventas_label.Size = new System.Drawing.Size(68, 25);
            this.cantidad_ventas_label.TabIndex = 25;
            this.cantidad_ventas_label.Text = "Ventas";
            // 
            // VentasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.tarea_label);
            this.Controls.Add(this.ventas_cantidad_tb);
            this.Controls.Add(this.cantidad_ventas_label);
            this.Controls.Add(this.limpiar_button);
            this.Controls.Add(this.exportar_button);
            this.Controls.Add(this.total_inversion_tb);
            this.Controls.Add(this.total_inversion_label);
            this.Controls.Add(this.total_ingreso_tb);
            this.Controls.Add(this.total_ingreso_label);
            this.Controls.Add(this.total_ganancia_tb);
            this.Controls.Add(this.total_ganancia_label);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.filtros_button);
            this.Controls.Add(this.contenedor_panel);
            this.Controls.Add(this.cargar_reporte_button);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "VentasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de ventas";
            this.contenedor_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultados_dtgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cargar_reporte_button;
        private System.Windows.Forms.Panel contenedor_panel;
        private System.Windows.Forms.DataGridView resultados_dtgv;
        private System.Windows.Forms.Button filtros_button;
        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.TextBox total_ganancia_tb;
        private System.Windows.Forms.Label total_ganancia_label;
        private System.Windows.Forms.TextBox total_ingreso_tb;
        private System.Windows.Forms.Label total_ingreso_label;
        private System.Windows.Forms.TextBox total_inversion_tb;
        private System.Windows.Forms.Label total_inversion_label;
        private System.Windows.Forms.Button exportar_button;
        private System.Windows.Forms.Button limpiar_button;
        private System.Windows.Forms.Label tarea_label;
        private System.Windows.Forms.TextBox ventas_cantidad_tb;
        private System.Windows.Forms.Label cantidad_ventas_label;
    }
}