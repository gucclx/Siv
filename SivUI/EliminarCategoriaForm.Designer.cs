namespace SivUI
{
    partial class EliminarCategoriaForm
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
            this.eliminar_categoria_button = new System.Windows.Forms.Button();
            this.categorias_existentes_listbox = new System.Windows.Forms.ListBox();
            this.categorias_existentes_label = new System.Windows.Forms.Label();
            this.cerrar_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eliminar_categoria_button
            // 
            this.eliminar_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminar_categoria_button.ForeColor = System.Drawing.Color.Crimson;
            this.eliminar_categoria_button.Location = new System.Drawing.Point(12, 327);
            this.eliminar_categoria_button.Name = "eliminar_categoria_button";
            this.eliminar_categoria_button.Size = new System.Drawing.Size(225, 37);
            this.eliminar_categoria_button.TabIndex = 18;
            this.eliminar_categoria_button.Text = "Eliminar selección";
            this.eliminar_categoria_button.UseVisualStyleBackColor = true;
            this.eliminar_categoria_button.Click += new System.EventHandler(this.eliminar_categoria_button_Click);
            // 
            // categorias_existentes_listbox
            // 
            this.categorias_existentes_listbox.FormattingEnabled = true;
            this.categorias_existentes_listbox.HorizontalScrollbar = true;
            this.categorias_existentes_listbox.ItemHeight = 25;
            this.categorias_existentes_listbox.Location = new System.Drawing.Point(12, 60);
            this.categorias_existentes_listbox.Name = "categorias_existentes_listbox";
            this.categorias_existentes_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categorias_existentes_listbox.Size = new System.Drawing.Size(500, 254);
            this.categorias_existentes_listbox.TabIndex = 17;
            // 
            // categorias_existentes_label
            // 
            this.categorias_existentes_label.AutoSize = true;
            this.categorias_existentes_label.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_existentes_label.Location = new System.Drawing.Point(158, 9);
            this.categorias_existentes_label.Name = "categorias_existentes_label";
            this.categorias_existentes_label.Size = new System.Drawing.Size(209, 30);
            this.categorias_existentes_label.TabIndex = 16;
            this.categorias_existentes_label.Text = "Categorias existentes";
            // 
            // cerrar_button
            // 
            this.cerrar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cerrar_button.Location = new System.Drawing.Point(379, 327);
            this.cerrar_button.Name = "cerrar_button";
            this.cerrar_button.Size = new System.Drawing.Size(133, 37);
            this.cerrar_button.TabIndex = 19;
            this.cerrar_button.Text = "Cerrar";
            this.cerrar_button.UseVisualStyleBackColor = true;
            this.cerrar_button.Click += new System.EventHandler(this.cerrar_button_Click);
            // 
            // EliminarCategoriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(524, 376);
            this.Controls.Add(this.cerrar_button);
            this.Controls.Add(this.eliminar_categoria_button);
            this.Controls.Add(this.categorias_existentes_listbox);
            this.Controls.Add(this.categorias_existentes_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EliminarCategoriaForm";
            this.Text = "EliminarCategoriaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button eliminar_categoria_button;
        private System.Windows.Forms.ListBox categorias_existentes_listbox;
        private System.Windows.Forms.Label categorias_existentes_label;
        private System.Windows.Forms.Button cerrar_button;
    }
}