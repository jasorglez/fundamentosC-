using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals.Models
{
    class CervezaBD
    {
        private string connectionString
            = "Data Source=SORIANO;Initial Catalog=fundaments;" +
            "user=sa;Password=qwer1974";

        public List<Beer> Get()
        {
            List<Beer> cervezas = new List<Beer>();
            
            string query = "select Name, marca, Alcohol, quantity, Description "+
                "from cerveza";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
              
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int Cantidad = reader.GetInt32(3);
                    string Name = reader.GetString(0);
                    string Descrip = reader.GetString(4);

                    Beer cerveza = new Beer(1, Name, Descrip, Cantidad);

                    cerveza.Alcohol = reader.GetInt32(2);
                    cerveza.Marca = reader.GetString(1);
                    cervezas.Add(cerveza);
                   
                }
                reader.Close();
                connection.Close();

            }
             return cervezas;
        }


    }
}
