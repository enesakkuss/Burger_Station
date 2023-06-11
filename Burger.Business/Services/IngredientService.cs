using Burger.DataAccess;
using BurgerStation.Business.Validators;
using BurgerStation.Domain;
using BurgerStation.Ingredients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Services
{
    public class IngredientService
    {
        private BurgerStationContext _context=new BurgerStationContext();
        private readonly IngredientValidator _validator=new IngredientValidator();

        public IEnumerable<IngredientDto> GetAll()
        {
            try
            {
                return _context.Ingredients.Select(MapToDto).ToList();
            }
            catch (Exception)
            {
                return new List<IngredientDto>();
            }
        }
        public IngredientDto GetById(int id) 
        {
            var entity = _context.Ingredients.Find(id);
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

        public CommandResult Create (IngredientDto ingredientDto)
        {
            if (ingredientDto == null)
                throw new ArgumentNullException(nameof(ingredientDto));

            try
            {
                var entity = MapToEntity(ingredientDto);
                var validationResult=_validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }
                
                _context.Ingredients.Add(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(IngredientDto ingredientDto)
        {
            var entity = MapToEntity(ingredientDto);
            try
            {
                _context.Ingredients.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(IngredientDto ingredientDto)
        {
            if (ingredientDto == null)
                throw new ArgumentNullException(nameof(ingredientDto));

            try
            {
                var entity = MapToEntity(ingredientDto);
                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.Ingredients.Update(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        internal static IngredientDto? MapToDto (Ingredient ingredient)
        {
            IngredientDto dto=null;
            if(ingredient!=null)
            {
                dto = new IngredientDto()
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    Price = ingredient.Price,
                };
            }
            return dto;
        }
        internal static Ingredient? MapToEntity(IngredientDto ingredientDto)
        {
            Ingredient entity = null;
            if (ingredientDto != null)
            {
                entity = new Ingredient()
                { 
                    Id = ingredientDto.Id,
                    Name = ingredientDto.Name,
                    Price = ingredientDto.Price,
                };
            }
            return entity;
        }
    }
}
