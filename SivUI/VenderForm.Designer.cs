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
            this.limpiar_button = new System.Windows.Forms.Button();
            this.remover_venta_button = new System.Windows.Forms.Button();
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
            this.ventas_dtgv.Size = new System.Drawing.Size(792, 328);
            this.ventas_dtgv.TabIndex = 12;
            this.ventas_dtgv.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ventas_dtgv_CellValidating);
            // 
            // total_tb
            // 
            this.total_tb.Location = new System.Drawing.Point(652, 411);
            this.total_tb.Name = "total_tb";
            this.total_tb.ReadOnly = true;
            this.total_tb.Size = new System.Drawing.Size(150, 33);
            this.total_tb.TabIndex = 14;
            this.total_tb.Text = "0";
            // 
            // total_label
            // 
            this.total_label.AutoSize = true;
            this.total_label.Location = new System.Drawing.Point(594, 414);
            this.total_label.Name = "total_label";
            this.total_label.Size = new System.Drawing.Size(52, 25);
            this.total_label.TabIndex = 13;
            this.total_label.Text = "Total";
            // 
            // vender_button
            // 
            this.vender_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vender_button.Location = new System.Drawing.Point(677, 512);
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
            // limpiar_button
            // 
            this.limpiar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiar_button.Location = new System.Drawing.Point(10, 512);
            this.limpiar_button.Name = "limpiar_button";
            this.limpiar_button.Size = new System.Drawing.Size(125, 37);
            this.limpiar_button.TabIndex = 15;
            this.limpiar_button.Text = "Limpiar";
            this.limpiar_button.UseVisualStyleBackColor = true;
            this.limpiar_button.Click += new System.EventHandler(this.limpiar_button_Click);
            // 
            // remover_venta_button
            // 
            this.remover_venta_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_venta_button.Location = new System.Drawing.Point(12, 414);
            this.remover_venta_button.Name = "remover_venta_button";
            this.remover_venta_button.Size = new System.Drawing.Size(203, 37);
            this.remover_venta_button.TabIndex = 16;
            this.remover_venta_button.Text = "Remover selección";
            this.remover_venta_button.UseVisualStyleBackColor = true;
            this.remover_venta_button.Click += new System.EventHandler(this.remover_venta_button_Click);
            // 
            // VenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(814, 561);
            this.Controls.Add(this.remover_venta_button);
            this.Controls.Add(this.limpiar_button);
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
        private System.Windows.Forms.Button limpiar_button;
        private System.Windows.Forms.Button remover_venta_button;
    }
}