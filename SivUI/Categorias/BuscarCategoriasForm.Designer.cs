namespace SivUI
{
    partial class BuscarCategoriasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarCategoriasForm));
            this.header_label = new System.Windows.Forms.Label();
            this.resultados_label = new System.Windows.Forms.Label();
            this.remover_categoria_button = new System.Windows.Forms.Button();
            this.resultados_listbox = new System.Windows.Forms.ListBox();
            this.agregar_categoria_button = new System.Windows.Forms.Button();
            this.nombre_categoria_tb = new System.Windows.Forms.TextBox();
            this.nombre_categoria_label = new System.Windows.Forms.Label();
            this.categorias_seleccionadas_listbox = new System.Windows.Forms.ListBox();
            this.categorias_seleccionadas_label = new System.Windows.Forms.Label();
            this.buscar_button = new System.Windows.Forms.Button();
            this.listo_button = new System.Windows.Forms.Button();
            this.tarea_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(271, 10);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(242, 30);
            this.header_label.TabIndex = 3;
            this.header_label.Text = "Búsqueda de categorias";
            // 
            // resultados_label
            // 
            this.resultados_label.AutoSize = true;
            this.resultados_label.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultados_label.Location = new System.Drawing.Point(20, 119);
            this.resultados_label.Name = "resultados_label";
            this.resultados_label.Size = new System.Drawing.Size(102, 25);
            this.resultados_label.TabIndex = 26;
            this.resultados_label.Text = "Resultados";
            // 
            // remover_categoria_button
            // 
            this.remover_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_categoria_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.remover_categoria_button.Location = new System.Drawing.Point(558, 262);
            this.remover_categoria_button.MaximumSize = new System.Drawing.Size(800, 600);
            this.remover_categoria_button.Name = "remover_categoria_button";
            this.remover_categoria_button.Size = new System.Drawing.Size(206, 37);
            this.remover_categoria_button.TabIndex = 25;
            this.remover_categoria_button.Text = "Remover selección";
            this.remover_categoria_button.UseVisualStyleBackColor = true;
            this.remover_categoria_button.Click += new System.EventHandler(this.remover_categoria_button_Click);
            // 
            // resultados_listbox
            // 
            this.resultados_listbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultados_listbox.FormattingEnabled = true;
            this.resultados_listbox.HorizontalScrollbar = true;
            this.resultados_listbox.ItemHeight = 21;
            this.resultados_listbox.Location = new System.Drawing.Point(25, 147);
            this.resultados_listbox.Name = "resultados_listbox";
            this.resultados_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.resultados_listbox.Size = new System.Drawing.Size(364, 109);
            this.resultados_listbox.TabIndex = 24;
            // 
            // agregar_categoria_button
            // 
            this.agregar_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_categoria_button.Location = new System.Drawing.Point(25, 262);
            this.agregar_categoria_button.Name = "agregar_categoria_button";
            this.agregar_categoria_button.Size = new System.Drawing.Size(206, 37);
            this.agregar_categoria_button.TabIndex = 23;
            this.agregar_categoria_button.Text = "Agregar selección";
            this.agregar_categoria_button.UseVisualStyleBackColor = true;
            this.agregar_categoria_button.Click += new System.EventHandler(this.agregar_categoria_button_Click);
            // 
            // nombre_categoria_tb
            // 
            this.nombre_categoria_tb.Location = new System.Drawing.Point(25, 71);
            this.nombre_categoria_tb.Name = "nombre_categoria_tb";
            this.nombre_categoria_tb.Size = new System.Drawing.Size(281, 33);
            this.nombre_categoria_tb.TabIndex = 22;
            // 
            // nombre_categoria_label
            // 
            this.nombre_categoria_label.AutoSize = true;
            this.nombre_categoria_label.Location = new System.Drawing.Point(20, 43);
            this.nombre_categoria_label.Name = "nombre_categoria_label";
            this.nombre_categoria_label.Size = new System.Drawing.Size(81, 25);
            this.nombre_categoria_label.TabIndex = 21;
            this.nombre_categoria_label.Text = "Nombre";
            // 
            // categorias_seleccionadas_listbox
            // 
            this.categorias_seleccionadas_listbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_seleccionadas_listbox.FormattingEnabled = true;
            this.categorias_seleccionadas_listbox.HorizontalScrollbar = true;
            this.categorias_seleccionadas_listbox.ItemHeight = 21;
            this.categorias_seleccionadas_listbox.Location = new System.Drawing.Point(400, 147);
            this.categorias_seleccionadas_listbox.Name = "categorias_seleccionadas_listbox";
            this.categorias_seleccionadas_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categorias_seleccionadas_listbox.Size = new System.Drawing.Size(364, 109);
            this.categorias_seleccionadas_listbox.TabIndex = 27;
            // 
            // categorias_seleccionadas_label
            // 
            this.categorias_seleccionadas_label.AutoSize = true;
            this.categorias_seleccionadas_label.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_seleccionadas_label.Location = new System.Drawing.Point(395, 119);
            this.categorias_seleccionadas_label.Name = "categorias_seleccionadas_label";
            this.categorias_seleccionadas_label.Size = new System.Drawing.Size(224, 25);
            this.categorias_seleccionadas_label.TabIndex = 28;
            this.categorias_seleccionadas_label.Text = "Categorias seleccionadas";
            // 
            // buscar_button
            // 
            this.buscar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar_button.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_button.Location = new System.Drawing.Point(312, 68);
            this.buscar_button.Name = "buscar_button";
            this.buscar_button.Size = new System.Drawing.Size(77, 37);
            this.buscar_button.TabIndex = 29;
            this.buscar_button.Text = "Buscar";
            this.buscar_button.UseVisualStyleBackColor = true;
            this.buscar_button.Click += new System.EventHandler(this.buscar_button_Click);
            // 
            // listo_button
            // 
            this.listo_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listo_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.listo_button.Location = new System.Drawing.Point(666, 359);
            this.listo_button.MaximumSize = new System.Drawing.Size(800, 600);
            this.listo_button.Name = "listo_button";
            this.listo_button.Size = new System.Drawing.Size(98, 37);
            this.listo_button.TabIndex = 30;
            this.listo_button.Text = "Listo";
            this.listo_button.UseVisualStyleBackColor = true;
            this.listo_button.Click += new System.EventHandler(this.listo_button_Click);
            // 
            // tarea_label
            // 
            this.tarea_label.AutoSize = true;
            this.tarea_label.Location = new System.Drawing.Point(705, 9);
            this.tarea_label.Name = "tarea_label";
            this.tarea_label.Size = new System.Drawing.Size(67, 25);
            this.tarea_label.TabIndex = 31;
            this.tarea_label.Text = "[tarea]";
            this.tarea_label.Visible = false;
            // 
            // BuscarCategoriasForm
            // 
            this.AcceptButton = this.buscar_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 407);
            this.Controls.Add(this.tarea_label);
            this.Controls.Add(this.listo_button);
            this.Controls.Add(this.buscar_button);
            this.Controls.Add(this.categorias_seleccionadas_label);
            this.Controls.Add(this.categorias_seleccionadas_listbox);
            this.Controls.Add(this.resultados_label);
            this.Controls.Add(this.remover_categoria_button);
            this.Controls.Add(this.resultados_listbox);
            this.Controls.Add(this.agregar_categoria_button);
            this.Controls.Add(this.nombre_categoria_tb);
            this.Controls.Add(this.nombre_categoria_label);
            this.Controls.Add(this.header_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "BuscarCategoriasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar categorias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.Label resultados_label;
        private System.Windows.Forms.Button remover_categoria_button;
        private System.Windows.Forms.ListBox resultados_listbox;
        private System.Windows.Forms.Button agregar_categoria_button;
        private System.Windows.Forms.TextBox nombre_categoria_tb;
        private System.Windows.Forms.Label nombre_categoria_label;
        private System.Windows.Forms.ListBox categorias_seleccionadas_listbox;
        private System.Windows.Forms.Label categorias_seleccionadas_label;
        private System.Windows.Forms.Button buscar_button;
        private System.Windows.Forms.Button listo_button;
        private System.Windows.Forms.Label tarea_label;
    }
}