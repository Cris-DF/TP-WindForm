using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Comercio
{
    public class AccesoDatos
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public AccesoDatos()
        {
            connection = new SqlConnection("server = .\\SQLEXPRESS; database = CATALOGO_DB; integrated security = true");
            command = new SqlCommand();
        }
        public void setQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }
    }
}
