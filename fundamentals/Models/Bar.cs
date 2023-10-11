using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals.Models
{
    public class Bar
    {
        public string Name { get; set; }
        
        public List<Beer> beers = new List<Beer>();

        //esto es un constructor
        public Bar(string Name)
        {
            this.Name = Name;
        }

    }
}
