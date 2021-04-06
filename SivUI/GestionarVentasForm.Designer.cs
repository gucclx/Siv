namespace SivUI
{
    partial class GestionarVentasForm
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
            this.fecha_inicial_dtp = new System.Windows.Forms.DateTimePicker();
            this.fecha_final_dtp = new System.Windows.Forms.DateTimePicker();
            this.fecha_inicial_label = new System.Windows.Forms.Label();
            this.fecha_final_label = new System.Windows.Forms.Label();
            this.fechas_groupbox = new System.Windows.Forms.GroupBox();
            this.habilitar_fechas_checkbox = new System.Windows.Forms.CheckBox();
            this.cargar_reporte_button = new System.Windows.Forms.Button();
            this.contenedor_panel = new System.Windows.Forms.Panel();
            this.resultados_dtgv = new System.Windows.Forms.DataGridView();
            this.fechas_groupbox.SuspendLayout();
            this.contenedor_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultados_dtgv)).BeginInit();
            this.SuspendLayout();
            // 
            // fecha_inicial_dtp
            // 
            this.fecha_inicial_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_inicial_dtp.Location = new System.Drawing.Point(16, 56);
            this.fecha_inicial_dtp.Name = "fecha_inicial_dtp";
            this.fecha_inicial_dtp.Size = new System.Drawing.Size(116, 29);
            this.fecha_inicial_dtp.TabIndex = 0;
            // 
            // fecha_final_dtp
            // 
            this.fecha_final_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_final_dtp.Location = new System.Drawing.Point(137, 56);
            this.fecha_final_dtp.Name = "fecha_final_dtp";
            this.fecha_final_dtp.Size = new System.Drawing.Size(119, 29);
            this.fecha_final_dtp.TabIndex = 1;
            // 
            // fecha_inicial_label
            // 
            this.fecha_inicial_label.AutoSize = true;
            this.fecha_inicial_label.Location = new System.Drawing.Point(11, 28);
            this.fecha_inicial_label.Name = "fecha_inicial_label";
            this.fecha_inicial_label.Size = new System.Drawing.Size(94, 21);
            this.fecha_inicial_label.TabIndex = 3;
            this.fecha_inicial_label.Text = "Fecha inicial";
            // 
            // fecha_final_label
            // 
            this.fecha_final_label.AutoSize = true;
            this.fecha_final_label.Location = new System.Drawing.Point(134, 28);
            this.fecha_final_label.Name = "fecha_final_label";
            this.fecha_final_label.Size = new System.Drawing.Size(84, 21);
            this.fecha_final_label.TabIndex = 4;
            this.fecha_final_label.Text = "Fecha final";
            // 
            // fechas_groupbox
            // 
            this.fechas_groupbox.Controls.Add(this.fecha_inicial_label);
            this.fechas_groupbox.Controls.Add(this.fecha_final_label);
            this.fechas_groupbox.Controls.Add(this.fecha_final_dtp);
            this.fechas_groupbox.Controls.Add(this.fecha_inicial_dtp);
            this.fechas_groupbox.Enabled = false;
            this.fechas_groupbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechas_groupbox.Location = new System.Drawing.Point(13, 12);
            this.fechas_groupbox.Name = "fechas_groupbox";
            this.fechas_groupbox.Size = new System.Drawing.Size(280, 107);
            this.fechas_groupbox.TabIndex = 5;
            this.fechas_groupbox.TabStop = false;
            this.fechas_groupbox.Text = "Fechas";
            // 
            // habilitar_fechas_checkbox
            // 
            this.habilitar_fechas_checkbox.AutoSize = true;
            this.habilitar_fechas_checkbox.Location = new System.Drawing.Point(297, 22);
            this.habilitar_fechas_checkbox.Name = "habilitar_fechas_checkbox";
            this.habilitar_fechas_checkbox.Size = new System.Drawing.Size(173, 29);
            this.habilitar_fechas_checkbox.TabIndex = 6;
            this.habilitar_fechas_checkbox.Text = "Filtrar por fechas";
            this.habilitar_fechas_checkbox.UseVisualStyleBackColor = true;
            this.habilitar_fechas_checkbox.CheckedChanged += new System.EventHandler(this.habilitar_fechas_checkbox_CheckedChanged);
            // 
            // cargar_reporte_button
            // 
            this.cargar_reporte_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cargar_reporte_button.Location = new System.Drawing.Point(13, 412);
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
            this.contenedor_panel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedor_panel.Location = new System.Drawing.Point(13, 125);
            this.contenedor_panel.Name = "contenedor_panel";
            this.contenedor_panel.Size = new System.Drawing.Size(959, 281);
            this.contenedor_panel.TabIndex = 13;
            // 
            // resultados_dtgv
            // 
            this.resultados_dtgv.AllowUserToAddRows = false;
            this.resultados_dtgv.AllowUserToDeleteRows = false;
            this.resultados_dtgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.resultados_dtgv.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.resultados_dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultados_dtgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultados_dtgv.Location = new System.Drawing.Point(0, 0);
            this.resultados_dtgv.Name = "resultados_dtgv";
            this.resultados_dtgv.ReadOnly = true;
            this.resultados_dtgv.Size = new System.Drawing.Size(959, 281);
            this.resultados_dtgv.TabIndex = 0;
            // 
            // GestionarVentasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.contenedor_panel);
            this.Controls.Add(this.cargar_reporte_button);
            this.Controls.Add(this.habilitar_fechas_checkbox);
            this.Controls.Add(this.fechas_groupbox);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "GestionarVentasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionar ventas";
            this.fechas_groupbox.ResumeLayout(false);
            this.fechas_groupbox.PerformLayout();
            this.contenedor_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultados_dtgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fecha_inicial_dtp;
        private System.Windows.Forms.DateTimePicker fecha_final_dtp;
        private System.Windows.Forms.Label fecha_inicial_label;
        private System.Windows.Forms.Label fecha_final_label;
        private System.Windows.Forms.GroupBox fechas_groupbox;
        private System.Windows.Forms.CheckBox habilitar_fechas_checkbox;
        private System.Windows.Forms.Button cargar_reporte_button;
        private System.Windows.Forms.Panel contenedor_panel;
        private System.Windows.Forms.DataGridView resultados_dtgv;
    }
}