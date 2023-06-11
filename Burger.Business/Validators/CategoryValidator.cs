using BurgerStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Validators
{
    internal class CategoryValidator
    {
        public ValidationResult Validate(Category category)
        {
            var validationResult=new ValidationResult();

            if(string.IsNullOrWhiteSpace(category.Name))
            {
                validationResult.AddError("İsim Boş Geçilemez");
            }

            return validationResult;
        }
    }
}
