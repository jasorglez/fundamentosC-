using fundamentals.Models;

namespace fundamentals
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Bar> bares = new List<Bar>()
            {
                new Bar("El Bar de las 3 cervezas")
                {
                    beers = new List<Beer>()
                    {
                        new Beer(){ Alcohol = 7, quantity = 90, Name = "Pale ale",  Marca = "Minerva" },
                        new Beer(){ Alcohol = 8, quantity = 350, Name = "Ticus",  Marca = "Colima" },
                        new Beer(){ Alcohol = 79, quantity = 267, Name = "Stout", Marca = "Corona" }
                    }
                },
                new Bar("El Bar 2 el de las 2 cervezas")
                {
                    beers = new List<Beer>()
                    {
                        new Beer(){ Alcohol = 7, quantity = 90, Name = "Negra Modelo",  Marca = "Modelo" },
                        new Beer(){ Alcohol = 8, quantity = 350, Name = "XX",  Marca = "Superior" },
                        new Beer(){ Alcohol = 8, quantity = 350, Name = "Stout", Marca = "Superior" },
                    }
                },
                new Bar("El Bar Nuevo")

            };

            var bar = (from d in bares
                       where d.beers.Where(c => c.Name== "Stout").Count()>0
                       select new BarData(d.Name) 
                       {
                         drinks = (from c in d.beers
                                    select new Drink(c.Name, c.quantity)
                                    ).ToList()
                       }
                       ).ToList();

            Console.WriteLine("Gelo");

        }
    }
}