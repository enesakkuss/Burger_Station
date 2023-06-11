using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Domain
{
    public class FinalOrder
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

    }
}
