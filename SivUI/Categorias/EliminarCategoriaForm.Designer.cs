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
            this.categorias_listbox = new System.Windows.Forms.ListBox();
            this.categorias_existentes_label = new System.Windows.Forms.Label();
            this.remover_button = new System.Windows.Forms.Button();
            this.buscar_categoria_linklabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // eliminar_categoria_button
            // 
            this.eliminar_categoria_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminar_categoria_button.ForeColor = System.Drawing.Color.Crimson;
            this.eliminar_categoria_button.Location = new System.Drawing.Point(12, 327);
            this.eliminar_categoria_button.Name = "eliminar_categoria_button";
            this.eliminar_categoria_button.Size = new System.Drawing.Size(192, 37);
            this.eliminar_categoria_button.TabIndex = 18;
            this.eliminar_categoria_button.Text = "Eliminar categorias";
            this.eliminar_categoria_button.UseVisualStyleBackColor = true;
            this.eliminar_categoria_button.Click += new System.EventHandler(this.eliminar_categoria_button_Click);
            // 
            // categorias_listbox
            // 
            this.categorias_listbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorias_listbox.FormattingEnabled = true;
            this.categorias_listbox.HorizontalScrollbar = true;
            this.categorias_listbox.ItemHeight = 21;
            this.categorias_listbox.Location = new System.Drawing.Point(12, 83);
            this.categorias_listbox.Name = "categorias_listbox";
            this.categorias_listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categorias_listbox.Size = new System.Drawing.Size(500, 193);
            this.categorias_listbox.TabIndex = 17;
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
            // remover_button
            // 
            this.remover_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remover_button.Location = new System.Drawing.Point(320, 327);
            this.remover_button.Name = "remover_button";
            this.remover_button.Size = new System.Drawing.Size(192, 37);
            this.remover_button.TabIndex = 19;
            this.remover_button.Text = "Remover selección";
            this.remover_button.UseVisualStyleBackColor = true;
            this.remover_button.Click += new System.EventHandler(this.remover_button_Click);
            // 
            // buscar_categoria_linklabel
            // 
            this.buscar_categoria_linklabel.AutoSize = true;
            this.buscar_categoria_linklabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_categoria_linklabel.Location = new System.Drawing.Point(8, 59);
            this.buscar_categoria_linklabel.Name = "buscar_categoria_linklabel";
            this.buscar_categoria_linklabel.Size = new System.Drawing.Size(56, 21);
            this.buscar_categoria_linklabel.TabIndex = 20;
            this.buscar_categoria_linklabel.TabStop = true;
            this.buscar_categoria_linklabel.Text = "Buscar";
            this.buscar_categoria_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buscar_categoria_linklabel_LinkClicked);
            // 
            // EliminarCategoriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(524, 376);
            this.Controls.Add(this.buscar_categoria_linklabel);
            this.Controls.Add(this.remover_button);
            this.Controls.Add(this.eliminar_categoria_button);
            this.Controls.Add(this.categorias_listbox);
            this.Controls.Add(this.categorias_existentes_label);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "EliminarCategoriaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EliminarCategoriaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button eliminar_categoria_button;
        private System.Windows.Forms.ListBox categorias_listbox;
        private System.Windows.Forms.Label categorias_existentes_label;
        private System.Windows.Forms.Button remover_button;
        private System.Windows.Forms.LinkLabel buscar_categoria_linklabel;
    }
}