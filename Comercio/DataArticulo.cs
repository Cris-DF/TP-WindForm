﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Comercio
{
    public class DataArticulo
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {

                acceso.setQuery("Select A.Id id, Codigo, Nombre, A.Descripcion descr, ImagenUrl, Precio, M.Descripcion Marca, C.Descripcion Categoria, IdMarca, IdCategoria From ARTICULOS AS A left JOIN MARCAS M ON M.Id = A.IdMarca left JOIN CATEGORIAS AS C  ON C.Id = A.IdCategoria");
                acceso.executeQuery();

                //lectura con VARIAS validaciones por los NULL en DB_CATALOGO
                while (acceso.Reader.Read())
                {
                    Articulo articulo = new Articulo();

                    articulo.Id = (int)acceso.Reader["id"];
                    articulo.Codigo = acceso.Reader["Codigo"] is DBNull ?
                        "" : (string)acceso.Reader["Codigo"];
                    articulo.Nombre = acceso.Reader["Nombre"] is DBNull ?
                        "-sin nombre-" : (string)acceso.Reader["Nombre"];

                    articulo.Descripcion = acceso.Reader["descr"] is DBNull ?
                        "" : (string)acceso.Reader["descr"];

                    articulo.ImagenUrl = acceso.Reader["ImagenUrl"] is DBNull ?
                        "" : (string)acceso.Reader["ImagenUrl"];

                    if (!(acceso.Reader["Precio"] is DBNull))
                    {
                        float f;
                        float.TryParse(acceso.Reader["Precio"].ToString(), out f);
                        articulo.Precio = f;
                    }



                    articulo.Marca = new Clasificacion();
                    articulo.Categoria = new Clasificacion();

                    articulo.Marca.Descripcion = acceso.Reader["Marca"] is DBNull ?
                        "" : (string)acceso.Reader["Marca"];

                    articulo.Categoria.Descripcion = acceso.Reader["Categoria"] is DBNull ?
                        "" : (string)acceso.Reader["Categoria"];

                    //es necesario tener el id del articulo para recuperar el dato cuando lo editemos
                    if (!(acceso.Reader["IdMarca"] is DBNull))
                        articulo.Marca.ID = (int)acceso.Reader["IdMarca"];
                    if (!(acceso.Reader["IdCategoria"] is DBNull))
                        articulo.Categoria.ID = (int)acceso.Reader["IdCategoria"];

                    lista.Add(articulo);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //IMPORTANTE, cerrar la conexion
                acceso.closeConnection();
            }



        }


        public void agregar(Articulo nuevoArt)
        {
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.setQuery("Insert into ARTICULOS(Codigo, Nombre, Descripcion, idMarca, IdCategoria, ImagenUrl, Precio) values(@codigo, @nombre, @desc, @idMarca, @idCategoria, @Url, @precio)");
                setearParametros(acceso,nuevoArt);
                acceso.ejecutar();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.closeConnection();
            }


        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.setQuery("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @desc, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @Url, Precio = @precio Where Id =" + articulo.Id);
                setearParametros(acceso, articulo);
                acceso.ejecutar();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.closeConnection();
            }

            
        }


        private void setearParametros(AccesoDatos accesoDatos,Articulo art)
        {
            accesoDatos.setParametro("@codigo",art.Codigo);
            accesoDatos.setParametro("@nombre",art.Nombre);
            accesoDatos.setParametro("@desc",art.Descripcion);
            accesoDatos.setParametro("@idMarca",art.Marca.ID);
            accesoDatos.setParametro("@idCategoria",art.Categoria.ID);
            accesoDatos.setParametro("@Url",art.ImagenUrl);
            accesoDatos.setParametro("@precio",art.Precio);

        }

        public void eliminar(int id)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            { 
                acceso.setQuery("delete from ARTICULOS where id = " + id);
                acceso.ejecutar();  
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.closeConnection();
            }

        }

    }
}
