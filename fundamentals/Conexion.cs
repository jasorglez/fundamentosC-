using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals
{
    public class Conexion
    {
        private readonly string _connectionString;

        public Conexion(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection CrearConexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
