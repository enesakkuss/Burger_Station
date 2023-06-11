using Burger.DataAccess;
using BurgerStation.Business.Validators;
using BurgerStation.Categories;
using BurgerStation.Domain;
using BurgerStation.FinalOrders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Services
{
    public class FinalOrderService
    {
        private BurgerStationContext _context = new BurgerStationContext();
        private readonly FinalOrderValidator _validator = new FinalOrderValidator();
        public IEnumerable<FinalOrderDto> GetAll()
        {
            try
            {
                return _context.FinalOrders.Select(MapToDto).ToList();
            }
            catch (Exception)
            {
                return new List<FinalOrderDto>();
            }
        }
        public CommandResult Create(FinalOrderDto finalOrderDto)
        {
            if (finalOrderDto == null)
                throw new ArgumentNullException(nameof(finalOrderDto));

            try
            {
                var entity = MapToEntity(finalOrderDto);

                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.FinalOrders.Add(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        internal static FinalOrderDto? MapToDto(FinalOrder finalOrder)
        {
            FinalOrderDto dto = null;
            if (finalOrder != null)
            {
                dto = new FinalOrderDto()
                {
                    Id = finalOrder.Id,
                    CustomerId = finalOrder.CustomerId,
                    OrderId=finalOrder.OrderId,
                };
            }
            return dto;
        }
        internal static FinalOrder? MapToEntity(FinalOrderDto finalOrderDto)
        {
            FinalOrder entity = null;
            if (finalOrderDto != null)
            {
                entity = new FinalOrder()
                {
                    Id = finalOrderDto.Id,
                    CustomerId = finalOrderDto.CustomerId,
                    OrderId = finalOrderDto.OrderId,
                };
            }
            return entity;
        }
    }
}
