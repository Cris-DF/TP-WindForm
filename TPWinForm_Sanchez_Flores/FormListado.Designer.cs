
namespace TPWinForm_Sanchez_Flores
{
    partial class VentanaListaArticulos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListBoxArticulos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ListBoxArticulos
            // 
            this.ListBoxArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBoxArticulos.FormattingEnabled = true;
            this.ListBoxArticulos.Location = new System.Drawing.Point(12, 12);
            this.ListBoxArticulos.Name = "ListBoxArticulos";
            this.ListBoxArticulos.Size = new System.Drawing.Size(357, 420);
            this.ListBoxArticulos.TabIndex = 0;
            // 
            // VentanaListaArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 450);
            this.Controls.Add(this.ListBoxArticulos);
            this.Name = "VentanaListaArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Articulos";
            this.Load += new System.EventHandler(this.VentanaListaArticulos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxArticulos;
    }
}

