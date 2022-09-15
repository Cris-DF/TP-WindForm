using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;

namespace TPWinForm_Sanchez_Flores
{
    public partial class FormEditarArticulo : Form
    {
        Articulo articulo;
        public FormEditarArticulo(Articulo art)
        {
            InitializeComponent();
            articulo = art;

        }

        private void FormVerArticulo_Load(object sender, EventArgs e)
        {

            txtId.Text = articulo.Id.ToString();
            txtCodigo.Text = articulo.Codigo;
            txtNombre.Text = articulo.Nombre;
            txtDescripcion.Text = articulo.Descripcion;
            txtMarca.Text = articulo.Marca.Descripcion;
            txtCategoria.Text = articulo.Categoria.Descripcion;
            txtPrecio.Text = articulo.Precio.ToString();

        }
    }
}
