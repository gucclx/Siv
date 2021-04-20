namespace SivUI
{
    partial class HistorialLotesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialLotesForm));
            this.header_label = new System.Windows.Forms.Label();
            this.tarea_label = new System.Windows.Forms.Label();
            this.exportar_button = new System.Windows.Forms.Button();
            this.filtros_button = new System.Windows.Forms.Button();
            this.resultados_dtgv = new System.Windows.Forms.DataGridView();
            this.contenedor_panel = new System.Windows.Forms.Panel();
            this.limpiar_button = new System.Windows.Forms.Button();
            this.cargar_reporte_button = new System.Windows.Forms.Button();
            this.total_inversion_tb = new System.Windows.Forms.TextBox();
            this.total_inversion_label = new System.Windows.Forms.Label();
            this.total_unidades_tb = new System.Windows.Forms.TextBox();
            this.total_unidades_label = new System.Windows.Forms.Label();
            this.valor_unidades_tb = new System.Windows.Forms.TextBox();
            this.valor_unidades_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultados_dtgv)).BeginInit();
            this.contenedor_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(387, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(211, 30);
            this.header_label.TabIndex = 16;
            this.header_label.Text = "Información de lotes";
            // 
            // tarea_label
            // 
            this.tarea_label.AutoSize = true;
            this.tarea_label.Location = new System.Drawing.Point(747, 25);
            this.tarea_label.Name = "tarea_label";
            this.tarea_label.Size = new System.Drawing.Size(67, 25);
            this.tarea_label.TabIndex = 27;
            this.tarea_label.Text = "[tarea]";
            this.tarea_label.Visible = false;
            // 
            // exportar_button
            // 
            this.exportar_button.ForeColor = System.Drawing.SystemColors.Desktop;
            this.exportar_button.Location = new System.Drawing.Point(874, 19);
            this.exportar_button.Name = "exportar_button";
            this.exportar_button.Size = new System.Drawing.Size(98, 37);
            this.exportar_button.TabIndex = 26;
            this.exportar_button.Text = "Exportar";
            this.exportar_button.UseVisualStyleBackColor = true;
            this.exportar_button.Click += new System.EventHandler(this.exportar_button_Click);
            // 
            // filtros_button
            // 
            this.filtros_button.ForeColor = System.Drawing.SystemColors.Desktop;
            this.filtros_button.Location = new System.Drawing.Point(12, 19);
            this.filtros_button.Name = "filtros_button";
            this.filtros_button.Size = new System.Drawing.Size(98, 37);
            this.filtros_button.TabIndex = 25;
            this.filtros_button.Text = "Filtros";
            this.filtros_button.UseVisualStyleBackColor = true;
            this.filtros_button.Click += new System.EventHandler(this.filtros_button_Click);
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
            this.resultados_dtgv.Size = new System.Drawing.Size(960, 323);
            this.resultados_dtgv.TabIndex = 28;
            // 
            // contenedor_panel
            // 
            this.contenedor_panel.Controls.Add(this.resultados_dtgv);
            this.contenedor_panel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedor_panel.Location = new System.Drawing.Point(12, 62);
            this.contenedor_panel.Name = "contenedor_panel";
            this.contenedor_panel.Size = new System.Drawing.Size(960, 323);
            this.contenedor_panel.TabIndex = 29;
            // 
            // limpiar_button
            // 
            this.limpiar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiar_button.Location = new System.Drawing.Point(174, 416);
            this.limpiar_button.Name = "limpiar_button";
            this.limpiar_button.Size = new System.Drawing.Size(156, 37);
            this.limpiar_button.TabIndex = 31;
            this.limpiar_button.Text = "Limpiar";
            this.limpiar_button.UseVisualStyleBackColor = true;
            this.limpiar_button.Click += new System.EventHandler(this.limpiar_button_Click);
            // 
            // cargar_reporte_button
            // 
            this.cargar_reporte_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cargar_reporte_button.Location = new System.Drawing.Point(12, 416);
            this.cargar_reporte_button.Name = "cargar_reporte_button";
            this.cargar_reporte_button.Size = new System.Drawing.Size(156, 37);
            this.cargar_reporte_button.TabIndex = 30;
            this.cargar_reporte_button.Text = "Cargar";
            this.cargar_reporte_button.UseVisualStyleBackColor = true;
            this.cargar_reporte_button.Click += new System.EventHandler(this.cargar_reporte_button_Click);
            // 
            // total_inversion_tb
            // 
            this.total_inversion_tb.Location = new System.Drawing.Point(845, 420);
            this.total_inversion_tb.Name = "total_inversion_tb";
            this.total_inversion_tb.ReadOnly = true;
            this.total_inversion_tb.Size = new System.Drawing.Size(127, 33);
            this.total_inversion_tb.TabIndex = 33;
            this.total_inversion_tb.TabStop = false;
            this.total_inversion_tb.Text = "N/A";
            // 
            // total_inversion_label
            // 
            this.total_inversion_label.AutoSize = true;
            this.total_inversion_label.Location = new System.Drawing.Point(840, 392);
            this.total_inversion_label.Name = "total_inversion_label";
            this.total_inversion_label.Size = new System.Drawing.Size(132, 25);
            this.total_inversion_label.TabIndex = 32;
            this.total_inversion_label.Text = "Inversión total";
            // 
            // total_unidades_tb
            // 
            this.total_unidades_tb.Location = new System.Drawing.Point(493, 420);
            this.total_unidades_tb.Name = "total_unidades_tb";
            this.total_unidades_tb.ReadOnly = true;
            this.total_unidades_tb.Size = new System.Drawing.Size(130, 33);
            this.total_unidades_tb.TabIndex = 35;
            this.total_unidades_tb.TabStop = false;
            this.total_unidades_tb.Text = "N/A";
            // 
            // total_unidades_label
            // 
            this.total_unidades_label.AutoSize = true;
            this.total_unidades_label.Location = new System.Drawing.Point(488, 393);
            this.total_unidades_label.Name = "total_unidades_label";
            this.total_unidades_label.Size = new System.Drawing.Size(135, 25);
            this.total_unidades_label.TabIndex = 34;
            this.total_unidades_label.Text = "Unidades disp.";
            // 
            // valor_unidades_tb
            // 
            this.valor_unidades_tb.Location = new System.Drawing.Point(629, 420);
            this.valor_unidades_tb.Name = "valor_unidades_tb";
            this.valor_unidades_tb.ReadOnly = true;
            this.valor_unidades_tb.Size = new System.Drawing.Size(210, 33);
            this.valor_unidades_tb.TabIndex = 37;
            this.valor_unidades_tb.TabStop = false;
            this.valor_unidades_tb.Text = "N/A";
            // 
            // valor_unidades_label
            // 
            this.valor_unidades_label.AutoSize = true;
            this.valor_unidades_label.Location = new System.Drawing.Point(624, 393);
            this.valor_unidades_label.Name = "valor_unidades_label";
            this.valor_unidades_label.Size = new System.Drawing.Size(215, 25);
            this.valor_unidades_label.TabIndex = 36;
            this.valor_unidades_label.Text = "Inversión unidades disp.";
            // 
            // HistorialLotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.tarea_label);
            this.Controls.Add(this.valor_unidades_tb);
            this.Controls.Add(this.valor_unidades_label);
            this.Controls.Add(this.total_unidades_tb);
            this.Controls.Add(this.total_unidades_label);
            this.Controls.Add(this.total_inversion_tb);
            this.Controls.Add(this.total_inversion_label);
            this.Controls.Add(this.limpiar_button);
            this.Controls.Add(this.cargar_reporte_button);
            this.Controls.Add(this.contenedor_panel);
            this.Controls.Add(this.exportar_button);
            this.Controls.Add(this.filtros_button);
            this.Controls.Add(this.header_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "HistorialLotesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de lotes";
            ((System.ComponentModel.ISupportInitialize)(this.resultados_dtgv)).EndInit();
            this.contenedor_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.Label tarea_label;
        private System.Windows.Forms.Button exportar_button;
        private System.Windows.Forms.Button filtros_button;
        private System.Windows.Forms.DataGridView resultados_dtgv;
        private System.Windows.Forms.Panel contenedor_panel;
        private System.Windows.Forms.Button limpiar_button;
        private System.Windows.Forms.Button cargar_reporte_button;
        private System.Windows.Forms.TextBox total_inversion_tb;
        private System.Windows.Forms.Label total_inversion_label;
        private System.Windows.Forms.TextBox total_unidades_tb;
        private System.Windows.Forms.Label total_unidades_label;
        private System.Windows.Forms.TextBox valor_unidades_tb;
        private System.Windows.Forms.Label valor_unidades_label;
    }
}