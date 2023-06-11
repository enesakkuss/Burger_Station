using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Domain
{
    public class Order
    {
        public Order()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
