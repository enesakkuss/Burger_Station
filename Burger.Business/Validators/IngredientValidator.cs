using BurgerStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerStation.Business.Validators
{
    internal class IngredientValidator
    {
        public ValidationResult Validate (Ingredient ingredient)
        {
            var validationResult= new ValidationResult ();
            if(string.IsNullOrWhiteSpace(ingredient.Name))
            {
                validationResult.AddError("İsim Boş Geçilemez");
            }
            return validationResult;
        }
    }
}
