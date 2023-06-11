using Burger.DataAccess;
using BurgerStation.Business.Validators;
using BurgerStation.Districts;
using BurgerStation.Domain;
using BurgerStation.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Services
{
    public class DistrictService
    {
        private static readonly BurgerStationContext _context = new BurgerStationContext();

        public IEnumerable<DistrictDto> GetAll()
        {
            try
            {
                return _context.Districts.Select(MapToDto).ToList();
            }
            catch (Exception)
            {
                return new List<DistrictDto>();
            }
        }
        internal static DistrictDto? MapToDto(District district)
        {
            DistrictDto dto = null;
            if (district != null)
            {
                dto = new DistrictDto()
                {
                    Id = district.Id,
                    Name = district.Name,
                };

            }
            return dto;
        }
    }
}
