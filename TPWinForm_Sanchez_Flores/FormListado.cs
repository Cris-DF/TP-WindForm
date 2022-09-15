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
            dgvListadoArticulos.Columns["Codigo"].Visible = false;
            dgvListadoArticulos.Columns["Id"].Visible = false;
            dgvListadoArticulos.Columns["Descripcion"].Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            Articulo seleccion = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

            FormEditarArticulo frmVer = new FormEditarArticulo(seleccion);
            frmVer.ShowDialog();
            

        }


        private void dgvListadoArticulos_SelectionChanged(object sender, EventArgs e)
        {if(dgvListadoArticulos.CurrentRow!=null)
            {

                Articulo seleccion = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

                txtDescripcion.Text = seleccion.Descripcion;
                txtId.Text = seleccion.Id.ToString();
            }

        }
    }
}
