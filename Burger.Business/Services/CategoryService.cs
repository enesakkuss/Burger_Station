using Burger.DataAccess;
using BurgerStation.Business.Validators;
using BurgerStation.Categories;
using BurgerStation.Domain;
using BurgerStation.Ingredients;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Services
{
    public class CategoryService
    {
        private BurgerStationContext _context = new BurgerStationContext();
        private readonly CategoryValidator _validator = new CategoryValidator();
        public IEnumerable<CategoryDto> GetAll()
        {
            try
            {
                return _context.Categories.Select(MapToDto).ToList();
            }
            catch (Exception)
            {
                return new List<CategoryDto>();
            }
        }
        public CategoryDto GetById(int id)
        {
            var entity = _context.Categories.Find(id);
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
        public CommandResult Create(CategoryDto categoryDto)
        {
            if (categoryDto == null)
                throw new ArgumentNullException(nameof(categoryDto));

            try
            {
                var entity = MapToEntity(categoryDto);

                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.Categories.Add(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(CategoryDto categoryDto)
        {
            var entity = MapToEntity(categoryDto);
            try
            {
                _context.Categories.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(CategoryDto categoryDto)
        {
            if (categoryDto == null)
                throw new ArgumentNullException(nameof(categoryDto));

            try
            {
                var entity = MapToEntity(categoryDto);
                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.Categories.Update(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        internal static CategoryDto? MapToDto(Category category)
        {
            CategoryDto dto = null;
            if (category != null)
            {
                dto = new CategoryDto()
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
            return dto;
        }
        internal static Category? MapToEntity(CategoryDto categoryDto)
        {
            Category entity = null;
            if (categoryDto != null)
            {
                entity = new Category()
                {
                    Id = categoryDto.Id,
                    Name = categoryDto.Name
                };
            }
            return entity;
        }

    }
}
