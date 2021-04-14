namespace SivUI
{
    partial class EditarLoteForm
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
            this.lote_id_tb = new System.Windows.Forms.TextBox();
            this.lote_id_label = new System.Windows.Forms.Label();
            this.cargar_lote_button = new System.Windows.Forms.Button();
            this.unidades_disponibles_tb = new System.Windows.Forms.TextBox();
            this.unidades_disponibles_label = new System.Windows.Forms.Label();
            this.unidades_adquiridas_tb = new System.Windows.Forms.TextBox();
            this.unidades_adquiridas_label = new System.Windows.Forms.Label();
            this.inversion_unidad_tb = new System.Windows.Forms.TextBox();
            this.inversion_unidad_label = new System.Windows.Forms.Label();
            this.inversion_total_tb = new System.Windows.Forms.TextBox();
            this.inversion_total_label = new System.Windows.Forms.Label();
            this.producto_tb = new System.Windows.Forms.TextBox();
            this.producto_label = new System.Windows.Forms.Label();
            this.precio_venta_unidad_tb = new System.Windows.Forms.TextBox();
            this.precio_venta_unidad_label = new System.Windows.Forms.Label();
            this.editar_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(330, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(164, 30);
            this.header_label.TabIndex = 17;
            this.header_label.Text = "Edición de lotes";
            // 
            // lote_id_tb
            // 
            this.lote_id_tb.Location = new System.Drawing.Point(18, 316);
            this.lote_id_tb.Name = "lote_id_tb";
            this.lote_id_tb.Size = new System.Drawing.Size(156, 33);
            this.lote_id_tb.TabIndex = 6;
            // 
            // lote_id_label
            // 
            this.lote_id_label.AutoSize = true;
            this.lote_id_label.Location = new System.Drawing.Point(13, 288);
            this.lote_id_label.Name = "lote_id_label";
            this.lote_id_label.Size = new System.Drawing.Size(67, 25);
            this.lote_id_label.TabIndex = 18;
            this.lote_id_label.Text = "ID lote";
            // 
            // cargar_lote_button
            // 
            this.cargar_lote_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cargar_lote_button.Location = new System.Drawing.Point(180, 313);
            this.cargar_lote_button.Name = "cargar_lote_button";
            this.cargar_lote_button.Size = new System.Drawing.Size(120, 37);
            this.cargar_lote_button.TabIndex = 20;
            this.cargar_lote_button.Text = "Cargar lote";
            this.cargar_lote_button.UseVisualStyleBackColor = true;
            this.cargar_lote_button.Click += new System.EventHandler(this.cargar_lote_button_Click);
            // 
            // unidades_disponibles_tb
            // 
            this.unidades_disponibles_tb.Location = new System.Drawing.Point(282, 114);
            this.unidades_disponibles_tb.Name = "unidades_disponibles_tb";
            this.unidades_disponibles_tb.Size = new System.Drawing.Size(108, 33);
            this.unidades_disponibles_tb.TabIndex = 2;
            this.unidades_disponibles_tb.TabStop = false;
            this.unidades_disponibles_tb.Text = "N/A";
            // 
            // unidades_disponibles_label
            // 
            this.unidades_disponibles_label.AutoSize = true;
            this.unidades_disponibles_label.Location = new System.Drawing.Point(282, 61);
            this.unidades_disponibles_label.Name = "unidades_disponibles_label";
            this.unidades_disponibles_label.Size = new System.Drawing.Size(108, 50);
            this.unidades_disponibles_label.TabIndex = 21;
            this.unidades_disponibles_label.Text = "Unidades \r\ndisponibles";
            // 
            // unidades_adquiridas_tb
            // 
            this.unidades_adquiridas_tb.Location = new System.Drawing.Point(180, 114);
            this.unidades_adquiridas_tb.Name = "unidades_adquiridas_tb";
            this.unidades_adquiridas_tb.ReadOnly = true;
            this.unidades_adquiridas_tb.Size = new System.Drawing.Size(96, 33);
            this.unidades_adquiridas_tb.TabIndex = 1;
            this.unidades_adquiridas_tb.TabStop = false;
            this.unidades_adquiridas_tb.Text = "N/A";
            // 
            // unidades_adquiridas_label
            // 
            this.unidades_adquiridas_label.AutoSize = true;
            this.unidades_adquiridas_label.Location = new System.Drawing.Point(175, 61);
            this.unidades_adquiridas_label.Name = "unidades_adquiridas_label";
            this.unidades_adquiridas_label.Size = new System.Drawing.Size(101, 50);
            this.unidades_adquiridas_label.TabIndex = 23;
            this.unidades_adquiridas_label.Text = "Unidades \r\nadquiridas";
            // 
            // inversion_unidad_tb
            // 
            this.inversion_unidad_tb.Location = new System.Drawing.Point(396, 114);
            this.inversion_unidad_tb.Name = "inversion_unidad_tb";
            this.inversion_unidad_tb.ReadOnly = true;
            this.inversion_unidad_tb.Size = new System.Drawing.Size(150, 33);
            this.inversion_unidad_tb.TabIndex = 3;
            this.inversion_unidad_tb.TabStop = false;
            this.inversion_unidad_tb.Text = "N/A";
            // 
            // inversion_unidad_label
            // 
            this.inversion_unidad_label.AutoSize = true;
            this.inversion_unidad_label.Location = new System.Drawing.Point(391, 86);
            this.inversion_unidad_label.Name = "inversion_unidad_label";
            this.inversion_unidad_label.Size = new System.Drawing.Size(155, 25);
            this.inversion_unidad_label.TabIndex = 25;
            this.inversion_unidad_label.Text = "Inversión Unidad";
            // 
            // inversion_total_tb
            // 
            this.inversion_total_tb.Location = new System.Drawing.Point(685, 114);
            this.inversion_total_tb.Name = "inversion_total_tb";
            this.inversion_total_tb.ReadOnly = true;
            this.inversion_total_tb.Size = new System.Drawing.Size(127, 33);
            this.inversion_total_tb.TabIndex = 5;
            this.inversion_total_tb.TabStop = false;
            this.inversion_total_tb.Text = "N/A";
            // 
            // inversion_total_label
            // 
            this.inversion_total_label.AutoSize = true;
            this.inversion_total_label.Location = new System.Drawing.Point(680, 86);
            this.inversion_total_label.Name = "inversion_total_label";
            this.inversion_total_label.Size = new System.Drawing.Size(132, 25);
            this.inversion_total_label.TabIndex = 27;
            this.inversion_total_label.Text = "Inversión total";
            // 
            // producto_tb
            // 
            this.producto_tb.Location = new System.Drawing.Point(18, 114);
            this.producto_tb.Name = "producto_tb";
            this.producto_tb.ReadOnly = true;
            this.producto_tb.Size = new System.Drawing.Size(156, 33);
            this.producto_tb.TabIndex = 0;
            this.producto_tb.TabStop = false;
            this.producto_tb.Text = "N/A";
            // 
            // producto_label
            // 
            this.producto_label.AutoSize = true;
            this.producto_label.Location = new System.Drawing.Point(13, 86);
            this.producto_label.Name = "producto_label";
            this.producto_label.Size = new System.Drawing.Size(89, 25);
            this.producto_label.TabIndex = 29;
            this.producto_label.Text = "Producto";
            // 
            // precio_venta_unidad_tb
            // 
            this.precio_venta_unidad_tb.Location = new System.Drawing.Point(552, 114);
            this.precio_venta_unidad_tb.Name = "precio_venta_unidad_tb";
            this.precio_venta_unidad_tb.Size = new System.Drawing.Size(127, 33);
            this.precio_venta_unidad_tb.TabIndex = 4;
            this.precio_venta_unidad_tb.TabStop = false;
            this.precio_venta_unidad_tb.Text = "N/A";
            // 
            // precio_venta_unidad_label
            // 
            this.precio_venta_unidad_label.AutoSize = true;
            this.precio_venta_unidad_label.Location = new System.Drawing.Point(547, 86);
            this.precio_venta_unidad_label.Name = "precio_venta_unidad_label";
            this.precio_venta_unidad_label.Size = new System.Drawing.Size(131, 25);
            this.precio_venta_unidad_label.TabIndex = 31;
            this.precio_venta_unidad_label.Text = "Precio Unidad";
            // 
            // editar_button
            // 
            this.editar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editar_button.ForeColor = System.Drawing.Color.Gold;
            this.editar_button.Location = new System.Drawing.Point(696, 312);
            this.editar_button.Name = "editar_button";
            this.editar_button.Size = new System.Drawing.Size(107, 37);
            this.editar_button.TabIndex = 7;
            this.editar_button.Text = "Editar";
            this.editar_button.UseVisualStyleBackColor = true;
            this.editar_button.Click += new System.EventHandler(this.editar_button_Click);
            // 
            // EditarLoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(824, 361);
            this.Controls.Add(this.editar_button);
            this.Controls.Add(this.precio_venta_unidad_tb);
            this.Controls.Add(this.precio_venta_unidad_label);
            this.Controls.Add(this.producto_tb);
            this.Controls.Add(this.producto_label);
            this.Controls.Add(this.inversion_total_tb);
            this.Controls.Add(this.inversion_total_label);
            this.Controls.Add(this.inversion_unidad_tb);
            this.Controls.Add(this.inversion_unidad_label);
            this.Controls.Add(this.unidades_adquiridas_tb);
            this.Controls.Add(this.unidades_adquiridas_label);
            this.Controls.Add(this.unidades_disponibles_tb);
            this.Controls.Add(this.unidades_disponibles_label);
            this.Controls.Add(this.cargar_lote_button);
            this.Controls.Add(this.lote_id_tb);
            this.Controls.Add(this.lote_id_label);
            this.Controls.Add(this.header_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "EditarLoteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar lotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.TextBox lote_id_tb;
        private System.Windows.Forms.Label lote_id_label;
        private System.Windows.Forms.Button cargar_lote_button;
        private System.Windows.Forms.TextBox unidades_disponibles_tb;
        private System.Windows.Forms.Label unidades_disponibles_label;
        private System.Windows.Forms.TextBox unidades_adquiridas_tb;
        private System.Windows.Forms.Label unidades_adquiridas_label;
        private System.Windows.Forms.TextBox inversion_unidad_tb;
        private System.Windows.Forms.Label inversion_unidad_label;
        private System.Windows.Forms.TextBox inversion_total_tb;
        private System.Windows.Forms.Label inversion_total_label;
        private System.Windows.Forms.TextBox producto_tb;
        private System.Windows.Forms.Label producto_label;
        private System.Windows.Forms.TextBox precio_venta_unidad_tb;
        private System.Windows.Forms.Label precio_venta_unidad_label;
        private System.Windows.Forms.Button editar_button;
    }
}