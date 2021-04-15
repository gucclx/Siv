namespace SivUI
{
    partial class InicioForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crear_producto_ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.editar_producto_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregar_inventario_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historial_inventario_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.venderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historial_ventas_ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crear_categorias_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminar_categorias_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crear_clientes_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editar_cliente_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editar_lotes_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.inventarioToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.categoriasToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.exportarToolStripMenuItem,
            this.lotesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crear_producto_ToolStripMenuItem2,
            this.editar_producto_ToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // crear_producto_ToolStripMenuItem2
            // 
            this.crear_producto_ToolStripMenuItem2.Name = "crear_producto_ToolStripMenuItem2";
            this.crear_producto_ToolStripMenuItem2.Size = new System.Drawing.Size(104, 22);
            this.crear_producto_ToolStripMenuItem2.Text = "Crear";
            this.crear_producto_ToolStripMenuItem2.Click += new System.EventHandler(this.crear_producto_ToolStripMenuItem2_Click);
            // 
            // editar_producto_ToolStripMenuItem
            // 
            this.editar_producto_ToolStripMenuItem.Name = "editar_producto_ToolStripMenuItem";
            this.editar_producto_ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.editar_producto_ToolStripMenuItem.Text = "Editar";
            this.editar_producto_ToolStripMenuItem.Click += new System.EventHandler(this.editar_producto_ToolStripMenuItem_Click);
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregar_inventario_ToolStripMenuItem,
            this.historial_inventario_ToolStripMenuItem});
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // agregar_inventario_ToolStripMenuItem
            // 
            this.agregar_inventario_ToolStripMenuItem.Name = "agregar_inventario_ToolStripMenuItem";
            this.agregar_inventario_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.agregar_inventario_ToolStripMenuItem.Text = "Agregar";
            this.agregar_inventario_ToolStripMenuItem.Click += new System.EventHandler(this.agregar_inventario_ToolStripMenuItem_Click);
            // 
            // historial_inventario_ToolStripMenuItem
            // 
            this.historial_inventario_ToolStripMenuItem.Name = "historial_inventario_ToolStripMenuItem";
            this.historial_inventario_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.historial_inventario_ToolStripMenuItem.Text = "Historial";
            this.historial_inventario_ToolStripMenuItem.Click += new System.EventHandler(this.historial_inventario_ToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.venderToolStripMenuItem,
            this.historial_ventas_ToolStripMenuItem1});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // venderToolStripMenuItem
            // 
            this.venderToolStripMenuItem.Name = "venderToolStripMenuItem";
            this.venderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.venderToolStripMenuItem.Text = "Vender";
            this.venderToolStripMenuItem.Click += new System.EventHandler(this.venderToolStripMenuItem_Click);
            // 
            // historial_ventas_ToolStripMenuItem1
            // 
            this.historial_ventas_ToolStripMenuItem1.Name = "historial_ventas_ToolStripMenuItem1";
            this.historial_ventas_ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.historial_ventas_ToolStripMenuItem1.Text = "Historial";
            this.historial_ventas_ToolStripMenuItem1.Click += new System.EventHandler(this.historial_ventas_ToolStripMenuItem_Click);
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crear_categorias_ToolStripMenuItem,
            this.eliminar_categorias_ToolStripMenuItem});
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            // 
            // crear_categorias_ToolStripMenuItem
            // 
            this.crear_categorias_ToolStripMenuItem.Name = "crear_categorias_ToolStripMenuItem";
            this.crear_categorias_ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.crear_categorias_ToolStripMenuItem.Text = "Crear";
            this.crear_categorias_ToolStripMenuItem.Click += new System.EventHandler(this.crear_categorias_ToolStripMenuItem_Click);
            // 
            // eliminar_categorias_ToolStripMenuItem
            // 
            this.eliminar_categorias_ToolStripMenuItem.Name = "eliminar_categorias_ToolStripMenuItem";
            this.eliminar_categorias_ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminar_categorias_ToolStripMenuItem.Text = "Eliminar";
            this.eliminar_categorias_ToolStripMenuItem.Click += new System.EventHandler(this.eliminar_categorias_ToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crear_clientes_ToolStripMenuItem,
            this.editar_cliente_ToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // crear_clientes_ToolStripMenuItem
            // 
            this.crear_clientes_ToolStripMenuItem.Name = "crear_clientes_ToolStripMenuItem";
            this.crear_clientes_ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.crear_clientes_ToolStripMenuItem.Text = "Crear";
            this.crear_clientes_ToolStripMenuItem.Click += new System.EventHandler(this.crear_clientes_ToolStripMenuItem_Click);
            // 
            // editar_cliente_ToolStripMenuItem
            // 
            this.editar_cliente_ToolStripMenuItem.Name = "editar_cliente_ToolStripMenuItem";
            this.editar_cliente_ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.editar_cliente_ToolStripMenuItem.Text = "Editar";
            this.editar_cliente_ToolStripMenuItem.Click += new System.EventHandler(this.editar_cliente_ToolStripMenuItem_Click);
            // 
            // exportarToolStripMenuItem
            // 
            this.exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            this.exportarToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.exportarToolStripMenuItem.Text = "Exportar";
            this.exportarToolStripMenuItem.Click += new System.EventHandler(this.exportarToolStripMenuItem_Click);
            // 
            // lotesToolStripMenuItem
            // 
            this.lotesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editar_lotes_ToolStripMenuItem});
            this.lotesToolStripMenuItem.Name = "lotesToolStripMenuItem";
            this.lotesToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.lotesToolStripMenuItem.Text = "Lotes";
            // 
            // editar_lotes_ToolStripMenuItem
            // 
            this.editar_lotes_ToolStripMenuItem.Name = "editar_lotes_ToolStripMenuItem";
            this.editar_lotes_ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.editar_lotes_ToolStripMenuItem.Text = "Editar";
            this.editar_lotes_ToolStripMenuItem.Click += new System.EventHandler(this.editar_lotes_ToolStripMenuItem_Click);
            // 
            // InicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "InicioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregar_inventario_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem venderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crear_categorias_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminar_categorias_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crear_clientes_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editar_cliente_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historial_inventario_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historial_ventas_ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crear_producto_ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editar_producto_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editar_lotes_ToolStripMenuItem;
    }
}