// See https://aka.ms/new-console-template for more information
using fundamentals.Models;
using System.Data.SqlClient;





namespace CRUD_SQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString
              = "Data Source=SORIANO;Initial Catalog=fundaments;" +
                  "user=sa;Password=qwer1974";

            while (true)
            {
                Console.WriteLine("Menú de opciones:");
                Console.WriteLine("1. Create record");
                Console.WriteLine("2. Read record with List and Class");
                Console.WriteLine("3. Read record BD SQL Server");
                Console.WriteLine("4. Actualizar registro");
                Console.WriteLine("5. Eliminar registro");
                Console.WriteLine("6. Consulta con LINQ");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            CrearRegistroBD(connectionString);
                            break;
                        case 2:
                            ReadWithClass(connectionString);
                            break;
                        case 3:
                            LeerRegistrosBD(connectionString);
                            break;
                        case 4:
                            ActualizarRegistro(connectionString);
                            break;
                        case 5:
                            EliminarRegistro(connectionString);
                            break;
                        case 6:
                            ConsultaConLINQ(connectionString);
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
            }
        }


        static void CrearRegistroBD(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.Write("Enter name Beer: ");
                string ?nombre = Console.ReadLine();

                Console.Write("Enter Description: ");
                string ?description = Console.ReadLine();

                Console.Write("Enter Brand: ");
                string ?marca = Console.ReadLine();

                Console.Write("Alcohol: ");
                string ?alc = Console.ReadLine();

                Console.Write("Quantity: ");
                string ?quant = Console.ReadLine();


                string query = "INSERT INTO cerveza (name, description, marca, alcohol, quantity) VALUES (@Nombre, @Desc, @Brand, @Alc, @Quant )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Desc", description);
                    command.Parameters.AddWithValue("@Brand", marca);
                    command.Parameters.AddWithValue("@Alc", alc);
                    command.Parameters.AddWithValue("@Quant", quant);

                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} registro(s) insertado(s) correctamente.");
                }
            }
        }

        static void CreateRecordWithClass(string connectionString)
        {
            CervezaBD cervezaBD = new CervezaBD();
            // insert new beer

            Beer cerveza = new Beer("Oscura", "Descripcion", 5);
            cerveza.Marca = "Minerva";
            cerveza.Alcohol = 60;
            cervezaBD.Add(cerveza, connectionString);

        }

        static void ReadWithClass(string connectionString)
        {
            CervezaBD cervezaBD = new CervezaBD();

            var cervezas = cervezaBD.Get(connectionString);

            foreach (var item in cervezas)
            {
                //Console.WriteLine(item.Name);
                Console.WriteLine($"Id: {item.Id}, Nombre: {item.Name}, Description: {item.Description}");
            }

        }

        static void LeerRegistrosBD(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Id, Name, Description FROM cerveza";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Nombre: {reader["Name"]}, Description: {reader["description"]}");
                    }
                }
            }
        }

        static void ActualizarRegistro(string connectionString)
        {
            CervezaBD cervezaBD = new CervezaBD();

            Beer beer = new Beer("Coronita", "Descr", 66);
            beer.Marca = "Minerbva";
            beer.Alcohol = 90;
            cervezaBD.Update(beer, connectionString, 14);
        }

            static void ActualizarRegistro2(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.Write("Ingrese el ID del registro a actualizar: ");
                string ?input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada inválida. El ID no puede estar vacío.");
                    return; // O manejar de alguna otra manera
                }
                if (int.TryParse(input, out int id))
                {

                }

                Console.Write("Ingrese el nuevo nombre: ");
                string ?nuevoNombre = Console.ReadLine();

                Console.Write("Ingrese el nuevo correo electrónico: ");
                string ?nuevoCorreo = Console.ReadLine();

                string query = "UPDATE Usuarios SET Nombre = @NuevoNombre, Correo = @NuevoCorreo WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@NuevoNombre", nuevoNombre);
                    command.Parameters.AddWithValue("@NuevoCorreo", nuevoCorreo);
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} registro(s) actualizado(s) correctamente.");
                }
            }
        }
    

        static void EliminarRegistro(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.Write("Ingrese el ID del registro a eliminar: ");
                string ?input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada inválida. El ID no puede estar vacío.");
                    return; // O manejar de alguna otra manera
                }

                if (int.TryParse(input, out int id))
                {
                    // Ahora puedes usar la variable "id" de manera segura.
                    // Realiza la operación de eliminación con el ID.
                }
                else
                {
                    Console.WriteLine("Entrada inválida. El ID debe ser un número entero.");
                    return; // O manejar de alguna otra manera
                }

                string query = "DELETE FROM Usuarios WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} registro(s) eliminado(s) correctamente.");
                }
            }
        }

        static void ConsultaConLINQ(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

            }
        }



    }
}