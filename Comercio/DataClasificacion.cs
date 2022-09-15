using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace Comercio
{
    public class DataClasificacion
    {
        

        public List<Clasificacion> listar(string nombretab)
        {
            
            List<Clasificacion> lista = new List<Clasificacion>();
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.setQuery("SELECT ID,DESCRIPCION FROM "+nombretab);
                acceso.executeQuery();

                
                while (acceso.Reader.Read())
                {
                    Clasificacion aux = new Clasificacion();
                    aux.ID = (int)acceso.Reader["ID"];
                    aux.Descripcion = acceso.Reader["DESCRIPCION"] is DBNull ? "-Sin descripcion" : (string)acceso.Reader["DESCRIPCION"];

                    lista.Add(aux);
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





    }
}
