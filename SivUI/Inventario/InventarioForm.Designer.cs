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
            this.contenedor_panel = new System.Windows.Forms.Panel();
            this.resultados_dtgv = new System.Windows.Forms.DataGridView();
            this.header_label = new System.Windows.Forms.Label();
            this.filtros_button = new System.Windows.Forms.Button();
            this.limpiar_button = new System.Windows.Forms.Button();
            this.cargar_reporte_button = new System.Windows.Forms.Button();
            this.tarea_label = new System.Windows.Forms.Label();
            this.contenedor_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultados_dtgv)).BeginInit();
            this.SuspendLayout();
            // 
            // contenedor_panel
            // 
            this.contenedor_panel.Controls.Add(this.resultados_dtgv);
            this.contenedor_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedor_panel.Location = new System.Drawing.Point(12, 73);
            this.contenedor_panel.Name = "contenedor_panel";
            this.contenedor_panel.Size = new System.Drawing.Size(851, 165);
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
            this.resultados_dtgv.Size = new System.Drawing.Size(851, 165);
            this.resultados_dtgv.TabIndex = 29;
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(277, 9);
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
            this.filtros_button.TabIndex = 26;
            this.filtros_button.Text = "Filtros";
            this.filtros_button.UseVisualStyleBackColor = true;
            // 
            // limpiar_button
            // 
            this.limpiar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiar_button.Location = new System.Drawing.Point(174, 244);
            this.limpiar_button.Name = "limpiar_button";
            this.limpiar_button.Size = new System.Drawing.Size(156, 37);
            this.limpiar_button.TabIndex = 33;
            this.limpiar_button.Text = "Limpiar";
            this.limpiar_button.UseVisualStyleBackColor = true;
            // 
            // cargar_reporte_button
            // 
            this.cargar_reporte_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cargar_reporte_button.Location = new System.Drawing.Point(12, 244);
            this.cargar_reporte_button.Name = "cargar_reporte_button";
            this.cargar_reporte_button.Size = new System.Drawing.Size(156, 37);
            this.cargar_reporte_button.TabIndex = 32;
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
            // InventarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(868, 502);
            this.Controls.Add(this.tarea_label);
            this.Controls.Add(this.limpiar_button);
            this.Controls.Add(this.cargar_reporte_button);
            this.Controls.Add(this.filtros_button);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.contenedor_panel);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}