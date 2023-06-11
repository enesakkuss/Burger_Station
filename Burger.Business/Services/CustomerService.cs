using Burger.DataAccess;
using BurgerStation.Business.Validators;
using BurgerStation.Customers;
using BurgerStation.Domain;
using BurgerStation.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Services
{
    public class CustomerService
    {
        private BurgerStationContext _context = new BurgerStationContext();
        private readonly CustomerValidator _validator = new CustomerValidator();
        public IEnumerable<CustomerDto> GetAll()
        {
            try
            {
                return _context.Customers.Select(MapToDto).ToList();
            }
            catch (Exception)
            {
                return new List<CustomerDto>();

            }
        }
        public CustomerDto GetById(int id)
        {
            var entity = _context.Customers.Find(id);
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
        public CommandResult Create(CustomerDto customerDto)
        {
            if (customerDto == null)
                throw new ArgumentNullException(nameof(customerDto));

            try
            {
                var entity = MapToEntity(customerDto);

                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.Customers.Add(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(CustomerDto customerDto)
        {
            var entity = MapToEntity(customerDto);
            try
            {
                _context.Customers.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(CustomerDto customerDto)
        {
            if (customerDto == null)
                throw new ArgumentNullException(nameof(customerDto));

            try
            {
                var entity = MapToEntity(customerDto);
                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.Customers.Update(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        internal static CustomerDto? MapToDto(Customer customer)
        {
            CustomerDto dto = null;
            if (customer != null)
            {
                dto = new CustomerDto()
                {
                    Id = customer.Id,
                    Address = customer.Address,
                    DistrictId = customer.DistrictId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Mail = customer.Mail,
                    NeighborhoodId = customer.NeighborhoodId,
                    PhoneNumber = customer.PhoneNumber
                };
            }
            return dto;
        }
        internal static Customer? MapToEntity(CustomerDto customerDto)
        {
            Customer entity = null;
            if (customerDto != null)
            {
                entity = new Customer()
                {
                    Id = customerDto.Id,
                    Address = customerDto.Address,
                    DistrictId = customerDto.DistrictId,
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Mail = customerDto.Mail,
                    NeighborhoodId = customerDto.NeighborhoodId,
                    PhoneNumber = customerDto.PhoneNumber
                };
            }
            return entity;
        }
    }
}
