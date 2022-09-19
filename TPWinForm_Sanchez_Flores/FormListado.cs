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
            DataClasificacion dataClas = new DataClasificacion();
            cargar();

            cboFiltroCategoria.DataSource = dataClas.listar("CATEGORIAS");
            cboFiltroCategoria.DisplayMember = "Descripcion";
            cboFiltroCategoria.ValueMember = "ID";
            cboFiltroCategoria.SelectedIndex = -1;

            cboFiltroMarca.DataSource = dataClas.listar("MARCAS");
            cboFiltroMarca.DisplayMember = "Descripcion";
            cboFiltroMarca.ValueMember = "ID";
            cboFiltroMarca.SelectedIndex = -1;
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
            //El codigo ya estaba en la parte derecha como detalle
            dgvListadoArticulos.Columns["Codigo"].Visible = false;
            dgvListadoArticulos.Columns["Id"].Visible = false;
            dgvListadoArticulos.Columns["Descripcion"].Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            Articulo seleccion = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

            FormEditarArticulo frmVer = new FormEditarArticulo(seleccion);
            frmVer.ShowDialog();
            cargar();
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

     

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            FormEditarArticulo frmVer = new FormEditarArticulo();
            frmVer.ShowDialog();
            cargar();

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaResultado = new List<Articulo>();
            string busqueda = txtBusqueda.Text;

            if(busqueda.Length > 2)
            {
                listaResultado= listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(busqueda.ToUpper()) || x.Descripcion.ToUpper().Contains(busqueda.ToUpper()));
            }
            else
            {
                listaResultado = listaArticulos;
            }

            dgvListadoArticulos.DataSource = null;
            dgvListadoArticulos.DataSource = listaResultado;
            ocultarColumns();


        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            cargar();

            if(cboFiltroCategoria.SelectedIndex >= 0)
            {
                int cat = (int)cboFiltroCategoria.SelectedValue;
                listaArticulos = listaArticulos.FindAll(x => x.Categoria.ID == cat);
            }
            if (cboFiltroMarca.SelectedIndex >= 0)
            {
                int marca = (int)cboFiltroMarca.SelectedValue;
                listaArticulos = listaArticulos.FindAll(x => x.Marca.ID == marca);
            }
            dgvListadoArticulos.DataSource = null;
            dgvListadoArticulos.DataSource = listaArticulos ;
            ocultarColumns();

            //reiniciar los cbo
            cboFiltroCategoria.SelectedIndex = -1;
            cboFiltroMarca.SelectedIndex = -1;
        }
    }
}
