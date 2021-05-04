namespace SivUI.Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearProductoForm));
            this.header_label = new System.Windows.Forms.Label();
            this.nombre_producto_tb = new System.Windows.Forms.TextBox();
            this.producto_nombre_label = new System.Windows.Forms.Label();
            this.nueva_categoria_linklabel = new System.Windows.Forms.LinkLabel();
            this.categorias_seleccionadas_listbox = new System.Windows.Forms.ListBox();
            this.remover_categoria_button = new System.Windows.Forms.Button();
            this.crear_producto_button = new System.Windows.Forms.Button();
            this.descripcion_tb = new System.Windows.Forms.TextBox();
            this.descripcion_label = new System.Windows.Forms.Label();
            this.categorias_seleccionadas_label = new System.Windows.Forms.Label();
            this.buscar_categoria_linklabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.header_label.Location = new System.Drawing.Point(153, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(231, 30);
            this.header_label.TabIndex = 2;
            this.header_label.Text = "Creación de productos";
            // 
            // nombre_producto_tb
            // 
            this.nombre_producto_tb.BackColor = System.Drawing.Color.White;
            this.nombre_producto_tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombre_producto_tb.ForeColor = System.Drawing.Color.Black;
            this.nombre_producto_tb.Location = new System.Drawing.Point(22, 80);
            this.nombre_producto_tb.Name = "nombre_producto_tb";
            this.nombre_producto_tb.Size = new System.Drawing.Size(497, 33);
            this.nombre_producto_tb.TabIndex = 4;
            // 
            // producto_nombre_label
            // 
            this.producto_nombre_label.AutoSize = true;
            this.producto_nombre_label.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.producto_nombre_label.Location = new System.Drawing.Point(17, 52);
            this.producto_nombre_label.Name = "producto_nombre_label";
            this.producto_nombre_label.Size = new System.Drawing.Size(194, 25);
            this.producto_nombre_label.TabIndex = 3;
            this.producto_nombre_label.Text = "Nombre del producto";
            // 
            // nueva_categoria_linklabel
            // 
            this.nueva_categoria_linklabel.AutoSize = true;
            this.nueva_categoria_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nueva_categoria_linklabel.LinkColor = System.Drawing.Color.Blue;
            this.nueva_categoria_linklabel.Location = new System.Drawing.Point(425, 152);
            this.nueva_categoria_linklabel.Name = "nueva_categoria_linklabel";
            this.nueva_categoria_linklabel.Size = new System.Drawing.Size(94, 21);
            this.nueva_categoria_linklabel.TabIndex = 6;
            this.nueva_categoria_linklabel.TabStop = true;
            this.nueva_categoria_linklabel.Text = "Crear nueva";
            this.nueva_categoria_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nueva_categoria_linklabel_LinkClicked);
            // 
            // categorias_seleccionadas_listbox
            // 
            this.categorias_seleccionadas_listbox.BackColor = System.Drawing.Color.White;
            this.categorias_seleccionadas_listbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.categorias_seleccionadas_listbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_seleccionadas_listbox.ForeColor = System.Drawing.Color.Black;
            this.categorias_seleccionadas_listbox.FormattingEnabled = true;
            this.categorias_seleccionadas_listbox.HorizontalScrollbar = true;
            this.categorias_seleccionadas_listbox.ItemHeight = 21;
            this.categorias_seleccionadas_listbox.Location = new System.Drawing.Point(22, 177);
            this.categorias_seleccionadas_listbox.Name = "categorias_seleccionadas_listbox";
            this.categorias_seleccionadas_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categorias_seleccionadas_listbox.Size = new System.Drawing.Size(497, 107);
            this.categorias_seleccionadas_listbox.TabIndex = 7;
            // 
            // remover_categoria_button
            // 
            this.remover_categoria_button.BackColor = System.Drawing.Color.White;
            this.remover_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_categoria_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.remover_categoria_button.Location = new System.Drawing.Point(331, 290);
            this.remover_categoria_button.Name = "remover_categoria_button";
            this.remover_categoria_button.Size = new System.Drawing.Size(188, 37);
            this.remover_categoria_button.TabIndex = 8;
            this.remover_categoria_button.Text = "Remover selección";
            this.remover_categoria_button.UseVisualStyleBackColor = false;
            this.remover_categoria_button.Click += new System.EventHandler(this.remover_categoria_button_Click);
            // 
            // crear_producto_button
            // 
            this.crear_producto_button.BackColor = System.Drawing.Color.White;
            this.crear_producto_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crear_producto_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.crear_producto_button.Location = new System.Drawing.Point(331, 452);
            this.crear_producto_button.Name = "crear_producto_button";
            this.crear_producto_button.Size = new System.Drawing.Size(188, 37);
            this.crear_producto_button.TabIndex = 10;
            this.crear_producto_button.Text = "Crear producto";
            this.crear_producto_button.UseVisualStyleBackColor = false;
            this.crear_producto_button.Click += new System.EventHandler(this.crear_producto_button_Click);
            // 
            // descripcion_tb
            // 
            this.descripcion_tb.BackColor = System.Drawing.Color.White;
            this.descripcion_tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descripcion_tb.ForeColor = System.Drawing.Color.Black;
            this.descripcion_tb.Location = new System.Drawing.Point(22, 348);
            this.descripcion_tb.Multiline = true;
            this.descripcion_tb.Name = "descripcion_tb";
            this.descripcion_tb.Size = new System.Drawing.Size(497, 76);
            this.descripcion_tb.TabIndex = 9;
            // 
            // descripcion_label
            // 
            this.descripcion_label.AutoSize = true;
            this.descripcion_label.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.descripcion_label.Location = new System.Drawing.Point(17, 320);
            this.descripcion_label.Name = "descripcion_label";
            this.descripcion_label.Size = new System.Drawing.Size(111, 25);
            this.descripcion_label.TabIndex = 21;
            this.descripcion_label.Text = "Descripción";
            // 
            // categorias_seleccionadas_label
            // 
            this.categorias_seleccionadas_label.AutoSize = true;
            this.categorias_seleccionadas_label.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.categorias_seleccionadas_label.Location = new System.Drawing.Point(17, 149);
            this.categorias_seleccionadas_label.Name = "categorias_seleccionadas_label";
            this.categorias_seleccionadas_label.Size = new System.Drawing.Size(224, 25);
            this.categorias_seleccionadas_label.TabIndex = 23;
            this.categorias_seleccionadas_label.Text = "Categorias seleccionadas";
            // 
            // buscar_categoria_linklabel
            // 
            this.buscar_categoria_linklabel.AutoSize = true;
            this.buscar_categoria_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_categoria_linklabel.LinkColor = System.Drawing.Color.Blue;
            this.buscar_categoria_linklabel.Location = new System.Drawing.Point(247, 152);
            this.buscar_categoria_linklabel.Name = "buscar_categoria_linklabel";
            this.buscar_categoria_linklabel.Size = new System.Drawing.Size(56, 21);
            this.buscar_categoria_linklabel.TabIndex = 5;
            this.buscar_categoria_linklabel.TabStop = true;
            this.buscar_categoria_linklabel.Text = "Buscar";
            this.buscar_categoria_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buscar_categoria_linklabel_LinkClicked);
            // 
            // CrearProductoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(537, 501);
            this.Controls.Add(this.buscar_categoria_linklabel);
            this.Controls.Add(this.categorias_seleccionadas_label);
            this.Controls.Add(this.descripcion_tb);
            this.Controls.Add(this.descripcion_label);
            this.Controls.Add(this.crear_producto_button);
            this.Controls.Add(this.remover_categoria_button);
            this.Controls.Add(this.categorias_seleccionadas_listbox);
            this.Controls.Add(this.nueva_categoria_linklabel);
            this.Controls.Add(this.producto_nombre_label);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.nombre_producto_tb);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
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
        private System.Windows.Forms.ListBox categorias_seleccionadas_listbox;
        private System.Windows.Forms.Button remover_categoria_button;
        private System.Windows.Forms.Button crear_producto_button;
        private System.Windows.Forms.TextBox descripcion_tb;
        private System.Windows.Forms.Label descripcion_label;
        private System.Windows.Forms.Label categorias_seleccionadas_label;
        private System.Windows.Forms.LinkLabel buscar_categoria_linklabel;
    }
}