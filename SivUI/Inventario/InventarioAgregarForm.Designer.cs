namespace SivUI
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
            this.producto_label = new System.Windows.Forms.Label();
            this.precio_venta_defecto_tb = new System.Windows.Forms.TextBox();
            this.precio_venta_defecto_label = new System.Windows.Forms.Label();
            this.agregar_al_inventario_button = new System.Windows.Forms.Button();
            this.nuevo_producto_linklabel = new System.Windows.Forms.LinkLabel();
            this.lote_id_tb = new System.Windows.Forms.TextBox();
            this.lote_id_label = new System.Windows.Forms.Label();
            this.header_label = new System.Windows.Forms.Label();
            this.buscar_producto_linklabel = new System.Windows.Forms.LinkLabel();
            this.nombre_producto_tb = new System.Windows.Forms.TextBox();
            this.descripcion_producto_tb = new System.Windows.Forms.TextBox();
            this.descripcion_producto_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // unidades_label
            // 
            this.unidades_label.AutoSize = true;
            this.unidades_label.Location = new System.Drawing.Point(17, 76);
            this.unidades_label.Name = "unidades_label";
            this.unidades_label.Size = new System.Drawing.Size(91, 25);
            this.unidades_label.TabIndex = 1;
            this.unidades_label.Text = "Unidades";
            // 
            // unidades_tb
            // 
            this.unidades_tb.Location = new System.Drawing.Point(22, 104);
            this.unidades_tb.Name = "unidades_tb";
            this.unidades_tb.Size = new System.Drawing.Size(125, 33);
            this.unidades_tb.TabIndex = 2;
            this.unidades_tb.TextChanged += new System.EventHandler(this.unidades_tb_TextChanged);
            // 
            // inversion_total_label
            // 
            this.inversion_total_label.AutoSize = true;
            this.inversion_total_label.Location = new System.Drawing.Point(157, 76);
            this.inversion_total_label.Name = "inversion_total_label";
            this.inversion_total_label.Size = new System.Drawing.Size(132, 25);
            this.inversion_total_label.TabIndex = 3;
            this.inversion_total_label.Text = "Inversión total";
            // 
            // inversion_total_tb
            // 
            this.inversion_total_tb.Location = new System.Drawing.Point(162, 104);
            this.inversion_total_tb.Name = "inversion_total_tb";
            this.inversion_total_tb.Size = new System.Drawing.Size(127, 33);
            this.inversion_total_tb.TabIndex = 4;
            this.inversion_total_tb.TextChanged += new System.EventHandler(this.inversion_total_tb_TextChanged);
            // 
            // inversion_unidad_label
            // 
            this.inversion_unidad_label.AutoSize = true;
            this.inversion_unidad_label.Location = new System.Drawing.Point(299, 76);
            this.inversion_unidad_label.Name = "inversion_unidad_label";
            this.inversion_unidad_label.Size = new System.Drawing.Size(187, 25);
            this.inversion_unidad_label.TabIndex = 5;
            this.inversion_unidad_label.Text = "Inversión por unidad";
            // 
            // inversion_unidad_tb
            // 
            this.inversion_unidad_tb.Location = new System.Drawing.Point(304, 104);
            this.inversion_unidad_tb.Name = "inversion_unidad_tb";
            this.inversion_unidad_tb.ReadOnly = true;
            this.inversion_unidad_tb.Size = new System.Drawing.Size(182, 33);
            this.inversion_unidad_tb.TabIndex = 6;
            this.inversion_unidad_tb.TabStop = false;
            // 
            // producto_label
            // 
            this.producto_label.AutoSize = true;
            this.producto_label.Location = new System.Drawing.Point(17, 162);
            this.producto_label.Name = "producto_label";
            this.producto_label.Size = new System.Drawing.Size(204, 25);
            this.producto_label.TabIndex = 8;
            this.producto_label.Text = "Producto seleccionado";
            // 
            // precio_venta_defecto_tb
            // 
            this.precio_venta_defecto_tb.Location = new System.Drawing.Point(501, 104);
            this.precio_venta_defecto_tb.Name = "precio_venta_defecto_tb";
            this.precio_venta_defecto_tb.Size = new System.Drawing.Size(217, 33);
            this.precio_venta_defecto_tb.TabIndex = 8;
            // 
            // precio_venta_defecto_label
            // 
            this.precio_venta_defecto_label.AutoSize = true;
            this.precio_venta_defecto_label.Location = new System.Drawing.Point(496, 76);
            this.precio_venta_defecto_label.Name = "precio_venta_defecto_label";
            this.precio_venta_defecto_label.Size = new System.Drawing.Size(222, 25);
            this.precio_venta_defecto_label.TabIndex = 7;
            this.precio_venta_defecto_label.Text = "Precio de venta (defecto)";
            // 
            // agregar_al_inventario_button
            // 
            this.agregar_al_inventario_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_al_inventario_button.Location = new System.Drawing.Point(511, 391);
            this.agregar_al_inventario_button.Name = "agregar_al_inventario_button";
            this.agregar_al_inventario_button.Size = new System.Drawing.Size(207, 37);
            this.agregar_al_inventario_button.TabIndex = 17;
            this.agregar_al_inventario_button.Text = "Agregar al inventario";
            this.agregar_al_inventario_button.UseVisualStyleBackColor = true;
            this.agregar_al_inventario_button.Click += new System.EventHandler(this.agregar_al_inventario_button_Click);
            // 
            // nuevo_producto_linklabel
            // 
            this.nuevo_producto_linklabel.AutoSize = true;
            this.nuevo_producto_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuevo_producto_linklabel.Location = new System.Drawing.Point(623, 165);
            this.nuevo_producto_linklabel.Name = "nuevo_producto_linklabel";
            this.nuevo_producto_linklabel.Size = new System.Drawing.Size(95, 21);
            this.nuevo_producto_linklabel.TabIndex = 9;
            this.nuevo_producto_linklabel.TabStop = true;
            this.nuevo_producto_linklabel.Text = "Crear nuevo";
            this.nuevo_producto_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nuevo_producto_linklabel_LinkClicked);
            // 
            // lote_id_tb
            // 
            this.lote_id_tb.Location = new System.Drawing.Point(22, 395);
            this.lote_id_tb.Name = "lote_id_tb";
            this.lote_id_tb.ReadOnly = true;
            this.lote_id_tb.Size = new System.Drawing.Size(152, 33);
            this.lote_id_tb.TabIndex = 17;
            this.lote_id_tb.TabStop = false;
            this.lote_id_tb.Text = "N/A";
            // 
            // lote_id_label
            // 
            this.lote_id_label.AutoSize = true;
            this.lote_id_label.Location = new System.Drawing.Point(17, 367);
            this.lote_id_label.Name = "lote_id_label";
            this.lote_id_label.Size = new System.Drawing.Size(157, 25);
            this.lote_id_label.TabIndex = 16;
            this.lote_id_label.Text = "ID del último lote";
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(260, 12);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(215, 30);
            this.header_label.TabIndex = 18;
            this.header_label.Text = "Agregar al inventario";
            // 
            // buscar_producto_linklabel
            // 
            this.buscar_producto_linklabel.AutoSize = true;
            this.buscar_producto_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_producto_linklabel.Location = new System.Drawing.Point(224, 165);
            this.buscar_producto_linklabel.Name = "buscar_producto_linklabel";
            this.buscar_producto_linklabel.Size = new System.Drawing.Size(56, 21);
            this.buscar_producto_linklabel.TabIndex = 19;
            this.buscar_producto_linklabel.TabStop = true;
            this.buscar_producto_linklabel.Text = "Buscar";
            this.buscar_producto_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buscar_producto_linklabel_LinkClicked);
            // 
            // nombre_producto_tb
            // 
            this.nombre_producto_tb.Location = new System.Drawing.Point(22, 190);
            this.nombre_producto_tb.Name = "nombre_producto_tb";
            this.nombre_producto_tb.ReadOnly = true;
            this.nombre_producto_tb.Size = new System.Drawing.Size(696, 33);
            this.nombre_producto_tb.TabIndex = 20;
            this.nombre_producto_tb.TabStop = false;
            // 
            // descripcion_producto_tb
            // 
            this.descripcion_producto_tb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descripcion_producto_tb.Location = new System.Drawing.Point(22, 275);
            this.descripcion_producto_tb.Multiline = true;
            this.descripcion_producto_tb.Name = "descripcion_producto_tb";
            this.descripcion_producto_tb.ReadOnly = true;
            this.descripcion_producto_tb.Size = new System.Drawing.Size(696, 75);
            this.descripcion_producto_tb.TabIndex = 22;
            this.descripcion_producto_tb.TabStop = false;
            // 
            // descripcion_producto_label
            // 
            this.descripcion_producto_label.AutoSize = true;
            this.descripcion_producto_label.Location = new System.Drawing.Point(17, 247);
            this.descripcion_producto_label.Name = "descripcion_producto_label";
            this.descripcion_producto_label.Size = new System.Drawing.Size(224, 25);
            this.descripcion_producto_label.TabIndex = 21;
            this.descripcion_producto_label.Text = "Descripción del producto";
            // 
            // InventarioAgregarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 440);
            this.Controls.Add(this.descripcion_producto_tb);
            this.Controls.Add(this.descripcion_producto_label);
            this.Controls.Add(this.nombre_producto_tb);
            this.Controls.Add(this.buscar_producto_linklabel);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.lote_id_tb);
            this.Controls.Add(this.lote_id_label);
            this.Controls.Add(this.nuevo_producto_linklabel);
            this.Controls.Add(this.agregar_al_inventario_button);
            this.Controls.Add(this.precio_venta_defecto_tb);
            this.Controls.Add(this.precio_venta_defecto_label);
            this.Controls.Add(this.producto_label);
            this.Controls.Add(this.inversion_unidad_tb);
            this.Controls.Add(this.inversion_unidad_label);
            this.Controls.Add(this.inversion_total_tb);
            this.Controls.Add(this.inversion_total_label);
            this.Controls.Add(this.unidades_tb);
            this.Controls.Add(this.unidades_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.Label producto_label;
        private System.Windows.Forms.TextBox precio_venta_defecto_tb;
        private System.Windows.Forms.Label precio_venta_defecto_label;
        private System.Windows.Forms.Button agregar_al_inventario_button;
        private System.Windows.Forms.LinkLabel nuevo_producto_linklabel;
        private System.Windows.Forms.TextBox lote_id_tb;
        private System.Windows.Forms.Label lote_id_label;
        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.LinkLabel buscar_producto_linklabel;
        private System.Windows.Forms.TextBox nombre_producto_tb;
        private System.Windows.Forms.TextBox descripcion_producto_tb;
        private System.Windows.Forms.Label descripcion_producto_label;
    }
}

