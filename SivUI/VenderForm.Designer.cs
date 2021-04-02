namespace SivUI
{
    partial class pago_tb
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
            this.unidades_tb = new System.Windows.Forms.TextBox();
            this.id_producto_label = new System.Windows.Forms.Label();
            this.agregar_producto_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inversion_unidad_tb = new System.Windows.Forms.TextBox();
            this.total_label = new System.Windows.Forms.Label();
            this.vender_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pago_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // unidades_tb
            // 
            this.unidades_tb.Location = new System.Drawing.Point(130, 12);
            this.unidades_tb.Name = "unidades_tb";
            this.unidades_tb.Size = new System.Drawing.Size(125, 33);
            this.unidades_tb.TabIndex = 4;
            // 
            // id_producto_label
            // 
            this.id_producto_label.AutoSize = true;
            this.id_producto_label.Location = new System.Drawing.Point(12, 15);
            this.id_producto_label.Name = "id_producto_label";
            this.id_producto_label.Size = new System.Drawing.Size(112, 25);
            this.id_producto_label.TabIndex = 3;
            this.id_producto_label.Text = "ID producto";
            // 
            // agregar_producto_button
            // 
            this.agregar_producto_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_producto_button.Location = new System.Drawing.Point(261, 9);
            this.agregar_producto_button.Name = "agregar_producto_button";
            this.agregar_producto_button.Size = new System.Drawing.Size(100, 37);
            this.agregar_producto_button.TabIndex = 11;
            this.agregar_producto_button.Text = "Agregar";
            this.agregar_producto_button.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 200);
            this.dataGridView1.TabIndex = 12;
            // 
            // inversion_unidad_tb
            // 
            this.inversion_unidad_tb.Location = new System.Drawing.Point(622, 312);
            this.inversion_unidad_tb.Name = "inversion_unidad_tb";
            this.inversion_unidad_tb.ReadOnly = true;
            this.inversion_unidad_tb.Size = new System.Drawing.Size(150, 33);
            this.inversion_unidad_tb.TabIndex = 14;
            // 
            // total_label
            // 
            this.total_label.AutoSize = true;
            this.total_label.Location = new System.Drawing.Point(564, 315);
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
            this.vender_button.TabIndex = 17;
            this.vender_button.Text = "Vender";
            this.vender_button.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 424);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 33);
            this.textBox1.TabIndex = 19;
            // 
            // pago_label
            // 
            this.pago_label.AutoSize = true;
            this.pago_label.Location = new System.Drawing.Point(12, 427);
            this.pago_label.Name = "pago_label";
            this.pago_label.Size = new System.Drawing.Size(54, 25);
            this.pago_label.TabIndex = 18;
            this.pago_label.Text = "Pago";
            // 
            // pago_tb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pago_label);
            this.Controls.Add(this.vender_button);
            this.Controls.Add(this.inversion_unidad_tb);
            this.Controls.Add(this.total_label);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.agregar_producto_button);
            this.Controls.Add(this.unidades_tb);
            this.Controls.Add(this.id_producto_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "pago_tb";
            this.Text = "Vender";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox unidades_tb;
        private System.Windows.Forms.Label id_producto_label;
        private System.Windows.Forms.Button agregar_producto_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox inversion_unidad_tb;
        private System.Windows.Forms.Label total_label;
        private System.Windows.Forms.Button vender_button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label pago_label;
    }
}