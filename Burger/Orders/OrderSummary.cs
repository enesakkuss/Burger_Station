using BurgerStation.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Orders
{
    public class OrderSummary
    {
        public int Id { get; set; }
        public ICollection<ProductSummary> Products { get; set; }
        public string ProductName { get; set; }
    }
}
