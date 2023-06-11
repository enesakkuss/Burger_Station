using Burger.DataAccess;
using BurgerStation.Business.Validators;
using BurgerStation.Domain;
using BurgerStation.Ingredients;
using BurgerStation.Orders;
using BurgerStation.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Services
{
    public class OrderService
    {
        private readonly BurgerStationContext _context = new BurgerStationContext();
        private readonly OrderValidator _validator = new OrderValidator();
        public ProductService _productService=new ProductService();
        public CustomerService _customerService = new CustomerService();
        private readonly List<Order> _orders = new List<Order>();

        public IEnumerable<OrderDto> GetAll()
        {
            try
            {
                return _context.Orders.Select(MapToDto).ToList();
            }
            catch (Exception)
            {
                return new List<OrderDto>();
            }
        }
        public CommandResult Create(OrderDto orderDto)
        {
            if (orderDto == null)
                throw new ArgumentNullException(nameof(orderDto));

            try
            {
                var entity = MapToEntity(orderDto);

                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.Orders.Add(entity);
                _context.SaveChanges();

                int orderId = entity.Id;

                var result = CommandResult.Success();
                result.OrderId = orderId;

                return result;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public OrderDto GetById(int id)
        {
            try
            {
                var entity = _context.Orders
                    .Include(p => p.Products)
                    .SingleOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    var dto = MapToDto(entity);
                    return dto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }
        internal Order? MapToEntity(OrderDto orderDto)
        {
            Order entity = null;
            if (orderDto != null)
            {
                entity = new Order()
                {
                    Id = orderDto.Id,
                };

                entity.Products.Clear();

                foreach (var product in orderDto.Products)
                {
                    var aa = _context.Set<Product>().Find(product);
                    if (aa != null)
                    {
                        entity.Products.Add(aa);
                    }
                }
            }

            return entity;
        }

        public int OrderId(OrderDto orderDto)
        {
            Order entity = null;
            if (orderDto != null)
            {
                entity = new Order()
                {
                    Id = orderDto.Id,
                };


            }
            return entity.Id;
        }
        internal static OrderDto? MapToDto(Order order)
        {
            OrderDto dto = null;
            if (order != null)
            {
                dto = new OrderDto()
                {
                    Id = order.Id,
                    Products = order.Products.Select(i => i.Id).ToList(),
                };

            }
            return dto;
        }
        

    }
    
}
