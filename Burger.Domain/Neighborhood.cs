using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Domain
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        public Customer Customer { get; set; }
        
    }
}
