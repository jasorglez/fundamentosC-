using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals.Models
{
    class Vino : Drink, IBeerAlcoholic
    {
        public int Alcohol { get; set; }
        public void MaxRecomendado()
        {
            Console.WriteLine("El maximo permitido son 3 Copas Vino:");
        }
        public Vino( string Name = "Vino", string Description = "Descripcion", int quantity = 145)
              : base( Name, Description, quantity)
        {

        }
    }
}
