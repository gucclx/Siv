namespace SivUI
{
    partial class CrearFiltroForm
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
            this.habilitar_fechas_checkbox = new System.Windows.Forms.CheckBox();
            this.filtrar_por_fechas_groupbox = new System.Windows.Forms.GroupBox();
            this.fecha_inicial_label = new System.Windows.Forms.Label();
            this.fecha_final_label = new System.Windows.Forms.Label();
            this.fecha_final_dtp = new System.Windows.Forms.DateTimePicker();
            this.fecha_inicial_dtp = new System.Windows.Forms.DateTimePicker();
            this.categorias_listbox = new System.Windows.Forms.ListBox();
            this.remover_categoria_button = new System.Windows.Forms.Button();
            this.agregar_categorias_button = new System.Windows.Forms.Button();
            this.listo_button = new System.Windows.Forms.Button();
            this.buscar_linklabel = new System.Windows.Forms.LinkLabel();
            this.cliente_tb = new System.Windows.Forms.TextBox();
            this.cliente_label = new System.Windows.Forms.Label();
            this.filtrar_por_producto_checkbox = new System.Windows.Forms.CheckBox();
            this.filtrar_por_producto_groupbox = new System.Windows.Forms.GroupBox();
            this.producto_nombre_label = new System.Windows.Forms.Label();
            this.filtrar_por_cliente_groupbox = new System.Windows.Forms.GroupBox();
            this.filtrar_por_cliente_checkbox = new System.Windows.Forms.CheckBox();
            this.categorias_label = new System.Windows.Forms.Label();
            this.nombre_producto_tb = new System.Windows.Forms.TextBox();
            this.buscar_producto_linklabel = new System.Windows.Forms.LinkLabel();
            this.filtrar_por_fechas_groupbox.SuspendLayout();
            this.filtrar_por_producto_groupbox.SuspendLayout();
            this.filtrar_por_cliente_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // habilitar_fechas_checkbox
            // 
            this.habilitar_fechas_checkbox.AutoSize = true;
            this.habilitar_fechas_checkbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.habilitar_fechas_checkbox.Location = new System.Drawing.Point(12, 136);
            this.habilitar_fechas_checkbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.habilitar_fechas_checkbox.Name = "habilitar_fechas_checkbox";
            this.habilitar_fechas_checkbox.Size = new System.Drawing.Size(146, 25);
            this.habilitar_fechas_checkbox.TabIndex = 8;
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
            this.filtrar_por_fechas_groupbox.Location = new System.Drawing.Point(12, 12);
            this.filtrar_por_fechas_groupbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_fechas_groupbox.Name = "filtrar_por_fechas_groupbox";
            this.filtrar_por_fechas_groupbox.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_fechas_groupbox.Size = new System.Drawing.Size(285, 118);
            this.filtrar_por_fechas_groupbox.TabIndex = 7;
            this.filtrar_por_fechas_groupbox.TabStop = false;
            this.filtrar_por_fechas_groupbox.Text = "Fechas";
            // 
            // fecha_inicial_label
            // 
            this.fecha_inicial_label.AutoSize = true;
            this.fecha_inicial_label.Location = new System.Drawing.Point(20, 30);
            this.fecha_inicial_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fecha_inicial_label.Name = "fecha_inicial_label";
            this.fecha_inicial_label.Size = new System.Drawing.Size(94, 21);
            this.fecha_inicial_label.TabIndex = 3;
            this.fecha_inicial_label.Text = "Fecha inicial";
            // 
            // fecha_final_label
            // 
            this.fecha_final_label.AutoSize = true;
            this.fecha_final_label.Location = new System.Drawing.Point(143, 30);
            this.fecha_final_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fecha_final_label.Name = "fecha_final_label";
            this.fecha_final_label.Size = new System.Drawing.Size(84, 21);
            this.fecha_final_label.TabIndex = 4;
            this.fecha_final_label.Text = "Fecha final";
            // 
            // fecha_final_dtp
            // 
            this.fecha_final_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_final_dtp.Location = new System.Drawing.Point(146, 59);
            this.fecha_final_dtp.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.fecha_final_dtp.Name = "fecha_final_dtp";
            this.fecha_final_dtp.Size = new System.Drawing.Size(119, 29);
            this.fecha_final_dtp.TabIndex = 1;
            // 
            // fecha_inicial_dtp
            // 
            this.fecha_inicial_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_inicial_dtp.Location = new System.Drawing.Point(25, 59);
            this.fecha_inicial_dtp.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.fecha_inicial_dtp.Name = "fecha_inicial_dtp";
            this.fecha_inicial_dtp.Size = new System.Drawing.Size(116, 29);
            this.fecha_inicial_dtp.TabIndex = 0;
            // 
            // categorias_listbox
            // 
            this.categorias_listbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_listbox.FormattingEnabled = true;
            this.categorias_listbox.HorizontalScrollbar = true;
            this.categorias_listbox.ItemHeight = 21;
            this.categorias_listbox.Location = new System.Drawing.Point(9, 271);
            this.categorias_listbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.categorias_listbox.Name = "categorias_listbox";
            this.categorias_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categorias_listbox.Size = new System.Drawing.Size(365, 172);
            this.categorias_listbox.TabIndex = 17;
            // 
            // remover_categoria_button
            // 
            this.remover_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_categoria_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.remover_categoria_button.Location = new System.Drawing.Point(186, 451);
            this.remover_categoria_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.remover_categoria_button.MaximumSize = new System.Drawing.Size(801, 600);
            this.remover_categoria_button.Name = "remover_categoria_button";
            this.remover_categoria_button.Size = new System.Drawing.Size(188, 37);
            this.remover_categoria_button.TabIndex = 23;
            this.remover_categoria_button.Text = "Remover selección";
            this.remover_categoria_button.UseVisualStyleBackColor = true;
            this.remover_categoria_button.Click += new System.EventHandler(this.remover_categoria_button_Click);
            // 
            // agregar_categorias_button
            // 
            this.agregar_categorias_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_categorias_button.Location = new System.Drawing.Point(11, 451);
            this.agregar_categorias_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.agregar_categorias_button.Name = "agregar_categorias_button";
            this.agregar_categorias_button.Size = new System.Drawing.Size(109, 37);
            this.agregar_categorias_button.TabIndex = 22;
            this.agregar_categorias_button.Text = "Agregar";
            this.agregar_categorias_button.UseVisualStyleBackColor = true;
            this.agregar_categorias_button.Click += new System.EventHandler(this.agregar_categorias_button_Click);
            // 
            // listo_button
            // 
            this.listo_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listo_button.Location = new System.Drawing.Point(863, 451);
            this.listo_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.listo_button.Name = "listo_button";
            this.listo_button.Size = new System.Drawing.Size(109, 37);
            this.listo_button.TabIndex = 24;
            this.listo_button.Text = "Listo";
            this.listo_button.UseVisualStyleBackColor = true;
            this.listo_button.Click += new System.EventHandler(this.listo_button_Click);
            // 
            // buscar_linklabel
            // 
            this.buscar_linklabel.AutoSize = true;
            this.buscar_linklabel.Location = new System.Drawing.Point(85, 31);
            this.buscar_linklabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.buscar_linklabel.Name = "buscar_linklabel";
            this.buscar_linklabel.Size = new System.Drawing.Size(56, 21);
            this.buscar_linklabel.TabIndex = 27;
            this.buscar_linklabel.TabStop = true;
            this.buscar_linklabel.Text = "Buscar";
            this.buscar_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buscar_linklabel_LinkClicked);
            // 
            // cliente_tb
            // 
            this.cliente_tb.Location = new System.Drawing.Point(17, 59);
            this.cliente_tb.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cliente_tb.Name = "cliente_tb";
            this.cliente_tb.ReadOnly = true;
            this.cliente_tb.Size = new System.Drawing.Size(300, 29);
            this.cliente_tb.TabIndex = 26;
            this.cliente_tb.TabStop = false;
            // 
            // cliente_label
            // 
            this.cliente_label.AutoSize = true;
            this.cliente_label.Location = new System.Drawing.Point(17, 31);
            this.cliente_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cliente_label.Name = "cliente_label";
            this.cliente_label.Size = new System.Drawing.Size(68, 21);
            this.cliente_label.TabIndex = 25;
            this.cliente_label.Text = "Nombre";
            // 
            // filtrar_por_producto_checkbox
            // 
            this.filtrar_por_producto_checkbox.AutoSize = true;
            this.filtrar_por_producto_checkbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrar_por_producto_checkbox.Location = new System.Drawing.Point(301, 136);
            this.filtrar_por_producto_checkbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_producto_checkbox.Name = "filtrar_por_producto_checkbox";
            this.filtrar_por_producto_checkbox.Size = new System.Drawing.Size(165, 25);
            this.filtrar_por_producto_checkbox.TabIndex = 9;
            this.filtrar_por_producto_checkbox.Text = "Filtrar por producto";
            this.filtrar_por_producto_checkbox.UseVisualStyleBackColor = true;
            this.filtrar_por_producto_checkbox.CheckedChanged += new System.EventHandler(this.filtrar_por_producto_CheckedChanged);
            // 
            // filtrar_por_producto_groupbox
            // 
            this.filtrar_por_producto_groupbox.Controls.Add(this.buscar_producto_linklabel);
            this.filtrar_por_producto_groupbox.Controls.Add(this.nombre_producto_tb);
            this.filtrar_por_producto_groupbox.Controls.Add(this.producto_nombre_label);
            this.filtrar_por_producto_groupbox.Enabled = false;
            this.filtrar_por_producto_groupbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrar_por_producto_groupbox.Location = new System.Drawing.Point(301, 12);
            this.filtrar_por_producto_groupbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_producto_groupbox.Name = "filtrar_por_producto_groupbox";
            this.filtrar_por_producto_groupbox.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_producto_groupbox.Size = new System.Drawing.Size(333, 118);
            this.filtrar_por_producto_groupbox.TabIndex = 9;
            this.filtrar_por_producto_groupbox.TabStop = false;
            this.filtrar_por_producto_groupbox.Text = "Producto";
            // 
            // producto_nombre_label
            // 
            this.producto_nombre_label.AutoSize = true;
            this.producto_nombre_label.Location = new System.Drawing.Point(18, 30);
            this.producto_nombre_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.producto_nombre_label.Name = "producto_nombre_label";
            this.producto_nombre_label.Size = new System.Drawing.Size(68, 21);
            this.producto_nombre_label.TabIndex = 9;
            this.producto_nombre_label.Text = "Nombre";
            // 
            // filtrar_por_cliente_groupbox
            // 
            this.filtrar_por_cliente_groupbox.Controls.Add(this.cliente_tb);
            this.filtrar_por_cliente_groupbox.Controls.Add(this.buscar_linklabel);
            this.filtrar_por_cliente_groupbox.Controls.Add(this.cliente_label);
            this.filtrar_por_cliente_groupbox.Enabled = false;
            this.filtrar_por_cliente_groupbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrar_por_cliente_groupbox.Location = new System.Drawing.Point(638, 12);
            this.filtrar_por_cliente_groupbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_cliente_groupbox.Name = "filtrar_por_cliente_groupbox";
            this.filtrar_por_cliente_groupbox.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_cliente_groupbox.Size = new System.Drawing.Size(334, 118);
            this.filtrar_por_cliente_groupbox.TabIndex = 33;
            this.filtrar_por_cliente_groupbox.TabStop = false;
            this.filtrar_por_cliente_groupbox.Text = "Cliente";
            // 
            // filtrar_por_cliente_checkbox
            // 
            this.filtrar_por_cliente_checkbox.AutoSize = true;
            this.filtrar_por_cliente_checkbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrar_por_cliente_checkbox.Location = new System.Drawing.Point(638, 136);
            this.filtrar_por_cliente_checkbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_cliente_checkbox.Name = "filtrar_por_cliente_checkbox";
            this.filtrar_por_cliente_checkbox.Size = new System.Drawing.Size(147, 25);
            this.filtrar_por_cliente_checkbox.TabIndex = 9;
            this.filtrar_por_cliente_checkbox.Text = "Filtrar por cliente";
            this.filtrar_por_cliente_checkbox.UseVisualStyleBackColor = true;
            this.filtrar_por_cliente_checkbox.CheckedChanged += new System.EventHandler(this.filtrar_por_cliente_checkbox_CheckedChanged);
            // 
            // categorias_label
            // 
            this.categorias_label.AutoSize = true;
            this.categorias_label.Location = new System.Drawing.Point(6, 242);
            this.categorias_label.Name = "categorias_label";
            this.categorias_label.Size = new System.Drawing.Size(215, 25);
            this.categorias_label.TabIndex = 34;
            this.categorias_label.Text = "Filtrar por las categorias";
            // 
            // nombre_producto_tb
            // 
            this.nombre_producto_tb.Location = new System.Drawing.Point(22, 59);
            this.nombre_producto_tb.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.nombre_producto_tb.Name = "nombre_producto_tb";
            this.nombre_producto_tb.ReadOnly = true;
            this.nombre_producto_tb.Size = new System.Drawing.Size(300, 29);
            this.nombre_producto_tb.TabIndex = 29;
            this.nombre_producto_tb.TabStop = false;
            // 
            // buscar_producto_linklabel
            // 
            this.buscar_producto_linklabel.AutoSize = true;
            this.buscar_producto_linklabel.Location = new System.Drawing.Point(90, 30);
            this.buscar_producto_linklabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.buscar_producto_linklabel.Name = "buscar_producto_linklabel";
            this.buscar_producto_linklabel.Size = new System.Drawing.Size(56, 21);
            this.buscar_producto_linklabel.TabIndex = 28;
            this.buscar_producto_linklabel.TabStop = true;
            this.buscar_producto_linklabel.Text = "Buscar";
            this.buscar_producto_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buscar_producto_linklabel_LinkClicked);
            // 
            // CrearFiltroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 501);
            this.Controls.Add(this.categorias_label);
            this.Controls.Add(this.categorias_listbox);
            this.Controls.Add(this.agregar_categorias_button);
            this.Controls.Add(this.remover_categoria_button);
            this.Controls.Add(this.filtrar_por_cliente_checkbox);
            this.Controls.Add(this.filtrar_por_producto_checkbox);
            this.Controls.Add(this.filtrar_por_cliente_groupbox);
            this.Controls.Add(this.filtrar_por_producto_groupbox);
            this.Controls.Add(this.habilitar_fechas_checkbox);
            this.Controls.Add(this.listo_button);
            this.Controls.Add(this.filtrar_por_fechas_groupbox);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "CrearFiltroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajuste de filtros";
            this.filtrar_por_fechas_groupbox.ResumeLayout(false);
            this.filtrar_por_fechas_groupbox.PerformLayout();
            this.filtrar_por_producto_groupbox.ResumeLayout(false);
            this.filtrar_por_producto_groupbox.PerformLayout();
            this.filtrar_por_cliente_groupbox.ResumeLayout(false);
            this.filtrar_por_cliente_groupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox habilitar_fechas_checkbox;
        private System.Windows.Forms.GroupBox filtrar_por_fechas_groupbox;
        private System.Windows.Forms.Label fecha_inicial_label;
        private System.Windows.Forms.Label fecha_final_label;
        private System.Windows.Forms.DateTimePicker fecha_final_dtp;
        private System.Windows.Forms.DateTimePicker fecha_inicial_dtp;
        private System.Windows.Forms.ListBox categorias_listbox;
        private System.Windows.Forms.Button remover_categoria_button;
        private System.Windows.Forms.Button agregar_categorias_button;
        private System.Windows.Forms.Button listo_button;
        private System.Windows.Forms.LinkLabel buscar_linklabel;
        private System.Windows.Forms.TextBox cliente_tb;
        private System.Windows.Forms.Label cliente_label;
        private System.Windows.Forms.CheckBox filtrar_por_producto_checkbox;
        private System.Windows.Forms.GroupBox filtrar_por_producto_groupbox;
        private System.Windows.Forms.Label producto_nombre_label;
        private System.Windows.Forms.GroupBox filtrar_por_cliente_groupbox;
        private System.Windows.Forms.CheckBox filtrar_por_cliente_checkbox;
        private System.Windows.Forms.Label categorias_label;
        private System.Windows.Forms.TextBox nombre_producto_tb;
        private System.Windows.Forms.LinkLabel buscar_producto_linklabel;
    }
}