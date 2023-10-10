using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals.Models
{
    internal class Drink

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int quantity { get; set; }   
        public Drink( string name, string description, int quantity)
        {
            
            this.Name = name;
            this.Description = description;
            this.quantity = quantity;
        }

        public void Drinkme(int howdrink) 
        {
            this.quantity -= howdrink;
        }
    }
}
