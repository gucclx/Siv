﻿namespace SivUI
{
    partial class InventarioAgregarForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.unidades_label = new System.Windows.Forms.Label();
            this.unidades_tb = new System.Windows.Forms.TextBox();
            this.inversion_total_label = new System.Windows.Forms.Label();
            this.inversion_total_tb = new System.Windows.Forms.TextBox();
            this.inversion_unidad_label = new System.Windows.Forms.Label();
            this.inversion_unidad_tb = new System.Windows.Forms.TextBox();
            this.seleccionar_categoria_label = new System.Windows.Forms.Label();
            this.categorias_listbox = new System.Windows.Forms.ListBox();
            this.categorias_dropdown = new System.Windows.Forms.ComboBox();
            this.agregar_categoria_button = new System.Windows.Forms.Button();
            this.descripcion_unidad_label = new System.Windows.Forms.Label();
            this.descripcion_unidad_tb = new System.Windows.Forms.TextBox();
            this.precio_venta_defecto_tb = new System.Windows.Forms.TextBox();
            this.precio_venta_defecto_label = new System.Windows.Forms.Label();
            this.remover_categoria_button = new System.Windows.Forms.Button();
            this.agregar_al_inventario_button = new System.Windows.Forms.Button();
            this.nueva_categoria_linklabel = new System.Windows.Forms.LinkLabel();
            this.categorias_label = new System.Windows.Forms.Label();
            this.ultimo_producto_id_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // unidades_label
            // 
            this.unidades_label.AutoSize = true;
            this.unidades_label.Location = new System.Drawing.Point(42, 28);
            this.unidades_label.Name = "unidades_label";
            this.unidades_label.Size = new System.Drawing.Size(91, 25);
            this.unidades_label.TabIndex = 1;
            this.unidades_label.Text = "Unidades";
            // 
            // unidades_tb
            // 
            this.unidades_tb.Location = new System.Drawing.Point(47, 56);
            this.unidades_tb.Name = "unidades_tb";
            this.unidades_tb.Size = new System.Drawing.Size(125, 33);
            this.unidades_tb.TabIndex = 2;
            this.unidades_tb.TextChanged += new System.EventHandler(this.unidades_tb_TextChanged);
            // 
            // inversion_total_label
            // 
            this.inversion_total_label.AutoSize = true;
            this.inversion_total_label.Location = new System.Drawing.Point(182, 28);
            this.inversion_total_label.Name = "inversion_total_label";
            this.inversion_total_label.Size = new System.Drawing.Size(132, 25);
            this.inversion_total_label.TabIndex = 3;
            this.inversion_total_label.Text = "Inversión total";
            // 
            // inversion_total_tb
            // 
            this.inversion_total_tb.Location = new System.Drawing.Point(187, 56);
            this.inversion_total_tb.Name = "inversion_total_tb";
            this.inversion_total_tb.Size = new System.Drawing.Size(127, 33);
            this.inversion_total_tb.TabIndex = 4;
            this.inversion_total_tb.TextChanged += new System.EventHandler(this.inversion_total_tb_TextChanged);
            // 
            // inversion_unidad_label
            // 
            this.inversion_unidad_label.AutoSize = true;
            this.inversion_unidad_label.Location = new System.Drawing.Point(324, 28);
            this.inversion_unidad_label.Name = "inversion_unidad_label";
            this.inversion_unidad_label.Size = new System.Drawing.Size(187, 25);
            this.inversion_unidad_label.TabIndex = 5;
            this.inversion_unidad_label.Text = "Inversión por unidad";
            // 
            // inversion_unidad_tb
            // 
            this.inversion_unidad_tb.Location = new System.Drawing.Point(329, 56);
            this.inversion_unidad_tb.Name = "inversion_unidad_tb";
            this.inversion_unidad_tb.ReadOnly = true;
            this.inversion_unidad_tb.Size = new System.Drawing.Size(182, 33);
            this.inversion_unidad_tb.TabIndex = 6;
            this.inversion_unidad_tb.Text = "N/A";
            // 
            // seleccionar_categoria_label
            // 
            this.seleccionar_categoria_label.AutoSize = true;
            this.seleccionar_categoria_label.Location = new System.Drawing.Point(42, 109);
            this.seleccionar_categoria_label.Name = "seleccionar_categoria_label";
            this.seleccionar_categoria_label.Size = new System.Drawing.Size(193, 25);
            this.seleccionar_categoria_label.TabIndex = 8;
            this.seleccionar_categoria_label.Text = "Seleccionar categoria";
            // 
            // categorias_listbox
            // 
            this.categorias_listbox.FormattingEnabled = true;
            this.categorias_listbox.HorizontalScrollbar = true;
            this.categorias_listbox.ItemHeight = 25;
            this.categorias_listbox.Location = new System.Drawing.Point(47, 199);
            this.categorias_listbox.Name = "categorias_listbox";
            this.categorias_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categorias_listbox.Size = new System.Drawing.Size(534, 129);
            this.categorias_listbox.TabIndex = 12;
            // 
            // categorias_dropdown
            // 
            this.categorias_dropdown.FormattingEnabled = true;
            this.categorias_dropdown.Location = new System.Drawing.Point(47, 137);
            this.categorias_dropdown.Name = "categorias_dropdown";
            this.categorias_dropdown.Size = new System.Drawing.Size(534, 33);
            this.categorias_dropdown.TabIndex = 10;
            // 
            // agregar_categoria_button
            // 
            this.agregar_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_categoria_button.Location = new System.Drawing.Point(587, 134);
            this.agregar_categoria_button.Name = "agregar_categoria_button";
            this.agregar_categoria_button.Size = new System.Drawing.Size(156, 37);
            this.agregar_categoria_button.TabIndex = 11;
            this.agregar_categoria_button.Text = "Agregar categoria";
            this.agregar_categoria_button.UseVisualStyleBackColor = true;
            this.agregar_categoria_button.Click += new System.EventHandler(this.agregar_categoria_button_Click);
            // 
            // descripcion_unidad_label
            // 
            this.descripcion_unidad_label.AutoSize = true;
            this.descripcion_unidad_label.Location = new System.Drawing.Point(42, 331);
            this.descripcion_unidad_label.Name = "descripcion_unidad_label";
            this.descripcion_unidad_label.Size = new System.Drawing.Size(356, 25);
            this.descripcion_unidad_label.TabIndex = 14;
            this.descripcion_unidad_label.Text = "Descripción para cada unidad (Opcional)";
            // 
            // descripcion_unidad_tb
            // 
            this.descripcion_unidad_tb.Location = new System.Drawing.Point(47, 359);
            this.descripcion_unidad_tb.Multiline = true;
            this.descripcion_unidad_tb.Name = "descripcion_unidad_tb";
            this.descripcion_unidad_tb.Size = new System.Drawing.Size(534, 77);
            this.descripcion_unidad_tb.TabIndex = 15;
            // 
            // precio_venta_defecto_tb
            // 
            this.precio_venta_defecto_tb.Location = new System.Drawing.Point(526, 56);
            this.precio_venta_defecto_tb.Name = "precio_venta_defecto_tb";
            this.precio_venta_defecto_tb.Size = new System.Drawing.Size(217, 33);
            this.precio_venta_defecto_tb.TabIndex = 8;
            // 
            // precio_venta_defecto_label
            // 
            this.precio_venta_defecto_label.AutoSize = true;
            this.precio_venta_defecto_label.Location = new System.Drawing.Point(521, 28);
            this.precio_venta_defecto_label.Name = "precio_venta_defecto_label";
            this.precio_venta_defecto_label.Size = new System.Drawing.Size(222, 25);
            this.precio_venta_defecto_label.TabIndex = 7;
            this.precio_venta_defecto_label.Text = "Precio de venta (defecto)";
            // 
            // remover_categoria_button
            // 
            this.remover_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_categoria_button.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remover_categoria_button.Location = new System.Drawing.Point(587, 199);
            this.remover_categoria_button.Name = "remover_categoria_button";
            this.remover_categoria_button.Size = new System.Drawing.Size(156, 69);
            this.remover_categoria_button.TabIndex = 13;
            this.remover_categoria_button.Text = "Remover selección";
            this.remover_categoria_button.UseVisualStyleBackColor = true;
            this.remover_categoria_button.Click += new System.EventHandler(this.remover_categoria_button_Click);
            // 
            // agregar_al_inventario_button
            // 
            this.agregar_al_inventario_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_al_inventario_button.Location = new System.Drawing.Point(565, 512);
            this.agregar_al_inventario_button.Name = "agregar_al_inventario_button";
            this.agregar_al_inventario_button.Size = new System.Drawing.Size(207, 37);
            this.agregar_al_inventario_button.TabIndex = 17;
            this.agregar_al_inventario_button.Text = "Agregar al inventario";
            this.agregar_al_inventario_button.UseVisualStyleBackColor = true;
            this.agregar_al_inventario_button.Click += new System.EventHandler(this.agregar_al_inventario_button_Click);
            // 
            // nueva_categoria_linklabel
            // 
            this.nueva_categoria_linklabel.AutoSize = true;
            this.nueva_categoria_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nueva_categoria_linklabel.Location = new System.Drawing.Point(241, 112);
            this.nueva_categoria_linklabel.Name = "nueva_categoria_linklabel";
            this.nueva_categoria_linklabel.Size = new System.Drawing.Size(123, 21);
            this.nueva_categoria_linklabel.TabIndex = 9;
            this.nueva_categoria_linklabel.TabStop = true;
            this.nueva_categoria_linklabel.Text = "Nueva categoria";
            this.nueva_categoria_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nueva_categoria_linklabel_LinkClicked);
            // 
            // categorias_label
            // 
            this.categorias_label.AutoSize = true;
            this.categorias_label.Location = new System.Drawing.Point(42, 173);
            this.categorias_label.Name = "categorias_label";
            this.categorias_label.Size = new System.Drawing.Size(308, 25);
            this.categorias_label.TabIndex = 18;
            this.categorias_label.Text = "Categorias del producto (Opcional)";
            // 
            // ultimo_producto_id_tb
            // 
            this.ultimo_producto_id_tb.Location = new System.Drawing.Point(47, 516);
            this.ultimo_producto_id_tb.Name = "ultimo_producto_id_tb";
            this.ultimo_producto_id_tb.ReadOnly = true;
            this.ultimo_producto_id_tb.Size = new System.Drawing.Size(197, 33);
            this.ultimo_producto_id_tb.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "ID del último producto";
            // 
            // InventarioAgregarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ultimo_producto_id_tb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categorias_label);
            this.Controls.Add(this.nueva_categoria_linklabel);
            this.Controls.Add(this.agregar_al_inventario_button);
            this.Controls.Add(this.remover_categoria_button);
            this.Controls.Add(this.precio_venta_defecto_tb);
            this.Controls.Add(this.precio_venta_defecto_label);
            this.Controls.Add(this.descripcion_unidad_tb);
            this.Controls.Add(this.descripcion_unidad_label);
            this.Controls.Add(this.agregar_categoria_button);
            this.Controls.Add(this.categorias_dropdown);
            this.Controls.Add(this.categorias_listbox);
            this.Controls.Add(this.seleccionar_categoria_label);
            this.Controls.Add(this.inversion_unidad_tb);
            this.Controls.Add(this.inversion_unidad_label);
            this.Controls.Add(this.inversion_total_tb);
            this.Controls.Add(this.inversion_total_label);
            this.Controls.Add(this.unidades_tb);
            this.Controls.Add(this.unidades_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "InventarioAgregarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar al inventario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label unidades_label;
        private System.Windows.Forms.TextBox unidades_tb;
        private System.Windows.Forms.Label inversion_total_label;
        private System.Windows.Forms.TextBox inversion_total_tb;
        private System.Windows.Forms.Label inversion_unidad_label;
        private System.Windows.Forms.TextBox inversion_unidad_tb;
        private System.Windows.Forms.Label seleccionar_categoria_label;
        private System.Windows.Forms.ListBox categorias_listbox;
        private System.Windows.Forms.ComboBox categorias_dropdown;
        private System.Windows.Forms.Button agregar_categoria_button;
        private System.Windows.Forms.Label descripcion_unidad_label;
        private System.Windows.Forms.TextBox descripcion_unidad_tb;
        private System.Windows.Forms.TextBox precio_venta_defecto_tb;
        private System.Windows.Forms.Label precio_venta_defecto_label;
        private System.Windows.Forms.Button remover_categoria_button;
        private System.Windows.Forms.Button agregar_al_inventario_button;
        private System.Windows.Forms.LinkLabel nueva_categoria_linklabel;
        private System.Windows.Forms.Label categorias_label;
        private System.Windows.Forms.TextBox ultimo_producto_id_tb;
        private System.Windows.Forms.Label label1;
    }
}

