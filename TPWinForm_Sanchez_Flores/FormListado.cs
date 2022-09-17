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
    public partial class VentanaListaArticulos : Form
    {
        private List<Articulo> listaArticulos;
        public VentanaListaArticulos()
        {
            InitializeComponent();
        }

        private void VentanaListaArticulos_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            DataArticulo datos = new DataArticulo();

            //le asignamos una lista de articulos al dataGridView
            try
            {
                listaArticulos = datos.listar();
                dgvListadoArticulos.DataSource = listaArticulos;
                ocultarColumns();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumns()
        {
            dgvListadoArticulos.Columns["ImagenUrl"].Visible = false;
            //Creo que el código debería estar
            //dgvListadoArticulos.Columns["Codigo"].Visible = false;
            dgvListadoArticulos.Columns["Id"].Visible = false;
            dgvListadoArticulos.Columns["Descripcion"].Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            Articulo seleccion = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

            FormEditarArticulo frmVer = new FormEditarArticulo(seleccion);
            frmVer.ShowDialog();
            //despues de editar el articulo la ventana actual tiene que actualizar las listas
        }


        //evento cuando cambia la seleccion. Aplica tambien para la columna inicial
        private void dgvListadoArticulos_SelectionChanged(object sender, EventArgs e)
        {if (dgvListadoArticulos.CurrentRow != null)
            {


                Articulo seleccion = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

                //Debajo de la imagen se muestran detalles del articulo seleccionado
                txtDescripcion.Text = seleccion.Descripcion;
                txtId.Text = seleccion.Id.ToString();
                txtCodigo.Text = seleccion.Codigo;
                //esta es una carga basica de imagenes
                try
                {
                    pictureArticulo.Load(seleccion.ImagenUrl);
                }
                catch
                {
                    pictureArticulo.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Articulo seleccion;
            DataArticulo dataArticulo = new DataArticulo();
            try
            {
                DialogResult respuesta = MessageBox.Show("\t Segur@? \n Se eliminara definitivamente", "Eliminar Articulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.OK)
                {
                    seleccion = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;
                    dataArticulo.eliminar(seleccion.Id);
                    cargar();
                }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


    }
}
