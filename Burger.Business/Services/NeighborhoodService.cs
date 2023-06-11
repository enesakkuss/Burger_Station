using Burger.DataAccess;
using BurgerStation.Districts;
using BurgerStation.Domain;
using BurgerStation.Neighborhoods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Services
{
    public class NeighborhoodService
    {
        private static readonly BurgerStationContext _context = new BurgerStationContext();

        public IEnumerable<NeighborhoodDto> GetAll()
        {
            try
            {
                return _context.Neighborhoods.Select(MapToDto).ToList();
            }
            catch (Exception)
            {
                return new List<NeighborhoodDto>();
            }
        }
        internal static NeighborhoodDto? MapToDto(Neighborhood neighborhood)
        {
            NeighborhoodDto dto = null;
            if (neighborhood != null)
            {
                dto = new NeighborhoodDto()
                {
                    Id = neighborhood.Id,
                    Name = neighborhood.Name,
                    DistrictId=neighborhood.DistrictId,
                };

            }
            return dto;
        }
    }
}
