namespace SivUI
{
    partial class CrearFiltroForm
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
            this.habilitar_fechas_checkbox = new System.Windows.Forms.CheckBox();
            this.fechas_groupbox = new System.Windows.Forms.GroupBox();
            this.fecha_inicial_label = new System.Windows.Forms.Label();
            this.fecha_final_label = new System.Windows.Forms.Label();
            this.fecha_final_dtp = new System.Windows.Forms.DateTimePicker();
            this.fecha_inicial_dtp = new System.Windows.Forms.DateTimePicker();
            this.categorias_listbox = new System.Windows.Forms.ListBox();
            this.categorias_filtro_label = new System.Windows.Forms.Label();
            this.remover_categoria_button = new System.Windows.Forms.Button();
            this.agregar_categorias_button = new System.Windows.Forms.Button();
            this.listo_button = new System.Windows.Forms.Button();
            this.fechas_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(311, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(163, 30);
            this.header_label.TabIndex = 3;
            this.header_label.Text = "Ajuste de filtros";
            // 
            // habilitar_fechas_checkbox
            // 
            this.habilitar_fechas_checkbox.AutoSize = true;
            this.habilitar_fechas_checkbox.Location = new System.Drawing.Point(12, 196);
            this.habilitar_fechas_checkbox.Name = "habilitar_fechas_checkbox";
            this.habilitar_fechas_checkbox.Size = new System.Drawing.Size(173, 29);
            this.habilitar_fechas_checkbox.TabIndex = 8;
            this.habilitar_fechas_checkbox.Text = "Filtrar por fechas";
            this.habilitar_fechas_checkbox.UseVisualStyleBackColor = true;
            this.habilitar_fechas_checkbox.CheckedChanged += new System.EventHandler(this.habilitar_fechas_checkbox_CheckedChanged);
            // 
            // fechas_groupbox
            // 
            this.fechas_groupbox.Controls.Add(this.fecha_inicial_label);
            this.fechas_groupbox.Controls.Add(this.fecha_final_label);
            this.fechas_groupbox.Controls.Add(this.fecha_final_dtp);
            this.fechas_groupbox.Controls.Add(this.fecha_inicial_dtp);
            this.fechas_groupbox.Enabled = false;
            this.fechas_groupbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechas_groupbox.Location = new System.Drawing.Point(12, 83);
            this.fechas_groupbox.Name = "fechas_groupbox";
            this.fechas_groupbox.Size = new System.Drawing.Size(269, 107);
            this.fechas_groupbox.TabIndex = 7;
            this.fechas_groupbox.TabStop = false;
            this.fechas_groupbox.Text = "Fechas";
            // 
            // fecha_inicial_label
            // 
            this.fecha_inicial_label.AutoSize = true;
            this.fecha_inicial_label.Location = new System.Drawing.Point(12, 25);
            this.fecha_inicial_label.Name = "fecha_inicial_label";
            this.fecha_inicial_label.Size = new System.Drawing.Size(94, 21);
            this.fecha_inicial_label.TabIndex = 3;
            this.fecha_inicial_label.Text = "Fecha inicial";
            // 
            // fecha_final_label
            // 
            this.fecha_final_label.AutoSize = true;
            this.fecha_final_label.Location = new System.Drawing.Point(135, 25);
            this.fecha_final_label.Name = "fecha_final_label";
            this.fecha_final_label.Size = new System.Drawing.Size(84, 21);
            this.fecha_final_label.TabIndex = 4;
            this.fecha_final_label.Text = "Fecha final";
            // 
            // fecha_final_dtp
            // 
            this.fecha_final_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_final_dtp.Location = new System.Drawing.Point(138, 53);
            this.fecha_final_dtp.Name = "fecha_final_dtp";
            this.fecha_final_dtp.Size = new System.Drawing.Size(119, 29);
            this.fecha_final_dtp.TabIndex = 1;
            // 
            // fecha_inicial_dtp
            // 
            this.fecha_inicial_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_inicial_dtp.Location = new System.Drawing.Point(17, 53);
            this.fecha_inicial_dtp.Name = "fecha_inicial_dtp";
            this.fecha_inicial_dtp.Size = new System.Drawing.Size(116, 29);
            this.fecha_inicial_dtp.TabIndex = 0;
            // 
            // categorias_listbox
            // 
            this.categorias_listbox.FormattingEnabled = true;
            this.categorias_listbox.HorizontalScrollbar = true;
            this.categorias_listbox.ItemHeight = 25;
            this.categorias_listbox.Location = new System.Drawing.Point(408, 83);
            this.categorias_listbox.Name = "categorias_listbox";
            this.categorias_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categorias_listbox.Size = new System.Drawing.Size(364, 179);
            this.categorias_listbox.TabIndex = 17;
            // 
            // categorias_filtro_label
            // 
            this.categorias_filtro_label.AutoSize = true;
            this.categorias_filtro_label.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_filtro_label.Location = new System.Drawing.Point(408, 55);
            this.categorias_filtro_label.Name = "categorias_filtro_label";
            this.categorias_filtro_label.Size = new System.Drawing.Size(215, 25);
            this.categorias_filtro_label.TabIndex = 21;
            this.categorias_filtro_label.Text = "Filtrar por las categorias";
            // 
            // remover_categoria_button
            // 
            this.remover_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_categoria_button.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.remover_categoria_button.Location = new System.Drawing.Point(584, 268);
            this.remover_categoria_button.MaximumSize = new System.Drawing.Size(800, 600);
            this.remover_categoria_button.Name = "remover_categoria_button";
            this.remover_categoria_button.Size = new System.Drawing.Size(188, 37);
            this.remover_categoria_button.TabIndex = 23;
            this.remover_categoria_button.Text = "Remover selección";
            this.remover_categoria_button.UseVisualStyleBackColor = true;
            this.remover_categoria_button.Click += new System.EventHandler(this.remover_categoria_button_Click);
            // 
            // agregar_categorias_button
            // 
            this.agregar_categorias_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregar_categorias_button.Location = new System.Drawing.Point(408, 268);
            this.agregar_categorias_button.Name = "agregar_categorias_button";
            this.agregar_categorias_button.Size = new System.Drawing.Size(109, 37);
            this.agregar_categorias_button.TabIndex = 22;
            this.agregar_categorias_button.Text = "Agregar";
            this.agregar_categorias_button.UseVisualStyleBackColor = true;
            this.agregar_categorias_button.Click += new System.EventHandler(this.agregar_categorias_button_Click);
            // 
            // listo_button
            // 
            this.listo_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listo_button.Location = new System.Drawing.Point(663, 452);
            this.listo_button.Name = "listo_button";
            this.listo_button.Size = new System.Drawing.Size(109, 37);
            this.listo_button.TabIndex = 24;
            this.listo_button.Text = "Listo";
            this.listo_button.UseVisualStyleBackColor = true;
            this.listo_button.Click += new System.EventHandler(this.listo_button_Click);
            // 
            // CrearFiltroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 501);
            this.Controls.Add(this.listo_button);
            this.Controls.Add(this.remover_categoria_button);
            this.Controls.Add(this.agregar_categorias_button);
            this.Controls.Add(this.categorias_filtro_label);
            this.Controls.Add(this.categorias_listbox);
            this.Controls.Add(this.habilitar_fechas_checkbox);
            this.Controls.Add(this.fechas_groupbox);
            this.Controls.Add(this.header_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "CrearFiltroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtros";
            this.fechas_groupbox.ResumeLayout(false);
            this.fechas_groupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.CheckBox habilitar_fechas_checkbox;
        private System.Windows.Forms.GroupBox fechas_groupbox;
        private System.Windows.Forms.Label fecha_inicial_label;
        private System.Windows.Forms.Label fecha_final_label;
        private System.Windows.Forms.DateTimePicker fecha_final_dtp;
        private System.Windows.Forms.DateTimePicker fecha_inicial_dtp;
        private System.Windows.Forms.ListBox categorias_listbox;
        private System.Windows.Forms.Label categorias_filtro_label;
        private System.Windows.Forms.Button remover_categoria_button;
        private System.Windows.Forms.Button agregar_categorias_button;
        private System.Windows.Forms.Button listo_button;
    }
}