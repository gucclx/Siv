namespace SivUI
{
    partial class CrearProductoForm
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
            this.header_label = new System.Windows.Forms.Label();
            this.nombre_producto_tb = new System.Windows.Forms.TextBox();
            this.producto_nombre_label = new System.Windows.Forms.Label();
            this.nueva_categoria_linklabel = new System.Windows.Forms.LinkLabel();
            this.categorias_disponibles_dropdown = new System.Windows.Forms.ComboBox();
            this.seleccionar_categorias_label = new System.Windows.Forms.Label();
            this.categorias_seleccionadas_listbox = new System.Windows.Forms.ListBox();
            this.agregar_categoria_button = new System.Windows.Forms.Button();
            this.remover_categoria_button = new System.Windows.Forms.Button();
            this.crear_producto_button = new System.Windows.Forms.Button();
            this.descripcion_tb = new System.Windows.Forms.TextBox();
            this.descripcion_label = new System.Windows.Forms.Label();
            this.categorias_seleccionadas_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(274, 24);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(231, 30);
            this.header_label.TabIndex = 2;
            this.header_label.Text = "Creación de productos";
            // 
            // nombre_producto_tb
            // 
            this.nombre_producto_tb.Location = new System.Drawing.Point(49, 83);
            this.nombre_producto_tb.Name = "nombre_producto_tb";
            this.nombre_producto_tb.Size = new System.Drawing.Size(691, 33);
            this.nombre_producto_tb.TabIndex = 4;
            // 
            // producto_nombre_label
            // 
            this.producto_nombre_label.AutoSize = true;
            this.producto_nombre_label.Location = new System.Drawing.Point(44, 55);
            this.producto_nombre_label.Name = "producto_nombre_label";
            this.producto_nombre_label.Size = new System.Drawing.Size(194, 25);
            this.producto_nombre_label.TabIndex = 3;
            this.producto_nombre_label.Text = "Nombre del producto";
            // 
            // nueva_categoria_linklabel
            // 
            this.nueva_categoria_linklabel.AutoSize = true;
            this.nueva_categoria_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nueva_categoria_linklabel.Location = new System.Drawing.Point(243, 122);
            this.nueva_categoria_linklabel.Name = "nueva_categoria_linklabel";
            this.nueva_categoria_linklabel.Size = new System.Drawing.Size(123, 21);
            this.nueva_categoria_linklabel.TabIndex = 12;
            this.nueva_categoria_linklabel.TabStop = true;
            this.nueva_categoria_linklabel.Text = "Nueva categoria";
            this.nueva_categoria_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nueva_categoria_linklabel_LinkClicked);
            // 
            // categorias_disponibles_dropdown
            // 
            this.categorias_disponibles_dropdown.FormattingEnabled = true;
            this.categorias_disponibles_dropdown.Location = new System.Drawing.Point(49, 147);
            this.categorias_disponibles_dropdown.Name = "categorias_disponibles_dropdown";
            this.categorias_disponibles_dropdown.Size = new System.Drawing.Size(497, 33);
            this.categorias_disponibles_dropdown.TabIndex = 13;
            // 
            // seleccionar_categorias_label
            // 
            this.seleccionar_categorias_label.AutoSize = true;
            this.seleccionar_categorias_label.Location = new System.Drawing.Point(44, 119);
            this.seleccionar_categorias_label.Name = "seleccionar_categorias_label";
            this.seleccionar_categorias_label.Size = new System.Drawing.Size(201, 25);
            this.seleccionar_categorias_label.TabIndex = 11;
            this.seleccionar_categorias_label.Text = "Seleccionar categorias";
            // 
            // categorias_seleccionadas_listbox
            // 
            this.categorias_seleccionadas_listbox.FormattingEnabled = true;
            this.categorias_seleccionadas_listbox.HorizontalScrollbar = true;
            this.categorias_seleccionadas_listbox.ItemHeight = 25;
            this.categorias_seleccionadas_listbox.Location = new System.Drawing.Point(49, 216);
            this.categorias_seleccionadas_listbox.Name = "categorias_seleccionadas_listbox";
            this.categorias_seleccionadas_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categorias_seleccionadas_listbox.Size = new System.Drawing.Size(497, 154);
            this.categorias_seleccionadas_listbox.TabIndex = 14;
            // 
            // agregar_categoria_button
            // 
            this.agregar_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_categoria_button.Location = new System.Drawing.Point(552, 144);
            this.agregar_categoria_button.Name = "agregar_categoria_button";
            this.agregar_categoria_button.Size = new System.Drawing.Size(188, 37);
            this.agregar_categoria_button.TabIndex = 18;
            this.agregar_categoria_button.Text = "Agregar";
            this.agregar_categoria_button.UseVisualStyleBackColor = true;
            this.agregar_categoria_button.Click += new System.EventHandler(this.agregar_categoria_button_Click);
            // 
            // remover_categoria_button
            // 
            this.remover_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_categoria_button.Location = new System.Drawing.Point(552, 216);
            this.remover_categoria_button.Name = "remover_categoria_button";
            this.remover_categoria_button.Size = new System.Drawing.Size(188, 37);
            this.remover_categoria_button.TabIndex = 19;
            this.remover_categoria_button.Text = "Remover selección";
            this.remover_categoria_button.UseVisualStyleBackColor = true;
            this.remover_categoria_button.Click += new System.EventHandler(this.remover_categoria_button_Click);
            // 
            // crear_producto_button
            // 
            this.crear_producto_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crear_producto_button.Location = new System.Drawing.Point(552, 440);
            this.crear_producto_button.Name = "crear_producto_button";
            this.crear_producto_button.Size = new System.Drawing.Size(188, 37);
            this.crear_producto_button.TabIndex = 20;
            this.crear_producto_button.Text = "Crear producto";
            this.crear_producto_button.UseVisualStyleBackColor = true;
            this.crear_producto_button.Click += new System.EventHandler(this.crear_producto_button_Click);
            // 
            // descripcion_tb
            // 
            this.descripcion_tb.Location = new System.Drawing.Point(49, 401);
            this.descripcion_tb.Multiline = true;
            this.descripcion_tb.Name = "descripcion_tb";
            this.descripcion_tb.Size = new System.Drawing.Size(497, 76);
            this.descripcion_tb.TabIndex = 22;
            // 
            // descripcion_label
            // 
            this.descripcion_label.AutoSize = true;
            this.descripcion_label.Location = new System.Drawing.Point(44, 373);
            this.descripcion_label.Name = "descripcion_label";
            this.descripcion_label.Size = new System.Drawing.Size(111, 25);
            this.descripcion_label.TabIndex = 21;
            this.descripcion_label.Text = "Descripción";
            // 
            // categorias_seleccionadas_label
            // 
            this.categorias_seleccionadas_label.AutoSize = true;
            this.categorias_seleccionadas_label.Location = new System.Drawing.Point(44, 183);
            this.categorias_seleccionadas_label.Name = "categorias_seleccionadas_label";
            this.categorias_seleccionadas_label.Size = new System.Drawing.Size(224, 25);
            this.categorias_seleccionadas_label.TabIndex = 23;
            this.categorias_seleccionadas_label.Text = "Categorias seleccionadas";
            // 
            // CrearProductoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 501);
            this.Controls.Add(this.categorias_seleccionadas_label);
            this.Controls.Add(this.descripcion_tb);
            this.Controls.Add(this.descripcion_label);
            this.Controls.Add(this.crear_producto_button);
            this.Controls.Add(this.remover_categoria_button);
            this.Controls.Add(this.agregar_categoria_button);
            this.Controls.Add(this.categorias_seleccionadas_listbox);
            this.Controls.Add(this.nueva_categoria_linklabel);
            this.Controls.Add(this.categorias_disponibles_dropdown);
            this.Controls.Add(this.seleccionar_categorias_label);
            this.Controls.Add(this.nombre_producto_tb);
            this.Controls.Add(this.producto_nombre_label);
            this.Controls.Add(this.header_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CrearProductoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear producto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.TextBox nombre_producto_tb;
        private System.Windows.Forms.Label producto_nombre_label;
        private System.Windows.Forms.LinkLabel nueva_categoria_linklabel;
        private System.Windows.Forms.ComboBox categorias_disponibles_dropdown;
        private System.Windows.Forms.Label seleccionar_categorias_label;
        private System.Windows.Forms.ListBox categorias_seleccionadas_listbox;
        private System.Windows.Forms.Button agregar_categoria_button;
        private System.Windows.Forms.Button remover_categoria_button;
        private System.Windows.Forms.Button crear_producto_button;
        private System.Windows.Forms.TextBox descripcion_tb;
        private System.Windows.Forms.Label descripcion_label;
        private System.Windows.Forms.Label categorias_seleccionadas_label;
    }
}