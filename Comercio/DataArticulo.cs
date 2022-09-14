using System;
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

                while (acceso.Reader.Read())
                {
                    Articulo articulo = new Articulo();
                  
                    articulo.Id = (int)acceso.Reader["id"];
                    
                    articulo.Codigo = acceso.Reader["Codigo"] is DBNull ? 
                        "":(string)acceso.Reader["Codigo"];
                    articulo.Nombre = acceso.Reader["Nombre"] is DBNull? 
                        "-sin nombre-":(string)acceso.Reader["Nombre"];
                    
                    articulo.Descripcion = acceso.Reader["descr"] is DBNull?
                        "":(string)acceso.Reader["descr"];
                    
                    articulo.ImagenUrl = acceso.Reader["ImagenUrl"] is DBNull?
                        "":(string)acceso.Reader["ImagenUrl"];

                    if( !(acceso.Reader["Precio"] is DBNull))
                    {
                        float f;
                        float.TryParse(acceso.Reader["Precio"].ToString(), out f);
                        articulo.Precio = f;
                    }
                         
                               

                    articulo.Marca = new Clasificacion();
                    articulo.Categoria = new Clasificacion();
                    
                    articulo.Marca.Descripcion =acceso.Reader["Marca"] is DBNull? 
                        "" : (string)acceso.Reader["Marca"];
                    
                    articulo.Categoria.Descripcion = acceso.Reader["Categoria"] is DBNull?
                        "" :(string)acceso.Reader["Categoria"];

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
                acceso.closeConnection();
            }



        }

    }
}
