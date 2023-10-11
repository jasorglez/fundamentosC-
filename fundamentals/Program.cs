using fundamentals.Models;
using System.Text.Json ;
using System.Text.Json.Serialization;
using System.IO;

namespace fundamentals
{
    class Program
    {
        static async Task Main(string[]args)
        {
            {
                List<int> namelist = new List<int>() { 1, 5, 7, 8, 9, 10, 11, 12, 76, 3, 24 };

                 var num76 = namelist.Where(busq => busq == 76).FirstOrDefault();
                 Console.Write("el numero Encontrado es: " + num76);

                var numberOrder = namelist.OrderBy(x => x).ToList();

                
                Console.WriteLine();
                Console.WriteLine("----------------------------");

                Console.WriteLine("Los numeros Ordenados");
                foreach (var number in numberOrder)
                    Console.WriteLine(number);
                

                var averagenumber = namelist.Average(x => x);

                Console.WriteLine();
                Console.WriteLine("----------------------------");

                Console.WriteLine("El promedio de la lista es: " + averagenumber);

                List<Beer> beer = new List<Beer>()
                {
                    new Beer(){ Alcohol = 7, quantity = 90, Name = "Pale ale", Description = "Descripcion 1", Marca = "Minerva" },
                    new Beer(){ Alcohol = 8, quantity = 350, Name = "Ticus", Description = "Descripcion 1", Marca = "Colima" },
                    new Beer(){ Alcohol = 79, quantity = 267, Name = "Stout", Description = "Descripcion 1", Marca = "Corona" },
                    new Beer(){ Alcohol = 27, quantity = 190, Name = "Angela Lisa", Description = "Descripcion 1", Marca = "Superior" },
                };

                var cervezasOrdenadas = from d in beer
                                        orderby d.Name
                                        select d;
                Console.WriteLine();
                Console.WriteLine("----------------------------");
                Console.WriteLine(" List Beer ");

                foreach (var cerv in cervezasOrdenadas)
                {
                    Console.WriteLine(cerv.Name);
                }

                var cervezasOne = from d in beer
                                        where d.Name=="Ticus"
                                        orderby d.Name
                                        select d;
                Console.WriteLine();
                Console.WriteLine("----------------------------");
                Console.WriteLine(" List One Beer in C# ");

                foreach (var cervone in cervezasOne)
                {
                    Console.WriteLine(cervone.Name);
                }

            }
        }
    }
}