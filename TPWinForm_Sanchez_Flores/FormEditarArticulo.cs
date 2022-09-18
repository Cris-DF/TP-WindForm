﻿using System;
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
        private Articulo articulo;
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
            numericPrecio.Value = articulo.Precio;
            //carga basica de imagen
            try
            {
                DataClasificacion dataClasificacion = new DataClasificacion();
                
                cboMarca.DataSource = dataClasificacion.listar("MARCAS");
                cboMarca.Text = articulo.Marca.Descripcion;
                cboCategorias.DataSource = dataClasificacion.listar("CATEGORIAS");
                cboCategorias.Text = articulo.Categoria.Descripcion;
                //TODO: que los desplegables inicien con el dato correspondiente

                BoxImg.Load(articulo.ImagenUrl);

            }
            catch
            {
                BoxImg.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
            }

        }
    }
}
