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
using Comercio;

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

            txtPrecio.Text = articulo.Precio.ToString();


            //carga basica de imagen
            try
            {
                DataClasificacion dataClasificacion = new DataClasificacion();
                cboCategorias.DataSource = dataClasificacion.listar("CATEGORIAS");
                cboMarca.DataSource = dataClasificacion.listar("MARCAS");
                
                //PENDIENTE: que los desplegables inicien con el dato correspondiente

                BoxImg.Load(articulo.ImagenUrl);

            }
            catch
            {
                BoxImg.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
