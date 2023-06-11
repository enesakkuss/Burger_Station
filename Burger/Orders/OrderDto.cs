using BurgerStation.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public ICollection<int> Products { get; set; }

    }
}
