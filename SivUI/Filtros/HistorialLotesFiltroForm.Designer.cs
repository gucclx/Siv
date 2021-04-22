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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialLotesFiltroForm));
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
            this.general_groupbox = new System.Windows.Forms.GroupBox();
            this.no_incluir_lotes_sin_unidades_checkbox = new System.Windows.Forms.CheckBox();
            this.categorias_seleccionadas_label = new System.Windows.Forms.Label();
            this.categorias_seleccionadas_listbox = new System.Windows.Forms.ListBox();
            this.agregar_categorias_linklabel = new System.Windows.Forms.LinkLabel();
            this.remover_categoria_button = new System.Windows.Forms.Button();
            this.filtrar_por_producto_groupbox.SuspendLayout();
            this.filtrar_por_fechas_groupbox.SuspendLayout();
            this.general_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // filtrar_por_producto_checkbox
            // 
            this.filtrar_por_producto_checkbox.AutoSize = true;
            this.filtrar_por_producto_checkbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrar_por_producto_checkbox.Location = new System.Drawing.Point(331, 140);
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
            this.filtrar_por_producto_groupbox.Location = new System.Drawing.Point(331, 16);
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
            this.habilitar_fechas_checkbox.Location = new System.Drawing.Point(15, 140);
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
            this.filtrar_por_fechas_groupbox.Location = new System.Drawing.Point(15, 16);
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
            this.listo_button.Location = new System.Drawing.Point(546, 329);
            this.listo_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.listo_button.Name = "listo_button";
            this.listo_button.Size = new System.Drawing.Size(118, 37);
            this.listo_button.TabIndex = 44;
            this.listo_button.Text = "Listo";
            this.listo_button.UseVisualStyleBackColor = true;
            this.listo_button.Click += new System.EventHandler(this.listo_button_Click);
            // 
            // general_groupbox
            // 
            this.general_groupbox.Controls.Add(this.no_incluir_lotes_sin_unidades_checkbox);
            this.general_groupbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.general_groupbox.Location = new System.Drawing.Point(333, 203);
            this.general_groupbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.general_groupbox.Name = "general_groupbox";
            this.general_groupbox.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.general_groupbox.Size = new System.Drawing.Size(331, 118);
            this.general_groupbox.TabIndex = 47;
            this.general_groupbox.TabStop = false;
            this.general_groupbox.Text = "Generales";
            // 
            // no_incluir_lotes_sin_unidades_checkbox
            // 
            this.no_incluir_lotes_sin_unidades_checkbox.AutoSize = true;
            this.no_incluir_lotes_sin_unidades_checkbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no_incluir_lotes_sin_unidades_checkbox.Location = new System.Drawing.Point(16, 34);
            this.no_incluir_lotes_sin_unidades_checkbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.no_incluir_lotes_sin_unidades_checkbox.Name = "no_incluir_lotes_sin_unidades_checkbox";
            this.no_incluir_lotes_sin_unidades_checkbox.Size = new System.Drawing.Size(276, 25);
            this.no_incluir_lotes_sin_unidades_checkbox.TabIndex = 48;
            this.no_incluir_lotes_sin_unidades_checkbox.Text = "Solo lotes con unidades disponibles";
            this.no_incluir_lotes_sin_unidades_checkbox.UseVisualStyleBackColor = true;
            // 
            // categorias_seleccionadas_label
            // 
            this.categorias_seleccionadas_label.AutoSize = true;
            this.categorias_seleccionadas_label.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_seleccionadas_label.Location = new System.Drawing.Point(11, 184);
            this.categorias_seleccionadas_label.Name = "categorias_seleccionadas_label";
            this.categorias_seleccionadas_label.Size = new System.Drawing.Size(224, 25);
            this.categorias_seleccionadas_label.TabIndex = 49;
            this.categorias_seleccionadas_label.Text = "Categorias seleccionadas";
            // 
            // categorias_seleccionadas_listbox
            // 
            this.categorias_seleccionadas_listbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_seleccionadas_listbox.FormattingEnabled = true;
            this.categorias_seleccionadas_listbox.HorizontalScrollbar = true;
            this.categorias_seleccionadas_listbox.ItemHeight = 21;
            this.categorias_seleccionadas_listbox.Location = new System.Drawing.Point(16, 212);
            this.categorias_seleccionadas_listbox.Name = "categorias_seleccionadas_listbox";
            this.categorias_seleccionadas_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categorias_seleccionadas_listbox.Size = new System.Drawing.Size(312, 109);
            this.categorias_seleccionadas_listbox.TabIndex = 48;
            // 
            // agregar_categorias_linklabel
            // 
            this.agregar_categorias_linklabel.AutoSize = true;
            this.agregar_categorias_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregar_categorias_linklabel.Location = new System.Drawing.Point(261, 187);
            this.agregar_categorias_linklabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.agregar_categorias_linklabel.Name = "agregar_categorias_linklabel";
            this.agregar_categorias_linklabel.Size = new System.Drawing.Size(66, 21);
            this.agregar_categorias_linklabel.TabIndex = 30;
            this.agregar_categorias_linklabel.TabStop = true;
            this.agregar_categorias_linklabel.Text = "Agregar";
            this.agregar_categorias_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.agregar_categorias_linklabel_LinkClicked);
            // 
            // remover_categoria_button
            // 
            this.remover_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_categoria_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.remover_categoria_button.Location = new System.Drawing.Point(16, 327);
            this.remover_categoria_button.MaximumSize = new System.Drawing.Size(800, 600);
            this.remover_categoria_button.Name = "remover_categoria_button";
            this.remover_categoria_button.Size = new System.Drawing.Size(183, 37);
            this.remover_categoria_button.TabIndex = 50;
            this.remover_categoria_button.Text = "Remover selección";
            this.remover_categoria_button.UseVisualStyleBackColor = true;
            this.remover_categoria_button.Click += new System.EventHandler(this.remover_categoria_button_Click);
            // 
            // HistorialLotesFiltroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(675, 383);
            this.Controls.Add(this.remover_categoria_button);
            this.Controls.Add(this.agregar_categorias_linklabel);
            this.Controls.Add(this.categorias_seleccionadas_label);
            this.Controls.Add(this.categorias_seleccionadas_listbox);
            this.Controls.Add(this.general_groupbox);
            this.Controls.Add(this.listo_button);
            this.Controls.Add(this.filtrar_por_producto_checkbox);
            this.Controls.Add(this.filtrar_por_producto_groupbox);
            this.Controls.Add(this.habilitar_fechas_checkbox);
            this.Controls.Add(this.filtrar_por_fechas_groupbox);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "HistorialLotesFiltroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtros";
            this.filtrar_por_producto_groupbox.ResumeLayout(false);
            this.filtrar_por_producto_groupbox.PerformLayout();
            this.filtrar_por_fechas_groupbox.ResumeLayout(false);
            this.filtrar_por_fechas_groupbox.PerformLayout();
            this.general_groupbox.ResumeLayout(false);
            this.general_groupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.GroupBox general_groupbox;
        private System.Windows.Forms.CheckBox no_incluir_lotes_sin_unidades_checkbox;
        private System.Windows.Forms.Label categorias_seleccionadas_label;
        private System.Windows.Forms.ListBox categorias_seleccionadas_listbox;
        private System.Windows.Forms.LinkLabel agregar_categorias_linklabel;
        private System.Windows.Forms.Button remover_categoria_button;
    }
}