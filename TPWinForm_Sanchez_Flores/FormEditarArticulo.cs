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
        private Articulo articulo=null;

        public FormEditarArticulo(Articulo art)
        {
            InitializeComponent();
            articulo = art;

        }

        public FormEditarArticulo()
        {
            InitializeComponent();

            //ocultamos el Id porque corresponde a la DB y no al usuario
            txtId.Visible = false;
            lblId.Visible = false;
            cargarImagen("");
            Text = "Nuevo Articulo";
        }

        private void FormVerArticulo_Load(object sender, EventArgs e)
        {
            
            try
            {
                DataClasificacion dataClasificacion = new DataClasificacion();
                cboCategorias.DataSource = dataClasificacion.listar("CATEGORIAS");
                cboCategorias.DisplayMember = "Descripcion";
                cboCategorias.ValueMember = "ID";
                cboMarca.DataSource = dataClasificacion.listar("MARCAS");
                cboMarca.DisplayMember = "Descripcion";
                cboMarca.ValueMember = "ID";


                //si articulo no es nulo: hay datos existentes, se cargan esos datos en el form
                if (articulo != null)
                {
                    txtId.Text = articulo.Id.ToString();
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    numPrecio.Value = (decimal)articulo.Precio;
                    cboCategorias.SelectedValue = articulo.Categoria.ID;
                    cboMarca.SelectedValue = articulo.Marca.ID;
                    txtImagenUrl.Text = articulo.ImagenUrl;
                    cargarImagen(articulo.ImagenUrl);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void cargarImagen(string imagen)
        {
            try
            {
                BoxImg.Load(imagen);
            }
            catch 
            {
                BoxImg.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DataArticulo dataArticulo = new DataArticulo();
            try
            {
                // luego de aqui el articulo no puede ser null 
                if (articulo == null)
                {
                    articulo = new Articulo();
                }
                
                if (validarIngresos())
                {
                    return;
                } 
                
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Precio = (float)numPrecio.Value; //   convertir
                articulo.Descripcion = txtDescripcion.Text;
                articulo.ImagenUrl = txtImagenUrl.Text;
                articulo.Categoria = (Clasificacion)cboCategorias.SelectedItem;
                articulo.Marca = (Clasificacion)cboMarca.SelectedItem;
         

                if(articulo.Id == 0)
                {
                    dataArticulo.agregar(articulo);
                    MessageBox.Show(articulo.Marca+ " " +articulo.Nombre + " Agregado" );
                }
                else
                {
                    dataArticulo.modificar(articulo);
                    MessageBox.Show(articulo.Marca + " " + articulo.Nombre + " Modificado");
                }

                Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// devuelve True si los valores ingresados son incorrectos
        /// </summary>
        /// <returns></returns>
        private bool validarIngresos()
        {
            bool error = false;
            string mensaje = "Error de longitud del campo de texto";

            if (txtCodigo.Text.Length > 50) {
                error = true;
                mensaje += ", Codigo(max 50)";
            }
            else if (txtCodigo.Text.Length <1)
            {
                
                error = true;
                mensaje += ", Codigo no puede estar vacio";
            }
            if (txtNombre.Text.Length > 50)
            {
                error = true;
                mensaje += ", Nombre(max 50)";
            }
            else if (txtNombre.Text.Length < 1)
            {

                error = true;
                mensaje += ", Nombre no puede estar vacio";
            }


            if (txtDescripcion.Text.Length > 150)
            {
                error = true;
                mensaje += ", Descripcion(max 150)";
            }
            if (txtImagenUrl.Text.Length > 1000)
            {
                error = true;
                mensaje += ", Url(max 1000)";
            }
            if (error)
            {
                MessageBox.Show(mensaje);
            }
            

            return error;
        }


        private void txtImagenUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagenUrl.Text);
        }
    }
}
