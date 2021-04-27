
namespace SivUI.Ventas
{
    partial class EliminarVentaForm
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
            this.cliente_tb = new System.Windows.Forms.TextBox();
            this.cliente_label = new System.Windows.Forms.Label();
            this.fecha_venta_tb = new System.Windows.Forms.TextBox();
            this.fecha_label = new System.Windows.Forms.Label();
            this.producto_tb = new System.Windows.Forms.TextBox();
            this.producto_label = new System.Windows.Forms.Label();
            this.unidades_vendidas_tb = new System.Windows.Forms.TextBox();
            this.unidades_vendidas_label = new System.Windows.Forms.Label();
            this.venta_id_tb = new System.Windows.Forms.TextBox();
            this.venta_id_label = new System.Windows.Forms.Label();
            this.eliminar_venta_button = new System.Windows.Forms.Button();
            this.cargar_venta_button = new System.Windows.Forms.Button();
            this.total_tb = new System.Windows.Forms.TextBox();
            this.total_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(393, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(148, 30);
            this.header_label.TabIndex = 16;
            this.header_label.Text = "Eliminar venta";
            // 
            // lote_id_tb
            // 
            this.lote_id_tb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lote_id_tb.Location = new System.Drawing.Point(21, 119);
            this.lote_id_tb.Name = "lote_id_tb";
            this.lote_id_tb.ReadOnly = true;
            this.lote_id_tb.Size = new System.Drawing.Size(123, 29);
            this.lote_id_tb.TabIndex = 32;
            this.lote_id_tb.TabStop = false;
            this.lote_id_tb.Text = "N/A";
            // 
            // lote_id_label
            // 
            this.lote_id_label.AutoSize = true;
            this.lote_id_label.Location = new System.Drawing.Point(16, 91);
            this.lote_id_label.Name = "lote_id_label";
            this.lote_id_label.Size = new System.Drawing.Size(67, 25);
            this.lote_id_label.TabIndex = 42;
            this.lote_id_label.Text = "ID lote";
            // 
            // cliente_tb
            // 
            this.cliente_tb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cliente_tb.Location = new System.Drawing.Point(726, 119);
            this.cliente_tb.Name = "cliente_tb";
            this.cliente_tb.ReadOnly = true;
            this.cliente_tb.Size = new System.Drawing.Size(192, 29);
            this.cliente_tb.TabIndex = 37;
            this.cliente_tb.TabStop = false;
            this.cliente_tb.Text = "N/A";
            // 
            // cliente_label
            // 
            this.cliente_label.AutoSize = true;
            this.cliente_label.Location = new System.Drawing.Point(721, 91);
            this.cliente_label.Name = "cliente_label";
            this.cliente_label.Size = new System.Drawing.Size(71, 25);
            this.cliente_label.TabIndex = 41;
            this.cliente_label.Text = "Cliente";
            // 
            // fecha_venta_tb
            // 
            this.fecha_venta_tb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha_venta_tb.Location = new System.Drawing.Point(576, 119);
            this.fecha_venta_tb.Name = "fecha_venta_tb";
            this.fecha_venta_tb.ReadOnly = true;
            this.fecha_venta_tb.Size = new System.Drawing.Size(144, 29);
            this.fecha_venta_tb.TabIndex = 36;
            this.fecha_venta_tb.TabStop = false;
            this.fecha_venta_tb.Text = "N/A";
            // 
            // fecha_label
            // 
            this.fecha_label.AutoSize = true;
            this.fecha_label.Location = new System.Drawing.Point(571, 91);
            this.fecha_label.Name = "fecha_label";
            this.fecha_label.Size = new System.Drawing.Size(61, 25);
            this.fecha_label.TabIndex = 40;
            this.fecha_label.Text = "Fecha";
            // 
            // producto_tb
            // 
            this.producto_tb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.producto_tb.Location = new System.Drawing.Point(150, 119);
            this.producto_tb.Name = "producto_tb";
            this.producto_tb.ReadOnly = true;
            this.producto_tb.Size = new System.Drawing.Size(192, 29);
            this.producto_tb.TabIndex = 33;
            this.producto_tb.TabStop = false;
            this.producto_tb.Text = "N/A";
            // 
            // producto_label
            // 
            this.producto_label.AutoSize = true;
            this.producto_label.Location = new System.Drawing.Point(145, 91);
            this.producto_label.Name = "producto_label";
            this.producto_label.Size = new System.Drawing.Size(89, 25);
            this.producto_label.TabIndex = 39;
            this.producto_label.Text = "Producto";
            // 
            // unidades_vendidas_tb
            // 
            this.unidades_vendidas_tb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unidades_vendidas_tb.Location = new System.Drawing.Point(348, 119);
            this.unidades_vendidas_tb.Name = "unidades_vendidas_tb";
            this.unidades_vendidas_tb.ReadOnly = true;
            this.unidades_vendidas_tb.Size = new System.Drawing.Size(91, 29);
            this.unidades_vendidas_tb.TabIndex = 34;
            this.unidades_vendidas_tb.TabStop = false;
            this.unidades_vendidas_tb.Text = "N/A";
            // 
            // unidades_vendidas_label
            // 
            this.unidades_vendidas_label.AutoSize = true;
            this.unidades_vendidas_label.Location = new System.Drawing.Point(343, 66);
            this.unidades_vendidas_label.Name = "unidades_vendidas_label";
            this.unidades_vendidas_label.Size = new System.Drawing.Size(96, 50);
            this.unidades_vendidas_label.TabIndex = 38;
            this.unidades_vendidas_label.Text = "Unidades \r\nvendidas";
            // 
            // venta_id_tb
            // 
            this.venta_id_tb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.venta_id_tb.Location = new System.Drawing.Point(21, 259);
            this.venta_id_tb.Name = "venta_id_tb";
            this.venta_id_tb.Size = new System.Drawing.Size(123, 29);
            this.venta_id_tb.TabIndex = 0;
            this.venta_id_tb.TabStop = false;
            // 
            // venta_id_label
            // 
            this.venta_id_label.AutoSize = true;
            this.venta_id_label.Location = new System.Drawing.Point(16, 231);
            this.venta_id_label.Name = "venta_id_label";
            this.venta_id_label.Size = new System.Drawing.Size(81, 25);
            this.venta_id_label.TabIndex = 44;
            this.venta_id_label.Text = "ID venta";
            // 
            // eliminar_venta_button
            // 
            this.eliminar_venta_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminar_venta_button.ForeColor = System.Drawing.Color.Crimson;
            this.eliminar_venta_button.Location = new System.Drawing.Point(764, 253);
            this.eliminar_venta_button.Name = "eliminar_venta_button";
            this.eliminar_venta_button.Size = new System.Drawing.Size(154, 37);
            this.eliminar_venta_button.TabIndex = 2;
            this.eliminar_venta_button.Text = "Eliminar venta";
            this.eliminar_venta_button.UseVisualStyleBackColor = true;
            this.eliminar_venta_button.Click += new System.EventHandler(this.eliminar_venta_button_Click);
            // 
            // cargar_venta_button
            // 
            this.cargar_venta_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cargar_venta_button.Location = new System.Drawing.Point(150, 253);
            this.cargar_venta_button.Name = "cargar_venta_button";
            this.cargar_venta_button.Size = new System.Drawing.Size(139, 37);
            this.cargar_venta_button.TabIndex = 1;
            this.cargar_venta_button.Text = "Cargar venta";
            this.cargar_venta_button.UseVisualStyleBackColor = true;
            this.cargar_venta_button.Click += new System.EventHandler(this.cargar_venta_button_Click);
            // 
            // total_tb
            // 
            this.total_tb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_tb.Location = new System.Drawing.Point(445, 119);
            this.total_tb.Name = "total_tb";
            this.total_tb.ReadOnly = true;
            this.total_tb.Size = new System.Drawing.Size(125, 29);
            this.total_tb.TabIndex = 35;
            this.total_tb.TabStop = false;
            this.total_tb.Text = "N/A";
            // 
            // total_label
            // 
            this.total_label.AutoSize = true;
            this.total_label.Location = new System.Drawing.Point(440, 91);
            this.total_label.Name = "total_label";
            this.total_label.Size = new System.Drawing.Size(52, 25);
            this.total_label.TabIndex = 48;
            this.total_label.Text = "Total";
            // 
            // EliminarVentaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 300);
            this.Controls.Add(this.total_tb);
            this.Controls.Add(this.total_label);
            this.Controls.Add(this.cargar_venta_button);
            this.Controls.Add(this.eliminar_venta_button);
            this.Controls.Add(this.venta_id_label);
            this.Controls.Add(this.venta_id_tb);
            this.Controls.Add(this.lote_id_tb);
            this.Controls.Add(this.lote_id_label);
            this.Controls.Add(this.cliente_tb);
            this.Controls.Add(this.cliente_label);
            this.Controls.Add(this.fecha_venta_tb);
            this.Controls.Add(this.fecha_label);
            this.Controls.Add(this.producto_tb);
            this.Controls.Add(this.producto_label);
            this.Controls.Add(this.unidades_vendidas_tb);
            this.Controls.Add(this.unidades_vendidas_label);
            this.Controls.Add(this.header_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "EliminarVentaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar venta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.TextBox lote_id_tb;
        private System.Windows.Forms.Label lote_id_label;
        private System.Windows.Forms.TextBox cliente_tb;
        private System.Windows.Forms.Label cliente_label;
        private System.Windows.Forms.TextBox fecha_venta_tb;
        private System.Windows.Forms.Label fecha_label;
        private System.Windows.Forms.TextBox producto_tb;
        private System.Windows.Forms.Label producto_label;
        private System.Windows.Forms.TextBox unidades_vendidas_tb;
        private System.Windows.Forms.Label unidades_vendidas_label;
        private System.Windows.Forms.TextBox venta_id_tb;
        private System.Windows.Forms.Label venta_id_label;
        private System.Windows.Forms.Button eliminar_venta_button;
        private System.Windows.Forms.Button cargar_venta_button;
        private System.Windows.Forms.TextBox total_tb;
        private System.Windows.Forms.Label total_label;
    }
}