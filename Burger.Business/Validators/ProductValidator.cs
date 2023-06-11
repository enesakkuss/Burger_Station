using BurgerStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Validators
{
    internal class ProductValidator
    {
        public ValidationResult Validate(Product product)
        {
            var validationResult=new ValidationResult();
            
            if(string.IsNullOrWhiteSpace(product.Name))
            {
                validationResult.AddError("İsim Boş Geçilemez");
            }
            if(product.Price <= 0)
            {
                validationResult.AddError("Lütfen Geçerli Bir Fiyat Giriniz");
            }
            //if(product.Ingredients.Count <= 0) 
            //{
            //    validationResult.AddError("Lütfen Malzemeleri Seçiniz");
            //}
            if(product.CategoryId <=0)
            {
                validationResult.AddError("Lütfen Kategori Seçiniz");
            }
            return validationResult;
        }
    }
}
