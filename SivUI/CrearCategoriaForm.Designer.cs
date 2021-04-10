namespace SivUI
{
    partial class CrearCategoriaForm
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
            this.agregar_categoria_button = new System.Windows.Forms.Button();
            this.header_label = new System.Windows.Forms.Label();
            this.nombre_categoria_tb = new System.Windows.Forms.TextBox();
            this.nombre_categoria_label = new System.Windows.Forms.Label();
            this.categorias_listbox = new System.Windows.Forms.ListBox();
            this.crear_categorias_button = new System.Windows.Forms.Button();
            this.remover_categoria_button = new System.Windows.Forms.Button();
            this.categorias_a_crear_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // agregar_categoria_button
            // 
            this.agregar_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_categoria_button.Location = new System.Drawing.Point(15, 123);
            this.agregar_categoria_button.Name = "agregar_categoria_button";
            this.agregar_categoria_button.Size = new System.Drawing.Size(115, 37);
            this.agregar_categoria_button.TabIndex = 15;
            this.agregar_categoria_button.Text = "Agregar";
            this.agregar_categoria_button.UseVisualStyleBackColor = true;
            this.agregar_categoria_button.Click += new System.EventHandler(this.agregar_categoria_button_Click);
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(150, 24);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(231, 30);
            this.header_label.TabIndex = 14;
            this.header_label.Text = "Creación de categorías";
            // 
            // nombre_categoria_tb
            // 
            this.nombre_categoria_tb.Location = new System.Drawing.Point(15, 84);
            this.nombre_categoria_tb.Name = "nombre_categoria_tb";
            this.nombre_categoria_tb.Size = new System.Drawing.Size(500, 33);
            this.nombre_categoria_tb.TabIndex = 13;
            this.nombre_categoria_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nombre_categoria_tb_KeyDown);
            // 
            // nombre_categoria_label
            // 
            this.nombre_categoria_label.AutoSize = true;
            this.nombre_categoria_label.Location = new System.Drawing.Point(10, 56);
            this.nombre_categoria_label.Name = "nombre_categoria_label";
            this.nombre_categoria_label.Size = new System.Drawing.Size(81, 25);
            this.nombre_categoria_label.TabIndex = 12;
            this.nombre_categoria_label.Text = "Nombre";
            // 
            // categorias_listbox
            // 
            this.categorias_listbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_listbox.FormattingEnabled = true;
            this.categorias_listbox.HorizontalScrollbar = true;
            this.categorias_listbox.ItemHeight = 21;
            this.categorias_listbox.Location = new System.Drawing.Point(15, 209);
            this.categorias_listbox.Name = "categorias_listbox";
            this.categorias_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categorias_listbox.Size = new System.Drawing.Size(500, 130);
            this.categorias_listbox.TabIndex = 16;
            // 
            // crear_categorias_button
            // 
            this.crear_categorias_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crear_categorias_button.Location = new System.Drawing.Point(392, 345);
            this.crear_categorias_button.Name = "crear_categorias_button";
            this.crear_categorias_button.Size = new System.Drawing.Size(123, 37);
            this.crear_categorias_button.TabIndex = 18;
            this.crear_categorias_button.Text = "Crear";
            this.crear_categorias_button.UseVisualStyleBackColor = true;
            this.crear_categorias_button.Click += new System.EventHandler(this.crear_categorias_button_Click);
            // 
            // remover_categoria_button
            // 
            this.remover_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_categoria_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.remover_categoria_button.Location = new System.Drawing.Point(15, 345);
            this.remover_categoria_button.MaximumSize = new System.Drawing.Size(800, 600);
            this.remover_categoria_button.Name = "remover_categoria_button";
            this.remover_categoria_button.Size = new System.Drawing.Size(206, 37);
            this.remover_categoria_button.TabIndex = 17;
            this.remover_categoria_button.Text = "Remover selección";
            this.remover_categoria_button.UseVisualStyleBackColor = true;
            this.remover_categoria_button.Click += new System.EventHandler(this.remover_categoria_button_Click);
            // 
            // categorias_a_crear_label
            // 
            this.categorias_a_crear_label.AutoSize = true;
            this.categorias_a_crear_label.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_a_crear_label.Location = new System.Drawing.Point(10, 181);
            this.categorias_a_crear_label.Name = "categorias_a_crear_label";
            this.categorias_a_crear_label.Size = new System.Drawing.Size(165, 25);
            this.categorias_a_crear_label.TabIndex = 20;
            this.categorias_a_crear_label.Text = "Categorias a crear";
            // 
            // CrearCategoriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(524, 405);
            this.Controls.Add(this.categorias_a_crear_label);
            this.Controls.Add(this.remover_categoria_button);
            this.Controls.Add(this.crear_categorias_button);
            this.Controls.Add(this.categorias_listbox);
            this.Controls.Add(this.agregar_categoria_button);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.nombre_categoria_tb);
            this.Controls.Add(this.nombre_categoria_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CrearCategoriaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear categoría";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button agregar_categoria_button;
        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.TextBox nombre_categoria_tb;
        private System.Windows.Forms.Label nombre_categoria_label;
        private System.Windows.Forms.ListBox categorias_listbox;
        private System.Windows.Forms.Button crear_categorias_button;
        private System.Windows.Forms.Button remover_categoria_button;
        private System.Windows.Forms.Label categorias_a_crear_label;
    }
}