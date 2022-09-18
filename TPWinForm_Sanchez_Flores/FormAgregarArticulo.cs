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
    public partial class FormAgregarArticulo : Form
    {
        public FormAgregarArticulo()
        {
            InitializeComponent();
        }

        private void FormAgregarArticulo_Load(object sender, EventArgs e)
        {
            DataClasificacion dataClasificacion = new DataClasificacion();
            cboCategorias.DataSource = dataClasificacion.listar("CATEGORIAS");
            cboMarca.DataSource = dataClasificacion.listar("MARCAS");
        }
    }
}
