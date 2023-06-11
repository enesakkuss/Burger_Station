using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Domain
{
    public class District
    {
        public District() 
        {
            Neighborhoods=new List<Neighborhood>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Neighborhood> Neighborhoods { get; set; }



    }
}
