﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals.Models
{
    class Beer : Drink, IBeerAlcoholic
    {
        public int Alcohol { get; set; }
        public string ?Marca { get; set; }
        public void MaxRecomendado()
        {
           Console.WriteLine("El maximo permitido son 10 cervezas:") ;
        }
        public Beer(string Name="Coronita", string Description= "Descripcion", int quantity=45)
              :base(Name, Description, quantity)
        {

        }
    }
}
