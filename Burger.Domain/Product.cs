using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Domain
{
    public class Product
    {
        public Product() 
        {
            Ingredients=new List<Ingredient>();
            Orders = new List<Order>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Ingredient> Ingredients { get; set;}
        public Category Category { get; set; }
        public ICollection<Order> Orders { get; set;}

    }
}
