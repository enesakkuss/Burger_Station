using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Domain
{
    public class Ingredient
    {
        public Ingredient() 
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
