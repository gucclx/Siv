namespace SivUI.Inventario
{
    partial class InventarioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventarioForm));
            this.contenedor_panel = new System.Windows.Forms.Panel();
            this.resultados_dtgv = new System.Windows.Forms.DataGridView();
            this.header_label = new System.Windows.Forms.Label();
            this.filtros_button = new System.Windows.Forms.Button();
            this.limpiar_button = new System.Windows.Forms.Button();
            this.cargar_reporte_button = new System.Windows.Forms.Button();
            this.tarea_label = new System.Windows.Forms.Label();
            this.unidades_tb = new System.Windows.Forms.TextBox();
            this.total_unidades_label = new System.Windows.Forms.Label();
            this.inversion_tb = new System.Windows.Forms.TextBox();
            this.inversion_label = new System.Windows.Forms.Label();
            this.exportar_button = new System.Windows.Forms.Button();
            this.productos_tb = new System.Windows.Forms.TextBox();
            this.productos_label = new System.Windows.Forms.Label();
            this.contenedor_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultados_dtgv)).BeginInit();
            this.SuspendLayout();
            // 
            // contenedor_panel
            // 
            this.contenedor_panel.Controls.Add(this.resultados_dtgv);
            this.contenedor_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.contenedor_panel.Location = new System.Drawing.Point(12, 55);
            this.contenedor_panel.Name = "contenedor_panel";
            this.contenedor_panel.Size = new System.Drawing.Size(844, 370);
            this.contenedor_panel.TabIndex = 0;
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
            this.resultados_dtgv.Size = new System.Drawing.Size(844, 370);
            this.resultados_dtgv.TabIndex = 29;
            this.resultados_dtgv.TabStop = false;
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.header_label.Location = new System.Drawing.Point(379, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(110, 30);
            this.header_label.TabIndex = 17;
            this.header_label.Text = "Inventario";
            // 
            // filtros_button
            // 
            this.filtros_button.ForeColor = System.Drawing.SystemColors.Desktop;
            this.filtros_button.Location = new System.Drawing.Point(12, 12);
            this.filtros_button.Name = "filtros_button";
            this.filtros_button.Size = new System.Drawing.Size(98, 37);
            this.filtros_button.TabIndex = 0;
            this.filtros_button.Text = "Filtros";
            this.filtros_button.UseVisualStyleBackColor = true;
            this.filtros_button.Click += new System.EventHandler(this.filtros_button_Click);
            // 
            // limpiar_button
            // 
            this.limpiar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiar_button.Location = new System.Drawing.Point(174, 453);
            this.limpiar_button.Name = "limpiar_button";
            this.limpiar_button.Size = new System.Drawing.Size(156, 37);
            this.limpiar_button.TabIndex = 3;
            this.limpiar_button.Text = "Limpiar";
            this.limpiar_button.UseVisualStyleBackColor = true;
            this.limpiar_button.Click += new System.EventHandler(this.limpiar_button_Click);
            // 
            // cargar_reporte_button
            // 
            this.cargar_reporte_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cargar_reporte_button.Location = new System.Drawing.Point(12, 453);
            this.cargar_reporte_button.Name = "cargar_reporte_button";
            this.cargar_reporte_button.Size = new System.Drawing.Size(156, 37);
            this.cargar_reporte_button.TabIndex = 2;
            this.cargar_reporte_button.Text = "Cargar";
            this.cargar_reporte_button.UseVisualStyleBackColor = true;
            this.cargar_reporte_button.Click += new System.EventHandler(this.cargar_reporte_button_Click);
            // 
            // tarea_label
            // 
            this.tarea_label.AutoSize = true;
            this.tarea_label.Location = new System.Drawing.Point(586, 18);
            this.tarea_label.Name = "tarea_label";
            this.tarea_label.Size = new System.Drawing.Size(67, 25);
            this.tarea_label.TabIndex = 34;
            this.tarea_label.Text = "[tarea]";
            this.tarea_label.Visible = false;
            // 
            // unidades_tb
            // 
            this.unidades_tb.Location = new System.Drawing.Point(557, 456);
            this.unidades_tb.Name = "unidades_tb";
            this.unidades_tb.ReadOnly = true;
            this.unidades_tb.Size = new System.Drawing.Size(129, 33);
            this.unidades_tb.TabIndex = 5;
            this.unidades_tb.Text = "N/A";
            // 
            // total_unidades_label
            // 
            this.total_unidades_label.AutoSize = true;
            this.total_unidades_label.Location = new System.Drawing.Point(552, 428);
            this.total_unidades_label.Name = "total_unidades_label";
            this.total_unidades_label.Size = new System.Drawing.Size(91, 25);
            this.total_unidades_label.TabIndex = 37;
            this.total_unidades_label.Text = "Unidades";
            // 
            // inversion_tb
            // 
            this.inversion_tb.Location = new System.Drawing.Point(692, 456);
            this.inversion_tb.Name = "inversion_tb";
            this.inversion_tb.ReadOnly = true;
            this.inversion_tb.Size = new System.Drawing.Size(164, 33);
            this.inversion_tb.TabIndex = 6;
            this.inversion_tb.Text = "N/A";
            // 
            // inversion_label
            // 
            this.inversion_label.AutoSize = true;
            this.inversion_label.Location = new System.Drawing.Point(687, 428);
            this.inversion_label.Name = "inversion_label";
            this.inversion_label.Size = new System.Drawing.Size(173, 25);
            this.inversion_label.TabIndex = 35;
            this.inversion_label.Text = "Inversión Unidades";
            // 
            // exportar_button
            // 
            this.exportar_button.ForeColor = System.Drawing.SystemColors.Desktop;
            this.exportar_button.Location = new System.Drawing.Point(758, 12);
            this.exportar_button.Name = "exportar_button";
            this.exportar_button.Size = new System.Drawing.Size(98, 37);
            this.exportar_button.TabIndex = 1;
            this.exportar_button.Text = "Exportar";
            this.exportar_button.UseVisualStyleBackColor = true;
            this.exportar_button.Click += new System.EventHandler(this.exportar_button_Click);
            // 
            // productos_tb
            // 
            this.productos_tb.Location = new System.Drawing.Point(459, 456);
            this.productos_tb.Name = "productos_tb";
            this.productos_tb.ReadOnly = true;
            this.productos_tb.Size = new System.Drawing.Size(92, 33);
            this.productos_tb.TabIndex = 4;
            this.productos_tb.Text = "N/A";
            // 
            // productos_label
            // 
            this.productos_label.AutoSize = true;
            this.productos_label.Location = new System.Drawing.Point(454, 428);
            this.productos_label.Name = "productos_label";
            this.productos_label.Size = new System.Drawing.Size(97, 25);
            this.productos_label.TabIndex = 39;
            this.productos_label.Text = "Productos";
            // 
            // InventarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(868, 502);
            this.Controls.Add(this.tarea_label);
            this.Controls.Add(this.productos_tb);
            this.Controls.Add(this.productos_label);
            this.Controls.Add(this.exportar_button);
            this.Controls.Add(this.unidades_tb);
            this.Controls.Add(this.total_unidades_label);
            this.Controls.Add(this.inversion_tb);
            this.Controls.Add(this.inversion_label);
            this.Controls.Add(this.limpiar_button);
            this.Controls.Add(this.cargar_reporte_button);
            this.Controls.Add(this.filtros_button);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.contenedor_panel);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "InventarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.contenedor_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultados_dtgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel contenedor_panel;
        private System.Windows.Forms.DataGridView resultados_dtgv;
        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.Button filtros_button;
        private System.Windows.Forms.Button limpiar_button;
        private System.Windows.Forms.Button cargar_reporte_button;
        private System.Windows.Forms.Label tarea_label;
        private System.Windows.Forms.TextBox unidades_tb;
        private System.Windows.Forms.Label total_unidades_label;
        private System.Windows.Forms.TextBox inversion_tb;
        private System.Windows.Forms.Label inversion_label;
        private System.Windows.Forms.Button exportar_button;
        private System.Windows.Forms.TextBox productos_tb;
        private System.Windows.Forms.Label productos_label;
    }
}