namespace SivUI
{
    partial class EditarProductoForm
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
            this.buscar_producto_linklabel = new System.Windows.Forms.LinkLabel();
            this.producto_label = new System.Windows.Forms.Label();
            this.nuevo_nombre_tb = new System.Windows.Forms.TextBox();
            this.nuevo_nombre_label = new System.Windows.Forms.Label();
            this.categorias_listbox = new System.Windows.Forms.ListBox();
            this.categorias_producto_label = new System.Windows.Forms.Label();
            this.agregar_categorias_linklabel = new System.Windows.Forms.LinkLabel();
            this.remover_categorias_button = new System.Windows.Forms.Button();
            this.editar_button = new System.Windows.Forms.Button();
            this.crear_categoria_linklabel = new System.Windows.Forms.LinkLabel();
            this.nueva_descripcion_tb = new System.Windows.Forms.TextBox();
            this.descripcion_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(128, 11);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(217, 30);
            this.header_label.TabIndex = 0;
            this.header_label.Text = "Edición de productos";
            // 
            // nombre_producto_tb
            // 
            this.nombre_producto_tb.Location = new System.Drawing.Point(12, 86);
            this.nombre_producto_tb.Name = "nombre_producto_tb";
            this.nombre_producto_tb.ReadOnly = true;
            this.nombre_producto_tb.Size = new System.Drawing.Size(449, 33);
            this.nombre_producto_tb.TabIndex = 24;
            this.nombre_producto_tb.TabStop = false;
            // 
            // buscar_producto_linklabel
            // 
            this.buscar_producto_linklabel.AutoSize = true;
            this.buscar_producto_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_producto_linklabel.Location = new System.Drawing.Point(405, 61);
            this.buscar_producto_linklabel.Name = "buscar_producto_linklabel";
            this.buscar_producto_linklabel.Size = new System.Drawing.Size(56, 21);
            this.buscar_producto_linklabel.TabIndex = 23;
            this.buscar_producto_linklabel.TabStop = true;
            this.buscar_producto_linklabel.Text = "Buscar";
            this.buscar_producto_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buscar_producto_linklabel_LinkClicked);
            // 
            // producto_label
            // 
            this.producto_label.AutoSize = true;
            this.producto_label.Location = new System.Drawing.Point(7, 58);
            this.producto_label.Name = "producto_label";
            this.producto_label.Size = new System.Drawing.Size(158, 25);
            this.producto_label.TabIndex = 21;
            this.producto_label.Text = "Producto a editar";
            // 
            // nuevo_nombre_tb
            // 
            this.nuevo_nombre_tb.Location = new System.Drawing.Point(12, 150);
            this.nuevo_nombre_tb.Name = "nuevo_nombre_tb";
            this.nuevo_nombre_tb.Size = new System.Drawing.Size(449, 33);
            this.nuevo_nombre_tb.TabIndex = 26;
            // 
            // nuevo_nombre_label
            // 
            this.nuevo_nombre_label.AutoSize = true;
            this.nuevo_nombre_label.Location = new System.Drawing.Point(12, 122);
            this.nuevo_nombre_label.Name = "nuevo_nombre_label";
            this.nuevo_nombre_label.Size = new System.Drawing.Size(138, 25);
            this.nuevo_nombre_label.TabIndex = 25;
            this.nuevo_nombre_label.Text = "Nuevo nombre";
            // 
            // categorias_listbox
            // 
            this.categorias_listbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_listbox.FormattingEnabled = true;
            this.categorias_listbox.HorizontalScrollbar = true;
            this.categorias_listbox.ItemHeight = 21;
            this.categorias_listbox.Location = new System.Drawing.Point(12, 317);
            this.categorias_listbox.Name = "categorias_listbox";
            this.categorias_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categorias_listbox.Size = new System.Drawing.Size(449, 88);
            this.categorias_listbox.TabIndex = 27;
            // 
            // categorias_producto_label
            // 
            this.categorias_producto_label.AutoSize = true;
            this.categorias_producto_label.Location = new System.Drawing.Point(7, 289);
            this.categorias_producto_label.Name = "categorias_producto_label";
            this.categorias_producto_label.Size = new System.Drawing.Size(215, 25);
            this.categorias_producto_label.TabIndex = 28;
            this.categorias_producto_label.Text = "Categorias del producto";
            // 
            // agregar_categorias_linklabel
            // 
            this.agregar_categorias_linklabel.AutoSize = true;
            this.agregar_categorias_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregar_categorias_linklabel.Location = new System.Drawing.Point(228, 292);
            this.agregar_categorias_linklabel.Name = "agregar_categorias_linklabel";
            this.agregar_categorias_linklabel.Size = new System.Drawing.Size(66, 21);
            this.agregar_categorias_linklabel.TabIndex = 29;
            this.agregar_categorias_linklabel.TabStop = true;
            this.agregar_categorias_linklabel.Text = "Agregar";
            this.agregar_categorias_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.agregar_categorias_linklabel_LinkClicked);
            // 
            // remover_categorias_button
            // 
            this.remover_categorias_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_categorias_button.Location = new System.Drawing.Point(12, 411);
            this.remover_categorias_button.Name = "remover_categorias_button";
            this.remover_categorias_button.Size = new System.Drawing.Size(204, 37);
            this.remover_categorias_button.TabIndex = 30;
            this.remover_categorias_button.Text = "Remover selección";
            this.remover_categorias_button.UseVisualStyleBackColor = true;
            this.remover_categorias_button.Click += new System.EventHandler(this.remover_categorias_button_Click);
            // 
            // editar_button
            // 
            this.editar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editar_button.ForeColor = System.Drawing.Color.Gold;
            this.editar_button.Location = new System.Drawing.Point(354, 453);
            this.editar_button.Name = "editar_button";
            this.editar_button.Size = new System.Drawing.Size(107, 37);
            this.editar_button.TabIndex = 31;
            this.editar_button.Text = "Editar";
            this.editar_button.UseVisualStyleBackColor = true;
            this.editar_button.Click += new System.EventHandler(this.editar_button_Click);
            // 
            // crear_categoria_linklabel
            // 
            this.crear_categoria_linklabel.AutoSize = true;
            this.crear_categoria_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crear_categoria_linklabel.Location = new System.Drawing.Point(413, 292);
            this.crear_categoria_linklabel.Name = "crear_categoria_linklabel";
            this.crear_categoria_linklabel.Size = new System.Drawing.Size(48, 21);
            this.crear_categoria_linklabel.TabIndex = 32;
            this.crear_categoria_linklabel.TabStop = true;
            this.crear_categoria_linklabel.Text = "Crear";
            this.crear_categoria_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.crear_categoria_linklabel_LinkClicked);
            // 
            // nueva_descripcion_tb
            // 
            this.nueva_descripcion_tb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nueva_descripcion_tb.Location = new System.Drawing.Point(12, 214);
            this.nueva_descripcion_tb.Multiline = true;
            this.nueva_descripcion_tb.Name = "nueva_descripcion_tb";
            this.nueva_descripcion_tb.Size = new System.Drawing.Size(449, 72);
            this.nueva_descripcion_tb.TabIndex = 34;
            // 
            // descripcion_label
            // 
            this.descripcion_label.AutoSize = true;
            this.descripcion_label.Location = new System.Drawing.Point(7, 186);
            this.descripcion_label.Name = "descripcion_label";
            this.descripcion_label.Size = new System.Drawing.Size(168, 25);
            this.descripcion_label.TabIndex = 33;
            this.descripcion_label.Text = "Nueva descripción";
            // 
            // EditarProductoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(473, 501);
            this.Controls.Add(this.nueva_descripcion_tb);
            this.Controls.Add(this.descripcion_label);
            this.Controls.Add(this.crear_categoria_linklabel);
            this.Controls.Add(this.editar_button);
            this.Controls.Add(this.remover_categorias_button);
            this.Controls.Add(this.agregar_categorias_linklabel);
            this.Controls.Add(this.categorias_producto_label);
            this.Controls.Add(this.categorias_listbox);
            this.Controls.Add(this.nuevo_nombre_tb);
            this.Controls.Add(this.nuevo_nombre_label);
            this.Controls.Add(this.nombre_producto_tb);
            this.Controls.Add(this.buscar_producto_linklabel);
            this.Controls.Add(this.producto_label);
            this.Controls.Add(this.header_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "EditarProductoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar producto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.TextBox nombre_producto_tb;
        private System.Windows.Forms.LinkLabel buscar_producto_linklabel;
        private System.Windows.Forms.Label producto_label;
        private System.Windows.Forms.TextBox nuevo_nombre_tb;
        private System.Windows.Forms.Label nuevo_nombre_label;
        private System.Windows.Forms.ListBox categorias_listbox;
        private System.Windows.Forms.Label categorias_producto_label;
        private System.Windows.Forms.LinkLabel agregar_categorias_linklabel;
        private System.Windows.Forms.Button remover_categorias_button;
        private System.Windows.Forms.Button editar_button;
        private System.Windows.Forms.LinkLabel crear_categoria_linklabel;
        private System.Windows.Forms.TextBox nueva_descripcion_tb;
        private System.Windows.Forms.Label descripcion_label;
    }
}