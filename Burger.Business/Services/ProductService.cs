using Burger.DataAccess;
using BurgerStation.Business.Validators;
using BurgerStation.Categories;
using BurgerStation.Domain;
using BurgerStation.Ingredients;
using BurgerStation.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Services
{
    public class ProductService
    {
        private static readonly BurgerStationContext _context = new BurgerStationContext();
        private readonly ProductValidator _validator = new ProductValidator();
        public  IngredientService _ingredientService=new IngredientService();
        public IEnumerable<ProductDto> GetAll()
        {
            try
            {
                return _context.Products.Select(MapToDto).ToList();
            }
            catch (Exception)
            {
                return new List<ProductDto>();
            }
        }
        public ProductDto GetById(int id)
        {
            try
            {
                var entity = _context.Products
                    .Include(p=>p.Ingredients)
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
        public CommandResult Create(ProductDto productDto)
        {
            if (productDto == null)
                throw new ArgumentNullException(nameof(productDto));

            try
            {
                var entity = MapToEntity(productDto);

                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.Products.Add(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Delete(ProductDto productDto)
        {
            var entity = MapToEntityForDelete(productDto);
            try
            {
                _context.Products.Remove(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Error(ex);
            }
        }
        public CommandResult Update(ProductDto productDto)
        {
            if (productDto == null)
                throw new ArgumentNullException(nameof(productDto));

            try
            {
                var entity = MapToEntityForUpdate(productDto);
                var validationResult = _validator.Validate(entity);
                if (validationResult.HasErrors)
                {
                    return CommandResult.Failure(validationResult.ErrorString);
                }

                _context.Products.Update(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Error(ex);
            }
        }
        internal static ProductDto? MapToDto(Product product)
        {
            ProductDto dto = null;
            if (product != null)
            {
                dto = new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    Ingredients = product.Ingredients.Select(i => i.Id).ToList()
                };
                
            }
            return dto;
        }
        internal static Product? MapToEntity(ProductDto productDto)
        {
            Product entity = null;
            if (productDto != null)
            {
                entity = new Product()
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryId = productDto.CategoryId,
                    Description = productDto.Description,
                    
                };
                entity.Ingredients.Clear();

                foreach (var ingredient in productDto.Ingredients)
                {
                    var aa = _context.Set<Ingredient>().Find(ingredient);
                    if (aa != null)
                    {
                        entity.Ingredients.Add(aa);
                    }
                }
                
            }
                return entity;
        }
        internal Product MapToEntityForUpdate(ProductDto productDto)
        {
            if (productDto == null)
                throw new ArgumentNullException(nameof(productDto));

            var entity = _context.Products
                .Include(p => p.Ingredients)
                .FirstOrDefault(p => p.Id == productDto.Id);;

            entity.Name = productDto.Name;
            entity.Price = productDto.Price;
            entity.CategoryId = productDto.CategoryId;
            entity.Description = productDto.Description;

            entity.Ingredients.Clear();

            foreach (var ingredientId in productDto.Ingredients)
            {
                var ingredient = _context.Set<Ingredient>().Find(ingredientId);
                if (ingredient != null)
                {
                    entity.Ingredients.Add(ingredient);
                }
            }

            return entity;
        }
        internal Product? MapToEntityForDelete(ProductDto productDto)
        {
            Product entity = null;
            if (productDto != null)
            {
                entity = new Product()
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryId = productDto.CategoryId,
                    Description = productDto.Description
                };


            }
            return entity;
        }
        public IEnumerable<ProductSummary> GetSummaries()
        {
            try
            {
                return _context.Products
                    .Include(p => p.Ingredients)
                    .Select(product => new ProductSummary()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        CategoryId = product.CategoryId,
                        Description = product.Description,
                        CategoryName = product.Category.Name,
                        Ingredients = product.Ingredients.Select(ingredient => new IngredientDto()
                        {
                            Id=ingredient.Id,
                            Name = ingredient.Name,
                            Price = ingredient.Price,
                        }).ToList()
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<ProductSummary>();
            }
        }

        internal Product? MapToEntityForOther(ProductDto productDto)
        {
            Product entity = null;
            if (productDto != null)
            {
                entity = new Product()
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryId = productDto.CategoryId,
                    Description = productDto.Description,

                };
                entity.Ingredients.Clear();

                foreach (var ingredient in productDto.Ingredients)
                {
                    var aa = _context.Set<Ingredient>().Find(ingredient);
                    if (aa != null)
                    {
                        entity.Ingredients.Add(aa);
                    }
                }

            }
            return entity;
        }
    }

}
