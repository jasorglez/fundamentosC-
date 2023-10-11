using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals.Models
{
    public class Drink

    {

        public string Name { get; set; }

        public int quantity { get; set; }

        //esto es un constructor
        public Drink( string name, int quantity)
        {
            
            this.Name = name;
       
            this.quantity = quantity;
        }

        public void Drinkme(int howdrink) 
        {
            this.quantity -= howdrink;
        }
    }
}
