using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.FinalOrders
{
    public class FinalOrderDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
    }
}
