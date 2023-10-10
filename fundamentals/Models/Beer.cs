using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentals.Models
{
     class Beer : Drink
    {
        public Beer(int id,string Name="jose", string Description= "Descripcion", int quantity=45)
              :base(id, Name, Description, quantity)
        {

        }
    }
}
