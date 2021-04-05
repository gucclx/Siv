namespace SivUI
{
    partial class VenderForm
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
            this.producto_id_tb = new System.Windows.Forms.TextBox();
            this.id_producto_label = new System.Windows.Forms.Label();
            this.agregar_producto_button = new System.Windows.Forms.Button();
            this.ventas_dtgv = new System.Windows.Forms.DataGridView();
            this.total_tb = new System.Windows.Forms.TextBox();
            this.total_label = new System.Windows.Forms.Label();
            this.vender_button = new System.Windows.Forms.Button();
            this.unidades_label = new System.Windows.Forms.Label();
            this.unidades_tb = new System.Windows.Forms.TextBox();
            this.remover_venta_button = new System.Windows.Forms.Button();
            this.cliente_tb = new System.Windows.Forms.TextBox();
            this.cliente_label = new System.Windows.Forms.Label();
            this.buscar_linklabel = new System.Windows.Forms.LinkLabel();
            this.comentario_tb = new System.Windows.Forms.TextBox();
            this.comentario_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ventas_dtgv)).BeginInit();
            this.SuspendLayout();
            // 
            // producto_id_tb
            // 
            this.producto_id_tb.Location = new System.Drawing.Point(10, 37);
            this.producto_id_tb.Name = "producto_id_tb";
            this.producto_id_tb.Size = new System.Drawing.Size(167, 33);
            this.producto_id_tb.TabIndex = 1;
            // 
            // id_producto_label
            // 
            this.id_producto_label.AutoSize = true;
            this.id_producto_label.Location = new System.Drawing.Point(5, 9);
            this.id_producto_label.Name = "id_producto_label";
            this.id_producto_label.Size = new System.Drawing.Size(112, 25);
            this.id_producto_label.TabIndex = 0;
            this.id_producto_label.Text = "ID producto";
            // 
            // agregar_producto_button
            // 
            this.agregar_producto_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_producto_button.Location = new System.Drawing.Point(275, 34);
            this.agregar_producto_button.Name = "agregar_producto_button";
            this.agregar_producto_button.Size = new System.Drawing.Size(100, 37);
            this.agregar_producto_button.TabIndex = 4;
            this.agregar_producto_button.Text = "Agregar";
            this.agregar_producto_button.UseVisualStyleBackColor = true;
            this.agregar_producto_button.Click += new System.EventHandler(this.agregar_producto_button_Click);
            // 
            // ventas_dtgv
            // 
            this.ventas_dtgv.AllowUserToAddRows = false;
            this.ventas_dtgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ventas_dtgv.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.ventas_dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ventas_dtgv.Location = new System.Drawing.Point(10, 77);
            this.ventas_dtgv.Name = "ventas_dtgv";
            this.ventas_dtgv.Size = new System.Drawing.Size(762, 289);
            this.ventas_dtgv.TabIndex = 12;
            this.ventas_dtgv.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ventas_dtgv_CellValidating);
            // 
            // total_tb
            // 
            this.total_tb.Location = new System.Drawing.Point(622, 372);
            this.total_tb.Name = "total_tb";
            this.total_tb.ReadOnly = true;
            this.total_tb.Size = new System.Drawing.Size(150, 33);
            this.total_tb.TabIndex = 14;
            this.total_tb.Text = "0";
            // 
            // total_label
            // 
            this.total_label.AutoSize = true;
            this.total_label.Location = new System.Drawing.Point(564, 375);
            this.total_label.Name = "total_label";
            this.total_label.Size = new System.Drawing.Size(52, 25);
            this.total_label.TabIndex = 13;
            this.total_label.Text = "Total";
            // 
            // vender_button
            // 
            this.vender_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vender_button.Location = new System.Drawing.Point(647, 512);
            this.vender_button.Name = "vender_button";
            this.vender_button.Size = new System.Drawing.Size(125, 37);
            this.vender_button.TabIndex = 5;
            this.vender_button.Text = "Vender";
            this.vender_button.UseVisualStyleBackColor = true;
            this.vender_button.Click += new System.EventHandler(this.vender_button_Click);
            // 
            // unidades_label
            // 
            this.unidades_label.AutoSize = true;
            this.unidades_label.Location = new System.Drawing.Point(178, 9);
            this.unidades_label.Name = "unidades_label";
            this.unidades_label.Size = new System.Drawing.Size(91, 25);
            this.unidades_label.TabIndex = 2;
            this.unidades_label.Text = "Unidades";
            // 
            // unidades_tb
            // 
            this.unidades_tb.Location = new System.Drawing.Point(183, 37);
            this.unidades_tb.Name = "unidades_tb";
            this.unidades_tb.Size = new System.Drawing.Size(86, 33);
            this.unidades_tb.TabIndex = 3;
            // 
            // remover_venta_button
            // 
            this.remover_venta_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_venta_button.Location = new System.Drawing.Point(588, 34);
            this.remover_venta_button.Name = "remover_venta_button";
            this.remover_venta_button.Size = new System.Drawing.Size(184, 37);
            this.remover_venta_button.TabIndex = 16;
            this.remover_venta_button.Text = "Remover selección";
            this.remover_venta_button.UseVisualStyleBackColor = true;
            this.remover_venta_button.Click += new System.EventHandler(this.remover_venta_button_Click);
            // 
            // cliente_tb
            // 
            this.cliente_tb.Location = new System.Drawing.Point(87, 372);
            this.cliente_tb.Name = "cliente_tb";
            this.cliente_tb.ReadOnly = true;
            this.cliente_tb.Size = new System.Drawing.Size(182, 33);
            this.cliente_tb.TabIndex = 18;
            this.cliente_tb.TabStop = false;
            // 
            // cliente_label
            // 
            this.cliente_label.AutoSize = true;
            this.cliente_label.Location = new System.Drawing.Point(10, 375);
            this.cliente_label.Name = "cliente_label";
            this.cliente_label.Size = new System.Drawing.Size(71, 25);
            this.cliente_label.TabIndex = 17;
            this.cliente_label.Text = "Cliente";
            // 
            // buscar_linklabel
            // 
            this.buscar_linklabel.AutoSize = true;
            this.buscar_linklabel.Location = new System.Drawing.Point(270, 375);
            this.buscar_linklabel.Name = "buscar_linklabel";
            this.buscar_linklabel.Size = new System.Drawing.Size(68, 25);
            this.buscar_linklabel.TabIndex = 19;
            this.buscar_linklabel.TabStop = true;
            this.buscar_linklabel.Text = "Buscar";
            this.buscar_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buscar_linklabel_LinkClicked);
            // 
            // comentario_tb
            // 
            this.comentario_tb.Location = new System.Drawing.Point(15, 474);
            this.comentario_tb.Multiline = true;
            this.comentario_tb.Name = "comentario_tb";
            this.comentario_tb.Size = new System.Drawing.Size(323, 75);
            this.comentario_tb.TabIndex = 21;
            // 
            // comentario_label
            // 
            this.comentario_label.AutoSize = true;
            this.comentario_label.Location = new System.Drawing.Point(12, 446);
            this.comentario_label.Name = "comentario_label";
            this.comentario_label.Size = new System.Drawing.Size(111, 25);
            this.comentario_label.TabIndex = 20;
            this.comentario_label.Text = "Comentario";
            // 
            // VenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.comentario_tb);
            this.Controls.Add(this.comentario_label);
            this.Controls.Add(this.buscar_linklabel);
            this.Controls.Add(this.cliente_tb);
            this.Controls.Add(this.cliente_label);
            this.Controls.Add(this.remover_venta_button);
            this.Controls.Add(this.unidades_tb);
            this.Controls.Add(this.unidades_label);
            this.Controls.Add(this.vender_button);
            this.Controls.Add(this.total_tb);
            this.Controls.Add(this.total_label);
            this.Controls.Add(this.ventas_dtgv);
            this.Controls.Add(this.agregar_producto_button);
            this.Controls.Add(this.producto_id_tb);
            this.Controls.Add(this.id_producto_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "VenderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vender";
            ((System.ComponentModel.ISupportInitialize)(this.ventas_dtgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox producto_id_tb;
        private System.Windows.Forms.Label id_producto_label;
        private System.Windows.Forms.Button agregar_producto_button;
        private System.Windows.Forms.DataGridView ventas_dtgv;
        private System.Windows.Forms.TextBox total_tb;
        private System.Windows.Forms.Label total_label;
        private System.Windows.Forms.Button vender_button;
        private System.Windows.Forms.Label unidades_label;
        private System.Windows.Forms.TextBox unidades_tb;
        private System.Windows.Forms.Button remover_venta_button;
        private System.Windows.Forms.TextBox cliente_tb;
        private System.Windows.Forms.Label cliente_label;
        private System.Windows.Forms.LinkLabel buscar_linklabel;
        private System.Windows.Forms.TextBox comentario_tb;
        private System.Windows.Forms.Label comentario_label;
    }
}