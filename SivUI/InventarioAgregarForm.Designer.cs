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
            this.seleccionar_producto_label = new System.Windows.Forms.Label();
            this.productos_dropdown = new System.Windows.Forms.ComboBox();
            this.precio_venta_defecto_tb = new System.Windows.Forms.TextBox();
            this.precio_venta_defecto_label = new System.Windows.Forms.Label();
            this.agregar_al_inventario_button = new System.Windows.Forms.Button();
            this.nuevo_producto_linklabel = new System.Windows.Forms.LinkLabel();
            this.ultimo_lote_id_label = new System.Windows.Forms.TextBox();
            this.lote_id_label = new System.Windows.Forms.Label();
            this.header_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // unidades_label
            // 
            this.unidades_label.AutoSize = true;
            this.unidades_label.Location = new System.Drawing.Point(42, 105);
            this.unidades_label.Name = "unidades_label";
            this.unidades_label.Size = new System.Drawing.Size(91, 25);
            this.unidades_label.TabIndex = 1;
            this.unidades_label.Text = "Unidades";
            // 
            // unidades_tb
            // 
            this.unidades_tb.Location = new System.Drawing.Point(47, 133);
            this.unidades_tb.Name = "unidades_tb";
            this.unidades_tb.Size = new System.Drawing.Size(125, 33);
            this.unidades_tb.TabIndex = 2;
            this.unidades_tb.TextChanged += new System.EventHandler(this.unidades_tb_TextChanged);
            // 
            // inversion_total_label
            // 
            this.inversion_total_label.AutoSize = true;
            this.inversion_total_label.Location = new System.Drawing.Point(182, 105);
            this.inversion_total_label.Name = "inversion_total_label";
            this.inversion_total_label.Size = new System.Drawing.Size(132, 25);
            this.inversion_total_label.TabIndex = 3;
            this.inversion_total_label.Text = "Inversión total";
            // 
            // inversion_total_tb
            // 
            this.inversion_total_tb.Location = new System.Drawing.Point(187, 133);
            this.inversion_total_tb.Name = "inversion_total_tb";
            this.inversion_total_tb.Size = new System.Drawing.Size(127, 33);
            this.inversion_total_tb.TabIndex = 4;
            this.inversion_total_tb.TextChanged += new System.EventHandler(this.inversion_total_tb_TextChanged);
            // 
            // inversion_unidad_label
            // 
            this.inversion_unidad_label.AutoSize = true;
            this.inversion_unidad_label.Location = new System.Drawing.Point(324, 105);
            this.inversion_unidad_label.Name = "inversion_unidad_label";
            this.inversion_unidad_label.Size = new System.Drawing.Size(187, 25);
            this.inversion_unidad_label.TabIndex = 5;
            this.inversion_unidad_label.Text = "Inversión por unidad";
            // 
            // inversion_unidad_tb
            // 
            this.inversion_unidad_tb.Location = new System.Drawing.Point(329, 133);
            this.inversion_unidad_tb.Name = "inversion_unidad_tb";
            this.inversion_unidad_tb.ReadOnly = true;
            this.inversion_unidad_tb.Size = new System.Drawing.Size(182, 33);
            this.inversion_unidad_tb.TabIndex = 6;
            this.inversion_unidad_tb.Text = "N/A";
            // 
            // seleccionar_producto_label
            // 
            this.seleccionar_producto_label.AutoSize = true;
            this.seleccionar_producto_label.Location = new System.Drawing.Point(42, 203);
            this.seleccionar_producto_label.Name = "seleccionar_producto_label";
            this.seleccionar_producto_label.Size = new System.Drawing.Size(191, 25);
            this.seleccionar_producto_label.TabIndex = 8;
            this.seleccionar_producto_label.Text = "Seleccionar producto";
            // 
            // productos_dropdown
            // 
            this.productos_dropdown.FormattingEnabled = true;
            this.productos_dropdown.Location = new System.Drawing.Point(47, 231);
            this.productos_dropdown.Name = "productos_dropdown";
            this.productos_dropdown.Size = new System.Drawing.Size(696, 33);
            this.productos_dropdown.TabIndex = 10;
            // 
            // precio_venta_defecto_tb
            // 
            this.precio_venta_defecto_tb.Location = new System.Drawing.Point(526, 133);
            this.precio_venta_defecto_tb.Name = "precio_venta_defecto_tb";
            this.precio_venta_defecto_tb.Size = new System.Drawing.Size(217, 33);
            this.precio_venta_defecto_tb.TabIndex = 8;
            // 
            // precio_venta_defecto_label
            // 
            this.precio_venta_defecto_label.AutoSize = true;
            this.precio_venta_defecto_label.Location = new System.Drawing.Point(521, 105);
            this.precio_venta_defecto_label.Name = "precio_venta_defecto_label";
            this.precio_venta_defecto_label.Size = new System.Drawing.Size(222, 25);
            this.precio_venta_defecto_label.TabIndex = 7;
            this.precio_venta_defecto_label.Text = "Precio de venta (defecto)";
            // 
            // agregar_al_inventario_button
            // 
            this.agregar_al_inventario_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_al_inventario_button.Location = new System.Drawing.Point(536, 325);
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
            this.nuevo_producto_linklabel.Location = new System.Drawing.Point(241, 206);
            this.nuevo_producto_linklabel.Name = "nuevo_producto_linklabel";
            this.nuevo_producto_linklabel.Size = new System.Drawing.Size(123, 21);
            this.nuevo_producto_linklabel.TabIndex = 9;
            this.nuevo_producto_linklabel.TabStop = true;
            this.nuevo_producto_linklabel.Text = "Nuevo producto";
            this.nuevo_producto_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nuevo_producto_linklabel_LinkClicked);
            // 
            // ultimo_lote_id_label
            // 
            this.ultimo_lote_id_label.Location = new System.Drawing.Point(47, 329);
            this.ultimo_lote_id_label.Name = "ultimo_lote_id_label";
            this.ultimo_lote_id_label.ReadOnly = true;
            this.ultimo_lote_id_label.Size = new System.Drawing.Size(197, 33);
            this.ultimo_lote_id_label.TabIndex = 17;
            // 
            // lote_id_label
            // 
            this.lote_id_label.AutoSize = true;
            this.lote_id_label.Location = new System.Drawing.Point(42, 301);
            this.lote_id_label.Name = "lote_id_label";
            this.lote_id_label.Size = new System.Drawing.Size(157, 25);
            this.lote_id_label.TabIndex = 16;
            this.lote_id_label.Text = "ID del último lote";
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(285, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(215, 30);
            this.header_label.TabIndex = 18;
            this.header_label.Text = "Agregar al inventario";
            // 
            // InventarioAgregarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 501);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.ultimo_lote_id_label);
            this.Controls.Add(this.lote_id_label);
            this.Controls.Add(this.nuevo_producto_linklabel);
            this.Controls.Add(this.agregar_al_inventario_button);
            this.Controls.Add(this.precio_venta_defecto_tb);
            this.Controls.Add(this.precio_venta_defecto_label);
            this.Controls.Add(this.productos_dropdown);
            this.Controls.Add(this.seleccionar_producto_label);
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
        private System.Windows.Forms.Label seleccionar_producto_label;
        private System.Windows.Forms.ComboBox productos_dropdown;
        private System.Windows.Forms.TextBox precio_venta_defecto_tb;
        private System.Windows.Forms.Label precio_venta_defecto_label;
        private System.Windows.Forms.Button agregar_al_inventario_button;
        private System.Windows.Forms.LinkLabel nuevo_producto_linklabel;
        private System.Windows.Forms.TextBox ultimo_lote_id_label;
        private System.Windows.Forms.Label lote_id_label;
        private System.Windows.Forms.Label header_label;
    }
}

