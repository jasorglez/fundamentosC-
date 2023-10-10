
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace fundamentals.Models
{
    class CervezaBD
    {


        public List<Beer> Get(string connectionString)
        {
            List<Beer> cervezas = new List<Beer>();
            
            string query = "select Id, Name, marca, Alcohol, quantity, Description "+
                "from cerveza";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
              
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    int Cantidad = reader.GetInt32(4);
                    string Name = reader.GetString(1);
                    string Descrip = reader.GetString(5);

                    Beer cerveza = new Beer( Name, Descrip, Cantidad);

                    cerveza.Alcohol = reader.GetInt32(3);
                    cerveza.Marca = reader.GetString(2);
                    cervezas.Add(cerveza);
                   
                }
                reader.Close();
                connection.Close();

            }
             return cervezas;
        }

        public void Add(Beer beer, string connectionString)
        {
            string query = "INSERT INTO cerveza (name, description, marca, alcohol, quantity) " +
                            "VALUES (@Nombre, @Desc, @Brand, @Alc, @Quant )";
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", beer.Name);
                command.Parameters.AddWithValue("@Desc", beer.Description);
                command.Parameters.AddWithValue("@Brand", beer.Marca);
                command.Parameters.AddWithValue("@Alc", beer.Alcohol);
                command.Parameters.AddWithValue("@Quant", beer.quantity);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} registro(s) insertado(s) correctamente.");
                connection.Close();

            }

        }

        public void Update(Beer beer, string connectionString, int Id)
        {
            string query = "update cerveza set name=@nombre," +
                           "marca=@marca, alcohol=@alcohol, quantity=@cantidad " +
                           "where id=@id";
                 
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", beer.Name);
                command.Parameters.AddWithValue("@marca", beer.Marca);
                command.Parameters.AddWithValue("@alcohol", beer.Alcohol);
                command.Parameters.AddWithValue("@cantidad", beer.quantity);
                command.Parameters.AddWithValue("@id", Id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} registro(s) Actualizado(s) correctamente.");
                connection.Close();

            }

        }
    }
}
