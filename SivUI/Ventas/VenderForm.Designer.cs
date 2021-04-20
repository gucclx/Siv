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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VenderForm));
            this.lote_id_tb = new System.Windows.Forms.TextBox();
            this.lote_id_label = new System.Windows.Forms.Label();
            this.agregar_lote_button = new System.Windows.Forms.Button();
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
            this.crear_nuevo_cliente_label = new System.Windows.Forms.LinkLabel();
            this.limpiar_cliente_button = new System.Windows.Forms.Button();
            this.panel_contenedor = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ventas_dtgv)).BeginInit();
            this.panel_contenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lote_id_tb
            // 
            this.lote_id_tb.Location = new System.Drawing.Point(10, 37);
            this.lote_id_tb.Name = "lote_id_tb";
            this.lote_id_tb.Size = new System.Drawing.Size(136, 33);
            this.lote_id_tb.TabIndex = 1;
            // 
            // lote_id_label
            // 
            this.lote_id_label.AutoSize = true;
            this.lote_id_label.Location = new System.Drawing.Point(5, 9);
            this.lote_id_label.Name = "lote_id_label";
            this.lote_id_label.Size = new System.Drawing.Size(67, 25);
            this.lote_id_label.TabIndex = 0;
            this.lote_id_label.Text = "ID lote";
            // 
            // agregar_lote_button
            // 
            this.agregar_lote_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_lote_button.Location = new System.Drawing.Point(299, 34);
            this.agregar_lote_button.Name = "agregar_lote_button";
            this.agregar_lote_button.Size = new System.Drawing.Size(101, 37);
            this.agregar_lote_button.TabIndex = 4;
            this.agregar_lote_button.Text = "Agregar";
            this.agregar_lote_button.UseVisualStyleBackColor = true;
            this.agregar_lote_button.Click += new System.EventHandler(this.agregar_lote_button_Click);
            // 
            // ventas_dtgv
            // 
            this.ventas_dtgv.AllowUserToAddRows = false;
            this.ventas_dtgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ventas_dtgv.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.ventas_dtgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ventas_dtgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ventas_dtgv.Location = new System.Drawing.Point(0, 0);
            this.ventas_dtgv.Name = "ventas_dtgv";
            this.ventas_dtgv.Size = new System.Drawing.Size(760, 296);
            this.ventas_dtgv.TabIndex = 12;
            this.ventas_dtgv.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ventas_dtgv_CellValidating);
            // 
            // total_tb
            // 
            this.total_tb.Location = new System.Drawing.Point(588, 400);
            this.total_tb.Name = "total_tb";
            this.total_tb.ReadOnly = true;
            this.total_tb.Size = new System.Drawing.Size(184, 33);
            this.total_tb.TabIndex = 14;
            this.total_tb.Text = "0";
            // 
            // total_label
            // 
            this.total_label.AutoSize = true;
            this.total_label.Location = new System.Drawing.Point(583, 375);
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
            this.unidades_label.Location = new System.Drawing.Point(147, 9);
            this.unidades_label.Name = "unidades_label";
            this.unidades_label.Size = new System.Drawing.Size(91, 25);
            this.unidades_label.TabIndex = 2;
            this.unidades_label.Text = "Unidades";
            // 
            // unidades_tb
            // 
            this.unidades_tb.Location = new System.Drawing.Point(152, 37);
            this.unidades_tb.Name = "unidades_tb";
            this.unidades_tb.Size = new System.Drawing.Size(141, 33);
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
            this.cliente_tb.Location = new System.Drawing.Point(17, 403);
            this.cliente_tb.Name = "cliente_tb";
            this.cliente_tb.ReadOnly = true;
            this.cliente_tb.Size = new System.Drawing.Size(276, 33);
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
            this.buscar_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_linklabel.Location = new System.Drawing.Point(87, 378);
            this.buscar_linklabel.Name = "buscar_linklabel";
            this.buscar_linklabel.Size = new System.Drawing.Size(56, 21);
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
            this.comentario_tb.Size = new System.Drawing.Size(385, 75);
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
            // crear_nuevo_cliente_label
            // 
            this.crear_nuevo_cliente_label.AutoSize = true;
            this.crear_nuevo_cliente_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crear_nuevo_cliente_label.Location = new System.Drawing.Point(198, 378);
            this.crear_nuevo_cliente_label.Name = "crear_nuevo_cliente_label";
            this.crear_nuevo_cliente_label.Size = new System.Drawing.Size(95, 21);
            this.crear_nuevo_cliente_label.TabIndex = 23;
            this.crear_nuevo_cliente_label.TabStop = true;
            this.crear_nuevo_cliente_label.Text = "Crear nuevo";
            this.crear_nuevo_cliente_label.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.crear_nuevo_cliente_label_LinkClicked);
            // 
            // limpiar_cliente_button
            // 
            this.limpiar_cliente_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.limpiar_cliente_button.Location = new System.Drawing.Point(299, 400);
            this.limpiar_cliente_button.Name = "limpiar_cliente_button";
            this.limpiar_cliente_button.Size = new System.Drawing.Size(101, 37);
            this.limpiar_cliente_button.TabIndex = 24;
            this.limpiar_cliente_button.Text = "Limpiar";
            this.limpiar_cliente_button.UseVisualStyleBackColor = true;
            this.limpiar_cliente_button.Click += new System.EventHandler(this.limpiar_cliente_button_Click);
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.Controls.Add(this.ventas_dtgv);
            this.panel_contenedor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_contenedor.Location = new System.Drawing.Point(12, 76);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(760, 296);
            this.panel_contenedor.TabIndex = 25;
            // 
            // VenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel_contenedor);
            this.Controls.Add(this.limpiar_cliente_button);
            this.Controls.Add(this.crear_nuevo_cliente_label);
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
            this.Controls.Add(this.agregar_lote_button);
            this.Controls.Add(this.lote_id_tb);
            this.Controls.Add(this.lote_id_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "VenderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vender";
            ((System.ComponentModel.ISupportInitialize)(this.ventas_dtgv)).EndInit();
            this.panel_contenedor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lote_id_tb;
        private System.Windows.Forms.Label lote_id_label;
        private System.Windows.Forms.Button agregar_lote_button;
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
        private System.Windows.Forms.LinkLabel crear_nuevo_cliente_label;
        private System.Windows.Forms.Button limpiar_cliente_button;
        private System.Windows.Forms.Panel panel_contenedor;
    }
}