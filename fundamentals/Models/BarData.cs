using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals.Models
{
    public class BarData
    {
        public string Name { get; set; }

        public List<Drink> drinks = new List<Drink>();

        //esto es un constructor
        public BarData(string Name)
        {
            this.Name = Name;
        }
    }
        
}
