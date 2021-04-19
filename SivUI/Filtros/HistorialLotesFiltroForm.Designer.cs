namespace SivUI.Filtros
{
    partial class HistorialLotesFiltroForm
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
            this.buscar_categoria_label = new System.Windows.Forms.LinkLabel();
            this.filtrar_por_producto_checkbox = new System.Windows.Forms.CheckBox();
            this.filtrar_por_producto_groupbox = new System.Windows.Forms.GroupBox();
            this.buscar_producto_linklabel = new System.Windows.Forms.LinkLabel();
            this.nombre_producto_tb = new System.Windows.Forms.TextBox();
            this.producto_nombre_label = new System.Windows.Forms.Label();
            this.habilitar_fechas_checkbox = new System.Windows.Forms.CheckBox();
            this.filtrar_por_fechas_groupbox = new System.Windows.Forms.GroupBox();
            this.fecha_inicial_label = new System.Windows.Forms.Label();
            this.fecha_final_label = new System.Windows.Forms.Label();
            this.fecha_final_dtp = new System.Windows.Forms.DateTimePicker();
            this.fecha_inicial_dtp = new System.Windows.Forms.DateTimePicker();
            this.listo_button = new System.Windows.Forms.Button();
            this.filtrar_por_categoria_checkbox = new System.Windows.Forms.CheckBox();
            this.filtrar_por_categoria_groupbox = new System.Windows.Forms.GroupBox();
            this.categoria_nombre_tb = new System.Windows.Forms.TextBox();
            this.categoria_nombre_label = new System.Windows.Forms.Label();
            this.general_groupbox = new System.Windows.Forms.GroupBox();
            this.lotes_sin_unidades_checkbox = new System.Windows.Forms.CheckBox();
            this.filtrar_por_producto_groupbox.SuspendLayout();
            this.filtrar_por_fechas_groupbox.SuspendLayout();
            this.filtrar_por_categoria_groupbox.SuspendLayout();
            this.general_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buscar_categoria_label
            // 
            this.buscar_categoria_label.AutoSize = true;
            this.buscar_categoria_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_categoria_label.Location = new System.Drawing.Point(89, 34);
            this.buscar_categoria_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.buscar_categoria_label.Name = "buscar_categoria_label";
            this.buscar_categoria_label.Size = new System.Drawing.Size(56, 21);
            this.buscar_categoria_label.TabIndex = 42;
            this.buscar_categoria_label.TabStop = true;
            this.buscar_categoria_label.Text = "Buscar";
            this.buscar_categoria_label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buscar_categoria_label_LinkClicked);
            // 
            // filtrar_por_producto_checkbox
            // 
            this.filtrar_por_producto_checkbox.AutoSize = true;
            this.filtrar_por_producto_checkbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrar_por_producto_checkbox.Location = new System.Drawing.Point(329, 137);
            this.filtrar_por_producto_checkbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_producto_checkbox.Name = "filtrar_por_producto_checkbox";
            this.filtrar_por_producto_checkbox.Size = new System.Drawing.Size(165, 25);
            this.filtrar_por_producto_checkbox.TabIndex = 37;
            this.filtrar_por_producto_checkbox.Text = "Filtrar por producto";
            this.filtrar_por_producto_checkbox.UseVisualStyleBackColor = true;
            this.filtrar_por_producto_checkbox.CheckedChanged += new System.EventHandler(this.filtrar_por_producto_checkbox_CheckedChanged);
            // 
            // filtrar_por_producto_groupbox
            // 
            this.filtrar_por_producto_groupbox.Controls.Add(this.buscar_producto_linklabel);
            this.filtrar_por_producto_groupbox.Controls.Add(this.nombre_producto_tb);
            this.filtrar_por_producto_groupbox.Controls.Add(this.producto_nombre_label);
            this.filtrar_por_producto_groupbox.Enabled = false;
            this.filtrar_por_producto_groupbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrar_por_producto_groupbox.Location = new System.Drawing.Point(329, 13);
            this.filtrar_por_producto_groupbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_producto_groupbox.Name = "filtrar_por_producto_groupbox";
            this.filtrar_por_producto_groupbox.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_producto_groupbox.Size = new System.Drawing.Size(333, 118);
            this.filtrar_por_producto_groupbox.TabIndex = 38;
            this.filtrar_por_producto_groupbox.TabStop = false;
            this.filtrar_por_producto_groupbox.Text = "Producto";
            // 
            // buscar_producto_linklabel
            // 
            this.buscar_producto_linklabel.AutoSize = true;
            this.buscar_producto_linklabel.Location = new System.Drawing.Point(86, 34);
            this.buscar_producto_linklabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.buscar_producto_linklabel.Name = "buscar_producto_linklabel";
            this.buscar_producto_linklabel.Size = new System.Drawing.Size(56, 21);
            this.buscar_producto_linklabel.TabIndex = 28;
            this.buscar_producto_linklabel.TabStop = true;
            this.buscar_producto_linklabel.Text = "Buscar";
            this.buscar_producto_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buscar_producto_linklabel_LinkClicked);
            // 
            // nombre_producto_tb
            // 
            this.nombre_producto_tb.Location = new System.Drawing.Point(18, 59);
            this.nombre_producto_tb.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.nombre_producto_tb.Name = "nombre_producto_tb";
            this.nombre_producto_tb.ReadOnly = true;
            this.nombre_producto_tb.Size = new System.Drawing.Size(296, 29);
            this.nombre_producto_tb.TabIndex = 29;
            this.nombre_producto_tb.TabStop = false;
            // 
            // producto_nombre_label
            // 
            this.producto_nombre_label.AutoSize = true;
            this.producto_nombre_label.Location = new System.Drawing.Point(14, 34);
            this.producto_nombre_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.producto_nombre_label.Name = "producto_nombre_label";
            this.producto_nombre_label.Size = new System.Drawing.Size(68, 21);
            this.producto_nombre_label.TabIndex = 9;
            this.producto_nombre_label.Text = "Nombre";
            // 
            // habilitar_fechas_checkbox
            // 
            this.habilitar_fechas_checkbox.AutoSize = true;
            this.habilitar_fechas_checkbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.habilitar_fechas_checkbox.Location = new System.Drawing.Point(13, 137);
            this.habilitar_fechas_checkbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.habilitar_fechas_checkbox.Name = "habilitar_fechas_checkbox";
            this.habilitar_fechas_checkbox.Size = new System.Drawing.Size(146, 25);
            this.habilitar_fechas_checkbox.TabIndex = 36;
            this.habilitar_fechas_checkbox.Text = "Filtrar por fechas";
            this.habilitar_fechas_checkbox.UseVisualStyleBackColor = true;
            this.habilitar_fechas_checkbox.CheckedChanged += new System.EventHandler(this.habilitar_fechas_checkbox_CheckedChanged);
            // 
            // filtrar_por_fechas_groupbox
            // 
            this.filtrar_por_fechas_groupbox.Controls.Add(this.fecha_inicial_label);
            this.filtrar_por_fechas_groupbox.Controls.Add(this.fecha_final_label);
            this.filtrar_por_fechas_groupbox.Controls.Add(this.fecha_final_dtp);
            this.filtrar_por_fechas_groupbox.Controls.Add(this.fecha_inicial_dtp);
            this.filtrar_por_fechas_groupbox.Enabled = false;
            this.filtrar_por_fechas_groupbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrar_por_fechas_groupbox.Location = new System.Drawing.Point(13, 13);
            this.filtrar_por_fechas_groupbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_fechas_groupbox.Name = "filtrar_por_fechas_groupbox";
            this.filtrar_por_fechas_groupbox.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_fechas_groupbox.Size = new System.Drawing.Size(312, 118);
            this.filtrar_por_fechas_groupbox.TabIndex = 35;
            this.filtrar_por_fechas_groupbox.TabStop = false;
            this.filtrar_por_fechas_groupbox.Text = "Fechas";
            // 
            // fecha_inicial_label
            // 
            this.fecha_inicial_label.AutoSize = true;
            this.fecha_inicial_label.Location = new System.Drawing.Point(34, 30);
            this.fecha_inicial_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fecha_inicial_label.Name = "fecha_inicial_label";
            this.fecha_inicial_label.Size = new System.Drawing.Size(94, 21);
            this.fecha_inicial_label.TabIndex = 3;
            this.fecha_inicial_label.Text = "Fecha inicial";
            // 
            // fecha_final_label
            // 
            this.fecha_final_label.AutoSize = true;
            this.fecha_final_label.Location = new System.Drawing.Point(157, 30);
            this.fecha_final_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fecha_final_label.Name = "fecha_final_label";
            this.fecha_final_label.Size = new System.Drawing.Size(84, 21);
            this.fecha_final_label.TabIndex = 4;
            this.fecha_final_label.Text = "Fecha final";
            // 
            // fecha_final_dtp
            // 
            this.fecha_final_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_final_dtp.Location = new System.Drawing.Point(160, 59);
            this.fecha_final_dtp.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.fecha_final_dtp.Name = "fecha_final_dtp";
            this.fecha_final_dtp.Size = new System.Drawing.Size(119, 29);
            this.fecha_final_dtp.TabIndex = 1;
            // 
            // fecha_inicial_dtp
            // 
            this.fecha_inicial_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_inicial_dtp.Location = new System.Drawing.Point(39, 59);
            this.fecha_inicial_dtp.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.fecha_inicial_dtp.Name = "fecha_inicial_dtp";
            this.fecha_inicial_dtp.Size = new System.Drawing.Size(116, 29);
            this.fecha_inicial_dtp.TabIndex = 0;
            // 
            // listo_button
            // 
            this.listo_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listo_button.Location = new System.Drawing.Point(544, 351);
            this.listo_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.listo_button.Name = "listo_button";
            this.listo_button.Size = new System.Drawing.Size(118, 37);
            this.listo_button.TabIndex = 44;
            this.listo_button.Text = "Listo";
            this.listo_button.UseVisualStyleBackColor = true;
            this.listo_button.Click += new System.EventHandler(this.listo_button_Click);
            // 
            // filtrar_por_categoria_checkbox
            // 
            this.filtrar_por_categoria_checkbox.AutoSize = true;
            this.filtrar_por_categoria_checkbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrar_por_categoria_checkbox.Location = new System.Drawing.Point(13, 324);
            this.filtrar_por_categoria_checkbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_categoria_checkbox.Name = "filtrar_por_categoria_checkbox";
            this.filtrar_por_categoria_checkbox.Size = new System.Drawing.Size(166, 25);
            this.filtrar_por_categoria_checkbox.TabIndex = 45;
            this.filtrar_por_categoria_checkbox.Text = "Filtrar por categoria";
            this.filtrar_por_categoria_checkbox.UseVisualStyleBackColor = true;
            this.filtrar_por_categoria_checkbox.CheckedChanged += new System.EventHandler(this.filtrar_por_categoria_checkbox_CheckedChanged);
            // 
            // filtrar_por_categoria_groupbox
            // 
            this.filtrar_por_categoria_groupbox.Controls.Add(this.categoria_nombre_tb);
            this.filtrar_por_categoria_groupbox.Controls.Add(this.categoria_nombre_label);
            this.filtrar_por_categoria_groupbox.Controls.Add(this.buscar_categoria_label);
            this.filtrar_por_categoria_groupbox.Enabled = false;
            this.filtrar_por_categoria_groupbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrar_por_categoria_groupbox.Location = new System.Drawing.Point(13, 200);
            this.filtrar_por_categoria_groupbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_categoria_groupbox.Name = "filtrar_por_categoria_groupbox";
            this.filtrar_por_categoria_groupbox.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_categoria_groupbox.Size = new System.Drawing.Size(312, 118);
            this.filtrar_por_categoria_groupbox.TabIndex = 46;
            this.filtrar_por_categoria_groupbox.TabStop = false;
            this.filtrar_por_categoria_groupbox.Text = "Categoria";
            // 
            // categoria_nombre_tb
            // 
            this.categoria_nombre_tb.Location = new System.Drawing.Point(18, 59);
            this.categoria_nombre_tb.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.categoria_nombre_tb.Name = "categoria_nombre_tb";
            this.categoria_nombre_tb.ReadOnly = true;
            this.categoria_nombre_tb.Size = new System.Drawing.Size(277, 29);
            this.categoria_nombre_tb.TabIndex = 29;
            this.categoria_nombre_tb.TabStop = false;
            // 
            // categoria_nombre_label
            // 
            this.categoria_nombre_label.AutoSize = true;
            this.categoria_nombre_label.Location = new System.Drawing.Point(17, 34);
            this.categoria_nombre_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.categoria_nombre_label.Name = "categoria_nombre_label";
            this.categoria_nombre_label.Size = new System.Drawing.Size(68, 21);
            this.categoria_nombre_label.TabIndex = 9;
            this.categoria_nombre_label.Text = "Nombre";
            // 
            // general_groupbox
            // 
            this.general_groupbox.Controls.Add(this.lotes_sin_unidades_checkbox);
            this.general_groupbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.general_groupbox.Location = new System.Drawing.Point(331, 200);
            this.general_groupbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.general_groupbox.Name = "general_groupbox";
            this.general_groupbox.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.general_groupbox.Size = new System.Drawing.Size(331, 118);
            this.general_groupbox.TabIndex = 47;
            this.general_groupbox.TabStop = false;
            this.general_groupbox.Text = "Generales";
            // 
            // lotes_sin_unidades_checkbox
            // 
            this.lotes_sin_unidades_checkbox.AutoSize = true;
            this.lotes_sin_unidades_checkbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lotes_sin_unidades_checkbox.Location = new System.Drawing.Point(16, 34);
            this.lotes_sin_unidades_checkbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.lotes_sin_unidades_checkbox.Name = "lotes_sin_unidades_checkbox";
            this.lotes_sin_unidades_checkbox.Size = new System.Drawing.Size(276, 25);
            this.lotes_sin_unidades_checkbox.TabIndex = 48;
            this.lotes_sin_unidades_checkbox.Text = "Solo lotes con unidades disponibles";
            this.lotes_sin_unidades_checkbox.UseVisualStyleBackColor = true;
            // 
            // HistorialLotesFiltroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(673, 401);
            this.Controls.Add(this.general_groupbox);
            this.Controls.Add(this.filtrar_por_categoria_checkbox);
            this.Controls.Add(this.filtrar_por_categoria_groupbox);
            this.Controls.Add(this.listo_button);
            this.Controls.Add(this.filtrar_por_producto_checkbox);
            this.Controls.Add(this.filtrar_por_producto_groupbox);
            this.Controls.Add(this.habilitar_fechas_checkbox);
            this.Controls.Add(this.filtrar_por_fechas_groupbox);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "HistorialLotesFiltroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtros";
            this.filtrar_por_producto_groupbox.ResumeLayout(false);
            this.filtrar_por_producto_groupbox.PerformLayout();
            this.filtrar_por_fechas_groupbox.ResumeLayout(false);
            this.filtrar_por_fechas_groupbox.PerformLayout();
            this.filtrar_por_categoria_groupbox.ResumeLayout(false);
            this.filtrar_por_categoria_groupbox.PerformLayout();
            this.general_groupbox.ResumeLayout(false);
            this.general_groupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel buscar_categoria_label;
        private System.Windows.Forms.CheckBox filtrar_por_producto_checkbox;
        private System.Windows.Forms.GroupBox filtrar_por_producto_groupbox;
        private System.Windows.Forms.LinkLabel buscar_producto_linklabel;
        private System.Windows.Forms.TextBox nombre_producto_tb;
        private System.Windows.Forms.Label producto_nombre_label;
        private System.Windows.Forms.CheckBox habilitar_fechas_checkbox;
        private System.Windows.Forms.GroupBox filtrar_por_fechas_groupbox;
        private System.Windows.Forms.Label fecha_inicial_label;
        private System.Windows.Forms.Label fecha_final_label;
        private System.Windows.Forms.DateTimePicker fecha_final_dtp;
        private System.Windows.Forms.DateTimePicker fecha_inicial_dtp;
        private System.Windows.Forms.Button listo_button;
        private System.Windows.Forms.CheckBox filtrar_por_categoria_checkbox;
        private System.Windows.Forms.GroupBox filtrar_por_categoria_groupbox;
        private System.Windows.Forms.TextBox categoria_nombre_tb;
        private System.Windows.Forms.Label categoria_nombre_label;
        private System.Windows.Forms.GroupBox general_groupbox;
        private System.Windows.Forms.CheckBox lotes_sin_unidades_checkbox;
    }
}