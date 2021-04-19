namespace SivUI
{
    partial class HistorialVentasFiltroForm
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
            this.listo_button = new System.Windows.Forms.Button();
            this.buscar_linklabel = new System.Windows.Forms.LinkLabel();
            this.cliente_tb = new System.Windows.Forms.TextBox();
            this.cliente_label = new System.Windows.Forms.Label();
            this.filtrar_por_producto_checkbox = new System.Windows.Forms.CheckBox();
            this.filtrar_por_producto_groupbox = new System.Windows.Forms.GroupBox();
            this.buscar_producto_linklabel = new System.Windows.Forms.LinkLabel();
            this.nombre_producto_tb = new System.Windows.Forms.TextBox();
            this.producto_nombre_label = new System.Windows.Forms.Label();
            this.filtrar_por_cliente_groupbox = new System.Windows.Forms.GroupBox();
            this.filtrar_por_cliente_checkbox = new System.Windows.Forms.CheckBox();
            this.filtrar_por_categoria_checkbox = new System.Windows.Forms.CheckBox();
            this.filtrar_por_categoria_groupbox = new System.Windows.Forms.GroupBox();
            this.categoria_nombre_tb = new System.Windows.Forms.TextBox();
            this.categoria_nombre_label = new System.Windows.Forms.Label();
            this.buscar_categoria_label = new System.Windows.Forms.LinkLabel();
            this.filtrar_por_fechas_groupbox.SuspendLayout();
            this.filtrar_por_producto_groupbox.SuspendLayout();
            this.filtrar_por_cliente_groupbox.SuspendLayout();
            this.filtrar_por_categoria_groupbox.SuspendLayout();
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
            // listo_button
            // 
            this.listo_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listo_button.Location = new System.Drawing.Point(855, 306);
            this.listo_button.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.listo_button.Name = "listo_button";
            this.listo_button.Size = new System.Drawing.Size(118, 37);
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
            this.filtrar_por_cliente_groupbox.Location = new System.Drawing.Point(639, 12);
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
            this.filtrar_por_cliente_checkbox.Location = new System.Drawing.Point(639, 136);
            this.filtrar_por_cliente_checkbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_cliente_checkbox.Name = "filtrar_por_cliente_checkbox";
            this.filtrar_por_cliente_checkbox.Size = new System.Drawing.Size(147, 25);
            this.filtrar_por_cliente_checkbox.TabIndex = 9;
            this.filtrar_por_cliente_checkbox.Text = "Filtrar por cliente";
            this.filtrar_por_cliente_checkbox.UseVisualStyleBackColor = true;
            this.filtrar_por_cliente_checkbox.CheckedChanged += new System.EventHandler(this.filtrar_por_cliente_checkbox_CheckedChanged);
            // 
            // filtrar_por_categoria_checkbox
            // 
            this.filtrar_por_categoria_checkbox.AutoSize = true;
            this.filtrar_por_categoria_checkbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrar_por_categoria_checkbox.Location = new System.Drawing.Point(12, 314);
            this.filtrar_por_categoria_checkbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_categoria_checkbox.Name = "filtrar_por_categoria_checkbox";
            this.filtrar_por_categoria_checkbox.Size = new System.Drawing.Size(166, 25);
            this.filtrar_por_categoria_checkbox.TabIndex = 47;
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
            this.filtrar_por_categoria_groupbox.Location = new System.Drawing.Point(12, 190);
            this.filtrar_por_categoria_groupbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_categoria_groupbox.Name = "filtrar_por_categoria_groupbox";
            this.filtrar_por_categoria_groupbox.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filtrar_por_categoria_groupbox.Size = new System.Drawing.Size(333, 118);
            this.filtrar_por_categoria_groupbox.TabIndex = 48;
            this.filtrar_por_categoria_groupbox.TabStop = false;
            this.filtrar_por_categoria_groupbox.Text = "Categoria";
            // 
            // categoria_nombre_tb
            // 
            this.categoria_nombre_tb.Location = new System.Drawing.Point(21, 59);
            this.categoria_nombre_tb.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.categoria_nombre_tb.Name = "categoria_nombre_tb";
            this.categoria_nombre_tb.ReadOnly = true;
            this.categoria_nombre_tb.Size = new System.Drawing.Size(290, 29);
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
            // HistorialVentasFiltroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 363);
            this.Controls.Add(this.filtrar_por_categoria_checkbox);
            this.Controls.Add(this.filtrar_por_categoria_groupbox);
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
            this.Name = "HistorialVentasFiltroForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtros";
            this.filtrar_por_fechas_groupbox.ResumeLayout(false);
            this.filtrar_por_fechas_groupbox.PerformLayout();
            this.filtrar_por_producto_groupbox.ResumeLayout(false);
            this.filtrar_por_producto_groupbox.PerformLayout();
            this.filtrar_por_cliente_groupbox.ResumeLayout(false);
            this.filtrar_por_cliente_groupbox.PerformLayout();
            this.filtrar_por_categoria_groupbox.ResumeLayout(false);
            this.filtrar_por_categoria_groupbox.PerformLayout();
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
        private System.Windows.Forms.Button listo_button;
        private System.Windows.Forms.LinkLabel buscar_linklabel;
        private System.Windows.Forms.TextBox cliente_tb;
        private System.Windows.Forms.Label cliente_label;
        private System.Windows.Forms.CheckBox filtrar_por_producto_checkbox;
        private System.Windows.Forms.GroupBox filtrar_por_producto_groupbox;
        private System.Windows.Forms.Label producto_nombre_label;
        private System.Windows.Forms.GroupBox filtrar_por_cliente_groupbox;
        private System.Windows.Forms.CheckBox filtrar_por_cliente_checkbox;
        private System.Windows.Forms.TextBox nombre_producto_tb;
        private System.Windows.Forms.LinkLabel buscar_producto_linklabel;
        private System.Windows.Forms.CheckBox filtrar_por_categoria_checkbox;
        private System.Windows.Forms.GroupBox filtrar_por_categoria_groupbox;
        private System.Windows.Forms.TextBox categoria_nombre_tb;
        private System.Windows.Forms.Label categoria_nombre_label;
        private System.Windows.Forms.LinkLabel buscar_categoria_label;
    }
}